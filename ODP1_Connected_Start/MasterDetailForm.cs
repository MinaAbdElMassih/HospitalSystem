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
    public partial class MasterDetailForm : Form
    {

        //string constr = "data source=orcl; user id=scott; password=tiger";

        public MasterDetailForm()
        {
            InitializeComponent();
        }

        private void MasterDetailForm_Load(object sender, EventArgs e)
        {
            string constr = "User Id=scott;Password=tiger;Data Source=orcl";
            DataSet ds = new DataSet();

            OracleDataAdapter adapter1 = new OracleDataAdapter(" select * from LAB ", constr);
            adapter1.Fill(ds, "la");

            OracleDataAdapter adapter2 = new OracleDataAdapter("select * from TEST ", constr);
            adapter2.Fill(ds, "te");
            DataRelation r = new DataRelation("fk", ds.Tables[0].Columns["LAB_ID"],
                ds.Tables[1].Columns["LAB_ID"]);
            ds.Relations.Add(r);
            BindingSource bs_master = new BindingSource(ds, "la");
            BindingSource bs_child = new BindingSource(bs_master, "fk");
            dataGridView1.DataSource = bs_master;
            dataGridView2.DataSource = bs_child;






        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Doctor d = new Doctor();
            d.Show();
            this.Hide();
        }
    }
}
