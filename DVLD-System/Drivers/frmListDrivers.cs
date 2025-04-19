using C19_Project.Licenses.International_Licenses;
using C19_Project.People;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C19_Project.Drivers
{
    public partial class frmListDrivers : Form
    {
        public frmListDrivers()
        {
            InitializeComponent();
        }
        private DataTable DriversTable = new DataTable();
        private void _FillDataIntoGridView()
        {
            DriversTable = clsDriver.GetAllDrivers();
            // full the data grid view
            DvgDriversList.DataSource = DriversTable;
        }
        private void _GetDriversCount()
        {
            // Get People Count
            lblPPLCount.Text = (DvgDriversList.RowCount).ToString();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            Font MyFont = new Font("Calibri", 14, FontStyle.Bold); // 14 is the size
            // Apply the font to the DataGridView's DefaultCellStyle
            DvgDriversList.DefaultCellStyle.Font = MyFont;
            // Optionally, you can also change the column header font size
            DvgDriversList.ColumnHeadersDefaultCellStyle.Font = MyFont;
            _FillDataIntoGridView();
            _GetDriversCount();

            DvgDriversList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Disable AutoSize
            cbFilterby.SelectedIndex = 0; 
            // Now, set the width And Text
            if (DvgDriversList.Columns.Contains("FullName"))
            {
                DvgDriversList.Columns["FullName"].Width = 260;
            }
            if (DvgDriversList.Columns.Contains("NumberOfActiveLicenses"))  
            {
                DvgDriversList.Columns["NumberOfActiveLicenses"].HeaderText = "Active Licenses";
                DvgDriversList.Columns["NumberOfActiveLicenses"].Width = 150;
            }

        }

        private void txtSearchPpl_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearchPpl.Text;
            // Apply the filter to the DataTable's DefaultView
            if (!string.IsNullOrEmpty(filterText))
            {
                switch (cbFilterby.Text)
                {
                    case "DriverID":
                        if (int.TryParse(filterText, out int DriverID))
                        {
                            // Apply the filter using the equality operator (PersonID = filterText)
                            DriversTable.DefaultView.RowFilter = $"DriverID = {DriverID}";
                        }
                        break;
                    case "PersonID":
                        if (int.TryParse(filterText, out int personID))
                        {
                            // Apply the filter using the equality operator (PersonID = filterText)
                            DriversTable.DefaultView.RowFilter = $"PersonID = {personID}";
                        }
                        break;
                    case "NationalNo":
                        DriversTable.DefaultView.RowFilter = $"NationalNo LIKE '{filterText}%'";
                        break;
                    case "Full Name":
                        DriversTable.DefaultView.RowFilter = $"FullName LIKE '{filterText}%'";
                        break;
                    case "Active Licenses":
                        if (int.TryParse(filterText, out int ActiveLicenses))
                        {
                            // Apply the filter using the equality operator (PersonID = filterText)
                            DriversTable.DefaultView.RowFilter = $"NumberOfActiveLicenses = {ActiveLicenses}";
                        }
                        break;
                    default:
                        DriversTable.DefaultView.RowFilter = "";
                        break;
                }
            }
            else
                DriversTable.DefaultView.RowFilter = "";
        }

        private void cbFilterby_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchPpl.Visible = true;
            if (cbFilterby.SelectedItem.ToString() == "None")
            {
                txtSearchPpl.Visible = false;
                txtSearchPpl.Text = "";
                DriversTable.DefaultView.RowFilter = "";
            }
        }

        private void txtSearchPpl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterby.SelectedItem.ToString() == "PersonID" || cbFilterby.SelectedItem.ToString() == "DriverID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)DvgDriversList.CurrentRow.Cells[1].Value;
            frmShowPersonDetails frm = new frmShowPersonDetails(PersonID);
            frm.ShowDialog();
            //refresh
            frmListDrivers_Load(null, null);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)DvgDriversList.CurrentRow.Cells[1].Value;
            int DriverID = (int)DvgDriversList.CurrentRow.Cells[0].Value;

            frmLicensesHistory frm = new frmLicensesHistory(DriverID ,PersonID);
            frm.ShowDialog();
        }
    }
}
