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
    public partial class Receptionist : Form
    {
        public Receptionist()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Receptionist r = new Receptionist();
            r.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Receptionist_1 r = new Receptionist_1();
            r.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Receptionist_2 r = new Receptionist_2();
            r.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 r = new Form1();
            r.Show();
            this.Close();
        }

        private void Receptionist_Load(object sender, EventArgs e)
        {
            button6.BackColor = System.Drawing.Color.Black;
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Receptionist where Receptionist_id = @a", con);
            cmd.Parameters.AddWithValue("@a", Global.ID);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtID.Text = reader["Receptionist_id"].ToString();
                txtName.Text = reader["Receptionist_name"].ToString();
                txtAge.Text = reader["Receptionist_age"].ToString();
                txtContact.Text = reader["Receptionist_contact"].ToString();
                txtCNIC.Text = reader["Receptionist_CNIC"].ToString();
                txtgender.Text = reader["Receptionist_gender"].ToString();
                txtDOB.Text = Convert.ToDateTime(reader["Receptionist_DOB"]).ToString("dd-MM-yyyy");
                txtQualification.Text = reader["Receptionist_qualification"].ToString();
                txtAddress.Text = reader["Receptionist_address"].ToString();
            }
            con.Close();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Receptionist_4 r = new Receptionist_4();
            r.Show();
            this.Close();
        }
    }
}
