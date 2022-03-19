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
    public partial class AdminPatientAdd : Form
    {
        public AdminPatientAdd()
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

        private void Form28_Load(object sender, EventArgs e)
        {
            button13.BackColor = System.Drawing.Color.Black;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (NameField.Text == "Full Name")
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
            if (CNICField.Text == "CNIC")
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
            if (phoneField.Text == "Phone")
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
            if (BldGrpField.Text == "Blood Group")
            {
                BldGrpField.Text = "";
                BldGrpField.ForeColor = Color.Black;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (BldGrpField.Text == "")
            {
                BldGrpField.Text = "Blood Group";
                BldGrpField.ForeColor = Color.Silver;
            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (AgeField.Text == "Age")
            {
                AgeField.Text = "";
                AgeField.ForeColor = Color.Black;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (AgeField.Text == "")
            {
                AgeField.Text = "Age";
                AgeField.ForeColor = Color.Silver;
            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (addressField.Text == "Address")
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
            if (MessageBox.Show("Do you really want to exit application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnPtAdd_Click(object sender, EventArgs e)
        {
            if (NameField.Text != "Full Name" && (Male.Checked) || (Female.Checked) && CNICField.Text != "CNIC" && phoneField.Text != "Phone" && AgeField.Text != "Age" && BldGrpField.Text != "Blood Group")
            {
                SqlCommand cmd = new SqlCommand("insert into Patient(Patient_name,Patient_gender,Patient_CNIC,Patient_DOB,Patient_contact,Patient_age,Patient_BldGrp,Patient_address) values(@PtName,@PtGender,@PtCNIC,@PtDOB,@PtPhone,@PtAge,@PtBldGrp,@PtAddress)", con);
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
            AdminPatientAdd Add = new AdminPatientAdd();
            Add.Show();
            this.Close();
        }
    }
}
