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
    public partial class Receptionist_3 : Form
    {
        public Receptionist_3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            Receptionist_1 r = new Receptionist_1();
            r.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            Receptionist r = new Receptionist();
            r.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            Receptionist_2 r = new Receptionist_2();
            r.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPatientID.Text == " PatientId" || txtPatientID.Text == "")
            {
                MessageBox.Show("Enter all required fields!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!isNumeric(txtPatientID.Text))
            {
                MessageBox.Show("Enter correct format!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Appointment where Patient_id = @a", con);
            cmd.Parameters.AddWithValue("@a", int.Parse(txtPatientID.Text));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                DataTable dtproducts = new DataTable();
                SqlConnection con2 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter(string.Format("Select Appointment.Patient_id AS 'Patient ID', Appointment_date AS 'Date', Appointment_time AS 'Time', Patient.Patient_contact AS 'Patient Contact' FROM Appointment left join Patient ON Appointment.Patient_id = Patient.Patient_id where Appointment.Patient_id = {0} and Appointment_date >= (Select GETDATE()) order by Appointment_date", txtPatientID.Text), con2);
                sda.Fill(dtproducts);
                tblAppointment1.DataSource = dtproducts;
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (tblAppointment1.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = xcelApp.Workbooks.Add(Type.Missing);
                for (int i = 1; i < tblAppointment1.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = tblAppointment1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < tblAppointment1.Rows.Count; i++)
                {
                    for (int j = 0; j < tblAppointment1.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = tblAppointment1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
                workbook.SaveAs("E:\\PatientAppointments.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            Receptionist_4 r = new Receptionist_4();
            r.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtPatientID.Visible = true;
            lblID.Visible = true;
            btnSearch1.Visible = true;
            pkrCheckupDate.Visible = false;
            lblDate.Visible = false;
            btnSearch2.Visible = false;
            tblAppointment1.Visible = true;
            tblAppointment2.Visible = false;
            btnExport1.Visible = true;
            btnExport2.Visible = false;
        }

        private void Receptionist_3_Load(object sender, EventArgs e)
        {
            txtPatientID.Visible = false;
            lblID.Visible = false;
            btnSearch1.Visible = false;
            pkrCheckupDate.Visible = false;
            lblDate.Visible = false;
            btnSearch2.Visible = false;
            btnExport1.Visible = false;
            btnExport2.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtPatientID.Visible = false;
            lblID.Visible = false;
            btnSearch1.Visible = false;
            pkrCheckupDate.Visible = true;
            lblDate.Visible = true;
            btnSearch2.Visible = true;
            tblAppointment1.Visible = false;
            tblAppointment2.Visible = true;
            btnExport1.Visible = false;
            btnExport2.Visible = true;
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
                DataTable dtproducts = new DataTable();
                SqlConnection con2 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter(string.Format("Select Appointment.Patient_id AS 'Patient ID', Appointment_date AS 'Date', Appointment_time AS 'Time', Patient.Patient_contact AS 'Patient Contact' FROM Appointment left join Patient ON Appointment.Patient_id = Patient.Patient_id where datediff(DAY, Appointment_date, '{0}') = 0  order by Appointment_date", (pkrCheckupDate.Text).ToString()), con2);
                sda.Fill(dtproducts);
                tblAppointment2.DataSource = dtproducts;
                con2.Close();
        }

        private void btnExport2_Click(object sender, EventArgs e)
        {
            if (tblAppointment2.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = xcelApp.Workbooks.Add(Type.Missing);
                for (int i = 1; i < tblAppointment2.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = tblAppointment2.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < tblAppointment2.Rows.Count; i++)
                {
                    for (int j = 0; j < tblAppointment2.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = tblAppointment2.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
                workbook.SaveAs("E:\\PatientAppointments.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
        }
    }
}
