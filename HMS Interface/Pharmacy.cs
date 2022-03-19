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
    public partial class Pharmacy : Form
    {
        public Pharmacy()
        {
            InitializeComponent();
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

        private void Pharmacy_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Pharmacist where Pharmacist_id = @a", con);
            cmd.Parameters.AddWithValue("@a", Global.ID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtID.Text = reader["Pharmacist_id"].ToString();
                txtName.Text = reader["Pharmacist_name"].ToString();
                txtAge.Text = reader["Pharmacist_age"].ToString();
                txtPhone.Text = reader["Pharmacist_contact"].ToString();
                txtCNIC.Text = reader["Pharmacist_CNIC"].ToString();
                txtgender.Text = reader["Pharmacist_gender"].ToString();
                txtDOB.Text = Convert.ToDateTime(reader["Pharmacist_DOB"]).ToString("dd-MM-yyyy");
                txtQualification.Text = reader["Pharmacist_qualification"].ToString();
                txtAddress.Text = reader["Pharmacist_address"].ToString();
            }
            con.Close();
            button6.BackColor = System.Drawing.Color.Black;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Pharmacy_5 p = new Pharmacy_5();
            p.Show();
            this.Close();
        }
    }
}
