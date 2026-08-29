namespace Hotel_erp_Winforms_App.UI.Controls
{
    partial class HousekeepingControl
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
            btnMarkAllClean = new Button();
            btnRefresh = new Button();
            lbUtility = new Label();
            btnSearch = new Button();
            cbStatusFilter = new ComboBox();
            lbStatusFilter = new Label();
            cbFloorFilter = new ComboBox();
            lbFloorFilter = new Label();
            txtRoomSearch = new TextBox();
            lbRoomSearch = new Label();
            lbFilter = new Label();
            pnlKpiDirty = new Panel();
            lbKpiDirtySub = new Label();
            lbKpiDirtyValue = new Label();
            lbKpiDirtyTitle = new Label();
            pnlKpiProgress = new Panel();
            lbKpiProgressSub = new Label();
            lbKpiProgressValue = new Label();
            lbKpiProgressTitle = new Label();
            pnlKpiClean = new Panel();
            lbKpiCleanSub = new Label();
            lbKpiCleanValue = new Label();
            lbKpiCleanTitle = new Label();
            pnlKpiMaintenance = new Panel();
            lbKpiStaffSub = new Label();
            lbKpiStaffValue = new Label();
            lbKpiStaffTitle = new Label();
            pnlGrid = new Panel();
            dgvRooms = new DataGridView();
            colRoomId = new DataGridViewTextBoxColumn();
            colRoomNumber = new DataGridViewTextBoxColumn();
            colFloor = new DataGridViewTextBoxColumn();
            colRoomType = new DataGridViewTextBoxColumn();
            colCurrentStatus = new DataGridViewTextBoxColumn();
            colCleaningStatus = new DataGridViewTextBoxColumn();
            colDisturb = new DataGridViewTextBoxColumn();
            colIsCleaning = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            cbColorCodes = new CheckBox();
            lbCleanColor = new Label();
            lbCleanTitle = new Label();
            lbUnderMaintenanceColor = new Label();
            lbUnderMaintenanceTitle = new Label();
            lbNeedsCleaningColor = new Label();
            lbNeedsCleaningTitle = new Label();
            lbPrioColor = new Label();
            lbPrioTitle = new Label();
            pnlEditor = new Panel();
            btnSaveRoomStatus = new Button();
            tbMaintenanceNotes = new TextBox();
            lbMaintenanceNotesTitle = new Label();
            cbAssignCleaner = new ComboBox();
            lbAssignCleanerTitle = new Label();
            cbSetStatus = new ComboBox();
            lbSetStatusTitle = new Label();
            lbSelectedRoomValue = new Label();
            lbSelectedRoomNumber = new Label();
            lbRoomDetailsTitle = new Label();
            pnlTop.SuspendLayout();
            pnlKpiDirty.SuspendLayout();
            pnlKpiProgress.SuspendLayout();
            pnlKpiClean.SuspendLayout();
            pnlKpiMaintenance.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            panel1.SuspendLayout();
            pnlEditor.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTop.BackColor = Color.FromArgb(245, 245, 248);
            pnlTop.BorderStyle = BorderStyle.FixedSingle;
            pnlTop.Controls.Add(btnMarkAllClean);
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Controls.Add(lbUtility);
            pnlTop.Controls.Add(btnSearch);
            pnlTop.Controls.Add(cbStatusFilter);
            pnlTop.Controls.Add(lbStatusFilter);
            pnlTop.Controls.Add(cbFloorFilter);
            pnlTop.Controls.Add(lbFloorFilter);
            pnlTop.Controls.Add(txtRoomSearch);
            pnlTop.Controls.Add(lbRoomSearch);
            pnlTop.Controls.Add(lbFilter);
            pnlTop.Location = new Point(10, 10);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(1350, 75);
            pnlTop.TabIndex = 0;
            // 
            // btnMarkAllClean
            // 
            btnMarkAllClean.BackColor = SystemColors.ButtonFace;
            btnMarkAllClean.FlatStyle = FlatStyle.Flat;
            btnMarkAllClean.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMarkAllClean.Location = new Point(1200, 33);
            btnMarkAllClean.Name = "btnMarkAllClean";
            btnMarkAllClean.Size = new Size(130, 30);
            btnMarkAllClean.TabIndex = 10;
            btnMarkAllClean.Text = "Reset All to Dirty";
            btnMarkAllClean.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ButtonFace;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.Location = new Point(1080, 33);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 30);
            btnRefresh.TabIndex = 9;
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
            lbUtility.TabIndex = 8;
            lbUtility.Text = "ACTIONS";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.ButtonFace;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSearch.Location = new Point(560, 31);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 32);
            btnSearch.TabIndex = 7;
            btnSearch.Text = "Filter";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // cbStatusFilter
            // 
            cbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatusFilter.FormattingEnabled = true;
            cbStatusFilter.Items.AddRange(new object[] { "All Statuses", "Dirty", "In Progress", "Clean" });
            cbStatusFilter.Location = new Point(415, 35);
            cbStatusFilter.Name = "cbStatusFilter";
            cbStatusFilter.Size = new Size(130, 25);
            cbStatusFilter.TabIndex = 6;
            // 
            // lbStatusFilter
            // 
            lbStatusFilter.AutoSize = true;
            lbStatusFilter.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbStatusFilter.Location = new Point(360, 38);
            lbStatusFilter.Name = "lbStatusFilter";
            lbStatusFilter.Size = new Size(50, 17);
            lbStatusFilter.TabIndex = 5;
            lbStatusFilter.Text = "Status:";
            // 
            // cbFloorFilter
            // 
            cbFloorFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFloorFilter.FormattingEnabled = true;
            cbFloorFilter.Items.AddRange(new object[] { "All Floors", "1st Floor", "2nd Floor", "3rd Floor", "4th Floor" });
            cbFloorFilter.Location = new Point(233, 35);
            cbFloorFilter.Name = "cbFloorFilter";
            cbFloorFilter.Size = new Size(110, 25);
            cbFloorFilter.TabIndex = 4;
            // 
            // lbFloorFilter
            // 
            lbFloorFilter.AutoSize = true;
            lbFloorFilter.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbFloorFilter.Location = new Point(185, 38);
            lbFloorFilter.Name = "lbFloorFilter";
            lbFloorFilter.Size = new Size(45, 17);
            lbFloorFilter.TabIndex = 3;
            lbFloorFilter.Text = "Floor:";
            // 
            // txtRoomSearch
            // 
            txtRoomSearch.Location = new Point(68, 35);
            txtRoomSearch.MaxLength = 3;
            txtRoomSearch.Name = "txtRoomSearch";
            txtRoomSearch.PlaceholderText = "Room number";
            txtRoomSearch.Size = new Size(100, 25);
            txtRoomSearch.TabIndex = 2;
            txtRoomSearch.KeyPress += txtRoomSearch_KeyPress;
            // 
            // lbRoomSearch
            // 
            lbRoomSearch.AutoSize = true;
            lbRoomSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbRoomSearch.Location = new Point(15, 38);
            lbRoomSearch.Name = "lbRoomSearch";
            lbRoomSearch.Size = new Size(48, 17);
            lbRoomSearch.TabIndex = 1;
            lbRoomSearch.Text = "Room:";
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
            lbFilter.Text = "ROOM FILTERS";
            // 
            // pnlKpiDirty
            // 
            pnlKpiDirty.BackColor = Color.White;
            pnlKpiDirty.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiDirty.Controls.Add(lbKpiDirtySub);
            pnlKpiDirty.Controls.Add(lbKpiDirtyValue);
            pnlKpiDirty.Controls.Add(lbKpiDirtyTitle);
            pnlKpiDirty.Location = new Point(10, 95);
            pnlKpiDirty.Name = "pnlKpiDirty";
            pnlKpiDirty.Size = new Size(325, 85);
            pnlKpiDirty.TabIndex = 1;
            // 
            // lbKpiDirtySub
            // 
            lbKpiDirtySub.AutoSize = true;
            lbKpiDirtySub.Font = new Font("Segoe UI", 8.5F);
            lbKpiDirtySub.ForeColor = Color.Gray;
            lbKpiDirtySub.Location = new Point(12, 60);
            lbKpiDirtySub.Name = "lbKpiDirtySub";
            lbKpiDirtySub.Size = new Size(152, 15);
            lbKpiDirtySub.TabIndex = 2;
            lbKpiDirtySub.Text = "Pending checkout/stayover";
            // 
            // lbKpiDirtyValue
            // 
            lbKpiDirtyValue.AutoSize = true;
            lbKpiDirtyValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiDirtyValue.ForeColor = Color.DarkRed;
            lbKpiDirtyValue.Location = new Point(10, 27);
            lbKpiDirtyValue.Name = "lbKpiDirtyValue";
            lbKpiDirtyValue.Size = new Size(28, 32);
            lbKpiDirtyValue.TabIndex = 1;
            lbKpiDirtyValue.Text = "0";
            // 
            // lbKpiDirtyTitle
            // 
            lbKpiDirtyTitle.AutoSize = true;
            lbKpiDirtyTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiDirtyTitle.ForeColor = Color.DimGray;
            lbKpiDirtyTitle.Location = new Point(12, 10);
            lbKpiDirtyTitle.Name = "lbKpiDirtyTitle";
            lbKpiDirtyTitle.Size = new Size(105, 15);
            lbKpiDirtyTitle.TabIndex = 0;
            lbKpiDirtyTitle.Text = "NEEDS CLEANING";
            // 
            // pnlKpiProgress
            // 
            pnlKpiProgress.BackColor = Color.White;
            pnlKpiProgress.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiProgress.Controls.Add(lbKpiProgressSub);
            pnlKpiProgress.Controls.Add(lbKpiProgressValue);
            pnlKpiProgress.Controls.Add(lbKpiProgressTitle);
            pnlKpiProgress.Location = new Point(350, 95);
            pnlKpiProgress.Name = "pnlKpiProgress";
            pnlKpiProgress.Size = new Size(325, 85);
            pnlKpiProgress.TabIndex = 2;
            // 
            // lbKpiProgressSub
            // 
            lbKpiProgressSub.AutoSize = true;
            lbKpiProgressSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiProgressSub.ForeColor = Color.Gray;
            lbKpiProgressSub.Location = new Point(12, 60);
            lbKpiProgressSub.Name = "lbKpiProgressSub";
            lbKpiProgressSub.Size = new Size(133, 15);
            lbKpiProgressSub.TabIndex = 2;
            lbKpiProgressSub.Text = "Currently being cleaned";
            // 
            // lbKpiProgressValue
            // 
            lbKpiProgressValue.AutoSize = true;
            lbKpiProgressValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiProgressValue.ForeColor = Color.DarkOrange;
            lbKpiProgressValue.Location = new Point(10, 27);
            lbKpiProgressValue.Name = "lbKpiProgressValue";
            lbKpiProgressValue.Size = new Size(28, 32);
            lbKpiProgressValue.TabIndex = 1;
            lbKpiProgressValue.Text = "0";
            // 
            // lbKpiProgressTitle
            // 
            lbKpiProgressTitle.AutoSize = true;
            lbKpiProgressTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiProgressTitle.ForeColor = Color.DimGray;
            lbKpiProgressTitle.Location = new Point(12, 10);
            lbKpiProgressTitle.Name = "lbKpiProgressTitle";
            lbKpiProgressTitle.Size = new Size(84, 15);
            lbKpiProgressTitle.TabIndex = 0;
            lbKpiProgressTitle.Text = "IN PROGRESS";
            // 
            // pnlKpiClean
            // 
            pnlKpiClean.BackColor = Color.White;
            pnlKpiClean.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiClean.Controls.Add(lbKpiCleanSub);
            pnlKpiClean.Controls.Add(lbKpiCleanValue);
            pnlKpiClean.Controls.Add(lbKpiCleanTitle);
            pnlKpiClean.Location = new Point(690, 95);
            pnlKpiClean.Name = "pnlKpiClean";
            pnlKpiClean.Size = new Size(325, 85);
            pnlKpiClean.TabIndex = 3;
            // 
            // lbKpiCleanSub
            // 
            lbKpiCleanSub.AutoSize = true;
            lbKpiCleanSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiCleanSub.ForeColor = Color.Gray;
            lbKpiCleanSub.Location = new Point(12, 60);
            lbKpiCleanSub.Name = "lbKpiCleanSub";
            lbKpiCleanSub.Size = new Size(138, 15);
            lbKpiCleanSub.TabIndex = 2;
            lbKpiCleanSub.Text = "Ready for guest check-in";
            // 
            // lbKpiCleanValue
            // 
            lbKpiCleanValue.AutoSize = true;
            lbKpiCleanValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiCleanValue.ForeColor = Color.DarkGreen;
            lbKpiCleanValue.Location = new Point(10, 27);
            lbKpiCleanValue.Name = "lbKpiCleanValue";
            lbKpiCleanValue.Size = new Size(28, 32);
            lbKpiCleanValue.TabIndex = 1;
            lbKpiCleanValue.Text = "0";
            // 
            // lbKpiCleanTitle
            // 
            lbKpiCleanTitle.AutoSize = true;
            lbKpiCleanTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiCleanTitle.ForeColor = Color.DimGray;
            lbKpiCleanTitle.Location = new Point(12, 10);
            lbKpiCleanTitle.Name = "lbKpiCleanTitle";
            lbKpiCleanTitle.Size = new Size(92, 15);
            lbKpiCleanTitle.TabIndex = 0;
            lbKpiCleanTitle.Text = "CLEAN / READY";
            // 
            // pnlKpiMaintenance
            // 
            pnlKpiMaintenance.BackColor = Color.White;
            pnlKpiMaintenance.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiMaintenance.Controls.Add(lbKpiStaffSub);
            pnlKpiMaintenance.Controls.Add(lbKpiStaffValue);
            pnlKpiMaintenance.Controls.Add(lbKpiStaffTitle);
            pnlKpiMaintenance.Location = new Point(1035, 95);
            pnlKpiMaintenance.Name = "pnlKpiMaintenance";
            pnlKpiMaintenance.Size = new Size(325, 85);
            pnlKpiMaintenance.TabIndex = 4;
            // 
            // lbKpiStaffSub
            // 
            lbKpiStaffSub.AutoSize = true;
            lbKpiStaffSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiStaffSub.ForeColor = Color.Gray;
            lbKpiStaffSub.Location = new Point(12, 60);
            lbKpiStaffSub.Name = "lbKpiStaffSub";
            lbKpiStaffSub.Size = new Size(192, 15);
            lbKpiStaffSub.TabIndex = 2;
            lbKpiStaffSub.Text = "Available housekeeping staff count";
            // 
            // lbKpiStaffValue
            // 
            lbKpiStaffValue.AutoSize = true;
            lbKpiStaffValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiStaffValue.ForeColor = Color.Red;
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
            lbKpiStaffTitle.Size = new Size(83, 15);
            lbKpiStaffTitle.TabIndex = 0;
            lbKpiStaffTitle.Text = "ACTIVE STAFF";
            // 
            // pnlGrid
            // 
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrid.BackColor = Color.White;
            pnlGrid.Controls.Add(dgvRooms);
            pnlGrid.Controls.Add(panel1);
            pnlGrid.Location = new Point(10, 190);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(1350, 430);
            pnlGrid.TabIndex = 5;
            // 
            // dgvRooms
            // 
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.AllowUserToDeleteRows = false;
            dgvRooms.AllowUserToResizeColumns = false;
            dgvRooms.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(245, 248, 253);
            dgvRooms.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvRooms.BackgroundColor = Color.White;
            dgvRooms.BorderStyle = BorderStyle.None;
            dgvRooms.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvRooms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvRooms.ColumnHeadersHeight = 40;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRooms.Columns.AddRange(new DataGridViewColumn[] { colRoomId, colRoomNumber, colFloor, colRoomType, colCurrentStatus, colCleaningStatus, colDisturb, colIsCleaning });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvRooms.DefaultCellStyle = dataGridViewCellStyle6;
            dgvRooms.Dock = DockStyle.Fill;
            dgvRooms.EnableHeadersVisualStyles = false;
            dgvRooms.GridColor = SystemColors.ControlLight;
            dgvRooms.Location = new Point(0, 0);
            dgvRooms.MultiSelect = false;
            dgvRooms.Name = "dgvRooms";
            dgvRooms.ReadOnly = true;
            dgvRooms.RowHeadersVisible = false;
            dgvRooms.RowTemplate.Height = 35;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.Size = new Size(1350, 380);
            dgvRooms.TabIndex = 0;
            dgvRooms.CellClick += dgvRooms_CellClick;
            // 
            // colRoomId
            // 
            colRoomId.HeaderText = "Id";
            colRoomId.Name = "colRoomId";
            colRoomId.ReadOnly = true;
            colRoomId.Visible = false;
            // 
            // colRoomNumber
            // 
            colRoomNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoomNumber.DataPropertyName = "Room_number";
            colRoomNumber.FillWeight = 12F;
            colRoomNumber.HeaderText = "Room #";
            colRoomNumber.Name = "colRoomNumber";
            colRoomNumber.ReadOnly = true;
            // 
            // colFloor
            // 
            colFloor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFloor.DataPropertyName = "Room_number";
            colFloor.FillWeight = 10F;
            colFloor.HeaderText = "Floor";
            colFloor.Name = "colFloor";
            colFloor.ReadOnly = true;
            // 
            // colRoomType
            // 
            colRoomType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoomType.DataPropertyName = "RoomsRoomtype";
            colRoomType.FillWeight = 18F;
            colRoomType.HeaderText = "Room Type";
            colRoomType.Name = "colRoomType";
            colRoomType.ReadOnly = true;
            // 
            // colCurrentStatus
            // 
            colCurrentStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCurrentStatus.DataPropertyName = "CurrentStatus";
            colCurrentStatus.FillWeight = 15F;
            colCurrentStatus.HeaderText = "Current Status";
            colCurrentStatus.Name = "colCurrentStatus";
            colCurrentStatus.ReadOnly = true;
            // 
            // colCleaningStatus
            // 
            colCleaningStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCleaningStatus.DataPropertyName = "NeedsCleaning";
            colCleaningStatus.FillWeight = 15F;
            colCleaningStatus.HeaderText = "Clean Status";
            colCleaningStatus.Name = "colCleaningStatus";
            colCleaningStatus.ReadOnly = true;
            // 
            // colDisturb
            // 
            colDisturb.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDisturb.DataPropertyName = "DontDisturb";
            colDisturb.FillWeight = 15F;
            colDisturb.HeaderText = "Disturb";
            colDisturb.Name = "colDisturb";
            colDisturb.ReadOnly = true;
            // 
            // colIsCleaning
            // 
            colIsCleaning.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colIsCleaning.DataPropertyName = "IsCleaning";
            colIsCleaning.FillWeight = 15F;
            colIsCleaning.HeaderText = "Under Maintenance";
            colIsCleaning.Name = "colIsCleaning";
            colIsCleaning.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(cbColorCodes);
            panel1.Controls.Add(lbCleanColor);
            panel1.Controls.Add(lbCleanTitle);
            panel1.Controls.Add(lbUnderMaintenanceColor);
            panel1.Controls.Add(lbUnderMaintenanceTitle);
            panel1.Controls.Add(lbNeedsCleaningColor);
            panel1.Controls.Add(lbNeedsCleaningTitle);
            panel1.Controls.Add(lbPrioColor);
            panel1.Controls.Add(lbPrioTitle);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 380);
            panel1.Name = "panel1";
            panel1.Size = new Size(1350, 50);
            panel1.TabIndex = 1;
            // 
            // cbColorCodes
            // 
            cbColorCodes.AutoSize = true;
            cbColorCodes.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            cbColorCodes.ForeColor = Color.DarkGreen;
            cbColorCodes.Location = new Point(1200, 16);
            cbColorCodes.Name = "cbColorCodes";
            cbColorCodes.Size = new Size(142, 21);
            cbColorCodes.TabIndex = 4;
            cbColorCodes.Text = "Enable color codes";
            cbColorCodes.UseVisualStyleBackColor = true;
            cbColorCodes.CheckedChanged += cbColorCodes_CheckedChanged;
            // 
            // lbCleanColor
            // 
            lbCleanColor.BackColor = Color.Honeydew;
            lbCleanColor.BorderStyle = BorderStyle.FixedSingle;
            lbCleanColor.ForeColor = SystemColors.ControlText;
            lbCleanColor.Location = new Point(975, 10);
            lbCleanColor.Name = "lbCleanColor";
            lbCleanColor.Size = new Size(54, 30);
            lbCleanColor.TabIndex = 1;
            // 
            // lbCleanTitle
            // 
            lbCleanTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbCleanTitle.ForeColor = Color.Black;
            lbCleanTitle.Location = new Point(925, 16);
            lbCleanTitle.Name = "lbCleanTitle";
            lbCleanTitle.Size = new Size(50, 18);
            lbCleanTitle.TabIndex = 3;
            lbCleanTitle.Text = "Clean:";
            // 
            // lbUnderMaintenanceColor
            // 
            lbUnderMaintenanceColor.BackColor = Color.PaleTurquoise;
            lbUnderMaintenanceColor.BorderStyle = BorderStyle.FixedSingle;
            lbUnderMaintenanceColor.ForeColor = SystemColors.ControlText;
            lbUnderMaintenanceColor.Location = new Point(760, 10);
            lbUnderMaintenanceColor.Name = "lbUnderMaintenanceColor";
            lbUnderMaintenanceColor.Size = new Size(55, 30);
            lbUnderMaintenanceColor.TabIndex = 1;
            // 
            // lbUnderMaintenanceTitle
            // 
            lbUnderMaintenanceTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbUnderMaintenanceTitle.ForeColor = Color.Black;
            lbUnderMaintenanceTitle.Location = new Point(620, 16);
            lbUnderMaintenanceTitle.Name = "lbUnderMaintenanceTitle";
            lbUnderMaintenanceTitle.Size = new Size(140, 18);
            lbUnderMaintenanceTitle.TabIndex = 3;
            lbUnderMaintenanceTitle.Text = "Under Maintenance:";
            // 
            // lbNeedsCleaningColor
            // 
            lbNeedsCleaningColor.BackColor = Color.NavajoWhite;
            lbNeedsCleaningColor.BorderStyle = BorderStyle.FixedSingle;
            lbNeedsCleaningColor.ForeColor = Color.NavajoWhite;
            lbNeedsCleaningColor.Location = new Point(525, 10);
            lbNeedsCleaningColor.Name = "lbNeedsCleaningColor";
            lbNeedsCleaningColor.Size = new Size(55, 30);
            lbNeedsCleaningColor.TabIndex = 1;
            // 
            // lbNeedsCleaningTitle
            // 
            lbNeedsCleaningTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbNeedsCleaningTitle.ForeColor = Color.Black;
            lbNeedsCleaningTitle.Location = new Point(380, 16);
            lbNeedsCleaningTitle.Name = "lbNeedsCleaningTitle";
            lbNeedsCleaningTitle.Size = new Size(145, 18);
            lbNeedsCleaningTitle.TabIndex = 3;
            lbNeedsCleaningTitle.Text = "Room needs cleaning:";
            // 
            // lbPrioColor
            // 
            lbPrioColor.BackColor = Color.FromArgb(236, 163, 163);
            lbPrioColor.BorderStyle = BorderStyle.FixedSingle;
            lbPrioColor.Location = new Point(285, 10);
            lbPrioColor.Name = "lbPrioColor";
            lbPrioColor.Size = new Size(55, 30);
            lbPrioColor.TabIndex = 1;
            // 
            // lbPrioTitle
            // 
            lbPrioTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbPrioTitle.ForeColor = Color.DarkRed;
            lbPrioTitle.Location = new Point(10, 16);
            lbPrioTitle.Name = "lbPrioTitle";
            lbPrioTitle.Size = new Size(275, 18);
            lbPrioTitle.TabIndex = 3;
            lbPrioTitle.Text = "High Priority Rooms (VIP / Early Checkin):";
            // 
            // pnlEditor
            // 
            pnlEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlEditor.BorderStyle = BorderStyle.FixedSingle;
            pnlEditor.Controls.Add(btnSaveRoomStatus);
            pnlEditor.Controls.Add(tbMaintenanceNotes);
            pnlEditor.Controls.Add(lbMaintenanceNotesTitle);
            pnlEditor.Controls.Add(cbAssignCleaner);
            pnlEditor.Controls.Add(lbAssignCleanerTitle);
            pnlEditor.Controls.Add(cbSetStatus);
            pnlEditor.Controls.Add(lbSetStatusTitle);
            pnlEditor.Controls.Add(lbSelectedRoomValue);
            pnlEditor.Controls.Add(lbSelectedRoomNumber);
            pnlEditor.Controls.Add(lbRoomDetailsTitle);
            pnlEditor.Location = new Point(1370, 10);
            pnlEditor.Name = "pnlEditor";
            pnlEditor.Size = new Size(355, 610);
            pnlEditor.TabIndex = 6;
            // 
            // btnSaveRoomStatus
            // 
            btnSaveRoomStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSaveRoomStatus.BackColor = SystemColors.ButtonFace;
            btnSaveRoomStatus.FlatStyle = FlatStyle.Flat;
            btnSaveRoomStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveRoomStatus.Location = new Point(15, 550);
            btnSaveRoomStatus.Name = "btnSaveRoomStatus";
            btnSaveRoomStatus.Size = new Size(320, 45);
            btnSaveRoomStatus.TabIndex = 10;
            btnSaveRoomStatus.Text = "Update Status and Save";
            btnSaveRoomStatus.UseVisualStyleBackColor = false;
            btnSaveRoomStatus.Click += btnSaveRoomStatus_Click;
            // 
            // tbMaintenanceNotes
            // 
            tbMaintenanceNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbMaintenanceNotes.Location = new Point(15, 232);
            tbMaintenanceNotes.Multiline = true;
            tbMaintenanceNotes.Name = "tbMaintenanceNotes";
            tbMaintenanceNotes.ScrollBars = ScrollBars.Vertical;
            tbMaintenanceNotes.Size = new Size(320, 240);
            tbMaintenanceNotes.TabIndex = 9;
            // 
            // lbMaintenanceNotesTitle
            // 
            lbMaintenanceNotesTitle.AutoSize = true;
            lbMaintenanceNotesTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbMaintenanceNotesTitle.Location = new Point(15, 210);
            lbMaintenanceNotesTitle.Name = "lbMaintenanceNotesTitle";
            lbMaintenanceNotesTitle.Size = new Size(198, 19);
            lbMaintenanceNotesTitle.TabIndex = 8;
            lbMaintenanceNotesTitle.Text = "Maintenance / Defect Notes:";
            // 
            // cbAssignCleaner
            // 
            cbAssignCleaner.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAssignCleaner.FormattingEnabled = true;
            cbAssignCleaner.Items.AddRange(new object[] { "Unassigned" });
            cbAssignCleaner.Location = new Point(15, 167);
            cbAssignCleaner.Name = "cbAssignCleaner";
            cbAssignCleaner.Size = new Size(320, 25);
            cbAssignCleaner.TabIndex = 5;
            // 
            // lbAssignCleanerTitle
            // 
            lbAssignCleanerTitle.AutoSize = true;
            lbAssignCleanerTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbAssignCleanerTitle.Location = new Point(15, 145);
            lbAssignCleanerTitle.Name = "lbAssignCleanerTitle";
            lbAssignCleanerTitle.Size = new Size(150, 19);
            lbAssignCleanerTitle.TabIndex = 4;
            lbAssignCleanerTitle.Text = "Assign Housekeeper:";
            // 
            // cbSetStatus
            // 
            cbSetStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSetStatus.FormattingEnabled = true;
            cbSetStatus.Items.AddRange(new object[] { "Dirty", "In Progress", "Clean" });
            cbSetStatus.Location = new Point(15, 102);
            cbSetStatus.Name = "cbSetStatus";
            cbSetStatus.Size = new Size(320, 25);
            cbSetStatus.TabIndex = 3;
            // 
            // lbSetStatusTitle
            // 
            lbSetStatusTitle.AutoSize = true;
            lbSetStatusTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbSetStatusTitle.Location = new Point(15, 80);
            lbSetStatusTitle.Name = "lbSetStatusTitle";
            lbSetStatusTitle.Size = new Size(115, 19);
            lbSetStatusTitle.TabIndex = 2;
            lbSetStatusTitle.Text = "Cleaning Status:";
            // 
            // lbSelectedRoomValue
            // 
            lbSelectedRoomValue.AutoSize = true;
            lbSelectedRoomValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbSelectedRoomValue.ForeColor = Color.Black;
            lbSelectedRoomValue.Location = new Point(100, 40);
            lbSelectedRoomValue.Name = "lbSelectedRoomValue";
            lbSelectedRoomValue.Size = new Size(28, 21);
            lbSelectedRoomValue.TabIndex = 1;
            lbSelectedRoomValue.Text = "---";
            // 
            // lbSelectedRoomNumber
            // 
            lbSelectedRoomNumber.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbSelectedRoomNumber.ForeColor = Color.Black;
            lbSelectedRoomNumber.Location = new Point(15, 40);
            lbSelectedRoomNumber.Name = "lbSelectedRoomNumber";
            lbSelectedRoomNumber.Size = new Size(79, 21);
            lbSelectedRoomNumber.TabIndex = 1;
            lbSelectedRoomNumber.Text = "Selected: ";
            // 
            // lbRoomDetailsTitle
            // 
            lbRoomDetailsTitle.AutoSize = true;
            lbRoomDetailsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbRoomDetailsTitle.ForeColor = Color.FromArgb(24, 60, 142);
            lbRoomDetailsTitle.Location = new Point(15, 12);
            lbRoomDetailsTitle.Name = "lbRoomDetailsTitle";
            lbRoomDetailsTitle.Size = new Size(175, 20);
            lbRoomDetailsTitle.TabIndex = 0;
            lbRoomDetailsTitle.Text = "UPDATE ROOM STATUS";
            // 
            // HousekeepingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(pnlEditor);
            Controls.Add(pnlGrid);
            Controls.Add(pnlKpiMaintenance);
            Controls.Add(pnlKpiClean);
            Controls.Add(pnlKpiProgress);
            Controls.Add(pnlKpiDirty);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 9.75F);
            Name = "HousekeepingControl";
            Size = new Size(1740, 639);
            Load += HousekeepingControl_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlKpiDirty.ResumeLayout(false);
            pnlKpiDirty.PerformLayout();
            pnlKpiProgress.ResumeLayout(false);
            pnlKpiProgress.PerformLayout();
            pnlKpiClean.ResumeLayout(false);
            pnlKpiClean.PerformLayout();
            pnlKpiMaintenance.ResumeLayout(false);
            pnlKpiMaintenance.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlEditor.ResumeLayout(false);
            pnlEditor.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lbFilter;
        private Label lbRoomSearch;
        private TextBox txtRoomSearch;
        private Label lbFloorFilter;
        private ComboBox cbFloorFilter;
        private Label lbStatusFilter;
        private ComboBox cbStatusFilter;
        private Button btnSearch;
        private Label lbUtility;
        private Button btnRefresh;
        private Button btnMarkAllClean;

        private Panel pnlKpiDirty;
        private Label lbKpiDirtyTitle;
        private Label lbKpiDirtyValue;
        private Label lbKpiDirtySub;

        private Panel pnlKpiProgress;
        private Label lbKpiProgressTitle;
        private Label lbKpiProgressValue;
        private Label lbKpiProgressSub;

        private Panel pnlKpiClean;
        private Label lbKpiCleanTitle;
        private Label lbKpiCleanValue;
        private Label lbKpiCleanSub;

        private Panel pnlKpiMaintenance;
        private Label lbKpiStaffTitle;
        private Label lbKpiStaffValue;
        private Label lbKpiStaffSub;

        private Panel pnlGrid;
        private DataGridView dgvRooms;

        private Panel pnlEditor;
        private Label lbRoomDetailsTitle;
        private Label lbSelectedRoomNumber;
        private Label lbSetStatusTitle;
        private ComboBox cbSetStatus;
        private Label lbAssignCleanerTitle;
        private ComboBox cbAssignCleaner;
        private Label lbMaintenanceNotesTitle;
        private TextBox tbMaintenanceNotes;
        private Button btnSaveRoomStatus;
        private DataGridViewTextBoxColumn colRoomId;
        private DataGridViewTextBoxColumn colRoomNumber;
        private DataGridViewTextBoxColumn colFloor;
        private DataGridViewTextBoxColumn colRoomType;
        private DataGridViewTextBoxColumn colCurrentStatus;
        private DataGridViewTextBoxColumn colCleaningStatus;
        private DataGridViewTextBoxColumn colDisturb;
        private DataGridViewTextBoxColumn colIsCleaning;
        private Label lbSelectedRoomValue;
        private Label lbPrioColor;
        private Panel panel1;
        private Label lbPrioTitle;
        private CheckBox cbColorCodes;
        private Label lbUnderMaintenanceColor;
        private Label lbUnderMaintenanceTitle;
        private Label lbNeedsCleaningColor;
        private Label lbNeedsCleaningTitle;
        private Label lbCleanColor;
        private Label lbCleanTitle;
    }
}