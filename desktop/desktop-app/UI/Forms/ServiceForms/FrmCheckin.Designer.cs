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
            dtpBirthdate = new DateTimePicker();
            cbDocumentType = new ComboBox();
            cbNationality = new ComboBox();
            cbPhoneCountry = new ComboBox();
            tbLastName = new TextBox();
            tbPhone = new TextBox();
            tbDocumentNumber = new TextBox();
            tbStreet = new TextBox();
            tbCity = new TextBox();
            tbZipCode = new TextBox();
            tbEmail = new TextBox();
            tbFirstName = new TextBox();
            label6 = new Label();
            label34 = new Label();
            label10 = new Label();
            label15 = new Label();
            label33 = new Label();
            label27 = new Label();
            label26 = new Label();
            label14 = new Label();
            label11 = new Label();
            label9 = new Label();
            label5 = new Label();
            label13 = new Label();
            label23 = new Label();
            label4 = new Label();
            label3 = new Label();
            label8 = new Label();
            label7 = new Label();
            label2 = new Label();
            pnlTop = new Panel();
            tlpBottom = new TableLayoutPanel();
            line = new Label();
            label1 = new Label();
            tpRoomPick = new TabPage();
            flpCardHolder = new FlowLayoutPanel();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            label30 = new Label();
            label31 = new Label();
            tpExtras = new TabPage();
            ckbParking = new CheckBox();
            tbOtherRequests = new TextBox();
            cbPet = new ComboBox();
            cbWellness = new ComboBox();
            cbDepartureNotes = new ComboBox();
            cbExtraBed = new ComboBox();
            cbCateringLevel = new ComboBox();
            tbCarPlateNumber = new TextBox();
            label16 = new Label();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            label24 = new Label();
            label21 = new Label();
            label22 = new Label();
            label20 = new Label();
            label25 = new Label();
            label28 = new Label();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label29 = new Label();
            label32 = new Label();
            tpPaymentSumm = new TabPage();
            tpSummary = new TabPage();
            pnlBottom = new Panel();
            label12 = new Label();
            btnBack = new Button();
            btnConfirm = new Button();
            btnNext = new Button();
            tcCheckin.SuspendLayout();
            tpPersonalData.SuspendLayout();
            pnlTop.SuspendLayout();
            tlpBottom.SuspendLayout();
            tpRoomPick.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tpExtras.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            pnlBottom.SuspendLayout();
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
            tcCheckin.Size = new Size(543, 597);
            tcCheckin.SizeMode = TabSizeMode.FillToRight;
            tcCheckin.TabIndex = 0;
            tcCheckin.SelectedIndexChanged += tcCheckin_SeledIndexChanged;
            // 
            // tpPersonalData
            // 
            tpPersonalData.BackColor = Color.White;
            tpPersonalData.Controls.Add(dtpBirthdate);
            tpPersonalData.Controls.Add(cbDocumentType);
            tpPersonalData.Controls.Add(cbNationality);
            tpPersonalData.Controls.Add(cbPhoneCountry);
            tpPersonalData.Controls.Add(tbLastName);
            tpPersonalData.Controls.Add(tbPhone);
            tpPersonalData.Controls.Add(tbDocumentNumber);
            tpPersonalData.Controls.Add(tbStreet);
            tpPersonalData.Controls.Add(tbCity);
            tpPersonalData.Controls.Add(tbZipCode);
            tpPersonalData.Controls.Add(tbEmail);
            tpPersonalData.Controls.Add(tbFirstName);
            tpPersonalData.Controls.Add(label6);
            tpPersonalData.Controls.Add(label34);
            tpPersonalData.Controls.Add(label10);
            tpPersonalData.Controls.Add(label15);
            tpPersonalData.Controls.Add(label33);
            tpPersonalData.Controls.Add(label27);
            tpPersonalData.Controls.Add(label26);
            tpPersonalData.Controls.Add(label14);
            tpPersonalData.Controls.Add(label11);
            tpPersonalData.Controls.Add(label9);
            tpPersonalData.Controls.Add(label5);
            tpPersonalData.Controls.Add(label13);
            tpPersonalData.Controls.Add(label23);
            tpPersonalData.Controls.Add(label4);
            tpPersonalData.Controls.Add(label3);
            tpPersonalData.Controls.Add(label8);
            tpPersonalData.Controls.Add(label7);
            tpPersonalData.Controls.Add(label2);
            tpPersonalData.Controls.Add(pnlTop);
            tpPersonalData.Location = new Point(4, 5);
            tpPersonalData.Name = "tpPersonalData";
            tpPersonalData.Size = new Size(535, 588);
            tpPersonalData.TabIndex = 0;
            tpPersonalData.Text = "Personal Data";
            // 
            // dtpBirthdate
            // 
            dtpBirthdate.Font = new Font("Segoe UI", 12F);
            dtpBirthdate.Format = DateTimePickerFormat.Short;
            dtpBirthdate.Location = new Point(272, 291);
            dtpBirthdate.MaxDate = new DateTime(2026, 7, 12, 0, 0, 0, 0);
            dtpBirthdate.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpBirthdate.Name = "dtpBirthdate";
            dtpBirthdate.Size = new Size(236, 29);
            dtpBirthdate.TabIndex = 6;
            dtpBirthdate.Value = new DateTime(2026, 7, 12, 0, 0, 0, 0);
            // 
            // cbDocumentType
            // 
            cbDocumentType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDocumentType.Font = new Font("Segoe UI", 12F);
            cbDocumentType.FormattingEnabled = true;
            cbDocumentType.Items.AddRange(new object[] { "ID", "Passport" });
            cbDocumentType.Location = new Point(20, 513);
            cbDocumentType.Name = "cbDocumentType";
            cbDocumentType.Size = new Size(133, 29);
            cbDocumentType.TabIndex = 11;
            // 
            // cbNationality
            // 
            cbNationality.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNationality.Font = new Font("Segoe UI", 12F);
            cbNationality.FormattingEnabled = true;
            cbNationality.Location = new Point(20, 365);
            cbNationality.Name = "cbNationality";
            cbNationality.Size = new Size(488, 29);
            cbNationality.TabIndex = 7;
            // 
            // cbPhoneCountry
            // 
            cbPhoneCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPhoneCountry.Font = new Font("Segoe UI", 12F);
            cbPhoneCountry.FormattingEnabled = true;
            cbPhoneCountry.Location = new Point(20, 291);
            cbPhoneCountry.Name = "cbPhoneCountry";
            cbPhoneCountry.Size = new Size(46, 29);
            cbPhoneCountry.TabIndex = 4;
            // 
            // tbLastName
            // 
            tbLastName.Font = new Font("Segoe UI", 12F);
            tbLastName.Location = new Point(272, 143);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(236, 29);
            tbLastName.TabIndex = 2;
            tbLastName.KeyPress += tbLastName_KeyPress;
            // 
            // tbPhone
            // 
            tbPhone.Font = new Font("Segoe UI", 12F);
            tbPhone.Location = new Point(72, 291);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(186, 29);
            tbPhone.TabIndex = 5;
            tbPhone.KeyPress += tbPhone_KeyPress;
            // 
            // tbDocumentNumber
            // 
            tbDocumentNumber.Font = new Font("Segoe UI", 12F);
            tbDocumentNumber.Location = new Point(166, 513);
            tbDocumentNumber.Name = "tbDocumentNumber";
            tbDocumentNumber.Size = new Size(342, 29);
            tbDocumentNumber.TabIndex = 12;
            // 
            // tbStreet
            // 
            tbStreet.Font = new Font("Segoe UI", 12F);
            tbStreet.Location = new Point(272, 439);
            tbStreet.Name = "tbStreet";
            tbStreet.Size = new Size(236, 29);
            tbStreet.TabIndex = 10;
            // 
            // tbCity
            // 
            tbCity.Font = new Font("Segoe UI", 12F);
            tbCity.Location = new Point(126, 439);
            tbCity.Name = "tbCity";
            tbCity.Size = new Size(132, 29);
            tbCity.TabIndex = 9;
            tbCity.KeyPress += tbCity_KeyPress;
            // 
            // tbZipCode
            // 
            tbZipCode.Font = new Font("Segoe UI", 12F);
            tbZipCode.Location = new Point(20, 439);
            tbZipCode.Name = "tbZipCode";
            tbZipCode.Size = new Size(98, 29);
            tbZipCode.TabIndex = 8;
            tbZipCode.KeyPress += tbZipCode_KeyPress;
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 12F);
            tbEmail.Location = new Point(20, 217);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(488, 29);
            tbEmail.TabIndex = 3;
            // 
            // tbFirstName
            // 
            tbFirstName.Font = new Font("Segoe UI", 12F);
            tbFirstName.Location = new Point(20, 143);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(238, 29);
            tbFirstName.TabIndex = 1;
            tbFirstName.KeyPress += tbFirstName_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(16, 415);
            label6.Name = "label6";
            label6.Size = new Size(66, 21);
            label6.TabIndex = 4;
            label6.Text = "Address";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("Segoe UI", 8F);
            label34.ForeColor = Color.Gray;
            label34.Location = new Point(20, 249);
            label34.Name = "label34";
            label34.Size = new Size(112, 13);
            label34.TabIndex = 4;
            label34.Text = "example@gmail.com";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 8F);
            label10.ForeColor = Color.Gray;
            label10.Location = new Point(72, 323);
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
            label15.Location = new Point(166, 545);
            label15.Name = "label15";
            label15.Size = new Size(104, 13);
            label15.TabIndex = 4;
            label15.Text = "Document Number";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new Font("Segoe UI", 8F);
            label33.ForeColor = Color.Gray;
            label33.Location = new Point(272, 471);
            label33.Name = "label33";
            label33.Size = new Size(114, 13);
            label33.TabIndex = 4;
            label33.Text = "Street name, number";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 8F);
            label27.ForeColor = Color.Gray;
            label27.Location = new Point(128, 471);
            label27.Name = "label27";
            label27.Size = new Size(26, 13);
            label27.TabIndex = 4;
            label27.Text = "City";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 8F);
            label26.ForeColor = Color.Gray;
            label26.Location = new Point(20, 471);
            label26.Name = "label26";
            label26.Size = new Size(53, 13);
            label26.TabIndex = 4;
            label26.Text = "Zip Code";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 8F);
            label14.ForeColor = Color.Gray;
            label14.Location = new Point(20, 545);
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
            label11.Location = new Point(20, 397);
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
            label9.Location = new Point(20, 323);
            label9.Name = "label9";
            label9.Size = new Size(48, 13);
            label9.TabIndex = 4;
            label9.Text = "Country";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(16, 341);
            label5.Name = "label5";
            label5.Size = new Size(86, 21);
            label5.TabIndex = 4;
            label5.Text = "Nationality";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.Location = new Point(16, 489);
            label13.Name = "label13";
            label13.Size = new Size(189, 21);
            label13.TabIndex = 4;
            label13.Text = "Identity Document Details";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 12F);
            label23.Location = new Point(272, 267);
            label23.Name = "label23";
            label23.Size = new Size(73, 21);
            label23.TabIndex = 4;
            label23.Text = "Birthdate";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(16, 267);
            label4.Name = "label4";
            label4.Size = new Size(113, 21);
            label4.TabIndex = 4;
            label4.Text = "Phone number";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(16, 193);
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
            label8.Location = new Point(272, 175);
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
            label7.Location = new Point(20, 175);
            label7.Name = "label7";
            label7.Size = new Size(61, 13);
            label7.TabIndex = 4;
            label7.Text = "First Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(16, 119);
            label2.Name = "label2";
            label2.Size = new Size(138, 21);
            label2.TabIndex = 4;
            label2.Text = "Reservation Name";
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(239, 246, 255);
            pnlTop.Controls.Add(tlpBottom);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(535, 100);
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
            tlpBottom.Margin = new Padding(0, 0, 0, 15);
            tlpBottom.Name = "tlpBottom";
            tlpBottom.RowCount = 1;
            tlpBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 19F));
            tlpBottom.Size = new Size(535, 100);
            tlpBottom.TabIndex = 0;
            // 
            // line
            // 
            line.BackColor = Color.FromArgb(230, 235, 240);
            line.Location = new Point(3, 81);
            line.Name = "line";
            line.Size = new Size(529, 1);
            line.TabIndex = 3;
            line.Text = "label24";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(177, 22);
            label1.Name = "label1";
            label1.Size = new Size(180, 37);
            label1.TabIndex = 0;
            label1.Text = "Personal Data";
            // 
            // tpRoomPick
            // 
            tpRoomPick.BackColor = Color.White;
            tpRoomPick.Controls.Add(flpCardHolder);
            tpRoomPick.Controls.Add(panel2);
            tpRoomPick.Location = new Point(4, 5);
            tpRoomPick.Name = "tpRoomPick";
            tpRoomPick.Padding = new Padding(3);
            tpRoomPick.Size = new Size(535, 588);
            tpRoomPick.TabIndex = 1;
            tpRoomPick.Text = "tabPage2";
            // 
            // flpCardHolder
            // 
            flpCardHolder.Dock = DockStyle.Fill;
            flpCardHolder.FlowDirection = FlowDirection.TopDown;
            flpCardHolder.Location = new Point(3, 103);
            flpCardHolder.Name = "flpCardHolder";
            flpCardHolder.Padding = new Padding(33, 5, 33, 10);
            flpCardHolder.Size = new Size(529, 482);
            flpCardHolder.TabIndex = 10;
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
            label31.Location = new Point(173, 22);
            label31.Name = "label31";
            label31.Size = new Size(183, 37);
            label31.TabIndex = 0;
            label31.Text = "Choose Room";
            // 
            // tpExtras
            // 
            tpExtras.BackColor = Color.White;
            tpExtras.Controls.Add(ckbParking);
            tpExtras.Controls.Add(tbOtherRequests);
            tpExtras.Controls.Add(cbPet);
            tpExtras.Controls.Add(cbWellness);
            tpExtras.Controls.Add(cbDepartureNotes);
            tpExtras.Controls.Add(cbExtraBed);
            tpExtras.Controls.Add(cbCateringLevel);
            tpExtras.Controls.Add(tbCarPlateNumber);
            tpExtras.Controls.Add(label16);
            tpExtras.Controls.Add(label19);
            tpExtras.Controls.Add(label18);
            tpExtras.Controls.Add(label17);
            tpExtras.Controls.Add(label24);
            tpExtras.Controls.Add(label21);
            tpExtras.Controls.Add(label22);
            tpExtras.Controls.Add(label20);
            tpExtras.Controls.Add(label25);
            tpExtras.Controls.Add(label28);
            tpExtras.Controls.Add(panel1);
            tpExtras.Location = new Point(4, 5);
            tpExtras.Margin = new Padding(0);
            tpExtras.Name = "tpExtras";
            tpExtras.Padding = new Padding(0, 0, 0, 15);
            tpExtras.Size = new Size(535, 588);
            tpExtras.TabIndex = 2;
            tpExtras.Text = "tabPage3";
            // 
            // ckbParking
            // 
            ckbParking.Font = new Font("Segoe UI", 30F);
            ckbParking.Location = new Point(22, 240);
            ckbParking.Name = "ckbParking";
            ckbParking.Size = new Size(14, 29);
            ckbParking.TabIndex = 23;
            ckbParking.UseVisualStyleBackColor = true;
            ckbParking.CheckedChanged += ckbParking_CheckedChanged;
            // 
            // tbOtherRequests
            // 
            tbOtherRequests.Location = new Point(22, 418);
            tbOtherRequests.Multiline = true;
            tbOtherRequests.Name = "tbOtherRequests";
            tbOtherRequests.Size = new Size(486, 152);
            tbOtherRequests.TabIndex = 7;
            // 
            // cbPet
            // 
            cbPet.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPet.Font = new Font("Segoe UI", 12F);
            cbPet.FormattingEnabled = true;
            cbPet.Items.AddRange(new object[] { "Yes", "No" });
            cbPet.Location = new Point(273, 144);
            cbPet.Name = "cbPet";
            cbPet.Size = new Size(235, 29);
            cbPet.TabIndex = 2;
            cbPet.SelectedIndexChanged += cbPet_SelectedIndexChanged;
            // 
            // cbWellness
            // 
            cbWellness.DropDownStyle = ComboBoxStyle.DropDownList;
            cbWellness.Font = new Font("Segoe UI", 12F);
            cbWellness.FormattingEnabled = true;
            cbWellness.Items.AddRange(new object[] { "Yes", "No" });
            cbWellness.Location = new Point(273, 240);
            cbWellness.Name = "cbWellness";
            cbWellness.Size = new Size(235, 29);
            cbWellness.TabIndex = 4;
            // 
            // cbDepartureNotes
            // 
            cbDepartureNotes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDepartureNotes.Font = new Font("Segoe UI", 12F);
            cbDepartureNotes.FormattingEnabled = true;
            cbDepartureNotes.Items.AddRange(new object[] { "None", "Late Check-out", "Early Departure" });
            cbDepartureNotes.Location = new Point(273, 336);
            cbDepartureNotes.Name = "cbDepartureNotes";
            cbDepartureNotes.Size = new Size(235, 29);
            cbDepartureNotes.TabIndex = 6;
            cbDepartureNotes.SelectedIndexChanged += cbDepartureNotes_SelectedIndexChanged;
            // 
            // cbExtraBed
            // 
            cbExtraBed.DropDownStyle = ComboBoxStyle.DropDownList;
            cbExtraBed.Font = new Font("Segoe UI", 12F);
            cbExtraBed.FormattingEnabled = true;
            cbExtraBed.Items.AddRange(new object[] { "None", "Extra Bed", "Baby Cot" });
            cbExtraBed.Location = new Point(22, 336);
            cbExtraBed.Name = "cbExtraBed";
            cbExtraBed.Size = new Size(235, 29);
            cbExtraBed.TabIndex = 5;
            cbExtraBed.SelectedIndexChanged += cbExtraBed_SelectedIndexChanged;
            // 
            // cbCateringLevel
            // 
            cbCateringLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCateringLevel.Font = new Font("Segoe UI", 12F);
            cbCateringLevel.FormattingEnabled = true;
            cbCateringLevel.Items.AddRange(new object[] { "Breakfast", "Halfboard", "Fullboard" });
            cbCateringLevel.Location = new Point(22, 144);
            cbCateringLevel.Name = "cbCateringLevel";
            cbCateringLevel.Size = new Size(235, 29);
            cbCateringLevel.TabIndex = 1;
            cbCateringLevel.SelectedIndexChanged += cbCateringLevel_SelectedIndexChanges;
            // 
            // tbCarPlateNumber
            // 
            tbCarPlateNumber.Font = new Font("Segoe UI", 12F);
            tbCarPlateNumber.Location = new Point(42, 240);
            tbCarPlateNumber.Name = "tbCarPlateNumber";
            tbCarPlateNumber.ReadOnly = true;
            tbCarPlateNumber.Size = new Size(215, 29);
            tbCarPlateNumber.TabIndex = 3;
            tbCarPlateNumber.TextAlign = HorizontalAlignment.Right;
            tbCarPlateNumber.TextChanged += tbCarPlateNumber_TextChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F);
            label16.Location = new Point(273, 117);
            label16.Name = "label16";
            label16.Size = new Size(31, 21);
            label16.TabIndex = 21;
            label16.Text = "Pet";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 8F);
            label19.ForeColor = Color.Gray;
            label19.Location = new Point(273, 272);
            label19.Name = "label19";
            label19.Size = new Size(47, 13);
            label19.TabIndex = 22;
            label19.Text = "Yes / No";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 8F);
            label18.ForeColor = Color.Gray;
            label18.Location = new Point(273, 176);
            label18.Name = "label18";
            label18.Size = new Size(47, 13);
            label18.TabIndex = 22;
            label18.Text = "Yes / No";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 8F);
            label17.ForeColor = Color.Gray;
            label17.Location = new Point(42, 272);
            label17.Name = "label17";
            label17.Size = new Size(76, 13);
            label17.TabIndex = 22;
            label17.Text = "Plate Number";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 12F);
            label24.Location = new Point(273, 216);
            label24.Name = "label24";
            label24.Size = new Size(121, 21);
            label24.TabIndex = 13;
            label24.Text = "Wellness Access";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 12F);
            label21.Location = new Point(273, 309);
            label21.Name = "label21";
            label21.Size = new Size(125, 21);
            label21.TabIndex = 19;
            label21.Text = "Departure Notes";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 12F);
            label22.Location = new Point(19, 394);
            label22.Name = "label22";
            label22.Size = new Size(50, 21);
            label22.TabIndex = 19;
            label22.Text = "Other";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 12F);
            label20.Location = new Point(19, 309);
            label20.Name = "label20";
            label20.Size = new Size(74, 21);
            label20.TabIndex = 19;
            label20.Text = "Extra Bed";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 12F);
            label25.Location = new Point(19, 216);
            label25.Name = "label25";
            label25.Size = new Size(62, 21);
            label25.TabIndex = 12;
            label25.Text = "Parking";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI", 12F);
            label28.Location = new Point(19, 117);
            label28.Name = "label28";
            label28.Size = new Size(69, 21);
            label28.TabIndex = 19;
            label28.Text = "Catering";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(239, 246, 255);
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(535, 100);
            panel1.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(label29, 0, 1);
            tableLayoutPanel2.Controls.Add(label32, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 19F));
            tableLayoutPanel2.Size = new Size(535, 100);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label29
            // 
            label29.BackColor = Color.FromArgb(230, 235, 240);
            label29.Location = new Point(3, 81);
            label29.Name = "label29";
            label29.Size = new Size(523, 1);
            label29.TabIndex = 3;
            label29.Text = "label24";
            // 
            // label32
            // 
            label32.Anchor = AnchorStyles.None;
            label32.AutoSize = true;
            label32.Font = new Font("Segoe UI", 20F);
            label32.Location = new Point(161, 22);
            label32.Name = "label32";
            label32.Size = new Size(213, 37);
            label32.TabIndex = 0;
            label32.Text = "Special Requests";
            // 
            // tpPaymentSumm
            // 
            tpPaymentSumm.Location = new Point(4, 5);
            tpPaymentSumm.Name = "tpPaymentSumm";
            tpPaymentSumm.Padding = new Padding(3);
            tpPaymentSumm.Size = new Size(535, 588);
            tpPaymentSumm.TabIndex = 3;
            tpPaymentSumm.Text = "tabPage4";
            tpPaymentSumm.UseVisualStyleBackColor = true;
            // 
            // tpSummary
            // 
            tpSummary.Location = new Point(4, 5);
            tpSummary.Name = "tpSummary";
            tpSummary.Padding = new Padding(3);
            tpSummary.Size = new Size(535, 588);
            tpSummary.TabIndex = 4;
            tpSummary.Text = "tabPage5";
            tpSummary.UseVisualStyleBackColor = true;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(239, 246, 255);
            pnlBottom.Controls.Add(label12);
            pnlBottom.Controls.Add(btnBack);
            pnlBottom.Controls.Add(btnConfirm);
            pnlBottom.Controls.Add(btnNext);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(15, 630);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(20);
            pnlBottom.Size = new Size(543, 100);
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
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(30, 58, 138);
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(23, 36);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(122, 41);
            btnBack.TabIndex = 13;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = AnchorStyles.None;
            btnConfirm.BackColor = Color.FromArgb(30, 58, 138);
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(390, 36);
            btnConfirm.Margin = new Padding(3, 3, 20, 3);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(122, 41);
            btnConfirm.TabIndex = 14;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnNext_Click;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.None;
            btnNext.BackColor = Color.FromArgb(30, 58, 138);
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(390, 36);
            btnNext.Margin = new Padding(3, 3, 20, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(122, 41);
            btnNext.TabIndex = 4;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // FrmCheckin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(573, 745);
            Controls.Add(tcCheckin);
            Controls.Add(pnlBottom);
            Name = "FrmCheckin";
            Padding = new Padding(15);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Check-in";
            Load += FrmCheckin_Load;
            tcCheckin.ResumeLayout(false);
            tpPersonalData.ResumeLayout(false);
            tpPersonalData.PerformLayout();
            pnlTop.ResumeLayout(false);
            tlpBottom.ResumeLayout(false);
            tlpBottom.PerformLayout();
            tpRoomPick.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tpExtras.ResumeLayout(false);
            tpExtras.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcCheckin;
        private TabPage tpRoomPick;
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
        private TextBox tbStreet;
        private ComboBox cbNationality;
        private Label label10;
        private Label label11;
        private TextBox tbZipCode;
        private Button btnNext;
        private Label label12;
        private ComboBox cbDocumentType;
        private TextBox tbDocumentNumber;
        private Label label15;
        private Label label14;
        private Label label13;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label30;
        private Label label31;
        private Button btnBack;
        private FlowLayoutPanel flpCardHolder;
        private TabPage tpExtras;
        private ComboBox cbPet;
        private ComboBox cbWellness;
        private ComboBox cbCateringLevel;
        private TextBox tbCarPlateNumber;
        private Label label16;
        private Label label17;
        private Label label24;
        private Label label25;
        private Label label28;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label29;
        private Label label32;
        private Label label18;
        private TextBox tbOtherRequests;
        private ComboBox cbDepartureNotes;
        private ComboBox cbExtraBed;
        private Label label19;
        private Label label21;
        private Label label22;
        private Label label20;
        private DateTimePicker dtpBirthdate;
        private TextBox tbCity;
        private Label label33;
        private Label label27;
        private Label label26;
        private Label label23;
        private Button btnConfirm;
        private Label label34;
        private CheckBox ckbParking;
    }
}