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
    public partial class PatientSignUp : Form
    {
        string ordb = "data source=orcl; user id=scott; password=tiger;";
        OracleConnection conn;

        OracleDataAdapter dA;
        OracleCommandBuilder com;
        DataSet ds;

        public PatientSignUp()
        {
            InitializeComponent();
        }

        private void PatientSignUp_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string cmdstr = "insert into patient values (:ID ,:FName,:SName,:Phone,:SSN,:Address,:RoomNumber);";
			dA = new OracleDataAdapter(cmdstr, ordb);
			dA.SelectCommand.Parameters.Add("ID", textBox1.Text);
			dA.SelectCommand.Parameters.Add("FName", textBox2.Text);
			dA.SelectCommand.Parameters.Add("SName", textBox3.Text);
			dA.SelectCommand.Parameters.Add("Phone", textBox5.Text);
			dA.SelectCommand.Parameters.Add("SSN", textBox4.Text);
			dA.SelectCommand.Parameters.Add("Address", textBox6.Text);
			dA.SelectCommand.Parameters.Add("RoomNumber", textBox7.Text);

			//ds = new DataSet();
			//dA.Fill(ds);
			OracleCommandBuilder builder = new OracleCommandBuilder(dA);
			dA.Update(ds.Tables[0]);
			*/
            try
            {
                string cmdstr = "select * from patient";
                dA = new OracleDataAdapter(cmdstr, ordb);
                ds = new DataSet();
                dA.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch
            {
                MessageBox.Show("No Available Records");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommandBuilder builder = new OracleCommandBuilder(dA);
                dA.Update(ds.Tables[0]);
                MessageBox.Show("Updated Successfully");
            }
              catch
              {
                  MessageBox.Show("Invalid");
              }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Nurse n = new Nurse();
            this.Hide();
            n.Show();
        }
    }
}
