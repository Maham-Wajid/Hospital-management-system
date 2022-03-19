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

namespace HMS_Interface
{
    public partial class AdminDocRstPassword : Form
    {
        public AdminDocRstPassword()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");

        private void btnback_Click(object sender, EventArgs e)
        {
            AdminResetPasswordInterface ResetPassword = new AdminResetPasswordInterface();
            ResetPassword.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtDocUsername_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Doctors where Doctor_username = @userName", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@userName", txtDocUserName.Text);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                label5.Text = "valid";
                label5.ForeColor = System.Drawing.Color.Green;
                errorProvider1.SetError(txtDocUserName, "");
            }
            else
            {
                label5.Text = "Invalid(not found)!";
                label5.ForeColor = System.Drawing.Color.Red;
                errorProvider1.SetError(txtDocUserName, "Username does not exist!");
            }

            con.Close();
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            if(confirmPassword == password)
            {
                label6.Text = "valid";
                label6.ForeColor = System.Drawing.Color.Green;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
            else
            {
                label6.Text = "Invalid";
                label6.ForeColor = System.Drawing.Color.Red;
                errorProvider1.SetError(txtConfirmPassword, "Password not match!");
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtNewPassword.Text;
            if(password.Length > 0 && password.Length < 5)
            {
                label7.Text = "Poor";
                label7.ForeColor = System.Drawing.Color.Red;
            }
            else if(password.Length >= 5 && password.Length <= 8)
            {
                label7.Text = "Good";
                label7.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                if (password.Length != 0)
                {
                    label7.Text = "Excellent";
                    label7.ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (txtDocUserName.Text != "" && txtNewPassword.Text != "" && txtConfirmPassword.Text != "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update Doctors SET Doctor_password = @password where Doctor_username = @userName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@userName", txtDocUserName.Text);
                cmd.Parameters.AddWithValue("@password", txtConfirmPassword.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Password reset Successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Enter required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ReSetControls();
        }

        private void ReSetControls()
        {
            txtDocUserName.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
            label5.Text = ".......";
            label6.Text = ".......";
            label7.Text = ".......";
            errorProvider1.SetError(txtDocUserName, "");
            errorProvider1.SetError(txtConfirmPassword, "");
            label5.ForeColor = System.Drawing.Color.Black;
            label6.ForeColor = System.Drawing.Color.Black;
            label7.ForeColor = System.Drawing.Color.Black;
        }
    }
}
