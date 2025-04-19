using C19_Project.Properties;
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

namespace C19_Project.ManageAppsTests.Controls
{
    public partial class CtrlSchuduledTest : UserControl
    {
        private clsLocalDrivingLicenseApplication _LocalLicenseApplication;
        private clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;

        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestType;
            }
            set
            {
                _TestType = value;

                switch (_TestType)
                {

                    case clsTestType.enTestType.VisionTest:
                        {
                            gbTestType.Text = "Vision Test";
                            pbTestTypeImage.Image = Resources.Vision_512;
                            break;
                        }

                    case clsTestType.enTestType.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            pbTestTypeImage.Image = Resources.Written_Test_512;
                            break;
                        }
                    case clsTestType.enTestType.StreetTest:
                        {
                            gbTestType.Text = "Street Test";
                            pbTestTypeImage.Image = Resources.driving_test_512;
                            break;
                        }
                }
            }
        }
        public CtrlSchuduledTest()
        {
            InitializeComponent();
        }
        
        private void _FillTestAppointmentInfo()
        {
            lblLocalDrivingLicenseAppID.Text = _LocalLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = clsLicenseClass.FindUserPersonID (_LocalLicenseApplication.LicenseClassID).ClassName ;
            lblFullName.Text = _LocalLicenseApplication.ApplicantFullName;
            lblTrial.Text = 
                clsLocalDrivingLicenseApplication.TotalTrialsPerTest(_LocalLicenseApplication.LocalDrivingLicenseApplicationID
                , _TestType).ToString();
            dtpTestDate.Text = _LocalLicenseApplication.ApplicationDate.ToShortDateString();
            lblFees.Text = clsTestType.FindUserPersonID(_TestType).Fees.ToString();
            
        }

        public void LoadAppintmentTestInfoByLocalDrivingLicenseID(int _LocalDrivingLicenseApplicationID)
        {
            _LocalLicenseApplication = clsLocalDrivingLicenseApplication.FindUserPersonIDByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalLicenseApplication != null)
            {
                _FillTestAppointmentInfo();
            }
            else
            {
                MessageBox.Show("Not Local Driving License ID = "+ _LocalDrivingLicenseApplicationID+ " !",
                  "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
