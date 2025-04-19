using C19_Project.ManageAppsTests.Controls;
using C19_Project.People.Controls;
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

namespace C19_Project.Applications.InterNationalDrivingLicenseApplication.Controls
{
    public partial class CtrlDriverLicenseWithFilter : UserControl
    {
        private int _LicenseID = -1;
        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicense SelectedLicenseInfo
        {
            get { return ctrlDriverLicenseInfo1.LicenseInfo; }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        // Define a custom event handler delegate with parameters
        public event Action<int> OnLicenseFounded;
        // Create a protected method to raise the event with a parameter
        protected virtual void LicenseSelected(int LicneseID)
        {
            Action<int> handler = OnLicenseFounded;
            if (handler != null)
            {
                handler(LicneseID); // Raise the event with the parameter
            }
        }

        public CtrlDriverLicenseWithFilter()
        {
            InitializeComponent();
        }

        private void btnFindUserPersonID_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text))
                return;

            _LicenseID = Convert.ToInt32(txtLicenseID.Text);

            LoadLicenseInfo(_LicenseID);
          
        }
        public void LoadLicenseInfo(int  licenseID)
        {
            txtLicenseID.Text = licenseID.ToString();
            ctrlDriverLicenseInfo1.LoadDrivingLicenseData(licenseID);
            _LicenseID = ctrlDriverLicenseInfo1.LicenseID;
            if (OnLicenseFounded != null && FilterEnabled)
            {
                // Raise the event with a parameter
                OnLicenseFounded(_LicenseID);
            }
        }
        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
        public void FocusOnFilterText()
        {
            txtLicenseID.Focus();
        }
    }
}
