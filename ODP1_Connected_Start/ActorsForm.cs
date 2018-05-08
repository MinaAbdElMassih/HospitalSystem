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
    public partial class ActorsForm : Form
    {
        string ordb = "data source=orcl; user id=scott; password=tiger;";
        OracleConnection conn;
        public ActorsForm()
        {
            InitializeComponent();
        }

        private void ActorsForm_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select ActorID from Actors";
            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmb_ID.Items.Add(dr[0]);
            }
            dr.Close();


        }

        private void cmb_ID_SelectedIndexChanged(object sender, EventArgs e)
        {

            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "select * from Actors where ActorID=:id";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("id", cmb_ID.SelectedItem.ToString());
            OracleDataReader dr = c.ExecuteReader();
            if (dr.Read())
            {
                txt_Name.Text = dr[1].ToString();
                txt_Gender.Text = dr[2].ToString();
            }
            dr.Close();


        }
    }
}
