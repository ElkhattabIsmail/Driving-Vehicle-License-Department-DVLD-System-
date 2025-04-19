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

namespace C19_Project.ManageAppsTests.TakeTests
{
    public partial class frmTakeTest : Form
    {
        private int _LocalDrivingLicenseID = -1;
        
        private clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;
        public frmTakeTest(int LDLID , clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _TestType = TestType;
            _LocalDrivingLicenseID = LDLID;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlSchuduledTest1.TestTypeID = _TestType;
            ctrlSchuduledTest1.LoadAppintmentTestInfoByLocalDrivingLicenseID(_LocalDrivingLicenseID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            int TestAppointmentId = 
                clsTestAppointment.GetLastTestAppointment(_LocalDrivingLicenseID, ctrlSchuduledTest1.TestTypeID).TestAppointmentID;

            clsTest Test = new clsTest();
            Test.TestAppointmentID = TestAppointmentId;
            Test.TestResult = rbPass.Checked;
            Test.Notes = txtNotes.Text;
            Test.CreatedByUserID = ClsGlobal.CurrentUser.UserID;

            if (Test.Save())
            {
                MessageBox.Show("Data LocalSave Succssfully",
                    "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Wrong Data UnSave!",
                    "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
