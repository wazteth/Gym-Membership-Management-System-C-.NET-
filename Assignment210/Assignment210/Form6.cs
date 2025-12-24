using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment210
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var F2 = new Form2();
            this.Hide();
            F2.Show();
        }

        private void btnAdminManagement_Click(object sender, EventArgs e)
        {
            var F7 = new Form7();
            this.Hide();
            F7.Show();
        }

        private void btnTManagement_Click(object sender, EventArgs e)
        {
            var F8 = new Form8();
            this.Hide();
            F8.Show();
        }

        private void btnDCManagement_Click(object sender, EventArgs e)
        {
            var F9 = new Form9();
            this.Hide();
            F9.Show();
        }

        private void btnEnrollManagement_Click(object sender, EventArgs e)
        {
            var F10 = new Form10();
            this.Hide();
            F10.Show();
        }
    }
}
