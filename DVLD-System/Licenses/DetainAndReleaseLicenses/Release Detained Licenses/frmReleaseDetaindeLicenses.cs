using C19_Project.Applications.InterNationalDrivingLicenseApplication.Controls;
using C19_Project.Licenses.International_Licenses;
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

namespace C19_Project.Licenses.DetainAndReleaseLicenses.Release_Detained_Licenses
{
    public partial class frmReleaseDetaindeLicenses : Form
    {
        private int _CurrentLicenseID = -1;
        public frmReleaseDetaindeLicenses()
        {
            InitializeComponent();
        }
        public frmReleaseDetaindeLicenses(int LicenseID)
        {
            InitializeComponent();
            _CurrentLicenseID = LicenseID;
            ctrlDriverLicenseWithFilter1.LoadLicenseInfo(_CurrentLicenseID);
            ctrlDriverLicenseWithFilter1.FilterEnabled = false;
        }

        private void ctrlDriverLicenseWithFilter1_OnLicenseFounded(int obj)
        {
            _CurrentLicenseID = obj;
            bool LicneseFounded = (_CurrentLicenseID != -1);
            llShowLicenseHistory.Enabled = LicneseFounded;
            lblLicenseID.Text = _CurrentLicenseID != -1 ? _CurrentLicenseID.ToString() : "[???]";

            if (!LicneseFounded)
            {
                return;
            }
            // Check if License Already Detainded
            if (!ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("This License Is Not Detained, Choose Another Licnese Please!", "Not Allowd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            lblApplicationFees.Text = clsApplicationType.FindUserPersonID(
                (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();

            lblCreatedByUser.Text = ClsGlobal.CurrentUser.UserName;

            lblDetainID.Text = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            lblCreatedByUser.Text = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.DetainedInfo.CreatedByUserInfo.UserName;
            lblDetainDate.Text = ClsFormat.DateToShort ( ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainDate);
            lblFineFees.Text = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString();


            btnRelease.Enabled = true;


        }


        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you You Want to release this detained  license?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = -1;

            // Create a new Application from Type Release Detain License
            if (!ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(ClsGlobal.CurrentUser.UserID, ref ApplicationID))
            {
                MessageBox.Show("Failed to release this License", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            llShowLicenseInfo.Enabled = true;
            MessageBox.Show("License released Successfully With Application ID = " + ApplicationID,
                "Data Saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblApplicationID.Text = ApplicationID.ToString();
            btnRelease.Enabled = false;
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense showLicense = new frmShowLicense(_CurrentLicenseID);
            showLicense.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory licensesHistory = new frmLicensesHistory(ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.DriverID,
          ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            licensesHistory.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
