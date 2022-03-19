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
    public partial class AdminPharmResetPassword : Form
    {
        public AdminPharmResetPassword()
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

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Pharmacist where Pharmacist_username = @username", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@username", username);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                label5.Text = "valid!";
                label5.ForeColor = System.Drawing.Color.Green;
                errorProvider1.SetError(txtUsername, "");
            }
            else
            {
                label5.Text = "Invalid(not found)!";
                label5.ForeColor = System.Drawing.Color.Red;
                errorProvider1.SetError(txtUsername, "Username does not exist!");
            }
            con.Close();
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            if (password.Length > 0 && password.Length < 5)
            {
                label6.Text = "Poor";
                label6.ForeColor = System.Drawing.Color.Red;
            }
            else if (password.Length >= 5 && password.Length <= 8)
            {
                label6.Text = "Good";
                label6.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                if(password.Length != 0)
                {
                    label6.Text = "Excellent";
                    label6.ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            if (confirmPassword == password)
            {
                label7.Text = "valid";
                label7.ForeColor = System.Drawing.Color.Green;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
            else
            {
                label7.Text = "Invalid";
                label7.ForeColor = System.Drawing.Color.Red;
                errorProvider1.SetError(txtConfirmPassword, "Password not match!");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "" && txtConfirmPassword.Text != "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update Pharmacist SET Pharmacist_password = @password where Pharmacist_username = @username", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
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
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            label5.Text = ".......";
            label6.Text = ".......";
            label7.Text = ".......";
            errorProvider1.SetError(txtUsername, "");
            errorProvider1.SetError(txtConfirmPassword, "");
            label5.ForeColor = System.Drawing.Color.Black;
            label6.ForeColor = System.Drawing.Color.Black;
            label7.ForeColor = System.Drawing.Color.Black;
        }
    }
}
