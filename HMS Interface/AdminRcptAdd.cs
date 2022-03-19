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
    public partial class AdminRcptAdd : Form
    {
        public AdminRcptAdd()
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

        /* SQL Connection */
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");

        /* Setting Button Color */
        private void Form13_Load(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.Color.Black;
        }

        /* PlaceHolders */
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(NameField.Text == "Full Name")
            {
                NameField.Text = "";
                NameField.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (NameField.Text == "")
            {
                NameField.Text = "Full Name";
                NameField.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if(CNICField.Text == "CNIC")
            {
                CNICField.Text = "";
                CNICField.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
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

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if(phoneField.Text == "Phone")
            {
                phoneField.Text = "";
                phoneField.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (phoneField.Text == "")
            {
                phoneField.Text = "Phone";
                phoneField.ForeColor = Color.Silver;
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if(AgeField.Text == "Age")
            {
                AgeField.Text = "";
                AgeField.ForeColor = Color.Black;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (AgeField.Text == "")
            {
                AgeField.Text = "Age";
                AgeField.ForeColor = Color.Silver;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if(EduField.Text == "Qualification")
            {
                EduField.Text = "";
                EduField.ForeColor = Color.Black;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (EduField.Text == "")
            {
                EduField.Text = "Qualification";
                EduField.ForeColor = Color.Silver;
            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if(addressField.Text == "Address")
            {
                addressField.Text = "";
                addressField.ForeColor = Color.Black;
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
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

        /* Validations */
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
                SqlCommand cmd = new SqlCommand("Select * from Receptionist where Receptionist_username = '" + txtUsername.Text + "'", con);
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
                if(password.Length != 0)
                {
                    checkPassword.Text = "Excellent";
                    checkPassword.ForeColor = System.Drawing.Color.Green;
                }
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

        /* Linking all pages via buttons */
        private void btnProfile_Click(object sender, EventArgs e)
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
            AdminRcptView viewRcp = new AdminRcptView();
            viewRcp.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdminRcptAdd AddRcp = new AdminRcptAdd();
            AddRcp.Show();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AdminRcptUpdate UpdateRcp = new AdminRcptUpdate();
            UpdateRcp.Show();
            this.Close();
        }

        private void btnPtn_Click(object sender, EventArgs e)
        {
            AdminPatientView ViewPtn = new AdminPatientView();
            ViewPtn.Show();
            this.Close();
        }

        /* Add details to database */
        private void btnRcpAdd_Click(object sender, EventArgs e)
        {
            if (NameField.Text != "Full Name" && (Male.Checked) || (Female.Checked) && CNICField.Text != "CNIC" && phoneField.Text != "Phone" && AgeField.Text != "Age" && EduField.Text != "Qualification")
            {
                if (txtConfirmPassword.Text == txtPassword.Text)
                {
                    SqlCommand cmd = new SqlCommand("insert into Receptionist(Receptionist_username,Receptionist_password,Receptionist_name,Receptionist_gender,Receptionist_CNIC,Receptionist_DOB,Receptionist_contact,Receptionist_age,Receptionist_qualification,Receptionist_address) values(@RcpUsername,@RcpPassword,@RcpName,@RcpGender,@RcpCNIC,@RcpDOB,@RcpPhone,@RcpAge,@RcpQualification,@RcpAddress)", con);
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@RcpUsername", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@RcpPassword", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@RcpName", NameField.Text);
                    cmd.Parameters.AddWithValue("@RcpGender", Gender);
                    cmd.Parameters.AddWithValue("@RcpCNIC", CNICField.Text);
                    cmd.Parameters.AddWithValue("@RcpDOB", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@RcpPhone", phoneField.Text);
                    cmd.Parameters.AddWithValue("@RcpAge", int.Parse(AgeField.Text));
                    cmd.Parameters.AddWithValue("@RcpQualification", EduField.Text);
                    cmd.Parameters.AddWithValue("@RcpAddress", addressField.Text);

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

        /* Refresh Page Button */
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AdminRcptAdd Add = new AdminRcptAdd();
            Add.Show();
            this.Close();
        }

        /* SignOut Button */
        private void btnSignout_Click(object sender, EventArgs e)
        {
            Form1 Interface = new Form1();
            Interface.Show();
            this.Close();
        }

        /* Exit Button */
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
