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
    public partial class floorroomdisconnected : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        string constr = "User Id=scott;Password=tiger;Data Source=orcl";
        string cmdstr = "";
           
        public floorroomdisconnected()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Nurse n = new Nurse();
            this.Hide();
                n.Show();
        }

        private void floorroomdisconnected_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("please enter floor number");
            }
            else
            {
                cmdstr = "select ROOM_NUMBER from HOSPITAL_ROOM where FLOOR = :Flo ";
                adapter = new OracleDataAdapter(cmdstr, constr);
                adapter.SelectCommand.Parameters.Add("Flo", textBox1.Text);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }
    }
}
