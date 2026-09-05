namespace Hotel_erp_Winforms_App.UI.Forms;

public partial class FrmCheckout : Form
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        grpGuestDetails = new GroupBox();
        dtpCheckOutDate = new DateTimePicker();
        dtpCheckInDate = new DateTimePicker();
        txtGuestName = new TextBox();
        txtRoomNumber = new TextBox();
        lblCheckOutDate = new Label();
        lblCheckInDate = new Label();
        lblGuestName = new Label();
        lblRoomNumber = new Label();
        grpConsumption = new GroupBox();
        dgvItems = new DataGridView();
        colName = new DataGridViewTextBoxColumn();
        colQuantity = new DataGridViewTextBoxColumn();
        colUnitPrice = new DataGridViewTextBoxColumn();
        colTotalPrice = new DataGridViewTextBoxColumn();
        grpSummary = new GroupBox();
        lblPaymentMethod = new Label();
        cmbPaymentMethod = new ComboBox();
        lblTotalAmount = new Label();
        lblTotal = new Label();
        lblCatering = new Label();
        lblExtraCharge = new Label();
        lblRoomPrice = new Label();
        btnCompleteCheckout = new Button();
        btnCancel = new Button();
        grpGuestDetails.SuspendLayout();
        grpConsumption.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
        grpSummary.SuspendLayout();
        SuspendLayout();
        // 
        // grpGuestDetails
        // 
        grpGuestDetails.Controls.Add(dtpCheckOutDate);
        grpGuestDetails.Controls.Add(dtpCheckInDate);
        grpGuestDetails.Controls.Add(txtGuestName);
        grpGuestDetails.Controls.Add(txtRoomNumber);
        grpGuestDetails.Controls.Add(lblCheckOutDate);
        grpGuestDetails.Controls.Add(lblCheckInDate);
        grpGuestDetails.Controls.Add(lblGuestName);
        grpGuestDetails.Controls.Add(lblRoomNumber);
        grpGuestDetails.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grpGuestDetails.Location = new Point(12, 12);
        grpGuestDetails.Name = "grpGuestDetails";
        grpGuestDetails.Size = new Size(760, 100);
        grpGuestDetails.TabIndex = 0;
        grpGuestDetails.TabStop = false;
        grpGuestDetails.Text = "Guest and Reservation Details";
        // 
        // dtpCheckOutDate
        // 
        dtpCheckOutDate.Enabled = false;
        dtpCheckOutDate.Font = new Font("Segoe UI", 9F);
        dtpCheckOutDate.Format = DateTimePickerFormat.Short;
        dtpCheckOutDate.Location = new Point(385, 61);
        dtpCheckOutDate.Name = "dtpCheckOutDate";
        dtpCheckOutDate.Size = new Size(150, 23);
        dtpCheckOutDate.TabIndex = 0;
        dtpCheckOutDate.TabStop = false;
        // 
        // dtpCheckInDate
        // 
        dtpCheckInDate.Enabled = false;
        dtpCheckInDate.Font = new Font("Segoe UI", 9F);
        dtpCheckInDate.Format = DateTimePickerFormat.Short;
        dtpCheckInDate.Location = new Point(115, 61);
        dtpCheckInDate.Name = "dtpCheckInDate";
        dtpCheckInDate.Size = new Size(150, 23);
        dtpCheckInDate.TabIndex = 1;
        dtpCheckInDate.TabStop = false;
        // 
        // txtGuestName
        // 
        txtGuestName.Font = new Font("Segoe UI", 9F);
        txtGuestName.Location = new Point(320, 27);
        txtGuestName.Name = "txtGuestName";
        txtGuestName.ReadOnly = true;
        txtGuestName.Size = new Size(420, 23);
        txtGuestName.TabIndex = 2;
        txtGuestName.TabStop = false;
        // 
        // txtRoomNumber
        // 
        txtRoomNumber.Font = new Font("Segoe UI", 9F);
        txtRoomNumber.Location = new Point(115, 27);
        txtRoomNumber.Name = "txtRoomNumber";
        txtRoomNumber.ReadOnly = true;
        txtRoomNumber.Size = new Size(100, 23);
        txtRoomNumber.TabIndex = 3;
        txtRoomNumber.TabStop = false;
        // 
        // lblCheckOutDate
        // 
        lblCheckOutDate.AutoSize = true;
        lblCheckOutDate.Font = new Font("Segoe UI", 9F);
        lblCheckOutDate.Location = new Point(285, 65);
        lblCheckOutDate.Name = "lblCheckOutDate";
        lblCheckOutDate.Size = new Size(95, 15);
        lblCheckOutDate.TabIndex = 4;
        lblCheckOutDate.Text = "Check-Out Date:";
        // 
        // lblCheckInDate
        // 
        lblCheckInDate.AutoSize = true;
        lblCheckInDate.Font = new Font("Segoe UI", 9F);
        lblCheckInDate.Location = new Point(15, 65);
        lblCheckInDate.Name = "lblCheckInDate";
        lblCheckInDate.Size = new Size(85, 15);
        lblCheckInDate.TabIndex = 5;
        lblCheckInDate.Text = "Check-In Date:";
        // 
        // lblGuestName
        // 
        lblGuestName.AutoSize = true;
        lblGuestName.Font = new Font("Segoe UI", 9F);
        lblGuestName.Location = new Point(235, 30);
        lblGuestName.Name = "lblGuestName";
        lblGuestName.Size = new Size(75, 15);
        lblGuestName.TabIndex = 6;
        lblGuestName.Text = "Guest Name:";
        // 
        // lblRoomNumber
        // 
        lblRoomNumber.AutoSize = true;
        lblRoomNumber.Font = new Font("Segoe UI", 9F);
        lblRoomNumber.Location = new Point(15, 30);
        lblRoomNumber.Name = "lblRoomNumber";
        lblRoomNumber.Size = new Size(89, 15);
        lblRoomNumber.TabIndex = 7;
        lblRoomNumber.Text = "Room Number:";
        // 
        // grpConsumption
        // 
        grpConsumption.Controls.Add(dgvItems);
        grpConsumption.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grpConsumption.Location = new Point(12, 125);
        grpConsumption.Name = "grpConsumption";
        grpConsumption.Size = new Size(760, 220);
        grpConsumption.TabIndex = 1;
        grpConsumption.TabStop = false;
        grpConsumption.Text = "Consumption and Extra Services";
        // 
        // dgvItems
        // 
        dgvItems.AllowUserToAddRows = false;
        dgvItems.AllowUserToDeleteRows = false;
        dgvItems.AllowUserToOrderColumns = true;
        dgvItems.AllowUserToResizeColumns = false;
        dgvItems.AllowUserToResizeRows = false;
        dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvItems.Columns.AddRange(new DataGridViewColumn[] { colName, colQuantity, colUnitPrice, colTotalPrice });
        dgvItems.Dock = DockStyle.Fill;
        dgvItems.Location = new Point(3, 19);
        dgvItems.Name = "dgvItems";
        dgvItems.ReadOnly = true;
        dgvItems.RowHeadersVisible = false;
        dgvItems.Size = new Size(754, 198);
        dgvItems.TabIndex = 0;
        dgvItems.TabStop = false;
        dgvItems.CellClick += dgvItems_CellClick;
        // 
        // colName
        // 
        colName.DataPropertyName = "Name";
        colName.HeaderText = "Description";
        colName.Name = "colName";
        colName.ReadOnly = true;
        // 
        // colQuantity
        // 
        colQuantity.DataPropertyName = "Quantity";
        colQuantity.HeaderText = "Quantity";
        colQuantity.Name = "colQuantity";
        colQuantity.ReadOnly = true;
        // 
        // colUnitPrice
        // 
        colUnitPrice.DataPropertyName = "UnitPrice";
        colUnitPrice.HeaderText = "Unit Price (HUF)";
        colUnitPrice.Name = "colUnitPrice";
        colUnitPrice.ReadOnly = true;
        // 
        // colTotalPrice
        // 
        colTotalPrice.DataPropertyName = "TotalPrice";
        colTotalPrice.HeaderText = "Total Price (HUF)";
        colTotalPrice.Name = "colTotalPrice";
        colTotalPrice.ReadOnly = true;
        // 
        // grpSummary
        // 
        grpSummary.Controls.Add(lblPaymentMethod);
        grpSummary.Controls.Add(cmbPaymentMethod);
        grpSummary.Controls.Add(lblTotalAmount);
        grpSummary.Controls.Add(lblTotal);
        grpSummary.Controls.Add(lblCatering);
        grpSummary.Controls.Add(lblExtraCharge);
        grpSummary.Controls.Add(lblRoomPrice);
        grpSummary.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grpSummary.Location = new Point(12, 355);
        grpSummary.Name = "grpSummary";
        grpSummary.Size = new Size(760, 130);
        grpSummary.TabIndex = 2;
        grpSummary.TabStop = false;
        grpSummary.Text = "Summary and Payment";
        // 
        // lblPaymentMethod
        // 
        lblPaymentMethod.AutoSize = true;
        lblPaymentMethod.Font = new Font("Segoe UI", 9F);
        lblPaymentMethod.Location = new Point(430, 30);
        lblPaymentMethod.Name = "lblPaymentMethod";
        lblPaymentMethod.Size = new Size(102, 15);
        lblPaymentMethod.TabIndex = 0;
        lblPaymentMethod.Text = "Payment Method:";
        // 
        // cmbPaymentMethod
        // 
        cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbPaymentMethod.Font = new Font("Segoe UI", 9F);
        cmbPaymentMethod.FormattingEnabled = true;
        cmbPaymentMethod.Items.AddRange(new object[] { "Cash", "Credit / Debit Card", "Bank Transfer" });
        cmbPaymentMethod.Location = new Point(535, 27);
        cmbPaymentMethod.Name = "cmbPaymentMethod";
        cmbPaymentMethod.Size = new Size(200, 23);
        cmbPaymentMethod.TabIndex = 1;
        // 
        // lblTotalAmount
        // 
        lblTotalAmount.AutoSize = true;
        lblTotalAmount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblTotalAmount.ForeColor = Color.DarkGreen;
        lblTotalAmount.Location = new Point(157, 96);
        lblTotalAmount.Name = "lblTotalAmount";
        lblTotalAmount.Size = new Size(49, 20);
        lblTotalAmount.TabIndex = 2;
        lblTotalAmount.Text = "$0.00";
        // 
        // lblTotal
        // 
        lblTotal.AutoSize = true;
        lblTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblTotal.ForeColor = Color.DarkGreen;
        lblTotal.Location = new Point(20, 96);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(142, 20);
        lblTotal.TabIndex = 3;
        lblTotal.Text = "Total Amount Due:";
        // 
        // lblCatering
        // 
        lblCatering.AutoSize = true;
        lblCatering.Font = new Font("Segoe UI", 9F);
        lblCatering.Location = new Point(20, 68);
        lblCatering.Name = "lblCatering";
        lblCatering.Size = new Size(98, 15);
        lblCatering.TabIndex = 4;
        lblCatering.Text = "Catering (HUF): 0";
        // 
        // lblExtraCharge
        // 
        lblExtraCharge.AutoSize = true;
        lblExtraCharge.Font = new Font("Segoe UI", 9F);
        lblExtraCharge.Location = new Point(20, 49);
        lblExtraCharge.Name = "lblExtraCharge";
        lblExtraCharge.Size = new Size(146, 15);
        lblExtraCharge.TabIndex = 4;
        lblExtraCharge.Text = "Extras/Services (HUF): 0.00";
        // 
        // lblRoomPrice
        // 
        lblRoomPrice.AutoSize = true;
        lblRoomPrice.Font = new Font("Segoe UI", 9F);
        lblRoomPrice.Location = new Point(20, 30);
        lblRoomPrice.Name = "lblRoomPrice";
        lblRoomPrice.Size = new Size(129, 15);
        lblRoomPrice.TabIndex = 5;
        lblRoomPrice.Text = "Room Price (HUF): 0.00";
        // 
        // btnCompleteCheckout
        // 
        btnCompleteCheckout.BackColor = Color.MediumSeaGreen;
        btnCompleteCheckout.FlatStyle = FlatStyle.Flat;
        btnCompleteCheckout.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        btnCompleteCheckout.ForeColor = Color.White;
        btnCompleteCheckout.Location = new Point(512, 500);
        btnCompleteCheckout.Name = "btnCompleteCheckout";
        btnCompleteCheckout.Size = new Size(260, 40);
        btnCompleteCheckout.TabIndex = 3;
        btnCompleteCheckout.Text = "Pay and Complete Check-Out";
        btnCompleteCheckout.UseVisualStyleBackColor = false;
        btnCompleteCheckout.Click += btnCompleteCheckout_Click;
        // 
        // btnCancel
        // 
        btnCancel.Font = new Font("Segoe UI", 9.75F);
        btnCancel.Location = new Point(396, 500);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(110, 40);
        btnCancel.TabIndex = 4;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // FrmCheckout
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(784, 555);
        Controls.Add(btnCancel);
        Controls.Add(btnCompleteCheckout);
        Controls.Add(grpSummary);
        Controls.Add(grpConsumption);
        Controls.Add(grpGuestDetails);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmCheckout";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Reception - Check-Out";
        Load += FrmCheckout_Load;
        grpGuestDetails.ResumeLayout(false);
        grpGuestDetails.PerformLayout();
        grpConsumption.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
        grpSummary.ResumeLayout(false);
        grpSummary.PerformLayout();
        ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox grpGuestDetails;
    private System.Windows.Forms.Label lblRoomNumber;
    private System.Windows.Forms.TextBox txtRoomNumber;
    private System.Windows.Forms.Label lblGuestName;
    private System.Windows.Forms.TextBox txtGuestName;
    private System.Windows.Forms.Label lblCheckInDate;
    private System.Windows.Forms.DateTimePicker dtpCheckInDate;
    private System.Windows.Forms.Label lblCheckOutDate;
    private System.Windows.Forms.DateTimePicker dtpCheckOutDate;

    private System.Windows.Forms.GroupBox grpConsumption;
    private System.Windows.Forms.DataGridView dgvItems;

    private System.Windows.Forms.GroupBox grpSummary;
    private System.Windows.Forms.Label lblRoomPrice;
    private System.Windows.Forms.Label lblExtraCharge;
    private System.Windows.Forms.Label lblTotal;
    private System.Windows.Forms.Label lblTotalAmount;
    private System.Windows.Forms.Label lblPaymentMethod;
    private System.Windows.Forms.ComboBox cmbPaymentMethod;

    private System.Windows.Forms.Button btnCompleteCheckout;
    private System.Windows.Forms.Button btnCancel;
    private Label lblCatering;
    private DataGridViewTextBoxColumn colName;
    private DataGridViewTextBoxColumn colQuantity;
    private DataGridViewTextBoxColumn colUnitPrice;
    private DataGridViewTextBoxColumn colTotalPrice;
}