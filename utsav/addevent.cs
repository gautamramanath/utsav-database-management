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
    public partial class addevent : Form
    {
        public addevent()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            
            string txt="";
            if(sports.Checked) txt = "sports";
            else if(technical.Checked) txt="technical";
            else if(cultural.Checked) txt="cultural";

            if (eid.Text.Equals("") || ename.Text.Equals("") || loc.Text.Equals("") || cid.Text.Equals("") || time.Text.Equals("") || txt.Equals(""))
                MessageBox.Show("Fields cannot be empty");
            else
            {

                SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                conn.Open();
                /*SqlCommand cmd1 = new SqlCommand(sql, conn);
                SqlDataReader DR = cmd1.ExecuteReader();
                String s = "";
                while (DR.Read())
                {
                    s = (DR[0].ToString());

                }
                DR.Close();*/
                string Sql = "insert into events values ('" + eid.Text + "' , '" + cid.Text + "' ,'" + ename.Text + "', '" + txt + "' , '" + time.Text + "' ,'" + loc.Text + "', NULL)";
                SqlCommand cmd = new SqlCommand(Sql, conn);
                int a = cmd.ExecuteNonQuery();
                if (a == 0)
                    MessageBox.Show("Invalid Data");
                else
                {
                    MessageBox.Show("Event Added Successfully..!!!! :)");
                    this.Hide();
                    admin x = new admin();
                    x.Show();
                }
            } 
        
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin a = new admin();
            a.Show();
        }

        private void cultural_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            string txt = "";
            if (sports.Checked) txt = "sports";
            else if (technical.Checked) txt = "technical";
            else if (cultural.Checked) txt = "cultural";

            if (eid.Text.Equals("") || ename.Text.Equals("") || loc.Text.Equals("") || cid.Text.Equals("") || time.Text.Equals("") || txt.Equals(""))
                MessageBox.Show("Fields cannot be empty");
            else
            {

                SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                conn.Open();
                /*SqlCommand cmd1 = new SqlCommand(sql, conn);
                SqlDataReader DR = cmd1.ExecuteReader();
                String s = "";
                while (DR.Read())
                {
                    s = (DR[0].ToString());

                }
                DR.Close();*/
                string Sql = "insert into events values ('" + eid.Text + "' , '" + cid.Text + "' ,'" + ename.Text + "', '" + txt + "' , '" + time.Text + "' ,'" + loc.Text + "', NULL)";
                SqlCommand cmd = new SqlCommand(Sql, conn);
                int a = cmd.ExecuteNonQuery();
                if (a == 0)
                    MessageBox.Show("Invalid Data");
                else
                {
                    MessageBox.Show("Event Added Successfully..!!!! :)");
                    this.Hide();
                    admin x = new admin();
                    x.Show();
                }
            } 
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin a = new admin();
            a.Show();
        }
    }
}
