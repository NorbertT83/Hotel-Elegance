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
            panel1 = new Panel();
            pnlMain = new Panel();
            lbRoomNumber = new Label();
            label2 = new Label();
            lbPrice = new Label();
            lbRoomType = new Label();
            lbCapacity = new Label();
            lbBedType = new Label();
            lbHasView = new Label();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(128, 255, 128);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(10, 50);
            panel1.TabIndex = 3;
            panel1.Click += RoomCard_Click;
            panel1.MouseLeave += RoomCard_MouseLeave;
            panel1.MouseHover += RoomCard_MouseHover;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(239, 246, 255);
            pnlMain.Controls.Add(lbRoomNumber);
            pnlMain.Controls.Add(label2);
            pnlMain.Controls.Add(lbPrice);
            pnlMain.Controls.Add(lbRoomType);
            pnlMain.Controls.Add(lbCapacity);
            pnlMain.Controls.Add(lbBedType);
            pnlMain.Controls.Add(lbHasView);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(10, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(10, 0, 10, 0);
            pnlMain.Size = new Size(453, 50);
            pnlMain.TabIndex = 4;
            pnlMain.Click += RoomCard_Click;
            pnlMain.MouseLeave += RoomCard_MouseLeave;
            pnlMain.MouseHover += RoomCard_MouseHover;
            // 
            // lbRoomNumber
            // 
            lbRoomNumber.AutoSize = true;
            lbRoomNumber.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lbRoomNumber.Location = new Point(14, 12);
            lbRoomNumber.Margin = new Padding(3, 0, 3, 14);
            lbRoomNumber.Name = "lbRoomNumber";
            lbRoomNumber.Size = new Size(45, 25);
            lbRoomNumber.TabIndex = 3;
            lbRoomNumber.Text = "101";
            lbRoomNumber.Click += RoomCard_Click;
            lbRoomNumber.MouseLeave += RoomCard_MouseLeave;
            lbRoomNumber.MouseHover += RoomCard_MouseHover;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(65, 12);
            label2.Margin = new Padding(3, 0, 3, 14);
            label2.Name = "label2";
            label2.Size = new Size(17, 25);
            label2.TabIndex = 4;
            label2.Text = "|";
            label2.Click += RoomCard_Click;
            label2.MouseLeave += RoomCard_MouseLeave;
            label2.MouseHover += RoomCard_MouseHover;
            // 
            // lbPrice
            // 
            lbPrice.Font = new Font("Segoe UI", 10F);
            lbPrice.ForeColor = Color.Black;
            lbPrice.Image = Properties.Resources.money;
            lbPrice.ImageAlign = ContentAlignment.MiddleLeft;
            lbPrice.Location = new Point(367, 17);
            lbPrice.Margin = new Padding(3, 0, 3, 14);
            lbPrice.Name = "lbPrice";
            lbPrice.Size = new Size(71, 19);
            lbPrice.TabIndex = 5;
            lbPrice.Text = "22000";
            lbPrice.TextAlign = ContentAlignment.MiddleRight;
            lbPrice.Click += RoomCard_Click;
            lbPrice.MouseLeave += RoomCard_MouseLeave;
            lbPrice.MouseHover += RoomCard_MouseHover;
            // 
            // lbRoomType
            // 
            lbRoomType.AutoSize = true;
            lbRoomType.Font = new Font("Segoe UI", 10F);
            lbRoomType.ForeColor = Color.Black;
            lbRoomType.Location = new Point(79, 17);
            lbRoomType.Margin = new Padding(3, 0, 3, 14);
            lbRoomType.Name = "lbRoomType";
            lbRoomType.Size = new Size(64, 19);
            lbRoomType.TabIndex = 6;
            lbRoomType.Text = "Standard";
            lbRoomType.Click += RoomCard_Click;
            lbRoomType.MouseLeave += RoomCard_MouseLeave;
            lbRoomType.MouseHover += RoomCard_MouseHover;
            // 
            // lbCapacity
            // 
            lbCapacity.Font = new Font("Segoe UI", 10F);
            lbCapacity.ForeColor = Color.Black;
            lbCapacity.Image = Properties.Resources.persons;
            lbCapacity.ImageAlign = ContentAlignment.MiddleLeft;
            lbCapacity.Location = new Point(319, 17);
            lbCapacity.Margin = new Padding(3, 0, 3, 14);
            lbCapacity.Name = "lbCapacity";
            lbCapacity.Size = new Size(41, 19);
            lbCapacity.TabIndex = 7;
            lbCapacity.Text = "3";
            lbCapacity.TextAlign = ContentAlignment.MiddleRight;
            lbCapacity.Click += RoomCard_Click;
            lbCapacity.MouseLeave += RoomCard_MouseLeave;
            lbCapacity.MouseHover += RoomCard_MouseHover;
            // 
            // lbBedType
            // 
            lbBedType.Font = new Font("Segoe UI", 10F);
            lbBedType.ForeColor = Color.Black;
            lbBedType.Image = Properties.Resources.bed;
            lbBedType.ImageAlign = ContentAlignment.MiddleLeft;
            lbBedType.Location = new Point(150, 17);
            lbBedType.Margin = new Padding(3, 0, 3, 14);
            lbBedType.Name = "lbBedType";
            lbBedType.Size = new Size(77, 19);
            lbBedType.TabIndex = 8;
            lbBedType.Text = "Kingsize";
            lbBedType.TextAlign = ContentAlignment.MiddleRight;
            lbBedType.Click += RoomCard_Click;
            lbBedType.MouseLeave += RoomCard_MouseLeave;
            lbBedType.MouseHover += RoomCard_MouseHover;
            // 
            // lbHasView
            // 
            lbHasView.AutoSize = true;
            lbHasView.Font = new Font("Segoe UI", 10F);
            lbHasView.ForeColor = Color.Black;
            lbHasView.Location = new Point(234, 17);
            lbHasView.Margin = new Padding(3, 0, 3, 14);
            lbHasView.Name = "lbHasView";
            lbHasView.Size = new Size(78, 19);
            lbHasView.TabIndex = 9;
            lbHasView.Text = "No Balcony";
            lbHasView.Click += RoomCard_Click;
            lbHasView.MouseLeave += RoomCard_MouseLeave;
            lbHasView.MouseHover += RoomCard_MouseHover;
            // 
            // RoomCardUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pnlMain);
            Controls.Add(panel1);
            Cursor = Cursors.Hand;
            Margin = new Padding(0, 10, 0, 10);
            Name = "RoomCardUserControl";
            Size = new Size(463, 50);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel pnlMain;
        private Label lbRoomNumber;
        private Label label2;
        private Label lbBedType;
        private Label lbPrice;
        private Label lbRoomType;
        private Label lbCapacity;
        private Label lbHasView;
    }
}
