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
using System.Text.RegularExpressions;

namespace HMS_Interface
{
    public partial class Receptionist_2 : Form
    {
        public Receptionist_2()
        {
            InitializeComponent();
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (txtPatientName.Text == " PatientName")
            {
                txtPatientName.Text = "";

                txtPatientName.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (txtPatientAge.Text == " PatientAge")
            {
                txtPatientAge.Text = "";

                txtPatientAge.ForeColor = Color.Black;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (txtPatientPhone.Text == " PatientContact")
            {
                txtPatientPhone.Text = "";

                txtPatientPhone.ForeColor = Color.Black;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (txtPatientCNIC.Text == " PatientCNIC")
            {
                txtPatientCNIC.Text = "";

                txtPatientCNIC.ForeColor = Color.Black;
            }
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (txtAddress.Text == " PatientAddress")
            {
                txtAddress.Text = "";

                txtAddress.ForeColor = Color.Black;
            }
        }


        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (txtPatientName.Text == "")
            {
                txtPatientName.Text = " PatientName";

                txtPatientName.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (txtPatientAge.Text == "")
            {
                txtPatientAge.Text = " PatientAge";

                txtPatientAge.ForeColor = Color.Silver;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (txtPatientPhone.Text == "")
            {
                txtPatientPhone.Text = " PatientContact";

                txtPatientPhone.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (txtPatientCNIC.Text == "")
            {
                txtPatientCNIC.Text = " PatientCNIC";

                txtPatientCNIC.ForeColor = Color.Silver;
            }
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (txtAddress.Text == "")
            {
                txtAddress.Text = " PatientAddress";

                txtAddress.ForeColor = Color.Silver;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtPatientAge.CausesValidation = false;
            txtPatientCNIC.CausesValidation = false;
            txtPatientPhone.CausesValidation = false;
            Receptionist r = new Receptionist();
            r.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPatientAge.CausesValidation = false;
            txtPatientCNIC.CausesValidation = false;
            txtPatientPhone.CausesValidation = false;
            Receptionist_1 r = new Receptionist_1();
            r.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPatientAge.CausesValidation = false;
            txtPatientCNIC.CausesValidation = false;
            txtPatientPhone.CausesValidation = false;
            Receptionist_2 r = new Receptionist_2();
            r.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtPatientAge.CausesValidation = false;
            txtPatientCNIC.CausesValidation = false;
            txtPatientPhone.CausesValidation = false;
            Form1 r = new Form1();
            r.Show();
            this.Close();
        }

        private void Receptionist_2_Load(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.Color.Black;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (txtPatientName.Text == "" || txtPatientName.Text == " PatientName" || txtPatientAge.Text == "" || txtPatientAge.Text == " PatientAge" || txtPatientCNIC.Text == "" || txtPatientCNIC.Text == " PatientCNIC")
            {
                MessageBox.Show("Enter Required Fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isNumeric(txtPatientAge.Text) && isAlpha(txtPatientName.Text) && (isValidateCNIC(txtPatientCNIC.Text)) && (isValidateContact(txtPatientPhone.Text) || txtPatientPhone.Text == " PatientContact"))
            {
                goto label1;
            }
            else {
                MessageBox.Show("Enter correct format!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            label1:
            string gender = "NULL";
            if(radioButton1.Checked)
            {
                gender = "Male";
            }
            else if (radioButton2.Checked)
            {
                gender = "Female";
            }
            if (txtPatientPhone.Text == " PatientContact" || txtPatientPhone.Text == "") {
                txtPatientPhone.Text = "NULL";
                txtPatientPhone.ForeColor = Color.Black;
            }
            if (txtAddress.Text == " PatientAddress" || txtAddress.Text == "") {
                txtAddress.Text = "NULL";
                txtAddress.ForeColor = Color.Black;
            }
            if (cmbBloodGroup.Text == "") {
                cmbBloodGroup.Text = "null";
            }
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Patient(Patient_name, Patient_contact, Patient_CNIC,Patient_address, Patient_age, Patient_gender, Patient_DOB, Patient_BldGrp) values (@b, @c, @d, @e, @f, @g, @h, @i)", con);
            cmd.Parameters.AddWithValue("@b", txtPatientName.Text);
            cmd.Parameters.AddWithValue("@c", txtPatientPhone.Text);
            cmd.Parameters.AddWithValue("@d", txtPatientCNIC.Text);
            cmd.Parameters.AddWithValue("@e", txtAddress.Text);
            cmd.Parameters.AddWithValue("@f", int.Parse(txtPatientAge.Text));
            cmd.Parameters.AddWithValue("@g", gender);
            cmd.Parameters.AddWithValue("@h", pkrDOB.Text);
            cmd.Parameters.AddWithValue("@i", cmbBloodGroup.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Patient has been registered!", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Receptionist_2 r = new Receptionist_2();
            r.Show();
            this.Close();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool isNumeric(string input)
        {
            bool result;
            foreach (char i in input)
            {
                result = Char.IsDigit(i);
                if (!result)
                {
                    return false;
                }
            }
            return true;
        }

        private bool isAlpha(string input)
        {
            bool result;
            foreach (char i in input)
            {
                result = Char.IsLetter(i);
                if (!result)
                {
                    return false;
                }
            }
            return true;
        }

        private bool isValidateContact(string input)
        {
            Regex r = new Regex(@"^[0][3]\d{9}$");
            if (r.IsMatch(txtPatientPhone.Text)) {
                return true;
            }
            return false;
        }

        private bool isValidateCNIC(string input)
        {
            Regex r = new Regex(@"^\d{13}$");
            if (r.IsMatch(txtPatientCNIC.Text))
            {
                return true;
            }
            return false;
        }

        private void txtPatientName_Validating(object sender, CancelEventArgs e)
        {
            if (txtPatientName.Text == " PatientName")
            {
                e.Cancel = true;
                txtPatientName.Focus();
                errorProvider1.SetError(txtPatientName, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPatientName, null);
            }

            if (!isAlpha(txtPatientName.Text))
            {
                e.Cancel = true;
                txtPatientName.Focus();
                errorProvider7.SetError(txtPatientName, "Input must be in alphabets!");
            }
            else
            {
                e.Cancel = false;
                errorProvider7.SetError(txtPatientName, null);
            }
        }

        private void txtPatientAge_Validating(object sender, CancelEventArgs e)
        {
            if (txtPatientAge.Text == " PatientAge")
            {
                e.Cancel = true;
                txtPatientAge.Focus();
                errorProvider2.SetError(txtPatientAge, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(txtPatientAge, null);
            }

            if (!isNumeric(txtPatientAge.Text))
            {
                e.Cancel = true;
                txtPatientAge.Focus();
                errorProvider4.SetError(txtPatientAge, "Input must be an integer number!");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(txtPatientAge, null);
            }
        }

        private void txtPatientCNIC_Validating(object sender, CancelEventArgs e)
        {
            if (txtPatientCNIC.Text == " PatientCNIC")
            {
                e.Cancel = true;
                txtPatientCNIC.Focus();
                errorProvider3.SetError(txtPatientCNIC, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(txtPatientCNIC, null);
                if (isValidateCNIC(txtPatientCNIC.Text))
                {
                    e.Cancel = false;
                    errorProvider9.SetError(txtPatientCNIC, null);
                }
                else
                {
                    e.Cancel = true;
                    txtPatientCNIC.Focus();
                    errorProvider9.SetError(txtPatientCNIC, "Format Incorrect!");
                }
            }

        }

        private void txtPatientPhone_Validating(object sender, CancelEventArgs e)
        {
            if (isValidateContact(txtPatientPhone.Text) || txtPatientPhone.Text == " PatientContact")
            {
                e.Cancel = false;
                errorProvider8.SetError(txtPatientPhone, null);
            }
            else
            {
                e.Cancel = true;
                txtPatientPhone.Focus();
                errorProvider8.SetError(txtPatientPhone, "Format Incorrect!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPatientAge.CausesValidation = false;
            txtPatientCNIC.CausesValidation = false;
            txtPatientPhone.CausesValidation = false;
            Receptionist_4 r = new Receptionist_4();
            r.Show();
            this.Close();
        }
    }
}
