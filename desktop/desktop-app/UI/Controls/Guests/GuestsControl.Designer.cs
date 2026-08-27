using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using System;

namespace Hotel_erp_Winforms_App.UI.Controls
{
    partial class GuestsControl
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

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            lbFilter = new Label();
            lbSearch = new Label();
            txtSearch = new TextBox();
            lbTypeFilter = new Label();
            cbTypeFilter = new ComboBox();
            btnSearch = new Button();
            lbUtility = new Label();
            btnRefresh = new Button();
            btnNewGuest = new Button();
            pnlKpiTotalGuests = new Panel();
            lbKpiTotalGuestsTitle = new Label();
            lbKpiTotalGuestsValue = new Label();
            lbKpiTotalGuestsSub = new Label();
            pnlKpiVip = new Panel();
            lbKpiVipTitle = new Label();
            lbKpiVipValue = new Label();
            lbKpiVipSub = new Label();
            pnlKpiInHouse = new Panel();
            lbKpiInHouseTitle = new Label();
            lbKpiInHouseValue = new Label();
            lbKpiInHouseSub = new Label();
            pnlKpiBlacklist = new Panel();
            lbKpiBlacklistTitle = new Label();
            lbKpiBlacklistValue = new Label();
            lbKpiBlacklistSub = new Label();
            pnlGrid = new Panel();
            dgvGuests = new DataGridView();
            colGuestId = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colIdCardNumber = new DataGridViewTextBoxColumn();
            colLoyaltyPoints = new DataGridViewTextBoxColumn();
            colGuestCategory = new DataGridViewTextBoxColumn();
            colTotalVisits = new DataGridViewTextBoxColumn();
            pnlEditor = new Panel();
            lbEditorTitle = new Label();
            lbFullNameTitle = new Label();
            tbFullName = new TextBox();
            lbEmailTitle = new Label();
            tbEmail = new TextBox();
            lbPhoneTitle = new Label();
            tbPhone = new TextBox();
            lbIdCardTitle = new Label();
            tbIdCard = new TextBox();
            lbAddressTitle = new Label();
            tbAddress = new TextBox();
            lbCategoryTitle = new Label();
            cbCategory = new ComboBox();
            lbNotesTitle = new Label();
            tbNotes = new TextBox();
            btnSaveGuest = new Button();
            pnlTop.SuspendLayout();
            pnlKpiTotalGuests.SuspendLayout();
            pnlKpiVip.SuspendLayout();
            pnlKpiInHouse.SuspendLayout();
            pnlKpiBlacklist.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGuests).BeginInit();
            pnlEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTop.BackColor = Color.FromArgb(245, 245, 248);
            pnlTop.BorderStyle = BorderStyle.FixedSingle;
            pnlTop.Controls.Add(btnNewGuest);
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Controls.Add(lbUtility);
            pnlTop.Controls.Add(btnSearch);
            pnlTop.Controls.Add(cbTypeFilter);
            pnlTop.Controls.Add(lbTypeFilter);
            pnlTop.Controls.Add(txtSearch);
            pnlTop.Controls.Add(lbSearch);
            pnlTop.Controls.Add(lbFilter);
            pnlTop.Location = new Point(10, 10);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1350, 75);
            pnlTop.TabIndex = 0;
            // 
            // lbFilter
            // 
            lbFilter.AutoSize = true;
            lbFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbFilter.ForeColor = Color.DimGray;
            lbFilter.Location = new Point(15, 10);
            lbFilter.Name = "lbFilter";
            lbFilter.Size = new Size(106, 19);
            lbFilter.TabIndex = 0;
            lbFilter.Text = "GUEST FILTERS";
            // 
            // lbSearch
            // 
            lbSearch.AutoSize = true;
            lbSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbSearch.Location = new Point(15, 38);
            lbSearch.Name = "lbSearch";
            lbSearch.Size = new Size(52, 17);
            lbSearch.TabIndex = 1;
            lbSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(73, 35);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(180, 25);
            txtSearch.TabIndex = 2;
            // 
            // lbTypeFilter
            // 
            lbTypeFilter.AutoSize = true;
            lbTypeFilter.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbTypeFilter.Location = new Point(275, 38);
            lbTypeFilter.Name = "lbTypeFilter";
            lbTypeFilter.Size = new Size(69, 17);
            lbTypeFilter.TabIndex = 3;
            lbTypeFilter.Text = "Category:";
            // 
            // cbTypeFilter
            // 
            cbTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTypeFilter.FormattingEnabled = true;
            cbTypeFilter.Items.AddRange(new object[] { "All Categories", "Standard", "VIP", "Corporate", "Blacklisted" });
            cbTypeFilter.Location = new Point(350, 35);
            cbTypeFilter.Name = "cbTypeFilter";
            cbTypeFilter.Size = new Size(140, 25);
            cbTypeFilter.TabIndex = 4;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ButtonFace;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSearch.Location = new Point(510, 31);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 32);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Filter";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // lbUtility
            // 
            lbUtility.AutoSize = true;
            lbUtility.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbUtility.ForeColor = Color.DimGray;
            lbUtility.Location = new Point(1080, 10);
            lbUtility.Name = "lbUtility";
            lbUtility.Size = new Size(69, 19);
            lbUtility.TabIndex = 6;
            lbUtility.Text = "ACTIONS";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ButtonFace;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.Location = new Point(1080, 33);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 30);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Reload";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnNewGuest
            // 
            btnNewGuest.BackColor = SystemColors.ButtonFace;
            btnNewGuest.FlatStyle = FlatStyle.Flat;
            btnNewGuest.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNewGuest.Location = new Point(1200, 33);
            btnNewGuest.Name = "btnNewGuest";
            btnNewGuest.Size = new Size(130, 30);
            btnNewGuest.TabIndex = 8;
            btnNewGuest.Text = "+ Add Guest";
            btnNewGuest.UseVisualStyleBackColor = false;
            // 
            // pnlKpiTotalGuests
            // 
            pnlKpiTotalGuests.BackColor = Color.White;
            pnlKpiTotalGuests.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiTotalGuests.Controls.Add(lbKpiTotalGuestsSub);
            pnlKpiTotalGuests.Controls.Add(lbKpiTotalGuestsValue);
            pnlKpiTotalGuests.Controls.Add(lbKpiTotalGuestsTitle);
            pnlKpiTotalGuests.Location = new Point(10, 95);
            pnlKpiTotalGuests.Name = "pnlKpiTotalGuests";
            pnlKpiTotalGuests.Size = new Size(325, 85);
            pnlKpiTotalGuests.TabIndex = 1;
            // 
            // lbKpiTotalGuestsTitle
            // 
            lbKpiTotalGuestsTitle.AutoSize = true;
            lbKpiTotalGuestsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiTotalGuestsTitle.ForeColor = Color.DimGray;
            lbKpiTotalGuestsTitle.Location = new Point(12, 10);
            lbKpiTotalGuestsTitle.Name = "lbKpiTotalGuestsTitle";
            lbKpiTotalGuestsTitle.Size = new Size(92, 15);
            lbKpiTotalGuestsTitle.TabIndex = 0;
            lbKpiTotalGuestsTitle.Text = "TOTAL GUESTS";
            // 
            // lbKpiTotalGuestsValue
            // 
            lbKpiTotalGuestsValue.AutoSize = true;
            lbKpiTotalGuestsValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiTotalGuestsValue.ForeColor = Color.FromArgb(24, 60, 142);
            lbKpiTotalGuestsValue.Location = new Point(10, 27);
            lbKpiTotalGuestsValue.Name = "lbKpiTotalGuestsValue";
            lbKpiTotalGuestsValue.Size = new Size(28, 32);
            lbKpiTotalGuestsValue.TabIndex = 1;
            lbKpiTotalGuestsValue.Text = "0";
            // 
            // lbKpiTotalGuestsSub
            // 
            lbKpiTotalGuestsSub.AutoSize = true;
            lbKpiTotalGuestsSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiTotalGuestsSub.ForeColor = Color.Gray;
            lbKpiTotalGuestsSub.Location = new Point(12, 60);
            lbKpiTotalGuestsSub.Name = "lbKpiTotalGuestsSub";
            lbKpiTotalGuestsSub.Size = new Size(130, 15);
            lbKpiTotalGuestsSub.TabIndex = 2;
            lbKpiTotalGuestsSub.Text = "Registered in database";
            // 
            // pnlKpiVip
            // 
            pnlKpiVip.BackColor = Color.White;
            pnlKpiVip.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiVip.Controls.Add(lbKpiVipSub);
            pnlKpiVip.Controls.Add(lbKpiVipValue);
            pnlKpiVip.Controls.Add(lbKpiVipTitle);
            pnlKpiVip.Location = new Point(350, 95);
            pnlKpiVip.Name = "pnlKpiVip";
            pnlKpiVip.Size = new Size(325, 85);
            pnlKpiVip.TabIndex = 2;
            // 
            // lbKpiVipTitle
            // 
            lbKpiVipTitle.AutoSize = true;
            lbKpiVipTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiVipTitle.ForeColor = Color.DimGray;
            lbKpiVipTitle.Location = new Point(12, 10);
            lbKpiVipTitle.Name = "lbKpiVipTitle";
            lbKpiVipTitle.Size = new Size(74, 15);
            lbKpiVipTitle.TabIndex = 0;
            lbKpiVipTitle.Text = "VIP GUESTS";
            // 
            // lbKpiVipValue
            // 
            lbKpiVipValue.AutoSize = true;
            lbKpiVipValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiVipValue.ForeColor = Color.DarkGoldenrod;
            lbKpiVipValue.Location = new Point(10, 27);
            lbKpiVipValue.Name = "lbKpiVipValue";
            lbKpiVipValue.Size = new Size(28, 32);
            lbKpiVipValue.TabIndex = 1;
            lbKpiVipValue.Text = "0";
            // 
            // lbKpiVipSub
            // 
            lbKpiVipSub.AutoSize = true;
            lbKpiVipSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiVipSub.ForeColor = Color.Gray;
            lbKpiVipSub.Location = new Point(12, 60);
            lbKpiVipSub.Name = "lbKpiVipSub";
            lbKpiVipSub.Size = new Size(130, 15);
            lbKpiVipSub.TabIndex = 2;
            lbKpiVipSub.Text = "High value / Loyalty VIP";
            // 
            // pnlKpiInHouse
            // 
            pnlKpiInHouse.BackColor = Color.White;
            pnlKpiInHouse.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiInHouse.Controls.Add(lbKpiInHouseSub);
            pnlKpiInHouse.Controls.Add(lbKpiInHouseValue);
            pnlKpiInHouse.Controls.Add(lbKpiInHouseTitle);
            pnlKpiInHouse.Location = new Point(690, 95);
            pnlKpiInHouse.Name = "pnlKpiInHouse";
            pnlKpiInHouse.Size = new Size(325, 85);
            pnlKpiInHouse.TabIndex = 3;
            // 
            // lbKpiInHouseTitle
            // 
            lbKpiInHouseTitle.AutoSize = true;
            lbKpiInHouseTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiInHouseTitle.ForeColor = Color.DimGray;
            lbKpiInHouseTitle.Location = new Point(12, 10);
            lbKpiInHouseTitle.Name = "lbKpiInHouseTitle";
            lbKpiInHouseTitle.Size = new Size(109, 15);
            lbKpiInHouseTitle.TabIndex = 0;
            lbKpiInHouseTitle.Text = "CURRENTLY STAYING";
            // 
            // lbKpiInHouseValue
            // 
            lbKpiInHouseValue.AutoSize = true;
            lbKpiInHouseValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiInHouseValue.ForeColor = Color.DarkGreen;
            lbKpiInHouseValue.Location = new Point(10, 27);
            lbKpiInHouseValue.Name = "lbKpiInHouseValue";
            lbKpiInHouseValue.Size = new Size(28, 32);
            lbKpiInHouseValue.TabIndex = 1;
            lbKpiInHouseValue.Text = "0";
            // 
            // lbKpiInHouseSub
            // 
            lbKpiInHouseSub.AutoSize = true;
            lbKpiInHouseSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiInHouseSub.ForeColor = Color.Gray;
            lbKpiInHouseSub.Location = new Point(12, 60);
            lbKpiInHouseSub.Name = "lbKpiInHouseSub";
            lbKpiInHouseSub.Size = new Size(130, 15);
            lbKpiInHouseSub.TabIndex = 2;
            lbKpiInHouseSub.Text = "Active room check-ins";
            // 
            // pnlKpiBlacklist
            // 
            pnlKpiBlacklist.BackColor = Color.White;
            pnlKpiBlacklist.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiBlacklist.Controls.Add(lbKpiBlacklistSub);
            pnlKpiBlacklist.Controls.Add(lbKpiBlacklistValue);
            pnlKpiBlacklist.Controls.Add(lbKpiBlacklistTitle);
            pnlKpiBlacklist.Location = new Point(1035, 95);
            pnlKpiBlacklist.Name = "pnlKpiBlacklist";
            pnlKpiBlacklist.Size = new Size(325, 85);
            pnlKpiBlacklist.TabIndex = 4;
            // 
            // lbKpiBlacklistTitle
            // 
            lbKpiBlacklistTitle.AutoSize = true;
            lbKpiBlacklistTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiBlacklistTitle.ForeColor = Color.DimGray;
            lbKpiBlacklistTitle.Location = new Point(12, 10);
            lbKpiBlacklistTitle.Name = "lbKpiBlacklistTitle";
            lbKpiBlacklistTitle.Size = new Size(76, 15);
            lbKpiBlacklistTitle.TabIndex = 0;
            lbKpiBlacklistTitle.Text = "BLACKLISTED";
            // 
            // lbKpiBlacklistValue
            // 
            lbKpiBlacklistValue.AutoSize = true;
            lbKpiBlacklistValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiBlacklistValue.ForeColor = Color.DarkRed;
            lbKpiBlacklistValue.Location = new Point(10, 27);
            lbKpiBlacklistValue.Name = "lbKpiBlacklistValue";
            lbKpiBlacklistValue.Size = new Size(28, 32);
            lbKpiBlacklistValue.TabIndex = 1;
            lbKpiBlacklistValue.Text = "0";
            // 
            // lbKpiBlacklistSub
            // 
            lbKpiBlacklistSub.AutoSize = true;
            lbKpiBlacklistSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiBlacklistSub.ForeColor = Color.Gray;
            lbKpiBlacklistSub.Location = new Point(12, 60);
            lbKpiBlacklistSub.Name = "lbKpiBlacklistSub";
            lbKpiBlacklistSub.Size = new Size(116, 15);
            lbKpiBlacklistSub.TabIndex = 2;
            lbKpiBlacklistSub.Text = "Restricted booking";
            // 
            // pnlGrid
            // 
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrid.BackColor = Color.White;
            pnlGrid.Controls.Add(dgvGuests);
            pnlGrid.Location = new Point(10, 190);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(1350, 430);
            pnlGrid.TabIndex = 5;
            // 
            // dgvGuests
            // 
            dgvGuests.AllowUserToAddRows = false;
            dgvGuests.AllowUserToDeleteRows = false;
            dgvGuests.BackgroundColor = Color.White;
            dgvGuests.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 60, 142);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(24, 60, 142);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvGuests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvGuests.ColumnHeadersHeight = 40;
            dgvGuests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvGuests.Columns.AddRange(new DataGridViewColumn[] { colGuestId, colFullName, colEmail, colPhone, colIdCardNumber, colLoyaltyPoints, colGuestCategory, colTotalVisits });
            dgvGuests.Dock = DockStyle.Fill;
            dgvGuests.EnableHeadersVisualStyles = false;
            dgvGuests.Location = new Point(0, 0);
            dgvGuests.MultiSelect = false;
            dgvGuests.Name = "dgvGuests";
            dgvGuests.ReadOnly = true;
            dgvGuests.RowHeadersVisible = false;
            dgvGuests.RowTemplate.Height = 35;
            dgvGuests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGuests.Size = new Size(1350, 430);
            dgvGuests.TabIndex = 0;
            // 
            // colGuestId
            // 
            colGuestId.HeaderText = "Id";
            colGuestId.Name = "colGuestId";
            colGuestId.ReadOnly = true;
            colGuestId.Visible = false;
            // 
            // colFullName
            // 
            colFullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFullName.FillWeight = 20F;
            colFullName.HeaderText = "Full Name";
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEmail.FillWeight = 20F;
            colEmail.HeaderText = "Email Address";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colPhone
            // 
            colPhone.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPhone.FillWeight = 15F;
            colPhone.HeaderText = "Phone";
            colPhone.Name = "colPhone";
            colPhone.ReadOnly = true;
            // 
            // colIdCardNumber
            // 
            colIdCardNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colIdCardNumber.FillWeight = 15F;
            colIdCardNumber.HeaderText = "ID / Passport #";
            colIdCardNumber.Name = "colIdCardNumber";
            colIdCardNumber.ReadOnly = true;
            // 
            // colLoyaltyPoints
            // 
            colLoyaltyPoints.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLoyaltyPoints.FillWeight = 10F;
            colLoyaltyPoints.HeaderText = "Points";
            colLoyaltyPoints.Name = "colLoyaltyPoints";
            colLoyaltyPoints.ReadOnly = true;
            // 
            // colGuestCategory
            // 
            colGuestCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colGuestCategory.FillWeight = 12F;
            colGuestCategory.HeaderText = "Category";
            colGuestCategory.Name = "colGuestCategory";
            colGuestCategory.ReadOnly = true;
            // 
            // colTotalVisits
            // 
            colTotalVisits.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTotalVisits.FillWeight = 8F;
            colTotalVisits.HeaderText = "Stays";
            colTotalVisits.Name = "colTotalVisits";
            colTotalVisits.ReadOnly = true;
            // 
            // pnlEditor
            // 
            pnlEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlEditor.BorderStyle = BorderStyle.FixedSingle;
            pnlEditor.Controls.Add(btnSaveGuest);
            pnlEditor.Controls.Add(tbNotes);
            pnlEditor.Controls.Add(lbNotesTitle);
            pnlEditor.Controls.Add(cbCategory);
            pnlEditor.Controls.Add(lbCategoryTitle);
            pnlEditor.Controls.Add(tbAddress);
            pnlEditor.Controls.Add(lbAddressTitle);
            pnlEditor.Controls.Add(tbIdCard);
            pnlEditor.Controls.Add(lbIdCardTitle);
            pnlEditor.Controls.Add(tbPhone);
            pnlEditor.Controls.Add(lbPhoneTitle);
            pnlEditor.Controls.Add(tbEmail);
            pnlEditor.Controls.Add(lbEmailTitle);
            pnlEditor.Controls.Add(tbFullName);
            pnlEditor.Controls.Add(lbFullNameTitle);
            pnlEditor.Controls.Add(lbEditorTitle);
            pnlEditor.Location = new Point(1370, 10);
            pnlEditor.Name = "pnlEditor";
            pnlEditor.Size = new Size(355, 610);
            pnlEditor.TabIndex = 6;
            // 
            // lbEditorTitle
            // 
            lbEditorTitle.AutoSize = true;
            lbEditorTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbEditorTitle.ForeColor = Color.FromArgb(24, 60, 142);
            lbEditorTitle.Location = new Point(15, 12);
            lbEditorTitle.Name = "lbEditorTitle";
            lbEditorTitle.Size = new Size(164, 20);
            lbEditorTitle.TabIndex = 0;
            lbEditorTitle.Text = "GUEST PROFILE DETAILS";
            // 
            // lbFullNameTitle
            // 
            lbFullNameTitle.AutoSize = true;
            lbFullNameTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbFullNameTitle.Location = new Point(15, 45);
            lbFullNameTitle.Name = "lbFullNameTitle";
            lbFullNameTitle.Size = new Size(75, 17);
            lbFullNameTitle.TabIndex = 1;
            lbFullNameTitle.Text = "Full Name:";
            // 
            // tbFullName
            // 
            tbFullName.Location = new Point(15, 65);
            tbFullName.Name = "tbFullName";
            tbFullName.Size = new Size(320, 25);
            tbFullName.TabIndex = 2;
            // 
            // lbEmailTitle
            // 
            lbEmailTitle.AutoSize = true;
            lbEmailTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbEmailTitle.Location = new Point(15, 100);
            lbEmailTitle.Name = "lbEmailTitle";
            lbEmailTitle.Size = new Size(100, 17);
            lbEmailTitle.TabIndex = 3;
            lbEmailTitle.Text = "Email Address:";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(15, 120);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(320, 25);
            tbEmail.TabIndex = 4;
            // 
            // lbPhoneTitle
            // 
            lbPhoneTitle.AutoSize = true;
            lbPhoneTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbPhoneTitle.Location = new Point(15, 155);
            lbPhoneTitle.Name = "lbPhoneTitle";
            lbPhoneTitle.Size = new Size(105, 17);
            lbPhoneTitle.TabIndex = 5;
            lbPhoneTitle.Text = "Phone Number:";
            // 
            // tbPhone
            // 
            tbPhone.Location = new Point(15, 175);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(320, 25);
            tbPhone.TabIndex = 6;
            // 
            // lbIdCardTitle
            // 
            lbIdCardTitle.AutoSize = true;
            lbIdCardTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbIdCardTitle.Location = new Point(15, 210);
            lbIdCardTitle.Name = "lbIdCardTitle";
            lbIdCardTitle.Size = new Size(130, 17);
            lbIdCardTitle.TabIndex = 7;
            lbIdCardTitle.Text = "ID / Passport Status:";
            // 
            // tbIdCard
            // 
            tbIdCard.Location = new Point(15, 230);
            tbIdCard.Name = "tbIdCard";
            tbIdCard.Size = new Size(320, 25);
            tbIdCard.TabIndex = 8;
            // 
            // lbAddressTitle
            // 
            lbAddressTitle.AutoSize = true;
            lbAddressTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbAddressTitle.Location = new Point(15, 265);
            lbAddressTitle.Name = "lbAddressTitle";
            lbAddressTitle.Size = new Size(119, 17);
            lbAddressTitle.TabIndex = 9;
            lbAddressTitle.Text = "Billing Address:";
            // 
            // tbAddress
            // 
            tbAddress.Location = new Point(15, 285);
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(320, 25);
            tbAddress.TabIndex = 10;
            // 
            // lbCategoryTitle
            // 
            lbCategoryTitle.AutoSize = true;
            lbCategoryTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbCategoryTitle.Location = new Point(15, 320);
            lbCategoryTitle.Name = "lbCategoryTitle";
            lbCategoryTitle.Size = new Size(111, 17);
            lbCategoryTitle.TabIndex = 11;
            lbCategoryTitle.Text = "Guest Category:";
            // 
            // cbCategory
            // 
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategory.FormattingEnabled = true;
            cbCategory.Items.AddRange(new object[] { "Standard", "VIP", "Corporate", "Blacklisted" });
            cbCategory.Location = new Point(15, 340);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(320, 25);
            cbCategory.TabIndex = 12;
            // 
            // lbNotesTitle
            // 
            lbNotesTitle.AutoSize = true;
            lbNotesTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbNotesTitle.Location = new Point(15, 375);
            lbNotesTitle.Name = "lbNotesTitle";
            lbNotesTitle.Size = new Size(176, 17);
            lbNotesTitle.TabIndex = 13;
            lbNotesTitle.Text = "Special Requests / Notes:";
            // 
            // tbNotes
            // 
            tbNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbNotes.Location = new Point(15, 395);
            tbNotes.Multiline = true;
            tbNotes.Name = "tbNotes";
            tbNotes.ScrollBars = ScrollBars.Vertical;
            tbNotes.Size = new Size(320, 142);
            tbNotes.TabIndex = 14;
            // 
            // btnSaveGuest
            // 
            btnSaveGuest.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSaveGuest.BackColor = SystemColors.ButtonFace;
            btnSaveGuest.FlatStyle = FlatStyle.Flat;
            btnSaveGuest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveGuest.Location = new Point(15, 550);
            btnSaveGuest.Name = "btnSaveGuest";
            btnSaveGuest.Size = new Size(320, 45);
            btnSaveGuest.TabIndex = 15;
            btnSaveGuest.Text = "Save Profile";
            btnSaveGuest.UseVisualStyleBackColor = false;
            // 
            // GuestsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            this.Controls.Add(pnlEditor);
            this.Controls.Add(pnlGrid);
            this.Controls.Add(pnlKpiBlacklist);
            this.Controls.Add(pnlKpiInHouse);
            this.Controls.Add(pnlKpiVip);
            this.Controls.Add(pnlKpiTotalGuests);
            this.Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 9.75F);
            Name = "GuestsControl";
            Size = new Size(1740, 639);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlKpiTotalGuests.ResumeLayout(false);
            pnlKpiTotalGuests.PerformLayout();
            pnlKpiVip.ResumeLayout(false);
            pnlKpiVip.PerformLayout();
            pnlKpiInHouse.ResumeLayout(false);
            pnlKpiInHouse.PerformLayout();
            pnlKpiBlacklist.ResumeLayout(false);
            pnlKpiBlacklist.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGuests).EndInit();
            pnlEditor.ResumeLayout(false);
            pnlEditor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Panel pnlTop;
        private Label lbFilter;
        private Label lbSearch;
        private TextBox txtSearch;
        private Label lbTypeFilter;
        private ComboBox cbTypeFilter;
        private Button btnSearch;
        private Label lbUtility;
        private Button btnRefresh;
        private Button btnNewGuest;

        private Panel pnlKpiTotalGuests;
        private Label lbKpiTotalGuestsTitle;
        private Label lbKpiTotalGuestsValue;
        private Label lbKpiTotalGuestsSub;

        private Panel pnlKpiVip;
        private Label lbKpiVipTitle;
        private Label lbKpiVipValue;
        private Label lbKpiVipSub;

        private Panel pnlKpiInHouse;
        private Label lbKpiInHouseTitle;
        private Label lbKpiInHouseValue;
        private Label lbKpiInHouseSub;

        private Panel pnlKpiBlacklist;
        private Label lbKpiBlacklistTitle;
        private Label lbKpiBlacklistValue;
        private Label lbKpiBlacklistSub;

        private Panel pnlGrid;
        private DataGridView dgvGuests;
        private DataGridViewTextBoxColumn colGuestId;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colIdCardNumber;
        private DataGridViewTextBoxColumn colLoyaltyPoints;
        private DataGridViewTextBoxColumn colGuestCategory;
        private DataGridViewTextBoxColumn colTotalVisits;

        private Panel pnlEditor;
        private Label lbEditorTitle;
        private Label lbFullNameTitle;
        private TextBox tbFullName;
        private Label lbEmailTitle;
        private TextBox tbEmail;
        private Label lbPhoneTitle;
        private TextBox tbPhone;
        private Label lbIdCardTitle;
        private TextBox tbIdCard;
        private Label lbAddressTitle;
        private TextBox tbAddress;
        private Label lbCategoryTitle;
        private ComboBox cbCategory;
        private Label lbNotesTitle;
        private TextBox tbNotes;
        private Button btnSaveGuest;
    }
}