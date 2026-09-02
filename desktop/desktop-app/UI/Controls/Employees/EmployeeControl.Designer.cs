namespace Hotel_erp_Winforms_App.UI.Controls.EmployeeControl
{
    partial class EmployeeControl
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            btnDelete = new Button();
            btnModify = new Button();
            btnAdd = new Button();
            btnRefresh = new Button();
            lbUtility = new Label();
            btnSearch = new Button();
            cbJobTitleFilter = new ComboBox();
            lbRoleFilter = new Label();
            txtSearch = new TextBox();
            lbSearch = new Label();
            lbFilter = new Label();
            pnlKpiTotal = new Panel();
            lbKpiTotalSub = new Label();
            lbKpiTotalValue = new Label();
            lbKpiTotalTitle = new Label();
            pnlKpiManagers = new Panel();
            lbKpiManagersSub = new Label();
            lbKpiManagersValue = new Label();
            lbKpiManagersTitle = new Label();
            pnlKpiStaff = new Panel();
            lbKpiStaffSub = new Label();
            lbKpiStaffValue = new Label();
            lbKpiStaffTitle = new Label();
            pnlKpiCleaners = new Panel();
            lbKpiCleanersSub = new Label();
            lbKpiCleanersValue = new Label();
            lbKpiCleanersTitle = new Label();
            pnlGrid = new Panel();
            dgvEmployees = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colLname = new DataGridViewTextBoxColumn();
            colFname = new DataGridViewTextBoxColumn();
            colJobTitle = new DataGridViewTextBoxColumn();
            colTaxNumber = new DataGridViewTextBoxColumn();
            colBirthDate = new DataGridViewTextBoxColumn();
            colHiringDate = new DataGridViewTextBoxColumn();
            colAddress = new DataGridViewTextBoxColumn();
            colHolidays = new DataGridViewTextBoxColumn();
            colSalary = new DataGridViewTextBoxColumn();
            pnlEditor = new Panel();
            pbProfilePhoto = new PictureBox();
            btnSaveEmployee = new Button();
            tbSalary = new TextBox();
            lbSalaryTitle = new Label();
            tbHolidays = new TextBox();
            lbHolidaysTitle = new Label();
            tbAddress = new TextBox();
            lbAddressTitle = new Label();
            dtpHiringDate = new DateTimePicker();
            lbHiringTitle = new Label();
            dtpBirthdate = new DateTimePicker();
            lbBirthdateTitle = new Label();
            tbTaxNumber = new TextBox();
            lbTaxNumberTitle = new Label();
            cbJobTitle = new ComboBox();
            lbJobTitleTitle = new Label();
            tbLastName = new TextBox();
            tbFirstName = new TextBox();
            lbFullNameTitle = new Label();
            lbEditorTitle = new Label();
            pnlTop.SuspendLayout();
            pnlKpiTotal.SuspendLayout();
            pnlKpiManagers.SuspendLayout();
            pnlKpiStaff.SuspendLayout();
            pnlKpiCleaners.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            pnlEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbProfilePhoto).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTop.BackColor = Color.FromArgb(245, 245, 248);
            pnlTop.BorderStyle = BorderStyle.FixedSingle;
            pnlTop.Controls.Add(btnDelete);
            pnlTop.Controls.Add(btnModify);
            pnlTop.Controls.Add(btnAdd);
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Controls.Add(lbUtility);
            pnlTop.Controls.Add(btnSearch);
            pnlTop.Controls.Add(cbJobTitleFilter);
            pnlTop.Controls.Add(lbRoleFilter);
            pnlTop.Controls.Add(txtSearch);
            pnlTop.Controls.Add(lbSearch);
            pnlTop.Controls.Add(lbFilter);
            pnlTop.Location = new Point(10, 10);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1350, 75);
            pnlTop.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = SystemColors.ButtonFace;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.DarkRed;
            btnDelete.Location = new Point(1220, 33);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 30);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnModify
            // 
            btnModify.BackColor = SystemColors.ButtonFace;
            btnModify.FlatStyle = FlatStyle.Flat;
            btnModify.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnModify.Location = new Point(1100, 33);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(110, 30);
            btnModify.TabIndex = 5;
            btnModify.Text = "Edit";
            btnModify.UseVisualStyleBackColor = false;
            btnModify.Click += btnModify_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.ButtonFace;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.DarkGreen;
            btnAdd.Location = new Point(960, 33);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(130, 30);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "+ Add Employee";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ButtonFace;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.Location = new Point(850, 33);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Reload";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lbUtility
            // 
            lbUtility.AutoSize = true;
            lbUtility.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbUtility.ForeColor = Color.DimGray;
            lbUtility.Location = new Point(850, 10);
            lbUtility.Name = "lbUtility";
            lbUtility.Size = new Size(70, 19);
            lbUtility.TabIndex = 8;
            lbUtility.Text = "ACTIONS";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ButtonFace;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSearch.Location = new Point(540, 31);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 32);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Filter";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // cbJobTitleFilter
            // 
            cbJobTitleFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbJobTitleFilter.FormattingEnabled = true;
            cbJobTitleFilter.Items.AddRange(new object[] { "All Roles", "HK Manager", "Receptionist", "Room Service", "Front Office Manager", "F&B Manager", "Cleaner" });
            cbJobTitleFilter.Location = new Point(340, 35);
            cbJobTitleFilter.Name = "cbJobTitleFilter";
            cbJobTitleFilter.Size = new Size(180, 25);
            cbJobTitleFilter.TabIndex = 1;
            // 
            // lbRoleFilter
            // 
            lbRoleFilter.AutoSize = true;
            lbRoleFilter.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbRoleFilter.Location = new Point(295, 38);
            lbRoleFilter.Name = "lbRoleFilter";
            lbRoleFilter.Size = new Size(39, 17);
            lbRoleFilter.TabIndex = 3;
            lbRoleFilter.Text = "Role:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(73, 35);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by name...";
            txtSearch.Size = new Size(200, 25);
            txtSearch.TabIndex = 0;
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
            lbFilter.Size = new Size(137, 19);
            lbFilter.TabIndex = 0;
            lbFilter.Text = "EMPLOYEE FILTERS";
            // 
            // pnlKpiTotal
            // 
            pnlKpiTotal.BackColor = Color.White;
            pnlKpiTotal.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiTotal.Controls.Add(lbKpiTotalSub);
            pnlKpiTotal.Controls.Add(lbKpiTotalValue);
            pnlKpiTotal.Controls.Add(lbKpiTotalTitle);
            pnlKpiTotal.Location = new Point(10, 95);
            pnlKpiTotal.Name = "pnlKpiTotal";
            pnlKpiTotal.Size = new Size(325, 85);
            pnlKpiTotal.TabIndex = 1;
            // 
            // lbKpiTotalSub
            // 
            lbKpiTotalSub.AutoSize = true;
            lbKpiTotalSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiTotalSub.ForeColor = Color.Gray;
            lbKpiTotalSub.Location = new Point(12, 60);
            lbKpiTotalSub.Name = "lbKpiTotalSub";
            lbKpiTotalSub.Size = new Size(130, 15);
            lbKpiTotalSub.TabIndex = 2;
            lbKpiTotalSub.Text = "Registered staff count";
            // 
            // lbKpiTotalValue
            // 
            lbKpiTotalValue.AutoSize = true;
            lbKpiTotalValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiTotalValue.ForeColor = Color.FromArgb(24, 60, 142);
            lbKpiTotalValue.Location = new Point(10, 27);
            lbKpiTotalValue.Name = "lbKpiTotalValue";
            lbKpiTotalValue.Size = new Size(28, 32);
            lbKpiTotalValue.TabIndex = 1;
            lbKpiTotalValue.Text = "0";
            // 
            // lbKpiTotalTitle
            // 
            lbKpiTotalTitle.AutoSize = true;
            lbKpiTotalTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiTotalTitle.ForeColor = Color.DimGray;
            lbKpiTotalTitle.Location = new Point(12, 10);
            lbKpiTotalTitle.Name = "lbKpiTotalTitle";
            lbKpiTotalTitle.Size = new Size(116, 15);
            lbKpiTotalTitle.TabIndex = 0;
            lbKpiTotalTitle.Text = "TOTAL EMPLOYEES";
            // 
            // pnlKpiManagers
            // 
            pnlKpiManagers.BackColor = Color.White;
            pnlKpiManagers.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiManagers.Controls.Add(lbKpiManagersSub);
            pnlKpiManagers.Controls.Add(lbKpiManagersValue);
            pnlKpiManagers.Controls.Add(lbKpiManagersTitle);
            pnlKpiManagers.Location = new Point(350, 95);
            pnlKpiManagers.Name = "pnlKpiManagers";
            pnlKpiManagers.Size = new Size(325, 85);
            pnlKpiManagers.TabIndex = 2;
            // 
            // lbKpiManagersSub
            // 
            lbKpiManagersSub.AutoSize = true;
            lbKpiManagersSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiManagersSub.ForeColor = Color.Gray;
            lbKpiManagersSub.Location = new Point(12, 60);
            lbKpiManagersSub.Name = "lbKpiManagersSub";
            lbKpiManagersSub.Size = new Size(125, 15);
            lbKpiManagersSub.TabIndex = 2;
            lbKpiManagersSub.Text = "Department directors";
            // 
            // lbKpiManagersValue
            // 
            lbKpiManagersValue.AutoSize = true;
            lbKpiManagersValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiManagersValue.ForeColor = Color.DarkGoldenrod;
            lbKpiManagersValue.Location = new Point(10, 27);
            lbKpiManagersValue.Name = "lbKpiManagersValue";
            lbKpiManagersValue.Size = new Size(28, 32);
            lbKpiManagersValue.TabIndex = 1;
            lbKpiManagersValue.Text = "0";
            // 
            // lbKpiManagersTitle
            // 
            lbKpiManagersTitle.AutoSize = true;
            lbKpiManagersTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiManagersTitle.ForeColor = Color.DimGray;
            lbKpiManagersTitle.Location = new Point(12, 10);
            lbKpiManagersTitle.Name = "lbKpiManagersTitle";
            lbKpiManagersTitle.Size = new Size(100, 15);
            lbKpiManagersTitle.TabIndex = 0;
            lbKpiManagersTitle.Text = "MANAGEMENT";
            // 
            // pnlKpiStaff
            // 
            pnlKpiStaff.BackColor = Color.White;
            pnlKpiStaff.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiStaff.Controls.Add(lbKpiStaffSub);
            pnlKpiStaff.Controls.Add(lbKpiStaffValue);
            pnlKpiStaff.Controls.Add(lbKpiStaffTitle);
            pnlKpiStaff.Location = new Point(690, 95);
            pnlKpiStaff.Name = "pnlKpiStaff";
            pnlKpiStaff.Size = new Size(325, 85);
            pnlKpiStaff.TabIndex = 3;
            // 
            // lbKpiStaffSub
            // 
            lbKpiStaffSub.AutoSize = true;
            lbKpiStaffSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiStaffSub.ForeColor = Color.Gray;
            lbKpiStaffSub.Location = new Point(12, 60);
            lbKpiStaffSub.Name = "lbKpiStaffSub";
            lbKpiStaffSub.Size = new Size(140, 15);
            lbKpiStaffSub.TabIndex = 2;
            lbKpiStaffSub.Text = "Front desk & Room service";
            // 
            // lbKpiStaffValue
            // 
            lbKpiStaffValue.AutoSize = true;
            lbKpiStaffValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiStaffValue.ForeColor = Color.DarkGreen;
            lbKpiStaffValue.Location = new Point(10, 27);
            lbKpiStaffValue.Name = "lbKpiStaffValue";
            lbKpiStaffValue.Size = new Size(28, 32);
            lbKpiStaffValue.TabIndex = 1;
            lbKpiStaffValue.Text = "0";
            // 
            // lbKpiStaffTitle
            // 
            lbKpiStaffTitle.AutoSize = true;
            lbKpiStaffTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiStaffTitle.ForeColor = Color.DimGray;
            lbKpiStaffTitle.Location = new Point(12, 10);
            lbKpiStaffTitle.Name = "lbKpiStaffTitle";
            lbKpiStaffTitle.Size = new Size(122, 15);
            lbKpiStaffTitle.TabIndex = 0;
            lbKpiStaffTitle.Text = "RECEPTION & SERVICE";
            // 
            // pnlKpiCleaners
            // 
            pnlKpiCleaners.BackColor = Color.White;
            pnlKpiCleaners.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiCleaners.Controls.Add(lbKpiCleanersSub);
            pnlKpiCleaners.Controls.Add(lbKpiCleanersValue);
            pnlKpiCleaners.Controls.Add(lbKpiCleanersTitle);
            pnlKpiCleaners.Location = new Point(1035, 95);
            pnlKpiCleaners.Name = "pnlKpiCleaners";
            pnlKpiCleaners.Size = new Size(325, 85);
            pnlKpiCleaners.TabIndex = 4;
            // 
            // lbKpiCleanersSub
            // 
            lbKpiCleanersSub.AutoSize = true;
            lbKpiCleanersSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiCleanersSub.ForeColor = Color.Gray;
            lbKpiCleanersSub.Location = new Point(12, 60);
            lbKpiCleanersSub.Name = "lbKpiCleanersSub";
            lbKpiCleanersSub.Size = new Size(126, 15);
            lbKpiCleanersSub.TabIndex = 2;
            lbKpiCleanersSub.Text = "Housekeeping crew";
            // 
            // lbKpiCleanersValue
            // 
            lbKpiCleanersValue.AutoSize = true;
            lbKpiCleanersValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiCleanersValue.ForeColor = Color.FromArgb(124, 58, 237);
            lbKpiCleanersValue.Location = new Point(10, 27);
            lbKpiCleanersValue.Name = "lbKpiCleanersValue";
            lbKpiCleanersValue.Size = new Size(28, 32);
            lbKpiCleanersValue.TabIndex = 1;
            lbKpiCleanersValue.Text = "0";
            // 
            // lbKpiCleanersTitle
            // 
            lbKpiCleanersTitle.AutoSize = true;
            lbKpiCleanersTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiCleanersTitle.ForeColor = Color.DimGray;
            lbKpiCleanersTitle.Location = new Point(12, 10);
            lbKpiCleanersTitle.Name = "lbKpiCleanersTitle";
            lbKpiCleanersTitle.Size = new Size(99, 15);
            lbKpiCleanersTitle.TabIndex = 0;
            lbKpiCleanersTitle.Text = "HOUSEKEEPING";
            // 
            // pnlGrid
            // 
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrid.BackColor = Color.White;
            pnlGrid.Controls.Add(dgvEmployees);
            pnlGrid.Location = new Point(10, 190);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(1350, 430);
            pnlGrid.TabIndex = 5;
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.AllowUserToOrderColumns = true;
            dgvEmployees.AllowUserToResizeColumns = false;
            dgvEmployees.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 248, 253);
            dgvEmployees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.BackgroundColor = Color.White;
            dgvEmployees.BorderStyle = BorderStyle.None;
            dgvEmployees.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvEmployees.ColumnHeadersHeight = 40;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEmployees.Columns.AddRange(new DataGridViewColumn[] { colId, colLname, colFname, colJobTitle, colTaxNumber, colBirthDate, colHiringDate, colAddress, colHolidays, colSalary });
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = SystemColors.Window;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle12.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            dgvEmployees.DefaultCellStyle = dataGridViewCellStyle12;
            dgvEmployees.Dock = DockStyle.Fill;
            dgvEmployees.EnableHeadersVisualStyles = false;
            dgvEmployees.GridColor = SystemColors.ControlLight;
            dgvEmployees.Location = new Point(0, 0);
            dgvEmployees.MultiSelect = false;
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.RowTemplate.Height = 35;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(1350, 430);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.CellClick += dgvEmployees_CellClick;
            // 
            // colId
            // 
            colId.DataPropertyName = "Id";
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colLname
            // 
            colLname.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLname.DataPropertyName = "LName";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colLname.DefaultCellStyle = dataGridViewCellStyle3;
            colLname.FillWeight = 15F;
            colLname.HeaderText = "Last Name";
            colLname.Name = "colLname";
            colLname.ReadOnly = true;
            // 
            // colFname
            // 
            colFname.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFname.DataPropertyName = "FName";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colFname.DefaultCellStyle = dataGridViewCellStyle4;
            colFname.FillWeight = 15F;
            colFname.HeaderText = "First Name";
            colFname.Name = "colFname";
            colFname.ReadOnly = true;
            // 
            // colJobTitle
            // 
            colJobTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colJobTitle.DataPropertyName = "JobTitle";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colJobTitle.DefaultCellStyle = dataGridViewCellStyle5;
            colJobTitle.FillWeight = 20F;
            colJobTitle.HeaderText = "Role / Title";
            colJobTitle.Name = "colJobTitle";
            colJobTitle.ReadOnly = true;
            // 
            // colTaxNumber
            // 
            colTaxNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTaxNumber.DataPropertyName = "TaxNumber";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTaxNumber.DefaultCellStyle = dataGridViewCellStyle6;
            colTaxNumber.FillWeight = 18F;
            colTaxNumber.HeaderText = "Tax Number";
            colTaxNumber.Name = "colTaxNumber";
            colTaxNumber.ReadOnly = true;
            // 
            // colBirthDate
            // 
            colBirthDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBirthDate.DataPropertyName = "DateOfBirth";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "yyyy.MM.dd";
            colBirthDate.DefaultCellStyle = dataGridViewCellStyle7;
            colBirthDate.FillWeight = 15F;
            colBirthDate.HeaderText = "Birthdate";
            colBirthDate.Name = "colBirthDate";
            colBirthDate.ReadOnly = true;
            // 
            // colHiringDate
            // 
            colHiringDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colHiringDate.DataPropertyName = "DateOfHiring";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "yyyy.MM.dd";
            colHiringDate.DefaultCellStyle = dataGridViewCellStyle8;
            colHiringDate.FillWeight = 15F;
            colHiringDate.HeaderText = "Date of Hiring";
            colHiringDate.Name = "colHiringDate";
            colHiringDate.ReadOnly = true;
            // 
            // colAddress
            // 
            colAddress.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colAddress.DataPropertyName = "Address";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colAddress.DefaultCellStyle = dataGridViewCellStyle9;
            colAddress.FillWeight = 25F;
            colAddress.HeaderText = "Address";
            colAddress.Name = "colAddress";
            colAddress.ReadOnly = true;
            // 
            // colHolidays
            // 
            colHolidays.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colHolidays.DataPropertyName = "PaidHolidaysLeft";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colHolidays.DefaultCellStyle = dataGridViewCellStyle10;
            colHolidays.FillWeight = 12F;
            colHolidays.HeaderText = "Holidays Left";
            colHolidays.Name = "colHolidays";
            colHolidays.ReadOnly = true;
            // 
            // colSalary
            // 
            colSalary.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colSalary.DataPropertyName = "Salary";
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "C0";
            colSalary.DefaultCellStyle = dataGridViewCellStyle11;
            colSalary.FillWeight = 15F;
            colSalary.HeaderText = "Salary";
            colSalary.Name = "colSalary";
            colSalary.ReadOnly = true;
            // 
            // pnlEditor
            // 
            pnlEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlEditor.BorderStyle = BorderStyle.FixedSingle;
            pnlEditor.Controls.Add(pbProfilePhoto);
            pnlEditor.Controls.Add(btnSaveEmployee);
            pnlEditor.Controls.Add(tbSalary);
            pnlEditor.Controls.Add(lbSalaryTitle);
            pnlEditor.Controls.Add(tbHolidays);
            pnlEditor.Controls.Add(lbHolidaysTitle);
            pnlEditor.Controls.Add(tbAddress);
            pnlEditor.Controls.Add(lbAddressTitle);
            pnlEditor.Controls.Add(dtpHiringDate);
            pnlEditor.Controls.Add(lbHiringTitle);
            pnlEditor.Controls.Add(dtpBirthdate);
            pnlEditor.Controls.Add(lbBirthdateTitle);
            pnlEditor.Controls.Add(tbTaxNumber);
            pnlEditor.Controls.Add(lbTaxNumberTitle);
            pnlEditor.Controls.Add(cbJobTitle);
            pnlEditor.Controls.Add(lbJobTitleTitle);
            pnlEditor.Controls.Add(tbLastName);
            pnlEditor.Controls.Add(tbFirstName);
            pnlEditor.Controls.Add(lbFullNameTitle);
            pnlEditor.Controls.Add(lbEditorTitle);
            pnlEditor.Location = new Point(1370, 10);
            pnlEditor.Name = "pnlEditor";
            pnlEditor.Size = new Size(355, 610);
            pnlEditor.TabIndex = 6;
            // 
            // pbProfilePhoto
            // 
            pbProfilePhoto.Anchor = AnchorStyles.Top;
            pbProfilePhoto.BorderStyle = BorderStyle.FixedSingle;
            pbProfilePhoto.Image = Properties.Resources.person_icon;
            pbProfilePhoto.Location = new Point(127, 36);
            pbProfilePhoto.Name = "pbProfilePhoto";
            pbProfilePhoto.Size = new Size(100, 100);
            pbProfilePhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbProfilePhoto.TabIndex = 19;
            pbProfilePhoto.TabStop = false;
            // 
            // btnSaveEmployee
            // 
            btnSaveEmployee.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSaveEmployee.BackColor = SystemColors.ButtonFace;
            btnSaveEmployee.FlatStyle = FlatStyle.Flat;
            btnSaveEmployee.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveEmployee.ForeColor = Color.DarkGreen;
            btnSaveEmployee.Location = new Point(15, 548);
            btnSaveEmployee.Name = "btnSaveEmployee";
            btnSaveEmployee.Size = new Size(320, 45);
            btnSaveEmployee.TabIndex = 10;
            btnSaveEmployee.Text = "Save Employee";
            btnSaveEmployee.UseVisualStyleBackColor = false;
            btnSaveEmployee.Click += btnSaveEmployee_Click;
            // 
            // tbSalary
            // 
            tbSalary.Location = new Point(180, 455);
            tbSalary.Name = "tbSalary";
            tbSalary.PlaceholderText = "0";
            tbSalary.Size = new Size(155, 25);
            tbSalary.TabIndex = 9;
            // 
            // lbSalaryTitle
            // 
            lbSalaryTitle.AutoSize = true;
            lbSalaryTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbSalaryTitle.Location = new Point(180, 435);
            lbSalaryTitle.Name = "lbSalaryTitle";
            lbSalaryTitle.Size = new Size(89, 17);
            lbSalaryTitle.TabIndex = 18;
            lbSalaryTitle.Text = "Salary (HUF):";
            // 
            // tbHolidays
            // 
            tbHolidays.Location = new Point(15, 455);
            tbHolidays.Name = "tbHolidays";
            tbHolidays.PlaceholderText = "20";
            tbHolidays.Size = new Size(155, 25);
            tbHolidays.TabIndex = 8;
            // 
            // lbHolidaysTitle
            // 
            lbHolidaysTitle.AutoSize = true;
            lbHolidaysTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbHolidaysTitle.Location = new Point(15, 435);
            lbHolidaysTitle.Name = "lbHolidaysTitle";
            lbHolidaysTitle.Size = new Size(94, 17);
            lbHolidaysTitle.TabIndex = 16;
            lbHolidaysTitle.Text = "Holidays Left:";
            // 
            // tbAddress
            // 
            tbAddress.Location = new Point(15, 398);
            tbAddress.Name = "tbAddress";
            tbAddress.PlaceholderText = "City, Street, House #";
            tbAddress.Size = new Size(320, 25);
            tbAddress.TabIndex = 7;
            // 
            // lbAddressTitle
            // 
            lbAddressTitle.AutoSize = true;
            lbAddressTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbAddressTitle.Location = new Point(15, 378);
            lbAddressTitle.Name = "lbAddressTitle";
            lbAddressTitle.Size = new Size(61, 17);
            lbAddressTitle.TabIndex = 14;
            lbAddressTitle.Text = "Address:";
            // 
            // dtpHiringDate
            // 
            dtpHiringDate.Format = DateTimePickerFormat.Short;
            dtpHiringDate.Location = new Point(180, 341);
            dtpHiringDate.Name = "dtpHiringDate";
            dtpHiringDate.Size = new Size(155, 25);
            dtpHiringDate.TabIndex = 6;
            // 
            // lbHiringTitle
            // 
            lbHiringTitle.AutoSize = true;
            lbHiringTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbHiringTitle.Location = new Point(180, 321);
            lbHiringTitle.Name = "lbHiringTitle";
            lbHiringTitle.Size = new Size(101, 17);
            lbHiringTitle.TabIndex = 12;
            lbHiringTitle.Text = "Date of Hiring:";
            // 
            // dtpBirthdate
            // 
            dtpBirthdate.Format = DateTimePickerFormat.Short;
            dtpBirthdate.Location = new Point(15, 341);
            dtpBirthdate.Name = "dtpBirthdate";
            dtpBirthdate.Size = new Size(155, 25);
            dtpBirthdate.TabIndex = 5;
            // 
            // lbBirthdateTitle
            // 
            lbBirthdateTitle.AutoSize = true;
            lbBirthdateTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbBirthdateTitle.Location = new Point(15, 321);
            lbBirthdateTitle.Name = "lbBirthdateTitle";
            lbBirthdateTitle.Size = new Size(69, 17);
            lbBirthdateTitle.TabIndex = 10;
            lbBirthdateTitle.Text = "Birthdate:";
            // 
            // tbTaxNumber
            // 
            tbTaxNumber.Location = new Point(15, 284);
            tbTaxNumber.Name = "tbTaxNumber";
            tbTaxNumber.PlaceholderText = "TX123456";
            tbTaxNumber.Size = new Size(320, 25);
            tbTaxNumber.TabIndex = 4;
            // 
            // lbTaxNumberTitle
            // 
            lbTaxNumberTitle.AutoSize = true;
            lbTaxNumberTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbTaxNumberTitle.Location = new Point(15, 264);
            lbTaxNumberTitle.Name = "lbTaxNumberTitle";
            lbTaxNumberTitle.Size = new Size(88, 17);
            lbTaxNumberTitle.TabIndex = 8;
            lbTaxNumberTitle.Text = "Tax Number:";
            // 
            // cbJobTitle
            // 
            cbJobTitle.DropDownStyle = ComboBoxStyle.DropDownList;
            cbJobTitle.FormattingEnabled = true;
            cbJobTitle.Items.AddRange(new object[] { "HK Manager", "Receptionist", "Room Service", "Front Office Manager", "F&B Manager", "Cleaner" });
            cbJobTitle.Location = new Point(15, 227);
            cbJobTitle.Name = "cbJobTitle";
            cbJobTitle.Size = new Size(320, 25);
            cbJobTitle.TabIndex = 3;
            // 
            // lbJobTitleTitle
            // 
            lbJobTitleTitle.AutoSize = true;
            lbJobTitleTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbJobTitleTitle.Location = new Point(15, 207);
            lbJobTitleTitle.Name = "lbJobTitleTitle";
            lbJobTitleTitle.Size = new Size(80, 17);
            lbJobTitleTitle.TabIndex = 6;
            lbJobTitleTitle.Text = "Role / Title:";
            // 
            // tbLastName
            // 
            tbLastName.Location = new Point(180, 170);
            tbLastName.Name = "tbLastName";
            tbLastName.PlaceholderText = "Last name";
            tbLastName.Size = new Size(155, 25);
            tbLastName.TabIndex = 2;
            // 
            // tbFirstName
            // 
            tbFirstName.Location = new Point(15, 170);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.PlaceholderText = "First name";
            tbFirstName.Size = new Size(155, 25);
            tbFirstName.TabIndex = 1;
            // 
            // lbFullNameTitle
            // 
            lbFullNameTitle.AutoSize = true;
            lbFullNameTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbFullNameTitle.Location = new Point(15, 150);
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
            lbEditorTitle.Size = new Size(211, 20);
            lbEditorTitle.TabIndex = 0;
            lbEditorTitle.Text = "EMPLOYEE PROFILE DETAILS";
            // 
            // EmployeeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(pnlEditor);
            Controls.Add(pnlGrid);
            Controls.Add(pnlKpiCleaners);
            Controls.Add(pnlKpiStaff);
            Controls.Add(pnlKpiManagers);
            Controls.Add(pnlKpiTotal);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 9.75F);
            Name = "EmployeeControl";
            Size = new Size(1740, 639);
            Load += EmployeeControl_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlKpiTotal.ResumeLayout(false);
            pnlKpiTotal.PerformLayout();
            pnlKpiManagers.ResumeLayout(false);
            pnlKpiManagers.PerformLayout();
            pnlKpiStaff.ResumeLayout(false);
            pnlKpiStaff.PerformLayout();
            pnlKpiCleaners.ResumeLayout(false);
            pnlKpiCleaners.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            pnlEditor.ResumeLayout(false);
            pnlEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbProfilePhoto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lbFilter;
        private Label lbSearch;
        private TextBox txtSearch;
        private Label lbRoleFilter;
        private ComboBox cbJobTitleFilter;
        private Button btnSearch;
        private Label lbUtility;
        private Button btnRefresh;
        private Button btnAdd;
        private Button btnModify;
        private Button btnDelete;

        private Panel pnlKpiTotal;
        private Label lbKpiTotalTitle;
        private Label lbKpiTotalValue;
        private Label lbKpiTotalSub;

        private Panel pnlKpiManagers;
        private Label lbKpiManagersTitle;
        private Label lbKpiManagersValue;
        private Label lbKpiManagersSub;

        private Panel pnlKpiStaff;
        private Label lbKpiStaffTitle;
        private Label lbKpiStaffValue;
        private Label lbKpiStaffSub;

        private Panel pnlKpiCleaners;
        private Label lbKpiCleanersTitle;
        private Label lbKpiCleanersValue;
        private Label lbKpiCleanersSub;

        private Panel pnlGrid;
        private DataGridView dgvEmployees;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colLname;
        private DataGridViewTextBoxColumn colFname;
        private DataGridViewTextBoxColumn colJobTitle;
        private DataGridViewTextBoxColumn colTaxNumber;
        private DataGridViewTextBoxColumn colBirthDate;
        private DataGridViewTextBoxColumn colHiringDate;
        private DataGridViewTextBoxColumn colAddress;
        private DataGridViewTextBoxColumn colHolidays;
        private DataGridViewTextBoxColumn colSalary;

        private Panel pnlEditor;
        private Label lbEditorTitle;
        private PictureBox pbProfilePhoto;
        private Label lbFullNameTitle;
        private TextBox tbFirstName;
        private TextBox tbLastName;
        private Label lbJobTitleTitle;
        private ComboBox cbJobTitle;
        private Label lbTaxNumberTitle;
        private TextBox tbTaxNumber;
        private Label lbBirthdateTitle;
        private DateTimePicker dtpBirthdate;
        private Label lbHiringTitle;
        private DateTimePicker dtpHiringDate;
        private Label lbAddressTitle;
        private TextBox tbAddress;
        private Label lbHolidaysTitle;
        private TextBox tbHolidays;
        private Label lbSalaryTitle;
        private TextBox tbSalary;
        private Button btnSaveEmployee;
    }
}