using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace Hotel_erp_Winforms_App.UI.Forms.ServiceForms.Change_Password
{
    partial class FrmChangePassword
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
            grpPasswordDetails = new GroupBox();
            lblOldPassword = new Label();
            tbOldPassword = new TextBox();
            lblNewPassword = new Label();
            tbNewPassword = new TextBox();
            lblConfirmNewPassword = new Label();
            tbConfirmNewPassword = new TextBox();
            chkShowPassword = new CheckBox();
            btnGeneratePassword = new Button();
            pnlActions = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            grpPasswordDetails.SuspendLayout();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // 
            // grpPasswordDetails
            // 
            grpPasswordDetails.Controls.Add(lblOldPassword);
            grpPasswordDetails.Controls.Add(tbOldPassword);
            grpPasswordDetails.Controls.Add(lblNewPassword);
            grpPasswordDetails.Controls.Add(tbNewPassword);
            grpPasswordDetails.Controls.Add(lblConfirmNewPassword);
            grpPasswordDetails.Controls.Add(tbConfirmNewPassword);
            grpPasswordDetails.Controls.Add(chkShowPassword);
            grpPasswordDetails.Controls.Add(btnGeneratePassword);
            grpPasswordDetails.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpPasswordDetails.ForeColor = Color.DarkBlue;
            grpPasswordDetails.Location = new Point(12, 12);
            grpPasswordDetails.Name = "grpPasswordDetails";
            grpPasswordDetails.Size = new Size(360, 220);
            grpPasswordDetails.TabIndex = 0;
            grpPasswordDetails.TabStop = false;
            grpPasswordDetails.Text = "CHANGE PASSWORD";
            // 
            // lblOldPassword
            // 
            lblOldPassword.AutoSize = true;
            lblOldPassword.Font = new Font("Segoe UI", 8.25F);
            lblOldPassword.ForeColor = Color.Black;
            lblOldPassword.Location = new Point(15, 31);
            lblOldPassword.Name = "lblOldPassword";
            lblOldPassword.Size = new Size(81, 13);
            lblOldPassword.TabIndex = 0;
            lblOldPassword.Text = "Old Password:";
            // 
            // tbOldPassword
            // 
            tbOldPassword.Font = new Font("Segoe UI", 9F);
            tbOldPassword.Location = new Point(15, 47);
            tbOldPassword.MaxLength = 255;
            tbOldPassword.Name = "tbOldPassword";
            tbOldPassword.Size = new Size(210, 23);
            tbOldPassword.TabIndex = 1;
            tbOldPassword.UseSystemPasswordChar = true;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new Font("Segoe UI", 8.25F);
            lblNewPassword.ForeColor = Color.Black;
            lblNewPassword.Location = new Point(15, 82);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(85, 13);
            lblNewPassword.TabIndex = 2;
            lblNewPassword.Text = "New Password:";
            // 
            // tbNewPassword
            // 
            tbNewPassword.Font = new Font("Segoe UI", 9F);
            tbNewPassword.Location = new Point(15, 98);
            tbNewPassword.MaxLength = 255;
            tbNewPassword.Name = "tbNewPassword";
            tbNewPassword.Size = new Size(210, 23);
            tbNewPassword.TabIndex = 2;
            tbNewPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmNewPassword
            // 
            lblConfirmNewPassword.AutoSize = true;
            lblConfirmNewPassword.Font = new Font("Segoe UI", 8.25F);
            lblConfirmNewPassword.ForeColor = Color.Black;
            lblConfirmNewPassword.Location = new Point(15, 133);
            lblConfirmNewPassword.Name = "lblConfirmNewPassword";
            lblConfirmNewPassword.Size = new Size(129, 13);
            lblConfirmNewPassword.TabIndex = 4;
            lblConfirmNewPassword.Text = "Confirm New Password:";
            // 
            // tbConfirmNewPassword
            // 
            tbConfirmNewPassword.Font = new Font("Segoe UI", 9F);
            tbConfirmNewPassword.Location = new Point(15, 149);
            tbConfirmNewPassword.MaxLength = 255;
            tbConfirmNewPassword.Name = "tbConfirmNewPassword";
            tbConfirmNewPassword.Size = new Size(210, 23);
            tbConfirmNewPassword.TabIndex = 3;
            tbConfirmNewPassword.UseSystemPasswordChar = true;
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
            btnGeneratePassword.TabIndex = 4;
            btnGeneratePassword.Text = "Generate";
            btnGeneratePassword.UseVisualStyleBackColor = true;
            btnGeneratePassword.Click += btnGeneratePassword_Click;
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
            btnCancel.TabIndex = 6;
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
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // FrmChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(384, 290);
            Controls.Add(grpPasswordDetails);
            Controls.Add(pnlActions);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmChangePassword";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Change Password";
            grpPasswordDetails.ResumeLayout(false);
            grpPasswordDetails.PerformLayout();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpPasswordDetails;
        private Label lblOldPassword;
        private TextBox tbOldPassword;
        private Label lblNewPassword;
        private TextBox tbNewPassword;
        private Label lblConfirmNewPassword;
        private TextBox tbConfirmNewPassword;
        private CheckBox chkShowPassword;
        private Button btnGeneratePassword;
        private Panel pnlActions;
        private Button btnSave;
        private Button btnCancel;
    }
}