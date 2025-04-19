using C19_Project.Properties;
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

namespace C19_Project.Applications.InterNationalDrivingLicenseApplication.Controls
{
    public partial class CtrlDriverLicenseInfo : UserControl
    {
        private int _LicenseID = -1;
        public clsLicense _License;
        public int LicenseID
        {
            get { return _LicenseID; }
        }
        public clsLicense LicenseInfo
        { 
            get { return _License; } 
        }
        public CtrlDriverLicenseInfo()
        {
            InitializeComponent();
        }
        private void _HandlePersonImage()
        {
            if (_License.DriverInfo.PersonInfo.ImagePath == "")
            {
                // Person With No Image
                pbPersonImage.Image  = 
                    _License.DriverInfo.PersonInfo.Gender == 0 ? pbPersonImage.Image = 
                    Resources.Male_512 : pbPersonImage.Image = Resources.Female_512;
                return;
            }
            // Person Has A Picture
            pbPersonImage.Load(_License.DriverInfo.PersonInfo.ImagePath) ;
        }
        private void _FillLicenseData()
        {
            _LicenseID = _License.LicenseID;
            lblLicenseID.Text = _License.LicenseID.ToString();
            lblClass.Text = _License.LicenseClassIfo.ClassName;
            lblDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = _License.DriverID.ToString();
            lblFullName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblGender.Text = _License.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female";
            lblIssueReason.Text = _License.IssueReasonText;
            lblIssueDate.Text = _License.IssueDate.ToShortDateString();
            lblExpirationDate.Text = _License.ExpirationDate.ToShortDateString();
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo.ToString();
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblIsDetained.Text = _License.IsDetained  ? "Yes" : "No";
            lblNotes.Text = _License.Notes != "" ? _License.Notes : "No Notes";
            _HandlePersonImage();
        }
        private void ResetDrivngLicenseData()
        {
            lblLicenseID.Text = "[????]";
            lblClass.Text = "[???]";
            lblDateOfBirth.Text = "[????]";
            lblDriverID.Text = "[????]";
            lblFullName.Text = "[????]";
            lblGender.Text = "[????]";
            lblIssueReason.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblExpirationDate.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblIsDetained.Text = "[????]";
            lblNotes.Text = "[????]";
            pbPersonImage.Image = Resources.Male_512;
        }
        public void LoadDrivingLicenseData(int LicenseID)
        {
            _License = clsLicense.FindUserPersonID(LicenseID);

            if (_License == null)
            {
                MessageBox.Show("No License Exist With ID = " + LicenseID,
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                ResetDrivngLicenseData();
                return;
            }
            _FillLicenseData();
        }
    }
}
