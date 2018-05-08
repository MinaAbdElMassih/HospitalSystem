using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ODP1_Connected_Start
{
    public partial class Bills : Form
    {
        CrystalReport3 cr;
        public Bills()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void Bills_Load(object sender, EventArgs e)
        {
            cr = new CrystalReport3();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = cr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nurse n = new Nurse();
            this.Hide();
            n.Show();
        }
    }
}
