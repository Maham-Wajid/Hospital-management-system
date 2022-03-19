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
    public partial class Doctor : Form
    {
        public Doctor()
        {
            InitializeComponent();
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

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 l = new Form1();
            l.Show();
            this.Close();
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Doctors where Doctor_id = @a", con);
            cmd.Parameters.AddWithValue("@a", Global.ID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtDoctorID.Text = reader["Doctor_id"].ToString();
                txtGender.Text = reader["Doctor_gender"].ToString();
                txtDoctorAge.Text = reader["Doctor_age"].ToString();
                txtDoctorName.Text = reader["Doctor_name"].ToString();
                txtDoctorPhone.Text = reader["Doctor_contact"].ToString();
                txtAddress.Text = reader["Doctor_address"].ToString();
                txtDOB.Text = Convert.ToDateTime(reader["Doctor_DOB"]).ToString("dd-MM-yyyy");
                txtQualification.Text = reader["Doctor_qualification"].ToString();
                txtDoctorCNIC.Text = reader["Doctor_CNIC"].ToString();
            }
            con.Close();
            button6.BackColor = System.Drawing.Color.Black;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Doctor_Appointments d = new Doctor_Appointments();
            d.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Doctor_precheckup d = new Doctor_precheckup();
            d.Show();
            this.Close();
        }
    }
}
