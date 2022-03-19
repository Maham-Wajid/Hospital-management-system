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
    public partial class Pharmacy_5 : Form
    {
        public Pharmacy_5()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            txtQuantity.CausesValidation = false;
            txtmedicine.CausesValidation = false;
            Pharmacy_5 p = new Pharmacy_5();
            p.Show();
            this.Close();
        }
        private DataTable LoadData()
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            DataTable dtproducts = new DataTable();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(string.Format("Select Patient_id AS 'Patient ID',Medicine_name AS 'Medicine', Medicine_Duration AS 'Duration',Disease_description AS 'Description', Checkup_date AS 'Date' from Checkup where Patient_id = {0} and Checkup_date = (select MAX(Checkup_date) from Checkup where Patient_id = {0})", txtPatientID.Text), con);
            sda.Fill(dtproducts);
            return dtproducts;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPatientID.Text == " PatientId" || txtPatientID.Text == "") {
                MessageBox.Show("Enter Required Fields", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                tblTestResult.DataSource = LoadData();
            }
            else
            {
                MessageBox.Show("Patient\'s Checkup Record Not Found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            txtQuantity.CausesValidation = false;
            txtmedicine.CausesValidation = false;
            Pharmacy p = new Pharmacy();
            p.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            txtQuantity.CausesValidation = false;
            txtmedicine.CausesValidation = false;
            Pharmacy_1 p = new Pharmacy_1();
            p.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            txtQuantity.CausesValidation = false;
            txtmedicine.CausesValidation = false;
            Pharmacy_2 p = new Pharmacy_2();
            p.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            txtQuantity.CausesValidation = false;
            txtmedicine.CausesValidation = false;
            Pharmacy_3 p = new Pharmacy_3();
            p.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            txtQuantity.CausesValidation = false;
            txtmedicine.CausesValidation = false;
            Pharmacy_4 p = new Pharmacy_4();
            p.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            txtQuantity.CausesValidation = false;
            txtmedicine.CausesValidation = false;
            Form1 p = new Form1();
            p.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtPatientID.CausesValidation = false;
            txtQuantity.CausesValidation = false;
            txtmedicine.CausesValidation = false;
            Application.Exit();
        }

        private void txtPatientID_Leave(object sender, EventArgs e)
        {
            if (txtPatientID.Text == "")
            {
                txtPatientID.Text = " PatientId";

                txtPatientID.ForeColor = Color.Silver;
            }
        }

        private void txtPatientID_Enter(object sender, EventArgs e)
        {
            if (txtPatientID.Text == " PatientId")
            {
                txtPatientID.Text = "";

                txtPatientID.ForeColor = Color.Black;
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (txtPatientID.Text == "" || txtPatientID.Text == " PatientId" || txtmedicine.Text == "" || txtmedicine.Text == " MedicineName" || txtQuantity.Text == "" || txtQuantity.Text == " Quantity")
            {
                MessageBox.Show("Enter Required Fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!isNumeric(txtQuantity.Text) || !isNumeric(txtPatientID.Text)) {
                MessageBox.Show("Enter correct Format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlConnection con0 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con0.Open();
            SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con1.Open();
            SqlConnection con3 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con3.Open();
            SqlCommand cmd0 = new SqlCommand("select Patient_id from Patient where Patient_id = @a", con0);
            cmd0.Parameters.AddWithValue("@a", int.Parse(txtPatientID.Text));
            SqlDataReader reader0 = cmd0.ExecuteReader();
            SqlCommand cmd1 = new SqlCommand("select Medicine_name from Medicines where Medicine_name = @a", con1);
            cmd1.Parameters.AddWithValue("@a", txtmedicine.Text);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            SqlCommand cmd2 = new SqlCommand("select Medicine_quantity from Medicines where Medicine_quantity > @a", con3);
            cmd2.Parameters.AddWithValue("@a", int.Parse(txtQuantity.Text));
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (!reader0.Read())
            {
                MessageBox.Show("Patient ID not found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con0.Close();
                return;
            }
            if (!reader1.Read())
            {
                MessageBox.Show("Medicine Name not found!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con1.Close();
                return;
            }
            if (!reader2.Read())
            {
                MessageBox.Show("Quantity that stored is less!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con3.Close();
                return;
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Medicine_Receipt(Patient_id, Medicine_name, Quantity, Bill_Date, Bill_Amount, Pharmacist_id) values (@a, @b, @c, @d, @e, @f)", con);
            cmd.Parameters.AddWithValue("@a", int.Parse(txtPatientID.Text));
            cmd.Parameters.AddWithValue("@b", txtmedicine.Text);
            cmd.Parameters.AddWithValue("@c", int.Parse(txtQuantity.Text));
            cmd.Parameters.AddWithValue("@d", pkrCheckupDate.Text);
            cmd.Parameters.AddWithValue("@e", int.Parse(txtPrice.Text) * int.Parse(txtQuantity.Text));
            cmd.Parameters.AddWithValue("@f", Global.ID);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Receipt Added Successfully!", "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con0.Close();
            con.Close();
            con1.Close();
            con3.Close();
            }
            SqlConnection con2 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con2.Open();
            SqlCommand cmd3 = new SqlCommand("update Medicines set Medicine_quantity = Medicine_quantity - @a where Medicine_Name = @b", con2);
            cmd3.Parameters.AddWithValue("@a", int.Parse(txtQuantity.Text));
            cmd3.Parameters.AddWithValue("@b", txtmedicine.Text);
            cmd3.ExecuteNonQuery();
            con2.Close();

            DataTable dtproducts = new DataTable();
            SqlConnection con5 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(string.Format("Select Pharmacist_id as 'Pharmacist Id', Patient_name as 'Patient_name',Medicine_name as 'Medicine name', Quantity,Medicine_Receipt.Bill_Date as 'Date', Bill_Amount as 'Total Amount' from Medicine_Receipt inner join Patient on Medicine_Receipt.Patient_id = Patient.Patient_id where Medicine_Receipt.Patient_id = {0} and Bill_Date = (select MAX(Bill_Date) from Medicine_Receipt where Patient_id = {0});", txtPatientID.Text), con5);
            sda.Fill(dtproducts);
            tblMedReceipt.DataSource = dtproducts;
            con2.Close();
        }

        private void txtmedicine_Enter(object sender, EventArgs e)
        {
            if (txtmedicine.Text == " MedicineName")
            {
                txtmedicine.Text = "";

                txtmedicine.ForeColor = Color.Black;
            }
        }

        private void txtQuantity_Enter(object sender, EventArgs e)
        {
            if (txtQuantity.Text == " Quantity")
            {
                txtQuantity.Text = "";

                txtQuantity.ForeColor = Color.Black;
            }
        }

        private void txtmedicine_Leave(object sender, EventArgs e)
        {
            if (txtmedicine.Text == "")
            {
                txtmedicine.Text = " MedicineName";

                txtmedicine.ForeColor = Color.Silver;
            }
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "")
            {
                txtQuantity.Text = " Quantity";

                txtQuantity.ForeColor = Color.Silver;
            }
            if (txtmedicine.Text != " MedicineName" && txtQuantity.Text != " Qunatity")
            {
                SqlConnection con4 = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
                con4.Open();
                SqlCommand cmd4 = new SqlCommand("select Medicine_price from Medicines where Medicine_name = @a", con4);
                cmd4.Parameters.AddWithValue("@a", txtmedicine.Text);
                SqlDataReader reader4 = cmd4.ExecuteReader();
                if (reader4.Read())
                {
                    txtPrice.ForeColor = Color.Black;
                    txtPrice.Text = reader4["Medicine_price"].ToString();
                }
                con4.Close();
            }
        }

        private void txtmedicine_Validating(object sender, CancelEventArgs e)
        {
            if (txtmedicine.Text == " MedicineName")
            {
                e.Cancel = true;
                txtmedicine.Focus();
                errorProvider3.SetError(txtmedicine, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(txtmedicine, null);
            }
        }

        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            if (txtQuantity.Text == " Quantity")
            {
                e.Cancel = true;
                txtQuantity.Focus();
                errorProvider4.SetError(txtQuantity, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(txtQuantity, null);
            }

            if (!isNumeric(txtQuantity.Text))
            {
                e.Cancel = true;
                txtQuantity.Focus();
                errorProvider5.SetError(txtQuantity, "Input must be an integer number!");
            }
            else
            {
                e.Cancel = false;
                errorProvider5.SetError(txtQuantity, null);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {
            if (tblMedReceipt.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = xcelApp.Workbooks.Add(Type.Missing);
                for (int i = 1; i < tblMedReceipt.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = tblMedReceipt.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < tblMedReceipt.Rows.Count; i++)
                {
                    for (int j = 0; j < tblMedReceipt.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = tblMedReceipt.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
                workbook.SaveAs("E:\\Medicine Receipt.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
        }
    }
}
