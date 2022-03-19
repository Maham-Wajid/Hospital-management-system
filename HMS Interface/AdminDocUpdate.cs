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
    public partial class AdminDocUpdate : Form
    {
        public AdminDocUpdate()
        {
            InitializeComponent();

            NameField.MaxLength = 50;
            CNICField.MaxLength = 13;
            phoneField.MaxLength = 20;
            AgeField.MaxLength = 5;
            EduField.MaxLength = 50;
            addressField.MaxLength = 50;
        }

        /* SQL Database Connection */
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
        string Gender;

        /* Setting page color button */
        private void Form4_Load(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.Color.Black;
        }

        /* Getting Details from database */
        private void button12_Click(object sender, EventArgs e)
        {
            if (DocIDField.Text == "Doctor's ID")
            {
                //e.Cancel = true;
                errorProvider1.SetError(DocIDField, "Doctor ID is Required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(DocIDField, "");

                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Doctors where Doctor_id = @userID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@userID", int.Parse(DocIDField.Text));
                SqlDataReader dr = cmd.ExecuteReader();

                if (!(dr.HasRows))
                {
                    MessageBox.Show("Doctor ID not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("Select * from Doctors where Doctor_id = '" + int.Parse(DocIDField.Text) + "'", con);
                    SqlDataReader sdr = cmd1.ExecuteReader();
                    while (sdr.Read())
                    {
                        NameField.Text = sdr.GetValue(1).ToString();
                        Gender = sdr.GetValue(3).ToString();
                        if (Gender == "Male")
                        {
                            Male.Checked = true;
                        }
                        else
                        {
                            Female.Checked = true;
                        }
                        CNICField.Text = sdr.GetValue(7).ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(sdr.GetValue(4));
                        phoneField.Text = sdr.GetValue(5).ToString();
                        AgeField.Text = sdr.GetValue(2).ToString();
                        EduField.Text = sdr.GetValue(6).ToString();
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            AdminResetPasswordInterface ResetPassword = new AdminResetPasswordInterface();
            ResetPassword.Show();
            this.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            AdminDocView view = new AdminDocView();
            view.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdminDocAdd Add = new AdminDocAdd();
            Add.Show();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AdminDocUpdate Update = new AdminDocUpdate();
            Update.Show();
            this.Close();
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            Form1 Interface = new Form1();
            Interface.Show();
            this.Close();
        }

        private void btnPtn_Click(object sender, EventArgs e)
        {
            AdminPatientView ViewPtn = new AdminPatientView();
            ViewPtn.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (DocIDField.Text == "Doctor's ID")
            {
                DocIDField.Text = "";
                DocIDField.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (DocIDField.Text == "")
            {
                DocIDField.Text = "Doctor's ID";
                DocIDField.ForeColor = Color.Silver;
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

        private void btnUpdate(object sender, EventArgs e)
        {
            if (NameField.Text != "Full Name" && (Male.Checked) || (Female.Checked) && CNICField.Text != "CNIC" && phoneField.Text != "Phone" && AgeField.Text != "Age" && AgeField.Text != "" && EduField.Text != "Qualification")
            {
                if (Male.Checked == true)
                {
                    Gender = Male.Text;
                }
                else
                {
                    Gender = Female.Text;
                }

                SqlCommand cmd = new SqlCommand("Update Doctors SET Doctor_name = @DocName, Doctor_gender = @DocGender,Doctor_CNIC = @DocCNIC,Doctor_DOB = @DocDOB,Doctor_contact = @DocPhone, Doctor_Age = @DocAge, Doctor_qualification = @DocQualification, Doctor_address = @DocAddress where Doctor_id = '" + int.Parse(DocIDField.Text) + "'", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@DocName", NameField.Text);
                cmd.Parameters.AddWithValue("@DocGender", Gender);
                cmd.Parameters.AddWithValue("@DocCNIC", CNICField.Text);
                cmd.Parameters.AddWithValue("@DocDOB", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@DocPhone", phoneField.Text);
                cmd.Parameters.AddWithValue("@DocAge", int.Parse(AgeField.Text));
                cmd.Parameters.AddWithValue("@DocQualification", EduField.Text);
                cmd.Parameters.AddWithValue("@DocAddress", addressField.Text);

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AdminDocUpdate Update = new AdminDocUpdate();
            Update.Show();
            this.Close();
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

        private void DocIDField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(DocIDField, "Only Digits Allowed!");
            }
            else
            {
                e.Handled = false;
                errorProvider1.SetError(DocIDField, "");
            }
        }
    }
}
