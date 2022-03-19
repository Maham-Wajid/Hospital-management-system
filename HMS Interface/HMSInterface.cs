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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(185, 30, 144, 255);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {
            panel3.BackColor = Color.FromArgb(140, 245,245,245);
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Global.person = "Admin";
            Login l = new Login();
            l.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Global.person = "Doctor";
            Login l = new Login();
            l.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Global.person = "Receptionist";
            Login l = new Login();
            l.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Global.person = "Nurse";
            Login l = new Login();
            l.Show();
            this.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Global.person = "Laboratorist";
            Login l = new Login();
            l.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Global.person = "Pharmacist";
            Login l = new Login();
            l.Show();
            this.Close();
        }
    }
}
