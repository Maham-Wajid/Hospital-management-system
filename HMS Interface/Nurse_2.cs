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
    public partial class Nurse_2 : Form
    {
        public Nurse_2()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            txtpatientBP.CausesValidation = false;
            txtpatienttemperature.CausesValidation = false;
            txtpatientweight.CausesValidation = false;
            Nurse n = new Nurse();
            n.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            txtpatientBP.CausesValidation = false;
            txtpatienttemperature.CausesValidation = false;
            txtpatientweight.CausesValidation = false;
            Nurse_1 n = new Nurse_1();
            n.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            txtpatientBP.CausesValidation = false;
            txtpatienttemperature.CausesValidation = false;
            txtpatientweight.CausesValidation = false;
            Nurse_2 n = new Nurse_2();
            n.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            txtpatientBP.CausesValidation = false;
            txtpatienttemperature.CausesValidation = false;
            txtpatientweight.CausesValidation = false;
            Form1 l = new Form1();
            l.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPatientID_Enter(object sender, EventArgs e)
        {
            if (txtPatientID.Text == " PatientId")
            {
                txtPatientID.Text = "";

                txtPatientID.ForeColor = Color.Black;
            }
        }

        private void txtPatientID_Leave(object sender, EventArgs e)
        {
            if (txtPatientID.Text == "")
            {
                txtPatientID.Text = " PatientId";

                txtPatientID.ForeColor = Color.Silver;
            }
        }

        private void txtpatientBP_Enter(object sender, EventArgs e)
        {
            if (txtpatientBP.Text == " PatientBP")
            {
                txtpatientBP.Text = "";

                txtpatientBP.ForeColor = Color.Black;
            }
        }

        private void txtpatientBP_Leave(object sender, EventArgs e)
        {
            if (txtpatientBP.Text == "")
            {
                txtpatientBP.Text = " PatientBP";

                txtpatientBP.ForeColor = Color.Silver;
            }
        }

        private void txtpatienttemperature_Enter(object sender, EventArgs e)
        {
            if (txtpatienttemperature.Text == " PatientTemperature")
            {
                txtpatienttemperature.Text = "";

                txtpatienttemperature.ForeColor = Color.Black;
            }
        }

        private void txtpatienttemperature_Leave(object sender, EventArgs e)
        {
            if (txtpatienttemperature.Text == "")
            {
                txtpatienttemperature.Text = " PatientTemperature";

                txtpatienttemperature.ForeColor = Color.Silver;
            }
        }

        private void txtpatientweight_Enter(object sender, EventArgs e)
        {
            if (txtpatientweight.Text == " PatientWeight")
            {
                txtpatientweight.Text = "";

                txtpatientweight.ForeColor = Color.Black;
            }
        }

        private void txtpatientweight_Leave(object sender, EventArgs e)
        {
            if (txtpatientweight.Text == "")
            {
                txtpatientweight.Text = " PatientWeight";

                txtpatientweight.ForeColor = Color.Silver;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPatientID.Text == " PatientId" || txtPatientID.Text == "")
            {
                MessageBox.Show("Enter Required Fields!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isNumeric(txtPatientID.Text) && (isNumeric(txtpatienttemperature.Text) || txtpatienttemperature.Text == " PatientTemperature") && (isNumeric(txtpatientweight.Text) || txtpatientweight.Text == " PatientWeight") && (isValidateBP(txtpatientBP.Text) || txtpatientBP.Text == " PatientBP"))
            {
                goto label1;
            }
            else {
                MessageBox.Show("Enter correct format!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            label1:
            SqlConnection con0 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con0.Open();
            SqlCommand cmd0 = new SqlCommand("select Patient_id from Patient where Patient_id = @a", con0);
            cmd0.Parameters.AddWithValue("@a", int.Parse(txtPatientID.Text));
            SqlDataReader reader0 = cmd0.ExecuteReader();
            if (reader0.Read())
            {
                if (txtpatienttemperature.Text == " PatientTemperature" || txtpatienttemperature.Text == "") {
                    txtpatienttemperature.Text = "0";
                    txtpatienttemperature.ForeColor = Color.Black;
                }
                if (txtpatientweight.Text == " PatientWeight" || txtpatientweight.Text == "")
                {
                    txtpatientweight.Text = "0";
                    txtpatientweight.ForeColor = Color.Black;
                }
                if (txtpatientBP.Text == " PatientBP" || txtpatientBP.Text == "")
                {
                    txtpatientBP.Text = "NULL";
                    txtpatientBP.ForeColor = Color.Black;
                }
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into PreCheckup(Patient_id, Temperature, Weight, BloodPressure, Nurse_id) values (@a, @b, @c, @d, @e)", con);
                cmd.Parameters.AddWithValue("@a", int.Parse(txtPatientID.Text));
                cmd.Parameters.AddWithValue("@b", txtpatienttemperature.Text);
                cmd.Parameters.AddWithValue("@c", txtpatientweight.Text);
                cmd.Parameters.AddWithValue("@d", txtpatientBP.Text);
                cmd.Parameters.AddWithValue("@e", Global.ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Pre-Checkup Added!", "Pre-Checkup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Patient ID Not Found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Nurse_2 N = new Nurse_2();
            N.Show();
            this.Close();
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

        private bool isValidateBP(string input)
        {
            Regex r = new Regex(@"^\d{2,3}\/\d{2,3}$");
            if (r.IsMatch(txtpatientBP.Text))
            {
                return true;
            }
            return false;
        }

        private void txtPatientID_Validating(object sender, CancelEventArgs e)
        {
            if (txtPatientID.Text == " PatientId")
            {
                e.Cancel = true;
                txtPatientID.Focus();
                errorProvider1.SetError(txtPatientID, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPatientID, null);
            }

            if (!isNumeric(txtPatientID.Text))
            {
                e.Cancel = true;
                txtPatientID.Focus();
                errorProvider2.SetError(txtPatientID, "Input must be an integer number!");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(txtPatientID, null);
            }
        }

        private void txtpatienttemperature_Validating(object sender, CancelEventArgs e)
        {
            if (isNumeric(txtpatienttemperature.Text) || txtpatienttemperature.Text == " PatientTemperature")
            {
                e.Cancel = false;
                errorProvider3.SetError(txtpatienttemperature, null);
            }
            else
            {
                e.Cancel = true;
                txtpatienttemperature.Focus();
                errorProvider3.SetError(txtpatienttemperature, "Input must be an integer number!");
            }
        }

        private void txtpatientweight_Validating(object sender, CancelEventArgs e)
        {
            if (isNumeric(txtpatientweight.Text) || txtpatientweight.Text == " PatientWeight")
            {
                e.Cancel = false;
                errorProvider4.SetError(txtpatientweight, null);
            }
            else
            {
                e.Cancel = true;
                txtpatientweight.Focus();
                errorProvider4.SetError(txtpatientweight, "Input must be an integer number!");
            }
        }
        private void txtpatientBP_Validating(object sender, CancelEventArgs e)
        {
            if (isValidateBP(txtpatientBP.Text) || txtpatientBP.Text == " PatientBP")
            {
                e.Cancel = false;
                errorProvider5.SetError(txtpatientBP, null);
            }
            else
            {
                e.Cancel = true;
                txtpatientBP.Focus();
                errorProvider5.SetError(txtpatientBP, "Format Incorrect!");
            }
        }
    }
}
