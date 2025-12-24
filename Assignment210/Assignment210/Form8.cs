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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        public void refresh()
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Trainer";
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvTrainer.DataSource = dt;
            con.Close();
            txtTID.Clear();
            txtTrainerName.Clear();
            txtAge.Clear();
            cboGender.SelectedIndex = -1;
            txtPhoneNumber.Clear();
        }
        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var F6 = new Form6();
            this.Hide();
            F6.Show();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand checkUser = new SqlCommand("SELECT COUNT(*) FROM Trainer WHERE Tname = @trainername", con);
            checkUser.Parameters.AddWithValue("@trainername", txtTrainerName.Text);
            int userExists = (int)checkUser.ExecuteScalar(); // Execute the query and get the result

            if (userExists > 0)
            {
                MessageBox.Show("Name already exists. Please choose a different Name.");
            }
            else
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Trainer(Tname,Tage,Tgender,TphoneNumber) values('" + txtTrainerName.Text + "','" + txtAge.Text + "','" + cboGender.Text + "','" + txtPhoneNumber.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                refresh();
                MessageBox.Show("SignUp Successful!!!");
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30";
            string query = "select * from Trainer";
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvTrainer.DataSource = dt;
        }

        private void dgvTrainer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow index = dgvTrainer.Rows[e.RowIndex];
                txtTID.Text = index.Cells[0].Value.ToString();
                txtTrainerName.Text = index.Cells[1].Value.ToString();
                txtAge.Text = index.Cells[2].Value.ToString();
                cboGender.Text = index.Cells[3].Value.ToString();
                txtPhoneNumber.Text = index.Cells[4].Value.ToString();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "update Trainer set Tname = '" + txtTrainerName.Text + "', Tage = '" + txtAge.Text + "',Tgender = '" + cboGender.Text + "', TphoneNumber = '" + txtPhoneNumber.Text + "' where Tid='" + txtTID.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            refresh();
            
            MessageBox.Show("Update Success!!!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Show a confirmation message box
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this trainer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Check if the user clicked "Yes"
            if (dialogResult == DialogResult.Yes)
            {
                // Proceed with the delete operation
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from Trainer where Tid='" + txtTID.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();

                // Refresh the data and clear fields
                refresh();

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

