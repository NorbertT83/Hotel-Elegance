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
            label1 = new Label();
            lbName = new Label();
            tbSearch = new TextBox();
            pnlControlHeader = new Panel();
            groupBox1 = new GroupBox();
            cbJobTitle = new ComboBox();
            label3 = new Label();
            rbJobTitle = new RadioButton();
            rbName = new RadioButton();
            label2 = new Label();
            pnlDgvContainer = new Panel();
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
            groupBox2 = new GroupBox();
            btnDelete = new Button();
            btnModify = new Button();
            btnAdd = new Button();
            pnlControlHeader.SuspendLayout();
            groupBox1.SuspendLayout();
            pnlDgvContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            groupBox2.SuspendLayout();
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
            pnlControlHeader.Controls.Add(groupBox1);
            pnlControlHeader.Controls.Add(label2);
            pnlControlHeader.Controls.Add(lbName);
            pnlControlHeader.Controls.Add(label1);
            pnlControlHeader.Controls.Add(tbSearch);
            pnlControlHeader.Dock = DockStyle.Top;
            pnlControlHeader.ForeColor = Color.FromArgb(64, 64, 64);
            pnlControlHeader.Location = new Point(10, 10);
            pnlControlHeader.Name = "pnlControlHeader";
            pnlControlHeader.Size = new Size(977, 201);
            pnlControlHeader.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(cbJobTitle);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(rbJobTitle);
            groupBox1.Controls.Add(rbName);
            groupBox1.Location = new Point(475, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(228, 201);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sort";
            // 
            // cbJobTitle
            // 
            cbJobTitle.DropDownStyle = ComboBoxStyle.DropDownList;
            cbJobTitle.FormattingEnabled = true;
            cbJobTitle.Items.AddRange(new object[] { "All", "HK Manager", "Receptionist", "Room Service", "Front Office Manager", "F&B Manager", "Cleaner" });
            cbJobTitle.Location = new Point(15, 144);
            cbJobTitle.Name = "cbJobTitle";
            cbJobTitle.Size = new Size(197, 36);
            cbJobTitle.TabIndex = 4;
            cbJobTitle.SelectedIndexChanged += cbJobTitle_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 113);
            label3.Name = "label3";
            label3.Size = new Size(137, 28);
            label3.TabIndex = 3;
            label3.Text = "Select job title";
            // 
            // rbJobTitle
            // 
            rbJobTitle.AutoSize = true;
            rbJobTitle.Location = new Point(15, 71);
            rbJobTitle.Name = "rbJobTitle";
            rbJobTitle.Size = new Size(124, 32);
            rbJobTitle.TabIndex = 1;
            rbJobTitle.TabStop = true;
            rbJobTitle.Text = "By job title";
            rbJobTitle.TextAlign = ContentAlignment.MiddleCenter;
            rbJobTitle.UseVisualStyleBackColor = true;
            rbJobTitle.CheckedChanged += rbJobTitle_CheckedChanged;
            // 
            // rbName
            // 
            rbName.AutoSize = true;
            rbName.Location = new Point(15, 33);
            rbName.Name = "rbName";
            rbName.Size = new Size(142, 32);
            rbName.TabIndex = 0;
            rbName.TabStop = true;
            rbName.Text = "By first name";
            rbName.TextAlign = ContentAlignment.MiddleCenter;
            rbName.UseVisualStyleBackColor = true;
            rbName.CheckedChanged += rbName_CheckedChanged;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ScrollBar;
            label2.Location = new Point(33, 68);
            label2.Name = "label2";
            label2.Size = new Size(411, 1);
            label2.TabIndex = 3;
            // 
            // pnlDgvContainer
            // 
            pnlDgvContainer.Controls.Add(dgvEmployees);
            pnlDgvContainer.Dock = DockStyle.Fill;
            pnlDgvContainer.Location = new Point(10, 211);
            pnlDgvContainer.Name = "pnlDgvContainer";
            pnlDgvContainer.Size = new Size(977, 275);
            pnlDgvContainer.TabIndex = 3;
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.AllowUserToOrderColumns = true;
            dgvEmployees.AllowUserToResizeColumns = false;
            dgvEmployees.AllowUserToResizeRows = false;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.BackgroundColor = Color.White;
            dgvEmployees.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Columns.AddRange(new DataGridViewColumn[] { colId, colLname, colFname, colBirthDate, colAddress, colTaxNumber, colJobTitle, colHiringDate, colHolidays, colSalary, colPasswordHash, colPasswordSalt, colCreatedAt, colUpdatedAt });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvEmployees.DefaultCellStyle = dataGridViewCellStyle2;
            dgvEmployees.Dock = DockStyle.Fill;
            dgvEmployees.Location = new Point(0, 0);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(977, 275);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.CellClick += dgvEmployees_CellClick;
            // 
            // colId
            // 
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.Visible = false;
            // 
            // colLname
            // 
            colLname.DataPropertyName = "LName";
            colLname.FillWeight = 15F;
            colLname.HeaderText = "First name";
            colLname.Name = "colLname";
            colLname.ReadOnly = true;
            // 
            // colFname
            // 
            colFname.DataPropertyName = "FName";
            colFname.FillWeight = 15F;
            colFname.HeaderText = "Last name";
            colFname.Name = "colFname";
            colFname.ReadOnly = true;
            // 
            // colBirthDate
            // 
            colBirthDate.DataPropertyName = "DateOfBirth";
            colBirthDate.FillWeight = 20F;
            colBirthDate.HeaderText = "Birthdate";
            colBirthDate.Name = "colBirthDate";
            colBirthDate.ReadOnly = true;
            // 
            // colAddress
            // 
            colAddress.DataPropertyName = "Address";
            colAddress.FillWeight = 35F;
            colAddress.HeaderText = "Address";
            colAddress.Name = "colAddress";
            colAddress.ReadOnly = true;
            // 
            // colTaxNumber
            // 
            colTaxNumber.DataPropertyName = "TaxNumber";
            colTaxNumber.FillWeight = 20F;
            colTaxNumber.HeaderText = "Tax number";
            colTaxNumber.Name = "colTaxNumber";
            colTaxNumber.ReadOnly = true;
            // 
            // colJobTitle
            // 
            colJobTitle.DataPropertyName = "JobTitle";
            colJobTitle.FillWeight = 20F;
            colJobTitle.HeaderText = "Job title";
            colJobTitle.Name = "colJobTitle";
            colJobTitle.ReadOnly = true;
            // 
            // colHiringDate
            // 
            colHiringDate.DataPropertyName = "DateOfHiring";
            colHiringDate.FillWeight = 20F;
            colHiringDate.HeaderText = "Date of hiring";
            colHiringDate.Name = "colHiringDate";
            colHiringDate.ReadOnly = true;
            // 
            // colHolidays
            // 
            colHolidays.DataPropertyName = "PaidHolidaysLeft";
            colHolidays.FillWeight = 15F;
            colHolidays.HeaderText = "Holidays";
            colHolidays.Name = "colHolidays";
            colHolidays.ReadOnly = true;
            // 
            // colSalary
            // 
            colSalary.DataPropertyName = "Salary";
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
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.BackColor = Color.FromArgb(239, 246, 255);
            groupBox2.Controls.Add(btnDelete);
            groupBox2.Controls.Add(btnModify);
            groupBox2.Controls.Add(btnAdd);
            groupBox2.Location = new Point(719, 10);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(268, 201);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Manage";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.White;
            btnDelete.BackgroundImage = Properties.Resources.piros_x;
            btnDelete.BackgroundImageLayout = ImageLayout.Zoom;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(190, 70);
            btnDelete.Name = "btnDelete";
            btnDelete.Padding = new Padding(2);
            btnDelete.Size = new Size(60, 60);
            btnDelete.TabIndex = 9;
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnModify
            // 
            btnModify.BackColor = Color.White;
            btnModify.BackgroundImage = Properties.Resources.modify;
            btnModify.BackgroundImageLayout = ImageLayout.Zoom;
            btnModify.Cursor = Cursors.Hand;
            btnModify.FlatStyle = FlatStyle.Flat;
            btnModify.Location = new Point(103, 70);
            btnModify.Name = "btnModify";
            btnModify.Padding = new Padding(2);
            btnModify.Size = new Size(60, 60);
            btnModify.TabIndex = 8;
            btnModify.UseVisualStyleBackColor = false;
            btnModify.Click += btnModify_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.White;
            btnAdd.BackgroundImage = Properties.Resources.personadd;
            btnAdd.BackgroundImageLayout = ImageLayout.Zoom;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(16, 70);
            btnAdd.Name = "btnAdd";
            btnAdd.Padding = new Padding(2);
            btnAdd.Size = new Size(60, 60);
            btnAdd.TabIndex = 7;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // EmployeeControl
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Controls.Add(pnlDgvContainer);
            Controls.Add(pnlControlHeader);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "EmployeeControl";
            Padding = new Padding(10);
            Size = new Size(997, 496);
            Load += EmployeeControl_Load;
            pnlControlHeader.ResumeLayout(false);
            pnlControlHeader.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            pnlDgvContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private TextBox tbSearch;
        private Label lbName;
        private Panel pnlControlHeader;
        private Panel pnlDgvContainer;
        private Label label2;
        private GroupBox groupBox1;
        private RadioButton rbJobTitle;
        private RadioButton rbName;
        private DataGridView dgvEmployees;
        private Label label3;
        private ComboBox cbJobTitle;
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
        private GroupBox groupBox2;
        private Button btnAdd;
        private Button btnModify;
        private Button btnDelete;
    }
}
