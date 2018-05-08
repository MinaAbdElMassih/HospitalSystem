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
    public partial class Nurse_Dissconnected : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        string constr = "User Id=scott;Password=tiger;Data Source=orcl";
        string cmdstr = "";
        public Nurse_Dissconnected()
        {
            InitializeComponent();
        }

        private void Nurse_Dissconnected_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cmdstr = "select * from Hospital_Room_Bed where STATUS = '" + "ava" + "' ";
                adapter = new OracleDataAdapter(cmdstr, constr);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch
            {
                MessageBox.Show("No Available Records");
            }

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
