using Hotel_erp_Winforms_App.Helpers;
using Hotel_erp_Winforms_App.Models;
using Hotel_erp_Winforms_App.UI;
using Hotel_erp_Winforms_App.Forms;
using Hotel_erp_Winforms_App.UI.Forms.ServiceForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;


namespace Hotel_erp_Winforms_App.UI.Controls.EmployeeControl
{
    public partial class EmployeeSideControl : UserControl
    {
        private Employee? _selectedEmployee;

        public EmployeeSideControl()
        {
            InitializeComponent();
        }

        private void MakePictureBoxRound(PictureBox pb)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();

            gp.AddEllipse(0, 0, pb.Width - 1, pb.Height - 1);
            pb.Region = new Region(gp);
        }

        private void pbProfilePhoto_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int borderSize = 3;

            using (Pen pen = new Pen(Color.Black, borderSize))
            {
                e.Graphics.DrawEllipse(
                    pen,
                    borderSize / 2f,
                    borderSize / 2f,
                    pbProfilePhoto.Width - borderSize - 1,
                    pbProfilePhoto.Height - borderSize - 1
                );
            }
        }

        private void EmployeeSideControl_Load(object sender, EventArgs e)
        {
            MakePictureBoxRound(pbProfilePhoto);
        }

        public void EmployeeDetails(Employee employee)
        {
            if (employee == null) return;

            _selectedEmployee = employee;

            lbEmployeeSideName.Text = $"{employee.LName} {employee.FName}";
            lbEmployeeSideTaxNumber.Text = $"{employee.TaxNumber}";
            lbEmployeeSideHolidays.Text = $"{employee.PaidHolidaysLeft} nap";
            lbEmployeeSideAddress.Text = $"{employee.Address}";
            lbEmployeeSideBirth.Text = $"{employee.DateOfBirth.ToString("yyyy-MM-dd")}";
            lbEmployeeSideHiring.Text = $"{employee.DateOfHiring.Date.ToString("yyyy-MM-dd")}";
            lbEmployeeSideJobTitle.Text = $"{employee.JobTitle}";
            lbEmployeeSideSalary.Text = $"{employee.Salary} Ft";
        }

        public void CurrentUserDetails(Employee user)
        {
            if (user == null) return;

            _selectedEmployee = user;

            lbEmployeeSideName.Text = $"{user.LName} {user.FName}";
            lbEmployeeSideTaxNumber.Text = $"{user.TaxNumber}";
            lbEmployeeSideHolidays.Text = $"{user.PaidHolidaysLeft} nap";
            lbEmployeeSideAddress.Text = $"{user.Address}";
            lbEmployeeSideBirth.Text = $"{user.DateOfBirth.ToString("yyyy-MM-dd")}";
            lbEmployeeSideHiring.Text = $"{user.DateOfHiring.Date.ToString("yyyy-MM-dd")}";
            lbEmployeeSideJobTitle.Text = $"{user.JobTitle}";
            lbEmployeeSideSalary.Text = $"{user.Salary} Ft";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddEmployee addEmployee = new FrmAddEmployee();
            addEmployee.ShowDialog();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if(_selectedEmployee == null)
            {
                MessageBox.Show("Please select an employee first!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (FrmEditEmployee editEmployee = new FrmEditEmployee())
            {
                editEmployee.DisplayEmployee(_selectedEmployee);
                editEmployee.ShowDialog();
            }
        }
    }
}
