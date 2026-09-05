namespace Hotel_erp_Winforms_App.UI.Forms.ServiceForms
{
    partial class FrmEditEmployee
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
            pbAddProfilePic = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            tbAddFirstName = new TextBox();
            tbAddLastName = new TextBox();
            tbAddTaxNumber = new TextBox();
            tbAddAddress = new TextBox();
            tbAddSalary = new TextBox();
            btnAddPicture = new Button();
            btnSaveEmployee = new Button();
            dtpBirthdate = new DateTimePicker();
            cbAddJobTitle = new ComboBox();
            cbAddHolidays = new ComboBox();
            label10 = new Label();
            tbTXholder = new TextBox();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbAddProfilePic).BeginInit();
            SuspendLayout();
            // 
            // pbAddProfilePic
            // 
            pbAddProfilePic.BorderStyle = BorderStyle.FixedSingle;
            pbAddProfilePic.Location = new Point(92, 12);
            pbAddProfilePic.Name = "pbAddProfilePic";
            pbAddProfilePic.Size = new Size(200, 200);
            pbAddProfilePic.TabIndex = 0;
            pbAddProfilePic.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(12, 261);
            label1.Name = "label1";
            label1.Size = new Size(106, 28);
            label1.TabIndex = 1;
            label1.Text = "First name:";
            // 
            // label2
            // 
            label2.BackColor = SystemColors.ScrollBar;
            label2.Location = new Point(4, 238);
            label2.Name = "label2";
            label2.Size = new Size(378, 1);
            label2.TabIndex = 11;
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(12, 298);
            label3.Name = "label3";
            label3.Size = new Size(103, 28);
            label3.TabIndex = 1;
            label3.Text = "Last name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(12, 335);
            label4.Name = "label4";
            label4.Size = new Size(116, 28);
            label4.TabIndex = 1;
            label4.Text = "Tax number:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(12, 372);
            label5.Name = "label5";
            label5.Size = new Size(92, 28);
            label5.TabIndex = 1;
            label5.Text = "Holidays:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F);
            label6.Location = new Point(12, 411);
            label6.Name = "label6";
            label6.Size = new Size(86, 28);
            label6.TabIndex = 1;
            label6.Text = "Address:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15F);
            label7.Location = new Point(12, 469);
            label7.Name = "label7";
            label7.Size = new Size(127, 28);
            label7.TabIndex = 1;
            label7.Text = "Date of birth:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 15F);
            label8.Location = new Point(12, 504);
            label8.Name = "label8";
            label8.Size = new Size(86, 28);
            label8.TabIndex = 1;
            label8.Text = "Job title:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15F);
            label9.Location = new Point(12, 543);
            label9.Name = "label9";
            label9.Size = new Size(69, 28);
            label9.TabIndex = 1;
            label9.Text = "Salary:";
            // 
            // tbAddFirstName
            // 
            tbAddFirstName.Font = new Font("Segoe UI", 15F);
            tbAddFirstName.Location = new Point(150, 258);
            tbAddFirstName.Name = "tbAddFirstName";
            tbAddFirstName.Size = new Size(222, 34);
            tbAddFirstName.TabIndex = 1;
            tbAddFirstName.TextAlign = HorizontalAlignment.Center;
            tbAddFirstName.KeyPress += tbAddFirstName_KeyPress;
            // 
            // tbAddLastName
            // 
            tbAddLastName.Font = new Font("Segoe UI", 15F);
            tbAddLastName.Location = new Point(150, 295);
            tbAddLastName.Name = "tbAddLastName";
            tbAddLastName.Size = new Size(222, 34);
            tbAddLastName.TabIndex = 2;
            tbAddLastName.TextAlign = HorizontalAlignment.Center;
            tbAddLastName.KeyPress += tbAddLastName_KeyPress;
            // 
            // tbAddTaxNumber
            // 
            tbAddTaxNumber.Font = new Font("Segoe UI", 15F);
            tbAddTaxNumber.Location = new Point(210, 332);
            tbAddTaxNumber.Name = "tbAddTaxNumber";
            tbAddTaxNumber.Size = new Size(161, 34);
            tbAddTaxNumber.TabIndex = 3;
            tbAddTaxNumber.TextAlign = HorizontalAlignment.Center;
            tbAddTaxNumber.KeyPress += tbAddTaxNumber_KeyPress;
            // 
            // tbAddAddress
            // 
            tbAddAddress.Font = new Font("Segoe UI", 15F);
            tbAddAddress.Location = new Point(104, 408);
            tbAddAddress.Name = "tbAddAddress";
            tbAddAddress.Size = new Size(268, 34);
            tbAddAddress.TabIndex = 5;
            tbAddAddress.TextAlign = HorizontalAlignment.Center;
            // 
            // tbAddSalary
            // 
            tbAddSalary.Font = new Font("Segoe UI", 15F);
            tbAddSalary.Location = new Point(150, 540);
            tbAddSalary.Name = "tbAddSalary";
            tbAddSalary.Size = new Size(222, 34);
            tbAddSalary.TabIndex = 8;
            tbAddSalary.TextAlign = HorizontalAlignment.Center;
            tbAddSalary.KeyPress += tbAddSalary_KeyPress;
            // 
            // btnAddPicture
            // 
            btnAddPicture.BackgroundImage = Properties.Resources.plus;
            btnAddPicture.BackgroundImageLayout = ImageLayout.Zoom;
            btnAddPicture.Location = new Point(298, 191);
            btnAddPicture.Name = "btnAddPicture";
            btnAddPicture.Size = new Size(20, 21);
            btnAddPicture.TabIndex = 9;
            btnAddPicture.UseVisualStyleBackColor = true;
            // 
            // btnSaveEmployee
            // 
            btnSaveEmployee.BackColor = Color.FromArgb(59, 130, 246);
            btnSaveEmployee.Cursor = Cursors.Hand;
            btnSaveEmployee.FlatAppearance.BorderSize = 0;
            btnSaveEmployee.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 58, 138);
            btnSaveEmployee.FlatStyle = FlatStyle.Popup;
            btnSaveEmployee.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            btnSaveEmployee.ForeColor = Color.White;
            btnSaveEmployee.Location = new Point(117, 603);
            btnSaveEmployee.Name = "btnSaveEmployee";
            btnSaveEmployee.Size = new Size(150, 55);
            btnSaveEmployee.TabIndex = 12;
            btnSaveEmployee.Text = "Save";
            btnSaveEmployee.UseVisualStyleBackColor = false;
            btnSaveEmployee.Click += btnSaveEmployee_Click;
            // 
            // dtpBirthdate
            // 
            dtpBirthdate.Font = new Font("Segoe UI", 15F);
            dtpBirthdate.Location = new Point(150, 464);
            dtpBirthdate.MinDate = new DateTime(1940, 1, 1, 0, 0, 0, 0);
            dtpBirthdate.Name = "dtpBirthdate";
            dtpBirthdate.Size = new Size(222, 34);
            dtpBirthdate.TabIndex = 13;
            // 
            // cbAddJobTitle
            // 
            cbAddJobTitle.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAddJobTitle.Font = new Font("Segoe UI", 15F);
            cbAddJobTitle.FormattingEnabled = true;
            cbAddJobTitle.Items.AddRange(new object[] { "HK Manager", "F&B Manager", "Receptionist", "Cleaner", "Room Service", "Front Office Manager" });
            cbAddJobTitle.Location = new Point(150, 501);
            cbAddJobTitle.Name = "cbAddJobTitle";
            cbAddJobTitle.Size = new Size(222, 36);
            cbAddJobTitle.TabIndex = 15;
            // 
            // cbAddHolidays
            // 
            cbAddHolidays.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbAddHolidays.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbAddHolidays.DropDownHeight = 100;
            cbAddHolidays.Font = new Font("Segoe UI", 15F);
            cbAddHolidays.FormattingEnabled = true;
            cbAddHolidays.IntegralHeight = false;
            cbAddHolidays.Items.AddRange(new object[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37" });
            cbAddHolidays.Location = new Point(284, 369);
            cbAddHolidays.Name = "cbAddHolidays";
            cbAddHolidays.Size = new Size(88, 36);
            cbAddHolidays.TabIndex = 16;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(258, 445);
            label10.Name = "label10";
            label10.Size = new Size(114, 15);
            label10.TabIndex = 17;
            label10.Text = "City, Street, Number";
            // 
            // tbTXholder
            // 
            tbTXholder.Font = new Font("Segoe UI", 15F);
            tbTXholder.Location = new Point(150, 332);
            tbTXholder.Name = "tbTXholder";
            tbTXholder.ReadOnly = true;
            tbTXholder.Size = new Size(41, 34);
            tbTXholder.TabIndex = 18;
            tbTXholder.Text = "TX";
            tbTXholder.TextAlign = HorizontalAlignment.Center;
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label11.Location = new Point(191, 332);
            label11.Name = "label11";
            label11.Size = new Size(13, 34);
            label11.TabIndex = 19;
            label11.Text = "-";
            // 
            // FrmEditEmployee
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(384, 678);
            Controls.Add(label11);
            Controls.Add(tbTXholder);
            Controls.Add(label10);
            Controls.Add(cbAddHolidays);
            Controls.Add(cbAddJobTitle);
            Controls.Add(dtpBirthdate);
            Controls.Add(btnSaveEmployee);
            Controls.Add(btnAddPicture);
            Controls.Add(tbAddSalary);
            Controls.Add(tbAddAddress);
            Controls.Add(tbAddTaxNumber);
            Controls.Add(tbAddLastName);
            Controls.Add(tbAddFirstName);
            Controls.Add(label2);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(pbAddProfilePic);
            Name = "FrmEditEmployee";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Employee";
            Load += FrmEditEmployee_Load;
            ((System.ComponentModel.ISupportInitialize)pbAddProfilePic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbAddProfilePic;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox tbAddFirstName;
        private TextBox tbAddLastName;
        private TextBox tbAddTaxNumber;
        private TextBox tbAddAddress;
        private TextBox tbAddSalary;
        private Button btnAddPicture;
        private Button btnSaveEmployee;
        private DateTimePicker dtpBirthdate;
        private ComboBox cbAddJobTitle;
        private ComboBox cbAddHolidays;
        private Label label10;
        private TextBox tbTXholder;
        private Label label11;
    }
}