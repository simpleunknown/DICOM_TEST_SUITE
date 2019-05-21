using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dicom;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;



namespace DICOMTest
{
    public partial class DICOM_TEST : Form
    {
        public static string labelprog=" ";
              
        public static string G_CallingAE = "";
        public static string G_callingport;
        public static string G_callingip;
        public bool sysdetset = false;
       public static List<string> ciphers = new List<string>();
        public static List<string> atciphers = new List<string>();
        public static int ciphercount=0;
        public static string[] supportedciphers = { 
"RSA_WITH_AES_128_GCM_SHA256",
"RSA_WITH_AES_128_GCM_SHA256",
"RSA_WITH_AES_256_GCM_SHA384",
"RSA_WITH_AES_256_GCM_SHA384",
"RSA_WITH_CAMELLIA_256_GCM_SHA384 ",
"RSA_WITH_CAMELLIA_128_GCM_SHA256",
"ECDSA_WITH_AES_256_GCM_SHA384",
"ECDSA_WITH_CAMELLIA_256_GCM_SHA384",
"RSA_WITH_CAMELLIA_256_GCM_SHA384",
"ECDSA_WITH_AES_128_GCM_SHA256",
"ECDSA_WITH_CAMELLIA_128_GCM_SHA256",
"RSA_WITH_CAMELLIA_128_GCM_SHA25" 
};
        public static string[] unsupportedssl = { "TLSv1.0", "TLSv1.1", "SSLv3.0", "SSLv2.0" };
        public static string[] supportedssl = { "TLSv1.2", "TLSv1.3" };
        public static bool sslcheckstatus=false;
        public static  bool supportlowerver;
        public static List<bool> ciphercontained = new List<bool>();
        public static List<bool> atciphercontained = new List<bool>();
        public static int sslcount;
        
        public DICOM_TEST()
        {
            InitializeComponent();
        }
        


        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Basic_Test.Enabled = false;
            Basic_Test.BackColor=Color.Chocolate;
            label3.Text = "Basic test initiated";
            Basic_Test bt = new Basic_Test();
            bt.Show();
            Basic_Test.BackColor = default(Color);
            Basic_Test.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Scan_Test.Enabled = false;
            Scan_Test.BackColor = Color.Chocolate;
            label3.Text = "Scan initiated";
            Scan st = new Scan();
             st.Show();
            Scan_Test.Enabled = true;
            Scan_Test.BackColor = default(Color);
            Scan_Test.Enabled = true;

        }

