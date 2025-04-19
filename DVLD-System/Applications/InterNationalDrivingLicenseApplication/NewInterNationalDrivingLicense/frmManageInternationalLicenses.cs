using C19_Project.Licenses.International_Licenses;
using C19_Project.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BuisnessLayer;

namespace C19_Project.Applications.InterNationalDrivingLicenseApplication.NewInterNationalDrivingLicense
{
    public partial class frmManageInternationalLicenses : Form
    {
        private DataTable _InternationalLicenseApplicationsTable;
        public frmManageInternationalLicenses()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _FillDataInGridView()
        {
            _InternationalLicenseApplicationsTable = clsInternationalLicense.GetAllInternationalLicenses();
            cbFilterby.SelectedIndex = 0;

            dgvInternationalLicenses.DataSource = _InternationalLicenseApplicationsTable;
        }
        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            _FillDataInGridView();
            lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();

            if (dgvInternationalLicenses.Rows.Count > 0)
            {
                Font MyFont = new Font("Calibri", 12, FontStyle.Bold);
                                                                       
                dgvInternationalLicenses.DefaultCellStyle.Font = MyFont;
                // Optionally, you can also change the column header font size
                dgvInternationalLicenses.ColumnHeadersDefaultCellStyle.Font = MyFont;


                dgvInternationalLicenses.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenses.Columns[0].Width = 120;

                dgvInternationalLicenses.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenses.Columns[1].Width = 100;

                dgvInternationalLicenses.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenses.Columns[2].Width = 90;

                dgvInternationalLicenses.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicenses.Columns[3].Width = 90;

                dgvInternationalLicenses.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenses.Columns[4].Width = 165;

                dgvInternationalLicenses.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenses.Columns[5].Width = 165;

                dgvInternationalLicenses.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenses.Columns[6].Width = 80;

            }
        }

        private void PesonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindUserPersonIDByDriverID(DriverID).PersonID;

            frmShowPersonDetails frm = new frmShowPersonDetails(PersonID);
            frm.ShowDialog();
            //refresh Form
            frmManageInternationalLicenses_Load(null, null);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dgvInternationalLicenses.CurrentRow.Cells[0].Value;
            frmShowInterNationalLicenseInfo frm = new frmShowInterNationalLicenseInfo(InternationalLicenseID);
            frm.ShowDialog();
        }

        private void btnNewApplication_Click(object sender, EventArgs e)
        {
            frmNewInterNationalLicenseApplication frm = new frmNewInterNationalLicenseApplication();
            frm.ShowDialog();
            //refresh Form
            frmManageInternationalLicenses_Load(null, null);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;
            int PersonID = clsDriver.FindUserPersonIDByDriverID(DriverID).PersonID;
            frmLicensesHistory frm = new frmLicensesHistory(DriverID,PersonID);
            frm.ShowDialog();
            //refresh Form
            frmManageInternationalLicenses_Load(null, null);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = true;
            if (cbFilterby.SelectedItem.ToString() == "None")
            {
                txtSearch.Visible = false;
                txtSearch.Text = "";
                _FillDataInGridView();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterby.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    {
                        FilterColumn = "ApplicationID";
                        break;
                    };

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;


                default:
                    FilterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtSearch.Text == "" || FilterColumn == "None")
            {
                _InternationalLicenseApplicationsTable.DefaultView.RowFilter = "";
                lblInternationalLicensesRecords.Text = dgvInternationalLicenses.Rows.Count.ToString();
                return;
            }
            _InternationalLicenseApplicationsTable.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
