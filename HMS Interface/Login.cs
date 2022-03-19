using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HMS_Interface
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(30, 0, 0, 0);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtUserID.Text == "UserId")
            {
                txtUserID.Text = null;

                txtUserID.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtUserID.Text == "")
            {
                txtUserID.Text = "UserId";

                txtUserID.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (txtUserPassword.Text == "*****")
            {
                txtUserPassword.Text = null;

                txtUserPassword.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (txtUserPassword.Text == "")
            {
                txtUserPassword.Text = "*****";

                txtUserPassword.ForeColor = Color.Silver;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please contact your admin to change your password!", "Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Global.person == "Admin")
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select Admin_id from Admin where Admin_username= @a and Admin_password = @b", con);
                cmd.Parameters.AddWithValue("@a", txtUserID.Text);
                cmd.Parameters.AddWithValue("@b", txtUserPassword.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Global.ID = reader.GetInt32(0);
                    AdminProfile d = new AdminProfile();
                    d.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Username and password!", "Error Msg", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }

            else if (Global.person == "Doctor")
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select Doctor_id from Doctors where Doctor_username= @a and Doctor_password = @b", con);
                cmd.Parameters.AddWithValue("@a", txtUserID.Text);
                cmd.Parameters.AddWithValue("@b", txtUserPassword.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Global.ID = reader.GetInt32(0);
                    Doctor d = new Doctor();
                    d.Show();
                    this.Close();
                }
                else {
                    MessageBox.Show("Invalid Username and password!", "Error Msg", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }

            else if (Global.person == "Receptionist")
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select Receptionist_id from Receptionist where Receptionist_username= @a and Receptionist_password = @b", con);
                cmd.Parameters.AddWithValue("@a", txtUserID.Text);
                cmd.Parameters.AddWithValue("@b", txtUserPassword.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Global.ID = reader.GetInt32(0);
                    Receptionist d = new Receptionist();
                    d.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Username and password!", "Error Msg", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }

            else if (Global.person == "Nurse")
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select Nurse_id from Nurses where Nurse_username= @a and Nurse_password = @b", con);
                cmd.Parameters.AddWithValue("@a", txtUserID.Text);
                cmd.Parameters.AddWithValue("@b", txtUserPassword.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Global.ID = reader.GetInt32(0);
                    Nurse d = new Nurse();
                    d.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Username and password!", "Error Msg", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }

            else if (Global.person == "Laboratorist")
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select Laboratorist_id from Laboratorist where Laboratorist_username= @a and Laboratorist_password = @b", con);
                cmd.Parameters.AddWithValue("@a", txtUserID.Text);
                cmd.Parameters.AddWithValue("@b", txtUserPassword.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Global.ID = reader.GetInt32(0);
                    Lab d = new Lab();
                    d.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Username and password!", "Error Msg", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }

            else if (Global.person == "Pharmacist")
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select Pharmacist_id from Pharmacist where Pharmacist_username= @a and Pharmacist_password = @b", con);
                cmd.Parameters.AddWithValue("@a", txtUserID.Text);
                cmd.Parameters.AddWithValue("@b", txtUserPassword.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Global.ID = reader.GetInt32(0);
                    Pharmacy d = new Pharmacy();
                    d.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Username and password!", "Error Msg", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }

            else
            {
                MessageBox.Show("Invalid Username and password!", "Error Msg", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }
    }
}
