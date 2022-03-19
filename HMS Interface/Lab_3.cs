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
    public partial class Lab_3 : Form
    {
        public Lab_3()
        {
            InitializeComponent();
        }

        private void txtMedicineName_Enter(object sender, EventArgs e)
        {
            if (txtMedicineName.Text == " TestName")
            {
                txtMedicineName.Text = "";

                txtMedicineName.ForeColor = Color.Black;
            }
        }

        private void txtMedicineName_Leave(object sender, EventArgs e)
        {
            if (txtMedicineName.Text == "")
            {
                txtMedicineName.Text = " TestName";

                txtMedicineName.ForeColor = Color.Silver;
            }
        }

        private void txtMedicinePrice_Enter(object sender, EventArgs e)
        {
            if (txtMedicinePrice.Text == " Rupees")
            {
                txtMedicinePrice.Text = "";

                txtMedicinePrice.ForeColor = Color.Black;
            }
        }

        private void txtMedicinePrice_Leave(object sender, EventArgs e)
        {
            if (txtMedicinePrice.Text == "")
            {
                txtMedicinePrice.Text = " Rupees";

                txtMedicinePrice.ForeColor = Color.Silver;
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtMedicineName.Text == " MedicineName" || txtMedicineName.Text == "" || txtMedicinePrice.Text == " Rupees" || txtMedicinePrice.Text == "")
            {
                MessageBox.Show("Enter Required Fields!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!isNumeric(txtMedicinePrice.Text))
            {
                MessageBox.Show("Enter correct format!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Test(Test_name, Test_price) values (@a, @b)", con);
            cmd.Parameters.AddWithValue("@a", txtMedicineName.Text);
            cmd.Parameters.AddWithValue("@b", int.Parse(txtMedicinePrice.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Test Added Successfully!", "Medicine", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            Lab_3 l = new Lab_3();
            l.Show();
            this.Close();
        }

        private void txtMedicineName_Validating(object sender, CancelEventArgs e)
        {
            if (txtMedicineName.Text == " TestName")
            {
                e.Cancel = true;
                txtMedicineName.Focus();
                errorProvider1.SetError(txtMedicineName, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtMedicineName, null);
            }
        }

        private void txtMedicinePrice_Validating(object sender, CancelEventArgs e)
        {
            if (txtMedicinePrice.Text == " Rupees")
            {
                e.Cancel = true;
                txtMedicinePrice.Focus();
                errorProvider2.SetError(txtMedicinePrice, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(txtMedicinePrice, null);
            }

            if (!isNumeric(txtMedicinePrice.Text))
            {
                e.Cancel = true;
                txtMedicinePrice.Focus();
                errorProvider3.SetError(txtMedicinePrice, "Input must be an integer number!");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(txtMedicinePrice, null);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtMedicineName.CausesValidation = false;
            txtMedicinePrice.CausesValidation = false;
            Lab l = new Lab();
            l.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMedicineName.CausesValidation = false;
            txtMedicinePrice.CausesValidation = false;
            Lab_1 l = new Lab_1();
            l.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtMedicineName.CausesValidation = false;
            txtMedicinePrice.CausesValidation = false;
            Lab_2 l = new Lab_2();
            l.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtMedicineName.CausesValidation = false;
            txtMedicinePrice.CausesValidation = false;
            Lab_3 l = new Lab_3();
            l.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtMedicineName.CausesValidation = false;
            txtMedicinePrice.CausesValidation = false;
            Form1 l = new Form1();
            l.Show();
            this.Close();
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
