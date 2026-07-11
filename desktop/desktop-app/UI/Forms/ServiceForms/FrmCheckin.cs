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
            tcCheckin.SelectedIndex = 0;
            btnBack.Visible = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tcCheckin.SelectedIndex < 4)
            {
                tcCheckin.SelectedIndex += 1;
                btnBack.Visible = true;
            }
        }

        private void btnBack_Click(object sencder, EventArgs e)
        {
            if (tcCheckin.SelectedIndex > 0)
            {
                tcCheckin.SelectedIndex -= 1;
                if (tcCheckin.SelectedIndex == 0)
                {
                    btnBack.Visible = false;
                }
            }
        }

    }
}
