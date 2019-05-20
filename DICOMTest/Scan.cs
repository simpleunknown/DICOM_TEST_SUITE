using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SaltwaterTaffy.Container;
using SaltwaterTaffy;
using System.Net;
using System.IO;


namespace DICOMTest
{
    public partial class Scan : Form
    {
        public Scan()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Scan_Load(object sender, EventArgs e)
        {
           // string Cae = DICOM_Test_Tool.G_CallingAE;
            string cport = DICOM_Test_Tool.G_callingport;
            string cip = DICOM_Test_Tool.G_callingip;
            var target = new Target(IPAddress.Parse(cip));
            //string pt = "2500";
            //ScanType sct = new ScanType();
            //sct = 0;
             
            if (!(string.IsNullOrEmpty(cport)))
            {

                ScanResult result = new Scanner(target, System.Diagnostics.ProcessWindowStyle.Hidden).PortScan(ScanType.Default, cport);

                foreach (Host i in result.Hosts)
                {
                    foreach (Port j in i.Ports)
                    {
                        if (!string.IsNullOrEmpty(j.Service.Name))
                        { //MessageBox.Show(string.Format("port {0} is running service {1}",j.PortNumber.ToString(), j.Service.Name));
                            textBox1.Text = j.Service.Name;
                        }
                        if (j.Filtered)
                        { //MessageBox.Show(string.Format("port {0} is filtered", j.PortNumber.ToString()));
                            textBox2.Text = "filtered";
                        }
                        textBox2.Text = "Open";
                    }
                }


            }
            else
            {
                string scanresultsfile = Directory.GetCurrentDirectory() + "\\networkscanresults.txt" + " ";
                
                MessageBox.Show(string.Format("since port is not selected the results are writeen into file: {0}", scanresultsfile));
                ScanResult nonresult = new Scanner(target, System.Diagnostics.ProcessWindowStyle.Hidden).PortScan();
                if (!(File.Exists(scanresultsfile)))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(scanresultsfile))
                    {
                        sw.WriteLine("Scan Results\n");

                    }
                }
                else
                {
                    File.WriteAllText(scanresultsfile, String.Empty);
                }
                foreach (Host i in nonresult.Hosts)
                {
                    //Console.WriteLine("Host: {0}", i.Address);
                    foreach (Port j in i.Ports)
                    {
                        using (StreamWriter sw = File.AppendText(scanresultsfile))
                        {
                            sw.WriteLine(string.Format("\tport {0}", j.PortNumber));
                        }
                        if (!string.IsNullOrEmpty(j.Service.Name))
                        {
                            using (StreamWriter sw = File.AppendText(scanresultsfile))
                            {
                                sw.WriteLine(string.Format(" is running {0}", j.Service.Name));
                            }
                        }

                        if (j.Filtered)
                        {
                            using (StreamWriter sw = File.AppendText(scanresultsfile))
                            {
                                sw.WriteLine(" is filtered");
                            }
                        }


                    }

                }
                textBox1.Text = "N/A";
                textBox2.Text = "N/A";
            }
           
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // returns port open/closed/filtered
        public string Autoscan()
        {
           
            string cport = DICOM_Test_Tool.G_callingport;
            string cip = DICOM_Test_Tool.G_callingip;
            var target = new Target(IPAddress.Parse(cip));
            

            if (!(string.IsNullOrEmpty(cport)))
            {

                ScanResult result = new Scanner(target, System.Diagnostics.ProcessWindowStyle.Hidden).PortScan(ScanType.Default, cport);
                if(result.Up==0)
                { return "closed"; }

                foreach (Host i in result.Hosts)
                {
                    foreach (Port j in i.Ports)
                    {

                        if (j.Filtered)
                        {
                            return "filtered";
                        }
                        else
                        {
                            return "open";
                        }
                    }
                }


            }
           
            return "closed"; 
           
               
            

        }
    }
}
