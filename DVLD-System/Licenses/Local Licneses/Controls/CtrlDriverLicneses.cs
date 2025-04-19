using C19_Project.Applications.InterNationalDrivingLicenseApplication.NewInterNationalDrivingLicense;
using DVLD_BuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C19_Project.Licenses.International_Licenses.Controls
{
    public partial class CtrlDriverLicneses : UserControl
    {
        private clsDriver Driverinfo;
        private int _DriverID = -1;
        public CtrlDriverLicneses()
        {
            InitializeComponent();
        }
        private void _LoadLocalDrivingLicenseByDriverID()
        {
            // Locals
            DataTable _LocalLicensesTable = new DataTable();
            _LocalLicensesTable = clsLicense.GetDriverLicenses(_DriverID);
            dgvLocalLicensesHistory.DataSource = _LocalLicensesTable;

            if (dgvLocalLicensesHistory.RowCount > 0)
            {
                Font MyFont = new Font("Calibri", 12, FontStyle.Bold); // 14 is the size
                                                                       // Apply the font to the DataGridView's DefaultCellStyle
                dgvLocalLicensesHistory.DefaultCellStyle.Font = MyFont;
                // Optionally, you can also change the column header font size
                dgvLocalLicensesHistory.ColumnHeadersDefaultCellStyle.Font = MyFont;

                // Rows count
                lblLocalLicensesRecords.Text = dgvLocalLicensesHistory.RowCount.ToString();

                dgvLocalLicensesHistory.Columns[0].Width = 120;

                dgvLocalLicensesHistory.Columns[1].HeaderText = "App.ID";
                dgvLocalLicensesHistory.Columns[1].Width = 120;

                dgvLocalLicensesHistory.Columns[2].Width = 250;
                dgvLocalLicensesHistory.Columns[3].Width = 165;
                dgvLocalLicensesHistory.Columns[4].Width = 165;
            }
        }
        private void _LoadInternationalDrivingLicenseByDriverID()
        {
            // internationals
            DataTable _InternationalLicensesTable = new DataTable();
            _InternationalLicensesTable = clsInternationalLicense.GetDriverInternationalLicenses(_DriverID);
            dgvInternationalLicensesHistory.DataSource = _InternationalLicensesTable;

            if (dgvInternationalLicensesHistory.RowCount > 0)
            {
                Font MyFont = new Font("Calibri", 12, FontStyle.Bold);

                dgvInternationalLicensesHistory.DefaultCellStyle.Font = MyFont;
                dgvInternationalLicensesHistory.ColumnHeadersDefaultCellStyle.Font = MyFont;

                lblInternationalLicensesRecords.Text = dgvInternationalLicensesHistory.RowCount.ToString();

                dgvInternationalLicensesHistory.Columns[0].HeaderText = "IntN.ID";
                dgvInternationalLicensesHistory.Columns[0].Width = 120;

                dgvInternationalLicensesHistory.Columns[1].HeaderText = "App.ID";
                dgvInternationalLicensesHistory.Columns[1].Width = 120;

                dgvInternationalLicensesHistory.Columns[2].HeaderText = "L.LID";
                dgvInternationalLicensesHistory.Columns[2].Width = 165;


                dgvInternationalLicensesHistory.Columns[3].Width = 165;

                dgvInternationalLicensesHistory.Columns[4].Width = 165;
            }
            else
                dgvInternationalLicensesHistory.Enabled = false;
        }
        public void LoadAllLicensesByDriverID(int DriverID)
        {
            _DriverID = DriverID;
            Driverinfo = clsDriver.FindUserPersonIDByDriverID(_DriverID);
            if (Driverinfo == null)
            {
                MessageBox.Show ("There is No Driver With ID = " + _DriverID ,"Not Found",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            _LoadLocalDrivingLicenseByDriverID();
            _LoadInternationalDrivingLicenseByDriverID();
        }
        public void LoadAllLicensesByPersonID(int PersonID)
        {
            Driverinfo = clsDriver.FindUserPersonIDByPersonID(PersonID);
            
            if (Driverinfo == null)
            {
                MessageBox.Show("There is No Driver Link With Person ID = " + PersonID, "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _DriverID = Driverinfo.DriverID;
            _LoadLocalDrivingLicenseByDriverID();
            _LoadInternationalDrivingLicenseByDriverID();
        }
        //public void Clear()
        //{
        //    .Clear();
        //    _dtDriverInternationalLicensesHistory.Clear();
        //}
        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicense ShowLocalLicense =
                new frmShowLicense((int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value);
            ShowLocalLicense.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowInterNationalLicenseInfo ShowInterLicense =
                new frmShowInterNationalLicenseInfo((int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value);
            ShowInterLicense.ShowDialog();
        }

    }
}
