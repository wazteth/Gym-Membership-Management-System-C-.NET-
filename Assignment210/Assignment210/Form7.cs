using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Assignment210
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var F6 = new Form6();
            this.Hide();
            F6.Show();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            // Show a confirmation message box
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to add this member?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Check if the user clicked "Yes"
            if (dialogResult == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(txtUsername.Text)) { MessageBox.Show("Enter user name"); return; }
                else if (string.IsNullOrEmpty(txtPwd.Text)) { MessageBox.Show("Enter Password"); return; }
                else if (string.IsNullOrEmpty(txtEmail.Text)) { MessageBox.Show("Enter Email"); return; }
                else if (string.IsNullOrEmpty(cboPosition.Text)) { MessageBox.Show("Enter position role"); return; }
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand checkUser = new SqlCommand("SELECT COUNT(*) FROM Member WHERE username = @username", con);
                checkUser.Parameters.AddWithValue("@username", txtUsername.Text);
                int userExists = (int)checkUser.ExecuteScalar();

                if (userExists > 0)
                {
                    MessageBox.Show("Username already exists. Please choose a different username."); return;
                }
                else
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into Member(username,password,gender,email,position) values('" + txtUsername.Text + "','" + txtPwd.Text + "','" + cboGender.Text + "','" + txtEmail.Text + "', '" + cboPosition.Text + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    refresh();
                    txtID.Clear();
                    txtUsername.Clear();
                    txtPwd.Clear();
                    txtEmail.Clear();
                    cboGender.SelectedIndex = -1;
                    cboPosition.SelectedIndex = -1;
                    MessageBox.Show("SignUp Successful!!!");
                }
            }
            else
            {
                MessageBox.Show("Cancelled!!!!!");
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30";
            string query = "select * from Member";
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvMember.DataSource = dt;
        }
        public void refresh()
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Member";
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt.Clear();
            adp.Fill(dt);
            dgvMember.DataSource = dt;
            con.Close();
        }

        private void dgvMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow index = dgvMember.Rows[e.RowIndex];
                txtID.Text = index.Cells[0].Value.ToString();
                txtUsername.Text = index.Cells[1].Value.ToString();
                txtPwd.Text = index.Cells[2].Value.ToString();
                cboGender.Text = index.Cells[3].Value.ToString();
                txtEmail.Text = index.Cells[4].Value.ToString();
                cboPosition.Text = index.Cells[5].Value.ToString();
                
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "update Member set username = '" + txtUsername.Text + "', password = '" + txtPwd.Text + "',gender = '" + cboGender.Text + "', email = '" + txtEmail.Text + "', position = '" + cboPosition.Text + "' where Uid='" + txtID.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            refresh();
            txtID.Clear();
            txtUsername.Clear();
            txtPwd.Clear();
            txtEmail.Clear();
            cboGender.SelectedIndex = -1;
            cboPosition.SelectedIndex = -1;
            MessageBox.Show("Update Success!!!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Show a confirmation message box
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this member?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Check if the user clicked "Yes"
            if (dialogResult == DialogResult.Yes)
            {
                // Proceed with the delete operation
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from Member where Uid='" + txtID.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();

                // Refresh the data and clear fields
                refresh();
                txtID.Clear();
                txtUsername.Clear();
                txtPwd.Clear();
                txtEmail.Clear();
                cboGender.SelectedIndex = -1;
                cboPosition.SelectedIndex =-1;

                MessageBox.Show("Delete Success!!!");
            }
            else
            {
                // If the user clicked "No", do nothing
                MessageBox.Show("Delete cancelled.");
            }
        }

    }
}
