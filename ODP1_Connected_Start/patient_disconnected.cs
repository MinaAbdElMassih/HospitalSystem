using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace ODP1_Connected_Start
{
    public partial class patient_disconnected : Form
    {
        string ordb = "data source=orcl; user id=scott; password=tiger;";
        //OracleConnection conn;
        int pssn;
        OracleDataAdapter dA;
        DataSet ds;
        public patient_disconnected(int x)
        {
            InitializeComponent();
            pssn = x;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string cmdstr = "select * from lab";
                dA = new OracleDataAdapter(cmdstr, ordb);
                ds = new DataSet();
                dA.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
            }
            catch
            {
                MessageBox.Show("No Available Records");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Patient p = new Patient(pssn);
            p.Show();
            this.Hide();
        }

        private void patient_disconnected_Load(object sender, EventArgs e)
        {

        }
    }
}
