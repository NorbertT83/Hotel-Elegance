namespace Hotel_erp_Winforms_App.UI.Controls.EmployeeControl
{
    partial class EmployeeControl
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
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
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
            label1 = new Label();
            lbName = new Label();
            tbSearch = new TextBox();
            pnlControlHeader = new Panel();
            panel3 = new Panel();
            label5 = new Label();
            btnDelete = new Button();
            btnAdd = new Button();
            btnModify = new Button();
            panel1 = new Panel();
            label6 = new Label();
            cbJobTitle = new ComboBox();
            rbName = new RadioButton();
            label3 = new Label();
            rbJobTitle = new RadioButton();
            label2 = new Label();
            dgvEmployees = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colLname = new DataGridViewTextBoxColumn();
            colFname = new DataGridViewTextBoxColumn();
            colBirthDate = new DataGridViewTextBoxColumn();
            colAddress = new DataGridViewTextBoxColumn();
            colTaxNumber = new DataGridViewTextBoxColumn();
            colJobTitle = new DataGridViewTextBoxColumn();
            colHiringDate = new DataGridViewTextBoxColumn();
            colHolidays = new DataGridViewTextBoxColumn();
            colSalary = new DataGridViewTextBoxColumn();
            colPasswordHash = new DataGridViewTextBoxColumn();
            colPasswordSalt = new DataGridViewTextBoxColumn();
            colCreatedAt = new DataGridViewTextBoxColumn();
            colUpdatedAt = new DataGridViewTextBoxColumn();
            pnlDgvContainer = new Panel();
            pnlSide = new Panel();
            gbReminders = new GroupBox();
            gbInfo = new GroupBox();
            pbProfilePhoto = new PictureBox();
            lbEmployeeSideSalary = new Label();
            lbEmployeeSideJobTitle = new Label();
            lbEmployeeSideHiring = new Label();
            lbEmployeeSideBirth = new Label();
            lbEmployeeSideAddress = new Label();
            lbEmployeeSideHolidays = new Label();
            lbEmployeeSideTaxNumber = new Label();
            label4 = new Label();
            lbSalary = new Label();
            lbJobTitle = new Label();
            lbHiringDate = new Label();
            lbBirthDate = new Label();
            lbAddress = new Label();
            lbHolidays = new Label();
            lbTaxNumber = new Label();
            pnlMain = new Panel();
            pnlControlHeader.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            pnlDgvContainer.SuspendLayout();
            pnlSide.SuspendLayout();
            gbInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbProfilePhoto).BeginInit();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(22, 12);
            label1.Name = "label1";
            label1.Size = new Size(422, 56);
            label1.TabIndex = 0;
            label1.Text = "Search for employee";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lbName.Location = new Point(46, 106);
            lbName.Name = "lbName";
            lbName.Size = new Size(100, 37);
            lbName.TabIndex = 2;
            lbName.Text = "Name:";
            // 
            // tbSearch
            // 
            tbSearch.Font = new Font("Segoe UI", 20F);
            tbSearch.Location = new Point(152, 103);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(317, 43);
            tbSearch.TabIndex = 1;
            tbSearch.TextChanged += tbSearch_TextChanged;
            // 
            // pnlControlHeader
            // 
            pnlControlHeader.BackColor = Color.FromArgb(239, 246, 255);
            pnlControlHeader.Controls.Add(panel3);
            pnlControlHeader.Controls.Add(panel1);
            pnlControlHeader.Controls.Add(label2);
            pnlControlHeader.Controls.Add(lbName);
            pnlControlHeader.Controls.Add(label1);
            pnlControlHeader.Controls.Add(tbSearch);
            pnlControlHeader.Dock = DockStyle.Top;
            pnlControlHeader.ForeColor = Color.FromArgb(64, 64, 64);
            pnlControlHeader.Location = new Point(0, 0);
            pnlControlHeader.Name = "pnlControlHeader";
            pnlControlHeader.Size = new Size(1181, 194);
            pnlControlHeader.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(label5);
            panel3.Controls.Add(btnDelete);
            panel3.Controls.Add(btnAdd);
            panel3.Controls.Add(btnModify);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(785, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(172, 194);
            panel3.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(54, 17);
            label5.TabIndex = 10;
            label5.Text = "Actions";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Transparent;
            btnDelete.BackgroundImageLayout = ImageLayout.Zoom;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnDelete.Image = Properties.Resources.delete;
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(13, 137);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(144, 43);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Transparent;
            btnAdd.BackgroundImageLayout = ImageLayout.Zoom;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnAdd.Image = Properties.Resources.personadd;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(13, 39);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(144, 43);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnModify
            // 
            btnModify.BackColor = Color.Transparent;
            btnModify.BackgroundImageLayout = ImageLayout.Zoom;
            btnModify.Cursor = Cursors.Hand;
            btnModify.FlatStyle = FlatStyle.Flat;
            btnModify.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnModify.Image = Properties.Resources.edit;
            btnModify.ImageAlign = ContentAlignment.MiddleLeft;
            btnModify.Location = new Point(13, 87);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(144, 43);
            btnModify.TabIndex = 8;
            btnModify.Text = "Modify";
            btnModify.UseVisualStyleBackColor = false;
            btnModify.Click += btnModify_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label6);
            panel1.Controls.Add(cbJobTitle);
            panel1.Controls.Add(rbName);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(rbJobTitle);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(957, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(224, 194);
            panel1.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(43, 17);
            label6.TabIndex = 11;
            label6.Text = "Order";
            // 
            // cbJobTitle
            // 
            cbJobTitle.DropDownStyle = ComboBoxStyle.DropDownList;
            cbJobTitle.Font = new Font("Segoe UI", 15F);
            cbJobTitle.FormattingEnabled = true;
            cbJobTitle.Items.AddRange(new object[] { "All", "HK Manager", "Receptionist", "Room Service", "Front Office Manager", "F&B Manager", "Cleaner" });
            cbJobTitle.Location = new Point(16, 149);
            cbJobTitle.Margin = new Padding(3, 10, 3, 3);
            cbJobTitle.Name = "cbJobTitle";
            cbJobTitle.Size = new Size(197, 36);
            cbJobTitle.TabIndex = 4;
            cbJobTitle.SelectedIndexChanged += cbJobTitle_SelectedIndexChanged;
            // 
            // rbName
            // 
            rbName.AutoSize = true;
            rbName.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            rbName.Location = new Point(16, 30);
            rbName.Name = "rbName";
            rbName.Size = new Size(157, 32);
            rbName.TabIndex = 0;
            rbName.TabStop = true;
            rbName.Text = "By first name";
            rbName.TextAlign = ContentAlignment.MiddleCenter;
            rbName.UseVisualStyleBackColor = true;
            rbName.CheckedChanged += rbName_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label3.Location = new Point(16, 112);
            label3.Name = "label3";
            label3.Size = new Size(150, 28);
            label3.TabIndex = 3;
            label3.Text = "Select job title";
            // 
            // rbJobTitle
            // 
            rbJobTitle.AutoSize = true;
            rbJobTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            rbJobTitle.Location = new Point(16, 71);
            rbJobTitle.Name = "rbJobTitle";
            rbJobTitle.Size = new Size(135, 32);
            rbJobTitle.TabIndex = 1;
            rbJobTitle.TabStop = true;
            rbJobTitle.Text = "By job title";
            rbJobTitle.TextAlign = ContentAlignment.MiddleCenter;
            rbJobTitle.UseVisualStyleBackColor = true;
            rbJobTitle.CheckedChanged += rbJobTitle_CheckedChanged;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ScrollBar;
            label2.Location = new Point(33, 68);
            label2.Name = "label2";
            label2.Size = new Size(411, 1);
            label2.TabIndex = 3;
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
            dgvEmployees.BorderStyle = BorderStyle.Fixed3D;
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
            dgvEmployees.Columns.AddRange(new DataGridViewColumn[] { colId, colLname, colFname, colBirthDate, colAddress, colTaxNumber, colJobTitle, colHiringDate, colHolidays, colSalary, colPasswordHash, colPasswordSalt, colCreatedAt, colUpdatedAt });
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = SystemColors.Window;
            dataGridViewCellStyle13.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle13.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = DataGridViewTriState.False;
            dgvEmployees.DefaultCellStyle = dataGridViewCellStyle13;
            dgvEmployees.Dock = DockStyle.Fill;
            dgvEmployees.EnableHeadersVisualStyles = false;
            dgvEmployees.GridColor = SystemColors.ControlLight;
            dgvEmployees.Location = new Point(0, 0);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.RowTemplate.Height = 35;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(1181, 462);
            dgvEmployees.TabIndex = 0;
            // 
            // colId
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colId.DefaultCellStyle = dataGridViewCellStyle3;
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colLname
            // 
            colLname.DataPropertyName = "LName";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colLname.DefaultCellStyle = dataGridViewCellStyle4;
            colLname.FillWeight = 15F;
            colLname.HeaderText = "First name";
            colLname.Name = "colLname";
            colLname.ReadOnly = true;
            // 
            // colFname
            // 
            colFname.DataPropertyName = "FName";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colFname.DefaultCellStyle = dataGridViewCellStyle5;
            colFname.FillWeight = 15F;
            colFname.HeaderText = "Last name";
            colFname.Name = "colFname";
            colFname.ReadOnly = true;
            // 
            // colBirthDate
            // 
            colBirthDate.DataPropertyName = "DateOfBirth";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colBirthDate.DefaultCellStyle = dataGridViewCellStyle6;
            colBirthDate.FillWeight = 20F;
            colBirthDate.HeaderText = "Birthdate";
            colBirthDate.Name = "colBirthDate";
            colBirthDate.ReadOnly = true;
            // 
            // colAddress
            // 
            colAddress.DataPropertyName = "Address";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colAddress.DefaultCellStyle = dataGridViewCellStyle7;
            colAddress.FillWeight = 35F;
            colAddress.HeaderText = "Address";
            colAddress.Name = "colAddress";
            colAddress.ReadOnly = true;
            // 
            // colTaxNumber
            // 
            colTaxNumber.DataPropertyName = "TaxNumber";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTaxNumber.DefaultCellStyle = dataGridViewCellStyle8;
            colTaxNumber.FillWeight = 20F;
            colTaxNumber.HeaderText = "Tax number";
            colTaxNumber.Name = "colTaxNumber";
            colTaxNumber.ReadOnly = true;
            // 
            // colJobTitle
            // 
            colJobTitle.DataPropertyName = "JobTitle";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colJobTitle.DefaultCellStyle = dataGridViewCellStyle9;
            colJobTitle.FillWeight = 20F;
            colJobTitle.HeaderText = "Job title";
            colJobTitle.Name = "colJobTitle";
            colJobTitle.ReadOnly = true;
            // 
            // colHiringDate
            // 
            colHiringDate.DataPropertyName = "DateOfHiring";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colHiringDate.DefaultCellStyle = dataGridViewCellStyle10;
            colHiringDate.FillWeight = 20F;
            colHiringDate.HeaderText = "Date of hiring";
            colHiringDate.Name = "colHiringDate";
            colHiringDate.ReadOnly = true;
            // 
            // colHolidays
            // 
            colHolidays.DataPropertyName = "PaidHolidaysLeft";
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colHolidays.DefaultCellStyle = dataGridViewCellStyle11;
            colHolidays.FillWeight = 15F;
            colHolidays.HeaderText = "Holidays";
            colHolidays.Name = "colHolidays";
            colHolidays.ReadOnly = true;
            // 
            // colSalary
            // 
            colSalary.DataPropertyName = "Salary";
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSalary.DefaultCellStyle = dataGridViewCellStyle12;
            colSalary.FillWeight = 20F;
            colSalary.HeaderText = "Salary";
            colSalary.Name = "colSalary";
            colSalary.ReadOnly = true;
            // 
            // colPasswordHash
            // 
            colPasswordHash.HeaderText = "password_hash";
            colPasswordHash.Name = "colPasswordHash";
            colPasswordHash.ReadOnly = true;
            colPasswordHash.Visible = false;
            // 
            // colPasswordSalt
            // 
            colPasswordSalt.HeaderText = "password_salt";
            colPasswordSalt.Name = "colPasswordSalt";
            colPasswordSalt.ReadOnly = true;
            colPasswordSalt.Visible = false;
            // 
            // colCreatedAt
            // 
            colCreatedAt.HeaderText = "Created At";
            colCreatedAt.Name = "colCreatedAt";
            colCreatedAt.ReadOnly = true;
            colCreatedAt.Visible = false;
            // 
            // colUpdatedAt
            // 
            colUpdatedAt.HeaderText = "Updated At";
            colUpdatedAt.Name = "colUpdatedAt";
            colUpdatedAt.ReadOnly = true;
            colUpdatedAt.Visible = false;
            // 
            // pnlDgvContainer
            // 
            pnlDgvContainer.Controls.Add(dgvEmployees);
            pnlDgvContainer.Dock = DockStyle.Fill;
            pnlDgvContainer.Location = new Point(0, 194);
            pnlDgvContainer.Name = "pnlDgvContainer";
            pnlDgvContainer.Size = new Size(1181, 462);
            pnlDgvContainer.TabIndex = 3;
            // 
            // pnlSide
            // 
            pnlSide.Controls.Add(gbReminders);
            pnlSide.Controls.Add(gbInfo);
            pnlSide.Dock = DockStyle.Fill;
            pnlSide.Location = new Point(0, 0);
            pnlSide.Name = "pnlSide";
            pnlSide.Size = new Size(400, 656);
            pnlSide.TabIndex = 1;
            // 
            // gbReminders
            // 
            gbReminders.Dock = DockStyle.Bottom;
            gbReminders.Location = new Point(0, 456);
            gbReminders.Name = "gbReminders";
            gbReminders.Size = new Size(400, 200);
            gbReminders.TabIndex = 4;
            gbReminders.TabStop = false;
            gbReminders.Text = "Reminders";
            // 
            // gbInfo
            // 
            gbInfo.Controls.Add(pbProfilePhoto);
            gbInfo.Controls.Add(lbEmployeeSideSalary);
            gbInfo.Controls.Add(lbEmployeeSideJobTitle);
            gbInfo.Controls.Add(lbEmployeeSideHiring);
            gbInfo.Controls.Add(lbEmployeeSideBirth);
            gbInfo.Controls.Add(lbEmployeeSideAddress);
            gbInfo.Controls.Add(lbEmployeeSideHolidays);
            gbInfo.Controls.Add(lbEmployeeSideTaxNumber);
            gbInfo.Controls.Add(label4);
            gbInfo.Controls.Add(lbSalary);
            gbInfo.Controls.Add(lbJobTitle);
            gbInfo.Controls.Add(lbHiringDate);
            gbInfo.Controls.Add(lbBirthDate);
            gbInfo.Controls.Add(lbAddress);
            gbInfo.Controls.Add(lbHolidays);
            gbInfo.Controls.Add(lbTaxNumber);
            gbInfo.Dock = DockStyle.Fill;
            gbInfo.Location = new Point(0, 0);
            gbInfo.Name = "gbInfo";
            gbInfo.Size = new Size(400, 656);
            gbInfo.TabIndex = 5;
            gbInfo.TabStop = false;
            gbInfo.Text = "Your Profile";
            gbInfo.Enter += gbInfo_Enter;
            // 
            // pbProfilePhoto
            // 
            pbProfilePhoto.Dock = DockStyle.Top;
            pbProfilePhoto.Image = Properties.Resources.person_icon;
            pbProfilePhoto.Location = new Point(3, 30);
            pbProfilePhoto.Name = "pbProfilePhoto";
            pbProfilePhoto.Size = new Size(394, 252);
            pbProfilePhoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbProfilePhoto.TabIndex = 19;
            pbProfilePhoto.TabStop = false;
            // 
            // lbEmployeeSideSalary
            // 
            lbEmployeeSideSalary.AutoSize = true;
            lbEmployeeSideSalary.Location = new Point(85, 505);
            lbEmployeeSideSalary.Name = "lbEmployeeSideSalary";
            lbEmployeeSideSalary.Size = new Size(0, 28);
            lbEmployeeSideSalary.TabIndex = 18;
            // 
            // lbEmployeeSideJobTitle
            // 
            lbEmployeeSideJobTitle.AutoSize = true;
            lbEmployeeSideJobTitle.Location = new Point(101, 471);
            lbEmployeeSideJobTitle.Name = "lbEmployeeSideJobTitle";
            lbEmployeeSideJobTitle.Size = new Size(0, 28);
            lbEmployeeSideJobTitle.TabIndex = 17;
            // 
            // lbEmployeeSideHiring
            // 
            lbEmployeeSideHiring.AutoSize = true;
            lbEmployeeSideHiring.Location = new Point(151, 437);
            lbEmployeeSideHiring.Name = "lbEmployeeSideHiring";
            lbEmployeeSideHiring.Size = new Size(0, 28);
            lbEmployeeSideHiring.TabIndex = 16;
            // 
            // lbEmployeeSideBirth
            // 
            lbEmployeeSideBirth.AutoSize = true;
            lbEmployeeSideBirth.Location = new Point(114, 403);
            lbEmployeeSideBirth.Name = "lbEmployeeSideBirth";
            lbEmployeeSideBirth.Size = new Size(0, 28);
            lbEmployeeSideBirth.TabIndex = 15;
            // 
            // lbEmployeeSideAddress
            // 
            lbEmployeeSideAddress.AutoSize = true;
            lbEmployeeSideAddress.Location = new Point(101, 369);
            lbEmployeeSideAddress.Name = "lbEmployeeSideAddress";
            lbEmployeeSideAddress.Size = new Size(0, 28);
            lbEmployeeSideAddress.TabIndex = 14;
            // 
            // lbEmployeeSideHolidays
            // 
            lbEmployeeSideHolidays.AutoSize = true;
            lbEmployeeSideHolidays.Location = new Point(185, 335);
            lbEmployeeSideHolidays.Name = "lbEmployeeSideHolidays";
            lbEmployeeSideHolidays.Size = new Size(0, 28);
            lbEmployeeSideHolidays.TabIndex = 13;
            // 
            // lbEmployeeSideTaxNumber
            // 
            lbEmployeeSideTaxNumber.AutoSize = true;
            lbEmployeeSideTaxNumber.Location = new Point(131, 301);
            lbEmployeeSideTaxNumber.Name = "lbEmployeeSideTaxNumber";
            lbEmployeeSideTaxNumber.Size = new Size(0, 28);
            lbEmployeeSideTaxNumber.TabIndex = 12;
            // 
            // label4
            // 
            label4.BackColor = SystemColors.ScrollBar;
            label4.Location = new Point(19, 288);
            label4.Name = "label4";
            label4.Size = new Size(368, 1);
            label4.TabIndex = 10;
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbSalary
            // 
            lbSalary.AutoSize = true;
            lbSalary.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lbSalary.Location = new Point(19, 508);
            lbSalary.Name = "lbSalary";
            lbSalary.Size = new Size(70, 25);
            lbSalary.TabIndex = 9;
            lbSalary.Text = "Salary:";
            // 
            // lbJobTitle
            // 
            lbJobTitle.AutoSize = true;
            lbJobTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lbJobTitle.Location = new Point(19, 474);
            lbJobTitle.Name = "lbJobTitle";
            lbJobTitle.Size = new Size(86, 25);
            lbJobTitle.TabIndex = 8;
            lbJobTitle.Text = "Job title:";
            // 
            // lbHiringDate
            // 
            lbHiringDate.AutoSize = true;
            lbHiringDate.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lbHiringDate.Location = new Point(19, 440);
            lbHiringDate.Name = "lbHiringDate";
            lbHiringDate.Size = new Size(135, 25);
            lbHiringDate.TabIndex = 7;
            lbHiringDate.Text = "Date of hiring:";
            // 
            // lbBirthDate
            // 
            lbBirthDate.AutoSize = true;
            lbBirthDate.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lbBirthDate.Location = new Point(19, 406);
            lbBirthDate.Name = "lbBirthDate";
            lbBirthDate.Size = new Size(98, 25);
            lbBirthDate.TabIndex = 6;
            lbBirthDate.Text = "Birthdate:";
            // 
            // lbAddress
            // 
            lbAddress.AutoSize = true;
            lbAddress.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lbAddress.Location = new Point(19, 372);
            lbAddress.Name = "lbAddress";
            lbAddress.Size = new Size(85, 25);
            lbAddress.TabIndex = 5;
            lbAddress.Text = "Address:";
            // 
            // lbHolidays
            // 
            lbHolidays.AutoSize = true;
            lbHolidays.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lbHolidays.Location = new Point(19, 338);
            lbHolidays.Name = "lbHolidays";
            lbHolidays.Size = new Size(164, 25);
            lbHolidays.TabIndex = 4;
            lbHolidays.Text = "Paid holidays left:";
            // 
            // lbTaxNumber
            // 
            lbTaxNumber.AutoSize = true;
            lbTaxNumber.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lbTaxNumber.Location = new Point(19, 304);
            lbTaxNumber.Name = "lbTaxNumber";
            lbTaxNumber.Size = new Size(118, 25);
            lbTaxNumber.TabIndex = 3;
            lbTaxNumber.Text = "Tax number:";
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(pnlSide);
            pnlMain.Dock = DockStyle.Right;
            pnlMain.Location = new Point(1181, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(400, 656);
            pnlMain.TabIndex = 4;
            // 
            // EmployeeControl
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlDgvContainer);
            Controls.Add(pnlControlHeader);
            Controls.Add(pnlMain);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "EmployeeControl";
            Size = new Size(1581, 656);
            Load += EmployeeControl_Load;
            pnlControlHeader.ResumeLayout(false);
            pnlControlHeader.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            pnlDgvContainer.ResumeLayout(false);
            pnlSide.ResumeLayout(false);
            gbInfo.ResumeLayout(false);
            gbInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbProfilePhoto).EndInit();
            pnlMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private TextBox tbSearch;
        private Label lbName;
        private Panel pnlControlHeader;
        private Label label2;
        private RadioButton rbJobTitle;
        private RadioButton rbName;
        private Label label3;
        private ComboBox cbJobTitle;
        private Button btnAdd;
        private Button btnModify;
        private Button btnDelete;
        private DataGridView dgvEmployees;
        private Panel pnlDgvContainer;
        private Panel pnlSide;
        private GroupBox gbInfo;
        private Label lbEmployeeSideSalary;
        private Label lbEmployeeSideJobTitle;
        private Label lbEmployeeSideHiring;
        private Label lbEmployeeSideBirth;
        private Label lbEmployeeSideAddress;
        private Label lbEmployeeSideHolidays;
        private Label lbEmployeeSideTaxNumber;
        private Label label4;
        private Label lbSalary;
        private Label lbJobTitle;
        private Label lbHiringDate;
        private Label lbBirthDate;
        private Label lbAddress;
        private Label lbHolidays;
        private Label lbTaxNumber;
        private GroupBox gbReminders;
        private Panel pnlMain;
        private PictureBox pbProfilePhoto;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colLname;
        private DataGridViewTextBoxColumn colFname;
        private DataGridViewTextBoxColumn colBirthDate;
        private DataGridViewTextBoxColumn colAddress;
        private DataGridViewTextBoxColumn colTaxNumber;
        private DataGridViewTextBoxColumn colJobTitle;
        private DataGridViewTextBoxColumn colHiringDate;
        private DataGridViewTextBoxColumn colHolidays;
        private DataGridViewTextBoxColumn colSalary;
        private DataGridViewTextBoxColumn colPasswordHash;
        private DataGridViewTextBoxColumn colPasswordSalt;
        private DataGridViewTextBoxColumn colCreatedAt;
        private DataGridViewTextBoxColumn colUpdatedAt;
        private Panel panel3;
        private Panel panel1;
        private Label label5;
        private Label label6;
    }
}
