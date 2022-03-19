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
    public partial class AdminNrsView : Form
    {
        public AdminNrsView()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(NrsIDField.Text == "Nurse ID")
            {
                NrsIDField.Text = "";
                NrsIDField.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (NrsIDField.Text == "")
            {
                NrsIDField.Text = "Nurse ID";
                NrsIDField.ForeColor = Color.Silver;
            }
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

        private void btnView_Click(object sender, EventArgs e)
        {
            AdminNrsView viewNrs = new AdminNrsView();
            viewNrs.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdminNrsAdd AddNrs = new AdminNrsAdd();
            AddNrs.Show();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AdminNrsUpdate UpdateNrs = new AdminNrsUpdate();
            UpdateNrs.Show();
            this.Close();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            button3.BackColor = System.Drawing.Color.Black;
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

        private void btnRefresh(object sender, EventArgs e)
        {
            AdminNrsView View = new AdminNrsView();
            View.Show();
            this.Close();
        }

        private void btnViewNrs_Click(object sender, EventArgs e)
        {
            if (NrsIDField.Text == "Nurse ID")
            {
                //e.Cancel = true;
                errorProvider1.SetError(NrsIDField, "Nurse ID is Required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(NrsIDField, "");

                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Nurses where Nurse_id = @userID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@userID", int.Parse(NrsIDField.Text));
                SqlDataReader dr = cmd.ExecuteReader();

                if (!(dr.HasRows))
                {
                    MessageBox.Show("Doctor ID not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Close();
                    SqlCommand cmd1 = new SqlCommand("Select * from Nurses where Nurse_id = '" + int.Parse(NrsIDField.Text) + "'", con);
                    SqlDataAdapter sd = new SqlDataAdapter(cmd1);
                    DataTable dt = new DataTable();
                    con.Open();
                    sd.Fill(dt);
                    con.Close();

                    dataGridView1.DataSource = dt;
                    dataGridView1.AllowUserToAddRows = false;

                    if (MessageBox.Show("Export Report?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (dataGridView1.Rows.Count != 0)
                        {
                            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(Type.Missing);
                            for (int index1 = 1; index1 < dataGridView1.Columns.Count + 1; index1++)
                            {
                                xlApp.Cells[1, index1] = dataGridView1.Columns[index1 - 1].HeaderText;
                            }

                            for (int index1 = 0; index1 < dataGridView1.Rows.Count; index1++)
                            {
                                for (int index2 = 0; index2 < dataGridView1.Columns.Count; index2++)
                                {
                                    xlApp.Cells[index1 + 2, index2 + 1] = dataGridView1.Rows[index1].Cells[index2].Value.ToString();
                                }
                            }

                            xlApp.Columns.AutoFit();
                            xlApp.Visible = true;
                            MessageBox.Show("You have successfully export data to excel file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                con.Close();
            }
        }

        private void btnFullHistory_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Nurses", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;

            if (MessageBox.Show("Export Report?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Add(Type.Missing);
                    for (int index1 = 1; index1 < dataGridView1.Columns.Count + 1; index1++)
                    {
                        xlApp.Cells[1, index1] = dataGridView1.Columns[index1 - 1].HeaderText;
                    }

                    for (int index1 = 0; index1 < dataGridView1.Rows.Count; index1++)
                    {
                        for (int index2 = 0; index2 < dataGridView1.Columns.Count; index2++)
                        {
                            xlApp.Cells[index1 + 2, index2 + 1] = dataGridView1.Rows[index1].Cells[index2].Value.ToString();
                        }
                    }

                    xlApp.Columns.AutoFit();
                    xlApp.Visible = true;
                    MessageBox.Show("You have successfully export data to excel file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Refresh page?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                AdminNrsView view = new AdminNrsView();
                view.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ok", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void NrsIDField_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void NrsIDField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(NrsIDField, "Only Digits Allowed!");
            }
            else
            {
                e.Handled = false;
                errorProvider1.SetError(NrsIDField, "");
            }
        }
    }
}
