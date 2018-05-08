using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;


namespace ODP1_Connected_Start
{
    public partial class Doctors_Report : Form
    {
        int pssn;
        CrystalReport2 cr;
        public Doctors_Report(int x)
        {
            InitializeComponent();
            pssn = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cr.SetParameterValue(0, comboBox1.SelectedItem);
            crystalReportViewer1.ReportSource = cr;
           // cr.Close();
        }

        private void Doctors_Report_Load(object sender, EventArgs e)
        {
            cr = new CrystalReport2();
           // cr.OpenSubreport("CrystalReport2");
            foreach (ParameterDiscreteValue v in cr.ParameterFields[0].DefaultValues)
            {
                comboBox1.Items.Add(v.Value);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Patient p = new Patient(pssn);
            this.Hide();
            p.Show();
        }
    }
}
