
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

namespace C19_Project.ManageAppsTests.TakeTests
{
    public partial class frmScheduleTest : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private int _AppointmentID = -1;
        public frmScheduleTest(int LDL_ApplicationID, clsTestType.enTestType TestTypeID,
            int AppointmentID = -1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LDL_ApplicationID;
            _TestTypeID = TestTypeID;
            _AppointmentID = AppointmentID;
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _TestTypeID;
            ctrlScheduleTest1.LoadInformations(_LocalDrivingLicenseApplicationID, _AppointmentID);
        }
    }
}
