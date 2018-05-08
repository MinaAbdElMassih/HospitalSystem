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
    public partial class Nurse : Form
    {
        string ordb = "data source=orcl; user id=scott; password=tiger;";
        OracleConnection conn;
        public Nurse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            
                cmd.CommandText = "select * from Medication";
               
                cmd.CommandType = CommandType.Text;

                try
                {
                    OracleDataReader dr = cmd.ExecuteReader();

                    DataTable med = new DataTable();
                    med.Columns.Add("Med_ID");
                    med.Columns.Add("Med_Name");
                    DataRow row;
                    while (dr.Read())
                    {
                        row = med.NewRow();
                        row["Med_ID"] = dr["Med_ID"];
                        row["Med_Name"] = dr["Med_Name"];
                        med.Rows.Add(row);
                    }
                    dr.Close();
                    dataGridView1.DataSource = med;
                }
                catch
                {
                    MessageBox.Show("No Such Records");
                }
        }

        private void Nurse_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void Nurse_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = "select * from Medicationdose where MED_ID = :id";

            cmd.CommandType = CommandType.Text;


            cmd.Parameters.Add("id", textBox1.Text.ToString());

            try
            {
                OracleDataReader dr = cmd.ExecuteReader();




                //OracleDataReader dr = cmd.ExecuteReader();
                // OracleDataReader dr = cmd.ExecuteReader();
                DataTable dose = new DataTable();
                dose.Columns.Add("Med_ID");
                dose.Columns.Add("Dose");
                DataRow row;
                while (dr.Read())
                {
                   // MessageBox.Show("");
                    row = dose.NewRow();
                    row["Med_ID"] = dr["Med_ID"];
                    row["Dose"] = dr["Dose"];
                    dose.Rows.Add(row);
                }
                dr.Close();
                dataGridView2.DataSource = dose;
            }
            catch
            {
                MessageBox.Show("Invalid ID");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SignUp s = new SignUp();
            s.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();

            cmd.Connection = conn;

            cmd.CommandText = "delete from Medication where MED_ID = :id";

            cmd.CommandType = CommandType.Text;


            cmd.Parameters.Add("id", textBox2.Text.ToString());

            int r = cmd.ExecuteNonQuery();
            if (r != 0)
            {
                MessageBox.Show("Medication Deleted",r.ToString());
            }
            else
                MessageBox.Show("Invalid ID");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Update u = new Update();
            u.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete_Dose";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("medid", textBox2.Text);
            cmd.Parameters.Add("meddose", textBox3.Text);

            
            
                int dr = cmd.ExecuteNonQuery();
            if(dr!=-1)
            {
                MessageBox.Show("Dose is Deleted",dr.ToString());
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Nurse_Dissconnected f = new Nurse_Dissconnected();
            f.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PatientSignUp ps = new PatientSignUp();
            ps.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Bills b=new Bills();
            b.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            floorroomdisconnected fd = new floorroomdisconnected();
            fd.Show();
            this.Hide();
        }
    }
}
