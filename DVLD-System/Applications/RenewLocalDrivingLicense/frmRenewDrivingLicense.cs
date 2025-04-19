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

namespace C19_Project.Applications.RenewLocalDrivingLicense
{
    public partial class frmRenewDrivingLicense : Form
    {
        private int _NewLicneseID = -1;
        public frmRenewDrivingLicense()
        {
            InitializeComponent();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense showLicense  = new frmShowLicense(_NewLicneseID);
            showLicense.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlDriverLicenseWithFilter1_OnLicenseFounded(int obj)
        {
            _NewLicneseID = obj;

            bool LicneseFounded = (_NewLicneseID != -1);
            llShowLicenseHistory.Enabled = LicneseFounded;

            if (!LicneseFounded)
            {
                // Reset Values
                btnRenewLicense.Enabled = false;
                lblOldLicenseID.Text = "[???]";
                lblLicenseFees.Text = "[???]";
                lblTotalFees.Text = "[???]";
                return;
            }

            lblLicenseFees.Text = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.LicenseClassIfo.ClassFees.ToString();
            lblOldLicenseID.Text = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.LicenseID.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();
            lblExpirationDate.Text =  
                ClsFormat.DateToShort(DateTime.Now.AddYears(
                    ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.LicenseClassIfo.DefaultValidityLength)).ToString();

            bool LicenseIsExpired = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.IsLicenseExpired();
            btnRenewLicense.Enabled = LicenseIsExpired;

            // Check if The Licnese is Active or Expired
            if (!ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.IsActive)
            {
                btnRenewLicense.Enabled = false;
                MessageBox.Show("Selected License Is Not Active, To Renew It.",
                         "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!LicenseIsExpired)
            {
                MessageBox.Show("Selected License Is Not Expired Yet To Renew it.\nIt will Expired On : " +
                    ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.ExpirationDate,
                         "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int DriverID = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.DriverID;
            int PersonID = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            frmLicensesHistory licensesHistory = new frmLicensesHistory(DriverID, PersonID);
            licensesHistory.ShowDialog();
        }

        private void frmRenewDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseWithFilter1.FocusOnFilterText();

            lblApplicationDate.Text = ClsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = lblApplicationDate.Text;
            int ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            lblApplicationFees.Text = clsApplicationType.FindUserPersonID(ApplicationTypeID).Fees.ToString();
            lblCreatedByUser.Text = ClsGlobal.CurrentUser.UserName;
       
            btnRenewLicense.Enabled = false;
        }

        private void btnRenewLicense_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew this license?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            clsLicense NewLicense =  ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.RenewLicense
                (txtNotes.Text , ClsGlobal.CurrentUser.UserID);
            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblApplicationID.Text = NewLicense.ApplicationID.ToString();
            _NewLicneseID = NewLicense.LicenseID;
            lblRenewedLicenseID.Text = _NewLicneseID.ToString();

            // Update The License Filter info
            ctrlDriverLicenseWithFilter1.LoadLicenseInfo(_NewLicneseID);
            

            MessageBox.Show("Licensed Renewed Successfully with ID=" + _NewLicneseID.ToString(),
                "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            frmRenewDrivingLicense_Load(null, null);
            llShowLicenseInfo.Enabled = true;
        }
    }
}
