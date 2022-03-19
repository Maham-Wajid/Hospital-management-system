namespace HMS_Interface
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSignin = new System.Windows.Forms.Button();
            this.lblForgotPassword = new System.Windows.Forms.LinkLabel();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.btnCloseApp = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.btnSignin);
            this.panel1.Controls.Add(this.lblForgotPassword);
            this.panel1.Controls.Add(this.txtUserPassword);
            this.panel1.Controls.Add(this.txtUserID);
            this.panel1.Controls.Add(this.lblLogin);
            this.panel1.Controls.Add(this.imgLogo);
            this.panel1.Location = new System.Drawing.Point(445, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 473);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::HMS_Interface.Properties.Resources.kissclipart_password_icon_png_clipart_computer_icons_password_effae01cc669abc3;
            this.pictureBox3.Location = new System.Drawing.Point(52, 269);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HMS_Interface.Properties.Resources.final_icon;
            this.pictureBox2.Location = new System.Drawing.Point(52, 208);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // btnSignin
            // 
            this.btnSignin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignin.Font = new System.Drawing.Font("Modern No. 20", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignin.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnSignin.Location = new System.Drawing.Point(120, 360);
            this.btnSignin.Name = "btnSignin";
            this.btnSignin.Size = new System.Drawing.Size(126, 36);
            this.btnSignin.TabIndex = 5;
            this.btnSignin.Text = "Sign in";
            this.btnSignin.UseVisualStyleBackColor = true;
            this.btnSignin.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblForgotPassword
            // 
            this.lblForgotPassword.AutoSize = true;
            this.lblForgotPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblForgotPassword.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgotPassword.Location = new System.Drawing.Point(201, 308);
            this.lblForgotPassword.Name = "lblForgotPassword";
            this.lblForgotPassword.Size = new System.Drawing.Size(121, 18);
            this.lblForgotPassword.TabIndex = 4;
            this.lblForgotPassword.TabStop = true;
            this.lblForgotPassword.Text = "Forgot Password?";
            this.lblForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Font = new System.Drawing.Font("Modern No. 20", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserPassword.ForeColor = System.Drawing.Color.Silver;
            this.txtUserPassword.Location = new System.Drawing.Point(47, 266);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '*';
            this.txtUserPassword.Size = new System.Drawing.Size(275, 36);
            this.txtUserPassword.TabIndex = 3;
            this.txtUserPassword.Text = "*****";
            this.txtUserPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUserPassword.Enter += new System.EventHandler(this.textBox2_Enter);
            this.txtUserPassword.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("Modern No. 20", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.ForeColor = System.Drawing.Color.Silver;
            this.txtUserID.Location = new System.Drawing.Point(47, 205);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(275, 36);
            this.txtUserID.TabIndex = 2;
            this.txtUserID.Text = "UserId";
            this.txtUserID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUserID.Enter += new System.EventHandler(this.textBox1_Enter);
            this.txtUserID.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Font = new System.Drawing.Font("Modern No. 20", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblLogin.Location = new System.Drawing.Point(132, 150);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(105, 36);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Login";
            // 
            // imgLogo
            // 
            this.imgLogo.BackColor = System.Drawing.Color.Transparent;
            this.imgLogo.Image = global::HMS_Interface.Properties.Resources.logo;
            this.imgLogo.Location = new System.Drawing.Point(120, 42);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(126, 92);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLogo.TabIndex = 0;
            this.imgLogo.TabStop = false;
            // 
            // btnCloseApp
            // 
            this.btnCloseApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseApp.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseApp.BackgroundImage = global::HMS_Interface.Properties.Resources.Close_button_final;
            this.btnCloseApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCloseApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseApp.FlatAppearance.BorderSize = 0;
            this.btnCloseApp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCloseApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCloseApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseApp.Location = new System.Drawing.Point(1250, 0);
            this.btnCloseApp.Name = "btnCloseApp";
            this.btnCloseApp.Size = new System.Drawing.Size(34, 32);
            this.btnCloseApp.TabIndex = 3;
            this.btnCloseApp.UseVisualStyleBackColor = false;
            this.btnCloseApp.Click += new System.EventHandler(this.button7_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::HMS_Interface.Properties.Resources.backbtn1_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(32, 579);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::HMS_Interface.Properties.Resources.Background_pic;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCloseApp);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.Button btnSignin;
        private System.Windows.Forms.LinkLabel lblForgotPassword;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnCloseApp;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

