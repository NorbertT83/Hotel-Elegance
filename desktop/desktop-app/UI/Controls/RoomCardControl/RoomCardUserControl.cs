using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_erp_Winforms_App.UI.Controls.RoomCardControl
{
    public partial class RoomCardUserControl : UserControl
    {
        public RoomCardUserControl()
        {
            InitializeComponent();
        }

        private void RoomCard_MouseHover(object sender, EventArgs e)
        {
            pnlMain.BackColor = Color.FromArgb(220, 233, 255);
        }

        private void RoomCard_MouseLeave(object sender, EventArgs e)
        {
            pnlMain.BackColor = Color.FromArgb(239, 246, 255);
        }

        private void RoomCard_MouseDown(object sender, MouseEventArgs e)
        {
            pnlMain.BackColor = Color.FromArgb(170, 202, 255);
        }

        private void RoomCard_MouseUp(object sender, MouseEventArgs e)
        {
            pnlMain.BackColor = Color.FromArgb(220, 233, 255);
        }
    }
}
