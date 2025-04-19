using C19_Project.Licenses;
using C19_Project.Licenses.International_Licenses;
using C19_Project.ManageAppsTests;
using C19_Project.ManageAppsTests.TakeTests;
using C19_Project.NewDrivingLicensesApplication.frmIssueDrivingLicenseFirstTime;


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DVLD_Buisness;

namespace C19_Project.NewDrivingLicensesApplication.NewLocalDrivingLicense
{
    public partial class frmManageLocalDrivingLicensesApps : Form
    {
        public frmManageLocalDrivingLicensesApps()
        {
            InitializeComponent();
        }
        private DataTable LDl_ApplicationsTable = new DataTable();
        private void _FillDataInGridView()
        {
            LDl_ApplicationsTable = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();

            // full the data grid view
            DvgAllDrivingLicenseApplication.DataSource = LDl_ApplicationsTable;
            cbFilterby.Text = "None";
        }
        private void _GetUsersCount()
        {
            // Get Apps Count
            lblAppsCount.Text = (DvgAllDrivingLicenseApplication.RowCount).ToString();
        }
        private void ManageLocalDrivingLicensesApps_Load(object sender, EventArgs e)
        {

            //DvgAllDLApplication.Font = new Font ()
            Font MyFont = new Font("Calibri", 13); // 13 is the size
            // Apply the font to the DataGridView's DefaultCellStyle
            DvgAllDrivingLicenseApplication.DefaultCellStyle.Font = MyFont;
            // Optionally, you can also change the column header font size
            DvgAllDrivingLicenseApplication.ColumnHeadersDefaultCellStyle.Font = MyFont;

            //btnAddNewUser.Focus();
            cbFilterby.Text = "None";

            _FillDataInGridView();
            _GetUsersCount();

            //// Ensure no row is selected initially
            //DvgAllDLApplication.ClearSelection(); DvgAllDLApplication.CurrentCell = null;

            DvgAllDrivingLicenseApplication.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Disable AutoSize

            DvgAllDrivingLicenseApplication.Columns[0].HeaderText = "LDLID";
            DvgAllDrivingLicenseApplication.Columns[5].HeaderText = "PassedTests";
            // Now, set the width
            DvgAllDrivingLicenseApplication.Columns[0].Width = 70;
            DvgAllDrivingLicenseApplication.Columns[1].Width = 260;
            DvgAllDrivingLicenseApplication.Columns[2].Width = 110;
            DvgAllDrivingLicenseApplication.Columns[3].Width = 215;
            DvgAllDrivingLicenseApplication.Columns[4].Width = 180;
            DvgAllDrivingLicenseApplication.Columns[5].Width = 119;
            DvgAllDrivingLicenseApplication.Columns[6].Width = 110;
            // Wire up the TextChanged event for filtering
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearch.Text;

            // Apply the filter to the DataTable's DefaultView
            if (!string.IsNullOrEmpty(filterText))
            {

                if (cbFilterby.SelectedItem.ToString() == "DDL_ID")
                {
                    if (int.TryParse(filterText, out int UserID))
                    {
                        // Apply the filter using the equality operator (PersonID = filterText)
                        LDl_ApplicationsTable.DefaultView.RowFilter = $"LocalDrivingLicenseApplicationID = {UserID}";
                    }
                }

                else if (cbFilterby.SelectedItem.ToString() == "National No")
                {
                    LDl_ApplicationsTable.DefaultView.RowFilter = $"NationalNo LIKE '{filterText}%'";
                }
                else if (cbFilterby.SelectedItem.ToString() == "Full Name")
                {
                    LDl_ApplicationsTable.DefaultView.RowFilter = $"FullName LIKE '{filterText}%'";
                }
                else if (cbFilterby.SelectedItem.ToString() == "status")
                {
                    LDl_ApplicationsTable.DefaultView.RowFilter = $"status LIKE '{filterText}%'";
                }

                else
                {
                    LDl_ApplicationsTable.DefaultView.RowFilter = "";
                }

            }
            else
            {
                LDl_ApplicationsTable.DefaultView.RowFilter = "";
            }
        }

        private void cbFilterby_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = true;
            if (cbFilterby.SelectedItem.ToString() == "None")
            {
                txtSearch.Visible = false;
                txtSearch.Text = "";
                _FillDataInGridView();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterby.SelectedItem.ToString() == "DDL_ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            frmAdd_UpdateNewLocalDrivingLicenseApps frmAddLDL = new frmAdd_UpdateNewLocalDrivingLicenseApps();
            frmAddLDL.ShowDialog();

            // Refresh Data
            _FillDataInGridView();
            _GetUsersCount();
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseID = Convert.ToInt32(DvgAllDrivingLicenseApplication.SelectedRows[0].Cells[0].Value);
            frmTestsAppointments Test = new frmTestsAppointments(LocalDrivingLicenseID ,clsTestType.enTestType.VisionTest);
            Test.ShowDialog();
            // Refresh Form
            _FillDataInGridView();
            _GetUsersCount();
        }

