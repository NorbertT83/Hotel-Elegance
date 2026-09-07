using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_erp_Winforms_App.UI.Forms.ServiceForms.ChangeEmail
{
    partial class FrmChangeEmail
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
            grpEmailDetails = new GroupBox();
            lblNewEmail = new Label();
            tbNewEmail = new TextBox();
            lblConfirmEmail = new Label();
            tbConfirmEmail = new TextBox();
            pnlActions = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            grpEmailDetails.SuspendLayout();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // 
            // grpEmailDetails
            // 
            grpEmailDetails.Controls.Add(lblNewEmail);
            grpEmailDetails.Controls.Add(tbNewEmail);
            grpEmailDetails.Controls.Add(lblConfirmEmail);
            grpEmailDetails.Controls.Add(tbConfirmEmail);
            grpEmailDetails.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpEmailDetails.ForeColor = Color.DarkBlue;
            grpEmailDetails.Location = new Point(12, 12);
            grpEmailDetails.Name = "grpEmailDetails";
            grpEmailDetails.Size = new Size(360, 150);
            grpEmailDetails.TabIndex = 0;
            grpEmailDetails.TabStop = false;
            grpEmailDetails.Text = "UPDATE EMAIL ADDRESS";
            // 
            // lblNewEmail
            // 
            lblNewEmail.AutoSize = true;
            lblNewEmail.Font = new Font("Segoe UI", 8.25F);
            lblNewEmail.ForeColor = Color.Black;
            lblNewEmail.Location = new Point(15, 31);
            lblNewEmail.Name = "lblNewEmail";
            lblNewEmail.Size = new Size(107, 13);
            lblNewEmail.TabIndex = 0;
            lblNewEmail.Text = "New Email Address:";
            // 
            // tbNewEmail
            // 
            tbNewEmail.Font = new Font("Segoe UI", 9F);
            tbNewEmail.Location = new Point(15, 47);
            tbNewEmail.MaxLength = 200;
            tbNewEmail.Name = "tbNewEmail";
            tbNewEmail.Size = new Size(331, 23);
            tbNewEmail.TabIndex = 1;
            // 
            // lblConfirmEmail
            // 
            lblConfirmEmail.AutoSize = true;
            lblConfirmEmail.Font = new Font("Segoe UI", 8.25F);
            lblConfirmEmail.ForeColor = Color.Black;
            lblConfirmEmail.Location = new Point(15, 82);
            lblConfirmEmail.Name = "lblConfirmEmail";
            lblConfirmEmail.Size = new Size(125, 13);
            lblConfirmEmail.TabIndex = 2;
            lblConfirmEmail.Text = "Confirm Email Address:";
            // 
            // tbConfirmEmail
            // 
            tbConfirmEmail.Font = new Font("Segoe UI", 9F);
            tbConfirmEmail.Location = new Point(15, 98);
            tbConfirmEmail.MaxLength = 200;
            tbConfirmEmail.Name = "tbConfirmEmail";
            tbConfirmEmail.Size = new Size(331, 23);
            tbConfirmEmail.TabIndex = 3;
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.FromArgb(240, 243, 246);
            pnlActions.Controls.Add(btnCancel);
            pnlActions.Controls.Add(btnSave);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 175);
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
            btnSave.Text = "Save Email";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // FrmChangeEmail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(384, 220);
            Controls.Add(grpEmailDetails);
            Controls.Add(pnlActions);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmChangeEmail";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Edit Email Address";
            Load += FrmChangeEmail_Load;
            grpEmailDetails.ResumeLayout(false);
            grpEmailDetails.PerformLayout();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpEmailDetails;
        private Label lblNewEmail;
        private TextBox tbNewEmail;
        private Label lblConfirmEmail;
        private TextBox tbConfirmEmail;
        private Panel pnlActions;
        private Button btnSave;
        private Button btnCancel;
    }
}