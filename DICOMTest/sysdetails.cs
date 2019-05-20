using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DICOMTest
{
    public partial class sysdetails : Form
    {
        public static string CallingAE = "";
        public static string callingport;
        public static string callingip;
        public bool iniitalset = false;
        public sysdetails()
        {
            InitializeComponent();

                   }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CallingAE = textBox2.Text;
            callingport = textBox3.Text;
            callingip = textBox1.Text;
            
            this.Close();
        }

        private void sysdetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.CallingAE = textBox2.Text;
            Properties.Settings.Default.Callingip = textBox1.Text;
            Properties.Settings.Default.Callingport = textBox3.Text;
            Properties.Settings.Default.Save();
        }

        private void sysdetails_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.Callingip;
            textBox2.Text = Properties.Settings.Default.CallingAE;
            textBox3.Text = Properties.Settings.Default.Callingport;
        }
    }
    
}