        private void DvgAllDLApplication_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tmsShow_Click(object sender, EventArgs e)
        {
            int LDL_ID = Convert.ToInt32( DvgAllDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            int ApplicationID = clsLocalDrivingLicenseApplication.FindUserPersonIDByLocalDrivingAppLicenseID(LDL_ID).ApplicationID;

            if (ApplicationID != -1)
            {
                frmShowLocalDrivingLicenseApplicationDetails ShowDetails = new frmShowLocalDrivingLicenseApplicationDetails(ApplicationID);
                ShowDetails.ShowDialog();
            }
        }

        private void cmsApplications_Opening(object sender, CancelEventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)DvgAllDrivingLicenseApplication.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
              clsLocalDrivingLicenseApplication.FindUserPersonIDByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            // if License Issued so I can Show it 
            bool IsLicenseExist = LocalDrivingLicenseApplication.IsLicenseIssued();
            tmsShowLicense.Enabled = IsLicenseExist;

            tmsHistory.Enabled = IsLicenseExist;


            // just Canceled Or delete The Applications With New Status
            tmsCancelApp.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            tsmDelete.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            int TotalPassedTests = (int)DvgAllDrivingLicenseApplication.CurrentRow.Cells[5].Value;

            tmsIssueDL_FirstTime.Enabled = (TotalPassedTests == 3) && !IsLicenseExist;

            tmsEdit.Enabled = !IsLicenseExist && (LocalDrivingLicenseApplication.ApplicationStatus
                == clsApplication.enApplicationStatus.New && TotalPassedTests == 0);

            SheduleTest.Enabled = !IsLicenseExist;
            // Enabled in Case Whan Status of the Application Is new
            SheduleTest.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);

            if (SheduleTest.Enabled)
            {
                // Disabled All Test In First
                cmsVesionTest.Enabled = false;
                cmsWritingTest.Enabled = false;
                cmsStreetTest.Enabled = false;

                switch (TotalPassedTests)
                {
                    case 0:
                        cmsVesionTest.Enabled = true;
                        break;
                    case 1:
                        cmsWritingTest.Enabled = true;
                        break;
                    case 2:
                        cmsStreetTest.Enabled = true;
                        break;
                    default:
                        SheduleTest.Enabled = false;
                        break;
                }
            }
           
        }

        private void cmsWritingTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseID = Convert.ToInt32(DvgAllDrivingLicenseApplication.SelectedRows[0].Cells[0].Value);
            frmTestsAppointments Test = new frmTestsAppointments(LocalDrivingLicenseID, clsTestType.enTestType.WrittenTest);
            Test.ShowDialog();
            // Refresh Form
            _FillDataInGridView();
            _GetUsersCount();
        }

        private void cmsStreetTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseID = Convert.ToInt32(DvgAllDrivingLicenseApplication.SelectedRows[0].Cells[0].Value);
            frmTestsAppointments Test = new frmTestsAppointments(LocalDrivingLicenseID, clsTestType.enTestType.StreetTest);
            Test.ShowDialog();
            // Refresh Form
            _FillDataInGridView();
            _GetUsersCount();
        }

        private void tmsIssueDL_FirstTime_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseID = Convert.ToInt32(DvgAllDrivingLicenseApplication.SelectedRows[0].Cells[0].Value);
            frmIssueD_L_FirstTime Issue = new frmIssueD_L_FirstTime(LocalDrivingLicenseID);
            Issue.ShowDialog();
            // Refresh Form
            _FillDataInGridView();
            _GetUsersCount();
        }

        private void tmsShowLicense_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)DvgAllDrivingLicenseApplication.CurrentRow.Cells[0].Value;

            int LicenseID = clsLocalDrivingLicenseApplication.FindUserPersonIDByLocalDrivingAppLicenseID(
               LocalDrivingLicenseApplicationID).GetActiveLicenseID();

            if (LicenseID != -1)
            {
                frmShowLicense ShowLicense = new frmShowLicense(LicenseID);
                ShowLicense.ShowDialog();

            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void tmsEdit_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)DvgAllDrivingLicenseApplication.CurrentRow.Cells[0].Value;
            int PersonID = clsPerson.FindUserPersonID((string)DvgAllDrivingLicenseApplication.CurrentRow.Cells[2].Value).PersonID;

            frmAdd_UpdateNewLocalDrivingLicenseApps frm =
                         new frmAdd_UpdateNewLocalDrivingLicenseApps(LocalDrivingLicenseApplicationID,PersonID);
            frm.ShowDialog();
            // Refresh Form
            ManageLocalDrivingLicensesApps_Load(null, null);
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)DvgAllDrivingLicenseApplication.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication LocalDriverLicense = 
                clsLocalDrivingLicenseApplication.FindUserPersonIDByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            if (LocalDriverLicense == null)
            {
                MessageBox.Show("This Application Not Exist!", "Not Exist", MessageBoxButtons.OKCancel,
                         MessageBoxIcon.Warning);
                return;
            }
           
            if (MessageBox.Show("Are You Sure Do You Want  delete This Application?", "Confirm", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question) == DialogResult.OK)
            { 

                if (LocalDriverLicense.delete())
                {
                    MessageBox.Show("This Application Deleted Succesfully.", "Data Saved", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information);
                    // Refresh Form
                    _FillDataInGridView();
                    _GetUsersCount();
                }
                else
                {
                    MessageBox.Show("Could Not delete This Applicatoin, Cause other data depends on it.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tmsCancelApp_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)DvgAllDrivingLicenseApplication.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication.FindUserPersonIDByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID).Cancel();
            // Refresh Form
            ManageLocalDrivingLicensesApps_Load(null, null);
        }

        private void tmsHistory_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LocalLicense 
                =  clsLocalDrivingLicenseApplication.FindUserPersonIDByLocalDrivingAppLicenseID((int)DvgAllDrivingLicenseApplication.CurrentRow.Cells[0].Value);
            int DriverID = clsDriver.FindUserPersonIDByPersonID(LocalLicense.ApplicantPersonID).DriverID;

            frmLicensesHistory licensesHistory = new frmLicensesHistory(DriverID, LocalLicense.ApplicantPersonID);
            licensesHistory.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
