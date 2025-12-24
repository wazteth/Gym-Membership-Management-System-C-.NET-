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

namespace Assignment210
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        public void refresh()
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select g.cID as ID,g.cTitle as Title,g.cCategory as Category,g.cFee as Fee,t.Tname as 'Trainer Name' from GymClass as g join Trainer as t on t.Tid = g.Tid;";
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvGymClass.DataSource = dt;
            con.Close();
            txtCID.Clear();
            txtTitle.Clear();
            txtCategory.Clear();
            txtTName.Clear();
            txtFee.Clear();
        }

        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var F6 = new Form6();
            this.Hide();
            F6.Show();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30";
            string query = "select g.cID as ID,g.cTitle as Title,g.cCategory as Category,g.cFee as Fee,t.Tname as 'Trainer Name' from GymClass as g join Trainer as t on t.Tid = g.Tid;";
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvGymClass.DataSource = dt;

            string query1 = "select Tname as 'Trainer Name' from Trainer;";
            SqlDataAdapter dp = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            dp.Fill(dt1);
            dgvTrainer.DataSource = dt1;
        }

        private void dgvGymClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow index = dgvGymClass.Rows[e.RowIndex];
                txtCID.Text = index.Cells[0].Value.ToString();
                txtTitle.Text = index.Cells[1].Value.ToString();
                txtCategory.Text = index.Cells[2].Value.ToString();
                txtTName.Text = index.Cells[4].Value.ToString();
                txtFee.Text = index.Cells[3].Value.ToString();
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand checkUser = new SqlCommand("SELECT COUNT(*) FROM GymClass WHERE cTitle = @titlename", con);
            checkUser.Parameters.AddWithValue("@titlename", txtTitle.Text);
            int userExists = (int)checkUser.ExecuteScalar(); // Execute the query and get the result

            if (userExists > 0)
            {
                MessageBox.Show("Name already exists. Please choose a different Name.");
            }
            else
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into GymClass(cTitle, cCategory, Tid, cFee) "+
                    "select '" + txtTitle.Text + "', '" + txtCategory.Text + "', Tid, '" + txtFee.Text + "' " +
                  "from Trainer where Tname = '" + txtTName.Text + "'";
                
                cmd.ExecuteNonQuery();
                con.Close();

                refresh();
                MessageBox.Show("New Course Created Successful!!!");
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "UPDATE GymClass " +
                      "SET cTitle = @title, cCategory = @category, Tid = (SELECT Tid FROM Trainer WHERE Tname = @trainerName), cFee = @fee " +
                      "WHERE cID = @classId";

            // Add parameters
            cmd.Parameters.AddWithValue("@title", txtTitle.Text);
            cmd.Parameters.AddWithValue("@category", txtCategory.Text);
            cmd.Parameters.AddWithValue("@trainerName", txtTName.Text);
            cmd.Parameters.AddWithValue("@fee", txtFee.Text);
            cmd.Parameters.AddWithValue("@classId", txtCID.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            refresh();

            MessageBox.Show("Update Success!!!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Show a confirmation message box
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this class?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Check if the user clicked "Yes"
            if (dialogResult == DialogResult.Yes)
            {
                // Proceed with the delete operation
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from GymClass where cID='" + txtCID.Text + "'";
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

        private void dgvTrainer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow index = dgvTrainer.Rows[e.RowIndex];
                txtTName.Text = index.Cells[0].Value.ToString();
            }
        }
    }
}
