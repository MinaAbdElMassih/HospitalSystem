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
    public partial class Update : Form
    {

        string ordb = "data source=orcl; user id=scott; password=tiger;";
        OracleConnection conn;
        public Update()
        {
            InitializeComponent();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;
            if (radioButton1.Checked)
            {
                cmd.CommandText = "update_doc";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("id", textBox1.Text.ToString());
                cmd.Parameters.Add("phone", textBox5.Text.ToString()); 
                cmd.Parameters.Add("address", textBox6.Text.ToString());

                try
                {
                    int r = cmd.ExecuteNonQuery();

                    MessageBox.Show("Doctor Updated");
                }
                catch
                {
                    MessageBox.Show("Invalid ID");
                }
                
            }
            else if (radioButton2.Checked)
            {
                cmd.CommandText = "update nurse set phone =:p , address=:a where n_id=:id";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("phone", textBox5.Text);
                cmd.Parameters.Add("address", textBox6.Text);
                cmd.Parameters.Add("id", textBox1.Text);
                

                try
                {
                    int r = cmd.ExecuteNonQuery();

                    MessageBox.Show("Nurse Updated");
                }
                catch
                {
                    MessageBox.Show("Invalid ID");
                }

            }
        }

        private void Update_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
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
