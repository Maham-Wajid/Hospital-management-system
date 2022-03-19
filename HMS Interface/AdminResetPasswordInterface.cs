using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_Interface
{
    public partial class AdminResetPasswordInterface : Form
    {
        public AdminResetPasswordInterface()
        {
            InitializeComponent();
        }

        private void Form32_Load(object sender, EventArgs e)
        {
            button8.BackColor = System.Drawing.Color.Black;
        }

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

        private void btnSignout_Click(object sender, EventArgs e)
        {
            Form1 Interface = new Form1();
            Interface.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDoctRst_Click(object sender, EventArgs e)
        {
            AdminDocRstPassword DocReset = new AdminDocRstPassword();
            DocReset.Show();
            this.Close();
        }

        private void btnNrsRst_Click(object sender, EventArgs e)
        {
            AdminNrsResetPassword NrsReset = new AdminNrsResetPassword();
            NrsReset.Show();
            this.Close();
        }

        private void btnRcpRst_Click(object sender, EventArgs e)
        {
            AdminRcptResetPassword RcpReset = new AdminRcptResetPassword();
            RcpReset.Show();
            this.Close();
        }

        private void btnLbRst_Click(object sender, EventArgs e)
        {
            AdminLabResetPassword LbReset = new AdminLabResetPassword();
            LbReset.Show();
            this.Close();
        }

        private void btnPhrmRst_Click(object sender, EventArgs e)
        {
            AdminPharmResetPassword PhrmReset = new AdminPharmResetPassword();
            PhrmReset.Show();
            this.Close();
        }
    }
}
