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
            label1 = new Label();
            label2 = new Label();
            label7 = new Label();
            label3 = new Label();
            label6 = new Label();
            label4 = new Label();
            label5 = new Label();
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
            panel1.MouseDown += RoomCard_MouseDown;
            panel1.MouseLeave += RoomCard_MouseLeave;
            panel1.MouseHover += RoomCard_MouseHover;
            panel1.MouseUp += RoomCard_MouseUp;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(239, 246, 255);
            pnlMain.Controls.Add(label1);
            pnlMain.Controls.Add(label2);
            pnlMain.Controls.Add(label7);
            pnlMain.Controls.Add(label3);
            pnlMain.Controls.Add(label6);
            pnlMain.Controls.Add(label4);
            pnlMain.Controls.Add(label5);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(10, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(10, 0, 10, 0);
            pnlMain.Size = new Size(453, 50);
            pnlMain.TabIndex = 4;
            pnlMain.MouseDown += RoomCard_MouseDown;
            pnlMain.MouseLeave += RoomCard_MouseLeave;
            pnlMain.MouseHover += RoomCard_MouseHover;
            pnlMain.MouseUp += RoomCard_MouseUp;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(14, 12);
            label1.Margin = new Padding(3, 0, 3, 14);
            label1.Name = "label1";
            label1.Size = new Size(45, 25);
            label1.TabIndex = 3;
            label1.Text = "101";
            label1.MouseDown += RoomCard_MouseDown;
            label1.MouseLeave += RoomCard_MouseLeave;
            label1.MouseHover += RoomCard_MouseHover;
            label1.MouseUp += RoomCard_MouseUp;
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
            label2.MouseDown += RoomCard_MouseDown;
            label2.MouseLeave += RoomCard_MouseLeave;
            label2.MouseHover += RoomCard_MouseHover;
            label2.MouseUp += RoomCard_MouseUp;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 10F);
            label7.ForeColor = Color.Black;
            label7.Image = Properties.Resources.money;
            label7.ImageAlign = ContentAlignment.MiddleLeft;
            label7.Location = new Point(372, 17);
            label7.Margin = new Padding(3, 0, 3, 14);
            label7.Name = "label7";
            label7.Size = new Size(64, 19);
            label7.TabIndex = 5;
            label7.Text = "22000";
            label7.TextAlign = ContentAlignment.MiddleRight;
            label7.MouseDown += RoomCard_MouseDown;
            label7.MouseLeave += RoomCard_MouseLeave;
            label7.MouseHover += RoomCard_MouseHover;
            label7.MouseUp += RoomCard_MouseUp;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(88, 17);
            label3.Margin = new Padding(3, 0, 3, 14);
            label3.Name = "label3";
            label3.Size = new Size(64, 19);
            label3.TabIndex = 6;
            label3.Text = "Standard";
            label3.MouseDown += RoomCard_MouseDown;
            label3.MouseLeave += RoomCard_MouseLeave;
            label3.MouseHover += RoomCard_MouseHover;
            label3.MouseUp += RoomCard_MouseUp;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 10F);
            label6.ForeColor = Color.Black;
            label6.Image = Properties.Resources.persons;
            label6.ImageAlign = ContentAlignment.MiddleLeft;
            label6.Location = new Point(325, 17);
            label6.Margin = new Padding(3, 0, 3, 14);
            label6.Name = "label6";
            label6.Size = new Size(41, 19);
            label6.TabIndex = 7;
            label6.Text = "3";
            label6.TextAlign = ContentAlignment.MiddleRight;
            label6.MouseDown += RoomCard_MouseDown;
            label6.MouseLeave += RoomCard_MouseLeave;
            label6.MouseHover += RoomCard_MouseHover;
            label6.MouseUp += RoomCard_MouseUp;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = Color.Black;
            label4.Image = Properties.Resources.bed;
            label4.ImageAlign = ContentAlignment.MiddleLeft;
            label4.Location = new Point(158, 17);
            label4.Margin = new Padding(3, 0, 3, 14);
            label4.Name = "label4";
            label4.Size = new Size(77, 19);
            label4.TabIndex = 8;
            label4.Text = "Kingsize";
            label4.TextAlign = ContentAlignment.MiddleRight;
            label4.MouseDown += RoomCard_MouseDown;
            label4.MouseLeave += RoomCard_MouseLeave;
            label4.MouseHover += RoomCard_MouseHover;
            label4.MouseUp += RoomCard_MouseUp;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(241, 17);
            label5.Margin = new Padding(3, 0, 3, 14);
            label5.Name = "label5";
            label5.Size = new Size(78, 19);
            label5.TabIndex = 9;
            label5.Text = "No Balcony";
            label5.MouseDown += RoomCard_MouseDown;
            label5.MouseLeave += RoomCard_MouseLeave;
            label5.MouseHover += RoomCard_MouseHover;
            label5.MouseUp += RoomCard_MouseUp;
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
        private Label label1;
        private Label label2;
        private Label label7;
        private Label label3;
        private Label label6;
        private Label label4;
        private Label label5;
    }
}
