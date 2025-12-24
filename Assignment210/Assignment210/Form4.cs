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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPwd.Text))
            {
                MessageBox.Show("Please Enter Username or Password");
                return;
            }
            else
            {
                try
                {
                    SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Zaw Htet\Documents\GymMember.mdf"";Integrated Security=True;Connect Timeout=30");
                    cn.Open();
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Member where username = '" + txtUser.Text + "' and password = '" + txtPwd.Text + "' and position = 'admin'";
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dp.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        if (dt.Rows[0][1].ToString() == txtUser.Text && dt.Rows[0][2].ToString() == txtPwd.Text)
                        {
                            MessageBox.Show("Admin login Success");
                            var F6 = new Form6();
                            this.Hide();
                            F6.Show();
                        }
                        else MessageBox.Show("Incorrect Username or Password");
                    }

                    else MessageBox.Show("Incorrect Username or Password");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void cboShow_CheckedChanged(object sender, EventArgs e)
        {
            if (cboShow.Checked) txtPwd.UseSystemPasswordChar = false;
            else txtPwd.UseSystemPasswordChar = true;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            txtPwd.UseSystemPasswordChar = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
    }

