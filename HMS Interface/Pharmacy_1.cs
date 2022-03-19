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
    public partial class Pharmacy_1 : Form
    {
        public Pharmacy_1()
        {
            InitializeComponent();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (txtMedicineName.Text == " MedicineName")
            {
                txtMedicineName.Text = "";

                txtMedicineName.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (txtMedicineName.Text == "")
            {
                txtMedicineName.Text = " MedicineName";

                txtMedicineName.ForeColor = Color.Silver;
            }
        }


        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (txtMedicinePrice.Text == "")
            {
                txtMedicinePrice.Text = " Rupees";

                txtMedicinePrice.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (txtMedicineQuantity.Text == " Quantity")
            {
                txtMedicineQuantity.Text = "";

                txtMedicineQuantity.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (txtMedicineQuantity.Text == "")
            {
                txtMedicineQuantity.Text = " Quantity";

                txtMedicineQuantity.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Enter_1(object sender, EventArgs e)
        {
            if (txtMedicinePrice.Text == " Rupees")
            {
                txtMedicinePrice.Text = "";

                txtMedicinePrice.ForeColor = Color.Black;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtMedicineQuantity.CausesValidation = false;
            txtMedicinePrice.CausesValidation = false;
            Pharmacy p = new Pharmacy();
            p.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMedicineQuantity.CausesValidation = false;
            txtMedicinePrice.CausesValidation = false;
            Pharmacy_1 p = new Pharmacy_1();
            p.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtMedicineQuantity.CausesValidation = false;
            txtMedicinePrice.CausesValidation = false;
            Pharmacy_2 p = new Pharmacy_2();
            p.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtMedicineQuantity.CausesValidation = false;
            txtMedicinePrice.CausesValidation = false;
            Pharmacy_3 p = new Pharmacy_3();
            p.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtMedicineQuantity.CausesValidation = false;
            txtMedicinePrice.CausesValidation = false;
            Pharmacy_4 p = new Pharmacy_4();
            p.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtMedicineQuantity.CausesValidation = false;
            txtMedicinePrice.CausesValidation = false;
            Form1 p = new Form1();
            p.Show();
            this.Close();
        }

        private void Pharmacy_1_Load(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.Color.Black;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            if (txtMedicineName.Text == " MedicineName" || txtMedicineName.Text == "" || txtMedicineQuantity.Text == " Quantity" || txtMedicineQuantity.Text == "" || txtMedicinePrice.Text == " Rupees" || txtMedicinePrice.Text == "")
            {
                MessageBox.Show("Enter Required Fields!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!isNumeric(txtMedicinePrice.Text) || !isNumeric(txtMedicineQuantity.Text))
            {
                MessageBox.Show("Enter correct format!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Medicines(Medicine_name, Medicine_quantity, Medicine_price) values (@b, @c, @d)", con);
            cmd.Parameters.AddWithValue("@b", txtMedicineName.Text);
            cmd.Parameters.AddWithValue("@c", int.Parse(txtMedicineQuantity.Text));
            cmd.Parameters.AddWithValue("@d", int.Parse(txtMedicinePrice.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Medicine Added Successfully!", "Medicine", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            Pharmacy_1 p = new Pharmacy_1();
            p.Show();
            this.Close();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtMedicineQuantity.CausesValidation = false;
            txtMedicinePrice.CausesValidation = false;
            Pharmacy_5 p = new Pharmacy_5();
            p.Show();
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

        private void txtMedicineName_Validating(object sender, CancelEventArgs e)
        {
            if (txtMedicineName.Text == " MedicineName")
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

        private void txtMedicineQuantity_Validating(object sender, CancelEventArgs e)
        {
            if (txtMedicineQuantity.Text == " Quantity")
            {
                e.Cancel = true;
                txtMedicineQuantity.Focus();
                errorProvider2.SetError(txtMedicineQuantity, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(txtMedicineQuantity, null);
            }

            if (!isNumeric(txtMedicineQuantity.Text))
            {
                e.Cancel = true;
                txtMedicineQuantity.Focus();
                errorProvider4.SetError(txtMedicineQuantity, "Input must be an integer number!");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(txtMedicineQuantity, null);
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
    }
}
