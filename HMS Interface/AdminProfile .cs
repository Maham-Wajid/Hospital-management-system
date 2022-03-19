using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_Interface
{
    public partial class AdminProfile : Form
    {
        public AdminProfile()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");

        private void btnProfile_Click(object sender, EventArgs e)
        {
            AdminProfile adminProfile = new AdminProfile();
            adminProfile.Show();
            this.Close();
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            AdminDocView view = new AdminDocView();
            view.Show();
            this.Close();
        }

        private void btnNrs_Click(object sender, EventArgs e)
        {
            AdminNrsView viewNrs = new AdminNrsView();
            viewNrs.Show();
            this.Close();
        }

        private void btnRcp_Click(object sender, EventArgs e)
        {
            AdminRcptView viewRcp = new AdminRcptView();
            viewRcp.Show();
            this.Close();
        }

        private void btnLab_Click(object sender, EventArgs e)
        {
            AdminLabortryView viewLab = new AdminLabortryView();
            viewLab.Show();
            this.Close();
        }

        private void btnPhrm_Click(object sender, EventArgs e)
        {
            AdminPhrmcyView viewPharm = new AdminPhrmcyView();
            viewPharm.Show();
            this.Close();
        }

        private void AdminProfile_Load(object sender, EventArgs e)
        {
            button6.BackColor = System.Drawing.Color.Black;
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from Admin where Admin_ID = @ID", con);
            cmd1.Parameters.AddWithValue("@ID", Global.ID);

            SqlDataReader sdr = cmd1.ExecuteReader();
            while(sdr.Read())
            {
                txtID.Text = sdr.GetValue(0).ToString();
                txtName.Text = sdr.GetValue(1).ToString();
                txtAge.Text = sdr.GetValue(2).ToString();
                txtContact.Text = sdr.GetValue(3).ToString();
                txtCNIC.Text = sdr.GetValue(4).ToString();
                txtGender.Text = sdr.GetValue(5).ToString();
                txtDOB.Text = Convert.ToDateTime(sdr.GetValue(6)).ToString("yyyy-MM-dd");
                txtEdu.Text = sdr.GetValue(7).ToString();
                txtAddress.Text = sdr.GetValue(8).ToString();
            }
            txtID.ForeColor = Color.Black;
            txtName.ForeColor = Color.Black;
            txtAge.ForeColor = Color.Black;
            txtContact.ForeColor = Color.Black;
            txtCNIC.ForeColor = Color.Black;
            txtGender.ForeColor = Color.Black;
            txtDOB.ForeColor = Color.Black;
            txtEdu.ForeColor = Color.Black;
            txtAddress.ForeColor = Color.Black;
            con.Close();
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            Form1 Interface = new Form1();
            Interface.Show();
            this.Close();
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnPtn_Click(object sender, EventArgs e)
        {
            AdminPatientView ViewPtn = new AdminPatientView();
            ViewPtn.Show();
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            AdminResetPasswordInterface ResetPassword = new AdminResetPasswordInterface();
            ResetPassword.Show();
            this.Close();
        }

        private void Managebtn_Click(object sender, EventArgs e)
        {
            AdminView view = new AdminView();
            view.Show();
            this.Close();

        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            AdminResetPassword adminResetPassword = new AdminResetPassword();
            adminResetPassword.Show();
            this.Close();
        }
    }
}
