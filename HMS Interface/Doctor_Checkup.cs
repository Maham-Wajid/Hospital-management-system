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
    public partial class Doctor_Checkup : Form
    {
        public Doctor_Checkup()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtPatientId.Text == " PatientId")
            {
                txtPatientId.Text = "";

                txtPatientId.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtPatientId.Text == "")
            {
                txtPatientId.Text = " PatientId";

                txtPatientId.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (txtMedicineName.Text == " Medicines")
            {
                txtMedicineName.Text = "";

                txtMedicineName.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (txtMedicineName.Text == "")
            {
                txtMedicineName.Text = " Medicines";

                txtMedicineName.ForeColor = Color.Silver;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (txtMedicineDuration.Text == " Days")
            {
                txtMedicineDuration.Text = "";

                txtMedicineDuration.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (txtMedicineDuration.Text == "")
            {
                txtMedicineDuration.Text = " Days";

                txtMedicineDuration.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (txtTestName.Text == " Tests")
            {
                txtTestName.Text = "";

                txtTestName.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (txtTestName.Text == "")
            {
                txtTestName.Text = " Tests";

                txtTestName.ForeColor = Color.Silver;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtPatientId.CausesValidation = false;
            txtMedicineDuration.CausesValidation = false;
            Doctor d = new Doctor();
            d.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPatientId.CausesValidation = false;
            txtMedicineDuration.CausesValidation = false;
            Doctor_Checkup d = new Doctor_Checkup();
            d.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPatientId.CausesValidation = false;
            txtMedicineDuration.CausesValidation = false;
            Doctor_History d = new Doctor_History();
            d.Show();
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            txtPatientId.CausesValidation = false;
            txtMedicineDuration.CausesValidation = false;
            Doctor_Appointments d = new Doctor_Appointments();
            d.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtPatientId.CausesValidation = false;
            txtMedicineDuration.CausesValidation = false;
            Form1 d = new Form1();
            d.Show();
            this.Close();
        }

        private void Doctor_1_Load(object sender, EventArgs e)
        {
            button2.BackColor = System.Drawing.Color.Black;
        }

        private void richTextBox1_Enter_1(object sender, EventArgs e)
        {
            if (txtDescription.Text == " AddDescription")
            {
                txtDescription.Text = "";

                txtDescription.ForeColor = Color.Black;
            }
        }

        private void richTextBox1_Leave_1(object sender, EventArgs e)
        {
            if (txtDescription.Text == "")
            {
                txtDescription.Text = " AddDescription";

                txtDescription.ForeColor = Color.Silver;
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtPatientId.Text == " PatientId" || txtPatientId.Text == "") {
                MessageBox.Show("Enter Required Fields!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (isNumeric(txtPatientId.Text) && (isNumeric(txtMedicineDuration.Text) || txtMedicineDuration.Text == " Days"))
            {
                goto label1;
            }
            else
            {
                MessageBox.Show("Enter correct format!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            label1:
            SqlConnection con0 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con0.Open();
            SqlCommand cmd0 = new SqlCommand("select Patient_id from Patient where Patient_id = @a", con0);
            cmd0.Parameters.AddWithValue("@a", int.Parse(txtPatientId.Text));
            SqlDataReader reader0 = cmd0.ExecuteReader();
            if (!reader0.Read())
            {
                MessageBox.Show("Patient ID not found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con0.Close();
                return;
            }
            else
            {
                if (txtMedicineDuration.Text == " Days" || txtMedicineDuration.Text == null)
                {
                    txtMedicineDuration.Text = "0";
                    txtMedicineDuration.ForeColor = Color.Black;
                }
                if (txtMedicineName.Text == " Medicines" || txtMedicineName.Text == null)
                {
                    txtMedicineName.Text = "NULL";
                    txtMedicineName.ForeColor = Color.Black;
                }
                if (txtTestName.Text == " Tests" || txtTestName.Text == null)
                {
                    txtTestName.Text = "NULL";
                    txtTestName.ForeColor = Color.Black;
                }
                if (txtDescription.Text == " AddDescription" || txtDescription.Text == null)
                {
                    txtDescription.Text = "NULL";
                    txtDescription.ForeColor = Color.Black;
                }
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Checkup(Patient_id, Medicine_name, Test_name, Medicine_duration, Disease_description, Checkup_date, Doctor_id) values (@a, @b, @c, @d, @e, @f, @g)", con);
                cmd.Parameters.AddWithValue("@a", int.Parse(txtPatientId.Text));
                cmd.Parameters.AddWithValue("@b", txtMedicineName.Text);
                cmd.Parameters.AddWithValue("@c", txtTestName.Text);
                cmd.Parameters.AddWithValue("@d", int.Parse(txtMedicineDuration.Text));
                cmd.Parameters.AddWithValue("@e", txtDescription.Text);
                cmd.Parameters.AddWithValue("@f", pkrCheckupDate.Text);
                cmd.Parameters.AddWithValue("@g", Global.ID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Checkup Details Added Successfully!", "Checkup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con0.Close();
                con.Close();
            }
            Doctor_Checkup d = new Doctor_Checkup();
            d.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtPatientId.CausesValidation = false;
            txtMedicineDuration.CausesValidation = false;
            Doctor_precheckup d = new Doctor_precheckup();
            d.Show();
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

        private void txtPatientId_Validating(object sender, CancelEventArgs e)
        {
            if (txtPatientId.Text == " PatientId")
            {
                e.Cancel = true;
                txtPatientId.Focus();
                errorProvider1.SetError(txtPatientId, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPatientId, null);
            }

            if (!isNumeric(txtPatientId.Text))
            {
                e.Cancel = true;
                txtPatientId.Focus();
                errorProvider2.SetError(txtPatientId, "Input must be an integer number!");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(txtPatientId, null);
            }
        }

        private void txtMedicineDuration_Validating(object sender, CancelEventArgs e)
        {
            if (isNumeric(txtMedicineDuration.Text) || txtMedicineDuration.Text == " Days")
            {
                e.Cancel = false;
                errorProvider3.SetError(txtMedicineDuration, null);
            }
            else
            {
                e.Cancel = true;
                txtMedicineDuration.Focus();
                errorProvider3.SetError(txtMedicineDuration, "Input must be an integer number!");
            }
        }
    }
}
