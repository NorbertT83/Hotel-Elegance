using Hotel_erp_Winforms_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_erp_Winforms_App.UI.Forms.ServiceForms
{
    public partial class FrmCheckin : Form
    {
        public Booking _selectedBooking;

        public FrmCheckin(Booking booking)
        {
            InitializeComponent();
            _selectedBooking = booking;
        }

        private void FrmCheckin_Load(object sender, EventArgs e)
        {
        }
    }
}
