namespace Hotel_erp_Winforms_App.UI.Forms
{
    partial class FrmRegistration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistration));
            panel1 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label8 = new Label();
            label9 = new Label();
            tbRegTaxNumber = new TextBox();
            tbRegPassword = new TextBox();
            btnSave = new Button();
            label3 = new Label();
            tbRegConfirmPassword = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(59, 130, 246);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 494);
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.Font = new Font("Modern No. 20", 20F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(57, 363);
            label2.Name = "label2";
            label2.Size = new Size(279, 79);
            label2.TabIndex = 1;
            label2.Text = "Hotel Management Application";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(57, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(279, 281);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(511, 85);
            label1.Name = "label1";
            label1.Size = new Size(175, 37);
            label1.TabIndex = 3;
            label1.Text = "Registration";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(491, 167);
            label8.Name = "label8";
            label8.Size = new Size(93, 21);
            label8.TabIndex = 3;
            label8.Text = "Tax Number";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(491, 240);
            label9.Name = "label9";
            label9.Size = new Size(76, 21);
            label9.TabIndex = 3;
            label9.Text = "Password";
            // 
            // tbRegTaxNumber
            // 
            tbRegTaxNumber.Font = new Font("Segoe UI", 15F);
            tbRegTaxNumber.Location = new Point(491, 191);
            tbRegTaxNumber.Name = "tbRegTaxNumber";
            tbRegTaxNumber.Size = new Size(207, 34);
            tbRegTaxNumber.TabIndex = 4;
            // 
            // tbRegPassword
            // 
            tbRegPassword.Font = new Font("Segoe UI", 15F);
            tbRegPassword.Location = new Point(491, 264);
            tbRegPassword.Name = "tbRegPassword";
            tbRegPassword.Size = new Size(207, 34);
            tbRegPassword.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(59, 130, 246);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 58, 138);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 15F);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(532, 404);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(131, 49);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(491, 316);
            label3.Name = "label3";
            label3.Size = new Size(118, 21);
            label3.TabIndex = 3;
            label3.Text = "Password again";
            // 
            // tbRegConfirmPassword
            // 
            tbRegConfirmPassword.Font = new Font("Segoe UI", 15F);
            tbRegConfirmPassword.Location = new Point(491, 340);
            tbRegConfirmPassword.Name = "tbRegConfirmPassword";
            tbRegConfirmPassword.Size = new Size(207, 34);
            tbRegConfirmPassword.TabIndex = 4;
            // 
            // RegistrationFrom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(784, 494);
            Controls.Add(btnSave);
            Controls.Add(tbRegConfirmPassword);
            Controls.Add(tbRegPassword);
            Controls.Add(label3);
            Controls.Add(tbRegTaxNumber);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RegistrationFrom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registration";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label8;
        private Label label9;
        private TextBox tbRegTaxNumber;
        private TextBox tbRegPassword;
        private Button btnSave;
        private Label label3;
        private TextBox tbRegConfirmPassword;
    }
}