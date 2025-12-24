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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text)) { MessageBox.Show("Enter user name"); return; }
            else if (string.IsNullOrEmpty(txtPwd.Text)) { MessageBox.Show("Enter Password"); return; }
            else if (string.IsNullOrEmpty(txtEmail.Text)) { MessageBox.Show("Enter Email"); return; }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand checkUser = new SqlCommand("SELECT COUNT(*) FROM Member WHERE username = @username", con);
                checkUser.Parameters.AddWithValue("@username", txtUsername.Text);
                int userExists = (int)checkUser.ExecuteScalar(); // Execute the query and get the result
                SqlCommand checkEmail = new SqlCommand("select count(*) from Member where email = @email", con);
                checkEmail.Parameters.AddWithValue("@email", txtEmail.Text);
                int emailExists = (int)checkEmail.ExecuteScalar();

                if (userExists > 0)
                {
                    MessageBox.Show("Username already exists. Please choose a different username.");
                    return;
                }
                if (emailExists > 0)
                {
                    MessageBox.Show("Email already exists. Please choose a different email.");
                    return;
                }
                else
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Member(username,password,gender,email,position) values('" + txtUsername.Text + "','" + txtPwd.Text + "','" + cboGender.Text + "','" + txtEmail.Text + "', 'member')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    txtUsername.Clear();
                    txtPwd.Clear();
                    txtEmail.Clear();
                    cboGender.SelectedIndex = -1;
                    MessageBox.Show("SignUp Successful!!!");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var F2 = new Form2();
            this.Hide();
            F2.Show();
        }
    }
}
