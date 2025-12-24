using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Assignment210
{
    public partial class Form5 : Form
    {
        private string Uid;
        public Form5(string id)
        {
            InitializeComponent();
            Uid = id;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        private string cID;
        private string eID;
        private void dgvCourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow index = dgvCourse.Rows[e.RowIndex];
                cID = index.Cells[0].Value.ToString();
                txtTitle.Text = index.Cells[1].Value.ToString();
                txtCategory.Text = index.Cells[2].Value.ToString();
                txtFee.Text = index.Cells[3].Value.ToString();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30";
            string query = "select g.cID as ID,g.cTitle as Title,g.cCategory as Category,g.cFee as Fee,t.Tname as 'Trainer Name' from GymClass as g join Trainer as t on t.Tid = g.Tid;";
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvCourse.DataSource = dt;

            string query1 = "SELECT e.eID as ID, g.cTitle as Title, g.cCategory as Category, e.eStartDate as StartDate " +
                    "FROM Enrolment e " +
                    "JOIN GymClass g ON e.cID = g.cID " +
                    "WHERE e.Uid = @Uid;";
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query1, connection);
                cmd.Parameters.AddWithValue("@Uid", Uid);  // Using the Uid passed to Form5 (logged-in user's id)

                SqlDataAdapter enrolmentAdapter = new SqlDataAdapter(cmd);
                DataTable enrolmentTable = new DataTable();
                enrolmentAdapter.Fill(enrolmentTable);

                // Assuming dgvEnrolledClasses is another DataGridView to show enrolled classes
                dgvMyClass.DataSource = enrolmentTable;
            }
            dgvMyClass.Hide();
            btnLeave.Hide();
            lblNote.Hide();
            refresh();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var F2 = new Form2();
            this.Hide();
            F2.Show();
        }

        private void btnMyClass_Click(object sender, EventArgs e)
        {
            if (dgvMyClass.Visible)
            {
                dgvMyClass.Hide();  // Hide the "My Gym Class" grid
                dgvCourse.Show();   // Show the "Available Courses" grid
                btnLeave.Hide();
                lblNote.Hide();
            }
            // If dgvMyClass is hidden, show it and hide dgvCourse.
            else
            {
                dgvMyClass.Show();  // Show the "My Gym Class" grid
                dgvCourse.Hide();   // Hide the "Available Courses" grid
                btnLeave.Show();
                lblNote.Show();
            }
            refresh();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30"))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("Insert into Enrolment(Uid,cID,eStartDate) values(@Uid,@cID,@eStartDate)", con))
                    {
                        cmd.Parameters.AddWithValue("@Uid", Uid);
                        cmd.Parameters.AddWithValue("@cID", cID);
                        cmd.Parameters.AddWithValue("@eStartDate", dtpStartDate.Value.ToString("yyyy-MM-dd"));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Enrolment Success");
                        txtTitle.Clear();
                        txtCategory.Clear();
                        txtFee.Clear();
                    }

                }
                catch (SqlException sqlEx) { MessageBox.Show(sqlEx.Message); }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                refresh();
            }
        }
        public void refresh()
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT e.eID as ID, g.cTitle as Title, g.cCategory as Category, e.eStartDate as StartDate " +
                    "FROM Enrolment e " +
                    "JOIN GymClass g ON e.cID = g.cID " +
                    "WHERE e.Uid = @Uid;";
            cmd.Parameters.AddWithValue("@Uid", Uid);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvMyClass.DataSource = dt;
            con.Close();
            txtCategory.Clear();
            txtFee.Clear();
            txtTitle.Clear();

        }

        private void dgvMyClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow index = dgvMyClass.Rows[e.RowIndex];
                eID = index.Cells[0].Value.ToString();
                
            }

        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            // Show a confirmation message box
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to leave this class?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Check if the user clicked "Yes"
            if (dialogResult == DialogResult.Yes)
            {
                // Proceed with the delete operation
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from Enrolment where eID=@eID";
                cmd.Parameters.AddWithValue("@eID", eID);
                cmd.ExecuteNonQuery();
                con.Close();

                // Refresh the data and clear fields
                refresh();

                MessageBox.Show("You Cancelled The Class!!!");
            }
            else
            {
                // If the user clicked "No", do nothing
                MessageBox.Show("Class is not cancelled.");
            }
        }
    }
}
