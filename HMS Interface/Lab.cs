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
    public partial class Lab : Form
    {
        public Lab()
        {
            InitializeComponent();
        }

        private void Lab_Load(object sender, EventArgs e)
        {
            button6.BackColor = System.Drawing.Color.Black;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Laboratorist where Laboratorist_id = @a", con);
            cmd.Parameters.AddWithValue("@a", Global.ID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtLabID.Text = reader["Laboratorist_id"].ToString();
                txtLabName.Text = reader["Laboratorist_name"].ToString();
                txtLabAge.Text = reader["Laboratorist_age"].ToString();
                txtLabPhone.Text = reader["Laboratorist_contact"].ToString();
                txtLabCNIC.Text = reader["Laboratorist_CNIC"].ToString();
                txtLabGender.Text = reader["Laboratorist_gender"].ToString();
                txtLabDOB.Text = Convert.ToDateTime(reader["Laboratorist_DOB"]).ToString("dd-MM-yyyy");
                txtLabQualification.Text = reader["Laboratorist_qualification"].ToString();
                txtLabAddress.Text = reader["Laboratorist_address"].ToString();
            }
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Lab l = new Lab();
            l.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lab_1 l = new Lab_1();
            l.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lab_2 l = new Lab_2();
            l.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Lab_3 l = new Lab_3();
            l.Show();
            this.Close();
        }
    }
}
