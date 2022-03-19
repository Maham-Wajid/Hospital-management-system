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
    public partial class Lab_2 : Form
    {
        public Lab_2()
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

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (txtTestName.Text == " TestName")
            {
                txtTestName.Text = "";

                txtTestName.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (txtTestName.Text == "")
            {
                txtTestName.Text = " TestName";

                txtTestName.ForeColor = Color.Silver;
            }
            if (txtTestName.Text != " TestName")
            {
                SqlConnection con4 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                con4.Open();
                SqlCommand cmd4 = new SqlCommand("select Test_price from Test where Test_name = @a", con4);
                cmd4.Parameters.AddWithValue("@a", txtTestName.Text);
                SqlDataReader reader4 = cmd4.ExecuteReader();
                if (reader4.Read())
                {
                    txtamount.ForeColor = Color.Black;
                    txtamount.Text = reader4["Test_price"].ToString();
                }
                con4.Close();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            txtTestName.CausesValidation = false;
            Lab l = new Lab();
            l.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            txtTestName.CausesValidation = false;
            Lab_1 l = new Lab_1();
            l.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            txtTestName.CausesValidation = false;
            Lab_2 l = new Lab_2();
            l.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            txtTestName.CausesValidation = false;
            Form1 l = new Form1();
            l.Show();
            this.Close();

        }

        private void Lab_2_Load(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.Color.Black;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (txtPatientID.Text == " PatientId" || txtPatientID.Text == "" || txtTestName.Text == " TestName" || txtTestName.Text == "")
            {
                MessageBox.Show("Enter Required Fields!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!isNumeric(txtPatientID.Text))
            {
                MessageBox.Show("Enter correct format!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select Test_name from Test where Test_name = @a", con1);
            cmd1.Parameters.AddWithValue("@a", txtTestName.Text);
            SqlDataReader reader2 = cmd1.ExecuteReader();
            if (!reader2.Read())
            {
                MessageBox.Show("Test Name not found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con1.Close();
                return;
            }

            SqlConnection con0 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con0.Open();
            SqlCommand cmd0 = new SqlCommand("select * from Checkup where Patient_id = @a", con0);
            cmd0.Parameters.AddWithValue("@a", int.Parse(txtPatientID.Text));
            SqlDataReader reader = cmd0.ExecuteReader();
            if (reader.Read())
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Laboratory(patient_id, Test_name, Test_date, Result_date,Test_amount, Laboratorist_id) values(@a, @c, @d, @e, @f, @g)", con);
                cmd.Parameters.AddWithValue("@a", int.Parse(txtPatientID.Text));
                cmd.Parameters.AddWithValue("@c", txtTestName.Text);
                cmd.Parameters.AddWithValue("@d", pkrTestDate.Text);
                cmd.Parameters.AddWithValue("@e", pkrResultDate.Text);
                cmd.Parameters.AddWithValue("@f", int.Parse(txtamount.Text));
                cmd.Parameters.AddWithValue("@g", Global.ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Report Added Succesfully!", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Patient\'s Checkup Record Not Found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SqlConnection con4 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con4.Open();
            SqlCommand cmd4 = new SqlCommand("select * from Checkup where Patient_id = @a", con4);
            cmd4.Parameters.AddWithValue("@a", int.Parse(txtPatientID.Text));
            SqlDataReader reader1 = cmd4.ExecuteReader();
            if (reader1.Read())
            {
                DataTable Receipt = new DataTable();
                SqlConnection con5 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                SqlDataAdapter sda4 = new SqlDataAdapter(string.Format("select Laboratorist_id as 'Laboratorist ID',Patient.Patient_name as 'Patient Name', Test_name as 'Test Name', Test_date as 'Test date',Test_amount as 'Test amount' from Laboratory inner join Patient on Laboratory.Patient_id = Patient.Patient_id where Laboratory.Patient_id = {0} and Test_date = (select MAX(Test_date) from Laboratory)", txtPatientID.Text), con5);
                sda4.Fill(Receipt);
                tblReceipt.DataSource = Receipt;
                con4.Close();
                con5.Close();
            }
            else
            {
                MessageBox.Show("Patient\'s Checkup Record Not Found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
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
            SqlCommand cmd = new SqlCommand("select * from Checkup where Patient_id = @a", con);
            cmd.Parameters.AddWithValue("@a", int.Parse(txtPatientID.Text));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                DataTable dtproducts = new DataTable();
                SqlConnection con2 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter(string.Format("Select Test_name AS 'Test', Checkup_date AS 'Date' from Checkup where Patient_id = {0} and Checkup_date = (select MAX(Checkup_date) from Checkup where patient_id = {0})", txtPatientID.Text), con2);
                sda.Fill(dtproducts);
                tblCheckupTests.DataSource = dtproducts;
                con2.Close();
            }
            else
            {
                MessageBox.Show("Patient\'s Checkup Record Not Found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtTestName_Validating(object sender, CancelEventArgs e)
        {
            if (txtTestName.Text == " TestName")
            {
                e.Cancel = true;
                txtTestName.Focus();
                errorProvider2.SetError(txtTestName, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(txtTestName, null);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (tblReceipt.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = xcelApp.Workbooks.Add(Type.Missing);
                for (int i = 1; i < tblReceipt.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = tblReceipt.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < tblReceipt.Rows.Count; i++)
                {
                    for (int j = 0; j < tblReceipt.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = tblReceipt.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
                workbook.SaveAs("E:\\ReportReceipt.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            txtTestName.CausesValidation = false;
            Lab_3 l = new Lab_3();
            l.Show();
            this.Close();
        }
    }
}
