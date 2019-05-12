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

namespace DICOMTest
{
    public partial class DICOM_Test_Tool : Form
    {
        public DICOM_Test_Tool()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Basic_Test bt = new Basic_Test();
            bt.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Scan st = new Scan();
            st.Show();

        }


    }
}
