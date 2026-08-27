using System.Drawing;
using System.Windows.Forms;

namespace Hotel_erp_Winforms_App.UI.Controls.Settings
{
    partial class SettingsControl
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lbSettingsTitle = new Label();
            pnlSidebar = new Panel();
            btnNavGeneral = new Button();
            btnNavInvoicing = new Button();
            btnNavDatabase = new Button();
            btnNavNotifications = new Button();
            pnlContent = new Panel();
            pnlGeneralGroup = new Panel();
            lbGeneralGroupTitle = new Label();
            lbHotelName = new Label();
            txtHotelName = new TextBox();
            lbHotelAddress = new Label();
            txtHotelAddress = new TextBox();
            lbHotelTaxNum = new Label();
            txtHotelTaxNum = new TextBox();
            lbHotelEmail = new Label();
            txtHotelEmail = new TextBox();
            pnlSystemGroup = new Panel();
            lbSystemGroupTitle = new Label();
            lbCurrency = new Label();
            cbCurrency = new ComboBox();
            chkEnableAutoBackup = new CheckBox();
            chkEnableDebugMode = new CheckBox();
            btnSaveSettings = new Button();
            pnlHeader.SuspendLayout();
            pnlSidebar.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlGeneralGroup.SuspendLayout();
            pnlSystemGroup.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.BorderStyle = BorderStyle.FixedSingle;
            pnlHeader.Controls.Add(lbSettingsTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(10, 10);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1720, 50);
            pnlHeader.TabIndex = 0;
            // 
            // lbSettingsTitle
            // 
            lbSettingsTitle.AutoSize = true;
            lbSettingsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbSettingsTitle.ForeColor = Color.FromArgb(24, 60, 142);
            lbSettingsTitle.Location = new Point(15, 14);
            lbSettingsTitle.Name = "lbSettingsTitle";
            lbSettingsTitle.Size = new Size(170, 21);
            lbSettingsTitle.TabIndex = 0;
            lbSettingsTitle.Text = "SYSTEM SETTINGS";
            // 
            // pnlSidebar
            // 
            pnlSidebar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlSidebar.BackColor = Color.White;
            pnlSidebar.BorderStyle = BorderStyle.FixedSingle;
            pnlSidebar.Controls.Add(btnNavNotifications);
            pnlSidebar.Controls.Add(btnNavDatabase);
            pnlSidebar.Controls.Add(btnNavInvoicing);
            pnlSidebar.Controls.Add(btnNavGeneral);
            pnlSidebar.Location = new Point(10, 70);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(250, 555);
            pnlSidebar.TabIndex = 1;
            // 
            // btnNavGeneral
            // 
            btnNavGeneral.BackColor = Color.FromArgb(24, 60, 142);
            btnNavGeneral.FlatStyle = FlatStyle.Flat;
            btnNavGeneral.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnNavGeneral.ForeColor = Color.White;
            btnNavGeneral.Location = new Point(10, 15);
            btnNavGeneral.Name = "btnNavGeneral";
            btnNavGeneral.Size = new Size(228, 40);
            btnNavGeneral.TabIndex = 0;
            btnNavGeneral.Text = "General Info";
            btnNavGeneral.TextAlign = ContentAlignment.MiddleLeft;
            btnNavGeneral.UseVisualStyleBackColor = false;
            // 
            // btnNavInvoicing
            // 
            btnNavInvoicing.FlatStyle = FlatStyle.Flat;
            btnNavInvoicing.Font = new Font("Segoe UI", 9.5F);
            btnNavInvoicing.Location = new Point(10, 65);
            btnNavInvoicing.Name = "btnNavInvoicing";
            btnNavInvoicing.Size = new Size(228, 40);
            btnNavInvoicing.TabIndex = 1;
            btnNavInvoicing.Text = "Invoicing Settings";
            btnNavInvoicing.TextAlign = ContentAlignment.MiddleLeft;
            btnNavInvoicing.UseVisualStyleBackColor = true;
            // 
            // btnNavDatabase
            // 
            btnNavDatabase.FlatStyle = FlatStyle.Flat;
            btnNavDatabase.Font = new Font("Segoe UI", 9.5F);
            btnNavDatabase.Location = new Point(10, 115);
            btnNavDatabase.Name = "btnNavDatabase";
            btnNavDatabase.Size = new Size(228, 40);
            btnNavDatabase.TabIndex = 2;
            btnNavDatabase.Text = "Database & Backup";
            btnNavDatabase.TextAlign = ContentAlignment.MiddleLeft;
            btnNavDatabase.UseVisualStyleBackColor = true;
            // 
            // btnNavNotifications
            // 
            btnNavNotifications.FlatStyle = FlatStyle.Flat;
            btnNavNotifications.Font = new Font("Segoe UI", 9.5F);
            btnNavNotifications.Location = new Point(10, 165);
            btnNavNotifications.Name = "btnNavNotifications";
            btnNavNotifications.Size = new Size(228, 40);
            btnNavNotifications.TabIndex = 3;
            btnNavNotifications.Text = "Notifications";
            btnNavNotifications.TextAlign = ContentAlignment.MiddleLeft;
            btnNavNotifications.UseVisualStyleBackColor = true;
            // 
            // pnlContent
            // 
            pnlContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlContent.BackColor = Color.FromArgb(248, 249, 250);
            pnlContent.Controls.Add(btnSaveSettings);
            pnlContent.Controls.Add(pnlSystemGroup);
            pnlContent.Controls.Add(pnlGeneralGroup);
            pnlContent.Location = new Point(270, 70);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1460, 555);
            pnlContent.TabIndex = 2;
            // 
            // pnlGeneralGroup
            // 
            pnlGeneralGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlGeneralGroup.BackColor = Color.White;
            pnlGeneralGroup.BorderStyle = BorderStyle.FixedSingle;
            pnlGeneralGroup.Controls.Add(txtHotelEmail);
            pnlGeneralGroup.Controls.Add(lbHotelEmail);
            pnlGeneralGroup.Controls.Add(txtHotelTaxNum);
            pnlGeneralGroup.Controls.Add(lbHotelTaxNum);
            pnlGeneralGroup.Controls.Add(txtHotelAddress);
            pnlGeneralGroup.Controls.Add(lbHotelAddress);
            pnlGeneralGroup.Controls.Add(txtHotelName);
            pnlGeneralGroup.Controls.Add(lbHotelName);
            pnlGeneralGroup.Controls.Add(lbGeneralGroupTitle);
            pnlGeneralGroup.Location = new Point(10, 10);
            pnlGeneralGroup.Name = "pnlGeneralGroup";
            pnlGeneralGroup.Size = new Size(1435, 200);
            pnlGeneralGroup.TabIndex = 0;
            // 
            // lbGeneralGroupTitle
            // 
            lbGeneralGroupTitle.AutoSize = true;
            lbGeneralGroupTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbGeneralGroupTitle.ForeColor = Color.DimGray;
            lbGeneralGroupTitle.Location = new Point(15, 12);
            lbGeneralGroupTitle.Name = "lbGeneralGroupTitle";
            lbGeneralGroupTitle.Size = new Size(125, 19);
            lbGeneralGroupTitle.TabIndex = 0;
            lbGeneralGroupTitle.Text = "HOTEL DETAILS";
            // 
            // lbHotelName
            // 
            lbHotelName.AutoSize = true;
            lbHotelName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbHotelName.Location = new Point(15, 45);
            lbHotelName.Name = "lbHotelName";
            lbHotelName.Size = new Size(79, 15);
            lbHotelName.TabIndex = 1;
            lbHotelName.Text = "Hotel Name:";
            // 
            // txtHotelName
            // 
            txtHotelName.Location = new Point(15, 65);
            txtHotelName.Name = "txtHotelName";
            txtHotelName.Size = new Size(400, 25);
            txtHotelName.TabIndex = 2;
            txtHotelName.Text = "Grand Hotel ERP";
            // 
            // lbHotelAddress
            // 
            lbHotelAddress.AutoSize = true;
            lbHotelAddress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbHotelAddress.Location = new Point(440, 45);
            lbHotelAddress.Name = "lbHotelAddress";
            lbHotelAddress.Size = new Size(56, 15);
            lbHotelAddress.TabIndex = 3;
            lbHotelAddress.Text = "Address:";
            // 
            // txtHotelAddress
            // 
            txtHotelAddress.Location = new Point(440, 65);
            txtHotelAddress.Name = "txtHotelAddress";
            txtHotelAddress.Size = new Size(500, 25);
            txtHotelAddress.TabIndex = 4;
            txtHotelAddress.Text = "1051 Budapest, Fő tér 1.";
            // 
            // lbHotelTaxNum
            // 
            lbHotelTaxNum.AutoSize = true;
            lbHotelTaxNum.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbHotelTaxNum.Location = new Point(15, 110);
            lbHotelTaxNum.Name = "lbHotelTaxNum";
            lbHotelTaxNum.Size = new Size(73, 15);
            lbHotelTaxNum.TabIndex = 5;
            lbHotelTaxNum.Text = "Tax Number:";
            // 
            // txtHotelTaxNum
            // 
            txtHotelTaxNum.Location = new Point(15, 130);
            txtHotelTaxNum.Name = "txtHotelTaxNum";
            txtHotelTaxNum.Size = new Size(400, 25);
            txtHotelTaxNum.TabIndex = 6;
            txtHotelTaxNum.Text = "12345678-2-41";
            // 
            // lbHotelEmail
            // 
            lbHotelEmail.AutoSize = true;
            lbHotelEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbHotelEmail.Location = new Point(440, 110);
            lbHotelEmail.Name = "lbHotelEmail";
            lbHotelEmail.Size = new Size(93, 15);
            lbHotelEmail.TabIndex = 7;
            lbHotelEmail.Text = "Contact E-mail:";
            // 
            // txtHotelEmail
            // 
            txtHotelEmail.Location = new Point(440, 130);
            txtHotelEmail.Name = "txtHotelEmail";
            txtHotelEmail.Size = new Size(500, 25);
            txtHotelEmail.TabIndex = 8;
            txtHotelEmail.Text = "info@grandhotelerp.hu";
            // 
            // pnlSystemGroup
            // 
            pnlSystemGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSystemGroup.BackColor = Color.White;
            pnlSystemGroup.BorderStyle = BorderStyle.FixedSingle;
            pnlSystemGroup.Controls.Add(chkEnableDebugMode);
            pnlSystemGroup.Controls.Add(chkEnableAutoBackup);
            pnlSystemGroup.Controls.Add(cbCurrency);
            pnlSystemGroup.Controls.Add(lbCurrency);
            pnlSystemGroup.Controls.Add(lbSystemGroupTitle);
            pnlSystemGroup.Location = new Point(10, 225);
            pnlSystemGroup.Name = "pnlSystemGroup";
            pnlSystemGroup.Size = new Size(1435, 180);
            pnlSystemGroup.TabIndex = 1;
            // 
            // lbSystemGroupTitle
            // 
            lbSystemGroupTitle.AutoSize = true;
            lbSystemGroupTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbSystemGroupTitle.ForeColor = Color.DimGray;
            lbSystemGroupTitle.Location = new Point(15, 12);
            lbSystemGroupTitle.Name = "lbSystemGroupTitle";
            lbSystemGroupTitle.Size = new Size(141, 19);
            lbSystemGroupTitle.TabIndex = 0;
            lbSystemGroupTitle.Text = "SYSTEM SETTINGS";
            // 
            // lbCurrency
            // 
            lbCurrency.AutoSize = true;
            lbCurrency.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbCurrency.Location = new Point(15, 45);
            lbCurrency.Name = "lbCurrency";
            lbCurrency.Size = new Size(116, 15);
            lbCurrency.TabIndex = 1;
            lbCurrency.Text = "Default Currency:";
            // 
            // cbCurrency
            // 
            cbCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCurrency.FormattingEnabled = true;
            cbCurrency.Items.AddRange(new object[] { "HUF (Ft)", "EUR (€)", "USD ($)" });
            cbCurrency.Location = new Point(15, 65);
            cbCurrency.Name = "cbCurrency";
            cbCurrency.Size = new Size(250, 25);
            cbCurrency.TabIndex = 2;
            // 
            // chkEnableAutoBackup
            // 
            chkEnableAutoBackup.AutoSize = true;
            chkEnableAutoBackup.Checked = true;
            chkEnableAutoBackup.CheckState = CheckState.Checked;
            chkEnableAutoBackup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chkEnableAutoBackup.Location = new Point(15, 110);
            chkEnableAutoBackup.Name = "chkEnableAutoBackup";
            chkEnableAutoBackup.Size = new Size(203, 19);
            chkEnableAutoBackup.TabIndex = 3;
            chkEnableAutoBackup.Text = "Automatic daily database backup";
            chkEnableAutoBackup.UseVisualStyleBackColor = true;
            // 
            // chkEnableDebugMode
            // 
            chkEnableDebugMode.AutoSize = true;
            chkEnableDebugMode.Font = new Font("Segoe UI", 9F);
            chkEnableDebugMode.Location = new Point(300, 110);
            chkEnableDebugMode.Name = "chkEnableDebugMode";
            chkEnableDebugMode.Size = new Size(188, 19);
            chkEnableDebugMode.TabIndex = 4;
            chkEnableDebugMode.Text = "Run in Debug Mode (Logs)";
            chkEnableDebugMode.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveSettings.BackColor = Color.ForestGreen;
            btnSaveSettings.FlatStyle = FlatStyle.Flat;
            btnSaveSettings.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSaveSettings.ForeColor = Color.White;
            btnSaveSettings.Location = new Point(1225, 490);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(220, 50);
            btnSaveSettings.TabIndex = 2;
            btnSaveSettings.Text = "SAVE SETTINGS";
            btnSaveSettings.UseVisualStyleBackColor = false;
            // 
            // SettingsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9.75F);
            Name = "SettingsControl";
            Size = new Size(1740, 639);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlSidebar.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlGeneralGroup.ResumeLayout(false);
            pnlGeneralGroup.PerformLayout();
            pnlSystemGroup.ResumeLayout(false);
            pnlSystemGroup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lbSettingsTitle;
        private Panel pnlSidebar;
        private Button btnNavGeneral;
        private Button btnNavInvoicing;
        private Button btnNavDatabase;
        private Button btnNavNotifications;

        private Panel pnlContent;
        private Panel pnlGeneralGroup;
        private Label lbGeneralGroupTitle;
        private Label lbHotelName;
        private TextBox txtHotelName;
        private Label lbHotelAddress;
        private TextBox txtHotelAddress;
        private Label lbHotelTaxNum;
        private TextBox txtHotelTaxNum;
        private Label lbHotelEmail;
        private TextBox txtHotelEmail;

        private Panel pnlSystemGroup;
        private Label lbSystemGroupTitle;
        private Label lbCurrency;
        private ComboBox cbCurrency;
        private CheckBox chkEnableAutoBackup;
        private CheckBox chkEnableDebugMode;

        private Button btnSaveSettings;
    }
}