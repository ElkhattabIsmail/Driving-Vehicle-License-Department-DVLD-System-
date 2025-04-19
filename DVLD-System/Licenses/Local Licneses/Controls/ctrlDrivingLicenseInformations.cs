using C19_Project.Licenses;
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

namespace C19_Project.ManageAppsTests.Controls
{
    public partial class ctrlDrivingLicenseInformations : UserControl
    {
        public ctrlDrivingLicenseInformations()
        {
            InitializeComponent();
        }
        private clsLocalDrivingLicenseApplication _LocalLicenseApplication;
        private int _LicenseID =-1;

        private int _LocalDrivingLicenseApplicationID = -1;
        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }


        private void ResetLocalLicenseinfo()
        {
            lblAppliedFor.Text = "[???]";
            lblLocalDrivingLicenseApplicationID.Text = "[???]";
            lblPassedTests.Text = "0";
            LlShowLicenceInfo.Visible = false;
        }
     
        private void ResetApplicationInfo()
        {
            lblApplicationID.Text = "[???]";
            lblStatus.Text = "[???]";
            lblFees.Text = "[$$$]";
            lblType.Text = "[???]";
            lblApplicant.Text = "[?????]";
            lblDate.Text = "[??/??/??]";
            lblStatus.Text = "[??/??/??]";
            lblCreatedByUser.Text = "[???]";
        }

        private void FillDrivingLicenseData()
        {
            lblAppliedFor.Text = _LocalLicenseApplication.LicenseClassInfo.ClassName;
            lblLocalDrivingLicenseApplicationID.Text = _LocalLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblPassedTests.Text = _LocalLicenseApplication.GetPassedTestCount().ToString() + "/3";
        }
        private void _FillApplicationData()
        {
            lblApplicationID.Text = _LocalLicenseApplication.ApplicationID.ToString ();
            lblStatus.Text = _LocalLicenseApplication.StatusText;
            lblFees.Text = _LocalLicenseApplication.PaidFees.ToString ();
            lblType.Text = clsApplicationType.FindUserPersonID(_LocalLicenseApplication.ApplicationTypeID).Title;
            lblApplicant.Text = _LocalLicenseApplication.ApplicantFullName;
            lblDate.Text = _LocalLicenseApplication.ApplicationDate.ToShortDateString();
            lblStatusDate .Text  = _LocalLicenseApplication.LastStatusDate.ToShortDateString();
            lblCreatedByUser.Text = clsUser.FindUserByPersonID( _LocalLicenseApplication.CreatedByUserID).UserName;

        }
        private void _FillDrivingLicenseAndApplicationInfos()
        {
            _LicenseID = _LocalLicenseApplication.GetActiveLicenseID();

            //For show License link.
            LlShowLicenceInfo.Enabled = (_LicenseID != -1);
            FillDrivingLicenseData();
            _FillApplicationData();
            llViewPersonInfo.Enabled = true;
        }
        public void LoadDrivingLicenseByLocalLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            _LocalLicenseApplication = clsLocalDrivingLicenseApplication.FindUserPersonIDByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);
            if (_LocalLicenseApplication == null)
            {
                ResetLocalLicenseinfo();
                MessageBox.Show("No Local Driving License With ID = " + LocalDrivingLicenseApplicationID, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _FillDrivingLicenseAndApplicationInfos();
            }
        }
        public void LoadDrivingLicenseByApplicationID(int ApplicationID)
        {
            _LocalLicenseApplication = clsLocalDrivingLicenseApplication.FindUserPersonIDByApplicationID(ApplicationID);
            if (_LocalLicenseApplication == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + LocalDrivingLicenseApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillDrivingLicenseAndApplicationInfos();
        }
        private void llViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = _LocalLicenseApplication.ApplicantPersonID;
            frmShowPersonDetails personDetails = new frmShowPersonDetails(PersonID);
            personDetails.ShowDialog();
        }

        private void LlShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense frm = new frmShowLicense(_LocalLicenseApplication.GetActiveLicenseID());
            frm.ShowDialog();
        }
    }
}
