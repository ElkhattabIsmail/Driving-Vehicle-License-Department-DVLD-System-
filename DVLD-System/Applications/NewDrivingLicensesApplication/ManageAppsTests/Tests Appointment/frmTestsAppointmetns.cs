using C19_Project.Properties;
using DVLD_BuisnessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace C19_Project.ManageAppsTests.TakeTests
{
    public partial class frmTestsAppointments : Form
    {
        private int _LocalDrivingLicenseID = -1;
        private clsTestType.enTestType _TestType = clsTestType.enTestType.VisionTest;

        private DataTable LocalLicenseApplicationsTable;
        public frmTestsAppointments(int LocalDrivingLicenseID , clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _LocalDrivingLicenseID = LocalDrivingLicenseID;
            _TestType = TestType;
        }
        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestType)
            {

                case clsTestType.enTestType.VisionTest:
                    {
                        lblTitle.Text = "Vision Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestType.Image = Resources.Vision_512;
                        break;
                    }

                case clsTestType.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Written Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestType.Image = Resources.Written_Test_512;
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Street Test Appointments";
                        this.Text = lblTitle.Text;
                        pbTestType.Image = Resources.driving_test_512;
                        break;
                    }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this .Close();
        }
        private void _FillAppointmentsData()
        {
            LocalLicenseApplicationsTable = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseID, _TestType);
            DvgAppointments.DataSource = LocalLicenseApplicationsTable;
        }
        private void _AppointmentsCount()
        {
            lblAppointmentsCount.Text = LocalLicenseApplicationsTable.Rows.Count.ToString ();
        }

        private void TestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();
           
            ctrlDrivingLicenseInformations1.LoadDrivingLicenseByLocalLicenseApplicationID(_LocalDrivingLicenseID);

            _FillAppointmentsData();
            _AppointmentsCount();

            Font MyFont = new Font("Calibri", 14, FontStyle.Bold); // 14 is the size
            // Apply the font to the DataGridView's DefaultCellStyle
            DvgAppointments.DefaultCellStyle.Font = MyFont;
            // Optionally, you can also change the column header font size
            DvgAppointments.ColumnHeadersDefaultCellStyle.Font = MyFont;
            if (DvgAppointments.Rows.Count > 0)
            {
                DvgAppointments.Columns[0].HeaderText = "Appointment ID";
                DvgAppointments.Columns[0].Width = 130;

                DvgAppointments.Columns[1].HeaderText = "Appointment Date";
                DvgAppointments.Columns[1].Width = 270;

                DvgAppointments.Columns[2].HeaderText = "Paid Fees";
                DvgAppointments.Columns[2].Width = 150;

                DvgAppointments.Columns[3].HeaderText = "Is Locked";
                DvgAppointments.Columns[3].Width = 110;
            }

        }


        private void button1_Add_Click_1(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LocalLicenseApplication =
                clsLocalDrivingLicenseApplication.FindUserPersonIDByLocalDrivingAppLicenseID(_LocalDrivingLicenseID);

            if (LocalLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment",
                    "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get last Test 
            clsTest LastTest = LocalLicenseApplication.GetLastTestPerTestType(_TestType);
            if (LastTest == null)
            {
                frmScheduleTest frmScheduleTest = new frmScheduleTest(_LocalDrivingLicenseID, _TestType);
                frmScheduleTest.ShowDialog();
                TestAppointments_Load(null, null);
                return;
            }

            //if person already passed the test  cannot retak it.
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake failed test",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest SheduleTest = new frmScheduleTest
                (LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestType);
            SheduleTest.ShowDialog();
            TestAppointments_Load(null, null);

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)DvgAppointments.CurrentRow.Cells[0].Value;

            frmScheduleTest SheduleTest = new frmScheduleTest
                (_LocalDrivingLicenseID, _TestType, TestAppointmentID);

            SheduleTest.ShowDialog();
            // Refresh Form
            TestAppointments_Load(null, null);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)DvgAppointments.CurrentRow.Cells[0].Value;

            if (clsTestAppointment.FindUserPersonID(TestAppointmentID).IsLocked)
            {
                MessageBox.Show("Sorry That Test Appiontment Is Locked!",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmTakeTest TakeTest = new frmTakeTest(_LocalDrivingLicenseID,_TestType );
            TakeTest .ShowDialog();
            // Refresh Form
            TestAppointments_Load(null, null); 
        }
    }
}
