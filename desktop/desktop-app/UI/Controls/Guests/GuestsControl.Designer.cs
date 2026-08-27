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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            btnNewGuest = new Button();
            btnRefresh = new Button();
            lbUtility = new Label();
            btnSearch = new Button();
            cbTypeFilter = new ComboBox();
            lbTypeFilter = new Label();
            txtSearch = new TextBox();
            lbSearch = new Label();
            lbFilter = new Label();
            pnlKpiTotalGuests = new Panel();
            lbKpiTotalGuestsSub = new Label();
            lbKpiTotalGuestsValue = new Label();
            lbKpiTotalGuestsTitle = new Label();
            pnlKpiVip = new Panel();
            lbKpiVipSub = new Label();
            lbKpiVipValue = new Label();
            lbKpiVipTitle = new Label();
            pnlKpiInHouse = new Panel();
            lbKpiInHouseSub = new Label();
            lbKpiInHouseValue = new Label();
            lbKpiInHouseTitle = new Label();
            pnlKpiBlacklist = new Panel();
            lbKpiReturningSub = new Label();
            lbKpiReturningValue = new Label();
            lbKpiReturningTitle = new Label();
            pnlGrid = new Panel();
            dgvGuests = new DataGridView();
            colGuestId = new DataGridViewTextBoxColumn();
            colFirstName = new DataGridViewTextBoxColumn();
            colLastName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colIdCardNumber = new DataGridViewTextBoxColumn();
            colBirthdate = new DataGridViewTextBoxColumn();
            colCountry = new DataGridViewTextBoxColumn();
            colZip = new DataGridViewTextBoxColumn();
            colCity = new DataGridViewTextBoxColumn();
            colStreet = new DataGridViewTextBoxColumn();
            colCarPlate = new DataGridViewTextBoxColumn();
            colTotalNights = new DataGridViewTextBoxColumn();
            colLoyalty = new DataGridViewTextBoxColumn();
            pnlEditor = new Panel();
            dtpBirthdate = new DateTimePicker();
            btnSaveGuest = new Button();
            tbNotes = new TextBox();
            lbNotesTitle = new Label();
            cbCategory = new ComboBox();
            lbCountryTitle = new Label();
            lbBirthdateTitle = new Label();
            lbCategoryTitle = new Label();
            tbCountry = new TextBox();
            tbStreet = new TextBox();
            tbCity = new TextBox();
            tbZip = new TextBox();
            tbAddress = new TextBox();
            lbAddressTitle = new Label();
            tbIdCard = new TextBox();
            lbIdCardTitle = new Label();
            tbEmail = new TextBox();
            lbEmailTitle = new Label();
            tbLname = new TextBox();
            tbFname = new TextBox();
            tbFullName = new TextBox();
            lbFullNameTitle = new Label();
            lbEditorTitle = new Label();
            pnlTop.SuspendLayout();
            pnlKpiTotalGuests.SuspendLayout();
            pnlKpiVip.SuspendLayout();
            pnlKpiInHouse.SuspendLayout();
            pnlKpiBlacklist.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGuests).BeginInit();
            pnlEditor.SuspendLayout();
            SuspendLayout();
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
            btnNewGuest.Click += btnNewGuest_Click;
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
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lbUtility
            // 
            lbUtility.AutoSize = true;
            lbUtility.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbUtility.ForeColor = Color.DimGray;
            lbUtility.Location = new Point(1080, 10);
            lbUtility.Name = "lbUtility";
            lbUtility.Size = new Size(70, 19);
            lbUtility.TabIndex = 6;
            lbUtility.Text = "ACTIONS";
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
            btnSearch.Click += btnSearch_Click;
            // 
            // cbTypeFilter
            // 
            cbTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTypeFilter.FormattingEnabled = true;
            cbTypeFilter.Items.AddRange(new object[] { "All Categories", "Standard", "VIP", "Corporate" });
            cbTypeFilter.Location = new Point(350, 35);
            cbTypeFilter.Name = "cbTypeFilter";
            cbTypeFilter.Size = new Size(140, 25);
            cbTypeFilter.TabIndex = 4;
            // 
            // lbTypeFilter
            // 
            lbTypeFilter.AutoSize = true;
            lbTypeFilter.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbTypeFilter.Location = new Point(275, 38);
            lbTypeFilter.Name = "lbTypeFilter";
            lbTypeFilter.Size = new Size(68, 17);
            lbTypeFilter.TabIndex = 3;
            lbTypeFilter.Text = "Category:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(73, 35);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(180, 25);
            txtSearch.TabIndex = 2;
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
            // lbFilter
            // 
            lbFilter.AutoSize = true;
            lbFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbFilter.ForeColor = Color.DimGray;
            lbFilter.Location = new Point(15, 10);
            lbFilter.Name = "lbFilter";
            lbFilter.Size = new Size(105, 19);
            lbFilter.TabIndex = 0;
            lbFilter.Text = "GUEST FILTERS";
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
            // lbKpiTotalGuestsSub
            // 
            lbKpiTotalGuestsSub.AutoSize = true;
            lbKpiTotalGuestsSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiTotalGuestsSub.ForeColor = Color.Gray;
            lbKpiTotalGuestsSub.Location = new Point(12, 60);
            lbKpiTotalGuestsSub.Name = "lbKpiTotalGuestsSub";
            lbKpiTotalGuestsSub.Size = new Size(125, 15);
            lbKpiTotalGuestsSub.TabIndex = 2;
            lbKpiTotalGuestsSub.Text = "Registered in database";
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
            // lbKpiTotalGuestsTitle
            // 
            lbKpiTotalGuestsTitle.AutoSize = true;
            lbKpiTotalGuestsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiTotalGuestsTitle.ForeColor = Color.DimGray;
            lbKpiTotalGuestsTitle.Location = new Point(12, 10);
            lbKpiTotalGuestsTitle.Name = "lbKpiTotalGuestsTitle";
            lbKpiTotalGuestsTitle.Size = new Size(91, 15);
            lbKpiTotalGuestsTitle.TabIndex = 0;
            lbKpiTotalGuestsTitle.Text = "TOTAL GUESTS";
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
            // lbKpiVipSub
            // 
            lbKpiVipSub.AutoSize = true;
            lbKpiVipSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiVipSub.ForeColor = Color.Gray;
            lbKpiVipSub.Location = new Point(12, 60);
            lbKpiVipSub.Name = "lbKpiVipSub";
            lbKpiVipSub.Size = new Size(133, 15);
            lbKpiVipSub.TabIndex = 2;
            lbKpiVipSub.Text = "High value / Loyalty VIP";
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
            // lbKpiInHouseSub
            // 
            lbKpiInHouseSub.AutoSize = true;
            lbKpiInHouseSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiInHouseSub.ForeColor = Color.Gray;
            lbKpiInHouseSub.Location = new Point(12, 60);
            lbKpiInHouseSub.Name = "lbKpiInHouseSub";
            lbKpiInHouseSub.Size = new Size(126, 15);
            lbKpiInHouseSub.TabIndex = 2;
            lbKpiInHouseSub.Text = "Active room check-ins";
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
            // lbKpiInHouseTitle
            // 
            lbKpiInHouseTitle.AutoSize = true;
            lbKpiInHouseTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiInHouseTitle.ForeColor = Color.DimGray;
            lbKpiInHouseTitle.Location = new Point(12, 10);
            lbKpiInHouseTitle.Name = "lbKpiInHouseTitle";
            lbKpiInHouseTitle.Size = new Size(125, 15);
            lbKpiInHouseTitle.TabIndex = 0;
            lbKpiInHouseTitle.Text = "CURRENTLY STAYING";
            // 
            // pnlKpiBlacklist
            // 
            pnlKpiBlacklist.BackColor = Color.White;
            pnlKpiBlacklist.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiBlacklist.Controls.Add(lbKpiReturningSub);
            pnlKpiBlacklist.Controls.Add(lbKpiReturningValue);
            pnlKpiBlacklist.Controls.Add(lbKpiReturningTitle);
            pnlKpiBlacklist.Location = new Point(1035, 95);
            pnlKpiBlacklist.Name = "pnlKpiBlacklist";
            pnlKpiBlacklist.Size = new Size(325, 85);
            pnlKpiBlacklist.TabIndex = 4;
            // 
            // lbKpiReturningSub
            // 
            lbKpiReturningSub.AutoSize = true;
            lbKpiReturningSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiReturningSub.ForeColor = Color.Gray;
            lbKpiReturningSub.Location = new Point(12, 60);
            lbKpiReturningSub.Name = "lbKpiReturningSub";
            lbKpiReturningSub.Size = new Size(154, 15);
            lbKpiReturningSub.TabIndex = 2;
            lbKpiReturningSub.Text = "Number of returning guests";
            // 
            // lbKpiReturningValue
            // 
            lbKpiReturningValue.AutoSize = true;
            lbKpiReturningValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiReturningValue.ForeColor = Color.FromArgb(124, 58, 237);
            lbKpiReturningValue.Location = new Point(10, 27);
            lbKpiReturningValue.Name = "lbKpiReturningValue";
            lbKpiReturningValue.Size = new Size(28, 32);
            lbKpiReturningValue.TabIndex = 1;
            lbKpiReturningValue.Text = "0";
            // 
            // lbKpiReturningTitle
            // 
            lbKpiReturningTitle.AutoSize = true;
            lbKpiReturningTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiReturningTitle.ForeColor = Color.DimGray;
            lbKpiReturningTitle.Location = new Point(12, 10);
            lbKpiReturningTitle.Name = "lbKpiReturningTitle";
            lbKpiReturningTitle.Size = new Size(76, 15);
            lbKpiReturningTitle.TabIndex = 0;
            lbKpiReturningTitle.Text = "RETURNING";
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
            dgvGuests.AllowUserToOrderColumns = true;
            dgvGuests.AllowUserToResizeColumns = false;
            dgvGuests.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 248, 253);
            dgvGuests.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvGuests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGuests.BackgroundColor = Color.White;
            dgvGuests.BorderStyle = BorderStyle.None;
            dgvGuests.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvGuests.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvGuests.ColumnHeadersHeight = 40;
            dgvGuests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvGuests.Columns.AddRange(new DataGridViewColumn[] { colGuestId, colFirstName, colLastName, colEmail, colIdCardNumber, colBirthdate, colCountry, colZip, colCity, colStreet, colCarPlate, colTotalNights, colLoyalty });
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = SystemColors.Window;
            dataGridViewCellStyle15.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle15.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.False;
            dgvGuests.DefaultCellStyle = dataGridViewCellStyle15;
            dgvGuests.Dock = DockStyle.Fill;
            dgvGuests.EnableHeadersVisualStyles = false;
            dgvGuests.GridColor = SystemColors.ControlLight;
            dgvGuests.Location = new Point(0, 0);
            dgvGuests.Margin = new Padding(5);
            dgvGuests.MultiSelect = false;
            dgvGuests.Name = "dgvGuests";
            dgvGuests.ReadOnly = true;
            dgvGuests.RowHeadersVisible = false;
            dgvGuests.RowTemplate.Height = 35;
            dgvGuests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGuests.Size = new Size(1350, 430);
            dgvGuests.TabIndex = 0;
            dgvGuests.CellClick += dgvGuests_CellClick;
            // 
            // colGuestId
            // 
            colGuestId.DataPropertyName = "Id";
            colGuestId.HeaderText = "Id";
            colGuestId.Name = "colGuestId";
            colGuestId.ReadOnly = true;
            colGuestId.Visible = false;
            // 
            // colFirstName
            // 
            colFirstName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFirstName.DataPropertyName = "Fname";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colFirstName.DefaultCellStyle = dataGridViewCellStyle3;
            colFirstName.FillWeight = 90F;
            colFirstName.HeaderText = "First Name";
            colFirstName.Name = "colFirstName";
            colFirstName.ReadOnly = true;
            // 
            // colLastName
            // 
            colLastName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLastName.DataPropertyName = "Lname";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colLastName.DefaultCellStyle = dataGridViewCellStyle4;
            colLastName.FillWeight = 90F;
            colLastName.HeaderText = "Last Name";
            colLastName.Name = "colLastName";
            colLastName.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colEmail.DataPropertyName = "Email";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEmail.DefaultCellStyle = dataGridViewCellStyle5;
            colEmail.FillWeight = 120F;
            colEmail.HeaderText = "Email Address";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colIdCardNumber
            // 
            colIdCardNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colIdCardNumber.DataPropertyName = "IdCardNumber";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colIdCardNumber.DefaultCellStyle = dataGridViewCellStyle6;
            colIdCardNumber.FillWeight = 90F;
            colIdCardNumber.HeaderText = "ID Number";
            colIdCardNumber.Name = "colIdCardNumber";
            colIdCardNumber.ReadOnly = true;
            // 
            // colBirthdate
            // 
            colBirthdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBirthdate.DataPropertyName = "DateOfBirth";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colBirthdate.DefaultCellStyle = dataGridViewCellStyle7;
            colBirthdate.FillWeight = 85F;
            colBirthdate.HeaderText = "Birthdate";
            colBirthdate.Name = "colBirthdate";
            colBirthdate.ReadOnly = true;
            // 
            // colCountry
            // 
            colCountry.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCountry.DataPropertyName = "Country";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCountry.DefaultCellStyle = dataGridViewCellStyle8;
            colCountry.FillWeight = 80F;
            colCountry.HeaderText = "Country";
            colCountry.Name = "colCountry";
            colCountry.ReadOnly = true;
            // 
            // colZip
            // 
            colZip.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colZip.DataPropertyName = "ZipCode";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colZip.DefaultCellStyle = dataGridViewCellStyle9;
            colZip.FillWeight = 65F;
            colZip.HeaderText = "Zip code";
            colZip.Name = "colZip";
            colZip.ReadOnly = true;
            // 
            // colCity
            // 
            colCity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCity.DataPropertyName = "City";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCity.DefaultCellStyle = dataGridViewCellStyle10;
            colCity.FillWeight = 85F;
            colCity.HeaderText = "City";
            colCity.Name = "colCity";
            colCity.ReadOnly = true;
            // 
            // colStreet
            // 
            colStreet.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colStreet.DataPropertyName = "Street";
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStreet.DefaultCellStyle = dataGridViewCellStyle11;
            colStreet.FillWeight = 110F;
            colStreet.HeaderText = "Street";
            colStreet.Name = "colStreet";
            colStreet.ReadOnly = true;
            // 
            // colCarPlate
            // 
            colCarPlate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCarPlate.DataPropertyName = "CarPlateNumber";
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCarPlate.DefaultCellStyle = dataGridViewCellStyle12;
            colCarPlate.FillWeight = 80F;
            colCarPlate.HeaderText = "Car Plate Number";
            colCarPlate.Name = "colCarPlate";
            colCarPlate.ReadOnly = true;
            // 
            // colTotalNights
            // 
            colTotalNights.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTotalNights.DataPropertyName = "TotalNights";
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTotalNights.DefaultCellStyle = dataGridViewCellStyle13;
            colTotalNights.FillWeight = 65F;
            colTotalNights.HeaderText = "Total Nights";
            colTotalNights.Name = "colTotalNights";
            colTotalNights.ReadOnly = true;
            // 
            // colLoyalty
            // 
            colLoyalty.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLoyalty.DataPropertyName = "LoyaltyLevel";
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colLoyalty.DefaultCellStyle = dataGridViewCellStyle14;
            colLoyalty.FillWeight = 60F;
            colLoyalty.HeaderText = "Loyalty";
            colLoyalty.Name = "colLoyalty";
            colLoyalty.ReadOnly = true;
            // 
            // pnlEditor
            // 
            pnlEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlEditor.BorderStyle = BorderStyle.FixedSingle;
            pnlEditor.Controls.Add(dtpBirthdate);
            pnlEditor.Controls.Add(btnSaveGuest);
            pnlEditor.Controls.Add(tbNotes);
            pnlEditor.Controls.Add(lbNotesTitle);
            pnlEditor.Controls.Add(cbCategory);
            pnlEditor.Controls.Add(lbCountryTitle);
            pnlEditor.Controls.Add(lbBirthdateTitle);
            pnlEditor.Controls.Add(lbCategoryTitle);
            pnlEditor.Controls.Add(tbCountry);
            pnlEditor.Controls.Add(tbStreet);
            pnlEditor.Controls.Add(tbCity);
            pnlEditor.Controls.Add(tbZip);
            pnlEditor.Controls.Add(tbAddress);
            pnlEditor.Controls.Add(lbAddressTitle);
            pnlEditor.Controls.Add(tbIdCard);
            pnlEditor.Controls.Add(lbIdCardTitle);
            pnlEditor.Controls.Add(tbEmail);
            pnlEditor.Controls.Add(lbEmailTitle);
            pnlEditor.Controls.Add(tbLname);
            pnlEditor.Controls.Add(tbFname);
            pnlEditor.Controls.Add(tbFullName);
            pnlEditor.Controls.Add(lbFullNameTitle);
            pnlEditor.Controls.Add(lbEditorTitle);
            pnlEditor.Location = new Point(1370, 10);
            pnlEditor.Name = "pnlEditor";
            pnlEditor.Size = new Size(355, 610);
            pnlEditor.TabIndex = 6;
            // 
            // dtpBirthdate
            // 
            dtpBirthdate.Format = DateTimePickerFormat.Short;
            dtpBirthdate.Location = new Point(15, 285);
            dtpBirthdate.MaxDate = new DateTime(2026, 8, 27, 0, 0, 0, 0);
            dtpBirthdate.MinDate = new DateTime(1910, 1, 1, 0, 0, 0, 0);
            dtpBirthdate.Name = "dtpBirthdate";
            dtpBirthdate.Size = new Size(165, 25);
            dtpBirthdate.TabIndex = 16;
            dtpBirthdate.Value = new DateTime(2026, 8, 27, 0, 0, 0, 0);
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
            btnSaveGuest.Click += btnSaveGuest_Click;
            // 
            // tbNotes
            // 
            tbNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbNotes.Location = new Point(15, 340);
            tbNotes.Multiline = true;
            tbNotes.Name = "tbNotes";
            tbNotes.ScrollBars = ScrollBars.Vertical;
            tbNotes.Size = new Size(320, 142);
            tbNotes.TabIndex = 14;
            // 
            // lbNotesTitle
            // 
            lbNotesTitle.AutoSize = true;
            lbNotesTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbNotesTitle.Location = new Point(15, 320);
            lbNotesTitle.Name = "lbNotesTitle";
            lbNotesTitle.Size = new Size(164, 17);
            lbNotesTitle.TabIndex = 13;
            lbNotesTitle.Text = "Special Requests / Notes:";
            // 
            // cbCategory
            // 
            cbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategory.FormattingEnabled = true;
            cbCategory.Items.AddRange(new object[] { "Standard", "VIP", "Corporate" });
            cbCategory.Location = new Point(15, 285);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(320, 25);
            cbCategory.TabIndex = 12;
            // 
            // lbCountryTitle
            // 
            lbCountryTitle.AutoSize = true;
            lbCountryTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbCountryTitle.Location = new Point(185, 265);
            lbCountryTitle.Name = "lbCountryTitle";
            lbCountryTitle.Size = new Size(62, 17);
            lbCountryTitle.TabIndex = 11;
            lbCountryTitle.Text = "Country:";
            // 
            // lbBirthdateTitle
            // 
            lbBirthdateTitle.AutoSize = true;
            lbBirthdateTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbBirthdateTitle.Location = new Point(15, 265);
            lbBirthdateTitle.Name = "lbBirthdateTitle";
            lbBirthdateTitle.Size = new Size(69, 17);
            lbBirthdateTitle.TabIndex = 11;
            lbBirthdateTitle.Text = "Birthdate:";
            // 
            // lbCategoryTitle
            // 
            lbCategoryTitle.AutoSize = true;
            lbCategoryTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbCategoryTitle.Location = new Point(15, 265);
            lbCategoryTitle.Name = "lbCategoryTitle";
            lbCategoryTitle.Size = new Size(107, 17);
            lbCategoryTitle.TabIndex = 11;
            lbCategoryTitle.Text = "Guest Category:";
            // 
            // tbCountry
            // 
            tbCountry.Location = new Point(185, 285);
            tbCountry.Name = "tbCountry";
            tbCountry.PlaceholderText = "Country";
            tbCountry.Size = new Size(150, 25);
            tbCountry.TabIndex = 10;
            // 
            // tbStreet
            // 
            tbStreet.Location = new Point(185, 230);
            tbStreet.Name = "tbStreet";
            tbStreet.PlaceholderText = "Street address";
            tbStreet.Size = new Size(150, 25);
            tbStreet.TabIndex = 10;
            // 
            // tbCity
            // 
            tbCity.Location = new Point(60, 230);
            tbCity.Name = "tbCity";
            tbCity.PlaceholderText = "City";
            tbCity.Size = new Size(120, 25);
            tbCity.TabIndex = 10;
            // 
            // tbZip
            // 
            tbZip.Location = new Point(15, 230);
            tbZip.Name = "tbZip";
            tbZip.PlaceholderText = "Zip";
            tbZip.Size = new Size(40, 25);
            tbZip.TabIndex = 10;
            // 
            // tbAddress
            // 
            tbAddress.Location = new Point(15, 230);
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(320, 25);
            tbAddress.TabIndex = 10;
            // 
            // lbAddressTitle
            // 
            lbAddressTitle.AutoSize = true;
            lbAddressTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbAddressTitle.Location = new Point(15, 210);
            lbAddressTitle.Name = "lbAddressTitle";
            lbAddressTitle.Size = new Size(105, 17);
            lbAddressTitle.TabIndex = 9;
            lbAddressTitle.Text = "Billing Address:";
            // 
            // tbIdCard
            // 
            tbIdCard.Location = new Point(15, 175);
            tbIdCard.Name = "tbIdCard";
            tbIdCard.PlaceholderText = "ID123456";
            tbIdCard.Size = new Size(320, 25);
            tbIdCard.TabIndex = 8;
            // 
            // lbIdCardTitle
            // 
            lbIdCardTitle.AutoSize = true;
            lbIdCardTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbIdCardTitle.Location = new Point(15, 155);
            lbIdCardTitle.Name = "lbIdCardTitle";
            lbIdCardTitle.Size = new Size(81, 17);
            lbIdCardTitle.TabIndex = 7;
            lbIdCardTitle.Text = "ID Number:";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(15, 120);
            tbEmail.Name = "tbEmail";
            tbEmail.PlaceholderText = "example@gmail.com";
            tbEmail.Size = new Size(320, 25);
            tbEmail.TabIndex = 4;
            // 
            // lbEmailTitle
            // 
            lbEmailTitle.AutoSize = true;
            lbEmailTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbEmailTitle.Location = new Point(15, 100);
            lbEmailTitle.Name = "lbEmailTitle";
            lbEmailTitle.Size = new Size(99, 17);
            lbEmailTitle.TabIndex = 3;
            lbEmailTitle.Text = "Email Address:";
            // 
            // tbLname
            // 
            tbLname.Location = new Point(180, 65);
            tbLname.Name = "tbLname";
            tbLname.PlaceholderText = "Last name";
            tbLname.Size = new Size(155, 25);
            tbLname.TabIndex = 2;
            // 
            // tbFname
            // 
            tbFname.Location = new Point(15, 65);
            tbFname.Name = "tbFname";
            tbFname.PlaceholderText = "First name";
            tbFname.Size = new Size(155, 25);
            tbFname.TabIndex = 2;
            // 
            // tbFullName
            // 
            tbFullName.Location = new Point(15, 65);
            tbFullName.Name = "tbFullName";
            tbFullName.Size = new Size(320, 25);
            tbFullName.TabIndex = 2;
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
            // lbEditorTitle
            // 
            lbEditorTitle.AutoSize = true;
            lbEditorTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbEditorTitle.ForeColor = Color.FromArgb(24, 60, 142);
            lbEditorTitle.Location = new Point(15, 12);
            lbEditorTitle.Name = "lbEditorTitle";
            lbEditorTitle.Size = new Size(182, 20);
            lbEditorTitle.TabIndex = 0;
            lbEditorTitle.Text = "GUEST PROFILE DETAILS";
            // 
            // GuestsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(pnlEditor);
            Controls.Add(pnlGrid);
            Controls.Add(pnlKpiBlacklist);
            Controls.Add(pnlKpiInHouse);
            Controls.Add(pnlKpiVip);
            Controls.Add(pnlKpiTotalGuests);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 9.75F);
            Name = "GuestsControl";
            Size = new Size(1740, 639);
            Load += GuestsControl_Load;
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
            ResumeLayout(false);
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
        private Label lbKpiReturningTitle;
        private Label lbKpiReturningValue;
        private Label lbKpiReturningSub;

        private Panel pnlGrid;
        private DataGridView dgvGuests;

        private Panel pnlEditor;
        private Label lbEditorTitle;
        private Label lbFullNameTitle;
        private TextBox tbFullName;
        private Label lbEmailTitle;
        private TextBox tbEmail;
        private Label lbIdCardTitle;
        private TextBox tbIdCard;
        private Label lbAddressTitle;
        private TextBox tbAddress;
        private Label lbCategoryTitle;
        private ComboBox cbCategory;
        private Label lbNotesTitle;
        private TextBox tbNotes;
        private Button btnSaveGuest;
        private DataGridViewTextBoxColumn colGuestId;
        private DataGridViewTextBoxColumn colFirstName;
        private DataGridViewTextBoxColumn colLastName;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colIdCardNumber;
        private DataGridViewTextBoxColumn colBirthdate;
        private DataGridViewTextBoxColumn colCountry;
        private DataGridViewTextBoxColumn colZip;
        private DataGridViewTextBoxColumn colCity;
        private DataGridViewTextBoxColumn colStreet;
        private DataGridViewTextBoxColumn colCarPlate;
        private DataGridViewTextBoxColumn colTotalNights;
        private DataGridViewTextBoxColumn colLoyalty;
        private TextBox tbZip;
        private TextBox tbStreet;
        private TextBox tbCity;
        private TextBox tbLname;
        private TextBox tbFname;
        private Label lbBirthdateTitle;
        private DateTimePicker dtpBirthdate;
        private Label lbCountryTitle;
        private TextBox tbCountry;
    }
}