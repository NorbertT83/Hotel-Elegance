using Hotel_erp_Winforms_App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_erp_Winforms_App.Helpers
{
    public class CommonHelper
    {
        public static Employee? CurrentUser { get; set; }

        // Block digits in textbox
        public static class InputValidationService
        {
            public static void BlockDigits(KeyPressEventArgs e)
            {
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

            public static void BlockLetters(KeyPressEventArgs e)
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        // empty space check for textboxes
        public bool HasValidationError(System.Windows.Forms.TextBox tb, ErrorProvider ep)
        {
            if (string.IsNullOrEmpty(tb.Text.Trim()))
            {
                ep.SetError(tb, "You can't leave empty spaces!");
                return true;
            }
            else { ep.SetError(tb, ""); return false; }
        }

        // empty list message box
        public void EmptyListMessageBox(int listCount, string dataType)
        {
            if (listCount == 0)
            {
                MessageBox.Show(
                    $"No matching {dataType} found.",
                    "Search Results",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }
        }

        // Error message box
        public void MBErrorMessage(Exception ex)
        {
            MessageBox.Show(
                "An error occured while trying to execute the process: " + ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}
