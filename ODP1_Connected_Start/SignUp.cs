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
    public partial class SignUp : Form
    {
        string ordb = "data source=orcl; user id=scott; password=tiger;";
        OracleConnection conn;

        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into Doctor values (:id,:fname,:lname,:SID,:phone,:address)";
                cmd.Parameters.Add("id", textBox1.Text);
                cmd.Parameters.Add("fname", textBox2.Text);
                cmd.Parameters.Add("lname", textBox3.Text);
                cmd.Parameters.Add("SID", textBox4.Text);
                cmd.Parameters.Add("phone", textBox5.Text);
                cmd.Parameters.Add("adress", textBox6.Text);
                try
                {
                    int r = cmd.ExecuteNonQuery();
                    // MessageBox.Show("New Docotr is added");
                    if (r != -1)
                    {

                        MessageBox.Show("New Docotr is added");
                    }
                }
                catch
                {

                    MessageBox.Show("Invalid ID");
                }
                

            }
            else if (radioButton3.Checked)
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert_nurse";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", textBox1.Text);
                cmd.Parameters.Add("fname", textBox2.Text);
                cmd.Parameters.Add("lname", textBox3.Text);
                cmd.Parameters.Add("SID", textBox4.Text);
                cmd.Parameters.Add("phone", textBox5.Text);
                cmd.Parameters.Add("adress", textBox6.Text);
                try
                {
                    int r = cmd.ExecuteNonQuery();
                    // MessageBox.Show("New Docotr is added");
                    //if (r != -1)
                    //{

                    // MessageBox.Show("New Nurse is added");
                    // }
                    MessageBox.Show("New Nurse is added");
                }
                catch
                {
                    MessageBox.Show("Invalid ID");
                
                }

            }

        }

        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nurse n = new Nurse();
            n.Show();
            this.Hide();
        }
    }
}
