
using Hotel_erp_Winforms_App.Helpers;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.Services;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Hotel_erp_Winforms_App.UI.Forms
{
    public partial class FrmCheckout : Form
    {
        private readonly Booking _booking;

        public FrmCheckout(Booking booking)
        {
            InitializeComponent();

            _booking = booking ?? throw new ArgumentNullException(nameof(booking));
        }

        #region variables
        // SERVICE OSZTÁLYOK
        GuestService guestService = new GuestService();
        CommonHelper commonHelper = new CommonHelper();
        CheckoutService checkoutService = new CheckoutService();
        RoomService roomService = new RoomService();
        ServiceService serviceService = new ServiceService();

        // LISTÁK
        List<Guest> guests = new List<Guest>();
        List<Room> rooms = new List<Room>();

        // GLOBÁLIS VÁLTOZÓK
        Guest selectedGuest;

        #endregion

        #region Onload actions

        private async void FrmCheckout_Load(object sender, EventArgs e)
        {
            if (_booking != null)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    await GetSelectedGuestDataAsync();
                    List<CheckoutSumHelper> items = await checkoutService.GetServiceItemsAsync(_booking.Id);

                    // DATAGRIDVIEW
                    colName.DataPropertyName = nameof(CheckoutSumHelper.Name);
                    colQuantity.DataPropertyName = nameof(CheckoutSumHelper.Quantity);
                    colUnitPrice.DataPropertyName = nameof(CheckoutSumHelper.UnitPrice);
                    colTotalPrice.DataPropertyName = nameof(CheckoutSumHelper.TotalPrice);

                    colUnitPrice.DefaultCellStyle.Format = "N0";
                    colTotalPrice.DefaultCellStyle.Format = "N0";

                    dgvItems.AutoGenerateColumns = false;
                    dgvItems.DataSource = null;
                    dgvItems.DataSource = items;
                    dgvItems.ClearSelection();

                    // FENTI ADATOK
                    txtRoomNumber.Text = _booking.RoomNumber.ToString();
                    txtGuestName.Text = selectedGuest.LName + " " + selectedGuest.FName;
                    dtpCheckInDate.Value = Convert.ToDateTime(_booking.Checkin);
                    dtpCheckOutDate.Value = DateTime.Now;

                    // ÁR ÖSSZEGEK

                    int days = (DateTime.Today.Date - Convert.ToDateTime(_booking.Checkin).Date).Days;

                    // ----- Room price ------
                    rooms = await roomService.GetAllRoomsAsync();

                    Room selectedRoom = rooms.Find(r => r.Room_number == _booking.RoomNumber);
                    int roomPrice = selectedRoom.Price;

                    lblRoomPrice.Text = $"Room Price (HUF): {(roomPrice * days):n0}";

                    // ----- Extras price ----
                    int extrasPrice = 0;
                    foreach (var item in items)
                    {
                        extrasPrice += item.TotalPrice;
                    }

                    lblExtraCharge.Text = $"Extras/Services (HUF): {extrasPrice:n0}";

                    // ---- Catering price ---
                    List<Service> services = await serviceService.GetAllServicesFromDbAsync();

                    int cateringPrice = 0;
                    Service selectedCatering = null;

                    switch (_booking.SelectedCateringLevel)
                    {
                        case CateringLevel.breakfast:
                            cateringPrice = 0;
                            break;
                        case CateringLevel.halfboard:
                            selectedCatering = services.Find(s => s.NameHu == "Félpanzió");
                            cateringPrice = (int)selectedCatering.Price;
                            break;
                        case CateringLevel.fullboard:
                            selectedCatering = services.Find(s => s.NameHu == "Teljes ellátás");
                            cateringPrice = (int)selectedCatering.Price;
                            break;
                    }

                    if (selectedCatering != null)
                    {
                        lblCatering.Text = $"Catering (HUF): {(cateringPrice * days):n0}";
                    }

                    // ----- Total -----

                    lblTotalAmount.Text = $"{(roomPrice * days + extrasPrice + cateringPrice * days):N0} HUF";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba a betöltés során: {ex.Message}\n\nRészletek:\n{ex.StackTrace}");
                }
                finally
                {

                }
            }
            else
            {
                var ex = new Exception("A vendég adatai nem találhatók.");

                commonHelper.MBErrorMessage(ex);
            }
        }

        #endregion

        #region Actions

        // DGV CELLCLICK
        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvItems.ClearSelection();
        }

        // COMPLETE CHECKOUT BUTTON
        private async void btnCompleteCheckout_Click(object sender, EventArgs e)
        {
            if (_booking != null && cmbPaymentMethod.SelectedIndex > -1)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    await GenerateAndOpenInvoiceAsync(_booking);
                    await checkoutService.CheckoutBookingAsync(_booking);

                    MessageBox.Show(
                        $"The checkout of booking ({_booking.Id}) was successful.",
                        "Successful checkout",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    commonHelper.MBErrorMessage(ex);
                }
                finally
                {
                    this.Close();

                    Cursor.Current = Cursors.Default;
                }
            }

            else
            {
                MessageBox.Show(
                    $"Please select a payment method first!",
                    "Selection Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
        }

        // SZÁMLA GENERÁLÁS
        public async Task GenerateAndOpenInvoiceAsync(Booking selectedBooking, int copyNumber = 1)
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            int days = (DateTime.Today.Date - Convert.ToDateTime(selectedBooking.Checkin).Date).Days;
            if (days <= 0) days = 1;

            var items = await checkoutService.GetServiceItemsAsync(selectedBooking.Id);
            var rooms = await roomService.GetAllRoomsAsync();
            var services = await serviceService.GetAllServicesFromDbAsync();

            var selectedRoom = rooms.Find(r => r.Room_number == selectedBooking.RoomNumber);
            decimal roomUnitPriceGross = selectedRoom?.Price ?? 0;
            decimal totalRoomPriceGross = roomUnitPriceGross * days;
            string payMethod = cmbPaymentMethod.Text;
            string guestName = txtGuestName.Text;

            decimal extrasPriceGross = items?.Sum(i => i.TotalPrice) ?? 0;

            decimal cateringUnitPriceGross = selectedBooking.SelectedCateringLevel switch
            {
                CateringLevel.halfboard => services.Find(s => s.NameHu == "Félpanzió")?.Price ?? 0,
                CateringLevel.fullboard => services.Find(s => s.NameHu == "Teljes ellátás")?.Price ?? 0,
                _ => 0
            };
            decimal totalCateringPriceGross = cateringUnitPriceGross * days;

            // Számítások (ÁFA kulcsok: Szállás/Étkezés 5%, Egyéb szolgáltatások 27%)
            decimal roomNet = totalRoomPriceGross / 1.05m;
            decimal roomVat = totalRoomPriceGross - roomNet;

            decimal cateringNet = totalCateringPriceGross / 1.05m;
            decimal cateringVat = totalCateringPriceGross - cateringNet;

            decimal extrasNet = extrasPriceGross / 1.27m;
            decimal extrasVat = extrasPriceGross - extrasNet;

            decimal totalNet = roomNet + cateringNet + extrasNet;
            decimal totalVat = roomVat + cateringVat + extrasVat;
            decimal grandTotal = totalRoomPriceGross + totalCateringPriceGross + extrasPriceGross;

            string copyText = copyNumber == 1 ? "1. példány (Vevő)" : "2. példány (Eladó)";
            string logoPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "HE-Logo.png");

            var doc = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1.5f, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(9).FontColor(Colors.Grey.Darken3));

                    // FEJLÉC LOGÓVAL ÉS PÉLDÁNYSZÁMMAL
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Row(r =>
                        {
                            if (System.IO.File.Exists(logoPath))
                            {
                                r.AutoItem().Height(40).Image(logoPath);
                                r.ConstantItem(10);
                            }

                            r.RelativeItem().Column(col =>
                            {
                                col.Item().Text("SZÁMLA / INVOICE").FontSize(18).Bold().FontColor(Colors.Blue.Darken3);
                                col.Item().Text(copyText).FontSize(9).Bold().FontColor(Colors.Grey.Darken1);
                            });
                        });

                        row.RelativeItem().AlignRight().Column(col =>
                        {
                            col.Item().Text($"Számlaszám: INT-{DateTime.Now:yyyyMMdd}-{selectedBooking.Id}");
                            col.Item().Text($"Kelt: {DateTime.Now:yyyy.MM.dd}");
                            col.Item().Text($"Fizetési mód: {payMethod}");
                        });
                    });

                    // TARTALOM
                    page.Content().PaddingVertical(10).Column(col =>
                    {
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Border(1).BorderColor(Colors.Grey.Lighten2).Padding(8).Column(c =>
                            {
                                c.Item().Text("KIBOCSÁTÓ (HOTEL)").Bold().FontSize(8).FontColor(Colors.Blue.Medium);
                                c.Item().Text("Hotel Elegance Kft.").Bold();
                                c.Item().Text("1051 Budapest, Fő utca 1.");
                                c.Item().Text("Adószám: 12345678-2-41");
                            });

                            row.ConstantItem(10);

                            row.RelativeItem().Border(1).BorderColor(Colors.Grey.Lighten2).Padding(8).Column(c =>
                            {
                                c.Item().Text("VEVŐ (VENDÉG)").Bold().FontSize(8).FontColor(Colors.Blue.Medium);
                                c.Item().Text($"{guestName}").Bold();
                                c.Item().Text($"Szobaszám: {selectedBooking.RoomNumber}");
                                c.Item().Text($"Foglalási azonosító: {selectedBooking.Id}");
                            });
                        });

                        col.Item().PaddingVertical(10);

                        // TÁBLÁZAT ÁFA ÉRTÉKEKKEL
                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(3); // Megnevezés
                                columns.RelativeColumn(1); // Mennyiség
                                columns.RelativeColumn(1); // Nettó
                                columns.RelativeColumn(1); // ÁFA %
                                columns.RelativeColumn(1); // ÁFA érték
                                columns.RelativeColumn(1); // Bruttó
                            });

                            table.Header(header =>
                            {
                                header.Cell().Background(Colors.Blue.Darken3).Padding(4).Text("Megnevezés").FontColor(Colors.White).Bold();
                                header.Cell().Background(Colors.Blue.Darken3).Padding(4).AlignRight().Text("Menny.").FontColor(Colors.White).Bold();
                                header.Cell().Background(Colors.Blue.Darken3).Padding(4).AlignRight().Text("Nettó").FontColor(Colors.White).Bold();
                                header.Cell().Background(Colors.Blue.Darken3).Padding(4).AlignRight().Text("ÁFA %").FontColor(Colors.White).Bold();
                                header.Cell().Background(Colors.Blue.Darken3).Padding(4).AlignRight().Text("ÁFA").FontColor(Colors.White).Bold();
                                header.Cell().Background(Colors.Blue.Darken3).Padding(4).AlignRight().Text("Bruttó").FontColor(Colors.White).Bold();
                            });

                            // Szállás díj
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text($"Szállásdíj ({selectedBooking.RoomNumber}. szoba)");
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).AlignRight().Text($"{days} éj");
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).AlignRight().Text($"{roomNet:N0} Ft");
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).AlignRight().Text("5%");
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).AlignRight().Text($"{roomVat:N0} Ft");
                            table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).AlignRight().Text($"{totalRoomPriceGross:N0} Ft");

                            // Ellátás
                            if (totalCateringPriceGross > 0)
                            {
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text($"Ellátás ({selectedBooking.SelectedCateringLevel})");
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).AlignRight().Text($"{days} nap");
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).AlignRight().Text($"{cateringNet:N0} Ft");
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).AlignRight().Text("5%");
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).AlignRight().Text($"{cateringVat:N0} Ft");
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).AlignRight().Text($"{totalCateringPriceGross:N0} Ft");
                            }

                            // Extra szolgáltatások
                            if (items != null)
                            {
                                foreach (var item in items)
                                {
                                    decimal itemNet = item.TotalPrice / 1.27m;
                                    decimal itemVat = item.TotalPrice - itemNet;

                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).Text(item.Name ?? "Egyéb szolgáltatás");
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).AlignRight().Text("1 db");
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).AlignRight().Text($"{itemNet:N0} Ft");
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).AlignRight().Text("27%");
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).AlignRight().Text($"{itemVat:N0} Ft");
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(4).AlignRight().Text($"{item.TotalPrice:N0} Ft");
                                }
                            }
                        });

                        col.Item().PaddingVertical(8);

                        // ÖSSZESÍTÉS
                        col.Item().AlignRight().Column(c =>
                        {
                            c.Item().Text($"Összes nettó: {totalNet:N0} Ft").FontSize(9);
                            c.Item().Text($"Összes ÁFA: {totalVat:N0} Ft").FontSize(9);
                            c.Item().Text($"Fizetendő bruttó: {grandTotal:N0} Ft").FontSize(12).Bold().FontColor(Colors.Blue.Darken3);
                        });

                        col.Item().PaddingVertical(15);

                        // PECSÉT ÉS ALÁÍRÁS HELYE
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Height(40);
                                c.Item().LineHorizontal(1).LineColor(Colors.Grey.Medium);
                                c.Item().AlignCenter().Text("Hotel pecsét / Számlakibocsátó aláírása").FontSize(8);
                            });

                            row.ConstantItem(40);

                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Height(40);
                                c.Item().LineHorizontal(1).LineColor(Colors.Grey.Medium);
                                c.Item().AlignCenter().Text("Vendég aláírása (Átvette)").FontSize(8);
                            });
                        });
                    });

                    // LÁBLÉC
                    page.Footer().AlignCenter().Text("Köszönjük, hogy minket választott! • Hotel Elegance Budapest").FontSize(8).FontColor(Colors.Grey.Medium);
                });
            });

            string pdfPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"szamla_{selectedBooking.Id}.pdf");
            doc.GeneratePdf(pdfPath);

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = pdfPath,
                UseShellExecute = true
            });
        }

        // CANCEL BUTTON
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
        #region helpers

        private async Task GetSelectedGuestDataAsync()
        {
            guests = await guestService.GetAllGuestsFromDbAsync();

            if (_booking != null)
            {
                selectedGuest = guests.Find(g => g.Id == _booking.GuestId);
            }
        }

        #endregion
    }
}
