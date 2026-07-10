namespace Hotel_erp_Winforms_App.UI.Controls.RoomCardControl
{
    partial class RoomCardUserControl
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
            lbRoomNumber = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel1 = new Panel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbRoomNumber
            // 
            lbRoomNumber.Anchor = AnchorStyles.None;
            lbRoomNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbRoomNumber.Location = new Point(6, 10);
            lbRoomNumber.Margin = new Padding(0);
            lbRoomNumber.Name = "lbRoomNumber";
            lbRoomNumber.Size = new Size(125, 17);
            lbRoomNumber.TabIndex = 0;
            lbRoomNumber.Text = "101 - Standard Room";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(239, 246, 255);
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(lbRoomNumber, 0, 0);
            tableLayoutPanel1.Location = new Point(5, 8);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(138, 38);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F);
            label1.Location = new Point(11, 51);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "Price:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 9F);
            label2.Location = new Point(45, 51);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 0;
            label2.Text = "45000 / night";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F);
            label4.Location = new Point(11, 77);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 0;
            label4.Text = "Capacity:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 9F);
            label5.Location = new Point(63, 77);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 0;
            label5.Text = "2 person";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(128, 255, 128);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(5, 102);
            panel1.Name = "panel1";
            panel1.Size = new Size(138, 10);
            panel1.TabIndex = 0;
            // 
            // RoomCardUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(panel1);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(tableLayoutPanel1);
            Name = "RoomCardUserControl";
            Padding = new Padding(5);
            Size = new Size(148, 117);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbRoomNumber;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private Panel panel1;
    }
}
