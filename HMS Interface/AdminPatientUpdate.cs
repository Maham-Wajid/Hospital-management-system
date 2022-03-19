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
    public partial class AdminPatientUpdate : Form
    {
        public AdminPatientUpdate()
        {
            InitializeComponent();

            // Setting Max Length
            NameField.MaxLength = 50;
            CNICField.MaxLength = 13;
            phoneField.MaxLength = 20;
            BldGrpField.MaxLength = 6;
            AgeField.MaxLength = 5;
            addressField.MaxLength = 50;
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
        string Gender;

        private void Form29_Load(object sender, EventArgs e)
        {
            button13.BackColor = System.Drawing.Color.Black;
        }

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

        private void btnRecep_Click(object sender, EventArgs e)
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
            AdminPatientView view = new AdminPatientView();
            view.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdminPatientAdd Add = new AdminPatientAdd();
            Add.Show();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AdminPatientUpdate Update = new AdminPatientUpdate();
            Update.Show();
            this.Close();
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            Form1 Interface = new Form1();
            Interface.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (PtIDField.Text == "Patient's ID")
            {
                PtIDField.Text = "";
                PtIDField.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (PtIDField.Text == "")
            {
                PtIDField.Text = "Patient's ID";
                PtIDField.ForeColor = Color.Silver;
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

        private void BldGrpField_Enter(object sender, EventArgs e)
        {
            if (BldGrpField.Text == "Blood Group")
            {
                BldGrpField.Text = "";
                BldGrpField.ForeColor = Color.Black;
            }
        }

        private void BldGrpField_Leave(object sender, EventArgs e)
        {
            if (BldGrpField.Text == "")
            {
                BldGrpField.Text = "Blood Group";
                BldGrpField.ForeColor = Color.Silver;
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

        private void BldGrpField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(BldGrpField, "Only Characters Allowed!");
            }
            else
            {
                e.Handled = false;
                errorProvider1.SetError(BldGrpField, "");
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (PtIDField.Text == "Patient's ID")
            {
                //e.Cancel = true;
                errorProvider1.SetError(PtIDField, "Patient's ID is Required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(PtIDField, "");

                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Patient where Patient_id = @userID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@userID", int.Parse(PtIDField.Text));
                SqlDataReader dr = cmd.ExecuteReader();

                if (!(dr.HasRows))
                {
                    MessageBox.Show("Patient's ID not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("Select * from Patient where Patient_id = '" + int.Parse(PtIDField.Text) + "'", con);
                    SqlDataReader sdr = cmd1.ExecuteReader();
                    while (sdr.Read())
                    {
                        NameField.Text = sdr.GetValue(1).ToString();
                        Gender = sdr.GetValue(6).ToString();
                        if (Gender == "Male")
                        {
                            Male.Checked = true;
                        }
                        else
                        {
                            Female.Checked = true;
                        }
                        CNICField.Text = sdr.GetValue(3).ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(sdr.GetValue(8));
                        phoneField.Text = sdr.GetValue(2).ToString();
                        AgeField.Text = sdr.GetValue(5).ToString();
                        BldGrpField.Text = sdr.GetValue(7).ToString();
                        addressField.Text = sdr.GetValue(4).ToString();
                    }

                    NameField.ForeColor = Color.Black;
                    CNICField.ForeColor = Color.Black;
                    phoneField.ForeColor = Color.Black;
                    AgeField.ForeColor = Color.Black;
                    BldGrpField.ForeColor = Color.Black;
                    addressField.ForeColor = Color.Black;
                    con.Close();
                }
                con.Close();
            }

        }

        private void btnPtUpdate_Click(object sender, EventArgs e)
        {
            if (NameField.Text != "Full Name" && (Male.Checked) || (Female.Checked) && CNICField.Text != "CNIC" && phoneField.Text != "Phone" && AgeField.Text != "Age" && BldGrpField.Text != "Blood Group")
            {
                if (Male.Checked == true)
                {
                    Gender = Male.Text;
                }
                else
                {
                    Gender = Female.Text;
                }

                SqlCommand cmd = new SqlCommand("Update Patient SET Patient_name = @PtName, Patient_gender = @PtGender,Patient_CNIC = @PtCNIC, Patient_DOB = @PtDOB, Patient_contact = @PtPhone, Patient_Age = @PtAge, Patient_BldGrp = @PtBldGrp, Patient_address = @PtAddress where Patient_id = '" + int.Parse(PtIDField.Text) + "'", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@PtName", NameField.Text);
                cmd.Parameters.AddWithValue("@PtGender", Gender);
                cmd.Parameters.AddWithValue("@PtCNIC", CNICField.Text);
                cmd.Parameters.AddWithValue("@PtDOB", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@PtPhone", phoneField.Text);
                cmd.Parameters.AddWithValue("@PtAge", int.Parse(AgeField.Text));
                cmd.Parameters.AddWithValue("@PtBldGrp", BldGrpField.Text);
                cmd.Parameters.AddWithValue("@PtAddress", addressField.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Inserted Successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Enter Required Details!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AdminPatientUpdate Update = new AdminPatientUpdate();
            Update.Show();
            this.Close();
        }

        private void PtIDField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(PtIDField, "Only Digits Allowed!");
            }
            else
            {
                e.Handled = false;
                errorProvider1.SetError(PtIDField, "");
            }
        }
    }
}
