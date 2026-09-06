namespace Hotel_erp_Winforms_App.Forms
{
    partial class FrmLogin
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
            panel1 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            tbTaxNumber = new TextBox();
            tbPassword = new TextBox();
            btnLogin = new Button();
            label3 = new Label();
            label4 = new Label();
            linkLabel = new LinkLabel();
            label5 = new Label();
            cbJobTitle = new ComboBox();
            lbJobTitle = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 494);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.Font = new Font("Modern No. 20", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(57, 363);
            label2.Name = "label2";
            label2.Size = new Size(279, 79);
            label2.TabIndex = 100;
            label2.Text = "Hotel Elegance BackOffice";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.hotel_logo;
            pictureBox1.Location = new Point(57, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(279, 281);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(548, 82);
            label1.Name = "label1";
            label1.Size = new Size(100, 57);
            label1.TabIndex = 101;
            label1.Text = "Login";
            // 
            // tbTaxNumber
            // 
            tbTaxNumber.Font = new Font("Segoe UI", 15F);
            tbTaxNumber.Location = new Point(487, 183);
            tbTaxNumber.Name = "tbTaxNumber";
            tbTaxNumber.Size = new Size(210, 34);
            tbTaxNumber.TabIndex = 1;
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 15F);
            tbPassword.Location = new Point(487, 269);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(210, 34);
            tbPassword.TabIndex = 2;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Black;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 58, 138);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 15F);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(526, 346);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(131, 49);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(487, 159);
            label3.Name = "label3";
            label3.Size = new Size(93, 21);
            label3.TabIndex = 5;
            label3.Text = "Tax Number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(487, 245);
            label4.Name = "label4";
            label4.Size = new Size(76, 21);
            label4.TabIndex = 6;
            label4.Text = "Password";
            // 
            // linkLabel
            // 
            linkLabel.AutoSize = true;
            linkLabel.Font = new Font("Segoe UI", 10F);
            linkLabel.Location = new Point(619, 423);
            linkLabel.Name = "linkLabel";
            linkLabel.Size = new Size(101, 19);
            linkLabel.TabIndex = 4;
            linkLabel.TabStop = true;
            linkLabel.Text = "Make one here";
            linkLabel.LinkClicked += linkLabel_LinkClicked;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(447, 423);
            label5.Name = "label5";
            label5.Size = new Size(176, 19);
            label5.TabIndex = 102;
            label5.Text = "Don't have an account yet?";
            // 
            // cbJobTitle
            // 
            cbJobTitle.FormattingEnabled = true;
            cbJobTitle.Items.AddRange(new object[] { "Admin", "Manager", "Guest" });
            cbJobTitle.Location = new Point(530, 56);
            cbJobTitle.Name = "cbJobTitle";
            cbJobTitle.Size = new Size(118, 23);
            cbJobTitle.TabIndex = 103;
            // 
            // lbJobTitle
            // 
            lbJobTitle.AutoSize = true;
            lbJobTitle.Location = new Point(548, 35);
            lbJobTitle.Name = "lbJobTitle";
            lbJobTitle.Size = new Size(91, 15);
            lbJobTitle.TabIndex = 104;
            lbJobTitle.Text = "Default job title:";
            // 
            // FrmLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(784, 494);
            Controls.Add(lbJobTitle);
            Controls.Add(cbJobTitle);
            Controls.Add(label5);
            Controls.Add(linkLabel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnLogin);
            Controls.Add(tbPassword);
            Controls.Add(tbTaxNumber);
            Controls.Add(label1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += FrmLogin_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Panel panel1;
        private TextBox tbTaxNumber;
        private PictureBox pictureBox1;
        private TextBox tbPassword;
        private Button btnLogin;
        private Label label2;
        private Label label3;
        private Label label4;
        private LinkLabel linkLabel;
        private Label label5;
        private ComboBox cbJobTitle;
        private Label lbJobTitle;
    }
}