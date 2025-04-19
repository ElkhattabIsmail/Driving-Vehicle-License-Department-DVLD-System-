using C19_Project.Licenses;
using C19_Project.Licenses.International_Licenses;
using C19_Project.OtherClasses;
using DVLD_BuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_BuisnessLayer.clsLicense;

namespace C19_Project.Applications.Replacement_For_Lost_or_Damaged_Local_Licenses
{
    public partial class frmReplaceForDamagedOrLostLicenses : Form
    {
        private int _NewLicneseID = -1;
        
        private clsLicense.enIssueReason _IssueReason = enIssueReason.DamagedReplacement;

        public frmReplaceForDamagedOrLostLicenses()
        {
            InitializeComponent();
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            _IssueReason = enIssueReason.DamagedReplacement;
            lblTitle.Text = "Replacement for Damaged License";
            this.Text = lblTitle.Text;
            int ApplicationType = (int)clsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
            lblApplicationFees.Text = clsApplicationType.FindUserPersonID(ApplicationType).Fees.ToString();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            _IssueReason = enIssueReason.LostReplacement;
            lblTitle.Text = "Replacement for Lost License";
            this.Text = lblTitle.Text;
            int ApplicationType = (int)clsApplication.enApplicationType.ReplaceLostDrivingLicense;
            lblApplicationFees.Text = clsApplicationType.FindUserPersonID(ApplicationType).Fees.ToString();
        }

        private void ctrlDriverLicenseWithFilter1_OnLicenseFounded(int obj)
        {
            _NewLicneseID = obj;

            lblOldLicenseID.Text = _NewLicneseID.ToString();
            bool LicneseFounded = (_NewLicneseID != -1);

            llShowLicenseHistory.Enabled = LicneseFounded;

            if (_NewLicneseID == -1)
            {
                return;
            }

            if (!ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }
            if (ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is Expired, You Must Renew This license In First Place."
                   , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
            }
            btnIssueReplacement.Enabled = true;
        }

        private void frmReplaceForDamagedOrLostLicenses_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = ClsFormat.DateToShort(DateTime.Now);
            lblCreatedByUser.Text = ClsGlobal.CurrentUser.UserName;

            rbDamagedLicense.Checked = true;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            clsLicense NewLicense =
               ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.Replace(_IssueReason,
               ClsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Issue a replacemnet for this  License", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicneseID = NewLicense.LicenseID;

            lblRreplacedLicenseID.Text = _NewLicneseID.ToString();
            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicneseID.ToString(),
                "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ctrlDriverLicenseWithFilter1.LoadLicenseInfo(_NewLicneseID);

            btnIssueReplacement.Enabled = false;
            llShowLicenseInfo.Enabled = true;
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense showLicense = new frmShowLicense(_NewLicneseID);
            showLicense.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory licensesHistory = new frmLicensesHistory(
                ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.DriverID,
                ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            licensesHistory.ShowDialog();
        }
    }
}