        private void Autoscanbutton_Click(object sender, EventArgs e)
        {
            // write result to Log.........................
            string dtn = DateTime.Now.ToString();
            string AutoscanLog = Directory.GetCurrentDirectory() + "\\Autoscan_"+DateTime.Now.ToFileTime()+".txt";
            
            using (StreamWriter sw = File.CreateText(AutoscanLog))
            {
                sw.WriteLine("IP address:{0}\n\n",G_callingip);
            }
            //................................
            button3.Enabled = false;
            label3.Text = "Auto Scan initiated";
            autoscanbox ab = new autoscanbox();
           // ab.ShowDialog();
            Scan ast = new Scan();
            string asr=ast.Autoscan();
            if (asr.Contains("closed"))
            {
                progressBar1.Value = 100;
                MessageBox.Show("port closed cant proceed further");
                this.Close();
                using (StreamWriter sw = File.AppendText(AutoscanLog))
                {
                    sw.WriteLine(string.Format("Port status: Closed \n"));
                    
                }
            }
            progressBar1.Value = 30;
            MessageBox.Show("Found open/Filtered Port proceeding to test Secure DICOM");
            using (StreamWriter sw = File.AppendText(AutoscanLog))
            {
                sw.WriteLine(string.Format("Port status: Open\\Filtered \n"));

            }

            Basic_Test abt = new Basic_Test();
            bool autecho=abt.autoecho();
            if( autecho==true)
            {
                using (StreamWriter sw = File.AppendText(AutoscanLog))
                {
                    sw.WriteLine(string.Format("Secure DICOM: False \n"));

                }
                progressBar1.Value = 50;
                MessageBox.Show("C-Echo success Proceeding to dump patient details");
                using (StreamWriter sw = File.AppendText(AutoscanLog))
                {
                    sw.WriteLine(string.Format("C-Echo status: Sucess \n"));

                }

                abt.autofind(AutoscanLog);
                progressBar1.Value = 70;
            }
            else if( autecho==false)
            {
                using (StreamWriter sw = File.AppendText(AutoscanLog))
                {
                    sw.WriteLine(string.Format("Secure DICOM: True \n"));

                }
                progressBar1.Value = 70;
                MessageBox.Show("C-Echo fail proceeding to test SSL/TLS cipher suites");
                
                bool atsslcheck = autossl();
                if (atsslcheck == true)
                {
                    progressBar1.Value = 100;
                    MessageBox.Show("Meets the DICOM Standars");
                    using (StreamWriter sw = File.AppendText(AutoscanLog))
                    {
                        sw.WriteLine(string.Format("Supported Cipher suites of DICOM Standard: True \n"));

                    }

                }
                else
                {
                    progressBar1.Value = 100;
                    MessageBox.Show("Doesnt meet the Secure DICOM Standards");
                    using (StreamWriter sw = File.AppendText(AutoscanLog))
                    {
                        sw.WriteLine(string.Format("Supported Cipher suites of DICOM Standard: False \n"));

                    }

                }
                
            }

            MessageBox.Show("Test complete");
            this.Close();
            using (StreamWriter sw = File.AppendText(AutoscanLog))
            {
                sw.WriteLine(string.Format("Test complete : True \n"));

            }
            button3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Text = "Entering Config details";
            sysdetails sysconf = new sysdetails();
            sysconf.ShowDialog();
            G_CallingAE = sysdetails.CallingAE;
            G_callingport = sysdetails.callingport;
            G_callingip = sysdetails.callingip;
            sysdetset = true;
            
        }

        private void SSL_Click_1(object sender, EventArgs e)
        {
            SSL_button.Enabled = false;
            SSL_button.BackColor = Color.Chocolate;
            label3.Text = "SSL Scan initiated";
            if (sysdetset == true)
            {
                
                string strCmdText;
                SSLResults sslresform = new SSLResults();
//                sslresform.ShowDialog();
                ProcessStartInfo startinfo = new ProcessStartInfo();
                Process cmd = new Process();
                
                strCmdText = "/C" + " " + "TestSSLServer2.exe -json " + " \"" + Directory.GetCurrentDirectory() + "\\aresult.json" + "\" " + G_callingip + " " + G_callingport;
               
                 cmd.StartInfo.WorkingDirectory = @"C:\Windows\System32";
                
                cmd.StartInfo.FileName = "cmd.exe";
               
                cmd.StartInfo.Arguments = strCmdText.ToString();
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.Start();
                cmd.WaitForExit();
                // parsing json output of test ssl server
                string jsonfile = Directory.GetCurrentDirectory() + "\\aresult.json";
              

                // read JSON directly from a file
                using (StreamReader jfile = File.OpenText(jsonfile))
                using (JsonTextReader reader = new JsonTextReader(jfile))
                {
                    JObject o2 = (JObject)JToken.ReadFrom(reader);
                    IList<string> keys = o2.Properties().Select(p => p.Name).ToList();
                    
                    if ((keys.Any(l => l.Contains("TLS"))) || (keys.Any(l => l.Contains("SSL"))))
                    {
                        sslcheckstatus = true;
                    }
                    else
                    {
                        sslcheckstatus = false;
                    }
                    if (sslcheckstatus == false)
                    { MessageBox.Show("Could not detect cipher suites, please re run");
                        this.Close();

                    }
                    string foundkeys = keys[3].ToString();// write code to check if TLS1.0/etc is upported exit
                     if (foundkeys.Contains("TLSv1.0")||foundkeys.Contains("TLSv1.1")||foundkeys.Contains("SSLv3.0")||foundkeys.Contains("SSLv2.0"))
                        {
                        supportlowerver = true;
                        MessageBox.Show(String.Format("The SSL/TLS version is unsupported use only TLSv1.2 or above, the version detected is {0}", foundkeys));
                        this.Close();
                    }
                    if(supportlowerver==false)
                    {
                        
                        MessageBox.Show(String.Format("The SSL/TLS version detected is supported , the version is {0}", foundkeys));
                          //loop for ciphers
                            
                            
                                         


                        foreach (var st in o2.SelectTokens("['TLSv1.2'].suites[0].name"))
                        {
                            ciphers.Add(st.ToString());
                            
                        }
                        ciphers.ToArray();

                        foreach( string cp in ciphers)
                        {
                            ciphercontained.Add(supportedciphers.Contains(cp));
                        }
                        ciphercontained.ToArray();

                          

                        // code to match cipher suites with dicom standards
                        if (!(ciphercontained.Contains(false)))
                        {
                            MessageBox.Show(String.Format("The ciphersuite detected matches as per DICOM standards and cipher suite is {0}", ciphers));
                        }
                        else
                        {
                            string todisplay = string.Join(Environment.NewLine, supportedciphers);
                            string todisplayciphers = string.Join(Environment.NewLine, ciphers);

                            MessageBox.Show(String.Format("The ciphersuite detected does not matche as per DICOM standards and dicom supported cipher suites are {0}", todisplay));
                            MessageBox.Show(String.Format("The cipher suite detected is {0}", todisplayciphers));
                        }

                    }

                }



            }
            else
            {
                MessageBox.Show("Please enter the details in config"); }
            SSL_button.BackColor = default(Color);
            SSL_button.Enabled = true;

        }

