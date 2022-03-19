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
    public partial class AdminRcptUpdate : Form
    {
        public AdminRcptUpdate()
        {
            InitializeComponent();

            NameField.MaxLength = 50;
            CNICField.MaxLength = 13;
            phoneField.MaxLength = 20;
            AgeField.MaxLength = 5;
            EduField.MaxLength = 50;
            addressField.MaxLength = 50;
        }

        /* SQL Connection */
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
        string Gender;

        /* Setting page button color */
        private void Form14_Load(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.Color.Black;
        }

        /* Linking Pages via buttons */
        private void btnProfile_Click(object sender, EventArgs e)
        {
            AdminProfile adminProfile = new AdminProfile();
            adminProfile.Show();
            this.Close();
        }

        private void btnDoc_click(object sender, EventArgs e)
        {
            AdminDocView view = new AdminDocView();
            view.Show();
            this.Close();
        }

        private void btnNurse_Click(object sender, EventArgs e)
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

        private void btnPtn_Click(object sender, EventArgs e)
        {
            AdminPatientView ViewPtn = new AdminPatientView();
            ViewPtn.Show();
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

        /* Placeholders */
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (RcpIDField.Text == "Receptionist ID")
            {
                RcpIDField.Text = "";
                RcpIDField.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (RcpIDField.Text == "")
            {
                RcpIDField.Text = "Receptionist ID";
                RcpIDField.ForeColor = Color.Silver;
            }
        }

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

        private void RcpIDField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(RcpIDField, "Only Digits Allowed!");
            }
            else
            {
                e.Handled = false;
                errorProvider1.SetError(RcpIDField, "");
            }
        }

        /* Gettings details from database */
        private void btnGet_Click(object sender, EventArgs e)
        {
            if (RcpIDField.Text == "Receptionist ID")
            {
                //e.Cancel = true;
                errorProvider1.SetError(RcpIDField, "Receptionist ID is Required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(RcpIDField, "");

                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Receptionist where Receptionist_id = @userID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@userID", int.Parse(RcpIDField.Text));
                SqlDataReader dr = cmd.ExecuteReader();

                if (!(dr.HasRows))
                {
                    MessageBox.Show("Receptionist ID not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("Select * from Receptionist where Receptionist_id = '" + int.Parse(RcpIDField.Text) + "'", con);
                    SqlDataReader sdr = cmd1.ExecuteReader();
                    while (sdr.Read())
                    {
                        NameField.Text = sdr.GetValue(1).ToString();
                        Gender = sdr.GetValue(5).ToString();
                        if (Gender == "Male")
                        {
                            Male.Checked = true;
                        }
                        else
                        {
                            Female.Checked = true;
                        }
                        CNICField.Text = sdr.GetValue(4).ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(sdr.GetValue(6));
                        phoneField.Text = sdr.GetValue(3).ToString();
                        AgeField.Text = sdr.GetValue(2).ToString();
                        EduField.Text = sdr.GetValue(7).ToString();
                        addressField.Text = sdr.GetValue(8).ToString();
                    }

                    NameField.ForeColor = Color.Black;
                    CNICField.ForeColor = Color.Black;
                    phoneField.ForeColor = Color.Black;
                    AgeField.ForeColor = Color.Black;
                    EduField.ForeColor = Color.Black;
                    addressField.ForeColor = Color.Black;

                    con.Close();
                }
                con.Close();
            }
            
        }

        /* Edit/Update details */
        private void btnRcpUpdate_Click(object sender, EventArgs e)
        {
            if (NameField.Text != "Full Name" && (Male.Checked) || (Female.Checked) && CNICField.Text != "CNIC" && phoneField.Text != "Phone" && AgeField.Text != "Age" && EduField.Text != "Qualification")
            {
                if (Male.Checked == true)
                {
                    Gender = Male.Text;
                }
                else
                {
                    Gender = Female.Text;
                }

                SqlCommand cmd = new SqlCommand("Update Receptionist SET Receptionist_name = @RcpName, Receptionist_gender = @RcpGender,Receptionist_CNIC = @RcpCNIC,Receptionist_DOB = @RcpDOB,Receptionist_contact = @RcpPhone, Receptionist_Age = @RcpAge, Receptionist_qualification = @RcpQualification, Receptionist_address = @RcpAddress where Receptionist_id = '" + int.Parse(RcpIDField.Text) + "'", con);
                cmd.CommandType = CommandType.Text;

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

                MessageBox.Show("Successfully Updated!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Enter Required Details!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /* Refresh Page button */
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AdminRcptUpdate Update = new AdminRcptUpdate();
            Update.Show();
            this.Close();
        }

        /* SignOut Page Button */
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
