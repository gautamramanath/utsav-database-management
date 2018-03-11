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
    public partial class login : Form
    {
        
            
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void adminlogin_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from admin where id = '"+adminuser.Text+"'and password ='"+adminpass.Text+"'",connection);
            SqlDataReader dr;
            
                dr = cmd.ExecuteReader();
            
            
            int count = 0;
            while (dr.Read())
            {
                count += 1;
            }
            if (count == 1)
            {
                MessageBox.Show("Login Successful");
                this.Hide();
                admin a = new admin();
                a.Show();
                
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
            connection.Close();
        }

        private void adminpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void cologin_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from coordinator where cid = '" + couser.Text + "'and password ='" + copass.Text + "'", connection);
            SqlDataReader dr;

            dr = cmd.ExecuteReader();


            int count = 0;
            while (dr.Read())
            {
                count += 1;
            }
            dr.Close();
            if (count == 1)
            {
                MessageBox.Show("Login Successful");
                this.Hide();
                SqlCommand cmd1 = new SqlCommand("select cname from coordinator where cid = '" + couser.Text + "'and password ='" + copass.Text + "'", connection);
                SqlDataReader dr1;
                
                dr1 = cmd1.ExecuteReader();
                
                coordinator a = new coordinator(couser.Text,"");
                a.ShowDialog();

            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void buttonhome_Click(object sender, EventArgs e)
        {
            this.Hide();
            home h = new home();
            h.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            home h = new home();
            h.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from admin where id = '" + adminuser.Text + "'and password ='" + adminpass.Text + "'", connection);
            SqlDataReader dr;

            dr = cmd.ExecuteReader();


            int count = 0;
            while (dr.Read())
            {
                count += 1;
            }
            if (count == 1)
            {
                MessageBox.Show("Login Successful");
                this.Hide();
                admin a = new admin();
                a.Show();

            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
            connection.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            connection.Open();
            SqlCommand cmd = new SqlCommand("select * from coordinator where cid = '" + couser.Text + "'and password ='" + copass.Text + "'", connection);
            SqlDataReader dr;

            dr = cmd.ExecuteReader();


            int count = 0;
            while (dr.Read())
            {
                count += 1;
            }
            dr.Close();
            if (count == 1)
            {
                MessageBox.Show("Login Successful");
                this.Hide();
                SqlCommand cmd1 = new SqlCommand("select cname from coordinator where cid = '" + couser.Text + "'and password ='" + copass.Text + "'", connection);
                SqlDataReader dr1;

                dr1 = cmd1.ExecuteReader();

                coordinator a = new coordinator(couser.Text, "");
                a.ShowDialog();

            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }
    }
}
