using C19_Project.Properties;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLD_BuisnessLayer;

namespace C19_Project.Licenses.Controls
{
    public partial class CtrlDriverLicenseInfo : UserControl
    {
        private int _DriverLicenseID = -1;
        private clsLicense _DriverLicense;
        public CtrlDriverLicenseInfo()
        {
            InitializeComponent();
        }
        private void _LoadPersonImage()
        {
            if (_DriverLicense.DriverInfo.PersonInfo.Gender == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _DriverLicense.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not FindUserByPersonID this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void _FillDriverLicenseInfo()
        {
            lblLicenseID.Text = _DriverLicense.LicenseID.ToString();
            lblIsActive.Text = _DriverLicense.IsActive ? "Yes" : "No";
            lblIsDetained.Text = _DriverLicense.IsDetained ? "Yes" : "No";
            lblClass.Text = _DriverLicense.LicenseClassIfo.ClassName;
            lblFullName.Text = _DriverLicense.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _DriverLicense.DriverInfo.PersonInfo.NationalNo;
            lblGender.Text = _DriverLicense.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = _DriverLicense.DriverInfo.PersonInfo.DateOfBirth.ToString("dd/MMM/yyyy");
            lblDriverID.Text = _DriverLicense.DriverID.ToString();
            lblIssueDate.Text = _DriverLicense.IssueDate.ToString("dd/MMM/yyyy");
            lblExpirationDate.Text = _DriverLicense.ExpirationDate.ToString("dd/MMM/yyyy");
            lblIssueReason.Text = _DriverLicense.IssueReasonText;
            lblNotes.Text = _DriverLicense.Notes == "" ? "No Notes" : _DriverLicense.Notes;
            _LoadPersonImage();
        }
     
        public void LoadDriverLicenseInfo(int LicenseID)
        {
            _DriverLicenseID = LicenseID;
            _DriverLicense = clsLicense.FindUserPersonID(_DriverLicenseID);
            if (_DriverLicense == null)
            {
                MessageBox.Show("Could not FindUserByPersonID License ID = " + _DriverLicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _DriverLicenseID = -1;
                return;
            }
            _FillDriverLicenseInfo();
        }



    }
}
