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
    public partial class coordinator : Form
    {
        String c1, cn;
        public coordinator(String cid,String cname)
        {
            c1 = cid;
            
            InitializeComponent();

        }

        public void gridload()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            string sql = "SELECT * FROM participants p  where p.eid=(select eid from events e where e.cid ='" + c1 + "')";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "Coordinator Table");

            pview.DataSource = ds;
            pview.DataMember = "Coordinator Table";
            connection.Close();
        }
        public void comload()
        {
            premoveid.Items.Clear();
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            string Sql = "select usn from participants p  where p.eid=(select eid from events e where e.cid ='" + c1 + "')";
            connection.Open();
            SqlCommand cmd = new SqlCommand(Sql, connection);
            SqlDataReader DR = cmd.ExecuteReader();
            
            while (DR.Read())
            {
                premoveid.Items.Add(DR[0].ToString());

            }
            this.premoveid.DropDownStyle = ComboBoxStyle.DropDownList;
            connection.Close();
        }

        private void coordinator_Load(object sender, EventArgs e)
        {

            gridload();
            comload();
           
           
            
            
        }
            
        

        private void premoveid_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void clogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            login l = new login();
            l.Show();
        }

        private void premove_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
             connection.Open();
             String r = premoveid.Text;
            string Sql = "delete from participants  where usn = '" + r + "'";

            SqlCommand cmd = new SqlCommand(Sql, connection);
            cmd.ExecuteNonQuery();
            gridload();

            comload();
            
            MessageBox.Show(r + " Removed ");
           
            connection.Close();
            
        }

        private void uwinner_Click(object sender, EventArgs e)
        {
            String get = ewinner.Text;
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            connection.Open();
            //String r = premoveid.Text;
            string Sql = "update events set winner = '" + get + "'" + "where eid = (select eid from coordinator where cid = '" + c1 + "') and exists (select * from participants where eid = (select eid from coordinator where cid = '" + c1 + "') and name = '"+get+"' )";

            SqlCommand cmd = new SqlCommand(Sql, connection);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Winner Updated");

            connection.Close();
        }

        private void utime_Click(object sender, EventArgs e)
        {

            String get = etime.Text;
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            connection.Open();
            //String r = premoveid.Text;
            string Sql = "update events set time = '" + get + "'" + "where eid = (select eid from coordinator where cid = '" + c1 + "')";

            SqlCommand cmd = new SqlCommand(Sql, connection);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Time Updated");

            connection.Close();
        }

        private void uloc_Click(object sender, EventArgs e)
        {
            String get = eloc.Text;
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            connection.Open();
            //String r = premoveid.Text;
            string Sql = "update events set loc = '" + get + "'" +"where eid = (select eid from coordinator where cid = '"+c1+"')";

            SqlCommand cmd = new SqlCommand(Sql, connection);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Location Updated");

            connection.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            login l = new login();
            l.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            String get = ewinner.Text;
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            connection.Open();
            //String r = premoveid.Text;
            string Sql = "update events set winner = '" + get + "'" + "where eid = (select eid from coordinator where cid = '" + c1 + "') and exists (select * from participants where eid = (select eid from coordinator where cid = '" + c1 + "') and name = '" + get + "' )";

            SqlCommand cmd = new SqlCommand(Sql, connection);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Winner Updated");

            connection.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            String get = etime.Text;
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            connection.Open();
            //String r = premoveid.Text;
            string Sql = "update events set time = '" + get + "'" + "where eid = (select eid from coordinator where cid = '" + c1 + "')";

            SqlCommand cmd = new SqlCommand(Sql, connection);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Time Updated");

            connection.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            String get = eloc.Text;
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            connection.Open();
            //String r = premoveid.Text;
            string Sql = "update events set loc = '" + get + "'" + "where eid = (select eid from coordinator where cid = '" + c1 + "')";

            SqlCommand cmd = new SqlCommand(Sql, connection);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Location Updated");

            connection.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            connection.Open();
            String r = premoveid.Text;
            string Sql = "delete from participants  where usn = '" + r + "'";

            SqlCommand cmd = new SqlCommand(Sql, connection);
            cmd.ExecuteNonQuery();
            gridload();

            comload();

            MessageBox.Show(r + " Removed ");

            connection.Close();
        }

        
    }
}
