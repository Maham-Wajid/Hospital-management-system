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
    public partial class Lab_1 : Form
    {
        public Lab_1()
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
            txtPatientID.CausesValidation = false;
            Lab l = new Lab();
            l.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            Lab_1 l = new Lab_1();
            l.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            Lab_2 l = new Lab_2();
            l.Show();
            this.Close();
        }

        private DataTable LoadData()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            DataTable dtproducts = new DataTable();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(string.Format("Select Patient_id AS 'Patient ID', Test_Name AS 'Test', Test_date AS 'Date', Result_date AS 'Result Date' from Laboratory where Patient_id = {0} order by Test_date DESC", txtPatientID.Text), con);
            sda.Fill(dtproducts);
            return dtproducts;
        }

        private void Lab_1_Load(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.Color.Black;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            Form1 l = new Form1();
            l.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPatientID.Text == " PatientId" || txtPatientID.Text == "")
            {
                MessageBox.Show("Enter Required Fields!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!isNumeric(txtPatientID.Text))
            {
                MessageBox.Show("Enter correct format!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Patient where Patient_id = @a", con);
            cmd.Parameters.AddWithValue("@a", int.Parse(txtPatientID.Text));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                tblTestResult.DataSource = LoadData();
            }
            else
            {
                MessageBox.Show("Patient Not Found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            Lab_3 l = new Lab_3();
            l.Show();
            this.Close();
        }
    }
}
