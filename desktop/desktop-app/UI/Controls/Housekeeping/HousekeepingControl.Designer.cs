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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            btnSearch = new Button();
            cbFloorFilter = new ComboBox();
            txtRoomSearch = new TextBox();
            lbFloorFilter = new Label();
            lbFilter = new Label();
            lbRoomSearch = new Label();
            lbStatusFilter = new Label();
            cbStatusFilter = new ComboBox();
            lbUtility = new Label();
            btnRefresh = new Button();
            btnMarkAllClean = new Button();
            pnlKpiDirty = new Panel();
            lbKpiDirtyTitle = new Label();
            lbKpiDirtyValue = new Label();
            lbKpiDirtySub = new Label();
            pnlKpiProgress = new Panel();
            lbKpiProgressTitle = new Label();
            lbKpiProgressValue = new Label();
            lbKpiProgressSub = new Label();
            pnlKpiClean = new Panel();
            lbKpiCleanTitle = new Label();
            lbKpiCleanValue = new Label();
            lbKpiCleanSub = new Label();
            pnlKpiMaintenance = new Panel();
            lbKpiMaintenanceTitle = new Label();
            lbKpiMaintenanceValue = new Label();
            lbKpiMaintenanceSub = new Label();
            pnlGrid = new Panel();
            dgvRooms = new DataGridView();
            colRoomId = new DataGridViewTextBoxColumn();
            colRoomNumber = new DataGridViewTextBoxColumn();
            colFloor = new DataGridViewTextBoxColumn();
            colRoomType = new DataGridViewTextBoxColumn();
            colCleaningStatus = new DataGridViewTextBoxColumn();
            colOccupancyStatus = new DataGridViewTextBoxColumn();
            colAssignedCleaner = new DataGridViewTextBoxColumn();
            colLastCleaned = new DataGridViewTextBoxColumn();
            pnlEditor = new Panel();
            lbRoomDetailsTitle = new Label();
            lbSelectedRoomNumber = new Label();
            lbSetStatusTitle = new Label();
            cbSetStatus = new ComboBox();
            lbAssignCleanerTitle = new Label();
            cbAssignCleaner = new ComboBox();
            lbPriorityTitle = new Label();
            chkHighPriority = new CheckBox();
            lbMaintenanceNotesTitle = new Label();
            tbMaintenanceNotes = new TextBox();
            btnSaveRoomStatus = new Button();
            pnlTop.SuspendLayout();
            pnlKpiDirty.SuspendLayout();
            pnlKpiProgress.SuspendLayout();
            pnlKpiClean.SuspendLayout();
            pnlKpiMaintenance.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
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
            // txtRoomSearch
            // 
            txtRoomSearch.Location = new Point(68, 35);
            txtRoomSearch.Name = "txtRoomSearch";
            txtRoomSearch.Size = new Size(100, 25);
            txtRoomSearch.TabIndex = 2;
            // 
            // lbFloorFilter
            // 
            lbFloorFilter.AutoSize = true;
            lbFloorFilter.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbFloorFilter.Location = new Point(185, 38);
            lbFloorFilter.Name = "lbFloorFilter";
            lbFloorFilter.Size = new Size(44, 17);
            lbFloorFilter.TabIndex = 3;
            lbFloorFilter.Text = "Floor:";
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
            // cbStatusFilter
            // 
            cbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatusFilter.FormattingEnabled = true;
            cbStatusFilter.Items.AddRange(new object[] { "All Statuses", "Dirty", "In Progress", "Clean", "Inspected", "Out of Service" });
            cbStatusFilter.Location = new Point(415, 35);
            cbStatusFilter.Name = "cbStatusFilter";
            cbStatusFilter.Size = new Size(130, 25);
            cbStatusFilter.TabIndex = 6;
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
            // 
            // lbUtility
            // 
            lbUtility.AutoSize = true;
            lbUtility.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbUtility.ForeColor = Color.DimGray;
            lbUtility.Location = new Point(1080, 10);
            lbUtility.Name = "lbUtility";
            lbUtility.Size = new Size(69, 19);
            lbUtility.TabIndex = 8;
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
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "Reload";
            btnRefresh.UseVisualStyleBackColor = false;
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
            // lbKpiDirtyTitle
            // 
            lbKpiDirtyTitle.AutoSize = true;
            lbKpiDirtyTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiDirtyTitle.ForeColor = Color.DimGray;
            lbKpiDirtyTitle.Location = new Point(12, 10);
            lbKpiDirtyTitle.Name = "lbKpiDirtyTitle";
            lbKpiDirtyTitle.Size = new Size(95, 15);
            lbKpiDirtyTitle.TabIndex = 0;
            lbKpiDirtyTitle.Text = "NEEDS CLEANING";
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
            // lbKpiDirtySub
            // 
            lbKpiDirtySub.AutoSize = true;
            lbKpiDirtySub.Font = new Font("Segoe UI", 8.5F);
            lbKpiDirtySub.ForeColor = Color.Gray;
            lbKpiDirtySub.Location = new Point(12, 60);
            lbKpiDirtySub.Name = "lbKpiDirtySub";
            lbKpiDirtySub.Size = new Size(131, 15);
            lbKpiDirtySub.TabIndex = 2;
            lbKpiDirtySub.Text = "Pending checkout/stayover";
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
            // lbKpiProgressTitle
            // 
            lbKpiProgressTitle.AutoSize = true;
            lbKpiProgressTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiProgressTitle.ForeColor = Color.DimGray;
            lbKpiProgressTitle.Location = new Point(12, 10);
            lbKpiProgressTitle.Name = "lbKpiProgressTitle";
            lbKpiProgressTitle.Size = new Size(89, 15);
            lbKpiProgressTitle.TabIndex = 0;
            lbKpiProgressTitle.Text = "IN PROGRESS";
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
            // lbKpiProgressSub
            // 
            lbKpiProgressSub.AutoSize = true;
            lbKpiProgressSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiProgressSub.ForeColor = Color.Gray;
            lbKpiProgressSub.Location = new Point(12, 60);
            lbKpiProgressSub.Name = "lbKpiProgressSub";
            lbKpiProgressSub.Size = new Size(130, 15);
            lbKpiProgressSub.TabIndex = 2;
            lbKpiProgressSub.Text = "Currently being cleaned";
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
            // lbKpiCleanTitle
            // 
            lbKpiCleanTitle.AutoSize = true;
            lbKpiCleanTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiCleanTitle.ForeColor = Color.DimGray;
            lbKpiCleanTitle.Location = new Point(12, 10);
            lbKpiCleanTitle.Name = "lbKpiCleanTitle";
            lbKpiCleanTitle.Size = new Size(100, 15);
            lbKpiCleanTitle.TabIndex = 0;
            lbKpiCleanTitle.Text = "CLEAN / READY";
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
            // lbKpiCleanSub
            // 
            lbKpiCleanSub.AutoSize = true;
            lbKpiCleanSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiCleanSub.ForeColor = Color.Gray;
            lbKpiCleanSub.Location = new Point(12, 60);
            lbKpiCleanSub.Name = "lbKpiCleanSub";
            lbKpiCleanSub.Size = new Size(125, 15);
            lbKpiCleanSub.TabIndex = 2;
            lbKpiCleanSub.Text = "Ready for guest check-in";
            // 
            // pnlKpiMaintenance
            // 
            pnlKpiMaintenance.BackColor = Color.White;
            pnlKpiMaintenance.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiMaintenance.Controls.Add(lbKpiMaintenanceSub);
            pnlKpiMaintenance.Controls.Add(lbKpiMaintenanceValue);
            pnlKpiMaintenance.Controls.Add(lbKpiMaintenanceTitle);
            pnlKpiMaintenance.Location = new Point(1035, 95);
            pnlKpiMaintenance.Name = "pnlKpiMaintenance";
            pnlKpiMaintenance.Size = new Size(325, 85);
            pnlKpiMaintenance.TabIndex = 4;
            // 
            // lbKpiMaintenanceTitle
            // 
            lbKpiMaintenanceTitle.AutoSize = true;
            lbKpiMaintenanceTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiMaintenanceTitle.ForeColor = Color.DimGray;
            lbKpiMaintenanceTitle.Location = new Point(12, 10);
            lbKpiMaintenanceTitle.Name = "lbKpiMaintenanceTitle";
            lbKpiMaintenanceTitle.Size = new Size(111, 15);
            lbKpiMaintenanceTitle.TabIndex = 0;
            lbKpiMaintenanceTitle.Text = "OUT OF SERVICE";
            // 
            // lbKpiMaintenanceValue
            // 
            lbKpiMaintenanceValue.AutoSize = true;
            lbKpiMaintenanceValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiMaintenanceValue.ForeColor = Color.Red;
            lbKpiMaintenanceValue.Location = new Point(10, 27);
            lbKpiMaintenanceValue.Name = "lbKpiMaintenanceValue";
            lbKpiMaintenanceValue.Size = new Size(28, 32);
            lbKpiMaintenanceValue.TabIndex = 1;
            lbKpiMaintenanceValue.Text = "0";
            // 
            // lbKpiMaintenanceSub
            // 
            lbKpiMaintenanceSub.AutoSize = true;
            lbKpiMaintenanceSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiMaintenanceSub.ForeColor = Color.Gray;
            lbKpiMaintenanceSub.Location = new Point(12, 60);
            lbKpiMaintenanceSub.Name = "lbKpiMaintenanceSub";
            lbKpiMaintenanceSub.Size = new Size(130, 15);
            lbKpiMaintenanceSub.TabIndex = 2;
            lbKpiMaintenanceSub.Text = "Under maintenance issue";
            // 
            // pnlGrid
            // 
            pnlGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlGrid.BackColor = Color.White;
            pnlGrid.Controls.Add(dgvRooms);
            pnlGrid.Location = new Point(10, 190);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new Size(1350, 430);
            pnlGrid.TabIndex = 5;
            // 
            // dgvRooms
            // 
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.AllowUserToDeleteRows = false;
            dgvRooms.BackgroundColor = Color.White;
            dgvRooms.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 60, 142);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(24, 60, 142);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRooms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRooms.ColumnHeadersHeight = 40;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRooms.Columns.AddRange(new DataGridViewColumn[] { colRoomId, colRoomNumber, colFloor, colRoomType, colCleaningStatus, colOccupancyStatus, colAssignedCleaner, colLastCleaned });
            dgvRooms.Dock = DockStyle.Fill;
            dgvRooms.EnableHeadersVisualStyles = false;
            dgvRooms.Location = new Point(0, 0);
            dgvRooms.MultiSelect = false;
            dgvRooms.Name = "dgvRooms";
            dgvRooms.ReadOnly = true;
            dgvRooms.RowHeadersVisible = false;
            dgvRooms.RowTemplate.Height = 35;
            dgvRooms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRooms.Size = new Size(1350, 430);
            dgvRooms.TabIndex = 0;
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
            colRoomNumber.FillWeight = 12F;
            colRoomNumber.HeaderText = "Room #";
            colRoomNumber.Name = "colRoomNumber";
            colRoomNumber.ReadOnly = true;
            // 
            // colFloor
            // 
            colFloor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFloor.FillWeight = 10F;
            colFloor.HeaderText = "Floor";
            colFloor.Name = "colFloor";
            colFloor.ReadOnly = true;
            // 
            // colRoomType
            // 
            colRoomType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoomType.FillWeight = 18F;
            colRoomType.HeaderText = "Room Type";
            colRoomType.Name = "colRoomType";
            colRoomType.ReadOnly = true;
            // 
            // colCleaningStatus
            // 
            colCleaningStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCleaningStatus.FillWeight = 15F;
            colCleaningStatus.HeaderText = "Clean Status";
            colCleaningStatus.Name = "colCleaningStatus";
            colCleaningStatus.ReadOnly = true;
            // 
            // colOccupancyStatus
            // 
            colOccupancyStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colOccupancyStatus.FillWeight = 15F;
            colOccupancyStatus.HeaderText = "Guest Status";
            colOccupancyStatus.Name = "colOccupancyStatus";
            colOccupancyStatus.ReadOnly = true;
            // 
            // colAssignedCleaner
            // 
            colAssignedCleaner.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colAssignedCleaner.FillWeight = 15F;
            colAssignedCleaner.HeaderText = "Assigned To";
            colAssignedCleaner.Name = "colAssignedCleaner";
            colAssignedCleaner.ReadOnly = true;
            // 
            // colLastCleaned
            // 
            colLastCleaned.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLastCleaned.FillWeight = 15F;
            colLastCleaned.HeaderText = "Last Updated";
            colLastCleaned.Name = "colLastCleaned";
            colLastCleaned.ReadOnly = true;
            // 
            // pnlEditor
            // 
            pnlEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlEditor.BorderStyle = BorderStyle.FixedSingle;
            pnlEditor.Controls.Add(btnSaveRoomStatus);
            pnlEditor.Controls.Add(tbMaintenanceNotes);
            pnlEditor.Controls.Add(lbMaintenanceNotesTitle);
            pnlEditor.Controls.Add(chkHighPriority);
            pnlEditor.Controls.Add(lbPriorityTitle);
            pnlEditor.Controls.Add(cbAssignCleaner);
            pnlEditor.Controls.Add(lbAssignCleanerTitle);
            pnlEditor.Controls.Add(cbSetStatus);
            pnlEditor.Controls.Add(lbSetStatusTitle);
            pnlEditor.Controls.Add(lbSelectedRoomNumber);
            pnlEditor.Controls.Add(lbRoomDetailsTitle);
            pnlEditor.Location = new Point(1370, 10);
            pnlEditor.Name = "pnlEditor";
            pnlEditor.Size = new Size(355, 610);
            pnlEditor.TabIndex = 6;
            // 
            // lbRoomDetailsTitle
            // 
            lbRoomDetailsTitle.AutoSize = true;
            lbRoomDetailsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbRoomDetailsTitle.ForeColor = Color.FromArgb(24, 60, 142);
            lbRoomDetailsTitle.Location = new Point(15, 12);
            lbRoomDetailsTitle.Name = "lbRoomDetailsTitle";
            lbRoomDetailsTitle.Size = new Size(174, 20);
            lbRoomDetailsTitle.TabIndex = 0;
            lbRoomDetailsTitle.Text = "UPDATE ROOM STATUS";
            // 
            // lbSelectedRoomNumber
            // 
            lbSelectedRoomNumber.AutoSize = true;
            lbSelectedRoomNumber.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbSelectedRoomNumber.ForeColor = Color.Black;
            lbSelectedRoomNumber.Location = new Point(15, 40);
            lbSelectedRoomNumber.Name = "lbSelectedRoomNumber";
            lbSelectedRoomNumber.Size = new Size(155, 21);
            lbSelectedRoomNumber.TabIndex = 1;
            lbSelectedRoomNumber.Text = "Selected: Room ---";
            // 
            // lbSetStatusTitle
            // 
            lbSetStatusTitle.AutoSize = true;
            lbSetStatusTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbSetStatusTitle.Location = new Point(15, 80);
            lbSetStatusTitle.Name = "lbSetStatusTitle";
            lbSetStatusTitle.Size = new Size(122, 19);
            lbSetStatusTitle.TabIndex = 2;
            lbSetStatusTitle.Text = "Cleaning Status:";
            // 
            // cbSetStatus
            // 
            cbSetStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSetStatus.FormattingEnabled = true;
            cbSetStatus.Items.AddRange(new object[] { "Dirty", "In Progress", "Clean", "Inspected", "Out of Service" });
            cbSetStatus.Location = new Point(15, 102);
            cbSetStatus.Name = "cbSetStatus";
            cbSetStatus.Size = new Size(320, 25);
            cbSetStatus.TabIndex = 3;
            // 
            // lbAssignCleanerTitle
            // 
            lbAssignCleanerTitle.AutoSize = true;
            lbAssignCleanerTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbAssignCleanerTitle.Location = new Point(15, 145);
            lbAssignCleanerTitle.Name = "lbAssignCleanerTitle";
            lbAssignCleanerTitle.Size = new Size(137, 19);
            lbAssignCleanerTitle.TabIndex = 4;
            lbAssignCleanerTitle.Text = "Assign Housekeeper:";
            // 
            // cbAssignCleaner
            // 
            cbAssignCleaner.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAssignCleaner.FormattingEnabled = true;
            cbAssignCleaner.Items.AddRange(new object[] { "Unassigned", "Anna Kovács", "Péter Nagy", "Katalin Szabó" });
            cbAssignCleaner.Location = new Point(15, 167);
            cbAssignCleaner.Name = "cbAssignCleaner";
            cbAssignCleaner.Size = new Size(320, 25);
            cbAssignCleaner.TabIndex = 5;
            // 
            // lbPriorityTitle
            // 
            lbPriorityTitle.AutoSize = true;
            lbPriorityTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbPriorityTitle.Location = new Point(15, 210);
            lbPriorityTitle.Name = "lbPriorityTitle";
            lbPriorityTitle.Size = new Size(65, 19);
            lbPriorityTitle.TabIndex = 6;
            lbPriorityTitle.Text = "Priority:";
            // 
            // chkHighPriority
            // 
            chkHighPriority.AutoSize = true;
            chkHighPriority.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            chkHighPriority.ForeColor = Color.DarkRed;
            chkHighPriority.Location = new Point(15, 232);
            chkHighPriority.Name = "chkHighPriority";
            chkHighPriority.Size = new Size(204, 21);
            chkHighPriority.TabIndex = 7;
            chkHighPriority.Text = "High Priority (VIP / Early Check-in)";
            chkHighPriority.UseVisualStyleBackColor = true;
            // 
            // lbMaintenanceNotesTitle
            // 
            lbMaintenanceNotesTitle.AutoSize = true;
            lbMaintenanceNotesTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbMaintenanceNotesTitle.Location = new Point(15, 275);
            lbMaintenanceNotesTitle.Name = "lbMaintenanceNotesTitle";
            lbMaintenanceNotesTitle.Size = new Size(205, 19);
            lbMaintenanceNotesTitle.TabIndex = 8;
            lbMaintenanceNotesTitle.Text = "Maintenance / Defect Notes:";
            // 
            // tbMaintenanceNotes
            // 
            tbMaintenanceNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbMaintenanceNotes.Location = new Point(15, 297);
            tbMaintenanceNotes.Multiline = true;
            tbMaintenanceNotes.Name = "tbMaintenanceNotes";
            tbMaintenanceNotes.ScrollBars = ScrollBars.Vertical;
            tbMaintenanceNotes.Size = new Size(320, 240);
            tbMaintenanceNotes.TabIndex = 9;
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
            btnSaveRoomStatus.Text = "Update Status & Save";
            btnSaveRoomStatus.UseVisualStyleBackColor = false;
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
        private Label lbKpiMaintenanceTitle;
        private Label lbKpiMaintenanceValue;
        private Label lbKpiMaintenanceSub;

        private Panel pnlGrid;
        private DataGridView dgvRooms;
        private DataGridViewTextBoxColumn colRoomId;
        private DataGridViewTextBoxColumn colRoomNumber;
        private DataGridViewTextBoxColumn colFloor;
        private DataGridViewTextBoxColumn colRoomType;
        private DataGridViewTextBoxColumn colCleaningStatus;
        private DataGridViewTextBoxColumn colOccupancyStatus;
        private DataGridViewTextBoxColumn colAssignedCleaner;
        private DataGridViewTextBoxColumn colLastCleaned;

        private Panel pnlEditor;
        private Label lbRoomDetailsTitle;
        private Label lbSelectedRoomNumber;
        private Label lbSetStatusTitle;
        private ComboBox cbSetStatus;
        private Label lbAssignCleanerTitle;
        private ComboBox cbAssignCleaner;
        private Label lbPriorityTitle;
        private CheckBox chkHighPriority;
        private Label lbMaintenanceNotesTitle;
        private TextBox tbMaintenanceNotes;
        private Button btnSaveRoomStatus;
    }
}