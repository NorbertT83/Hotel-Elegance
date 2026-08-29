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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            pnlTop = new Panel();
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
            colNameHu = new DataGridViewTextBoxColumn();
            colTypeHu = new DataGridViewTextBoxColumn();
            colDescHu = new DataGridViewTextBoxColumn();
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
            pnlTop.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServices).BeginInit();
            pnlEditor.SuspendLayout();
            pnlSideBottom.SuspendLayout();
            tabControlLang.SuspendLayout();
            tabHun.SuspendLayout();
            tabEn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTop.BackColor = Color.FromArgb(245, 245, 248);
            pnlTop.BorderStyle = BorderStyle.FixedSingle;
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
            rbStatusActive.Size = new Size(64, 21);
            rbStatusActive.TabIndex = 5;
            rbStatusActive.Text = "Active";
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
            dataGridViewCellStyle4.BackColor = Color.FromArgb(245, 248, 253);
            dgvServices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvServices.BackgroundColor = Color.White;
            dgvServices.BorderStyle = BorderStyle.None;
            dgvServices.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(24, 60, 142);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(24, 60, 142);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvServices.ColumnHeadersHeight = 40;
            dgvServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvServices.Columns.AddRange(new DataGridViewColumn[] { colId, colNameHu, colTypeHu, colDescHu, colPrice, colNameEn, colTypeEn, colDescEn });
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
            // colPrice
            // 
            colPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPrice.DataPropertyName = "Price";
            dataGridViewCellStyle6.NullValue = null;
            colPrice.DefaultCellStyle = dataGridViewCellStyle6;
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
            // ProductContol
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(pnlEditor);
            Controls.Add(pnlGrid);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 9.75F);
            Name = "ProductContol";
            Size = new Size(1740, 639);
            Load += ProductContol_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
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
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNameHu;
        private DataGridViewTextBoxColumn colTypeHu;
        private DataGridViewTextBoxColumn colDescHu;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colNameEn;
        private DataGridViewTextBoxColumn colTypeEn;
        private DataGridViewTextBoxColumn colDescEn;
        private NumericUpDown numPrice;
        private Button btnSaveService;
        private Panel pnlSideBottom;
    }
}