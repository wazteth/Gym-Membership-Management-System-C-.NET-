using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment210
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text)) { MessageBox.Show("Enter user name"); return; }
            else if (string.IsNullOrEmpty(txtPwd.Text)) { MessageBox.Show("Enter Password"); return; }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Member where username = '" + txtUser.Text + "' and password = '" + txtPwd.Text + "'";
                
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                                
                if (dt.Rows.Count == 1 )
                {
                    if (dt.Rows[0][1].ToString() == txtUser.Text && dt.Rows[0][2].ToString() == txtPwd.Text)
                    {
                        string Uid = dt.Rows[0][0].ToString();
                        MessageBox.Show("Login Success");
                        var F5 = new Form5(Uid);
                        this.Hide();
                        F5.Show();
                    }
                    else MessageBox.Show("Incorrect Username or Password");

                }
                else MessageBox.Show("Incorrect Username or Password");

                txtUser.Clear();
                txtPwd.Clear();
                con.Close();
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtPwd.UseSystemPasswordChar = true;
        }

        private void cboShow_CheckedChanged(object sender, EventArgs e)
        {
            if (cboShow.Checked) txtPwd.UseSystemPasswordChar = false;
            else txtPwd.UseSystemPasswordChar = true;
        }

        private void lblSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var F3 = new Form3();
            this.Hide();
            F3.Show();
        }

        private void lblHere_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var F4 = new Form4();
            this.Hide();
            F4.Show();
        }
    }
}
