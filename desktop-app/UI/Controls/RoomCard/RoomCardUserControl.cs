using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;

namespace Hotel_erp_Winforms_App.UI.Controls.RoomCardControl
{
    public partial class RoomCardUserControl : UserControl
    {
        #region vairables

        private readonly RoomService _roomService;

        public Room? SelectedRoom { get; private set; }
        public event EventHandler? CardSelected;

        private bool _isSelected = false;

        private static readonly Color ColorSelected = Color.FromArgb(170, 202, 255);
        private static readonly Color ColorHover = Color.FromArgb(220, 233, 255);
        private static readonly Color ColorDefault = Color.FromArgb(239, 246, 255);

        #endregion

        public RoomCardUserControl()
        {
            InitializeComponent();
            _roomService = new RoomService();

            RegisterControlEvents(this);
        }

        #region Event Registration
        private void RegisterControlEvents(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                c.Click += RoomCard_Click;
                c.MouseEnter += RoomCard_MouseEnter;
                c.MouseLeave += RoomCard_MouseLeave;

                if (c.HasChildren)
                {
                    RegisterControlEvents(c);
                }
            }
        }
        #endregion

        #region Data Loading
        public async Task LoadSelectedRoomCardDataAsync(Booking selectedBooking)
        {
            if (selectedBooking == null) return;

            List<Room> rooms = await _roomService.GetAllRoomsAsync();

            Room? room = rooms.Find(r => r.Room_number == selectedBooking.RoomNumber);

            if (room != null)
            {
                LoadCardData(room);
            }
        }

        public void LoadCardData(Room room)
        {
            SelectedRoom = room ?? throw new ArgumentNullException(nameof(room));

            lbRoomNumber.Text = room.Room_number.ToString();
            lbRoomType.Text = room.RoomsRoomtype.ToString();
            lbBedType.Text = room.RoomsBedType.ToString();
            lbHasView.Text = room.RoomsView.ToString();
            lbCapacity.Text = room.MaxAdults.ToString();
            lbPrice.Text = $"{room.Price:C0}";
        }
        #endregion

        #region UI Logic & Selection
        public void SetSelected(bool isSelected)
        {
            _isSelected = isSelected;
            pnlMain.BackColor = _isSelected ? ColorSelected : ColorDefault;
        }

        private void RoomCard_Click(object? sender, EventArgs e)
        {
            CardSelected?.Invoke(this, EventArgs.Empty);
        }

        private void RoomCard_MouseEnter(object? sender, EventArgs e)
        {
            if (!_isSelected)
                pnlMain.BackColor = ColorHover;
        }

        private void RoomCard_MouseLeave(object? sender, EventArgs e)
        {
            if (!_isSelected)
                pnlMain.BackColor = ColorDefault;
        }

        private void RoomCard_MouseHover(object? sender, EventArgs e)
        {
            if (!_isSelected)
                pnlMain.BackColor = ColorHover;
        }
        #endregion
    }
}