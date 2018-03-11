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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void register_Load(object sender, EventArgs e)
        {
           //eventname.Items.Clear();
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            string Sql = "select ename from events";
            connection.Open();
            SqlCommand cmd = new SqlCommand(Sql, connection);
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                eventname.Items.Add(DR[0].ToString());

            }
            this.eventname.DropDownStyle = ComboBoxStyle.DropDownList;
            connection.Close();
        }

        private void eventname_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*string Sql = "select ename from events";
            SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=c:\users\harishchandra\documents\visual studio 2010\Projects\WindowsFormsApplication1\WindowsFormsApplication1\utsav.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlCommand cmd = new SqlCommand(Sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                eventname.Items.Add(ds.Tables[0].Rows[i][0].ToString());*/
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            home h = new home();
            h.Show();
        }

        private void reg_Click(object sender, EventArgs e)
        {
            Regex MY_EXP = new Regex("^(1[A-Z][A-Z]1)[3-6][A-Z][A-Z](([0-9][0-9][1-9])|([0-9][1-9][0-9])|([1-9][0-9][0-9]))*$");
            Match nmat = MY_EXP.Match(regusn.Text);

            if (regusn.Text.Equals("")||regname.Text.Equals("")||regcol.Text.Equals("")||eventname.Text.Equals(""))
                MessageBox.Show("Fields cannot be empty");
            else if(!nmat.Success)
                MessageBox.Show("Enter valid USN");
            else
            {
                string sql = "select eid from events where ename = '" + eventname.Text + "'";
                SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(sql, conn);
                SqlDataReader DR = cmd1.ExecuteReader();
                String s = "";
                while (DR.Read())
                {
                    s = (DR[0].ToString());

                }
                DR.Close();
                string Sql = "insert into participants values ('" + regusn.Text + "' , '" + regname.Text + "' ,'" + s + "', '" + eventname.Text + "' , '" + regcol.Text + "')";
                SqlCommand cmd = new SqlCommand(Sql, conn);
                int a = cmd.ExecuteNonQuery();
                if (a == 0)
                    MessageBox.Show("Invalid Data");
                else
                    MessageBox.Show("Registered Successfully..!!!! :)");
                this.Hide();
                home gh = new home();
                gh.Show();
            } 
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Regex MY_EXP = new Regex("^(1[A-Z][A-Z]1)[3-6][A-Z][A-Z](([0-9][0-9][1-9])|([0-9][1-9][0-9])|([1-9][0-9][0-9]))*$");
            Match nmat = MY_EXP.Match(regusn.Text);

            if (regusn.Text.Equals("") || regname.Text.Equals("") || regcol.Text.Equals("") || eventname.Text.Equals(""))
                MessageBox.Show("Fields cannot be empty");
            else if (!nmat.Success)
                MessageBox.Show("Enter valid USN");
            else
            {
                
                string sql = "select eid from events where ename = '" + eventname.Text + "'";
                SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(sql, conn);
                SqlDataReader DR = cmd1.ExecuteReader();
                String s = "";
                while (DR.Read())
                {
                    s = (DR[0].ToString());

                }
                string p = regusn.Text + s;
                DR.Close();
                string Sql = "insert into participants values ('" + regusn.Text + "' , '" + regname.Text + "' ,'" + s + "', '" + eventname.Text + "' , '" + regcol.Text + "','"+p+"')";
                SqlCommand cmd = new SqlCommand(Sql, conn);
                int a = cmd.ExecuteNonQuery();
                if (a == 0)
                    MessageBox.Show("Invalid Data");
                else
                    MessageBox.Show("Registered Successfully..!!!! :)");
                this.Hide();
                home gh = new home();
                gh.Show();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            home h = new home();
            h.Show();
        }
    }
}
