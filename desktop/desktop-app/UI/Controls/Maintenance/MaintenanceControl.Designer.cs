using System.Drawing;
using System.Windows.Forms;

namespace Hotel_erp_Winforms_App.UI.Controls.Maintenance
{
    partial class MaintenanceControl
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

        private void InitializeComponent()
        {
            DataGridViewCellStyle dgvHeaderStyle = new DataGridViewCellStyle();
            pnlKpiOpen = new Panel();
            lbKpiOpenTitle = new Label();
            lbKpiOpenValue = new Label();
            lbKpiOpenSub = new Label();
            pnlKpiUrgent = new Panel();
            lbKpiUrgentTitle = new Label();
            lbKpiUrgentValue = new Label();
            lbKpiUrgentSub = new Label();
            pnlKpiCompleted = new Panel();
            lbKpiCompletedTitle = new Label();
            lbKpiCompletedValue = new Label();
            lbKpiCompletedSub = new Label();
            pnlMainGrid = new Panel();
            dgvTickets = new DataGridView();
            colTicketId = new DataGridViewTextBoxColumn();
            colRoomNum = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colPriority = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colAssignedTo = new DataGridViewTextBoxColumn();
            pnlGridHeader = new Panel();
            btnFilterAll = new Button();
            btnFilterInProgress = new Button();
            btnFilterOpen = new Button();
            lbTicketsTitle = new Label();
            pnlEditor = new Panel();
            lbEditorTitle = new Label();
            lbRoom = new Label();
            cbRoomSelect = new ComboBox();
            lbCategory = new Label();
            cbCategorySelect = new ComboBox();
            lbPriority = new Label();
            cbPrioritySelect = new ComboBox();
            lbAssignedTo = new Label();
            cbAssigneeSelect = new ComboBox();
            lbDescription = new Label();
            txtDescription = new TextBox();
            btnSaveTicket = new Button();
            btnMarkResolved = new Button();
            pnlKpiOpen.SuspendLayout();
            pnlKpiUrgent.SuspendLayout();
            pnlKpiCompleted.SuspendLayout();
            pnlMainGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTickets).BeginInit();
            pnlGridHeader.SuspendLayout();
            pnlEditor.SuspendLayout();
            SuspendLayout();
            // 
            // pnlKpiOpen
            // 
            pnlKpiOpen.BackColor = Color.White;
            pnlKpiOpen.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiOpen.Controls.Add(lbKpiOpenSub);
            pnlKpiOpen.Controls.Add(lbKpiOpenValue);
            pnlKpiOpen.Controls.Add(lbKpiOpenTitle);
            pnlKpiOpen.Location = new Point(10, 10);
            pnlKpiOpen.Name = "pnlKpiOpen";
            pnlKpiOpen.Size = new Size(350, 80);
            pnlKpiOpen.TabIndex = 0;
            // 
            // lbKpiOpenTitle
            // 
            lbKpiOpenTitle.AutoSize = true;
            lbKpiOpenTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiOpenTitle.ForeColor = Color.DimGray;
            lbKpiOpenTitle.Location = new Point(12, 10);
            lbKpiOpenTitle.Name = "lbKpiOpenTitle";
            lbKpiOpenTitle.Size = new Size(130, 15);
            lbKpiOpenTitle.TabIndex = 0;
            lbKpiOpenTitle.Text = "OPEN TICKETS";
            // 
            // lbKpiOpenValue
            // 
            lbKpiOpenValue.AutoSize = true;
            lbKpiOpenValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbKpiOpenValue.ForeColor = Color.DarkOrange;
            lbKpiOpenValue.Location = new Point(10, 26);
            lbKpiOpenValue.Name = "lbKpiOpenValue";
            lbKpiOpenValue.Size = new Size(26, 30);
            lbKpiOpenValue.TabIndex = 1;
            lbKpiOpenValue.Text = "0";
            // 
            // lbKpiOpenSub
            // 
            lbKpiOpenSub.AutoSize = true;
            lbKpiOpenSub.Font = new Font("Segoe UI", 8F);
            lbKpiOpenSub.ForeColor = Color.Gray;
            lbKpiOpenSub.Location = new Point(12, 57);
            lbKpiOpenSub.Name = "lbKpiOpenSub";
            lbKpiOpenSub.Size = new Size(137, 13);
            lbKpiOpenSub.TabIndex = 2;
            lbKpiOpenSub.Text = "Tasks pending resolution";
            // 
            // pnlKpiUrgent
            // 
            pnlKpiUrgent.BackColor = Color.White;
            pnlKpiUrgent.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiUrgent.Controls.Add(lbKpiUrgentSub);
            pnlKpiUrgent.Controls.Add(lbKpiUrgentValue);
            pnlKpiUrgent.Controls.Add(lbKpiUrgentTitle);
            pnlKpiUrgent.Location = new Point(370, 10);
            pnlKpiUrgent.Name = "pnlKpiUrgent";
            pnlKpiUrgent.Size = new Size(350, 80);
            pnlKpiUrgent.TabIndex = 1;
            // 
            // lbKpiUrgentTitle
            // 
            lbKpiUrgentTitle.AutoSize = true;
            lbKpiUrgentTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiUrgentTitle.ForeColor = Color.DimGray;
            lbKpiUrgentTitle.Location = new Point(12, 10);
            lbKpiUrgentTitle.Name = "lbKpiUrgentTitle";
            lbKpiUrgentTitle.Size = new Size(125, 15);
            lbKpiUrgentTitle.TabIndex = 0;
            lbKpiUrgentTitle.Text = "URGENT / CRITICAL";
            // 
            // lbKpiUrgentValue
            // 
            lbKpiUrgentValue.AutoSize = true;
            lbKpiUrgentValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbKpiUrgentValue.ForeColor = Color.Firebrick;
            lbKpiUrgentValue.Location = new Point(10, 26);
            lbKpiUrgentValue.Name = "lbKpiUrgentValue";
            lbKpiUrgentValue.Size = new Size(26, 30);
            lbKpiUrgentValue.TabIndex = 1;
            lbKpiUrgentValue.Text = "0";
            // 
            // lbKpiUrgentSub
            // 
            lbKpiUrgentSub.AutoSize = true;
            lbKpiUrgentSub.Font = new Font("Segoe UI", 8F);
            lbKpiUrgentSub.ForeColor = Color.Gray;
            lbKpiUrgentSub.Location = new Point(12, 57);
            lbKpiUrgentSub.Name = "lbKpiUrgentSub";
            lbKpiUrgentSub.Size = new Size(137, 13);
            lbKpiUrgentSub.TabIndex = 2;
            lbKpiUrgentSub.Text = "Requires immediate action";
            // 
            // pnlKpiCompleted
            // 
            pnlKpiCompleted.BackColor = Color.White;
            pnlKpiCompleted.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiCompleted.Controls.Add(lbKpiCompletedSub);
            pnlKpiCompleted.Controls.Add(lbKpiCompletedValue);
            pnlKpiCompleted.Controls.Add(lbKpiCompletedTitle);
            pnlKpiCompleted.Location = new Point(730, 10);
            pnlKpiCompleted.Name = "pnlKpiCompleted";
            pnlKpiCompleted.Size = new Size(350, 80);
            pnlKpiCompleted.TabIndex = 2;
            // 
            // lbKpiCompletedTitle
            // 
            lbKpiCompletedTitle.AutoSize = true;
            lbKpiCompletedTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiCompletedTitle.ForeColor = Color.DimGray;
            lbKpiCompletedTitle.Location = new Point(12, 10);
            lbKpiCompletedTitle.Name = "lbKpiCompletedTitle";
            lbKpiCompletedTitle.Size = new Size(129, 15);
            lbKpiCompletedTitle.TabIndex = 0;
            lbKpiCompletedTitle.Text = "RESOLVED (THIS MONTH)";
            // 
            // lbKpiCompletedValue
            // 
            lbKpiCompletedValue.AutoSize = true;
            lbKpiCompletedValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbKpiCompletedValue.ForeColor = Color.DarkGreen;
            lbKpiCompletedValue.Location = new Point(10, 26);
            lbKpiCompletedValue.Name = "lbKpiCompletedValue";
            lbKpiCompletedValue.Size = new Size(26, 30);
            lbKpiCompletedValue.TabIndex = 1;
            lbKpiCompletedValue.Text = "0";
            // 
            // lbKpiCompletedSub
            // 
            lbKpiCompletedSub.AutoSize = true;
            lbKpiCompletedSub.Font = new Font("Segoe UI", 8F);
            lbKpiCompletedSub.ForeColor = Color.Gray;
            lbKpiCompletedSub.Location = new Point(12, 57);
            lbKpiCompletedSub.Name = "lbKpiCompletedSub";
            lbKpiCompletedSub.Size = new Size(117, 13);
            lbKpiCompletedSub.TabIndex = 2;
            lbKpiCompletedSub.Text = "Closed maintenance tasks";
            // 
            // pnlMainGrid
            // 
            pnlMainGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlMainGrid.BackColor = Color.White;
            pnlMainGrid.BorderStyle = BorderStyle.FixedSingle;
            pnlMainGrid.Controls.Add(dgvTickets);
            pnlMainGrid.Controls.Add(pnlGridHeader);
            pnlMainGrid.Location = new Point(10, 100);
            pnlMainGrid.Name = "pnlMainGrid";
            pnlMainGrid.Size = new Size(1070, 525);
            pnlMainGrid.TabIndex = 3;
            // 
            // dgvTickets
            // 
            dgvTickets.AllowUserToAddRows = false;
            dgvTickets.AllowUserToDeleteRows = false;
            dgvTickets.BackgroundColor = Color.White;
            dgvTickets.BorderStyle = BorderStyle.None;
            dgvHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = Color.FromArgb(24, 60, 142);
            dgvHeaderStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvHeaderStyle.ForeColor = Color.White;
            dgvHeaderStyle.SelectionBackColor = Color.FromArgb(24, 60, 142);
            dgvHeaderStyle.SelectionForeColor = SystemColors.HighlightText;
            dgvTickets.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            dgvTickets.ColumnHeadersHeight = 35;
            dgvTickets.Columns.AddRange(new DataGridViewColumn[] { colTicketId, colRoomNum, colCategory, colDescription, colPriority, colStatus, colAssignedTo });
            dgvTickets.Dock = DockStyle.Fill;
            dgvTickets.EnableHeadersVisualStyles = false;
            dgvTickets.Location = new Point(0, 50);
            dgvTickets.MultiSelect = false;
            dgvTickets.Name = "dgvTickets";
            dgvTickets.ReadOnly = true;
            dgvTickets.RowHeadersVisible = false;
            dgvTickets.RowTemplate.Height = 30;
            dgvTickets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTickets.Size = new Size(1068, 473);
            dgvTickets.TabIndex = 1;
            // 
            // colTicketId
            // 
            colTicketId.HeaderText = "ID";
            colTicketId.Name = "colTicketId";
            colTicketId.ReadOnly = true;
            colTicketId.Visible = false;
            // 
            // colRoomNum
            // 
            colRoomNum.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoomNum.FillWeight = 12F;
            colRoomNum.HeaderText = "Room / Location";
            colRoomNum.Name = "colRoomNum";
            colRoomNum.ReadOnly = true;
            // 
            // colCategory
            // 
            colCategory.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCategory.FillWeight = 18F;
            colCategory.HeaderText = "Category";
            colCategory.Name = "colCategory";
            colCategory.ReadOnly = true;
            // 
            // colDescription
            // 
            colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescription.FillWeight = 35F;
            colDescription.HeaderText = "Description";
            colDescription.Name = "colDescription";
            colDescription.ReadOnly = true;
            // 
            // colPriority
            // 
            colPriority.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPriority.FillWeight = 12F;
            colPriority.HeaderText = "Priority";
            colPriority.Name = "colPriority";
            colPriority.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colStatus.FillWeight = 13F;
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colAssignedTo
            // 
            colAssignedTo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colAssignedTo.FillWeight = 15F;
            colAssignedTo.HeaderText = "Assigned To";
            colAssignedTo.Name = "colAssignedTo";
            colAssignedTo.ReadOnly = true;
            // 
            // pnlGridHeader
            // 
            pnlGridHeader.BackColor = Color.FromArgb(248, 249, 250);
            pnlGridHeader.Controls.Add(btnFilterAll);
            pnlGridHeader.Controls.Add(btnFilterInProgress);
            pnlGridHeader.Controls.Add(btnFilterOpen);
            pnlGridHeader.Controls.Add(lbTicketsTitle);
            pnlGridHeader.Dock = DockStyle.Top;
            pnlGridHeader.Location = new Point(0, 0);
            pnlGridHeader.Name = "pnlGridHeader";
            pnlGridHeader.Size = new Size(1068, 50);
            pnlGridHeader.TabIndex = 0;
            // 
            // btnFilterAll
            // 
            btnFilterAll.FlatStyle = FlatStyle.Flat;
            btnFilterAll.Location = new Point(370, 12);
            btnFilterAll.Name = "btnFilterAll";
            btnFilterAll.Size = new Size(85, 26);
            btnFilterAll.TabIndex = 3;
            btnFilterAll.Text = "All";
            btnFilterAll.UseVisualStyleBackColor = true;
            // 
            // btnFilterInProgress
            // 
            btnFilterInProgress.FlatStyle = FlatStyle.Flat;
            btnFilterInProgress.Location = new Point(275, 12);
            btnFilterInProgress.Name = "btnFilterInProgress";
            btnFilterInProgress.Size = new Size(88, 26);
            btnFilterInProgress.TabIndex = 2;
            btnFilterInProgress.Text = "In Progress";
            btnFilterInProgress.UseVisualStyleBackColor = true;
            // 
            // btnFilterOpen
            // 
            btnFilterOpen.FlatStyle = FlatStyle.Flat;
            btnFilterOpen.Location = new Point(180, 12);
            btnFilterOpen.Name = "btnFilterOpen";
            btnFilterOpen.Size = new Size(88, 26);
            btnFilterOpen.TabIndex = 1;
            btnFilterOpen.Text = "Open";
            btnFilterOpen.UseVisualStyleBackColor = true;
            // 
            // lbTicketsTitle
            // 
            lbTicketsTitle.AutoSize = true;
            lbTicketsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbTicketsTitle.Location = new Point(15, 14);
            lbTicketsTitle.Name = "lbTicketsTitle";
            lbTicketsTitle.Size = new Size(149, 20);
            lbTicketsTitle.TabIndex = 0;
            lbTicketsTitle.Text = "MAINTENANCE";
            // 
            // pnlEditor
            // 
            pnlEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlEditor.BackColor = Color.White;
            pnlEditor.BorderStyle = BorderStyle.FixedSingle;
            pnlEditor.Controls.Add(btnMarkResolved);
            pnlEditor.Controls.Add(btnSaveTicket);
            pnlEditor.Controls.Add(txtDescription);
            pnlEditor.Controls.Add(lbDescription);
            pnlEditor.Controls.Add(cbAssigneeSelect);
            pnlEditor.Controls.Add(lbAssignedTo);
            pnlEditor.Controls.Add(cbPrioritySelect);
            pnlEditor.Controls.Add(lbPriority);
            pnlEditor.Controls.Add(cbCategorySelect);
            pnlEditor.Controls.Add(lbCategory);
            pnlEditor.Controls.Add(cbRoomSelect);
            pnlEditor.Controls.Add(lbRoom);
            pnlEditor.Controls.Add(lbEditorTitle);
            pnlEditor.Location = new Point(1090, 10);
            pnlEditor.Name = "pnlEditor";
            pnlEditor.Size = new Size(635, 615);
            pnlEditor.TabIndex = 4;
            // 
            // lbEditorTitle
            // 
            lbEditorTitle.AutoSize = true;
            lbEditorTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbEditorTitle.ForeColor = Color.FromArgb(24, 60, 142);
            lbEditorTitle.Location = new Point(15, 15);
            lbEditorTitle.Name = "lbEditorTitle";
            lbEditorTitle.Size = new Size(230, 21);
            lbEditorTitle.TabIndex = 0;
            lbEditorTitle.Text = "NEW TICKET / EDIT";
            // 
            // lbRoom
            // 
            lbRoom.AutoSize = true;
            lbRoom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbRoom.Location = new Point(15, 55);
            lbRoom.Name = "lbRoom";
            lbRoom.Size = new Size(125, 15);
            lbRoom.TabIndex = 1;
            lbRoom.Text = "Affected Room / Area:";
            // 
            // cbRoomSelect
            // 
            cbRoomSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRoomSelect.FormattingEnabled = true;
            cbRoomSelect.Location = new Point(15, 75);
            cbRoomSelect.Name = "cbRoomSelect";
            cbRoomSelect.Size = new Size(600, 25);
            cbRoomSelect.TabIndex = 2;
            // 
            // lbCategory
            // 
            lbCategory.AutoSize = true;
            lbCategory.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbCategory.Location = new Point(15, 115);
            lbCategory.Name = "lbCategory";
            lbCategory.Size = new Size(88, 15);
            lbCategory.TabIndex = 3;
            lbCategory.Text = "Issue Category:";
            // 
            // cbCategorySelect
            // 
            cbCategorySelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategorySelect.FormattingEnabled = true;
            cbCategorySelect.Items.AddRange(new object[] { "Plumbing / Bathroom", "Electrical / Lighting", "HVAC / Heating", "Furniture / Fixtures", "TV / Internet / IT", "Other" });
            cbCategorySelect.Location = new Point(15, 135);
            cbCategorySelect.Name = "cbCategorySelect";
            cbCategorySelect.Size = new Size(600, 25);
            cbCategorySelect.TabIndex = 4;
            // 
            // lbPriority
            // 
            lbPriority.AutoSize = true;
            lbPriority.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbPriority.Location = new Point(15, 175);
            lbPriority.Name = "lbPriority";
            lbPriority.Size = new Size(58, 15);
            lbPriority.TabIndex = 5;
            lbPriority.Text = "Priority:";
            // 
            // cbPrioritySelect
            // 
            cbPrioritySelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPrioritySelect.FormattingEnabled = true;
            cbPrioritySelect.Items.AddRange(new object[] { "Low", "Medium", "High", "Urgent" });
            cbPrioritySelect.Location = new Point(15, 195);
            cbPrioritySelect.Name = "cbPrioritySelect";
            cbPrioritySelect.Size = new Size(280, 25);
            cbPrioritySelect.TabIndex = 6;
            // 
            // lbAssignedTo
            // 
            lbAssignedTo.AutoSize = true;
            lbAssignedTo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbAssignedTo.Location = new Point(335, 175);
            lbAssignedTo.Name = "lbAssignedTo";
            lbAssignedTo.Size = new Size(125, 15);
            lbAssignedTo.TabIndex = 7;
            lbAssignedTo.Text = "Assigned Technician:";
            // 
            // cbAssigneeSelect
            // 
            cbAssigneeSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAssigneeSelect.FormattingEnabled = true;
            cbAssigneeSelect.Location = new Point(335, 195);
            cbAssigneeSelect.Name = "cbAssigneeSelect";
            cbAssigneeSelect.Size = new Size(280, 25);
            cbAssigneeSelect.TabIndex = 8;
            // 
            // lbDescription
            // 
            lbDescription.AutoSize = true;
            lbDescription.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbDescription.Location = new Point(15, 235);
            lbDescription.Name = "lbDescription";
            lbDescription.Size = new Size(111, 15);
            lbDescription.TabIndex = 9;
            lbDescription.Text = "Detailed Description:";
            // 
            // txtDescription
            // 
            txtDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDescription.Location = new Point(15, 255);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(600, 280);
            txtDescription.TabIndex = 10;
            // 
            // btnSaveTicket
            // 
            btnSaveTicket.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSaveTicket.BackColor = Color.FromArgb(24, 60, 142);
            btnSaveTicket.FlatStyle = FlatStyle.Flat;
            btnSaveTicket.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSaveTicket.ForeColor = Color.White;
            btnSaveTicket.Location = new Point(15, 555);
            btnSaveTicket.Name = "btnSaveTicket";
            btnSaveTicket.Size = new Size(280, 45);
            btnSaveTicket.TabIndex = 11;
            btnSaveTicket.Text = "SAVE TICKET";
            btnSaveTicket.UseVisualStyleBackColor = false;
            // 
            // btnMarkResolved
            // 
            btnMarkResolved.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnMarkResolved.BackColor = Color.ForestGreen;
            btnMarkResolved.FlatStyle = FlatStyle.Flat;
            btnMarkResolved.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMarkResolved.ForeColor = Color.White;
            btnMarkResolved.Location = new Point(335, 555);
            btnMarkResolved.Name = "btnMarkResolved";
            btnMarkResolved.Size = new Size(280, 45);
            btnMarkResolved.TabIndex = 12;
            btnMarkResolved.Text = "MARK AS RESOLVED";
            btnMarkResolved.UseVisualStyleBackColor = false;
            // 
            // MaintenanceControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(pnlEditor);
            Controls.Add(pnlMainGrid);
            Controls.Add(pnlKpiCompleted);
            Controls.Add(pnlKpiUrgent);
            Controls.Add(pnlKpiOpen);
            Font = new Font("Segoe UI", 9.75F);
            Name = "MaintenanceControl";
            Size = new Size(1740, 639);
            pnlKpiOpen.ResumeLayout(false);
            pnlKpiOpen.PerformLayout();
            pnlKpiUrgent.ResumeLayout(false);
            pnlKpiUrgent.PerformLayout();
            pnlKpiCompleted.ResumeLayout(false);
            pnlKpiCompleted.PerformLayout();
            pnlMainGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTickets).EndInit();
            pnlGridHeader.ResumeLayout(false);
            pnlGridHeader.PerformLayout();
            pnlEditor.ResumeLayout(false);
            pnlEditor.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlKpiOpen;
        private Label lbKpiOpenTitle;
        private Label lbKpiOpenValue;
        private Label lbKpiOpenSub;

        private Panel pnlKpiUrgent;
        private Label lbKpiUrgentTitle;
        private Label lbKpiUrgentValue;
        private Label lbKpiUrgentSub;

        private Panel pnlKpiCompleted;
        private Label lbKpiCompletedTitle;
        private Label lbKpiCompletedValue;
        private Label lbKpiCompletedSub;

        private Panel pnlMainGrid;
        private Panel pnlGridHeader;
        private Label lbTicketsTitle;
        private Button btnFilterOpen;
        private Button btnFilterInProgress;
        private Button btnFilterAll;

        private DataGridView dgvTickets;
        private DataGridViewTextBoxColumn colTicketId;
        private DataGridViewTextBoxColumn colRoomNum;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colPriority;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colAssignedTo;

        private Panel pnlEditor;
        private Label lbEditorTitle;
        private Label lbRoom;
        private ComboBox cbRoomSelect;
        private Label lbCategory;
        private ComboBox cbCategorySelect;
        private Label lbPriority;
        private ComboBox cbPrioritySelect;
        private Label lbAssignedTo;
        private ComboBox cbAssigneeSelect;
        private Label lbDescription;
        private TextBox txtDescription;
        private Button btnSaveTicket;
        private Button btnMarkResolved;
    }
}