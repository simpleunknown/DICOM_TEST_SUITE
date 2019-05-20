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
using Dicom.Network;
using Dicom.Log;
using NLog.Config;
using NLog.Targets;
using System.IO;

namespace DICOMTest
{
    
    public partial class Basic_Test : Form
    {
        public bool echostat,findstat = false;
        private string studyInstanceUid;
       public static string Basic_calling_ae = "SCU";
       public string Basic_called_ae = DICOM_Test_Tool.G_CallingAE;
    public   string Basic_called_ip = DICOM_Test_Tool.G_callingip;
   public     string Basic_called_port = DICOM_Test_Tool.G_callingport;

        public Basic_Test()
        {
            InitializeComponent();
            
        }

        private void Basic_Test_Load(object sender, EventArgs e)
        {

        }

        private void echo_click(object sender, EventArgs e)
        {
            
            DicomCEchoResponse echo_response;
            DicomCEchoRequest echo_request;

           
            try
            {
                var client = new DicomClient();
                var CEcho = new DicomCEchoRequest();
                CEcho.OnResponseReceived = (DicomCEchoRequest rq, DicomCEchoResponse resp) => {

                    
                    if(resp.Status==DicomStatus.Success)
                    {
                        // Console.WriteLine(resp);
                         echostat = true;
                        MessageBox.Show("C-Echo success");

                    }
                    else
                    {
                        echostat = false;
                        MessageBox.Show("C-Echo failure");
                    }
                };
                client.NegotiateAsyncOps();
                
                 client.AddRequest(CEcho); 
               client.Send(Basic_called_ip, System.Convert.ToInt32(Basic_called_port), false, Basic_called_ae,Basic_calling_ae);
               
                
            }
            catch (Exception exc)
            {
                if (!(exc is DicomException)) Console.WriteLine(exc.ToString());
            }
             
    }

       

        private void find_click(object sender, EventArgs e)
        {
            try
            {
                bool findloop = false;
                string scanresultsfile = Directory.GetCurrentDirectory() + "\\cfindresults.txt" + " ";
                
                var cfind = DicomCFindRequest.CreateStudyQuery(patientId: "*");
                cfind.OnResponseReceived = (DicomCFindRequest rq, DicomCFindResponse rp) => {
                    if (!findloop)
                    {
                        if (rp.Status == DicomStatus.Success || rp.Status == DicomStatus.Pending)
                        {
                            MessageBox.Show(string.Format("C-Find is sucess and the results are writeen into file: {0}", scanresultsfile));
                        }
                        else if(!(rp.Status == DicomStatus.Success || rp.Status == DicomStatus.Pending))
                        {
                            MessageBox.Show(string.Format("C-Find failure {0}", rp.Status.ToString()));
                            this.Close();
                        }

                        if (!(File.Exists(scanresultsfile)))
                        {
                            // Create a file to write to.
                            using (StreamWriter sw = File.CreateText(scanresultsfile))
                            {
                                sw.WriteLine("C-Find Results\n");

                            }
                        }
                        else if (File.Exists(scanresultsfile))
                        { File.WriteAllText(scanresultsfile, String.Empty); }
                    }
                                         
                    
                    using (StreamWriter sw = File.AppendText(scanresultsfile))
                    {
                        sw.WriteLine(string.Format("Patient ID: {0}\t", rp.Dataset.Get<string>(DicomTag.PatientID)));
                        sw.WriteLine(string.Format("PatientName: {0}\n", rp.Dataset.Get<string>(DicomTag.PatientName)));
                    }
                    findstat = true;
                    findloop = true;
                };

                var client = new DicomClient();
                client.AddRequest(cfind);
                //client.Send("127.0.0.1", 11112, false, "SCU-AE", "SCP-AE");
                client.Send(Basic_called_ip, System.Convert.ToInt32(Basic_called_port), false, Basic_called_ae, Basic_calling_ae);
            }
            catch (Exception exc)
            {
                if (!(exc is DicomException)) Console.WriteLine(exc.ToString());
            }
        }

        private void move_click(object sender, EventArgs e)
        {
            var cmove = new DicomCMoveRequest("DEST-AE",  studyInstanceUid);

            var client = new DicomClient();
            client.AddRequest(cmove);
            client.Send("127.0.0.1", 11112, false, "SCU-AE", "SCP-AE");
        }

        private void store_click(object sender, EventArgs e)
        {
            var client = new DicomClient();
            OpenFileDialog dcmfile = new OpenFileDialog();
            //string infile = dcmfile.FileName;
            DialogResult result = dcmfile.ShowDialog();
            client.AddRequest(new DicomCStoreRequest(dcmfile.FileName));
            client.Send("127.0.0.1", 2500, false, "SCU", "ANY-SCP");
        }

        //code for auto echo
        public bool autoecho()
        {
            DicomCEchoResponse echo_response;
            DicomCEchoRequest echo_request;


                var client = new DicomClient();
                var CEcho = new DicomCEchoRequest();
                CEcho.OnResponseReceived = (DicomCEchoRequest rq, DicomCEchoResponse resp) => {


                    if (resp.Status == DicomStatus.Success)
                    {
                        echostat = true;
                        

                    }
                    else
                    {
                        echostat = false;
                         }
                };
                client.NegotiateAsyncOps();

                client.AddRequest(CEcho);
                client.Send(Basic_called_ip, System.Convert.ToInt32(Basic_called_port), false, Basic_called_ae, Basic_calling_ae);
                if(echostat==true)
                { return true; }
                else
                { return false; }
             
        }
        public void autofind()
        {
            bool findloop = false;
            string scanresultsfile = Directory.GetCurrentDirectory() + "\\autocfindresults.txt" + " ";

            var cfind = DicomCFindRequest.CreateStudyQuery(patientId: "*");
            cfind.OnResponseReceived = (DicomCFindRequest rq, DicomCFindResponse rp) => {
                if (!findloop)
                {
                    if (rp.Status == DicomStatus.Success || rp.Status == DicomStatus.Pending)
                    {
                        MessageBox.Show(string.Format("Patient details are writeen into file: {0}", scanresultsfile));
                    }
                    else if (!(rp.Status == DicomStatus.Success || rp.Status == DicomStatus.Pending))
                    {
                        MessageBox.Show("Cannot dump patient details");
                        this.Close();
                    }

                    if (!(File.Exists(scanresultsfile)))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(scanresultsfile))
                        {
                            sw.WriteLine("Auto C-Find Results\n");

                        }
                    }
                    else if (File.Exists(scanresultsfile))
                    { File.WriteAllText(scanresultsfile, String.Empty); }
                }


                using (StreamWriter sw = File.AppendText(scanresultsfile))
                {
                    sw.WriteLine(string.Format("Patient ID: {0}\t", rp.Dataset.Get<string>(DicomTag.PatientID)));
                    sw.WriteLine(string.Format("PatientName: {0}\n", rp.Dataset.Get<string>(DicomTag.PatientName)));
                }
                findstat = true;
                findloop = true;
            };

            var client = new DicomClient();
            client.AddRequest(cfind);
            //client.Send("127.0.0.1", 11112, false, "SCU-AE", "SCP-AE");
            client.Send(Basic_called_ip, System.Convert.ToInt32(Basic_called_port), false, Basic_called_ae, Basic_calling_ae);

        }
    }
}
