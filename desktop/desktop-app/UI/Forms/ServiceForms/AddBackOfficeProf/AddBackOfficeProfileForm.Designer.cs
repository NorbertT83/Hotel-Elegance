using Org.BouncyCastle.Asn1.Crmf;
using System.Xml.Linq;
using Font = System.Drawing.Font;
using static System.Net.Mime.MediaTypeNames;

namespace Hotel_erp_Winforms_App.UI.Forms.ServiceForms.AddBackOfficeProf
{
    partial class AddBackOfficeProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            grpProfileDetails = new GroupBox();
            tbEmail = new TextBox();
            lblPassword = new Label();
            tbPassword = new TextBox();
            lblConfirmPassword = new Label();
            tbConfirmPassword = new TextBox();
            chkShowPassword = new CheckBox();
            btnGeneratePassword = new Button();
            lblEmail = new Label();
            pnlActions = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            llbChangeEmail = new LinkLabel();
            grpProfileDetails.SuspendLayout();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // 
            // grpProfileDetails
            // 
            grpProfileDetails.Controls.Add(llbChangeEmail);
            grpProfileDetails.Controls.Add(tbEmail);
            grpProfileDetails.Controls.Add(lblPassword);
            grpProfileDetails.Controls.Add(tbPassword);
            grpProfileDetails.Controls.Add(lblConfirmPassword);
            grpProfileDetails.Controls.Add(tbConfirmPassword);
            grpProfileDetails.Controls.Add(chkShowPassword);
            grpProfileDetails.Controls.Add(btnGeneratePassword);
            grpProfileDetails.Controls.Add(lblEmail);
            grpProfileDetails.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpProfileDetails.ForeColor = Color.DarkBlue;
            grpProfileDetails.Location = new Point(12, 12);
            grpProfileDetails.Name = "grpProfileDetails";
            grpProfileDetails.Size = new Size(360, 220);
            grpProfileDetails.TabIndex = 0;
            grpProfileDetails.TabStop = false;
            grpProfileDetails.Text = "ACCOUNT CREDENTIALS";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(15, 47);
            tbEmail.MaxLength = 200;
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(331, 23);
            tbEmail.TabIndex = 8;
            tbEmail.TabStop = false;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 8.25F);
            lblPassword.ForeColor = Color.Black;
            lblPassword.Location = new Point(15, 82);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(59, 13);
            lblPassword.TabIndex = 0;
            lblPassword.Text = "Password:";
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 9F);
            tbPassword.Location = new Point(15, 98);
            tbPassword.MaxLength = 255;
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new Size(210, 23);
            tbPassword.TabIndex = 1;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 8.25F);
            lblConfirmPassword.ForeColor = Color.Black;
            lblConfirmPassword.Location = new Point(15, 133);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(103, 13);
            lblConfirmPassword.TabIndex = 3;
            lblConfirmPassword.Text = "Confirm Password:";
            // 
            // tbConfirmPassword
            // 
            tbConfirmPassword.Font = new Font("Segoe UI", 9F);
            tbConfirmPassword.Location = new Point(15, 149);
            tbConfirmPassword.MaxLength = 255;
            tbConfirmPassword.Name = "tbConfirmPassword";
            tbConfirmPassword.PasswordChar = '*';
            tbConfirmPassword.Size = new Size(210, 23);
            tbConfirmPassword.TabIndex = 4;
            // 
            // chkShowPassword
            // 
            chkShowPassword.AutoSize = true;
            chkShowPassword.Font = new Font("Segoe UI", 8.25F);
            chkShowPassword.ForeColor = Color.Black;
            chkShowPassword.Location = new Point(231, 153);
            chkShowPassword.Name = "chkShowPassword";
            chkShowPassword.Size = new Size(55, 17);
            chkShowPassword.TabIndex = 5;
            chkShowPassword.Text = "Show";
            chkShowPassword.UseVisualStyleBackColor = true;
            chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
            // 
            // btnGeneratePassword
            // 
            btnGeneratePassword.Font = new Font("Segoe UI", 8.25F);
            btnGeneratePassword.Location = new Point(231, 98);
            btnGeneratePassword.Name = "btnGeneratePassword";
            btnGeneratePassword.Size = new Size(115, 25);
            btnGeneratePassword.TabIndex = 2;
            btnGeneratePassword.Text = "Generate";
            btnGeneratePassword.UseVisualStyleBackColor = true;
            btnGeneratePassword.Click += btnGeneratePassword_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 8.25F);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(15, 31);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(134, 13);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Account's Email Address:";
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.FromArgb(240, 243, 246);
            pnlActions.Controls.Add(btnCancel);
            pnlActions.Controls.Add(btnSave);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 245);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(384, 45);
            pnlActions.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.FlatAppearance.BorderColor = Color.LightGray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(186, 8);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 28);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 102, 204);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(272, 8);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 28);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save Profile";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // llbChangeEmail
            // 
            llbChangeEmail.AutoSize = true;
            llbChangeEmail.Location = new Point(15, 192);
            llbChangeEmail.Name = "llbChangeEmail";
            llbChangeEmail.Size = new Size(132, 15);
            llbChangeEmail.TabIndex = 9;
            llbChangeEmail.TabStop = true;
            llbChangeEmail.Text = "Change E-mail Address";
            llbChangeEmail.LinkClicked += llbChangeEmail_LinkClicked;
            // 
            // AddBackOfficeProfileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(384, 290);
            Controls.Add(grpProfileDetails);
            Controls.Add(pnlActions);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddBackOfficeProfileForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "BackOffice Profile Configuration";
            Load += AddBackOfficeProfileForm_Load;
            grpProfileDetails.ResumeLayout(false);
            grpProfileDetails.PerformLayout();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpProfileDetails;
        private Label lblPassword;
        private TextBox tbPassword;
        private Label lblConfirmPassword;
        private TextBox tbConfirmPassword;
        private CheckBox chkShowPassword;
        private Button btnGeneratePassword;
        private Label lblEmail;
        private Panel pnlActions;
        private Button btnSave;
        private Button btnCancel;
        private TextBox tbEmail;
        private LinkLabel llbChangeEmail;
    }
}