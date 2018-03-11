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
using System.Text.RegularExpressions;

namespace utsav
{
    public partial class addcoordinator : Form
    {
        public addcoordinator()
        {
            InitializeComponent();
        }

        private void cadd_Click(object sender, EventArgs e)
        {
            Regex MY_EXP = new Regex("^(1[A-Z][A-Z]1)[3-6][A-Z][A-Z](([0-9][0-9][1-9])|([0-9][1-9][0-9])|([1-9][0-9][0-9]))*$");
            Match nmat = MY_EXP.Match(cusn.Text);
            Regex con = new Regex("^(9|8|7)[0-9]{9}");
            Match nmat1 = con.Match(contact.Text);
            if (cid.Text.Equals("") || ceid.Text.Equals("") || cname.Text.Equals("") || cpassword.Text.Equals("") || cusn.Text.Equals("") || contact.Text.Equals(""))
                MessageBox.Show("Fields cannot be empty");
            else if (!cpassword.Text.Equals(rpassword.Text))
                MessageBox.Show("Passwords do not match");
            else if (cpassword.Text.Length < 8)
                MessageBox.Show("Password should be minimum 8 characters");
            else if (cpassword.Text.Length > 12)
                MessageBox.Show("Password should be maximum 12 characters");
            else if (!nmat.Success)
                MessageBox.Show("Enter valid USN");
            else if (!nmat1.Success)
                MessageBox.Show("Enter a valid contact no");
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
                string Sql = "insert into coordinator values ('" + cid.Text + "' , '" + cname.Text + "' ,'" + ceid.Text + "', '" + cusn.Text + "' , '" + cpassword.Text + "' ,'" + contact.Text + "')";
                SqlCommand cmd = new SqlCommand(Sql, conn);
                int a= cmd.ExecuteNonQuery();
                if (a == 0)
                    MessageBox.Show("Invalid Data");
                else
                {
                    MessageBox.Show("Coordinator Added Successfully..!!!! :)");
                    this.Hide();
                    admin x = new admin();
                    x.Show();
                }
                
            } 
        
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin a = new admin();
            a.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Regex MY_EXP = new Regex("^(1[A-Z][A-Z]1)[3-6][A-Z][A-Z](([0-9][0-9][1-9])|([0-9][1-9][0-9])|([1-9][0-9][0-9]))*$");
            Match nmat = MY_EXP.Match(cusn.Text);
            Regex con = new Regex("^(9|8|7)[0-9]{9}");
            Match nmat1 = con.Match(contact.Text);
            if (cid.Text.Equals("") || ceid.Text.Equals("") || cname.Text.Equals("") || cpassword.Text.Equals("") || cusn.Text.Equals("") || contact.Text.Equals(""))
                MessageBox.Show("Fields cannot be empty");
            else if (!cpassword.Text.Equals(rpassword.Text))
                MessageBox.Show("Passwords do not match");
            else if (cpassword.Text.Length < 8)
                MessageBox.Show("Password should be minimum 8 characters");
            else if (cpassword.Text.Length > 12)
                MessageBox.Show("Password should be maximum 12 characters");
            else if (!nmat.Success)
                MessageBox.Show("Enter valid USN");
            else if (!nmat1.Success)
                MessageBox.Show("Enter a valid contact no");
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
                string Sql = "insert into coordinator values ('" + cid.Text + "' , '" + cname.Text + "' ,'" + ceid.Text + "', '" + cusn.Text + "' , '" + cpassword.Text + "' ,'" + contact.Text + "')";
                SqlCommand cmd = new SqlCommand(Sql, conn);
                int a = cmd.ExecuteNonQuery();
                if (a == 0)
                    MessageBox.Show("Invalid Data");
                else
                {
                    MessageBox.Show("Coordinator Added Successfully..!!!! :)");
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
