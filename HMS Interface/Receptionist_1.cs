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
    public partial class Receptionist_1 : Form
    {
        public Receptionist_1()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtPatientID.Text == " PatientId")
            {
                txtPatientID.Text = "";

                txtPatientID.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtPatientID.Text == "")
            {
                txtPatientID.Text = " PatientId";

                txtPatientID.ForeColor = Color.Silver;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtDoctorID.CausesValidation = false;
            txtPatientID.CausesValidation = false;
            Receptionist r = new Receptionist();
            r.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtDoctorID.CausesValidation = false;
            txtPatientID.CausesValidation = false;
            Receptionist_1 r = new Receptionist_1();
            r.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtDoctorID.CausesValidation = false;
            txtPatientID.CausesValidation = false;
            Receptionist_2 r = new Receptionist_2();
            r.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtDoctorID.CausesValidation = false;
            txtPatientID.CausesValidation = false;
            Form1 r = new Form1();
            r.Show();
            this.Close();
        }

        private void Receptionist_1_Load(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.Color.Black;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (txtDoctorID.Text == " DoctorId" || txtDoctorID.Text == "" || txtPatientID.Text == " PatientId" || txtPatientID.Text == "") {
                MessageBox.Show("Enter all required Fields!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!isNumeric(txtPatientID.Text) || !isNumeric(txtDoctorID.Text))
            {
                MessageBox.Show("Enter correct format!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlConnection con0 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                con0.Open();
                SqlCommand cmd0 = new SqlCommand("select Doctor_id from Doctors where Doctor_id = @a", con0);
                cmd0.Parameters.AddWithValue("@a", txtDoctorID.Text);
                SqlDataReader reader0 = cmd0.ExecuteReader();
                if (!reader0.Read())
                {
                    MessageBox.Show("Doctor ID not found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("select * from Patient where Patient_id = @a", con1);
                cmd1.Parameters.AddWithValue("@a", txtPatientID.Text);
                SqlDataReader reader = cmd1.ExecuteReader();
                if (reader.Read())
                {
                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Appointment(Patient_id, Appointment_date, Appointment_time, Doctor_id) values (@a, @b, @c, @d)", con);
                    cmd.Parameters.AddWithValue("@a", int.Parse(txtPatientID.Text));
                    cmd.Parameters.AddWithValue("@b", pkrDate.Text);
                    cmd.Parameters.AddWithValue("@c", pkrTime.Text);
                    cmd.Parameters.AddWithValue("@d", int.Parse(txtDoctorID.Text));
                    cmd.ExecuteNonQuery();
                    con1.Close();
                    con.Close();
                    MessageBox.Show("Appointment has been added!", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Patient ID not found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Receptionist_1 r = new Receptionist_1();
                r.Show();
                this.Close();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Enter_1(object sender, EventArgs e)
        {
            if (txtDoctorID.Text == " DoctorId")
            {
                txtDoctorID.Text = "";

                txtDoctorID.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            if (txtDoctorID.Text == "")
            {
                txtDoctorID.Text = " DoctorId";

                txtDoctorID.ForeColor = Color.Silver;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Receptionist_3 r = new Receptionist_3();
            r.Show();
            this.Close();
        }

        private bool isNumeric(string input) {
            bool result;
            foreach (char i in input) {
                result = Char.IsDigit(i);
                if (!result) {
                    return false;
                } 
            }
            return true;
        }

        private void txtPatientID_Validating_1(object sender, CancelEventArgs e)
        {
            if (txtPatientID.Text == " PatientId")
            {
                e.Cancel = true;
                txtPatientID.Focus();
                errorProvider2.SetError(txtPatientID, "This field is required!");
            }
            else {
                e.Cancel = false;
                errorProvider2.SetError(txtPatientID, null);

            }
            if (!isNumeric(txtPatientID.Text))
            {
                e.Cancel = true;
                txtPatientID.Focus();
                errorProvider1.SetError(txtPatientID, "Input must be an integer number!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPatientID, null);
            }
        }

        private void txtDoctorID_Validating(object sender, CancelEventArgs e)
        {

            if (txtDoctorID.Text == " DoctorId")
            {
                e.Cancel = true;
                txtDoctorID.Focus();
                errorProvider4.SetError(txtDoctorID, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(txtDoctorID, null);
            }

            if (!isNumeric(txtDoctorID.Text))
            {
                e.Cancel = true;
                txtDoctorID.Focus();
                errorProvider3.SetError(txtDoctorID, "Input must be an integer number!");
            }
            else {
                e.Cancel = false;
                errorProvider3.SetError(txtDoctorID, null);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Receptionist_4 r = new Receptionist_4();
            r.Show();
            this.Close();
        }
    }
}
