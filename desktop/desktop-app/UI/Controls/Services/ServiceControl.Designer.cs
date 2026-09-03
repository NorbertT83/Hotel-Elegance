 namespace Hotel_erp_Winforms_App.UI.Controls
{
    partial class ProductContol
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            pnlRbHolder = new Panel();
            rbOrderBy = new RadioButton();
            rbOrderByDesc = new RadioButton();
            chkShowHistory = new CheckBox();
            lbRoomNumber = new Label();
            cbRoomNumbers = new ComboBox();
            btnSearch = new Button();
            cbTypeFilter = new ComboBox();
            txtSearch = new TextBox();
            btnDeleteService = new Button();
            lbTypeFilter = new Label();
            btnUpdateService = new Button();
            lbActiveServices = new Label();
            lbTotalServices = new Label();
            lbStats = new Label();
            lbActions = new Label();
            btnNewService = new Button();
            lbFilter = new Label();
            lbSearch = new Label();
            lbHistory = new Label();
            lbStatusFilter = new Label();
            rbStatusAll = new RadioButton();
            rbStatusActive = new RadioButton();
            rbStatusInactive = new RadioButton();
            lbUtility = new Label();
            btnRefresh = new Button();
            btnResetFilters = new Button();
            pnlGrid = new Panel();
            dgvServices = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colRoomNumber = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colRequestDate = new DataGridViewTextBoxColumn();
            colNameHu = new DataGridViewTextBoxColumn();
            colTypeHu = new DataGridViewTextBoxColumn();
            colDescHu = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colNameEn = new DataGridViewTextBoxColumn();
            colTypeEn = new DataGridViewTextBoxColumn();
            colDescEn = new DataGridViewTextBoxColumn();
            pnlEditor = new Panel();
            pnlSideBottom = new Panel();
            btnSaveService = new Button();
            chkIsActive = new CheckBox();
            tabControlLang = new TabControl();
            tabHun = new TabPage();
            tbDescHu = new TextBox();
            tbNameHu = new TextBox();
            cbTypeHu = new ComboBox();
            lbDescHu = new Label();
            lbNameHu = new Label();
            lbTypeHu = new Label();
            tabEn = new TabPage();
            tbDescEn = new TextBox();
            tbNameEn = new TextBox();
            cbTypeEn = new ComboBox();
            lbDescEn = new Label();
            lbNameEn = new Label();
            lbTypeEn = new Label();
            numPrice = new NumericUpDown();
            lbServiceDetails = new Label();
            lbPrice = new Label();
            pnlStatusEditor = new Panel();
            pnlStatusBottom = new Panel();
            btnUpdateStatus = new Button();
            cbNewStatus = new ComboBox();
            lbNewStatusTitle = new Label();
            lbCurrentStatusValue = new Label();
            lbCurrentStatusTitle = new Label();
            lbRoomNumberValue = new Label();
            lbRoomNumberTitle = new Label();
            lbServiceNameValue = new Label();
            lbServiceNameTitle = new Label();
            lbStatusEditorHeader = new Label();
            pnlNewServiceBooking = new Panel();
            pnlBookingBottom = new Panel();
            btnAddBooking = new Button();
            lbTotalPriceValue = new Label();
            lbTotalPriceTitle = new Label();
            numQuantity = new NumericUpDown();
            lbQuantityTitle = new Label();
            cbSelectService = new ComboBox();
            lbSelectServiceTitle = new Label();
            cbSelectRoom = new ComboBox();
            lbSelectRoomTitle = new Label();
            lbBookingHeader = new Label();
            btnNewServiceClear = new Button();
            pnlDeleteEditor = new Panel();
            pnlDeleteBottom = new Panel();
            btnDeleteServiceBooking = new Button();
            lbDeleteReqDateValue = new Label();
            lbDeleteReqDateTitle = new Label();
            lbDeletePriceValue = new Label();
            lbDeletePriceTitle = new Label();
            lbDeleteQuantityValue = new Label();
            lbDeleteQuantityTitle = new Label();
            lbDeleteCurrentStatusValue = new Label();
            lbDeleteCurrentStatusTitle = new Label();
            lbDeleteRoomNumberValue = new Label();
            lbDeleteRoomNumberTitle = new Label();
            lbDeleteServiceNameValue = new Label();
            lbDeleteServiceNameTitle = new Label();
            lbDeleteEditorHeader = new Label();
            pnlTop.SuspendLayout();
            pnlRbHolder.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            pnlEditor.SuspendLayout();
            pnlSideBottom.SuspendLayout();
            tabControlLang.SuspendLayout();
            tabHun.SuspendLayout();
            tabEn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            pnlStatusEditor.SuspendLayout();
            pnlStatusBottom.SuspendLayout();
            pnlNewServiceBooking.SuspendLayout();
            pnlBookingBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            pnlDeleteEditor.SuspendLayout();
            pnlDeleteBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTop.BackColor = Color.FromArgb(245, 245, 248);
            pnlTop.BorderStyle = BorderStyle.FixedSingle;
            pnlTop.Controls.Add(pnlRbHolder);
            pnlTop.Controls.Add(chkShowHistory);
            pnlTop.Controls.Add(lbRoomNumber);
            pnlTop.Controls.Add(cbRoomNumbers);
            pnlTop.Controls.Add(btnSearch);
            pnlTop.Controls.Add(cbTypeFilter);
            pnlTop.Controls.Add(txtSearch);
            pnlTop.Controls.Add(btnDeleteService);
            pnlTop.Controls.Add(lbTypeFilter);
            pnlTop.Controls.Add(btnUpdateService);
            pnlTop.Controls.Add(lbActiveServices);
            pnlTop.Controls.Add(lbTotalServices);
            pnlTop.Controls.Add(lbStats);
            pnlTop.Controls.Add(lbActions);
            pnlTop.Controls.Add(btnNewService);
            pnlTop.Controls.Add(lbFilter);
            pnlTop.Controls.Add(lbSearch);
            pnlTop.Controls.Add(lbHistory);
            pnlTop.Controls.Add(lbStatusFilter);
            pnlTop.Controls.Add(rbStatusAll);
            pnlTop.Controls.Add(rbStatusActive);
            pnlTop.Controls.Add(rbStatusInactive);
            pnlTop.Controls.Add(lbUtility);
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Controls.Add(btnResetFilters);
            pnlTop.Location = new Point(10, 10);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1350, 110);
            pnlTop.TabIndex = 0;
            // 
            // pnlRbHolder
            // 
            pnlRbHolder.Controls.Add(rbOrderBy);
            pnlRbHolder.Controls.Add(rbOrderByDesc);
            pnlRbHolder.Location = new Point(357, 57);
            pnlRbHolder.Name = "pnlRbHolder";
            pnlRbHolder.Size = new Size(174, 42);
            pnlRbHolder.TabIndex = 14;
            pnlRbHolder.Visible = false;
            // 
            // rbOrderBy
            // 
            rbOrderBy.Anchor = AnchorStyles.Left;
            rbOrderBy.AutoSize = true;
            rbOrderBy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            rbOrderBy.Location = new Point(0, 0);
            rbOrderBy.Name = "rbOrderBy";
            rbOrderBy.Size = new Size(159, 23);
            rbOrderBy.TabIndex = 12;
            rbOrderBy.TabStop = true;
            rbOrderBy.Text = "Order by ascending";
            rbOrderBy.UseVisualStyleBackColor = true;
            rbOrderBy.CheckedChanged += rbOrderBy_CheckedChanged;
            // 
            // rbOrderByDesc
            // 
            rbOrderByDesc.AutoSize = true;
            rbOrderByDesc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            rbOrderByDesc.Location = new Point(0, 21);
            rbOrderByDesc.Name = "rbOrderByDesc";
            rbOrderByDesc.Size = new Size(168, 23);
            rbOrderByDesc.TabIndex = 13;
            rbOrderByDesc.TabStop = true;
            rbOrderByDesc.Text = "Order by descending";
            rbOrderByDesc.UseVisualStyleBackColor = true;
            rbOrderByDesc.Click += rbOrderBy_CheckedChanged;
            // 
            // chkShowHistory
            // 
            chkShowHistory.AutoSize = true;
            chkShowHistory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkShowHistory.Location = new Point(357, 36);
            chkShowHistory.Name = "chkShowHistory";
            chkShowHistory.Size = new Size(115, 23);
            chkShowHistory.TabIndex = 11;
            chkShowHistory.Text = "Show history";
            chkShowHistory.UseVisualStyleBackColor = true;
            chkShowHistory.Visible = false;
            chkShowHistory.CheckedChanged += chkShowHistory_CheckedChanged;
            // 
            // lbRoomNumber
            // 
            lbRoomNumber.AutoSize = true;
            lbRoomNumber.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbRoomNumber.Location = new Point(15, 48);
            lbRoomNumber.Name = "lbRoomNumber";
            lbRoomNumber.Size = new Size(110, 19);
            lbRoomNumber.TabIndex = 10;
            lbRoomNumber.Text = "Room number:";
            lbRoomNumber.Visible = false;
            // 
            // cbRoomNumbers
            // 
            cbRoomNumbers.FormattingEnabled = true;
            cbRoomNumbers.Location = new Point(130, 45);
            cbRoomNumbers.MaxLength = 3;
            cbRoomNumbers.Name = "cbRoomNumbers";
            cbRoomNumbers.Size = new Size(90, 25);
            cbRoomNumbers.TabIndex = 9;
            cbRoomNumbers.Visible = false;
            cbRoomNumbers.KeyPress += cbRoomNumbers_KeyPress;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ButtonFace;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.Location = new Point(435, 42);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(85, 33);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // cbTypeFilter
            // 
            cbTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTypeFilter.Font = new Font("Segoe UI", 10F);
            cbTypeFilter.FormattingEnabled = true;
            cbTypeFilter.Items.AddRange(new object[] { "All", "Wellness", "Extras", "Logistics" });
            cbTypeFilter.Location = new Point(295, 45);
            cbTypeFilter.Name = "cbTypeFilter";
            cbTypeFilter.Size = new Size(130, 25);
            cbTypeFilter.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(80, 45);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(150, 25);
            txtSearch.TabIndex = 1;
            // 
            // btnDeleteService
            // 
            btnDeleteService.BackColor = SystemColors.ButtonFace;
            btnDeleteService.FlatStyle = FlatStyle.Flat;
            btnDeleteService.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDeleteService.ForeColor = Color.DarkRed;
            btnDeleteService.Location = new Point(940, 38);
            btnDeleteService.Name = "btnDeleteService";
            btnDeleteService.Size = new Size(100, 50);
            btnDeleteService.TabIndex = 0;
            btnDeleteService.Text = "Delete";
            btnDeleteService.UseVisualStyleBackColor = false;
            btnDeleteService.Click += btnDeleteService_Click;
            // 
            // lbTypeFilter
            // 
            lbTypeFilter.AutoSize = true;
            lbTypeFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbTypeFilter.Location = new Point(245, 48);
            lbTypeFilter.Name = "lbTypeFilter";
            lbTypeFilter.Size = new Size(45, 19);
            lbTypeFilter.TabIndex = 0;
            lbTypeFilter.Text = "Type:";
            // 
            // btnUpdateService
            // 
            btnUpdateService.BackColor = SystemColors.ButtonFace;
            btnUpdateService.FlatStyle = FlatStyle.Flat;
            btnUpdateService.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdateService.Location = new Point(810, 38);
            btnUpdateService.Name = "btnUpdateService";
            btnUpdateService.Size = new Size(120, 50);
            btnUpdateService.TabIndex = 0;
            btnUpdateService.Text = "Update";
            btnUpdateService.UseVisualStyleBackColor = false;
            btnUpdateService.Click += btnUpdateService_Click;
            // 
            // lbActiveServices
            // 
            lbActiveServices.AutoSize = true;
            lbActiveServices.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbActiveServices.ForeColor = Color.Green;
            lbActiveServices.Location = new Point(1210, 65);
            lbActiveServices.Name = "lbActiveServices";
            lbActiveServices.Size = new Size(67, 19);
            lbActiveServices.TabIndex = 0;
            lbActiveServices.Text = "Active: 0";
            // 
            // lbTotalServices
            // 
            lbTotalServices.AutoSize = true;
            lbTotalServices.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbTotalServices.ForeColor = Color.Black;
            lbTotalServices.Location = new Point(1210, 38);
            lbTotalServices.Name = "lbTotalServices";
            lbTotalServices.Size = new Size(116, 19);
            lbTotalServices.TabIndex = 0;
            lbTotalServices.Text = "Total services: 0";
            // 
            // lbStats
            // 
            lbStats.AutoSize = true;
            lbStats.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbStats.ForeColor = Color.DimGray;
            lbStats.Location = new Point(1210, 12);
            lbStats.Name = "lbStats";
            lbStats.Size = new Size(82, 19);
            lbStats.TabIndex = 0;
            lbStats.Text = "STATISTICS";
            // 
            // lbActions
            // 
            lbActions.AutoSize = true;
            lbActions.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbActions.ForeColor = Color.DimGray;
            lbActions.Location = new Point(680, 12);
            lbActions.Name = "lbActions";
            lbActions.Size = new Size(70, 19);
            lbActions.TabIndex = 0;
            lbActions.Text = "ACTIONS";
            // 
            // btnNewService
            // 
            btnNewService.BackColor = SystemColors.ButtonFace;
            btnNewService.FlatStyle = FlatStyle.Flat;
            btnNewService.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNewService.Location = new Point(680, 38);
            btnNewService.Name = "btnNewService";
            btnNewService.Size = new Size(120, 50);
            btnNewService.TabIndex = 0;
            btnNewService.Text = "+ New";
            btnNewService.UseVisualStyleBackColor = false;
            btnNewService.Click += btnNewService_Click;
            // 
            // lbFilter
            // 
            lbFilter.AutoSize = true;
            lbFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbFilter.ForeColor = Color.DimGray;
            lbFilter.Location = new Point(15, 12);
            lbFilter.Name = "lbFilter";
            lbFilter.Size = new Size(50, 19);
            lbFilter.TabIndex = 0;
            lbFilter.Text = "FILTER";
            // 
            // lbSearch
            // 
            lbSearch.AutoSize = true;
            lbSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbSearch.Location = new Point(15, 48);
            lbSearch.Name = "lbSearch";
            lbSearch.Size = new Size(58, 19);
            lbSearch.TabIndex = 0;
            lbSearch.Text = "Search:";
            // 
            // lbHistory
            // 
            lbHistory.AutoSize = true;
            lbHistory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbHistory.ForeColor = Color.DimGray;
            lbHistory.Location = new Point(357, 12);
            lbHistory.Name = "lbHistory";
            lbHistory.Size = new Size(68, 19);
            lbHistory.TabIndex = 0;
            lbHistory.Text = "HISTORY";
            lbHistory.Visible = false;
            // 
            // lbStatusFilter
            // 
            lbStatusFilter.AutoSize = true;
            lbStatusFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbStatusFilter.ForeColor = Color.DimGray;
            lbStatusFilter.Location = new Point(560, 12);
            lbStatusFilter.Name = "lbStatusFilter";
            lbStatusFilter.Size = new Size(59, 19);
            lbStatusFilter.TabIndex = 0;
            lbStatusFilter.Text = "STATUS";
            // 
            // rbStatusAll
            // 
            rbStatusAll.AutoSize = true;
            rbStatusAll.Checked = true;
            rbStatusAll.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            rbStatusAll.Location = new Point(560, 36);
            rbStatusAll.Name = "rbStatusAll";
            rbStatusAll.Size = new Size(43, 21);
            rbStatusAll.TabIndex = 4;
            rbStatusAll.TabStop = true;
            rbStatusAll.Text = "All";
            rbStatusAll.UseVisualStyleBackColor = true;
            rbStatusAll.CheckedChanged += rbStatusAll_CheckedChanged;
            // 
            // rbStatusActive
            // 
            rbStatusActive.AutoSize = true;
            rbStatusActive.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            rbStatusActive.Location = new Point(560, 57);
            rbStatusActive.Name = "rbStatusActive";
            rbStatusActive.Size = new Size(83, 21);
            rbStatusActive.TabIndex = 5;
            rbStatusActive.Text = "Bookings";
            rbStatusActive.UseVisualStyleBackColor = true;
            rbStatusActive.CheckedChanged += rbStatusActive_CheckedChanged;
            // 
            // rbStatusInactive
            // 
            rbStatusInactive.AutoSize = true;
            rbStatusInactive.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            rbStatusInactive.Location = new Point(560, 78);
            rbStatusInactive.Name = "rbStatusInactive";
            rbStatusInactive.Size = new Size(74, 21);
            rbStatusInactive.TabIndex = 6;
            rbStatusInactive.Text = "Inactive";
            rbStatusInactive.UseVisualStyleBackColor = true;
            rbStatusInactive.CheckedChanged += rbStatusInactive_CheckedChanged;
            // 
            // lbUtility
            // 
            lbUtility.AutoSize = true;
            lbUtility.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbUtility.ForeColor = Color.DimGray;
            lbUtility.Location = new Point(1080, 12);
            lbUtility.Name = "lbUtility";
            lbUtility.Size = new Size(67, 19);
            lbUtility.TabIndex = 0;
            lbUtility.Text = "REFRESH";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ButtonFace;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.Location = new Point(1080, 38);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 25);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Reload";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnResetFilters
            // 
            btnResetFilters.BackColor = SystemColors.ButtonFace;
            btnResetFilters.FlatStyle = FlatStyle.Flat;
            btnResetFilters.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnResetFilters.Location = new Point(1080, 66);
            btnResetFilters.Name = "btnResetFilters";
            btnResetFilters.Size = new Size(100, 25);
            btnResetFilters.TabIndex = 8;
            btnResetFilters.Text = "Reset Filters";
            btnResetFilters.UseVisualStyleBackColor = false;
            btnResetFilters.Click += btnResetFilters_Click;
            // 
            // pnlGrid
            // 
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrid.BackColor = Color.White;
            pnlGrid.Controls.Add(dgvServices);
            pnlGrid.Location = new Point(10, 130);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(1350, 490);
            pnlGrid.TabIndex = 1;
            // 
            // dgvServices
            // 
            dgvServices.AllowUserToAddRows = false;
            dgvServices.AllowUserToDeleteRows = false;
            dgvServices.AllowUserToResizeColumns = false;
            dgvServices.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 248, 253);
            dgvServices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvServices.BackgroundColor = Color.White;
            dgvServices.BorderStyle = BorderStyle.None;
            dgvServices.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(24, 60, 142);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(24, 60, 142);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvServices.ColumnHeadersHeight = 40;
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvServices.Columns.AddRange(new DataGridViewColumn[] { colId, colRoomNumber, colStatus, colRequestDate, colNameHu, colTypeHu, colDescHu, colQuantity, colPrice, colNameEn, colTypeEn, colDescEn });
            dgvServices.Dock = DockStyle.Fill;
            dgvServices.EnableHeadersVisualStyles = false;
            dgvServices.GridColor = SystemColors.ControlLight;
            dgvServices.Location = new Point(0, 0);
            dgvServices.MultiSelect = false;
            dgvServices.Name = "dgvServices";
            dgvServices.ReadOnly = true;
            dgvServices.RowHeadersVisible = false;
            dgvServices.RowTemplate.Height = 35;
            dgvServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServices.Size = new Size(1350, 490);
            dgvServices.TabIndex = 0;
            dgvServices.CellClick += dgvServices_CellClick;
            // 
            // colId
            // 
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            colId.Width = 50;
            // 
            // colRoomNumber
            // 
            colRoomNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoomNumber.DataPropertyName = "RoomNumber";
            colRoomNumber.FillWeight = 50F;
            colRoomNumber.HeaderText = "Room #";
            colRoomNumber.Name = "colRoomNumber";
            colRoomNumber.ReadOnly = true;
            colRoomNumber.Visible = false;
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colStatus.DataPropertyName = "CurrentServiceStatus";
            colStatus.FillWeight = 70F;
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Visible = false;
            // 
            // colRequestDate
            // 
            colRequestDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRequestDate.DataPropertyName = "RequestedAt";
            colRequestDate.FillWeight = 90F;
            colRequestDate.HeaderText = "Requested";
            colRequestDate.Name = "colRequestDate";
            colRequestDate.ReadOnly = true;
            colRequestDate.Visible = false;
            // 
            // colNameHu
            // 
            colNameHu.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNameHu.DataPropertyName = "NameHu";
            colNameHu.FillWeight = 20F;
            colNameHu.HeaderText = "Name (HU)";
            colNameHu.Name = "colNameHu";
            colNameHu.ReadOnly = true;
            // 
            // colTypeHu
            // 
            colTypeHu.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTypeHu.DataPropertyName = "SelectedServiceTypeHu";
            colTypeHu.FillWeight = 12F;
            colTypeHu.HeaderText = "Type (HU)";
            colTypeHu.Name = "colTypeHu";
            colTypeHu.ReadOnly = true;
            // 
            // colDescHu
            // 
            colDescHu.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescHu.DataPropertyName = "DescriptionHu";
            colDescHu.FillWeight = 26F;
            colDescHu.HeaderText = "Description (HU)";
            colDescHu.Name = "colDescHu";
            colDescHu.ReadOnly = true;
            // 
            // colQuantity
            // 
            colQuantity.DataPropertyName = "Quantity";
            colQuantity.HeaderText = "Quantity";
            colQuantity.Name = "colQuantity";
            colQuantity.ReadOnly = true;
            colQuantity.Visible = false;
            // 
            // colPrice
            // 
            colPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPrice.DataPropertyName = "Price";
            dataGridViewCellStyle3.NullValue = null;
            colPrice.DefaultCellStyle = dataGridViewCellStyle3;
            colPrice.FillWeight = 10F;
            colPrice.HeaderText = "Price (HUF)";
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // colNameEn
            // 
            colNameEn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNameEn.DataPropertyName = "NameEn";
            colNameEn.FillWeight = 20F;
            colNameEn.HeaderText = "Name (EN)";
            colNameEn.Name = "colNameEn";
            colNameEn.ReadOnly = true;
            // 
            // colTypeEn
            // 
            colTypeEn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTypeEn.DataPropertyName = "SelectedServiceTypeEn";
            colTypeEn.FillWeight = 12F;
            colTypeEn.HeaderText = "Type (EN)";
            colTypeEn.Name = "colTypeEn";
            colTypeEn.ReadOnly = true;
            // 
            // colDescEn
            // 
            colDescEn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescEn.DataPropertyName = "DescriptionEn";
            colDescEn.FillWeight = 26F;
            colDescEn.HeaderText = "Description (EN)";
            colDescEn.Name = "colDescEn";
            colDescEn.ReadOnly = true;
            // 
            // pnlEditor
            // 
            pnlEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlEditor.BorderStyle = BorderStyle.FixedSingle;
            pnlEditor.Controls.Add(pnlSideBottom);
            pnlEditor.Controls.Add(chkIsActive);
            pnlEditor.Controls.Add(tabControlLang);
            pnlEditor.Controls.Add(numPrice);
            pnlEditor.Controls.Add(lbServiceDetails);
            pnlEditor.Controls.Add(lbPrice);
            pnlEditor.Location = new Point(1370, 10);
            pnlEditor.Margin = new Padding(0);
            pnlEditor.Name = "pnlEditor";
            pnlEditor.Size = new Size(355, 610);
            pnlEditor.TabIndex = 2;
            // 
            // pnlSideBottom
            // 
            pnlSideBottom.Controls.Add(btnSaveService);
            pnlSideBottom.Dock = DockStyle.Bottom;
            pnlSideBottom.Location = new Point(0, 428);
            pnlSideBottom.Name = "pnlSideBottom";
            pnlSideBottom.Padding = new Padding(10, 65, 10, 65);
            pnlSideBottom.Size = new Size(353, 180);
            pnlSideBottom.TabIndex = 5;
            // 
            // btnSaveService
            // 
            btnSaveService.BackColor = SystemColors.ButtonFace;
            btnSaveService.Dock = DockStyle.Fill;
            btnSaveService.FlatStyle = FlatStyle.Flat;
            btnSaveService.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveService.ForeColor = Color.DarkGreen;
            btnSaveService.Location = new Point(10, 65);
            btnSaveService.Margin = new Padding(10);
            btnSaveService.Name = "btnSaveService";
            btnSaveService.Size = new Size(333, 50);
            btnSaveService.TabIndex = 0;
            btnSaveService.Text = "Save Service";
            btnSaveService.UseVisualStyleBackColor = false;
            btnSaveService.Click += btnSaveService_Click;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.Checked = true;
            chkIsActive.CheckState = CheckState.Checked;
            chkIsActive.Enabled = false;
            chkIsActive.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkIsActive.Location = new Point(250, 44);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(70, 23);
            chkIsActive.TabIndex = 4;
            chkIsActive.Text = "Active";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // tabControlLang
            // 
            tabControlLang.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlLang.Controls.Add(tabHun);
            tabControlLang.Controls.Add(tabEn);
            tabControlLang.Location = new Point(10, 80);
            tabControlLang.Name = "tabControlLang";
            tabControlLang.SelectedIndex = 0;
            tabControlLang.Size = new Size(333, 515);
            tabControlLang.TabIndex = 3;
            // 
            // tabHun
            // 
            tabHun.Controls.Add(tbDescHu);
            tabHun.Controls.Add(tbNameHu);
            tabHun.Controls.Add(cbTypeHu);
            tabHun.Controls.Add(lbDescHu);
            tabHun.Controls.Add(lbNameHu);
            tabHun.Controls.Add(lbTypeHu);
            tabHun.Location = new Point(4, 26);
            tabHun.Name = "tabHun";
            tabHun.Padding = new Padding(3);
            tabHun.Size = new Size(325, 485);
            tabHun.TabIndex = 0;
            tabHun.Text = "Hungarian (HU)";
            tabHun.UseVisualStyleBackColor = true;
            // 
            // tbDescHu
            // 
            tbDescHu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbDescHu.Location = new Point(10, 145);
            tbDescHu.Multiline = true;
            tbDescHu.Name = "tbDescHu";
            tbDescHu.ScrollBars = ScrollBars.Vertical;
            tbDescHu.Size = new Size(307, 330);
            tbDescHu.TabIndex = 2;
            // 
            // tbNameHu
            // 
            tbNameHu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbNameHu.Location = new Point(10, 90);
            tbNameHu.Name = "tbNameHu";
            tbNameHu.Size = new Size(307, 25);
            tbNameHu.TabIndex = 2;
            tbNameHu.KeyPress += tbNameHu_KeyPress;
            // 
            // cbTypeHu
            // 
            cbTypeHu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbTypeHu.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTypeHu.FormattingEnabled = true;
            cbTypeHu.Items.AddRange(new object[] { "Not set", "Wellness", "Extrák", "Logisztika" });
            cbTypeHu.Location = new Point(10, 35);
            cbTypeHu.Name = "cbTypeHu";
            cbTypeHu.Size = new Size(307, 25);
            cbTypeHu.TabIndex = 1;
            cbTypeHu.SelectedIndexChanged += cbTypeHu_SelectedIndexChanged;
            // 
            // lbDescHu
            // 
            lbDescHu.AutoSize = true;
            lbDescHu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbDescHu.Location = new Point(10, 125);
            lbDescHu.Name = "lbDescHu";
            lbDescHu.Size = new Size(124, 19);
            lbDescHu.TabIndex = 0;
            lbDescHu.Text = "Description (HU):";
            // 
            // lbNameHu
            // 
            lbNameHu.AutoSize = true;
            lbNameHu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbNameHu.Location = new Point(10, 70);
            lbNameHu.Name = "lbNameHu";
            lbNameHu.Size = new Size(88, 19);
            lbNameHu.TabIndex = 0;
            lbNameHu.Text = "Name (HU):";
            // 
            // lbTypeHu
            // 
            lbTypeHu.AutoSize = true;
            lbTypeHu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbTypeHu.Location = new Point(10, 15);
            lbTypeHu.Name = "lbTypeHu";
            lbTypeHu.Size = new Size(80, 19);
            lbTypeHu.TabIndex = 0;
            lbTypeHu.Text = "Type (HU):";
            // 
            // tabEn
            // 
            tabEn.Controls.Add(tbDescEn);
            tabEn.Controls.Add(tbNameEn);
            tabEn.Controls.Add(cbTypeEn);
            tabEn.Controls.Add(lbDescEn);
            tabEn.Controls.Add(lbNameEn);
            tabEn.Controls.Add(lbTypeEn);
            tabEn.Location = new Point(4, 24);
            tabEn.Name = "tabEn";
            tabEn.Padding = new Padding(3);
            tabEn.Size = new Size(325, 487);
            tabEn.TabIndex = 1;
            tabEn.Text = "English (EN)";
            tabEn.UseVisualStyleBackColor = true;
            // 
            // tbDescEn
            // 
            tbDescEn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbDescEn.Location = new Point(10, 145);
            tbDescEn.Multiline = true;
            tbDescEn.Name = "tbDescEn";
            tbDescEn.ScrollBars = ScrollBars.Vertical;
            tbDescEn.Size = new Size(307, 326);
            tbDescEn.TabIndex = 7;
            // 
            // tbNameEn
            // 
            tbNameEn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbNameEn.Location = new Point(10, 90);
            tbNameEn.Name = "tbNameEn";
            tbNameEn.Size = new Size(307, 25);
            tbNameEn.TabIndex = 8;
            tbNameEn.KeyPress += tbNameEn_KeyPress;
            // 
            // cbTypeEn
            // 
            cbTypeEn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbTypeEn.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTypeEn.FormattingEnabled = true;
            cbTypeEn.Items.AddRange(new object[] { "Not set", "Wellness", "Extras", "Logistics" });
            cbTypeEn.Location = new Point(10, 35);
            cbTypeEn.Name = "cbTypeEn";
            cbTypeEn.Size = new Size(307, 25);
            cbTypeEn.TabIndex = 6;
            cbTypeEn.SelectedIndexChanged += cbTypeEn_SelectedIndexChanged;
            // 
            // lbDescEn
            // 
            lbDescEn.AutoSize = true;
            lbDescEn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbDescEn.Location = new Point(10, 125);
            lbDescEn.Name = "lbDescEn";
            lbDescEn.Size = new Size(121, 19);
            lbDescEn.TabIndex = 3;
            lbDescEn.Text = "Description (EN):";
            // 
            // lbNameEn
            // 
            lbNameEn.AutoSize = true;
            lbNameEn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbNameEn.Location = new Point(10, 70);
            lbNameEn.Name = "lbNameEn";
            lbNameEn.Size = new Size(85, 19);
            lbNameEn.TabIndex = 4;
            lbNameEn.Text = "Name (EN):";
            // 
            // lbTypeEn
            // 
            lbTypeEn.AutoSize = true;
            lbTypeEn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbTypeEn.Location = new Point(10, 15);
            lbTypeEn.Name = "lbTypeEn";
            lbTypeEn.Size = new Size(77, 19);
            lbTypeEn.TabIndex = 5;
            lbTypeEn.Text = "Type (EN):";
            // 
            // numPrice
            // 
            numPrice.Location = new Point(105, 42);
            numPrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(130, 25);
            numPrice.TabIndex = 2;
            numPrice.TextAlign = HorizontalAlignment.Right;
            numPrice.ThousandsSeparator = true;
            // 
            // lbServiceDetails
            // 
            lbServiceDetails.AutoSize = true;
            lbServiceDetails.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbServiceDetails.ForeColor = Color.FromArgb(24, 60, 142);
            lbServiceDetails.Location = new Point(15, 12);
            lbServiceDetails.Name = "lbServiceDetails";
            lbServiceDetails.Size = new Size(130, 20);
            lbServiceDetails.TabIndex = 1;
            lbServiceDetails.Text = "SERVICE DETAILS";
            // 
            // lbPrice
            // 
            lbPrice.AutoSize = true;
            lbPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbPrice.Location = new Point(15, 45);
            lbPrice.Name = "lbPrice";
            lbPrice.Size = new Size(89, 19);
            lbPrice.TabIndex = 1;
            lbPrice.Text = "Price (HUF):";
            // 
            // pnlStatusEditor
            // 
            pnlStatusEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlStatusEditor.BorderStyle = BorderStyle.FixedSingle;
            pnlStatusEditor.Controls.Add(pnlStatusBottom);
            pnlStatusEditor.Controls.Add(cbNewStatus);
            pnlStatusEditor.Controls.Add(lbNewStatusTitle);
            pnlStatusEditor.Controls.Add(lbCurrentStatusValue);
            pnlStatusEditor.Controls.Add(lbCurrentStatusTitle);
            pnlStatusEditor.Controls.Add(lbRoomNumberValue);
            pnlStatusEditor.Controls.Add(lbRoomNumberTitle);
            pnlStatusEditor.Controls.Add(lbServiceNameValue);
            pnlStatusEditor.Controls.Add(lbServiceNameTitle);
            pnlStatusEditor.Controls.Add(lbStatusEditorHeader);
            pnlStatusEditor.Location = new Point(1371, 10);
            pnlStatusEditor.Margin = new Padding(0);
            pnlStatusEditor.Name = "pnlStatusEditor";
            pnlStatusEditor.Size = new Size(355, 610);
            pnlStatusEditor.TabIndex = 2;
            pnlStatusEditor.Visible = false;
            // 
            // pnlStatusBottom
            // 
            pnlStatusBottom.Controls.Add(btnUpdateStatus);
            pnlStatusBottom.Dock = DockStyle.Bottom;
            pnlStatusBottom.Location = new Point(0, 428);
            pnlStatusBottom.Name = "pnlStatusBottom";
            pnlStatusBottom.Padding = new Padding(15, 65, 15, 65);
            pnlStatusBottom.Size = new Size(353, 180);
            pnlStatusBottom.TabIndex = 2;
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.BackColor = Color.FromArgb(24, 60, 142);
            btnUpdateStatus.Dock = DockStyle.Fill;
            btnUpdateStatus.FlatAppearance.BorderSize = 0;
            btnUpdateStatus.FlatStyle = FlatStyle.Flat;
            btnUpdateStatus.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdateStatus.ForeColor = Color.White;
            btnUpdateStatus.Location = new Point(15, 65);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(323, 50);
            btnUpdateStatus.TabIndex = 0;
            btnUpdateStatus.Text = "UPDATE STATUS";
            btnUpdateStatus.UseVisualStyleBackColor = false;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            // 
            // cbNewStatus
            // 
            cbNewStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNewStatus.Enabled = false;
            cbNewStatus.Font = new Font("Segoe UI", 14F);
            cbNewStatus.FormattingEnabled = true;
            cbNewStatus.Items.AddRange(new object[] { "Created", "Deleted", "Pending", "Completed" });
            cbNewStatus.Location = new Point(15, 255);
            cbNewStatus.Name = "cbNewStatus";
            cbNewStatus.Size = new Size(323, 33);
            cbNewStatus.TabIndex = 1;
            // 
            // lbNewStatusTitle
            // 
            lbNewStatusTitle.AutoSize = true;
            lbNewStatusTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbNewStatusTitle.Location = new Point(15, 230);
            lbNewStatusTitle.Name = "lbNewStatusTitle";
            lbNewStatusTitle.Size = new Size(131, 19);
            lbNewStatusTitle.TabIndex = 3;
            lbNewStatusTitle.Text = "Select New Status:";
            // 
            // lbCurrentStatusValue
            // 
            lbCurrentStatusValue.AutoSize = true;
            lbCurrentStatusValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbCurrentStatusValue.ForeColor = Color.FromArgb(217, 83, 79);
            lbCurrentStatusValue.Location = new Point(15, 178);
            lbCurrentStatusValue.Name = "lbCurrentStatusValue";
            lbCurrentStatusValue.Size = new Size(122, 21);
            lbCurrentStatusValue.TabIndex = 4;
            lbCurrentStatusValue.Text = "NOT SELECTED";
            // 
            // lbCurrentStatusTitle
            // 
            lbCurrentStatusTitle.AutoSize = true;
            lbCurrentStatusTitle.Font = new Font("Segoe UI", 9F);
            lbCurrentStatusTitle.ForeColor = Color.Gray;
            lbCurrentStatusTitle.Location = new Point(15, 160);
            lbCurrentStatusTitle.Name = "lbCurrentStatusTitle";
            lbCurrentStatusTitle.Size = new Size(85, 15);
            lbCurrentStatusTitle.TabIndex = 5;
            lbCurrentStatusTitle.Text = "Current Status:";
            // 
            // lbRoomNumberValue
            // 
            lbRoomNumberValue.AutoSize = true;
            lbRoomNumberValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbRoomNumberValue.Location = new Point(15, 123);
            lbRoomNumberValue.Name = "lbRoomNumberValue";
            lbRoomNumberValue.Size = new Size(31, 20);
            lbRoomNumberValue.TabIndex = 6;
            lbRoomNumberValue.Text = "  -  ";
            // 
            // lbRoomNumberTitle
            // 
            lbRoomNumberTitle.AutoSize = true;
            lbRoomNumberTitle.Font = new Font("Segoe UI", 9F);
            lbRoomNumberTitle.ForeColor = Color.Gray;
            lbRoomNumberTitle.Location = new Point(15, 105);
            lbRoomNumberTitle.Name = "lbRoomNumberTitle";
            lbRoomNumberTitle.Size = new Size(89, 15);
            lbRoomNumberTitle.TabIndex = 7;
            lbRoomNumberTitle.Text = "Room Number:";
            // 
            // lbServiceNameValue
            // 
            lbServiceNameValue.AutoSize = true;
            lbServiceNameValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbServiceNameValue.Location = new Point(15, 68);
            lbServiceNameValue.Name = "lbServiceNameValue";
            lbServiceNameValue.Size = new Size(97, 20);
            lbServiceNameValue.TabIndex = 8;
            lbServiceNameValue.Text = "Not selected";
            // 
            // lbServiceNameTitle
            // 
            lbServiceNameTitle.AutoSize = true;
            lbServiceNameTitle.Font = new Font("Segoe UI", 9F);
            lbServiceNameTitle.ForeColor = Color.Gray;
            lbServiceNameTitle.Location = new Point(15, 50);
            lbServiceNameTitle.Name = "lbServiceNameTitle";
            lbServiceNameTitle.Size = new Size(82, 15);
            lbServiceNameTitle.TabIndex = 9;
            lbServiceNameTitle.Text = "Service Name:";
            // 
            // lbStatusEditorHeader
            // 
            lbStatusEditorHeader.AutoSize = true;
            lbStatusEditorHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbStatusEditorHeader.ForeColor = Color.FromArgb(24, 60, 142);
            lbStatusEditorHeader.Location = new Point(15, 15);
            lbStatusEditorHeader.Name = "lbStatusEditorHeader";
            lbStatusEditorHeader.Size = new Size(125, 20);
            lbStatusEditorHeader.TabIndex = 0;
            lbStatusEditorHeader.Text = "UPDATE STATUS";
            // 
            // pnlNewServiceBooking
            // 
            pnlNewServiceBooking.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlNewServiceBooking.BorderStyle = BorderStyle.FixedSingle;
            pnlNewServiceBooking.Controls.Add(pnlBookingBottom);
            pnlNewServiceBooking.Controls.Add(lbTotalPriceValue);
            pnlNewServiceBooking.Controls.Add(lbTotalPriceTitle);
            pnlNewServiceBooking.Controls.Add(numQuantity);
            pnlNewServiceBooking.Controls.Add(lbQuantityTitle);
            pnlNewServiceBooking.Controls.Add(cbSelectService);
            pnlNewServiceBooking.Controls.Add(lbSelectServiceTitle);
            pnlNewServiceBooking.Controls.Add(cbSelectRoom);
            pnlNewServiceBooking.Controls.Add(lbSelectRoomTitle);
            pnlNewServiceBooking.Controls.Add(lbBookingHeader);
            pnlNewServiceBooking.Controls.Add(btnNewServiceClear);
            pnlNewServiceBooking.Location = new Point(1372, 10);
            pnlNewServiceBooking.Margin = new Padding(0);
            pnlNewServiceBooking.Name = "pnlNewServiceBooking";
            pnlNewServiceBooking.Size = new Size(355, 610);
            pnlNewServiceBooking.TabIndex = 4;
            pnlNewServiceBooking.Visible = false;
            // 
            // pnlBookingBottom
            // 
            pnlBookingBottom.Controls.Add(btnAddBooking);
            pnlBookingBottom.Dock = DockStyle.Bottom;
            pnlBookingBottom.Location = new Point(0, 428);
            pnlBookingBottom.Name = "pnlBookingBottom";
            pnlBookingBottom.Padding = new Padding(15, 65, 15, 65);
            pnlBookingBottom.Size = new Size(353, 180);
            pnlBookingBottom.TabIndex = 4;
            // 
            // btnAddBooking
            // 
            btnAddBooking.BackColor = Color.FromArgb(24, 60, 142);
            btnAddBooking.Dock = DockStyle.Fill;
            btnAddBooking.FlatAppearance.BorderSize = 0;
            btnAddBooking.FlatStyle = FlatStyle.Flat;
            btnAddBooking.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAddBooking.ForeColor = Color.White;
            btnAddBooking.Location = new Point(15, 65);
            btnAddBooking.Name = "btnAddBooking";
            btnAddBooking.Size = new Size(323, 50);
            btnAddBooking.TabIndex = 0;
            btnAddBooking.Text = "ADD SERVICE";
            btnAddBooking.UseVisualStyleBackColor = false;
            btnAddBooking.Click += btnAddBooking_Click;
            // 
            // lbTotalPriceValue
            // 
            lbTotalPriceValue.AutoSize = true;
            lbTotalPriceValue.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lbTotalPriceValue.ForeColor = Color.FromArgb(24, 60, 142);
            lbTotalPriceValue.Location = new Point(15, 275);
            lbTotalPriceValue.Name = "lbTotalPriceValue";
            lbTotalPriceValue.Size = new Size(67, 25);
            lbTotalPriceValue.TabIndex = 5;
            lbTotalPriceValue.Text = "0 HUF";
            // 
            // lbTotalPriceTitle
            // 
            lbTotalPriceTitle.AutoSize = true;
            lbTotalPriceTitle.Font = new Font("Segoe UI", 9F);
            lbTotalPriceTitle.ForeColor = Color.Gray;
            lbTotalPriceTitle.Location = new Point(15, 255);
            lbTotalPriceTitle.Name = "lbTotalPriceTitle";
            lbTotalPriceTitle.Size = new Size(64, 15);
            lbTotalPriceTitle.TabIndex = 6;
            lbTotalPriceTitle.Text = "Total Price:";
            // 
            // numQuantity
            // 
            numQuantity.Font = new Font("Segoe UI", 10F);
            numQuantity.Location = new Point(15, 210);
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(130, 25);
            numQuantity.TabIndex = 3;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.ValueChanged += numQuantity_ValueChanged;
            // 
            // lbQuantityTitle
            // 
            lbQuantityTitle.AutoSize = true;
            lbQuantityTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbQuantityTitle.Location = new Point(15, 185);
            lbQuantityTitle.Name = "lbQuantityTitle";
            lbQuantityTitle.Size = new Size(70, 19);
            lbQuantityTitle.TabIndex = 7;
            lbQuantityTitle.Text = "Quantity:";
            // 
            // cbSelectService
            // 
            cbSelectService.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbSelectService.Font = new Font("Segoe UI", 10F);
            cbSelectService.FormattingEnabled = true;
            cbSelectService.Location = new Point(15, 145);
            cbSelectService.MaxLength = 50;
            cbSelectService.Name = "cbSelectService";
            cbSelectService.Size = new Size(323, 25);
            cbSelectService.TabIndex = 2;
            cbSelectService.SelectedIndexChanged += cbSelectService_SelectedIndexChanged;
            // 
            // lbSelectServiceTitle
            // 
            lbSelectServiceTitle.AutoSize = true;
            lbSelectServiceTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbSelectServiceTitle.Location = new Point(15, 120);
            lbSelectServiceTitle.Name = "lbSelectServiceTitle";
            lbSelectServiceTitle.Size = new Size(107, 19);
            lbSelectServiceTitle.TabIndex = 8;
            lbSelectServiceTitle.Text = "Select Service:";
            // 
            // cbSelectRoom
            // 
            cbSelectRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSelectRoom.Font = new Font("Segoe UI", 10F);
            cbSelectRoom.FormattingEnabled = true;
            cbSelectRoom.Location = new Point(15, 80);
            cbSelectRoom.Name = "cbSelectRoom";
            cbSelectRoom.Size = new Size(323, 25);
            cbSelectRoom.TabIndex = 1;
            // 
            // lbSelectRoomTitle
            // 
            lbSelectRoomTitle.AutoSize = true;
            lbSelectRoomTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbSelectRoomTitle.Location = new Point(15, 55);
            lbSelectRoomTitle.Name = "lbSelectRoomTitle";
            lbSelectRoomTitle.Size = new Size(113, 19);
            lbSelectRoomTitle.TabIndex = 9;
            lbSelectRoomTitle.Text = "Room Number:";
            // 
            // lbBookingHeader
            // 
            lbBookingHeader.AutoSize = true;
            lbBookingHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbBookingHeader.ForeColor = Color.FromArgb(24, 60, 142);
            lbBookingHeader.Location = new Point(15, 15);
            lbBookingHeader.Name = "lbBookingHeader";
            lbBookingHeader.Size = new Size(180, 20);
            lbBookingHeader.TabIndex = 0;
            lbBookingHeader.Text = "NEW SERVICE BOOKING";
            // 
            // btnNewServiceClear
            // 
            btnNewServiceClear.BackColor = SystemColors.ButtonFace;
            btnNewServiceClear.FlatStyle = FlatStyle.Flat;
            btnNewServiceClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNewServiceClear.Location = new Point(238, 209);
            btnNewServiceClear.Name = "btnNewServiceClear";
            btnNewServiceClear.Size = new Size(100, 25);
            btnNewServiceClear.TabIndex = 7;
            btnNewServiceClear.Text = "Clear";
            btnNewServiceClear.UseVisualStyleBackColor = false;
            btnNewServiceClear.Click += btnNewServiceClear_Click;
            // 
            // pnlDeleteEditor
            // 
            pnlDeleteEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlDeleteEditor.BorderStyle = BorderStyle.FixedSingle;
            pnlDeleteEditor.Controls.Add(pnlDeleteBottom);
            pnlDeleteEditor.Controls.Add(lbDeleteReqDateValue);
            pnlDeleteEditor.Controls.Add(lbDeleteReqDateTitle);
            pnlDeleteEditor.Controls.Add(lbDeletePriceValue);
            pnlDeleteEditor.Controls.Add(lbDeletePriceTitle);
            pnlDeleteEditor.Controls.Add(lbDeleteQuantityValue);
            pnlDeleteEditor.Controls.Add(lbDeleteQuantityTitle);
            pnlDeleteEditor.Controls.Add(lbDeleteCurrentStatusValue);
            pnlDeleteEditor.Controls.Add(lbDeleteCurrentStatusTitle);
            pnlDeleteEditor.Controls.Add(lbDeleteRoomNumberValue);
            pnlDeleteEditor.Controls.Add(lbDeleteRoomNumberTitle);
            pnlDeleteEditor.Controls.Add(lbDeleteServiceNameValue);
            pnlDeleteEditor.Controls.Add(lbDeleteServiceNameTitle);
            pnlDeleteEditor.Controls.Add(lbDeleteEditorHeader);
            pnlDeleteEditor.Location = new Point(1369, 10);
            pnlDeleteEditor.Margin = new Padding(0);
            pnlDeleteEditor.Name = "pnlDeleteEditor";
            pnlDeleteEditor.Size = new Size(355, 610);
            pnlDeleteEditor.TabIndex = 3;
            pnlDeleteEditor.Visible = false;
            // 
            // pnlDeleteBottom
            // 
            pnlDeleteBottom.Controls.Add(btnDeleteServiceBooking);
            pnlDeleteBottom.Dock = DockStyle.Bottom;
            pnlDeleteBottom.Location = new Point(0, 428);
            pnlDeleteBottom.Name = "pnlDeleteBottom";
            pnlDeleteBottom.Padding = new Padding(15, 65, 15, 65);
            pnlDeleteBottom.Size = new Size(353, 180);
            pnlDeleteBottom.TabIndex = 2;
            // 
            // btnDeleteServiceBooking
            // 
            btnDeleteServiceBooking.BackColor = Color.FromArgb(217, 83, 79);
            btnDeleteServiceBooking.Dock = DockStyle.Fill;
            btnDeleteServiceBooking.FlatAppearance.BorderSize = 0;
            btnDeleteServiceBooking.FlatStyle = FlatStyle.Flat;
            btnDeleteServiceBooking.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDeleteServiceBooking.ForeColor = Color.White;
            btnDeleteServiceBooking.Location = new Point(15, 65);
            btnDeleteServiceBooking.Name = "btnDeleteServiceBooking";
            btnDeleteServiceBooking.Size = new Size(323, 50);
            btnDeleteServiceBooking.TabIndex = 0;
            btnDeleteServiceBooking.Text = "DELETE BOOKING";
            btnDeleteServiceBooking.UseVisualStyleBackColor = false;
            btnDeleteServiceBooking.Click += btnDeleteServiceBooking_Click;
            // 
            // lbDeleteReqDateValue
            // 
            lbDeleteReqDateValue.AutoSize = true;
            lbDeleteReqDateValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbDeleteReqDateValue.Location = new Point(15, 318);
            lbDeleteReqDateValue.Name = "lbDeleteReqDateValue";
            lbDeleteReqDateValue.Size = new Size(31, 20);
            lbDeleteReqDateValue.TabIndex = 12;
            lbDeleteReqDateValue.Text = "  -  ";
            // 
            // lbDeleteReqDateTitle
            // 
            lbDeleteReqDateTitle.AutoSize = true;
            lbDeleteReqDateTitle.Font = new Font("Segoe UI", 9F);
            lbDeleteReqDateTitle.ForeColor = Color.Gray;
            lbDeleteReqDateTitle.Location = new Point(15, 300);
            lbDeleteReqDateTitle.Name = "lbDeleteReqDateTitle";
            lbDeleteReqDateTitle.Size = new Size(92, 15);
            lbDeleteReqDateTitle.TabIndex = 11;
            lbDeleteReqDateTitle.Text = "Requested Date:";
            // 
            // lbDeletePriceValue
            // 
            lbDeletePriceValue.AutoSize = true;
            lbDeletePriceValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbDeletePriceValue.Location = new Point(15, 218);
            lbDeletePriceValue.Name = "lbDeletePriceValue";
            lbDeletePriceValue.Size = new Size(31, 20);
            lbDeletePriceValue.TabIndex = 8;
            lbDeletePriceValue.Text = "  -  ";
            // 
            // lbDeletePriceTitle
            // 
            lbDeletePriceTitle.AutoSize = true;
            lbDeletePriceTitle.Font = new Font("Segoe UI", 9F);
            lbDeletePriceTitle.ForeColor = Color.Gray;
            lbDeletePriceTitle.Location = new Point(15, 200);
            lbDeletePriceTitle.Name = "lbDeletePriceTitle";
            lbDeletePriceTitle.Size = new Size(36, 15);
            lbDeletePriceTitle.TabIndex = 7;
            lbDeletePriceTitle.Text = "Price:";
            // 
            // lbDeleteQuantityValue
            // 
            lbDeleteQuantityValue.AutoSize = true;
            lbDeleteQuantityValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbDeleteQuantityValue.Location = new Point(15, 168);
            lbDeleteQuantityValue.Name = "lbDeleteQuantityValue";
            lbDeleteQuantityValue.Size = new Size(31, 20);
            lbDeleteQuantityValue.TabIndex = 6;
            lbDeleteQuantityValue.Text = "  -  ";
            // 
            // lbDeleteQuantityTitle
            // 
            lbDeleteQuantityTitle.AutoSize = true;
            lbDeleteQuantityTitle.Font = new Font("Segoe UI", 9F);
            lbDeleteQuantityTitle.ForeColor = Color.Gray;
            lbDeleteQuantityTitle.Location = new Point(15, 150);
            lbDeleteQuantityTitle.Name = "lbDeleteQuantityTitle";
            lbDeleteQuantityTitle.Size = new Size(56, 15);
            lbDeleteQuantityTitle.TabIndex = 5;
            lbDeleteQuantityTitle.Text = "Quantity:";
            // 
            // lbDeleteCurrentStatusValue
            // 
            lbDeleteCurrentStatusValue.AutoSize = true;
            lbDeleteCurrentStatusValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbDeleteCurrentStatusValue.ForeColor = Color.FromArgb(217, 83, 79);
            lbDeleteCurrentStatusValue.Location = new Point(15, 268);
            lbDeleteCurrentStatusValue.Name = "lbDeleteCurrentStatusValue";
            lbDeleteCurrentStatusValue.Size = new Size(113, 20);
            lbDeleteCurrentStatusValue.TabIndex = 10;
            lbDeleteCurrentStatusValue.Text = "NOT SELECTED";
            // 
            // lbDeleteCurrentStatusTitle
            // 
            lbDeleteCurrentStatusTitle.AutoSize = true;
            lbDeleteCurrentStatusTitle.Font = new Font("Segoe UI", 9F);
            lbDeleteCurrentStatusTitle.ForeColor = Color.Gray;
            lbDeleteCurrentStatusTitle.Location = new Point(15, 250);
            lbDeleteCurrentStatusTitle.Name = "lbDeleteCurrentStatusTitle";
            lbDeleteCurrentStatusTitle.Size = new Size(85, 15);
            lbDeleteCurrentStatusTitle.TabIndex = 9;
            lbDeleteCurrentStatusTitle.Text = "Current Status:";
            // 
            // lbDeleteRoomNumberValue
            // 
            lbDeleteRoomNumberValue.AutoSize = true;
            lbDeleteRoomNumberValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbDeleteRoomNumberValue.Location = new Point(15, 118);
            lbDeleteRoomNumberValue.Name = "lbDeleteRoomNumberValue";
            lbDeleteRoomNumberValue.Size = new Size(31, 20);
            lbDeleteRoomNumberValue.TabIndex = 4;
            lbDeleteRoomNumberValue.Text = "  -  ";
            // 
            // lbDeleteRoomNumberTitle
            // 
            lbDeleteRoomNumberTitle.AutoSize = true;
            lbDeleteRoomNumberTitle.Font = new Font("Segoe UI", 9F);
            lbDeleteRoomNumberTitle.ForeColor = Color.Gray;
            lbDeleteRoomNumberTitle.Location = new Point(15, 100);
            lbDeleteRoomNumberTitle.Name = "lbDeleteRoomNumberTitle";
            lbDeleteRoomNumberTitle.Size = new Size(89, 15);
            lbDeleteRoomNumberTitle.TabIndex = 3;
            lbDeleteRoomNumberTitle.Text = "Room Number:";
            // 
            // lbDeleteServiceNameValue
            // 
            lbDeleteServiceNameValue.AutoSize = true;
            lbDeleteServiceNameValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbDeleteServiceNameValue.Location = new Point(15, 68);
            lbDeleteServiceNameValue.Name = "lbDeleteServiceNameValue";
            lbDeleteServiceNameValue.Size = new Size(97, 20);
            lbDeleteServiceNameValue.TabIndex = 2;
            lbDeleteServiceNameValue.Text = "Not selected";
            // 
            // lbDeleteServiceNameTitle
            // 
            lbDeleteServiceNameTitle.AutoSize = true;
            lbDeleteServiceNameTitle.Font = new Font("Segoe UI", 9F);
            lbDeleteServiceNameTitle.ForeColor = Color.Gray;
            lbDeleteServiceNameTitle.Location = new Point(15, 50);
            lbDeleteServiceNameTitle.Name = "lbDeleteServiceNameTitle";
            lbDeleteServiceNameTitle.Size = new Size(82, 15);
            lbDeleteServiceNameTitle.TabIndex = 1;
            lbDeleteServiceNameTitle.Text = "Service Name:";
            // 
            // lbDeleteEditorHeader
            // 
            lbDeleteEditorHeader.AutoSize = true;
            lbDeleteEditorHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbDeleteEditorHeader.ForeColor = Color.FromArgb(217, 83, 79);
            lbDeleteEditorHeader.Location = new Point(15, 15);
            lbDeleteEditorHeader.Name = "lbDeleteEditorHeader";
            lbDeleteEditorHeader.Size = new Size(197, 20);
            lbDeleteEditorHeader.TabIndex = 0;
            lbDeleteEditorHeader.Text = "DELETE SERVICE BOOKING";
            // 
            // ProductContol
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(pnlStatusEditor);
            Controls.Add(pnlEditor);
            Controls.Add(pnlDeleteEditor);
            Controls.Add(pnlNewServiceBooking);
            Controls.Add(pnlGrid);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 9.75F);
            Name = "ProductContol";
            Size = new Size(1740, 639);
            Load += ProductContol_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlRbHolder.ResumeLayout(false);
            pnlRbHolder.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvServices).EndInit();
            pnlEditor.ResumeLayout(false);
            pnlEditor.PerformLayout();
            pnlSideBottom.ResumeLayout(false);
            tabControlLang.ResumeLayout(false);
            tabHun.ResumeLayout(false);
            tabHun.PerformLayout();
            tabEn.ResumeLayout(false);
            tabEn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            pnlStatusEditor.ResumeLayout(false);
            pnlStatusEditor.PerformLayout();
            pnlStatusBottom.ResumeLayout(false);
            pnlNewServiceBooking.ResumeLayout(false);
            pnlNewServiceBooking.PerformLayout();
            pnlBookingBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            pnlDeleteEditor.ResumeLayout(false);
            pnlDeleteEditor.PerformLayout();
            pnlDeleteBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Button btnSearch;
        private ComboBox cbTypeFilter;
        private TextBox txtSearch;
        private Label lbTypeFilter;
        private Label lbSearch;
        private Panel pnlGrid;
        private DataGridView dgvServices;
        private Panel pnlEditor;
        private Button btnNewService;
        private Button btnDeleteService;
        private Button btnUpdateService;
        private Label lbPrice;
        private TabControl tabControlLang;
        private TabPage tabHun;
        private TabPage tabEn;
        private Label lbTypeHu;
        private ComboBox cbTypeHu;
        private Label lbNameHu;
        private TextBox tbNameHu;
        private Label lbDescHu;
        private TextBox tbDescHu;
        private TextBox tbDescEn;
        private TextBox tbNameEn;
        private ComboBox cbTypeEn;
        private Label lbDescEn;
        private Label lbNameEn;
        private Label lbTypeEn;
        private Label lbFilter;
        private Label lbActions;
        private Label lbStats;
        private Label lbActiveServices;
        private Label lbTotalServices;
        private Label lbServiceDetails;
        private CheckBox chkIsActive;
        private Label lbStatusFilter;
        private RadioButton rbStatusAll;
        private RadioButton rbStatusActive;
        private RadioButton rbStatusInactive;
        private Label lbUtility;
        private Button btnRefresh;
        private Button btnResetFilters;
        private NumericUpDown numPrice;
        private Button btnSaveService;
        private Panel pnlSideBottom;
        private Label lbRoomNumber;
        private ComboBox cbRoomNumbers;
        private CheckBox chkShowHistory;
        private RadioButton rbOrderByDesc;
        private RadioButton rbOrderBy;
        private Label lbHistory;
        private Panel pnlRbHolder;
        private Panel pnlStatusEditor;
        private Label lbStatusEditorHeader;
        private Label lbServiceNameTitle;
        private Label lbServiceNameValue;
        private Label lbRoomNumberTitle;
        private Label lbRoomNumberValue;
        private Label lbCurrentStatusTitle;
        private Label lbCurrentStatusValue;
        private Label lbNewStatusTitle;
        private ComboBox cbNewStatus;
        private Panel pnlStatusBottom;
        private Button btnUpdateStatus;
        private Panel pnlNewServiceBooking;
        private Label lbBookingHeader;
        private Label lbSelectRoomTitle;
        private ComboBox cbSelectRoom;
        private Label lbSelectServiceTitle;
        private ComboBox cbSelectService;
        private Label lbQuantityTitle;
        private NumericUpDown numQuantity;
        private Label lbTotalPriceTitle;
        private Label lbTotalPriceValue;
        private Panel pnlBookingBottom;
        private Button btnAddBooking;
        private Button btnNewServiceClear;
        private Panel pnlDeleteEditor;
        private Panel pnlDeleteBottom;
        private Button btnDeleteServiceBooking;
        private Label lbDeleteEditorHeader;
        private Label lbDeleteServiceNameTitle;
        private Label lbDeleteServiceNameValue;
        private Label lbDeleteRoomNumberTitle;
        private Label lbDeleteRoomNumberValue;
        private Label lbDeleteQuantityTitle;
        private Label lbDeleteQuantityValue;
        private Label lbDeletePriceTitle;
        private Label lbDeletePriceValue;
        private Label lbDeleteCurrentStatusTitle;
        private Label lbDeleteCurrentStatusValue;
        private Label lbDeleteReqDateTitle;
        private Label lbDeleteReqDateValue;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colRoomNumber;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colRequestDate;
        private DataGridViewTextBoxColumn colNameHu;
        private DataGridViewTextBoxColumn colTypeHu;
        private DataGridViewTextBoxColumn colDescHu;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colNameEn;
        private DataGridViewTextBoxColumn colTypeEn;
        private DataGridViewTextBoxColumn colDescEn;
    }
}