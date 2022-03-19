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
    public partial class Pharmacy_2 : Form
    {
        public Pharmacy_2()
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

        private void button6_Click(object sender, EventArgs e)
        {
            Pharmacy p = new Pharmacy();
            p.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pharmacy_1 p = new Pharmacy_1();
            p.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pharmacy_2 p = new Pharmacy_2();
            p.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pharmacy_3 p = new Pharmacy_3();
            p.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Pharmacy_4 p = new Pharmacy_4();
            p.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 p = new Form1();
            p.Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pharmacy_2_Load(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.Color.Black;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (txtMedicineName.Text == " MedicineName" || txtMedicineName.Text == "" )
            {
                MessageBox.Show("Enter Required Fields!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Medicine_quantity from Medicines where Medicine_name = @a", con);
            cmd.Parameters.AddWithValue("@a", txtMedicineName.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show(string.Format("Remaining Quantity is: {0}", reader["Medicine_quantity"]), "Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Medicine Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Pharmacy_5 p = new Pharmacy_5();
            p.Show();
            this.Close();
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
    }
}
