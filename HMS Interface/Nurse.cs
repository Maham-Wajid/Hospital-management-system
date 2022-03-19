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
    public partial class Nurse : Form
    {
        public Nurse()
        {
            InitializeComponent();
        }

        private void Nurse_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Nurses where Nurse_id = @a", con);
            cmd.Parameters.AddWithValue("@a", Global.ID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtNurseID.Text = reader["Nurse_id"].ToString();
                txtNurseName.Text = reader["Nurse_name"].ToString();
                txtNurseAge.Text = reader["Nurse_age"].ToString();
                txtNursePhone.Text = reader["Nurse_contact"].ToString();
                txtNurseCNIC.Text = reader["Nurse_CNIC"].ToString();
                txtNurseGender.Text = reader["Nurse_gender"].ToString();
                txtNurseDOB.Text = Convert.ToDateTime(reader["Nurse_DOB"]).ToString("dd-MM-yyyy");
                txtNurseQualification.Text = reader["Nurse_qualification"].ToString();
                txtNurseAddress.Text = reader["Nurse_address"].ToString();
            }
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Nurse n = new Nurse();
            n.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Nurse_1 n = new Nurse_1();
            n.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            Nurse_2 n = new Nurse_2();
            n.Show();
            this.Close();
        }
    }
}
