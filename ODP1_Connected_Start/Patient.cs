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
    public partial class Patient : Form
    {
        string ordb = "data source=orcl; user id=scott; password=tiger;";
        OracleConnection conn;
        int pssn;
        OracleDataAdapter dA;
        OracleCommandBuilder com;
        DataSet ds;
        public Patient(int x)
        {
            InitializeComponent();
            pssn = x;
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
      
        }

        private void Patient_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "get_bill";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("ssn", pssn);
            cmd.Parameters.Add("fname", OracleDbType.RefCursor,ParameterDirection.Output);

            try
            {
                OracleDataReader r = cmd.ExecuteReader();

                DataTable bill = new DataTable();
                bill.Columns.Add("B_DATE");
                bill.Columns.Add("B_AMOUNT");
                bill.Columns.Add("B_STATUS");
                bill.Columns.Add("billoverduecost");
                bill.Columns.Add("paid_date");

                DataRow row;
                while (r.Read())
                {
                    //MessageBox.Show("");
                    row = bill.NewRow();
                    row["B_DATE"] = r["B_DATE"];
                    row["B_AMOUNT"] = r["B_AMOUNT"];
                    row["B_STATUS"] = r["B_STATUS"];
                    row["billoverduecost"] = r["billoverduecost"];
                    row["paid_date"] = r["paid_date"];
                    bill.Rows.Add(row);

                }
                dataGridView1.DataSource = bill;
                r.Close();
            }
            catch
            {
                
                MessageBox.Show("No Such Records");
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select B_STATUS from Bill where Bill_ID =:id";
            cmd.Parameters.Add("id", textBox2.Text);
            //cmd.Parameters.Add("amount", textBox3.Text);
            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if ((dr[0].ToString()).Equals("paid"))
                    MessageBox.Show("Already Paid");
                else
                {
                    //   MessageBox.Show(dr[0].ToString());
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "select B_Amount from Bill where Bill_ID =:id";
                    c.Parameters.Add("id", textBox2.Text);
                    c.CommandType = CommandType.Text;

                    OracleDataReader d = c.ExecuteReader();
                    if (d.Read())
                    {
                        // MessageBox.Show(d[0].ToString());
                        if (textBox3.Text == d[0].ToString())
                        {
                            OracleCommand cc = new OracleCommand();
                            cc.Connection = conn;
                            cc.CommandText = "update Bill set B_STATUS='" + "paid" + "' where Bill_ID =:id ";
                            cc.Parameters.Add("id", textBox2.Text);
                            int r = cc.ExecuteNonQuery();
                            if (r != -1)
                            {
                                MessageBox.Show("Paid Succ");
                            }
                        }
                        else
                            MessageBox.Show("Not Accurate Amount");
                    }
                    else
                        MessageBox.Show("Invalid Bill ID");


                    /*label1.Hide();
                    textBox2.Hide();
                    textBox3.Show();
                    label3.Show();
                    OracleCommand c = new OracleCommand();
                    c.Connection = conn;
                    c.CommandText = "select B_Amount from Bill where Bill_ID =:id";
                    c.Parameters.Add("id", textBox2.Text);
                    c.CommandType = CommandType.Text;

                     OracleDataReader d = cmd.ExecuteReader();
                     while (d.Read())
                     {
                         if ((textBox3.Text.ToString()) == d[0].ToString())
                         {
 
                         }
                     }*/


                }
            }
            else
                MessageBox.Show("Invalid Bill ID");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            patient_disconnected pd = new patient_disconnected(pssn);
            pd.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Doctors_Report dr = new Doctors_Report(pssn);
            dr.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
