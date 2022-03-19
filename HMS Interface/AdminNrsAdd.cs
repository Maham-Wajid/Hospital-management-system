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
using Microsoft.VisualBasic;

namespace HMS_Interface
{
    public partial class AdminNrsAdd : Form
    {
        public AdminNrsAdd()
        {
            InitializeComponent();

            // Setting Max Length
            NameField.MaxLength = 50;
            CNICField.MaxLength = 13;
            phoneField.MaxLength = 20;
            AgeField.MaxLength = 5;
            EduField.MaxLength = 20;
            addressField.MaxLength = 50;
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");

        private void NameField_Enter(object sender, EventArgs e)
        {
            if (NameField.Text == "Full Name")
            {
                NameField.Text = "";
                NameField.ForeColor = Color.Black;
            }
        }

        private void NameField_Leave(object sender, EventArgs e)
        {
            if (NameField.Text == "")
            {
                NameField.Text = "Full Name";
                NameField.ForeColor = Color.Silver;
            }
        }

        private void CNICField_Enter(object sender, EventArgs e)
        {
            if (CNICField.Text == "CNIC")
            {
                CNICField.Text = "";
                CNICField.ForeColor = Color.Black;
            }
        }

        private void CNICField_Leave(object sender, EventArgs e)
        {
            if (CNICField.Text == "")
            {
                CNICField.Text = "CNIC";
                CNICField.ForeColor = Color.Silver;
            }

            int CNIC = CNICField.Text.Length;
            if (CNIC != 13)
            {
                errorProvider1.SetError(CNICField, "Invalid CNIC!");
            }
            else
            {
                errorProvider1.SetError(CNICField, "");
            }
        }

        private void phoneField_Enter(object sender, EventArgs e)
        {
            if (phoneField.Text == "Phone")
            {
                phoneField.Text = "";
                phoneField.ForeColor = Color.Black;
            }
        }

        private void phoneField_Leave(object sender, EventArgs e)
        {
            if (phoneField.Text == "")
            {
                phoneField.Text = "Phone";
                phoneField.ForeColor = Color.Silver;
            }
        }

        private void AgeField_Enter(object sender, EventArgs e)
        {
            if (AgeField.Text == "Age")
            {
                AgeField.Text = "";
                AgeField.ForeColor = Color.Black;
            }
        }

        private void AgeField_Leave(object sender, EventArgs e)
        {
            if (AgeField.Text == "")
            {
                AgeField.Text = "Age";
                AgeField.ForeColor = Color.Silver;
            }
        }

        private void EduField_Enter(object sender, EventArgs e)
        {
            if (EduField.Text == "Qualification")
            {
                EduField.Text = "";
                EduField.ForeColor = Color.Black;
            }
        }

        private void EduField_Leave(object sender, EventArgs e)
        {
            if (EduField.Text == "")
            {
                EduField.Text = "Qualification";
                EduField.ForeColor = Color.Silver;
            }
        }

        private void addressField_Enter(object sender, EventArgs e)
        {
            if (addressField.Text == "Address")
            {
                addressField.Text = "";
                addressField.ForeColor = Color.Black;
            }
        }

        private void addressField_Leave(object sender, EventArgs e)
        {
            if (addressField.Text == "")
            {
                addressField.Text = "Address";
                addressField.ForeColor = Color.Silver;
            }
        }

        string Gender;
        private void Male_CheckedChanged(object sender, EventArgs e)
        {
            if (Male.Checked == true)
            {
                Gender = Male.Text;
            }
        }

        private void Female_CheckedChanged(object sender, EventArgs e)
        {
            if (Female.Checked == true)
            {
                Gender = Female.Text;
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "UserName")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "UserName";
                txtUsername.ForeColor = Color.Silver;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Silver;
            }
        }

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text == "Confirm Password")
            {
                txtConfirmPassword.Text = "";
                txtConfirmPassword.ForeColor = Color.Black;
            }
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text == "")
            {
                txtConfirmPassword.Text = "Confirm Password";
                txtConfirmPassword.ForeColor = Color.Silver;
            }
        }

        /* Setting page button color */
        private void Form7_Load(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.Color.Black;
        }

        /* Linking all the forms via buttons */

        private void btnPofile_Click(object sender, EventArgs e)
        {
            AdminProfile adminProfile = new AdminProfile();
            adminProfile.Show();
            this.Close();
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            AdminDocView view = new AdminDocView();
            view.Show();
            this.Close();
        }

        private void btnNrs_Click(object sender, EventArgs e)
        {
            AdminNrsView viewNrs = new AdminNrsView();
            viewNrs.Show();
            this.Close();
        }

        private void btnRcp_Click(object sender, EventArgs e)
        {
            AdminRcptView viewRcp = new AdminRcptView();
            viewRcp.Show();
            this.Close();
        }

        private void btnLab_Click(object sender, EventArgs e)
        {
            AdminLabortryView viewLab = new AdminLabortryView();
            viewLab.Show();
            this.Close();
        }

        private void btnPhrm_Click(object sender, EventArgs e)
        {
            AdminPhrmcyView viewPharm = new AdminPhrmcyView();
            viewPharm.Show();
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            AdminResetPasswordInterface ResetPassword = new AdminResetPasswordInterface();
            ResetPassword.Show();
            this.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            AdminNrsView viewNrs = new AdminNrsView();
            viewNrs.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdminNrsAdd AddNrs = new AdminNrsAdd();
            AddNrs.Show();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AdminNrsUpdate UpdateNrs = new AdminNrsUpdate();
            UpdateNrs.Show();
            this.Close();
        }

        private void btnPtn_Click(object sender, EventArgs e)
        {
            AdminPatientView ViewPtn = new AdminPatientView();
            ViewPtn.Show();
            this.Close();
        }

        /* Adding Details to database using ADD Button */

        private void btnAddNrs_Click(object sender, EventArgs e)
        {
            if (NameField.Text != "Full Name" && (Male.Checked) || (Female.Checked) && CNICField.Text != "CNIC" && phoneField.Text != "Phone" && AgeField.Text != "Age" && EduField.Text != "Qualification" && txtUsername.Text != "UserName" && txtPassword.Text != "Password" && txtConfirmPassword.Text != "Confirm Password")
            {
                if(txtConfirmPassword.Text == txtPassword.Text)
                {
                    SqlCommand cmd = new SqlCommand("insert into Nurses(Nurse_username,Nurse_password,Nurse_name,Nurse_gender,Nurse_CNIC,Nurse_DOB,Nurse_contact,Nurse_age,Nurse_qualification,Nurse_address) values(@NrsUsername,@NrsPassword,@NrsName,@NrsGender,@NrsCNIC,@NrsDOB,@NrsPhone,@NrsAge,@NrsQualification,@NrsAddress)", con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@NrsUsername", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@NrsPassword", txtConfirmPassword.Text);
                    cmd.Parameters.AddWithValue("@NrsName", NameField.Text);
                    cmd.Parameters.AddWithValue("@NrsGender", Gender);
                    cmd.Parameters.AddWithValue("@NrsDOB", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@NrsCNIC", CNICField.Text);
                    cmd.Parameters.AddWithValue("@NrsPhone", phoneField.Text);
                    cmd.Parameters.AddWithValue("@NrsAge", AgeField.Text);
                    cmd.Parameters.AddWithValue("@NrsQualification", EduField.Text);
                    cmd.Parameters.AddWithValue("@NrsAddress", addressField.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Data Inserted Successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Password and Confirm Password not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Enter Required Details!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void NameField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(NameField, "Only Charecters Allowed!");
            }
            else
            {
                e.Handled = false;
                errorProvider1.SetError(NameField, "");
            }
        }

        private void CNICField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(CNICField, "Only Digits Allowed!");
            }
            else
            {
                e.Handled = false;
                errorProvider1.SetError(CNICField, "");
            }
        }

        private void phoneField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(phoneField, "Only Digits Allowed!");
            }
            else
            {
                e.Handled = false;
                errorProvider1.SetError(phoneField, "");
            }
        }

        private void AgeField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(AgeField, "Only Digits Allowed!");
            }
            else
            {
                e.Handled = false;
                errorProvider1.SetError(AgeField, "");
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text != "UserName")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Nurses where Nurse_username = '" + txtUsername.Text + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    CheckUsername.Text = "Already Taken";
                    CheckUsername.ForeColor = System.Drawing.Color.Red;
                    errorProvider1.SetError(CheckUsername, "Username '" + txtUsername.Text + "' already exist!");
                }
                else
                {
                    CheckUsername.Text = "valid";
                    CheckUsername.ForeColor = System.Drawing.Color.Green;
                    errorProvider1.SetError(CheckUsername, "");
                }
                con.Close();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            if (password.Length > 0 && password.Length < 5)
            {
                checkPassword.Text = "Poor";
                checkPassword.ForeColor = System.Drawing.Color.Red;
            }
            else if (password.Length >= 5 && password.Length <= 8)
            {
                checkPassword.Text = "Good";
                checkPassword.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                checkPassword.Text = "Excellent";
                checkPassword.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            if (confirmPassword == password)
            {
                checkConfirmPassword.Text = "valid";
                checkConfirmPassword.ForeColor = System.Drawing.Color.Green;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
            else
            {
                checkConfirmPassword.Text = "Invalid";
                checkConfirmPassword.ForeColor = System.Drawing.Color.Red;
                errorProvider1.SetError(txtConfirmPassword, "Password not match!");
            }
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            Form1 Interface = new Form1();
            Interface.Show();
            this.Close();
        }

        private void btnRefresh(object sender, EventArgs e)
        {
            AdminNrsAdd Add = new AdminNrsAdd();
            Add.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
