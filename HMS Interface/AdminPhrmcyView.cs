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
    public partial class AdminPhrmcyView : Form
    {
        public AdminPhrmcyView()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-F0M3HSSL;Initial Catalog=HMS;Integrated Security=True");

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(PhrmIDField.Text== "Pharmacist ID")
            {
                PhrmIDField.Text = "";
                PhrmIDField.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (PhrmIDField.Text == "")
            {
                PhrmIDField.Text = "Pharmacist ID";
                PhrmIDField.ForeColor = Color.Silver;
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            AdminResetPasswordInterface ResetPassword = new AdminResetPasswordInterface();
            ResetPassword.Show();
            this.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            AdminPhrmcyView viewPhrm = new AdminPhrmcyView();
            viewPhrm.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdminPhrmcyAdd AddPhrm = new AdminPhrmcyAdd();
            AddPhrm.Show();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            AdminPhrmcyUpdate UpdatePhrm = new AdminPhrmcyUpdate();
            UpdatePhrm.Show();
            this.Close();
        }

        private void Form22_Load(object sender, EventArgs e)
        {
            button7.BackColor = System.Drawing.Color.Black;
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            Form1 Interface = new Form1();
            Interface.Show();
            this.Close();
        }

        private void btnPtn_Click(object sender, EventArgs e)
        {
            AdminPatientView ViewPtn = new AdminPatientView();
            ViewPtn.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnPhrmView_Click(object sender, EventArgs e)
        {
            if (PhrmIDField.Text == "Pharmacist ID")
            {
                //e.Cancel = true;
                errorProvider1.SetError(PhrmIDField, "Pharmacist ID is Required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(PhrmIDField, "");

                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Pharmacist where Pharmacist_id = @userID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@userID", int.Parse(PhrmIDField.Text));
                SqlDataReader dr = cmd.ExecuteReader();

                if (!(dr.HasRows))
                {
                    MessageBox.Show("Pharmacist ID not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Close();
                    SqlCommand cmd1 = new SqlCommand("Select * from Pharmacist where Pharmacist_id = '" + int.Parse(PhrmIDField.Text) + "'", con);
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
            SqlCommand cmd = new SqlCommand("Select * from Pharmacist", con);
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

        private void button14_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Refresh page?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                AdminPhrmcyView view = new AdminPhrmcyView();
                view.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ok", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AdminPhrmcyView view = new AdminPhrmcyView();
            view.Show();
            this.Close();
        }

        private void PhrmIDField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(PhrmIDField, "Only Digits Allowed!");
            }
            else
            {
                e.Handled = false;
                errorProvider1.SetError(PhrmIDField, "");
            }
        }
    }
}
