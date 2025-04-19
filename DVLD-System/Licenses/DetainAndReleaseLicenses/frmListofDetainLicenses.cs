using C19_Project.Licenses;
using C19_Project.Licenses.DetainAndReleaseLicenses.Release_Detained_Licenses;
using C19_Project.Licenses.International_Licenses;
using C19_Project.People;
using DVLD_BuisnessLayer;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace C19_Project.Applications.DetainAndReleaseLicenses
{
    public partial class frmListofDetainLicenses : Form
    {
        private DataTable _DetainedLicensesTable;
        public frmListofDetainLicenses()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListofDetainLicenses_Load(object sender, EventArgs e)
        {
            Font MyFont = new Font("Calibri", 11,FontStyle.Bold); // 11 is the size
            // Apply the font to the DataGridView's DefaultCellStyle
            dgvDetainedLicenses.DefaultCellStyle.Font = MyFont;
            // Optionally, you can also change the column header font size
            dgvDetainedLicenses.ColumnHeadersDefaultCellStyle.Font = MyFont;

            cbFilterBy.SelectedIndex = 0;

            _DetainedLicensesTable = clsDetainedLicense.GetAllDetainedLicenses();

            dgvDetainedLicenses.DataSource = _DetainedLicensesTable;
            lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

            if (dgvDetainedLicenses.Rows.Count > 0)
            {

                dgvDetainedLicenses.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicenses.Columns[0].Width = 70;

                dgvDetainedLicenses.Columns[1].HeaderText = "L.ID";
                dgvDetainedLicenses.Columns[1].Width = 70;

                dgvDetainedLicenses.Columns[2].HeaderText = "D.Date";
                dgvDetainedLicenses.Columns[2].Width = 150;

                dgvDetainedLicenses.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicenses.Columns[3].Width = 95;

                dgvDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicenses.Columns[4].Width = 90;

                dgvDetainedLicenses.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicenses.Columns[5].Width = 150;

                dgvDetainedLicenses.Columns[6].HeaderText = "N.No.";
                dgvDetainedLicenses.Columns[6].Width = 70;

                dgvDetainedLicenses.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicenses.Columns[7].Width = 300;

                dgvDetainedLicenses.Columns[8].HeaderText = "Release App.ID";
                dgvDetainedLicenses.Columns[8].Width = 120;

            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "Is Released":
                    {
                        FilterColumn = "IsReleased";
                        break;
                    };

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _DetainedLicensesTable.DefaultView.RowFilter = "";
                lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                _DetainedLicensesTable.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _DetainedLicensesTable.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblTotalRecords.Text = _DetainedLicensesTable.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Detain ID" || cbFilterBy.Text == "Release Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;

            frmShowPersonDetails frm = new frmShowPersonDetails(1);
            frm.ShowDialog();
        }

        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetaindeLicenses frm = new frmReleaseDetaindeLicenses();
            frm.ShowDialog();
            //refresh form
            frmListofDetainLicenses_Load(null, null);
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicenses frm = new frmDetainLicenses();
            frm.ShowDialog();
            //refresh form
            frmListofDetainLicenses_Load(null, null);
        }

        private void cmsApplications_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled = !(bool)dgvDetainedLicenses.CurrentRow.Cells[3].Value;
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;

            frmReleaseDetaindeLicenses frm = new frmReleaseDetaindeLicenses(LicenseID);
            frm.ShowDialog();
            //refresh form
            frmListofDetainLicenses_Load(null, null);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;

            frmShowLicense frm = new frmShowLicense(LicenseID);
            frm.ShowDialog();

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            int PersonID = clsLicense.FindUserPersonID(LicenseID).DriverInfo.PersonID;
            int DriverID = clsLicense.FindUserPersonID(LicenseID).DriverInfo.DriverID;

            frmLicensesHistory frm = new frmLicensesHistory(DriverID ,PersonID);
            frm.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Released")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Focus();
                cbIsReleased.SelectedIndex = 0;
            }

            else

            {

                txtFilterValue.Visible = (cbFilterBy.Text != "None");
                cbIsReleased.Visible = false;

                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Enabled = false; 
                }
                else
                    txtFilterValue.Enabled = true;

                txtFilterValue.Text = "";
                txtFilterValue.Focus();
            }
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsReleased";
            string FilterValue = cbIsReleased.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _DetainedLicensesTable.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _DetainedLicensesTable.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblTotalRecords.Text = _DetainedLicensesTable.Rows.Count.ToString();
        }
    }
}
