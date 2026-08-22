using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using Hotel_erp_Winforms_App.UI.Controls;
using Hotel_erp_Winforms_App.UI.Forms.ServiceForms;
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
        private BookingService _bookingService;
        public Room SelectedRoom { get; private set; }
        public event EventHandler CardSelected;
        private bool clicked = false;

        public RoomCardUserControl()
        {
            InitializeComponent();
        }

        private void RegisterControlEvents(Control parent)
        {
            foreach(Control c in parent.Controls)
            {
                c.Click += RoomCard_Click;
                c.MouseEnter += RoomCard_MouseHover;
                c.MouseLeave += RoomCard_MouseLeave;

                if (c.HasChildren) RegisterControlEvents(c);
            }
        }

        public void LoadSelectedRoomCardData(Booking selectedBooking)
        {
            _bookingService = new BookingService();
            Room room = _bookingService.GetRoomByBookingId(selectedBooking);

            LoadCardData(room);
        }

        public void LoadCardData(Room room)
        {
            SelectedRoom = room;

            lbRoomNumber.Text = room.Room_number.ToString();
            lbRoomType.Text = room.RoomsRoomtype.ToString();
            lbBedType.Text = room.RoomsBedType.ToString();
            lbHasView.Text = room.RoomsView.ToString();
            lbCapacity.Text = room.MaxAdults.ToString();
            lbPrice.Text = room.Price.ToString();
        }

        public void RoomCard_Click(object sender, EventArgs e)
        {
            CardSelected?.Invoke(this, EventArgs.Empty);
        }

        public void SetSelected(bool isSelected)
        {
            clicked = isSelected;
            pnlMain.BackColor = isSelected ? Color.FromArgb(170, 202, 255): Color.White;
        }

        #region Mouse effects
        private void RoomCard_MouseHover(object sender, EventArgs e)
        {
            if (!clicked) pnlMain.BackColor = Color.FromArgb(220, 233, 255);
        }

        private void RoomCard_MouseLeave(object sender, EventArgs e)
        {
            if (!clicked) pnlMain.BackColor = Color.FromArgb(239, 246, 255);
        }
        #endregion
    }
}
