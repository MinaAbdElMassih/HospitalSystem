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
    public partial class Doctor : Form
    {
        string ordb = "data source=orcl; user id=scott; password=tiger;";
        OracleConnection conn;

        public Doctor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Report1 r = new Report1();
            r.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "find";
            cmd.CommandType = CommandType.StoredProcedure;
            //inputeparamaters
            cmd.Parameters.Add("test_id", int.Parse(textBox1.Text));
            //outputeparamaters
            //cmd.Parameters.Add("testname", OracleDbType.Varchar2, ParameterDirection.Output);
            //cmd.Parameters.Add("testresult", OracleDbType.Varchar2, ParameterDirection.Output);
            cmd.Parameters.Add("testdate", OracleDbType.Date, ParameterDirection.Output);
            cmd.Parameters.Add("labsid", OracleDbType.Int32, ParameterDirection.Output);


            try
            {
                cmd.ExecuteNonQuery();
                textBox2.Text = cmd.Parameters["testdate"].Value.ToString();
                textBox3.Text = cmd.Parameters["labsid"].Value.ToString();

            }
            catch
            {
                MessageBox.Show("There Is No Such Test");
            }
           

            /*if (r.Read())
            {
            }*/


            /*DataTable test = new DataTable();
            //test.Columns.Add("test_name");
            //test.Columns.Add("test_result");
            test.Columns.Add("tresulet_date");

            DataRow row;
            while (r.Read())
            {
                MessageBox.Show("");
                row = test.NewRow();
                //row["test_name"] = r["test_name"];
                //row["test_result"] = r["test_result"];
                row["tresulet_date"] = r["tresulet_date"];
                test.Rows.Add(row);
            }
            dataGridView1.DataSource = test;
            r.Close();*/


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            MasterDetailForm f = new MasterDetailForm();
            f.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
        
    }
}
