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
    public partial class Doctor_Appointments : Form
    {
        public Doctor_Appointments()
        {
            InitializeComponent();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            Doctor d = new Doctor();
            d.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Doctor_Checkup d = new Doctor_Checkup();
            d.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Doctor_History d = new Doctor_History();
            d.Show();
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Doctor_Appointments d = new Doctor_Appointments();
            d.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 d = new Form1();
            d.Show();
            this.Close();
        }
        private DataTable LoadData()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con.Open();
            DataTable tbl = new DataTable();
            SqlDataAdapter sdl = new SqlDataAdapter(string.Format("Select Appointment.Patient_id AS 'Patient ID', Appointment_date AS 'Date', Appointment_time AS 'Time', Patient.Patient_contact AS 'Patient Contact' FROM Appointment left join Patient ON Appointment.Patient_id = Patient.Patient_id where Appointment_date >= (select GETDATE()) order by Appointment_date"), con);
            sdl.Fill(tbl);
            con.Close();
            return tbl;
        }

        private void Doctor_4_Load(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.Color.Black;
            tblDoctorAppointment.DataSource = LoadData();
        }


        private void button7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Doctor_precheckup d = new Doctor_precheckup();
            d.Show();
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (tblDoctorAppointment.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = xcelApp.Workbooks.Add(Type.Missing);
                for (int i = 1; i < tblDoctorAppointment.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = tblDoctorAppointment.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < tblDoctorAppointment.Rows.Count; i++)
                {
                    for (int j = 0; j < tblDoctorAppointment.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = tblDoctorAppointment.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
                workbook.SaveAs("E:\\DoctorAppointments.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
        }
    }
}
