namespace Hotel_erp_Winforms_App.UI.Controls.Rooms
{
    partial class RoomsControl
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
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            btnDeleteRoom = new Button();
            btnNewRoom = new Button();
            btnRefresh = new Button();
            lbUtility = new Label();
            btnSearch = new Button();
            cbStatusFilter = new ComboBox();
            lbStatusFilter = new Label();
            cbTypeFilter = new ComboBox();
            lbTypeFilter = new Label();
            txtSearch = new TextBox();
            lbSearch = new Label();
            lbFilter = new Label();
            pnlKpiTotal = new Panel();
            lbKpiTotalSub = new Label();
            lbKpiTotalValue = new Label();
            lbKpiTotalTitle = new Label();
            pnlKpiAvailable = new Panel();
            lbKpiAvailableSub = new Label();
            lbKpiAvailableValue = new Label();
            lbKpiAvailableTitle = new Label();
            pnlKpiOccupied = new Panel();
            lbKpiOccupiedSub = new Label();
            lbKpiOccupiedValue = new Label();
            lbKpiOccupiedTitle = new Label();
            pnlKpiMaintenance = new Panel();
            lbKpiMaintenanceSub = new Label();
            lbKpiMaintenanceValue = new Label();
            lbKpiMaintenanceTitle = new Label();
            pnlGrid = new Panel();
            dgvRooms = new DataGridView();
            colRoomNumber = new DataGridViewTextBoxColumn();
            colRoomType = new DataGridViewTextBoxColumn();
            colFloorSpace = new DataGridViewTextBoxColumn();
            colBedType = new DataGridViewTextBoxColumn();
            colBalcony = new DataGridViewTextBoxColumn();
            colView = new DataGridViewTextBoxColumn();
            colMaxAdults = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            pnlEditor = new Panel();
            btnSaveRoom = new Button();
            tbAcTemp = new TextBox();
            lbAcTempTitle = new Label();
            tbExtras = new TextBox();
            lbExtrasTitle = new Label();
            chkBalcony = new CheckBox();
            cbView = new ComboBox();
            lbViewTitle = new Label();
            cbStatus = new ComboBox();
            lbStatusTitle = new Label();
            tbPrice = new TextBox();
            lbPriceTitle = new Label();
            tbMaxAdults = new TextBox();
            lbMaxAdultsTitle = new Label();
            tbFloorSpace = new TextBox();
            lbFloorSpaceTitle = new Label();
            cbBedType = new ComboBox();
            lbBedTypeTitle = new Label();
            cbRoomType = new ComboBox();
            lbRoomTypeTitle = new Label();
            tbRoomNumber = new TextBox();
            lbRoomNumberTitle = new Label();
            lbEditorTitle = new Label();
            pnlTop.SuspendLayout();
            pnlKpiTotal.SuspendLayout();
            pnlKpiAvailable.SuspendLayout();
            pnlKpiOccupied.SuspendLayout();
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
            pnlTop.Controls.Add(btnDeleteRoom);
            pnlTop.Controls.Add(btnNewRoom);
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Controls.Add(lbUtility);
            pnlTop.Controls.Add(btnSearch);
            pnlTop.Controls.Add(cbStatusFilter);
            pnlTop.Controls.Add(lbStatusFilter);
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
            // btnDeleteRoom
            // 
            btnDeleteRoom.BackColor = SystemColors.ButtonFace;
            btnDeleteRoom.FlatStyle = FlatStyle.Flat;
            btnDeleteRoom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDeleteRoom.ForeColor = Color.DarkRed;
            btnDeleteRoom.Location = new Point(1220, 33);
            btnDeleteRoom.Name = "btnDeleteRoom";
            btnDeleteRoom.Size = new Size(110, 30);
            btnDeleteRoom.TabIndex = 6;
            btnDeleteRoom.Text = "Delete Room";
            btnDeleteRoom.UseVisualStyleBackColor = false;
            btnDeleteRoom.Click += btnDeleteRoom_Click;
            // 
            // btnNewRoom
            // 
            btnNewRoom.BackColor = SystemColors.ButtonFace;
            btnNewRoom.FlatStyle = FlatStyle.Flat;
            btnNewRoom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNewRoom.ForeColor = Color.DarkGreen;
            btnNewRoom.Location = new Point(1085, 33);
            btnNewRoom.Name = "btnNewRoom";
            btnNewRoom.Size = new Size(125, 30);
            btnNewRoom.TabIndex = 4;
            btnNewRoom.Text = "+ Add Room";
            btnNewRoom.UseVisualStyleBackColor = false;
            btnNewRoom.Click += btnNewRoom_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ButtonFace;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.Location = new Point(975, 33);
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
            lbUtility.Location = new Point(975, 10);
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
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Filter";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // cbStatusFilter
            // 
            cbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatusFilter.FormattingEnabled = true;
            cbStatusFilter.Items.AddRange(new object[] { "All Statuses", "Available", "Occupied", "Unavailable", "Under Maintenance" });
            cbStatusFilter.Location = new Point(395, 35);
            cbStatusFilter.Name = "cbStatusFilter";
            cbStatusFilter.Size = new Size(150, 25);
            cbStatusFilter.TabIndex = 1;
            // 
            // lbStatusFilter
            // 
            lbStatusFilter.AutoSize = true;
            lbStatusFilter.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbStatusFilter.Location = new Point(345, 38);
            lbStatusFilter.Name = "lbStatusFilter";
            lbStatusFilter.Size = new Size(50, 17);
            lbStatusFilter.TabIndex = 5;
            lbStatusFilter.Text = "Status:";
            // 
            // cbTypeFilter
            // 
            cbTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTypeFilter.FormattingEnabled = true;
            cbTypeFilter.Items.AddRange(new object[] { "All Types", "Standard", "Deluxe", "Suite" });
            cbTypeFilter.Location = new Point(205, 35);
            cbTypeFilter.Name = "cbTypeFilter";
            cbTypeFilter.Size = new Size(125, 25);
            cbTypeFilter.TabIndex = 1;
            // 
            // lbTypeFilter
            // 
            lbTypeFilter.AutoSize = true;
            lbTypeFilter.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbTypeFilter.Location = new Point(160, 38);
            lbTypeFilter.Name = "lbTypeFilter";
            lbTypeFilter.Size = new Size(41, 17);
            lbTypeFilter.TabIndex = 3;
            lbTypeFilter.Text = "Type:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(65, 35);
            txtSearch.MaxLength = 3;
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Room #";
            txtSearch.Size = new Size(80, 25);
            txtSearch.TabIndex = 0;
            // 
            // lbSearch
            // 
            lbSearch.AutoSize = true;
            lbSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbSearch.Location = new Point(15, 38);
            lbSearch.Name = "lbSearch";
            lbSearch.Size = new Size(48, 17);
            lbSearch.TabIndex = 1;
            lbSearch.Text = "Room:";
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
            lbKpiTotalSub.Size = new Size(119, 15);
            lbKpiTotalSub.TabIndex = 2;
            lbKpiTotalSub.Text = "Total inventory count";
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
            lbKpiTotalTitle.Size = new Size(90, 15);
            lbKpiTotalTitle.TabIndex = 0;
            lbKpiTotalTitle.Text = "TOTAL ROOMS";
            // 
            // pnlKpiAvailable
            // 
            pnlKpiAvailable.BackColor = Color.White;
            pnlKpiAvailable.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiAvailable.Controls.Add(lbKpiAvailableSub);
            pnlKpiAvailable.Controls.Add(lbKpiAvailableValue);
            pnlKpiAvailable.Controls.Add(lbKpiAvailableTitle);
            pnlKpiAvailable.Location = new Point(350, 95);
            pnlKpiAvailable.Name = "pnlKpiAvailable";
            pnlKpiAvailable.Size = new Size(325, 85);
            pnlKpiAvailable.TabIndex = 2;
            // 
            // lbKpiAvailableSub
            // 
            lbKpiAvailableSub.AutoSize = true;
            lbKpiAvailableSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiAvailableSub.ForeColor = Color.Gray;
            lbKpiAvailableSub.Location = new Point(12, 60);
            lbKpiAvailableSub.Name = "lbKpiAvailableSub";
            lbKpiAvailableSub.Size = new Size(118, 15);
            lbKpiAvailableSub.TabIndex = 2;
            lbKpiAvailableSub.Text = "Ready for reservation";
            // 
            // lbKpiAvailableValue
            // 
            lbKpiAvailableValue.AutoSize = true;
            lbKpiAvailableValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiAvailableValue.ForeColor = Color.DarkGreen;
            lbKpiAvailableValue.Location = new Point(10, 27);
            lbKpiAvailableValue.Name = "lbKpiAvailableValue";
            lbKpiAvailableValue.Size = new Size(28, 32);
            lbKpiAvailableValue.TabIndex = 1;
            lbKpiAvailableValue.Text = "0";
            // 
            // lbKpiAvailableTitle
            // 
            lbKpiAvailableTitle.AutoSize = true;
            lbKpiAvailableTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiAvailableTitle.ForeColor = Color.DimGray;
            lbKpiAvailableTitle.Location = new Point(12, 10);
            lbKpiAvailableTitle.Name = "lbKpiAvailableTitle";
            lbKpiAvailableTitle.Size = new Size(67, 15);
            lbKpiAvailableTitle.TabIndex = 0;
            lbKpiAvailableTitle.Text = "AVAILABLE";
            // 
            // pnlKpiOccupied
            // 
            pnlKpiOccupied.BackColor = Color.White;
            pnlKpiOccupied.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiOccupied.Controls.Add(lbKpiOccupiedSub);
            pnlKpiOccupied.Controls.Add(lbKpiOccupiedValue);
            pnlKpiOccupied.Controls.Add(lbKpiOccupiedTitle);
            pnlKpiOccupied.Location = new Point(690, 95);
            pnlKpiOccupied.Name = "pnlKpiOccupied";
            pnlKpiOccupied.Size = new Size(325, 85);
            pnlKpiOccupied.TabIndex = 3;
            // 
            // lbKpiOccupiedSub
            // 
            lbKpiOccupiedSub.AutoSize = true;
            lbKpiOccupiedSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiOccupiedSub.ForeColor = Color.Gray;
            lbKpiOccupiedSub.Location = new Point(12, 60);
            lbKpiOccupiedSub.Name = "lbKpiOccupiedSub";
            lbKpiOccupiedSub.Size = new Size(128, 15);
            lbKpiOccupiedSub.TabIndex = 2;
            lbKpiOccupiedSub.Text = "Active stays / Assigned";
            // 
            // lbKpiOccupiedValue
            // 
            lbKpiOccupiedValue.AutoSize = true;
            lbKpiOccupiedValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiOccupiedValue.ForeColor = Color.DarkOrange;
            lbKpiOccupiedValue.Location = new Point(10, 27);
            lbKpiOccupiedValue.Name = "lbKpiOccupiedValue";
            lbKpiOccupiedValue.Size = new Size(28, 32);
            lbKpiOccupiedValue.TabIndex = 1;
            lbKpiOccupiedValue.Text = "0";
            // 
            // lbKpiOccupiedTitle
            // 
            lbKpiOccupiedTitle.AutoSize = true;
            lbKpiOccupiedTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiOccupiedTitle.ForeColor = Color.DimGray;
            lbKpiOccupiedTitle.Location = new Point(12, 10);
            lbKpiOccupiedTitle.Name = "lbKpiOccupiedTitle";
            lbKpiOccupiedTitle.Size = new Size(125, 15);
            lbKpiOccupiedTitle.TabIndex = 0;
            lbKpiOccupiedTitle.Text = "OCCUPIED / BOOKED";
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
            // lbKpiMaintenanceSub
            // 
            lbKpiMaintenanceSub.AutoSize = true;
            lbKpiMaintenanceSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiMaintenanceSub.ForeColor = Color.Gray;
            lbKpiMaintenanceSub.Location = new Point(12, 60);
            lbKpiMaintenanceSub.Name = "lbKpiMaintenanceSub";
            lbKpiMaintenanceSub.Size = new Size(117, 15);
            lbKpiMaintenanceSub.TabIndex = 2;
            lbKpiMaintenanceSub.Text = "Defect / Out of order";
            // 
            // lbKpiMaintenanceValue
            // 
            lbKpiMaintenanceValue.AutoSize = true;
            lbKpiMaintenanceValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiMaintenanceValue.ForeColor = Color.Firebrick;
            lbKpiMaintenanceValue.Location = new Point(10, 27);
            lbKpiMaintenanceValue.Name = "lbKpiMaintenanceValue";
            lbKpiMaintenanceValue.Size = new Size(28, 32);
            lbKpiMaintenanceValue.TabIndex = 1;
            lbKpiMaintenanceValue.Text = "0";
            // 
            // lbKpiMaintenanceTitle
            // 
            lbKpiMaintenanceTitle.AutoSize = true;
            lbKpiMaintenanceTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiMaintenanceTitle.ForeColor = Color.DimGray;
            lbKpiMaintenanceTitle.Location = new Point(12, 10);
            lbKpiMaintenanceTitle.Name = "lbKpiMaintenanceTitle";
            lbKpiMaintenanceTitle.Size = new Size(135, 15);
            lbKpiMaintenanceTitle.TabIndex = 0;
            lbKpiMaintenanceTitle.Text = "UNDER MAINTENANCE";
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
            dgvRooms.AllowUserToOrderColumns = true;
            dgvRooms.AllowUserToResizeColumns = false;
            dgvRooms.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 248, 253);
            dgvRooms.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRooms.BackgroundColor = Color.White;
            dgvRooms.BorderStyle = BorderStyle.None;
            dgvRooms.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvRooms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvRooms.ColumnHeadersHeight = 40;
            dgvRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRooms.Columns.AddRange(new DataGridViewColumn[] { colRoomNumber, colRoomType, colFloorSpace, colBedType, colBalcony, colView, colMaxAdults, colStatus, colPrice });
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = SystemColors.Window;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle10.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            dgvRooms.DefaultCellStyle = dataGridViewCellStyle10;
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
            dgvRooms.Size = new Size(1350, 430);
            dgvRooms.TabIndex = 0;
            dgvRooms.CellClick += dgvRooms_CellClick;
            // 
            // colRoomNumber
            // 
            colRoomNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoomNumber.DataPropertyName = "Room_number";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colRoomNumber.DefaultCellStyle = dataGridViewCellStyle3;
            colRoomNumber.FillWeight = 10F;
            colRoomNumber.HeaderText = "Room #";
            colRoomNumber.Name = "colRoomNumber";
            colRoomNumber.ReadOnly = true;
            // 
            // colRoomType
            // 
            colRoomType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoomType.DataPropertyName = "RoomsRoomtype";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colRoomType.DefaultCellStyle = dataGridViewCellStyle4;
            colRoomType.FillWeight = 13F;
            colRoomType.HeaderText = "Room Type";
            colRoomType.Name = "colRoomType";
            colRoomType.ReadOnly = true;
            // 
            // colFloorSpace
            // 
            colFloorSpace.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFloorSpace.DataPropertyName = "FloorSpace";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colFloorSpace.DefaultCellStyle = dataGridViewCellStyle5;
            colFloorSpace.FillWeight = 10F;
            colFloorSpace.HeaderText = "Size (m²)";
            colFloorSpace.Name = "colFloorSpace";
            colFloorSpace.ReadOnly = true;
            // 
            // colBedType
            // 
            colBedType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBedType.DataPropertyName = "RoomsBedType";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colBedType.DefaultCellStyle = dataGridViewCellStyle6;
            colBedType.FillWeight = 12F;
            colBedType.HeaderText = "Bed Type";
            colBedType.Name = "colBedType";
            colBedType.ReadOnly = true;
            // 
            // colBalcony
            // 
            colBalcony.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBalcony.DataPropertyName = "HasBalcony";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colBalcony.DefaultCellStyle = dataGridViewCellStyle7;
            colBalcony.FillWeight = 10F;
            colBalcony.HeaderText = "Balcony";
            colBalcony.Name = "colBalcony";
            colBalcony.ReadOnly = true;
            // 
            // colView
            // 
            colView.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colView.DataPropertyName = "RoomsView";
            colView.FillWeight = 12F;
            colView.HeaderText = "View";
            colView.Name = "colView";
            colView.ReadOnly = true;
            // 
            // colMaxAdults
            // 
            colMaxAdults.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMaxAdults.DataPropertyName = "MaxAdults";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colMaxAdults.DefaultCellStyle = dataGridViewCellStyle8;
            colMaxAdults.FillWeight = 10F;
            colMaxAdults.HeaderText = "Max Adults";
            colMaxAdults.Name = "colMaxAdults";
            colMaxAdults.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colStatus.DataPropertyName = "CurrentStatus";
            colStatus.FillWeight = 13F;
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colPrice
            // 
            colPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPrice.DataPropertyName = "Price";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "C0";
            colPrice.DefaultCellStyle = dataGridViewCellStyle9;
            colPrice.FillWeight = 13F;
            colPrice.HeaderText = "Price / Night";
            colPrice.Name = "colPrice";
            colPrice.ReadOnly = true;
            // 
            // pnlEditor
            // 
            pnlEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlEditor.BorderStyle = BorderStyle.FixedSingle;
            pnlEditor.Controls.Add(btnSaveRoom);
            pnlEditor.Controls.Add(tbAcTemp);
            pnlEditor.Controls.Add(lbAcTempTitle);
            pnlEditor.Controls.Add(tbExtras);
            pnlEditor.Controls.Add(lbExtrasTitle);
            pnlEditor.Controls.Add(chkBalcony);
            pnlEditor.Controls.Add(cbView);
            pnlEditor.Controls.Add(lbViewTitle);
            pnlEditor.Controls.Add(cbStatus);
            pnlEditor.Controls.Add(lbStatusTitle);
            pnlEditor.Controls.Add(tbPrice);
            pnlEditor.Controls.Add(lbPriceTitle);
            pnlEditor.Controls.Add(tbMaxAdults);
            pnlEditor.Controls.Add(lbMaxAdultsTitle);
            pnlEditor.Controls.Add(tbFloorSpace);
            pnlEditor.Controls.Add(lbFloorSpaceTitle);
            pnlEditor.Controls.Add(cbBedType);
            pnlEditor.Controls.Add(lbBedTypeTitle);
            pnlEditor.Controls.Add(cbRoomType);
            pnlEditor.Controls.Add(lbRoomTypeTitle);
            pnlEditor.Controls.Add(tbRoomNumber);
            pnlEditor.Controls.Add(lbRoomNumberTitle);
            pnlEditor.Controls.Add(lbEditorTitle);
            pnlEditor.Location = new Point(1370, 10);
            pnlEditor.Name = "pnlEditor";
            pnlEditor.Size = new Size(355, 610);
            pnlEditor.TabIndex = 6;
            // 
            // btnSaveRoom
            // 
            btnSaveRoom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSaveRoom.BackColor = SystemColors.ButtonFace;
            btnSaveRoom.FlatStyle = FlatStyle.Flat;
            btnSaveRoom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveRoom.ForeColor = Color.DarkGreen;
            btnSaveRoom.Location = new Point(15, 548);
            btnSaveRoom.Name = "btnSaveRoom";
            btnSaveRoom.Size = new Size(320, 45);
            btnSaveRoom.TabIndex = 11;
            btnSaveRoom.Text = "Save Room Details";
            btnSaveRoom.UseVisualStyleBackColor = false;
            btnSaveRoom.Click += btnSaveRoom_Click;
            // 
            // tbAcTemp
            // 
            tbAcTemp.Location = new Point(180, 395);
            tbAcTemp.Name = "tbAcTemp";
            tbAcTemp.PlaceholderText = "22";
            tbAcTemp.Size = new Size(155, 25);
            tbAcTemp.TabIndex = 9;
            // 
            // lbAcTempTitle
            // 
            lbAcTempTitle.AutoSize = true;
            lbAcTempTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbAcTempTitle.Location = new Point(180, 375);
            lbAcTempTitle.Name = "lbAcTempTitle";
            lbAcTempTitle.Size = new Size(94, 17);
            lbAcTempTitle.TabIndex = 22;
            lbAcTempTitle.Text = "AC Temp (°C):";
            // 
            // tbExtras
            // 
            tbExtras.Location = new Point(15, 450);
            tbExtras.Multiline = true;
            tbExtras.Name = "tbExtras";
            tbExtras.PlaceholderText = "jacuzzi, mini-bar, safe...";
            tbExtras.ScrollBars = ScrollBars.Vertical;
            tbExtras.Size = new Size(320, 80);
            tbExtras.TabIndex = 10;
            // 
            // lbExtrasTitle
            // 
            lbExtrasTitle.AutoSize = true;
            lbExtrasTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbExtrasTitle.Location = new Point(15, 430);
            lbExtrasTitle.Name = "lbExtrasTitle";
            lbExtrasTitle.Size = new Size(104, 17);
            lbExtrasTitle.TabIndex = 20;
            lbExtrasTitle.Text = "Room Features:";
            // 
            // chkBalcony
            // 
            chkBalcony.AutoSize = true;
            chkBalcony.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            chkBalcony.Location = new Point(15, 397);
            chkBalcony.Name = "chkBalcony";
            chkBalcony.Size = new Size(102, 21);
            chkBalcony.TabIndex = 8;
            chkBalcony.Text = "Has Balcony";
            chkBalcony.UseVisualStyleBackColor = true;
            // 
            // cbView
            // 
            cbView.DropDownStyle = ComboBoxStyle.DropDownList;
            cbView.FormattingEnabled = true;
            cbView.Items.AddRange(new object[] { "city", "garden", "panorama" });
            cbView.Location = new Point(180, 340);
            cbView.Name = "cbView";
            cbView.Size = new Size(155, 25);
            cbView.TabIndex = 7;
            // 
            // lbViewTitle
            // 
            lbViewTitle.AutoSize = true;
            lbViewTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbViewTitle.Location = new Point(180, 320);
            lbViewTitle.Name = "lbViewTitle";
            lbViewTitle.Size = new Size(42, 17);
            lbViewTitle.TabIndex = 16;
            lbViewTitle.Text = "View:";
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "available", "occupied", "unavailable", "under_maintenance" });
            cbStatus.Location = new Point(15, 340);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(155, 25);
            cbStatus.TabIndex = 6;
            // 
            // lbStatusTitle
            // 
            lbStatusTitle.AutoSize = true;
            lbStatusTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbStatusTitle.Location = new Point(15, 320);
            lbStatusTitle.Name = "lbStatusTitle";
            lbStatusTitle.Size = new Size(100, 17);
            lbStatusTitle.TabIndex = 14;
            lbStatusTitle.Text = "Current Status:";
            // 
            // tbPrice
            // 
            tbPrice.Location = new Point(180, 285);
            tbPrice.Name = "tbPrice";
            tbPrice.PlaceholderText = "25000";
            tbPrice.Size = new Size(155, 25);
            tbPrice.TabIndex = 5;
            // 
            // lbPriceTitle
            // 
            lbPriceTitle.AutoSize = true;
            lbPriceTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbPriceTitle.Location = new Point(180, 265);
            lbPriceTitle.Name = "lbPriceTitle";
            lbPriceTitle.Size = new Size(131, 17);
            lbPriceTitle.TabIndex = 12;
            lbPriceTitle.Text = "Price / Night (HUF):";
            // 
            // tbMaxAdults
            // 
            tbMaxAdults.Location = new Point(15, 285);
            tbMaxAdults.Name = "tbMaxAdults";
            tbMaxAdults.PlaceholderText = "2";
            tbMaxAdults.Size = new Size(155, 25);
            tbMaxAdults.TabIndex = 4;
            // 
            // lbMaxAdultsTitle
            // 
            lbMaxAdultsTitle.AutoSize = true;
            lbMaxAdultsTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbMaxAdultsTitle.Location = new Point(15, 265);
            lbMaxAdultsTitle.Name = "lbMaxAdultsTitle";
            lbMaxAdultsTitle.Size = new Size(82, 17);
            lbMaxAdultsTitle.TabIndex = 10;
            lbMaxAdultsTitle.Text = "Max Adults:";
            // 
            // tbFloorSpace
            // 
            tbFloorSpace.Location = new Point(180, 230);
            tbFloorSpace.Name = "tbFloorSpace";
            tbFloorSpace.PlaceholderText = "35";
            tbFloorSpace.Size = new Size(155, 25);
            tbFloorSpace.TabIndex = 3;
            // 
            // lbFloorSpaceTitle
            // 
            lbFloorSpaceTitle.AutoSize = true;
            lbFloorSpaceTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbFloorSpaceTitle.Location = new Point(180, 210);
            lbFloorSpaceTitle.Name = "lbFloorSpaceTitle";
            lbFloorSpaceTitle.Size = new Size(114, 17);
            lbFloorSpaceTitle.TabIndex = 8;
            lbFloorSpaceTitle.Text = "Floor Space (m²):";
            // 
            // cbBedType
            // 
            cbBedType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBedType.FormattingEnabled = true;
            cbBedType.Items.AddRange(new object[] { "single", "twin", "kingsize" });
            cbBedType.Location = new Point(15, 230);
            cbBedType.Name = "cbBedType";
            cbBedType.Size = new Size(155, 25);
            cbBedType.TabIndex = 2;
            // 
            // lbBedTypeTitle
            // 
            lbBedTypeTitle.AutoSize = true;
            lbBedTypeTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbBedTypeTitle.Location = new Point(15, 210);
            lbBedTypeTitle.Name = "lbBedTypeTitle";
            lbBedTypeTitle.Size = new Size(68, 17);
            lbBedTypeTitle.TabIndex = 6;
            lbBedTypeTitle.Text = "Bed Type:";
            // 
            // cbRoomType
            // 
            cbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRoomType.FormattingEnabled = true;
            cbRoomType.Items.AddRange(new object[] { "standard", "deluxe", "suite" });
            cbRoomType.Location = new Point(15, 175);
            cbRoomType.Name = "cbRoomType";
            cbRoomType.Size = new Size(320, 25);
            cbRoomType.TabIndex = 1;
            // 
            // lbRoomTypeTitle
            // 
            lbRoomTypeTitle.AutoSize = true;
            lbRoomTypeTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbRoomTypeTitle.Location = new Point(15, 155);
            lbRoomTypeTitle.Name = "lbRoomTypeTitle";
            lbRoomTypeTitle.Size = new Size(81, 17);
            lbRoomTypeTitle.TabIndex = 4;
            lbRoomTypeTitle.Text = "Room Type:";
            // 
            // tbRoomNumber
            // 
            tbRoomNumber.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            tbRoomNumber.Location = new Point(15, 75);
            tbRoomNumber.Name = "tbRoomNumber";
            tbRoomNumber.PlaceholderText = "101";
            tbRoomNumber.Size = new Size(320, 29);
            tbRoomNumber.TabIndex = 0;
            // 
            // lbRoomNumberTitle
            // 
            lbRoomNumberTitle.AutoSize = true;
            lbRoomNumberTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbRoomNumberTitle.Location = new Point(15, 50);
            lbRoomNumberTitle.Name = "lbRoomNumberTitle";
            lbRoomNumberTitle.Size = new Size(113, 19);
            lbRoomNumberTitle.TabIndex = 1;
            lbRoomNumberTitle.Text = "Room Number:";
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
            lbEditorTitle.Text = "ROOM CONFIG & DETAILS";
            // 
            // RoomsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(pnlEditor);
            Controls.Add(pnlGrid);
            Controls.Add(pnlKpiMaintenance);
            Controls.Add(pnlKpiOccupied);
            Controls.Add(pnlKpiAvailable);
            Controls.Add(pnlKpiTotal);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 9.75F);
            Name = "RoomsControl";
            Size = new Size(1740, 639);
            Load += RoomsControl_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlKpiTotal.ResumeLayout(false);
            pnlKpiTotal.PerformLayout();
            pnlKpiAvailable.ResumeLayout(false);
            pnlKpiAvailable.PerformLayout();
            pnlKpiOccupied.ResumeLayout(false);
            pnlKpiOccupied.PerformLayout();
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
        private Label lbSearch;
        private TextBox txtSearch;
        private Label lbTypeFilter;
        private ComboBox cbTypeFilter;
        private Label lbStatusFilter;
        private ComboBox cbStatusFilter;
        private Button btnSearch;
        private Label lbUtility;
        private Button btnRefresh;
        private Button btnNewRoom;
        private Button btnDeleteRoom;

        private Panel pnlKpiTotal;
        private Label lbKpiTotalTitle;
        private Label lbKpiTotalValue;
        private Label lbKpiTotalSub;

        private Panel pnlKpiAvailable;
        private Label lbKpiAvailableTitle;
        private Label lbKpiAvailableValue;
        private Label lbKpiAvailableSub;

        private Panel pnlKpiOccupied;
        private Label lbKpiOccupiedTitle;
        private Label lbKpiOccupiedValue;
        private Label lbKpiOccupiedSub;

        private Panel pnlKpiMaintenance;
        private Label lbKpiMaintenanceTitle;
        private Label lbKpiMaintenanceValue;
        private Label lbKpiMaintenanceSub;

        private Panel pnlGrid;
        private DataGridView dgvRooms;
        private DataGridViewTextBoxColumn colRoomNumber;
        private DataGridViewTextBoxColumn colRoomType;
        private DataGridViewTextBoxColumn colFloorSpace;
        private DataGridViewTextBoxColumn colBedType;
        private DataGridViewTextBoxColumn colBalcony;
        private DataGridViewTextBoxColumn colView;
        private DataGridViewTextBoxColumn colMaxAdults;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colPrice;

        private Panel pnlEditor;
        private Label lbEditorTitle;
        private Label lbRoomNumberTitle;
        private TextBox tbRoomNumber;
        private Label lbRoomTypeTitle;
        private ComboBox cbRoomType;
        private Label lbBedTypeTitle;
        private ComboBox cbBedType;
        private Label lbFloorSpaceTitle;
        private TextBox tbFloorSpace;
        private Label lbMaxAdultsTitle;
        private TextBox tbMaxAdults;
        private Label lbPriceTitle;
        private TextBox tbPrice;
        private Label lbStatusTitle;
        private ComboBox cbStatus;
        private Label lbViewTitle;
        private ComboBox cbView;
        private CheckBox chkBalcony;
        private Label lbExtrasTitle;
        private TextBox tbExtras;
        private Label lbAcTempTitle;
        private TextBox tbAcTemp;
        private Button btnSaveRoom;
    }
}