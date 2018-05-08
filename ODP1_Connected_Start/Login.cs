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
    public partial class Login : Form
    {
        string ordb = "data source=orcl; user id=scott; password=tiger;";
        OracleConnection conn;

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            //cmd.Parameters.Add("id", (textBox1.Text.ToString()));
            if (radioButton1.Checked)
            {
                cmd.CommandText = "select Doc_ID from Doctor where SID=:id ";
                cmd.Parameters.Add("id", textBox1.Text.ToString());
                cmd.CommandType = CommandType.Text;

                OracleDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Doctor d = new Doctor();
                    d.Show();
                    this.Hide();
                }
                else
                MessageBox.Show("Invalid Credentials");
                dr.Close();
            }
            else if (radioButton2.Checked)
            {
                cmd.CommandText = "select pat_id from patient where SSN = :id ";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("id", textBox1.Text.ToString());
                //cmd.CommandType = CommandType.Text;

                OracleDataReader dr = cmd.ExecuteReader();
                //  MessageBox.Show(textBox1.Text.ToString());
                if (dr.Read())
                {
                    //MessageBox.Show(textBox1.Text.ToString());
                    Patient p = new Patient(int.Parse(textBox1.Text));
                    p.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Invalid Credentials");
                dr.Close();
            }
            else if (radioButton3.Checked)
            {
                cmd.CommandText = "select N_ID from nurse where SID = :id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("id", textBox1.Text.ToString());
                OracleDataReader dr = cmd.ExecuteReader();

                //  MessageBox.Show( textBox1.Text.ToString());
                if (dr.Read())
                {

                    Nurse n = new Nurse();
                    n.Show();
                    this.Hide();

                }
                else
                    MessageBox.Show("Invalid Credentials");
                dr.Close();
            }
            
            

        }

        private void Login_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
