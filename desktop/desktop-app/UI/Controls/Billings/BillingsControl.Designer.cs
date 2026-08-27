using System.Drawing;
using System.Windows.Forms;

namespace Hotel_erp_Winforms_App.UI.Controls
{
    partial class BillingsControl : UserControl
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
            pnlKpiTotal = new Panel();
            lbKpiTotalTitle = new Label();
            lbKpiTotalValue = new Label();
            lbKpiTotalSub = new Label();
            pnlKpiPaid = new Panel();
            lbKpiPaidTitle = new Label();
            lbKpiPaidValue = new Label();
            lbKpiPaidSub = new Label();
            pnlKpiPending = new Panel();
            lbKpiPendingTitle = new Label();
            lbKpiPendingValue = new Label();
            lbKpiPendingSub = new Label();
            pnlMainGrid = new Panel();
            dgvInvoices = new DataGridView();
            colInvoiceNum = new DataGridViewTextBoxColumn();
            colGuestName = new DataGridViewTextBoxColumn();
            colRoomNum = new DataGridViewTextBoxColumn();
            colIssueDate = new DataGridViewTextBoxColumn();
            colTotalAmount = new DataGridViewTextBoxColumn();
            colPaymentMethod = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            pnlGridHeader = new Panel();
            lbInvoicesTitle = new Label();
            btnFilterAll = new Button();
            btnFilterPending = new Button();
            btnFilterPaid = new Button();
            pnlEditor = new Panel();
            lbEditorTitle = new Label();
            lbGuestSelect = new Label();
            cbGuestSelect = new ComboBox();
            lbRoomSelect = new Label();
            cbRoomSelect = new ComboBox();
            lbPaymentMethod = new Label();
            cbPaymentMethod = new ComboBox();
            lbAmount = new Label();
            txtAmount = new TextBox();
            lbTaxRate = new Label();
            cbTaxRate = new ComboBox();
            btnCreateInvoice = new Button();
            btnPrintInvoice = new Button();
            pnlKpiTotal.SuspendLayout();
            pnlKpiPaid.SuspendLayout();
            pnlKpiPending.SuspendLayout();
            pnlMainGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).BeginInit();
            pnlGridHeader.SuspendLayout();
            pnlEditor.SuspendLayout();
            SuspendLayout();
            // 
            // pnlKpiTotal
            // 
            pnlKpiTotal.BackColor = Color.White;
            pnlKpiTotal.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiTotal.Controls.Add(lbKpiTotalSub);
            pnlKpiTotal.Controls.Add(lbKpiTotalValue);
            pnlKpiTotal.Controls.Add(lbKpiTotalTitle);
            pnlKpiTotal.Location = new Point(10, 10);
            pnlKpiTotal.Name = "pnlKpiTotal";
            pnlKpiTotal.Size = new Size(350, 80);
            pnlKpiTotal.TabIndex = 0;
            // 
            // lbKpiTotalTitle
            // 
            lbKpiTotalTitle.AutoSize = true;
            lbKpiTotalTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiTotalTitle.ForeColor = Color.DimGray;
            lbKpiTotalTitle.Location = new Point(12, 10);
            lbKpiTotalTitle.Name = "lbKpiTotalTitle";
            lbKpiTotalTitle.Size = new Size(137, 15);
            lbKpiTotalTitle.TabIndex = 0;
            lbKpiTotalTitle.Text = "TOTAL REVENUE (MONTH)";
            // 
            // lbKpiTotalValue
            // 
            lbKpiTotalValue.AutoSize = true;
            lbKpiTotalValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbKpiTotalValue.ForeColor = Color.FromArgb(24, 60, 142);
            lbKpiTotalValue.Location = new Point(10, 26);
            lbKpiTotalValue.Name = "lbKpiTotalValue";
            lbKpiTotalValue.Size = new Size(65, 30);
            lbKpiTotalValue.TabIndex = 1;
            lbKpiTotalValue.Text = "$ 0.00";
            // 
            // lbKpiTotalSub
            // 
            lbKpiTotalSub.AutoSize = true;
            lbKpiTotalSub.Font = new Font("Segoe UI", 8F);
            lbKpiTotalSub.ForeColor = Color.Gray;
            lbKpiTotalSub.Location = new Point(12, 57);
            lbKpiTotalSub.Name = "lbKpiTotalSub";
            lbKpiTotalSub.Size = new Size(111, 13);
            lbKpiTotalSub.TabIndex = 2;
            lbKpiTotalSub.Text = "Current month gross";
            // 
            // pnlKpiPaid
            // 
            pnlKpiPaid.BackColor = Color.White;
            pnlKpiPaid.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiPaid.Controls.Add(lbKpiPaidSub);
            pnlKpiPaid.Controls.Add(lbKpiPaidValue);
            pnlKpiPaid.Controls.Add(lbKpiPaidTitle);
            pnlKpiPaid.Location = new Point(370, 10);
            pnlKpiPaid.Name = "pnlKpiPaid";
            pnlKpiPaid.Size = new Size(350, 80);
            pnlKpiPaid.TabIndex = 1;
            // 
            // lbKpiPaidTitle
            // 
            lbKpiPaidTitle.AutoSize = true;
            lbKpiPaidTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiPaidTitle.ForeColor = Color.DimGray;
            lbKpiPaidTitle.Location = new Point(12, 10);
            lbKpiPaidTitle.Name = "lbKpiPaidTitle";
            lbKpiPaidTitle.Size = new Size(89, 15);
            lbKpiPaidTitle.TabIndex = 0;
            lbKpiPaidTitle.Text = "PAID INVOICES";
            // 
            // lbKpiPaidValue
            // 
            lbKpiPaidValue.AutoSize = true;
            lbKpiPaidValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbKpiPaidValue.ForeColor = Color.ForestGreen;
            lbKpiPaidValue.Location = new Point(10, 26);
            lbKpiPaidValue.Name = "lbKpiPaidValue";
            lbKpiPaidValue.Size = new Size(65, 30);
            lbKpiPaidValue.TabIndex = 1;
            lbKpiPaidValue.Text = "$ 0.00";
            // 
            // lbKpiPaidSub
            // 
            lbKpiPaidSub.AutoSize = true;
            lbKpiPaidSub.Font = new Font("Segoe UI", 8F);
            lbKpiPaidSub.ForeColor = Color.Gray;
            lbKpiPaidSub.Location = new Point(12, 57);
            lbKpiPaidSub.Name = "lbKpiPaidSub";
            lbKpiPaidSub.Size = new Size(116, 13);
            lbKpiPaidSub.TabIndex = 2;
            lbKpiPaidSub.Text = "Settled transactions";
            // 
            // pnlKpiPending
            // 
            pnlKpiPending.BackColor = Color.White;
            pnlKpiPending.BorderStyle = BorderStyle.FixedSingle;
            pnlKpiPending.Controls.Add(lbKpiPendingSub);
            pnlKpiPending.Controls.Add(lbKpiPendingValue);
            pnlKpiPending.Controls.Add(lbKpiPendingTitle);
            pnlKpiPending.Location = new Point(730, 10);
            pnlKpiPending.Name = "pnlKpiPending";
            pnlKpiPending.Size = new Size(350, 80);
            pnlKpiPending.TabIndex = 2;
            // 
            // lbKpiPendingTitle
            // 
            lbKpiPendingTitle.AutoSize = true;
            lbKpiPendingTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbKpiPendingTitle.ForeColor = Color.DimGray;
            lbKpiPendingTitle.Location = new Point(12, 10);
            lbKpiPendingTitle.Name = "lbKpiPendingTitle";
            lbKpiPendingTitle.Size = new Size(115, 15);
            lbKpiPendingTitle.TabIndex = 0;
            lbKpiPendingTitle.Text = "PENDING PAYMENT";
            // 
            // lbKpiPendingValue
            // 
            lbKpiPendingValue.AutoSize = true;
            lbKpiPendingValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbKpiPendingValue.ForeColor = Color.DarkOrange;
            lbKpiPendingValue.Location = new Point(10, 26);
            lbKpiPendingValue.Name = "lbKpiPendingValue";
            lbKpiPendingValue.Size = new Size(65, 30);
            lbKpiPendingValue.TabIndex = 1;
            lbKpiPendingValue.Text = "$ 0.00";
            // 
            // lbKpiPendingSub
            // 
            lbKpiPendingSub.AutoSize = true;
            lbKpiPendingSub.Font = new Font("Segoe UI", 8F);
            lbKpiPendingSub.ForeColor = Color.Gray;
            lbKpiPendingSub.Location = new Point(12, 57);
            lbKpiPendingSub.Name = "lbKpiPendingSub";
            lbKpiPendingSub.Size = new Size(119, 13);
            lbKpiPendingSub.TabIndex = 2;
            lbKpiPendingSub.Text = "Awaiting checkout pay";
            // 
            // pnlMainGrid
            // 
            pnlMainGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlMainGrid.BackColor = Color.White;
            pnlMainGrid.BorderStyle = BorderStyle.FixedSingle;
            pnlMainGrid.Controls.Add(dgvInvoices);
            pnlMainGrid.Controls.Add(pnlGridHeader);
            pnlMainGrid.Location = new Point(10, 100);
            pnlMainGrid.Name = "pnlMainGrid";
            pnlMainGrid.Size = new Size(1070, 525);
            pnlMainGrid.TabIndex = 3;
            // 
            // dgvInvoices
            // 
            dgvInvoices.AllowUserToAddRows = false;
            dgvInvoices.AllowUserToDeleteRows = false;
            dgvInvoices.BackgroundColor = Color.White;
            dgvInvoices.BorderStyle = BorderStyle.None;
            dgvHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = Color.FromArgb(24, 60, 142);
            dgvHeaderStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvHeaderStyle.ForeColor = Color.White;
            dgvHeaderStyle.SelectionBackColor = Color.FromArgb(24, 60, 142);
            dgvHeaderStyle.SelectionForeColor = SystemColors.HighlightText;
            dgvInvoices.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            dgvInvoices.ColumnHeadersHeight = 35;
            dgvInvoices.Columns.AddRange(new DataGridViewColumn[] { colInvoiceNum, colGuestName, colRoomNum, colIssueDate, colTotalAmount, colPaymentMethod, colStatus });
            dgvInvoices.Dock = DockStyle.Fill;
            dgvInvoices.EnableHeadersVisualStyles = false;
            dgvInvoices.Location = new Point(0, 50);
            dgvInvoices.MultiSelect = false;
            dgvInvoices.Name = "dgvInvoices";
            dgvInvoices.ReadOnly = true;
            dgvInvoices.RowHeadersVisible = false;
            dgvInvoices.RowTemplate.Height = 30;
            dgvInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoices.Size = new Size(1068, 473);
            dgvInvoices.TabIndex = 1;
            // 
            // colInvoiceNum
            // 
            colInvoiceNum.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colInvoiceNum.FillWeight = 15F;
            colInvoiceNum.HeaderText = "Invoice #";
            colInvoiceNum.Name = "colInvoiceNum";
            colInvoiceNum.ReadOnly = true;
            // 
            // colGuestName
            // 
            colGuestName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colGuestName.FillWeight = 25F;
            colGuestName.HeaderText = "Guest Name";
            colGuestName.Name = "colGuestName";
            colGuestName.ReadOnly = true;
            // 
            // colRoomNum
            // 
            colRoomNum.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRoomNum.FillWeight = 10F;
            colRoomNum.HeaderText = "Room";
            colRoomNum.Name = "colRoomNum";
            colRoomNum.ReadOnly = true;
            // 
            // colIssueDate
            // 
            colIssueDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colIssueDate.FillWeight = 15F;
            colIssueDate.HeaderText = "Issue Date";
            colIssueDate.Name = "colIssueDate";
            colIssueDate.ReadOnly = true;
            // 
            // colTotalAmount
            // 
            colTotalAmount.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTotalAmount.FillWeight = 15F;
            colTotalAmount.HeaderText = "Total Amount";
            colTotalAmount.Name = "colTotalAmount";
            colTotalAmount.ReadOnly = true;
            // 
            // colPaymentMethod
            // 
            colPaymentMethod.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPaymentMethod.FillWeight = 12F;
            colPaymentMethod.HeaderText = "Method";
            colPaymentMethod.Name = "colPaymentMethod";
            colPaymentMethod.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colStatus.FillWeight = 12F;
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // pnlGridHeader
            // 
            pnlGridHeader.BackColor = Color.FromArgb(248, 249, 250);
            pnlGridHeader.Controls.Add(btnFilterAll);
            pnlGridHeader.Controls.Add(btnFilterPending);
            pnlGridHeader.Controls.Add(btnFilterPaid);
            pnlGridHeader.Controls.Add(lbInvoicesTitle);
            pnlGridHeader.Dock = DockStyle.Top;
            pnlGridHeader.Location = new Point(0, 0);
            pnlGridHeader.Name = "pnlGridHeader";
            pnlGridHeader.Size = new Size(1068, 50);
            pnlGridHeader.TabIndex = 0;
            // 
            // lbInvoicesTitle
            // 
            lbInvoicesTitle.AutoSize = true;
            lbInvoicesTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lbInvoicesTitle.Location = new Point(15, 14);
            lbInvoicesTitle.Name = "lbInvoicesTitle";
            lbInvoicesTitle.Size = new Size(111, 20);
            lbInvoicesTitle.TabIndex = 0;
            lbInvoicesTitle.Text = "INVOICE LIST";
            // 
            // btnFilterAll
            // 
            btnFilterAll.FlatStyle = FlatStyle.Flat;
            btnFilterAll.Location = new Point(320, 12);
            btnFilterAll.Name = "btnFilterAll";
            btnFilterAll.Size = new Size(75, 26);
            btnFilterAll.TabIndex = 3;
            btnFilterAll.Text = "All";
            btnFilterAll.UseVisualStyleBackColor = true;
            // 
            // btnFilterPending
            // 
            btnFilterPending.FlatStyle = FlatStyle.Flat;
            btnFilterPending.Location = new Point(230, 12);
            btnFilterPending.Name = "btnFilterPending";
            btnFilterPending.Size = new Size(80, 26);
            btnFilterPending.TabIndex = 2;
            btnFilterPending.Text = "Pending";
            btnFilterPending.UseVisualStyleBackColor = true;
            // 
            // btnFilterPaid
            // 
            btnFilterPaid.FlatStyle = FlatStyle.Flat;
            btnFilterPaid.Location = new Point(140, 12);
            btnFilterPaid.Name = "btnFilterPaid";
            btnFilterPaid.Size = new Size(80, 26);
            btnFilterPaid.TabIndex = 1;
            btnFilterPaid.Text = "Paid";
            btnFilterPaid.UseVisualStyleBackColor = true;
            // 
            // pnlEditor
            // 
            pnlEditor.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlEditor.BackColor = Color.White;
            pnlEditor.BorderStyle = BorderStyle.FixedSingle;
            pnlEditor.Controls.Add(btnPrintInvoice);
            pnlEditor.Controls.Add(btnCreateInvoice);
            pnlEditor.Controls.Add(cbTaxRate);
            pnlEditor.Controls.Add(lbTaxRate);
            pnlEditor.Controls.Add(txtAmount);
            pnlEditor.Controls.Add(lbAmount);
            pnlEditor.Controls.Add(cbPaymentMethod);
            pnlEditor.Controls.Add(lbPaymentMethod);
            pnlEditor.Controls.Add(cbRoomSelect);
            pnlEditor.Controls.Add(lbRoomSelect);
            pnlEditor.Controls.Add(cbGuestSelect);
            pnlEditor.Controls.Add(lbGuestSelect);
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
            lbEditorTitle.Size = new Size(202, 21);
            lbEditorTitle.TabIndex = 0;
            lbEditorTitle.Text = "NEW INVOICE / PAYMENT";
            // 
            // lbGuestSelect
            // 
            lbGuestSelect.AutoSize = true;
            lbGuestSelect.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbGuestSelect.Location = new Point(15, 55);
            lbGuestSelect.Name = "lbGuestSelect";
            lbGuestSelect.Size = new Size(78, 15);
            lbGuestSelect.TabIndex = 1;
            lbGuestSelect.Text = "Select Guest:";
            // 
            // cbGuestSelect
            // 
            cbGuestSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGuestSelect.FormattingEnabled = true;
            cbGuestSelect.Location = new Point(15, 75);
            cbGuestSelect.Name = "cbGuestSelect";
            cbGuestSelect.Size = new Size(600, 25);
            cbGuestSelect.TabIndex = 2;
            // 
            // lbRoomSelect
            // 
            lbRoomSelect.AutoSize = true;
            lbRoomSelect.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbRoomSelect.Location = new Point(15, 115);
            lbRoomSelect.Name = "lbRoomSelect";
            lbRoomSelect.Size = new Size(79, 15);
            lbRoomSelect.TabIndex = 3;
            lbRoomSelect.Text = "Select Room:";
            // 
            // cbRoomSelect
            // 
            cbRoomSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRoomSelect.FormattingEnabled = true;
            cbRoomSelect.Location = new Point(15, 135);
            cbRoomSelect.Name = "cbRoomSelect";
            cbRoomSelect.Size = new Size(600, 25);
            cbRoomSelect.TabIndex = 4;
            // 
            // lbPaymentMethod
            // 
            lbPaymentMethod.AutoSize = true;
            lbPaymentMethod.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbPaymentMethod.Location = new Point(15, 175);
            lbPaymentMethod.Name = "lbPaymentMethod";
            lbPaymentMethod.Size = new Size(107, 15);
            lbPaymentMethod.TabIndex = 5;
            lbPaymentMethod.Text = "Payment Method:";
            // 
            // cbPaymentMethod
            // 
            cbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPaymentMethod.FormattingEnabled = true;
            cbPaymentMethod.Items.AddRange(new object[] { "Credit Card", "Cash", "Bank Transfer" });
            cbPaymentMethod.Location = new Point(15, 195);
            cbPaymentMethod.Name = "cbPaymentMethod";
            cbPaymentMethod.Size = new Size(280, 25);
            cbPaymentMethod.TabIndex = 6;
            // 
            // lbAmount
            // 
            lbAmount.AutoSize = true;
            lbAmount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbAmount.Location = new Point(335, 175);
            lbAmount.Name = "lbAmount";
            lbAmount.Size = new Size(88, 15);
            lbAmount.TabIndex = 7;
            lbAmount.Text = "Amount ($/€):";
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(335, 195);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(280, 25);
            txtAmount.TabIndex = 8;
            // 
            // lbTaxRate
            // 
            lbTaxRate.AutoSize = true;
            lbTaxRate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbTaxRate.Location = new Point(15, 235);
            lbTaxRate.Name = "lbTaxRate";
            lbTaxRate.Size = new Size(60, 15);
            lbTaxRate.TabIndex = 9;
            lbTaxRate.Text = "Tax Rate:";
            // 
            // cbTaxRate
            // 
            cbTaxRate.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTaxRate.FormattingEnabled = true;
            cbTaxRate.Items.AddRange(new object[] { "5%", "18%", "27%" });
            cbTaxRate.Location = new Point(15, 255);
            cbTaxRate.Name = "cbTaxRate";
            cbTaxRate.Size = new Size(280, 25);
            cbTaxRate.TabIndex = 10;
            // 
            // btnCreateInvoice
            // 
            btnCreateInvoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCreateInvoice.BackColor = Color.FromArgb(24, 60, 142);
            btnCreateInvoice.FlatStyle = FlatStyle.Flat;
            btnCreateInvoice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreateInvoice.ForeColor = Color.White;
            btnCreateInvoice.Location = new Point(15, 555);
            btnCreateInvoice.Name = "btnCreateInvoice";
            btnCreateInvoice.Size = new Size(280, 45);
            btnCreateInvoice.TabIndex = 11;
            btnCreateInvoice.Text = "GENERATE INVOICE";
            btnCreateInvoice.UseVisualStyleBackColor = false;
            // 
            // btnPrintInvoice
            // 
            btnPrintInvoice.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPrintInvoice.BackColor = Color.ForestGreen;
            btnPrintInvoice.FlatStyle = FlatStyle.Flat;
            btnPrintInvoice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPrintInvoice.ForeColor = Color.White;
            btnPrintInvoice.Location = new Point(335, 555);
            btnPrintInvoice.Name = "btnPrintInvoice";
            btnPrintInvoice.Size = new Size(280, 45);
            btnPrintInvoice.TabIndex = 12;
            btnPrintInvoice.Text = "PRINT / EXPORT PDF";
            btnPrintInvoice.UseVisualStyleBackColor = false;
            // 
            // BillingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 249, 250);
            Controls.Add(pnlEditor);
            Controls.Add(pnlMainGrid);
            Controls.Add(pnlKpiPending);
            Controls.Add(pnlKpiPaid);
            Controls.Add(pnlKpiTotal);
            Font = new Font("Segoe UI", 9.75F);
            Name = "BillingControl";
            Size = new Size(1740, 639);
            pnlKpiTotal.ResumeLayout(false);
            pnlKpiTotal.PerformLayout();
            pnlKpiPaid.ResumeLayout(false);
            pnlKpiPaid.PerformLayout();
            pnlKpiPending.ResumeLayout(false);
            pnlKpiPending.PerformLayout();
            pnlMainGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInvoices).EndInit();
            pnlGridHeader.ResumeLayout(false);
            pnlGridHeader.PerformLayout();
            pnlEditor.ResumeLayout(false);
            pnlEditor.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlKpiTotal;
        private Label lbKpiTotalTitle;
        private Label lbKpiTotalValue;
        private Label lbKpiTotalSub;

        private Panel pnlKpiPaid;
        private Label lbKpiPaidTitle;
        private Label lbKpiPaidValue;
        private Label lbKpiPaidSub;

        private Panel pnlKpiPending;
        private Label lbKpiPendingTitle;
        private Label lbKpiPendingValue;
        private Label lbKpiPendingSub;

        private Panel pnlMainGrid;
        private Panel pnlGridHeader;
        private Label lbInvoicesTitle;
        private Button btnFilterPaid;
        private Button btnFilterPending;
        private Button btnFilterAll;

        private DataGridView dgvInvoices;
        private DataGridViewTextBoxColumn colInvoiceNum;
        private DataGridViewTextBoxColumn colGuestName;
        private DataGridViewTextBoxColumn colRoomNum;
        private DataGridViewTextBoxColumn colIssueDate;
        private DataGridViewTextBoxColumn colTotalAmount;
        private DataGridViewTextBoxColumn colPaymentMethod;
        private DataGridViewTextBoxColumn colStatus;

        private Panel pnlEditor;
        private Label lbEditorTitle;
        private Label lbGuestSelect;
        private ComboBox cbGuestSelect;
        private Label lbRoomSelect;
        private ComboBox cbRoomSelect;
        private Label lbPaymentMethod;
        private ComboBox cbPaymentMethod;
        private Label lbAmount;
        private TextBox txtAmount;
        private Label lbTaxRate;
        private ComboBox cbTaxRate;
        private Button btnCreateInvoice;
        private Button btnPrintInvoice;
    }
}