using C19_Project.OtherClasses;
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

namespace C19_Project.Applications.InterNationalDrivingLicenseApplication.Controls
{
    public partial class CtrlInternationalLicenseInfo : UserControl
    {
        private int _InternationalLicenseID;
        private clsInternationalLicense _InternationalLicense;
        public CtrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        public int InternationalLicenseID
        {
            get { return _InternationalLicenseID; }
        }

        private void _LoadPersonImage()
        {
            if (_InternationalLicense.DriverInfo.PersonInfo.Gender  == 0)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            string ImagePath = _InternationalLicense.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not FindUserByPersonID this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void LoadInfo(int InternationalLicenseID)
        {
            _InternationalLicenseID = InternationalLicenseID;
            _InternationalLicense = clsInternationalLicense.FindByInternationalLicenseID(_InternationalLicenseID);
            if (_InternationalLicense == null)
            {
                MessageBox.Show("Could not FindUserByPersonID Internationa License ID = " + _InternationalLicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _InternationalLicenseID = -1;
                return;
            }

            lblInternationalLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
            lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            lblLocalLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblFullName.Text = _InternationalLicense.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _InternationalLicense.DriverInfo.PersonInfo.NationalNo;
            lblGender.Text = _InternationalLicense.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = ClsFormat.DateToShort(_InternationalLicense.DriverInfo.PersonInfo.DateOfBirth);

            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblIssueDate.Text = ClsFormat.DateToShort(_InternationalLicense.IssueDate);
            lblExpirationDate.Text = ClsFormat.DateToShort(_InternationalLicense.ExpirationDate);

            _LoadPersonImage();

        }
    }
}
