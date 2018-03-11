using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;

namespace utsav
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }
        public void gridload()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            string sql = "SELECT * FROM events";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "Coordinator Table");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Coordinator Table";
            connection.Close();
        }
        public void comload()
        {
           eremove.Items.Clear();
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            string Sql = "select eid from events";
            connection.Open();
            SqlCommand cmd = new SqlCommand(Sql, connection);
            SqlDataReader DR = cmd.ExecuteReader();
            
            while (DR.Read())
            {
                eremove.Items.Add(DR[0].ToString());

            }
            this.eremove.DropDownStyle = ComboBoxStyle.DropDownList;
            connection.Close();
        }

        private void eremove_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void adminadd_Click(object sender, EventArgs e)
        {
            this.Hide();
            addevent ae = new addevent();
            ae.Show();
        }

        private void addco_Click(object sender, EventArgs e)
        {
            this.Hide();
            addcoordinator ac = new addcoordinator();
            ac.Show();

        }

        private void adminremove_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            connection.Open();
            String r = eremove.Text;
            string Sql1 = "delete from coordinator where eid = '" + r + "'";
            string Sql = "delete from events  where eid = '" + r + "'";
            string Sql2 = "delete from participants where eid = '" + r + "'";

            SqlCommand cmd1 = new SqlCommand(Sql1, connection);
            cmd1.ExecuteNonQuery();
           
            SqlCommand cmd2 = new SqlCommand(Sql2, connection);
            cmd2.ExecuteNonQuery();
            SqlCommand cmd = new SqlCommand(Sql, connection);
            cmd.ExecuteNonQuery();
            gridload();
            gridload1();
            comload();
            comload1();

            MessageBox.Show("Event "+ r + " Removed ");

            connection.Close();
        }
        public void gridload1()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            string sql = "SELECT * FROM coordinator";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "Coordinator Table");

            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "Coordinator Table";
            connection.Close();
        }
        public void comload1()
        {
            cremove.Items.Clear();
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            string Sql = "select cid from coordinator";
            connection.Open();
            SqlCommand cmd = new SqlCommand(Sql, connection);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                cremove.Items.Add(DR[0].ToString());

            }
            this.cremove.DropDownStyle = ComboBoxStyle.DropDownList;
            connection.Close();
        }


        private void admin_Load(object sender, EventArgs e)
        {
            gridload();
            comload();
            gridload1();
            
            comload1();
        }

        private void alogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            login l = new login();
            l.Show();
        }

        private void removeco_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            connection.Open();
            String r = cremove.Text;
            string Sql1 = "delete from coordinator where cid = '" + r + "'";
           /* string Sql = "delete from events  where eid = '" + r + "'";
            string Sql2 = "delete from participants where eid = '" + r + "'";*/

            SqlCommand cmd1 = new SqlCommand(Sql1, connection);
            cmd1.ExecuteNonQuery();
            gridload();
            gridload1();
            comload();
            comload1();

            MessageBox.Show("Coordinator " + r + " Removed ");

            connection.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            addevent ae = new addevent();
            ae.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            connection.Open();
            String r = eremove.Text;
            string Sql1 = "delete from coordinator where eid = '" + r + "'";
            string Sql = "delete from events  where eid = '" + r + "'";
            string Sql2 = "delete from participants where eid = '" + r + "'";

            SqlCommand cmd1 = new SqlCommand(Sql1, connection);
            cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand(Sql2, connection);
            cmd2.ExecuteNonQuery();
            SqlCommand cmd = new SqlCommand(Sql, connection);
            cmd.ExecuteNonQuery();
            gridload();
            gridload1();
            comload();
            comload1();

            MessageBox.Show("Event " + r + " Removed ");

            connection.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            addcoordinator ac = new addcoordinator();
            ac.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            connection.Open();
            String r = cremove.Text;
            string Sql1 = "delete from coordinator where cid = '" + r + "'";
            /* string Sql = "delete from events  where eid = '" + r + "'";
             string Sql2 = "delete from participants where eid = '" + r + "'";*/

            SqlCommand cmd1 = new SqlCommand(Sql1, connection);
            cmd1.ExecuteNonQuery();
            gridload();
            gridload1();
            comload();
            comload1();

            MessageBox.Show("Coordinator " + r + " Removed ");

            connection.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            login l = new login();
            l.Show();
        }
    }
}
