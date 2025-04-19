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

namespace C19_Project.Applications.DetainAndReleaseLicenses
{
    public partial class frmDetainLicenses : Form
    {

        private int _DetainID = -1;
        private int _SelectedLicenseID = -1;
        public frmDetainLicenses()
        {
            InitializeComponent();
        }

        private void ctrlDriverLicenseWithFilter1_OnLicenseFounded(int obj)
        {
            int LicenseID = obj;

            bool LicneseFounded = (LicenseID != -1);
            llShowLicenseHistory.Enabled = LicneseFounded;
            txtFineFees.Enabled = LicneseFounded;

            if (!LicneseFounded)
            {
                lblLicenseID.Text = "[???]";
                return;
            }


            _SelectedLicenseID = LicenseID;
            lblLicenseID.Text = LicenseID.ToString();

            // Check if License Already Detainded
            if (ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                txtFineFees.Enabled = false;
                MessageBox.Show("This License Is Already Detained With DetainID = " + 
                    ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainID +
                    ", Choose Another Licnese Please!", "License Detained",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtFineFees.Focus();
            btnDetain.Enabled = true;
        }

        private void frmDetainLicenses_Activated(object sender, EventArgs e)
        {
            ctrlDriverLicenseWithFilter1.FocusOnFilterText();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text))
            {
                MessageBox.Show("Fine Field Cannot Be Empty, Enter The Fine Value First.", "Empty Field",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure Do you want to detain this license?", "Confirm", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
           

            _DetainID = ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.Detain
                (Convert.ToSingle(txtFineFees.Text), ClsGlobal.CurrentUser.UserID);

            if (_DetainID == -1)
            {
                MessageBox.Show("We Failed to Detain this License!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            llShowLicenseInfo.Enabled = true;
            lblDetainID.Text = _DetainID.ToString();
            MessageBox.Show("License Detained Successfully with ID = " + _DetainID.ToString(), "License Issued",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtFineFees.Text = string.Empty;
            txtFineFees.Enabled = false;
            btnDetain.Enabled = false;
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicense showLicense = new frmShowLicense(_SelectedLicenseID);
            showLicense.ShowDialog();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory licensesHistory = new frmLicensesHistory(ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.DriverID,
            ctrlDriverLicenseWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            licensesHistory.ShowDialog();
        }
        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow just Digit and Controls Button To Click
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFineFees.Text))
            {
                e.Cancel = false;
                epFineValue.SetError(txtFineFees, "Fine Value Cannot Be Empty!");
            }
            else
            {
                //e.Cancel = false;
                epFineValue.SetError(txtFineFees, null);
            }
        }

        private void frmDetainLicenses_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = ClsFormat.DateToShort(DateTime.Now);
            lblCreatedByUser.Text = ClsGlobal.CurrentUser.UserName;
        }
    }
}
