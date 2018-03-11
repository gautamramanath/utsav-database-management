using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace utsav
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void buttonevent_Click(object sender, EventArgs e)
        {
            events eve = new events();
            eve.Show();
            this.Hide();
        }

        private void buttonreg_Click(object sender, EventArgs e)
        {
            register eve = new register();
            eve.Show();
            this.Hide();
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            login eve = new login();
            eve.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            events eve = new events();
            eve.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            register eve = new register();
            eve.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            login eve = new login();
            eve.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
