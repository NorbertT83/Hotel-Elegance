namespace Hotel_erp_Winforms_App.UI.Controls
{
    partial class StatisticsControl
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
            lbFilter = new Label();
            lbDateFrom = new Label();
            dtpFrom = new DateTimePicker();
            lbDateTo = new Label();
            dtpTo = new DateTimePicker();
            lbQuickDate = new Label();
            cbQuickDate = new ComboBox();
            btnApplyFilter = new Button();
            lbUtility = new Label();
            btnRefresh = new Button();
            btnExportPdf = new Button();
            pnlKpiOccupancy = new Panel();
            lbKpiOccupancyTitle = new Label();
            lbKpiOccupancyValue = new Label();
            lbKpiOccupancySub = new Label();
            pnlKpiRevPar = new Panel();
            lbKpiRevParTitle = new Label();
            lbKpiRevParValue = new Label();
            lbKpiRevParSub = new Label();
            pnlKpiTotalRev = new Panel();
            lbKpiTotalRevTitle = new Label();
            lbKpiTotalRevValue = new Label();
            lbKpiTotalRevSub = new Label();
            pnlKpiAdr = new Panel();
            lbKpiAdrTitle = new Label();
            lbKpiAdrValue = new Label();
            lbKpiAdrSub = new Label();
            pnlCharts = new Panel();
            lbRevenueTrendTitle = new Label();
            pnlRevenueChartPlaceholder = new Panel();
            lbChartPlaceholderText = new Label();
            dgvTopServices = new DataGridView();
            colServiceName = new DataGridViewTextBoxColumn();
            colServiceCategory = new DataGridViewTextBoxColumn();
            colServiceOrders = new DataGridViewTextBoxColumn();
            colServiceRevenue = new DataGridViewTextBoxColumn();
            lbTopServicesTitle = new Label();
            pnlSideDetails = new Panel();
            lbSideTitle = new Label();
            lbAlosTitle = new Label();
            lbAlosValue = new Label();
            lbCancellationTitle = new Label();
            lbCancellationValue = new Label();
            lbHousekeepingTitle = new Label();
            lbHousekeepingValue = new Label();
            lbDemographicsTitle = new Label();
            lbDemographicsValue = new Label();
            pnlTop.SuspendLayout();
            pnlKpiOccupancy.SuspendLayout();
            pnlKpiRevPar.SuspendLayout();
            pnlKpiTotalRev.SuspendLayout();
            pnlKpiAdr.SuspendLayout();
            pnlCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopServices).BeginInit();
            pnlSideDetails.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTop.BackColor = Color.FromArgb(245, 245, 248);
            pnlTop.BorderStyle = BorderStyle.FixedSingle;
            pnlTop.Controls.Add(btnExportPdf);
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Controls.Add(lbUtility);
            pnlTop.Controls.Add(btnApplyFilter);
            pnlTop.Controls.Add(cbQuickDate);
            pnlTop.Controls.Add(lbQuickDate);
            pnlTop.Controls.Add(dtpTo);
            pnlTop.Controls.Add(lbDateTo);
            pnlTop.Controls.Add(dtpFrom);
            pnlTop.Controls.Add(lbDateFrom);
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
            lbFilter.Size = new Size(111, 19);
            lbFilter.TabIndex = 0;
            lbFilter.Text = "PERIOD FILTER";
            // 
            // lbDateFrom
            // 
            lbDateFrom.AutoSize = true;
            lbDateFrom.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbDateFrom.Location = new Point(15, 38);
            lbDateFrom.Name = "lbDateFrom";
            lbDateFrom.Size = new Size(44, 17);
            lbDateFrom.TabIndex = 1;
            lbDateFrom.Text = "From:";
            // 
            // dtpFrom
            // 
            dtpFrom.Format = DateTimePickerFormat.Short;
            dtpFrom.Location = new Point(65, 35);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(120, 25);
            dtpFrom.TabIndex = 2;
            // 
            // lbDateTo
            // 
            lbDateTo.AutoSize = true;
            lbDateTo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbDateTo.Location = new Point(200, 38);
            lbDateTo.Name = "lbDateTo";
            lbDateTo.Size = new Size(27, 17);
            lbDateTo.TabIndex = 3;
            lbDateTo.Text = "To:";
            // 
            // dtpTo
            // 
            dtpTo.Format = DateTimePickerFormat.Short;
            dtpTo.Location = new Point(233, 35);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(120, 25);
            dtpTo.TabIndex = 4;
            // 
            // lbQuickDate
            // 
            lbQuickDate.AutoSize = true;
            lbQuickDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lbQuickDate.Location = new Point(370, 38);
            lbQuickDate.Name = "lbQuickDate";
            lbQuickDate.Size = new Size(48, 17);
            lbQuickDate.TabIndex = 5;
            lbQuickDate.Text = "Range:";
            // 
            // cbQuickDate
            // 
            cbQuickDate.DropDownStyle = ComboBoxStyle.DropDownList;
            cbQuickDate.FormattingEnabled = true;
            cbQuickDate.Items.AddRange(new object[] { "Today", "This Week", "This Month", "This Year", "Custom" });
            cbQuickDate.Location = new Point(424, 35);
            cbQuickDate.Name = "cbQuickDate";
            cbQuickDate.Size = new Size(130, 25);
            cbQuickDate.TabIndex = 6;
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.BackColor = SystemColors.ButtonFace;
            btnApplyFilter.FlatStyle = FlatStyle.Flat;
            btnApplyFilter.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnApplyFilter.Location = new Point(570, 31);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(100, 32);
            btnApplyFilter.TabIndex = 7;
            btnApplyFilter.Text = "Apply";
            btnApplyFilter.UseVisualStyleBackColor = false;
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
            btnRefresh.Text = "Reload Data";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnExportPdf
            // 
            btnExportPdf.BackColor = SystemColors.ButtonFace;
            btnExportPdf.FlatStyle = FlatStyle.Flat;
            btnExportPdf.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExportPdf.Location = new Point(1200, 33);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(120, 30);
            btnExportPdf.TabIndex = 10;
            btnExportPdf.Text = "Export PDF";
            btnExportPdf.UseVisualStyleBackColor = false;
            // 
            // pnlKpiOccupancy
            // 
            pnlKpiOccupancy.BackColor = Color.White;
            pnlKpiOccupancy.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiOccupancy.Controls.Add(lbKpiOccupancySub);
            pnlKpiOccupancy.Controls.Add(lbKpiOccupancyValue);
            pnlKpiOccupancy.Controls.Add(lbKpiOccupancyTitle);
            pnlKpiOccupancy.Location = new Point(10, 95);
            pnlKpiOccupancy.Name = "pnlKpiOccupancy";
            pnlKpiOccupancy.Size = new Size(325, 85);
            pnlKpiOccupancy.TabIndex = 1;
            // 
            // lbKpiOccupancyTitle
            // 
            lbKpiOccupancyTitle.AutoSize = true;
            lbKpiOccupancyTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiOccupancyTitle.ForeColor = Color.DimGray;
            lbKpiOccupancyTitle.Location = new Point(12, 10);
            lbKpiOccupancyTitle.Name = "lbKpiOccupancyTitle";
            lbKpiOccupancyTitle.Size = new Size(106, 15);
            lbKpiOccupancyTitle.TabIndex = 0;
            lbKpiOccupancyTitle.Text = "OCCUPANCY RATE";
            // 
            // lbKpiOccupancyValue
            // 
            lbKpiOccupancyValue.AutoSize = true;
            lbKpiOccupancyValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiOccupancyValue.ForeColor = Color.FromArgb(24, 60, 142);
            lbKpiOccupancyValue.Location = new Point(10, 27);
            lbKpiOccupancyValue.Name = "lbKpiOccupancyValue";
            lbKpiOccupancyValue.Size = new Size(76, 32);
            lbKpiOccupancyValue.TabIndex = 1;
            lbKpiOccupancyValue.Text = "0.0 %";
            // 
            // lbKpiOccupancySub
            // 
            lbKpiOccupancySub.AutoSize = true;
            lbKpiOccupancySub.Font = new Font("Segoe UI", 8.5F);
            lbKpiOccupancySub.ForeColor = Color.Gray;
            lbKpiOccupancySub.Location = new Point(12, 60);
            lbKpiOccupancySub.Name = "lbKpiOccupancySub";
            lbKpiOccupancySub.Size = new Size(116, 15);
            lbKpiOccupancySub.TabIndex = 2;
            lbKpiOccupancySub.Text = "0 of 0 rooms occupied";
            // 
            // pnlKpiRevPar
            // 
            pnlKpiRevPar.BackColor = Color.White;
            pnlKpiRevPar.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiRevPar.Controls.Add(lbKpiRevParSub);
            pnlKpiRevPar.Controls.Add(lbKpiRevParValue);
            pnlKpiRevPar.Controls.Add(lbKpiRevParTitle);
            pnlKpiRevPar.Location = new Point(350, 95);
            pnlKpiRevPar.Name = "pnlKpiRevPar";
            pnlKpiRevPar.Size = new Size(325, 85);
            pnlKpiRevPar.TabIndex = 2;
            // 
            // lbKpiRevParTitle
            // 
            lbKpiRevParTitle.AutoSize = true;
            lbKpiRevParTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiRevParTitle.ForeColor = Color.DimGray;
            lbKpiRevParTitle.Location = new Point(12, 10);
            lbKpiRevParTitle.Name = "lbKpiRevParTitle";
            lbKpiRevParTitle.Size = new Size(51, 15);
            lbKpiRevParTitle.TabIndex = 0;
            lbKpiRevParTitle.Text = "REVPAR";
            // 
            // lbKpiRevParValue
            // 
            lbKpiRevParValue.AutoSize = true;
            lbKpiRevParValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiRevParValue.ForeColor = Color.FromArgb(24, 60, 142);
            lbKpiRevParValue.Location = new Point(10, 27);
            lbKpiRevParValue.Name = "lbKpiRevParValue";
            lbKpiRevParValue.Size = new Size(77, 32);
            lbKpiRevParValue.TabIndex = 1;
            lbKpiRevParValue.Text = "0 HUF";
            // 
            // lbKpiRevParSub
            // 
            lbKpiRevParSub.AutoSize = true;
            lbKpiRevParSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiRevParSub.ForeColor = Color.Gray;
            lbKpiRevParSub.Location = new Point(12, 60);
            lbKpiRevParSub.Name = "lbKpiRevParSub";
            lbKpiRevParSub.Size = new Size(128, 15);
            lbKpiRevParSub.TabIndex = 2;
            lbKpiRevParSub.Text = "Revenue per avail. room";
            // 
            // pnlKpiTotalRev
            // 
            pnlKpiTotalRev.BackColor = Color.White;
            pnlKpiTotalRev.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiTotalRev.Controls.Add(lbKpiTotalRevSub);
            pnlKpiTotalRev.Controls.Add(lbKpiTotalRevValue);
            pnlKpiTotalRev.Controls.Add(lbKpiTotalRevTitle);
            pnlKpiTotalRev.Location = new Point(690, 95);
            pnlKpiTotalRev.Name = "pnlKpiTotalRev";
            pnlKpiTotalRev.Size = new Size(325, 85);
            pnlKpiTotalRev.TabIndex = 3;
            // 
            // lbKpiTotalRevTitle
            // 
            lbKpiTotalRevTitle.AutoSize = true;
            lbKpiTotalRevTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiTotalRevTitle.ForeColor = Color.DimGray;
            lbKpiTotalRevTitle.Location = new Point(12, 10);
            lbKpiTotalRevTitle.Name = "lbKpiTotalRevTitle";
            lbKpiTotalRevTitle.Size = new Size(99, 15);
            lbKpiTotalRevTitle.TabIndex = 0;
            lbKpiTotalRevTitle.Text = "TOTAL REVENUE";
            // 
            // lbKpiTotalRevValue
            // 
            lbKpiTotalRevValue.AutoSize = true;
            lbKpiTotalRevValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiTotalRevValue.ForeColor = Color.DarkGreen;
            lbKpiTotalRevValue.Location = new Point(10, 27);
            lbKpiTotalRevValue.Name = "lbKpiTotalRevValue";
            lbKpiTotalRevValue.Size = new Size(77, 32);
            lbKpiTotalRevValue.TabIndex = 1;
            lbKpiTotalRevValue.Text = "0 HUF";
            // 
            // lbKpiTotalRevSub
            // 
            lbKpiTotalRevSub.AutoSize = true;
            lbKpiTotalRevSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiTotalRevSub.ForeColor = Color.Gray;
            lbKpiTotalRevSub.Location = new Point(12, 60);
            lbKpiTotalRevSub.Name = "lbKpiTotalRevSub";
            lbKpiTotalRevSub.Size = new Size(129, 15);
            lbKpiTotalRevSub.TabIndex = 2;
            lbKpiTotalRevSub.Text = "Rooms + Extra services";
            // 
            // pnlKpiAdr
            // 
            pnlKpiAdr.BackColor = Color.White;
            pnlKpiAdr.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiAdr.Controls.Add(lbKpiAdrSub);
            pnlKpiAdr.Controls.Add(lbKpiAdrValue);
            pnlKpiAdr.Controls.Add(lbKpiAdrTitle);
            pnlKpiAdr.Location = new Point(1035, 95);
            pnlKpiAdr.Name = "pnlKpiAdr";
            pnlKpiAdr.Size = new Size(325, 85);
            pnlKpiAdr.TabIndex = 4;
            // 
            // lbKpiAdrTitle
            // 
            lbKpiAdrTitle.AutoSize = true;
            lbKpiAdrTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiAdrTitle.ForeColor = Color.DimGray;
            lbKpiAdrTitle.Location = new Point(12, 10);
            lbKpiAdrTitle.Name = "lbKpiAdrTitle";
            lbKpiAdrTitle.Size = new Size(130, 15);
            lbKpiAdrTitle.TabIndex = 0;
            lbKpiAdrTitle.Text = "ADR (AVG DAILY RATE)";
            // 
            // lbKpiAdrValue
            // 
            lbKpiAdrValue.AutoSize = true;
            lbKpiAdrValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbKpiAdrValue.ForeColor = Color.FromArgb(24, 60, 142);
            lbKpiAdrValue.Location = new Point(10, 27);
            lbKpiAdrValue.Name = "lbKpiAdrValue";
            lbKpiAdrValue.Size = new Size(77, 32);
            lbKpiAdrValue.TabIndex = 1;
            lbKpiAdrValue.Text = "0 HUF";
            // 
            // lbKpiAdrSub
            // 
            lbKpiAdrSub.AutoSize = true;
            lbKpiAdrSub.Font = new Font("Segoe UI", 8.5F);
            lbKpiAdrSub.ForeColor = Color.Gray;
            lbKpiAdrSub.Location = new Point(12, 60);
            lbKpiAdrSub.Name = "lbKpiAdrSub";
            lbKpiAdrSub.Size = new Size(132, 15);
            lbKpiAdrSub.TabIndex = 2;
            lbKpiAdrSub.Text = "Average sold room price";
            // 
            // pnlCharts
            // 
            pnlCharts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCharts.BackColor = Color.White;
            pnlCharts.BorderStyle = BorderStyle.FixedSingle;
            pnlCharts.Controls.Add(lbTopServicesTitle);
            pnlCharts.Controls.Add(dgvTopServices);
            pnlCharts.Controls.Add(pnlRevenueChartPlaceholder);
            pnlCharts.Controls.Add(lbRevenueTrendTitle);
            pnlCharts.Location = new Point(10, 190);
            pnlCharts.Name = "pnlCharts";
            pnlCharts.Size = new Size(1350, 430);
            pnlCharts.TabIndex = 5;
            // 
            // lbRevenueTrendTitle
            // 
            lbRevenueTrendTitle.AutoSize = true;
            lbRevenueTrendTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbRevenueTrendTitle.ForeColor = Color.FromArgb(24, 60, 142);
            lbRevenueTrendTitle.Location = new Point(15, 12);
            lbRevenueTrendTitle.Name = "lbRevenueTrendTitle";
            lbRevenueTrendTitle.Size = new Size(190, 20);
            lbRevenueTrendTitle.TabIndex = 0;
            lbRevenueTrendTitle.Text = "REVENUE & OCCUPANCY";
            // 
            // pnlRevenueChartPlaceholder
            // 
            pnlRevenueChartPlaceholder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlRevenueChartPlaceholder.BackColor = Color.FromArgb(248, 249, 250);
            pnlRevenueChartPlaceholder.BorderStyle = BorderStyle.FixedSingle;
            pnlRevenueChartPlaceholder.Controls.Add(lbChartPlaceholderText);
            pnlRevenueChartPlaceholder.Location = new Point(15, 40);
            pnlRevenueChartPlaceholder.Name = "pnlRevenueChartPlaceholder";
            pnlRevenueChartPlaceholder.Size = new Size(1318, 170);
            pnlRevenueChartPlaceholder.TabIndex = 1;
            // 
            // lbChartPlaceholderText
            // 
            lbChartPlaceholderText.Dock = DockStyle.Fill;
            lbChartPlaceholderText.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lbChartPlaceholderText.ForeColor = Color.Gray;
            lbChartPlaceholderText.Location = new Point(0, 0);
            lbChartPlaceholderText.Name = "lbChartPlaceholderText";
            lbChartPlaceholderText.Size = new Size(1316, 168);
            lbChartPlaceholderText.TabIndex = 0;
            lbChartPlaceholderText.Text = "[ LiveCharts / Chart control location for Revenue trend ]";
            lbChartPlaceholderText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbTopServicesTitle
            // 
            lbTopServicesTitle.AutoSize = true;
            lbTopServicesTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbTopServicesTitle.ForeColor = Color.FromArgb(24, 60, 142);
            lbTopServicesTitle.Location = new Point(15, 225);
            lbTopServicesTitle.Name = "lbTopServicesTitle";
            lbTopServicesTitle.Size = new Size(231, 20);
            lbTopServicesTitle.TabIndex = 2;
            lbTopServicesTitle.Text = "TOP PERFORMING SERVICES";
            // 
            // dgvTopServices
            // 
            dgvTopServices.AllowUserToAddRows = false;
            dgvTopServices.AllowUserToDeleteRows = false;
            dgvTopServices.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTopServices.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(24, 60, 142);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(24, 60, 142);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTopServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTopServices.ColumnHeadersHeight = 35;
            dgvTopServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTopServices.Columns.AddRange(new DataGridViewColumn[] { colServiceName, colServiceCategory, colServiceOrders, colServiceRevenue });
            dgvTopServices.EnableHeadersVisualStyles = false;
            dgvTopServices.Location = new Point(15, 253);
            dgvTopServices.MultiSelect = false;
            dgvTopServices.Name = "dgvTopServices";
            dgvTopServices.ReadOnly = true;
            dgvTopServices.RowHeadersVisible = false;
            dgvTopServices.RowTemplate.Height = 30;
            dgvTopServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopServices.Size = new Size(1318, 160);
            dgvTopServices.TabIndex = 3;
            // 
            // colServiceName
            // 
            colServiceName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colServiceName.FillWeight = 40F;
            colServiceName.HeaderText = "Service Name";
            colServiceName.Name = "colServiceName";
            colServiceName.ReadOnly = true;
            // 
            // colServiceCategory
            // 
            colServiceCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colServiceCategory.FillWeight = 20F;
            colServiceCategory.HeaderText = "Category";
            colServiceCategory.Name = "colServiceCategory";
            colServiceCategory.ReadOnly = true;
            // 
            // colServiceOrders
            // 
            colServiceOrders.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colServiceOrders.FillWeight = 20F;
            colServiceOrders.HeaderText = "Total Orders";
            colServiceOrders.Name = "colServiceOrders";
            colServiceOrders.ReadOnly = true;
            // 
            // colServiceRevenue
            // 
            dataGridViewCellStyle2.NullValue = null;
            colServiceRevenue.DefaultCellStyle = dataGridViewCellStyle2;
            colServiceRevenue.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colServiceRevenue.FillWeight = 20F;
            colServiceRevenue.HeaderText = "Revenue (HUF)";
            colServiceRevenue.Name = "colServiceRevenue";
            colServiceRevenue.ReadOnly = true;
            // 
            // pnlSideDetails
            // 
            pnlSideDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlSideDetails.BorderStyle = BorderStyle.FixedSingle;
            pnlSideDetails.Controls.Add(lbDemographicsValue);
            pnlSideDetails.Controls.Add(lbDemographicsTitle);
            pnlSideDetails.Controls.Add(lbHousekeepingValue);
            pnlSideDetails.Controls.Add(lbHousekeepingTitle);
            pnlSideDetails.Controls.Add(lbCancellationValue);
            pnlSideDetails.Controls.Add(lbCancellationTitle);
            pnlSideDetails.Controls.Add(lbAlosValue);
            pnlSideDetails.Controls.Add(lbAlosTitle);
            pnlSideDetails.Controls.Add(lbSideTitle);
            pnlSideDetails.Location = new Point(1370, 10);
            pnlSideDetails.Name = "pnlSideDetails";
            pnlSideDetails.Size = new Size(355, 610);
            pnlSideDetails.TabIndex = 6;
            // 
            // lbSideTitle
            // 
            lbSideTitle.AutoSize = true;
            lbSideTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbSideTitle.ForeColor = Color.FromArgb(24, 60, 142);
            lbSideTitle.Location = new Point(15, 12);
            lbSideTitle.Name = "lbSideTitle";
            lbSideTitle.Size = new Size(181, 20);
            lbSideTitle.TabIndex = 0;
            lbSideTitle.Text = "OPERATIONAL METRICS";
            // 
            // lbAlosTitle
            // 
            lbAlosTitle.AutoSize = true;
            lbAlosTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbAlosTitle.Location = new Point(15, 50);
            lbAlosTitle.Name = "lbAlosTitle";
            lbAlosTitle.Size = new Size(207, 19);
            lbAlosTitle.TabIndex = 1;
            lbAlosTitle.Text = "Avg Length of Stay (ALOS):";
            // 
            // lbAlosValue
            // 
            lbAlosValue.AutoSize = true;
            lbAlosValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbAlosValue.ForeColor = Color.FromArgb(24, 60, 142);
            lbAlosValue.Location = new Point(15, 72);
            lbAlosValue.Name = "lbAlosValue";
            lbAlosValue.Size = new Size(86, 21);
            lbAlosValue.TabIndex = 2;
            lbAlosValue.Text = "0.0 nights";
            // 
            // lbCancellationTitle
            // 
            lbCancellationTitle.AutoSize = true;
            lbCancellationTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbCancellationTitle.Location = new Point(15, 120);
            lbCancellationTitle.Name = "lbCancellationTitle";
            lbCancellationTitle.Size = new Size(130, 19);
            lbCancellationTitle.TabIndex = 3;
            lbCancellationTitle.Text = "Cancellation Rate:";
            // 
            // lbCancellationValue
            // 
            lbCancellationValue.AutoSize = true;
            lbCancellationValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbCancellationValue.ForeColor = Color.DarkRed;
            lbCancellationValue.Location = new Point(15, 142);
            lbCancellationValue.Name = "lbCancellationValue";
            lbCancellationValue.Size = new Size(54, 21);
            lbCancellationValue.TabIndex = 4;
            lbCancellationValue.Text = "0.0 %";
            // 
            // lbHousekeepingTitle
            // 
            lbHousekeepingTitle.AutoSize = true;
            lbHousekeepingTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbHousekeepingTitle.Location = new Point(15, 190);
            lbHousekeepingTitle.Name = "lbHousekeepingTitle";
            lbHousekeepingTitle.Size = new Size(183, 19);
            lbHousekeepingTitle.TabIndex = 5;
            lbHousekeepingTitle.Text = "Avg Room Turnaround:";
            // 
            // lbHousekeepingValue
            // 
            lbHousekeepingValue.AutoSize = true;
            lbHousekeepingValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbHousekeepingValue.ForeColor = Color.Black;
            lbHousekeepingValue.Location = new Point(15, 212);
            lbHousekeepingValue.Name = "lbHousekeepingValue";
            lbHousekeepingValue.Size = new Size(71, 21);
            lbHousekeepingValue.TabIndex = 6;
            lbHousekeepingValue.Text = "00 mins";
            // 
            // lbDemographicsTitle
            // 
            lbDemographicsTitle.AutoSize = true;
            lbDemographicsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbDemographicsTitle.Location = new Point(15, 260);
            lbDemographicsTitle.Name = "lbDemographicsTitle";
            lbDemographicsTitle.Size = new Size(150, 19);
            lbDemographicsTitle.TabIndex = 7;
            lbDemographicsTitle.Text = "Guest Demographics:";
            // 
            // lbDemographicsValue
            // 
            lbDemographicsValue.AutoSize = true;
            lbDemographicsValue.Font = new Font("Segoe UI", 9.5F);
            lbDemographicsValue.ForeColor = Color.DimGray;
            lbDemographicsValue.Location = new Point(15, 285);
            lbDemographicsValue.Name = "lbDemographicsValue";
            lbDemographicsValue.Size = new Size(196, 51);
            lbDemographicsValue.TabIndex = 8;
            lbDemographicsValue.Text = "Domestic: 0%\r\nInternational: 0%\r\nBusiness / Leisure: 0% / 0%";
            // 
            // StatisticsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(pnlSideDetails);
            Controls.Add(pnlCharts);
            Controls.Add(pnlKpiAdr);
            Controls.Add(pnlKpiTotalRev);
            Controls.Add(pnlKpiRevPar);
            Controls.Add(pnlKpiOccupancy);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 9.75F);
            Name = "StatisticsControl";
            Size = new Size(1740, 639);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlKpiOccupancy.ResumeLayout(false);
            pnlKpiOccupancy.PerformLayout();
            pnlKpiRevPar.ResumeLayout(false);
            pnlKpiRevPar.PerformLayout();
            pnlKpiTotalRev.ResumeLayout(false);
            pnlKpiTotalRev.PerformLayout();
            pnlKpiAdr.ResumeLayout(false);
            pnlKpiAdr.PerformLayout();
            pnlCharts.ResumeLayout(false);
            pnlCharts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTopServices).EndInit();
            pnlSideDetails.ResumeLayout(false);
            pnlSideDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lbFilter;
        private Label lbDateFrom;
        private DateTimePicker dtpFrom;
        private Label lbDateTo;
        private DateTimePicker dtpTo;
        private Label lbQuickDate;
        private ComboBox cbQuickDate;
        private Button btnApplyFilter;
        private Label lbUtility;
        private Button btnRefresh;
        private Button btnExportPdf;

        private Panel pnlKpiOccupancy;
        private Label lbKpiOccupancyTitle;
        private Label lbKpiOccupancyValue;
        private Label lbKpiOccupancySub;

        private Panel pnlKpiRevPar;
        private Label lbKpiRevParTitle;
        private Label lbKpiRevParValue;
        private Label lbKpiRevParSub;

        private Panel pnlKpiTotalRev;
        private Label lbKpiTotalRevTitle;
        private Label lbKpiTotalRevValue;
        private Label lbKpiTotalRevSub;

        private Panel pnlKpiAdr;
        private Label lbKpiAdrTitle;
        private Label lbKpiAdrValue;
        private Label lbKpiAdrSub;

        private Panel pnlCharts;
        private Label lbRevenueTrendTitle;
        private Panel pnlRevenueChartPlaceholder;
        private Label lbChartPlaceholderText;
        private Label lbTopServicesTitle;
        private DataGridView dgvTopServices;
        private DataGridViewTextBoxColumn colServiceName;
        private DataGridViewTextBoxColumn colServiceCategory;
        private DataGridViewTextBoxColumn colServiceOrders;
        private DataGridViewTextBoxColumn colServiceRevenue;

        private Panel pnlSideDetails;
        private Label lbSideTitle;
        private Label lbAlosTitle;
        private Label lbAlosValue;
        private Label lbCancellationTitle;
        private Label lbCancellationValue;
        private Label lbHousekeepingTitle;
        private Label lbHousekeepingValue;
        private Label lbDemographicsTitle;
        private Label lbDemographicsValue;
    }
}