        public bool autossl()
        {
            Scan_Test.BackColor = Color.Chocolate;
            bool setssl=true;
            string strCmdText;
            SSLResults sslresform = new SSLResults();
            ProcessStartInfo startinfo = new ProcessStartInfo();
            Process cmd = new Process();
            
            strCmdText = "/C" + " " + "TestSSLServer2.exe -json " + " \"" + Directory.GetCurrentDirectory() + "\\aresult.json" + "\" " + G_callingip + " " + G_callingport;
            
            cmd.StartInfo.WorkingDirectory = @"C:\Windows\System32";
            
            cmd.StartInfo.FileName = "cmd.exe";
            
            cmd.StartInfo.Arguments = strCmdText.ToString();
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.Start();
            cmd.WaitForExit();
            
            string jsonfile = Directory.GetCurrentDirectory() + "\\aresult.json" + " ";
           
            using (StreamReader jfile = File.OpenText(jsonfile))
            using (JsonTextReader reader = new JsonTextReader(jfile))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                IList<string> keys = o2.Properties().Select(p => p.Name).ToList();
                //string rem= o2.SelectToken("TLSv1.2[1]").ToString();
                //Console.WriteLine(o2.SelectToken("TLSv1.2"));
                // string test= o2.SelectToken("TLSv1.2.suites[0].name").ToString();
                if ((keys.Any(l => l.Contains("TLS"))) || (keys.Any(l => l.Contains("SSL"))))
                {
                    sslcheckstatus = true;
                }
                else
                {
                    sslcheckstatus = false;
                }
                if (sslcheckstatus == false)
                {
                    setssl= false;

                }
                string foundkeys = keys[3].ToString();// write code to check if TLS1.0/etc is upported exit
                if (foundkeys.Contains("TLSv1.0") || foundkeys.Contains("TLSv1.1") || foundkeys.Contains("SSLv3.0") || foundkeys.Contains("SSLv2.0"))
                {
                    setssl = false;
                }
                if (supportlowerver == false)
                {



                    foreach (var st in o2.SelectTokens("['TLSv1.2'].suites[0].name"))
                    {
                        atciphers.Add(st.ToString());

                    }
                    atciphers.ToArray();

                    foreach (string cp in atciphers)
                    {
                        atciphercontained.Add(supportedciphers.Contains(cp));
                    }
                    atciphercontained.ToArray();



                    // code to match cipher suites with dicom standards
                    if (!(atciphercontained.Contains(false)))
                    {
                        setssl = true;
                    }
                    else
                    {
                        string todisplay = string.Join(Environment.NewLine, supportedciphers);
                        string todisplayciphers = string.Join(Environment.NewLine, atciphers);

                        setssl = false;
                    }

                }

            }
            return setssl;
            Scan_Test.BackColor = default(Color);

        }

       
        
        
    }
}
