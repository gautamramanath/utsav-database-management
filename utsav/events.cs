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
    public partial class events : Form
    {
        public events()
        {
            InitializeComponent();
        }

        private void events_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\HarishChandra\Documents\Visual Studio 2010\Projects\utsav\utsav\utsavbms.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            string sql = "SELECT e.eid as Event_Id,e.cid as Coordinator_Id,e.ename as Event_name,e.type as Event_type,e.time as Event_time,e.loc as Event_Location,c.cname as Coordinator_Name,c.contact as Coordinator_Contact,e.winner as Winner  FROM events as e,coordinator as c where e.cid=c.cid";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "Events Table");
            connection.Close();
            eventview.DataSource = ds;
            eventview.DataMember = "Events Table";
        }

        private void eventview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ehome_Click(object sender, EventArgs e)
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

        
    }
}
