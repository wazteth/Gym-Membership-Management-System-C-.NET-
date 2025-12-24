using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Assignment210
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        public void refresh()
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select e.eID,e.Uid,m.username,e.cID,g.cTitle as Title,g.cCategory as Category,e.eStartDate as StartDate from Enrolment as e join Member as m on e.Uid=m.Uid join GymClass as g on g.cID=e.cID;";
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvEnrolment.DataSource = dt;
            con.Close();
            txtEID.Clear();
            txtMName.Clear();
            txtTitle.Clear();
            
        }
        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var F6 = new Form6();
            this.Hide();
            F6.Show();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30";
            string query = "select e.eID,e.Uid,m.username,e.cID,g.cTitle as Title,g.cCategory as Category,e.eStartDate as StartDate from Enrolment as e join Member as m on e.Uid=m.Uid join GymClass as g on g.cID=e.cID;";
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvEnrolment.DataSource = dt;

            string query1 = "select g.cTitle as Title from GymClass as g";
            SqlDataAdapter dp = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            dp.Fill(dt1);
            dgvGymClass.DataSource = dt1;

            string query2 = "select username from Member";
            SqlDataAdapter ada = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            ada.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }

        private void dgvEnrolment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow index = dgvEnrolment.Rows[e.RowIndex];
                txtEID.Text = index.Cells[0].Value.ToString();
                txtMName.Text = index.Cells[2].Value.ToString();
                txtTitle.Text = index.Cells[4].Value.ToString();
                dtpStartDate.Text = index.Cells[6].Value.ToString();
               
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand checkUser = new SqlCommand("SELECT COUNT(*) FROM Member WHERE username = @username", con);
            checkUser.Parameters.AddWithValue("@username", txtMName.Text);
            int userExists = (int)checkUser.ExecuteScalar(); // Execute the query and get the result

            if (userExists <= 0)
            {
                MessageBox.Show("Name doesn't exist. Please choose an existing Name.");
            }
            else
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Enrolment (Uid, cID, eStartDate) SELECT m.Uid, g.cID, @startDate FROM Member m " +
                           "JOIN GymClass g ON g.cTitle = @courseTitle " +
                           "WHERE m.username = @username";

                // Add parameters for course title, username, and start date
                cmd.Parameters.AddWithValue("@courseTitle", txtTitle.Text);
                cmd.Parameters.AddWithValue("@username", txtMName.Text);
                cmd.Parameters.AddWithValue("@startDate", dtpStartDate.Value.ToString("yyyy-MM-dd"));
                cmd.ExecuteNonQuery();
                con.Close();

                refresh();
                MessageBox.Show("New Enrolment Created Successful!!!");
            }
        }

        private void txtBrowse_Click(object sender, EventArgs e)
        {

        }

        private void dgvGymClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow index = dgvGymClass.Rows[e.RowIndex];
                txtTitle.Text = index.Cells[0].Value.ToString();

            }
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
            con.Open();

            // Update query using a single command
            SqlCommand cmd = new SqlCommand(
                "UPDATE Enrolment SET Uid = (SELECT Uid FROM Member WHERE username = @username), cID = (SELECT cID FROM GymClass WHERE cTitle = @title), " +
                "eStartDate = @startDate WHERE eID = @eID", con);

            // Add parameters
            cmd.Parameters.AddWithValue("@title", txtTitle.Text);
            cmd.Parameters.AddWithValue("@startDate", dtpStartDate.Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@eID", txtEID.Text);
            cmd.Parameters.AddWithValue("@username", txtMName.Text);
            
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();

            if (rowsAffected > 0)
            {
                refresh();
                MessageBox.Show("Update Success!!!");
            }
            else
            {
                MessageBox.Show("Update failed. No matching records found.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Show a confirmation message box
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this enrollment?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Check if the user clicked "Yes"
            if (dialogResult == DialogResult.Yes)
            {
                // Proceed with the delete operation
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from Enrolment where eID='" + txtEID.Text + "'";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow index = dataGridView1.Rows[e.RowIndex];
                txtMName.Text = index.Cells[0].Value.ToString();

            }
        }
    }
}
