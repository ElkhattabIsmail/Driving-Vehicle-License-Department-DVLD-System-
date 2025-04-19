using C19_Project.OtherClasses;
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

namespace C19_Project.NewDrivingLicensesApplication.frmIssueDrivingLicenseFirstTime
{
    public partial class frmIssueD_L_FirstTime : Form
    {
        private int _LocalDrivingLicenseID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicense;
        public frmIssueD_L_FirstTime(int localDrivingLicenseID)
        {
            InitializeComponent();
            _LocalDrivingLicenseID = localDrivingLicenseID;
        }

        private void frmIssueD_L_FirstTime_Load(object sender, EventArgs e)
        {

            txtNotes.Focus();
            _LocalDrivingLicense = clsLocalDrivingLicenseApplication.FindUserPersonIDByLocalDrivingAppLicenseID(_LocalDrivingLicenseID);

            if (_LocalDrivingLicense == null)
            {

                MessageBox.Show("No Local Driving License Application with ID = " + _LocalDrivingLicenseID.ToString(), "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (!_LocalDrivingLicense.PassedAllTests())
            {

                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int LicenseID = _LocalDrivingLicense.GetActiveLicenseID();
            if (LicenseID != -1)
            {
                MessageBox.Show("Person already has License before with License ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlDrivingLicenseInformations1.LoadDrivingLicenseByLocalLicenseApplicationID(_LocalDrivingLicenseID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssueD_L_Click(object sender, EventArgs e)
        {
            int LicenseID = _LocalDrivingLicense.IssueLicenseForTheFirtTime(txtNotes.Text, ClsGlobal.CurrentUser.UserID);

            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + LicenseID.ToString(),
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued !",
                 "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
