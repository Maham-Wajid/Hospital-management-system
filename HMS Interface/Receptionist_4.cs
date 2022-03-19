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
    public partial class Receptionist_4 : Form
    {
        public Receptionist_4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Receptionist_4 r = new Receptionist_4();
            r.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Receptionist r = new Receptionist();
            r.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Receptionist_1 r = new Receptionist_1();
            r.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Receptionist_2 r = new Receptionist_2();
            r.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
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

        private void txtDoctorId_Enter(object sender, EventArgs e)
        {
            if (txtDoctorId.Text == " DoctorId")
            {
                txtDoctorId.Text = "";

                txtDoctorId.ForeColor = Color.Black;
            }
        }

        private void txtDoctorId_Leave(object sender, EventArgs e)
        {
            if (txtDoctorId.Text == "")
            {
                txtDoctorId.Text = " DoctorId";

                txtDoctorId.ForeColor = Color.Silver;
            }

            if (txtPatientID.Text != " PatientId" && txtDoctorId.Text != " DoctorId")
            {
                SqlConnection con4 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                con4.Open();
                SqlCommand cmd4 = new SqlCommand("select Doctor_charges from Doctors where Doctor_id = @a", con4);
                cmd4.Parameters.AddWithValue("@a", int.Parse(txtDoctorId.Text));
                SqlDataReader reader4 = cmd4.ExecuteReader();
                if (reader4.Read())
                {
                    txtCharges.ForeColor = Color.Black;
                    txtCharges.Text = reader4["Doctor_charges"].ToString();
                }
                con4.Close();
            }

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

        private void txtDoctorId_Validating(object sender, CancelEventArgs e)
        {
            if (txtDoctorId.Text == " DoctorId")
            {
                e.Cancel = true;
                txtDoctorId.Focus();
                errorProvider3.SetError(txtDoctorId, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(txtDoctorId, null);
            }

            if (!isNumeric(txtDoctorId.Text))
            {
                e.Cancel = true;
                txtDoctorId.Focus();
                errorProvider4.SetError(txtDoctorId, "Input must be an integer number!");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(txtDoctorId, null);
            }
        }

        private void txtCharges_Validating(object sender, CancelEventArgs e)
        {
            if (txtCharges.Text == " Charges")
            {
                e.Cancel = true;
                txtCharges.Focus();
                errorProvider5.SetError(txtCharges, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider5.SetError(txtCharges, null);
            }

            if (!isNumeric(txtCharges.Text))
            {
                e.Cancel = true;
                txtCharges.Focus();
                errorProvider6.SetError(txtCharges, "Input must be an integer number!");
            }
            else
            {
                e.Cancel = false;
                errorProvider6.SetError(txtCharges, null);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtPatientID.Text == "" || txtPatientID.Text == " PatientId" || txtDoctorId.Text == "" || txtDoctorId.Text == " DoctorId" || txtCharges.Text == "" || txtCharges.Text == " Charges")
            {
                MessageBox.Show("Enter Required Fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!isNumeric(txtPatientID.Text) || !isNumeric(txtDoctorId.Text) || !isNumeric(txtCharges.Text))
            {
                MessageBox.Show("Enter correct format!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlConnection con0 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con0.Open();
            SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con1.Open();
            SqlCommand cmd0 = new SqlCommand("select Patient_id from Patient where Patient_id = @a", con0);
            cmd0.Parameters.AddWithValue("@a", int.Parse(txtPatientID.Text));
            SqlDataReader reader0 = cmd0.ExecuteReader();
            SqlCommand cmd1 = new SqlCommand("select Doctor_id from Doctors where Doctor_id = @a", con1);
            cmd1.Parameters.AddWithValue("@a", txtDoctorId.Text);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            if (!reader0.Read())
            {
                MessageBox.Show("Patient ID not found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con0.Close();
                return;
            }
            if (!reader1.Read())
            {
                MessageBox.Show("Doctor Id not found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con1.Close();
                return;
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Bill(Patient_id, Doctor_id, Doctor_charges, Bill_date) values (@a, @b, @c, @d)", con);
                cmd.Parameters.AddWithValue("@a", int.Parse(txtPatientID.Text));
                cmd.Parameters.AddWithValue("@b", int.Parse(txtDoctorId.Text));
                cmd.Parameters.AddWithValue("@c", int.Parse(txtCharges.Text));
                cmd.Parameters.AddWithValue("@d", pkrCheckupDate.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                con0.Close();
                con1.Close();
                MessageBox.Show("Bill has been registered!", "Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DataTable dtproducts = new DataTable();
            SqlConnection con2 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(string.Format("Select Bill.Patient_id as 'Patient Id', Patient.Patient_name as 'Patient_name',Doctor_id as 'Doctor Id', Bill_date as 'Date', Doctor_Charges as 'Total Amount' from Bill inner join Patient on Bill.Patient_id = Patient.Patient_id where Bill.Patient_id = {0} and Bill_date = (select MAX(Bill_date) from Bill where Patient_id = {0});", txtPatientID.Text), con2);
            sda.Fill(dtproducts);
            tblBill.DataSource = dtproducts;
            con2.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (tblBill.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = xcelApp.Workbooks.Add(Type.Missing);
                for (int i = 1; i < tblBill.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = tblBill.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < tblBill.Rows.Count; i++)
                {
                    for (int j = 0; j < tblBill.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = tblBill.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
                workbook.SaveAs("E:\\Doctor Bill.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
        }
    }
}
