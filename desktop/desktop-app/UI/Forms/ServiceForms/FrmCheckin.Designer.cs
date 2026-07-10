namespace Hotel_erp_Winforms_App.UI.Forms.ServiceForms
{
    partial class FrmCheckin
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
            tcCheckin = new TabControl();
            tpPersonalData = new TabPage();
            cbDocumentType = new ComboBox();
            cbNationality = new ComboBox();
            cbPhoneCountry = new ComboBox();
            tbLastName = new TextBox();
            tbPhone = new TextBox();
            tbDocumentNumber = new TextBox();
            tbMothersName = new TextBox();
            tbEmail = new TextBox();
            tbFirstName = new TextBox();
            label6 = new Label();
            label10 = new Label();
            label15 = new Label();
            label14 = new Label();
            label11 = new Label();
            label9 = new Label();
            label5 = new Label();
            label13 = new Label();
            label4 = new Label();
            label3 = new Label();
            label8 = new Label();
            label7 = new Label();
            label2 = new Label();
            pnlBottom = new Panel();
            label12 = new Label();
            btnNext = new Button();
            pnlTop = new Panel();
            tlpBottom = new TableLayoutPanel();
            line = new Label();
            label1 = new Label();
            tpRoomPick = new TabPage();
            tpExtras = new TabPage();
            tpPaymentSumm = new TabPage();
            tpSummary = new TabPage();
            panel1 = new Panel();
            label29 = new Label();
            button1 = new Button();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label30 = new Label();
            label31 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            tcCheckin.SuspendLayout();
            tpPersonalData.SuspendLayout();
            pnlBottom.SuspendLayout();
            pnlTop.SuspendLayout();
            tlpBottom.SuspendLayout();
            tpRoomPick.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tcCheckin
            // 
            tcCheckin.Appearance = TabAppearance.FlatButtons;
            tcCheckin.Controls.Add(tpPersonalData);
            tcCheckin.Controls.Add(tpRoomPick);
            tcCheckin.Controls.Add(tpExtras);
            tcCheckin.Controls.Add(tpPaymentSumm);
            tcCheckin.Controls.Add(tpSummary);
            tcCheckin.ItemSize = new Size(0, 1);
            tcCheckin.Location = new Point(15, 15);
            tcCheckin.Name = "tcCheckin";
            tcCheckin.SelectedIndex = 0;
            tcCheckin.Size = new Size(543, 714);
            tcCheckin.SizeMode = TabSizeMode.FillToRight;
            tcCheckin.TabIndex = 0;
            // 
            // tpPersonalData
            // 
            tpPersonalData.BackColor = Color.White;
            tpPersonalData.Controls.Add(cbDocumentType);
            tpPersonalData.Controls.Add(cbNationality);
            tpPersonalData.Controls.Add(cbPhoneCountry);
            tpPersonalData.Controls.Add(tbLastName);
            tpPersonalData.Controls.Add(tbPhone);
            tpPersonalData.Controls.Add(tbDocumentNumber);
            tpPersonalData.Controls.Add(tbMothersName);
            tpPersonalData.Controls.Add(tbEmail);
            tpPersonalData.Controls.Add(tbFirstName);
            tpPersonalData.Controls.Add(label6);
            tpPersonalData.Controls.Add(label10);
            tpPersonalData.Controls.Add(label15);
            tpPersonalData.Controls.Add(label14);
            tpPersonalData.Controls.Add(label11);
            tpPersonalData.Controls.Add(label9);
            tpPersonalData.Controls.Add(label5);
            tpPersonalData.Controls.Add(label13);
            tpPersonalData.Controls.Add(label4);
            tpPersonalData.Controls.Add(label3);
            tpPersonalData.Controls.Add(label8);
            tpPersonalData.Controls.Add(label7);
            tpPersonalData.Controls.Add(label2);
            tpPersonalData.Controls.Add(pnlBottom);
            tpPersonalData.Controls.Add(pnlTop);
            tpPersonalData.Location = new Point(4, 5);
            tpPersonalData.Name = "tpPersonalData";
            tpPersonalData.Padding = new Padding(10);
            tpPersonalData.Size = new Size(535, 705);
            tpPersonalData.TabIndex = 0;
            tpPersonalData.Text = "Personal Data";
            // 
            // cbDocumentType
            // 
            cbDocumentType.Font = new Font("Segoe UI", 12F);
            cbDocumentType.FormattingEnabled = true;
            cbDocumentType.Items.AddRange(new object[] { "ID", "Passport" });
            cbDocumentType.Location = new Point(26, 526);
            cbDocumentType.Name = "cbDocumentType";
            cbDocumentType.Size = new Size(138, 29);
            cbDocumentType.TabIndex = 8;
            // 
            // cbNationality
            // 
            cbNationality.Font = new Font("Segoe UI", 12F);
            cbNationality.FormattingEnabled = true;
            cbNationality.Location = new Point(30, 378);
            cbNationality.Name = "cbNationality";
            cbNationality.Size = new Size(465, 29);
            cbNationality.TabIndex = 7;
            // 
            // cbPhoneCountry
            // 
            cbPhoneCountry.Font = new Font("Segoe UI", 12F);
            cbPhoneCountry.FormattingEnabled = true;
            cbPhoneCountry.Location = new Point(30, 303);
            cbPhoneCountry.Name = "cbPhoneCountry";
            cbPhoneCountry.Size = new Size(47, 29);
            cbPhoneCountry.TabIndex = 6;
            // 
            // tbLastName
            // 
            tbLastName.Font = new Font("Segoe UI", 12F);
            tbLastName.Location = new Point(270, 153);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(225, 29);
            tbLastName.TabIndex = 5;
            // 
            // tbPhone
            // 
            tbPhone.Font = new Font("Segoe UI", 12F);
            tbPhone.Location = new Point(85, 303);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(410, 29);
            tbPhone.TabIndex = 5;
            // 
            // tbDocumentNumber
            // 
            tbDocumentNumber.Font = new Font("Segoe UI", 12F);
            tbDocumentNumber.Location = new Point(177, 526);
            tbDocumentNumber.Name = "tbDocumentNumber";
            tbDocumentNumber.Size = new Size(318, 29);
            tbDocumentNumber.TabIndex = 5;
            // 
            // tbMothersName
            // 
            tbMothersName.Font = new Font("Segoe UI", 12F);
            tbMothersName.Location = new Point(26, 452);
            tbMothersName.Name = "tbMothersName";
            tbMothersName.Size = new Size(469, 29);
            tbMothersName.TabIndex = 5;
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 12F);
            tbEmail.Location = new Point(30, 228);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(465, 29);
            tbEmail.TabIndex = 5;
            // 
            // tbFirstName
            // 
            tbFirstName.Font = new Font("Segoe UI", 12F);
            tbFirstName.Location = new Point(30, 153);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(225, 29);
            tbFirstName.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(26, 430);
            label6.Name = "label6";
            label6.Size = new Size(118, 21);
            label6.TabIndex = 4;
            label6.Text = "Mother's Name";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 8F);
            label10.ForeColor = Color.Gray;
            label10.Location = new Point(80, 335);
            label10.Name = "label10";
            label10.Size = new Size(84, 13);
            label10.TabIndex = 4;
            label10.Text = "Phone Number";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 8F);
            label15.ForeColor = Color.Gray;
            label15.Location = new Point(177, 558);
            label15.Name = "label15";
            label15.Size = new Size(104, 13);
            label15.TabIndex = 4;
            label15.Text = "Document Number";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 8F);
            label14.ForeColor = Color.Gray;
            label14.Location = new Point(26, 558);
            label14.Name = "label14";
            label14.Size = new Size(86, 13);
            label14.TabIndex = 4;
            label14.Text = "Document Type";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 8F);
            label11.ForeColor = Color.Gray;
            label11.Location = new Point(26, 410);
            label11.Name = "label11";
            label11.Size = new Size(48, 13);
            label11.TabIndex = 4;
            label11.Text = "Country";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 8F);
            label9.ForeColor = Color.Gray;
            label9.Location = new Point(26, 335);
            label9.Name = "label9";
            label9.Size = new Size(48, 13);
            label9.TabIndex = 4;
            label9.Text = "Country";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(26, 354);
            label5.Name = "label5";
            label5.Size = new Size(86, 21);
            label5.TabIndex = 4;
            label5.Text = "Nationality";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.Location = new Point(26, 502);
            label13.Name = "label13";
            label13.Size = new Size(189, 21);
            label13.TabIndex = 4;
            label13.Text = "Identity Document Details";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(26, 279);
            label4.Name = "label4";
            label4.Size = new Size(113, 21);
            label4.TabIndex = 4;
            label4.Text = "Phone number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(26, 203);
            label3.Name = "label3";
            label3.Size = new Size(134, 21);
            label3.TabIndex = 4;
            label3.Text = "Reservation Email";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 8F);
            label8.ForeColor = Color.Gray;
            label8.Location = new Point(270, 185);
            label8.Name = "label8";
            label8.Size = new Size(59, 13);
            label8.TabIndex = 4;
            label8.Text = "Last Name";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 8F);
            label7.ForeColor = Color.Gray;
            label7.Location = new Point(30, 185);
            label7.Name = "label7";
            label7.Size = new Size(61, 13);
            label7.TabIndex = 4;
            label7.Text = "First Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(26, 129);
            label2.Name = "label2";
            label2.Size = new Size(138, 21);
            label2.TabIndex = 4;
            label2.Text = "Reservation Name";
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(239, 246, 255);
            pnlBottom.Controls.Add(label12);
            pnlBottom.Controls.Add(btnNext);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(10, 595);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(515, 100);
            pnlBottom.TabIndex = 3;
            // 
            // label12
            // 
            label12.BackColor = Color.FromArgb(230, 235, 240);
            label12.Location = new Point(3, 16);
            label12.Name = "label12";
            label12.Size = new Size(509, 1);
            label12.TabIndex = 3;
            label12.Text = "label24";
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(30, 58, 138);
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(377, 36);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(122, 41);
            btnNext.TabIndex = 4;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = false;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(239, 246, 255);
            pnlTop.Controls.Add(tlpBottom);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(10, 10);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(515, 100);
            pnlTop.TabIndex = 2;
            // 
            // tlpBottom
            // 
            tlpBottom.ColumnCount = 1;
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpBottom.Controls.Add(line, 0, 1);
            tlpBottom.Controls.Add(label1, 0, 0);
            tlpBottom.Dock = DockStyle.Fill;
            tlpBottom.Location = new Point(0, 0);
            tlpBottom.Name = "tlpBottom";
            tlpBottom.RowCount = 1;
            tlpBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 19F));
            tlpBottom.Size = new Size(515, 100);
            tlpBottom.TabIndex = 0;
            // 
            // line
            // 
            line.BackColor = Color.FromArgb(230, 235, 240);
            line.Location = new Point(3, 81);
            line.Name = "line";
            line.Size = new Size(509, 1);
            line.TabIndex = 3;
            line.Text = "label24";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(167, 22);
            label1.Name = "label1";
            label1.Size = new Size(180, 37);
            label1.TabIndex = 0;
            label1.Text = "Personal Data";
            // 
            // tpRoomPick
            // 
            tpRoomPick.BackColor = Color.White;
            tpRoomPick.Controls.Add(tableLayoutPanel2);
            tpRoomPick.Controls.Add(panel1);
            tpRoomPick.Controls.Add(panel2);
            tpRoomPick.Location = new Point(4, 5);
            tpRoomPick.Name = "tpRoomPick";
            tpRoomPick.Padding = new Padding(3);
            tpRoomPick.Size = new Size(535, 705);
            tpRoomPick.TabIndex = 1;
            tpRoomPick.Text = "tabPage2";
            // 
            // tpExtras
            // 
            tpExtras.Location = new Point(4, 5);
            tpExtras.Name = "tpExtras";
            tpExtras.Padding = new Padding(3);
            tpExtras.Size = new Size(535, 705);
            tpExtras.TabIndex = 2;
            tpExtras.Text = "tabPage3";
            tpExtras.UseVisualStyleBackColor = true;
            // 
            // tpPaymentSumm
            // 
            tpPaymentSumm.Location = new Point(4, 5);
            tpPaymentSumm.Name = "tpPaymentSumm";
            tpPaymentSumm.Padding = new Padding(3);
            tpPaymentSumm.Size = new Size(535, 705);
            tpPaymentSumm.TabIndex = 3;
            tpPaymentSumm.Text = "tabPage4";
            tpPaymentSumm.UseVisualStyleBackColor = true;
            // 
            // tpSummary
            // 
            tpSummary.Location = new Point(4, 5);
            tpSummary.Name = "tpSummary";
            tpSummary.Padding = new Padding(3);
            tpSummary.Size = new Size(535, 705);
            tpSummary.TabIndex = 4;
            tpSummary.Text = "tabPage5";
            tpSummary.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(239, 246, 255);
            panel1.Controls.Add(label29);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, 602);
            panel1.Name = "panel1";
            panel1.Size = new Size(529, 100);
            panel1.TabIndex = 10;
            // 
            // label29
            // 
            label29.BackColor = Color.FromArgb(230, 235, 240);
            label29.Location = new Point(3, 16);
            label29.Name = "label29";
            label29.Size = new Size(509, 1);
            label29.TabIndex = 3;
            label29.Text = "label24";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(30, 58, 138);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(377, 36);
            button1.Name = "button1";
            button1.Size = new Size(122, 41);
            button1.TabIndex = 4;
            button1.Text = "Next";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(239, 246, 255);
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(529, 100);
            panel2.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(label30, 0, 1);
            tableLayoutPanel1.Controls.Add(label31, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 19F));
            tableLayoutPanel1.Size = new Size(529, 100);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label30
            // 
            label30.BackColor = Color.FromArgb(230, 235, 240);
            label30.Location = new Point(3, 81);
            label30.Name = "label30";
            label30.Size = new Size(509, 1);
            label30.TabIndex = 3;
            label30.Text = "label24";
            // 
            // label31
            // 
            label31.Anchor = AnchorStyles.None;
            label31.AutoSize = true;
            label31.Font = new Font("Segoe UI", 20F);
            label31.Location = new Point(177, 22);
            label31.Name = "label31";
            label31.Size = new Size(175, 37);
            label31.TabIndex = 0;
            label31.Text = "Room Details";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 103);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel2.Size = new Size(529, 499);
            tableLayoutPanel2.TabIndex = 11;
            // 
            // FrmCheckin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(573, 745);
            Controls.Add(tcCheckin);
            Name = "FrmCheckin";
            Padding = new Padding(15);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Check-in";
            Load += FrmCheckin_Load;
            tcCheckin.ResumeLayout(false);
            tpPersonalData.ResumeLayout(false);
            tpPersonalData.PerformLayout();
            pnlBottom.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            tlpBottom.ResumeLayout(false);
            tlpBottom.PerformLayout();
            tpRoomPick.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcCheckin;
        private TabPage tpRoomPick;
        private TabPage tpExtras;
        private TabPage tpPaymentSumm;
        private TabPage tpSummary;
        private TabPage tpPersonalData;
        private Panel pnlTop;
        private Panel pnlBottom;
        private TableLayoutPanel tlpBottom;
        private Label label1;
        private Label line;
        private TextBox tbLastName;
        private TextBox tbEmail;
        private TextBox tbFirstName;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox cbPhoneCountry;
        private TextBox tbPhone;
        private Label label7;
        private Label label8;
        private Label label9;
        private ComboBox cbNationality;
        private Label label10;
        private Label label11;
        private TextBox tbMothersName;
        private Button btnNext;
        private Label label12;
        private ComboBox cbDocumentType;
        private TextBox tbDocumentNumber;
        private Label label15;
        private Label label14;
        private Label label13;
        private Panel panel1;
        private Label label29;
        private Button button1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label30;
        private Label label31;
        private TableLayoutPanel tableLayoutPanel2;
    }
}