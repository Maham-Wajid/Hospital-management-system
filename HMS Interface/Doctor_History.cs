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
    public partial class Doctor_History : Form
    {
        public Doctor_History()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            Doctor d = new Doctor();
            d.Show();
            this.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            Doctor_Appointments d = new Doctor_Appointments();
            d.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            Form1 d = new Form1();
            d.Show();
            this.Close();
        }

        private void Doctor_2_Load(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.Color.Black;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            Doctor_Checkup d = new Doctor_Checkup();
            d.Show();
            this.Close();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPatientID.Text == " PatientId" || txtPatientID.Text == "")
            {
                MessageBox.Show("Enter required Fields!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                SqlDataAdapter sda = new SqlDataAdapter(string.Format("EXEC CheckupDetails @ID = {0}", txtPatientID.Text), con2);
                sda.Fill(dtproducts);
                tblPatientHistory.DataSource = dtproducts;
                con2.Close();
            }
            else
            {
                MessageBox.Show("Patient\'s Checkup Record Not Found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
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

        private void button3_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            Doctor_History d = new Doctor_History();
            d.Show();
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (tblPatientHistory.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = xcelApp.Workbooks.Add(Type.Missing);
                for (int i = 1; i < tblPatientHistory.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = tblPatientHistory.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < tblPatientHistory.Rows.Count; i++)
                {
                    for (int j = 0; j < tblPatientHistory.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = tblPatientHistory.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
                workbook.SaveAs("E:\\PatientHistory.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
        }
    }
}
