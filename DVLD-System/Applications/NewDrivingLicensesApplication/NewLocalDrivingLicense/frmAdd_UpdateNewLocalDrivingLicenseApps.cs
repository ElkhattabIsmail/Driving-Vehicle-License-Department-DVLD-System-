using C19_Project.OtherClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BuisnessLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

//1 - New 2 - Cancelled 3 - Completed

namespace C19_Project.NewDrivingLicensesApplication.NewLocalDrivingLicense
{
    public partial class frmAdd_UpdateNewLocalDrivingLicenseApps : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;


        public frmAdd_UpdateNewLocalDrivingLicenseApps()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAdd_UpdateNewLocalDrivingLicenseApps(int LocalDrivingLicenseApplicationID ,int PersonID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _SelectedPersonID = PersonID;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];
                return;
            }


            //incase of add new mode.
            if (ctrlFilterPerson1.PersonID != -1)
            {

                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
                tcApplicationInfo.SelectedTab = tcApplicationInfo.TabPages["tpApplicationInfo"];

            }

            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlFilterPerson1.FilterFocus();
            }
        }

        private void _FillLicensesClassesNamesintoComboBox()
        {
            DataTable Countries = clsLicenseClass.GetAllLicenseClasses();
            foreach (DataRow Row in Countries.Rows)
            {
                cbLicenseClasses.Items.Add(Row["ClassName"]);
            }
        }
        private void _ResetDefualtValues()
        {
            _FillLicensesClassesNamesintoComboBox();


            if (_Mode == enMode.AddNew)
            {

                lblTitle.Text = "New Local Driving License Application";
                this.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                ctrlFilterPerson1.FilterFocus();
                tpApplicationInfo.Enabled = false;

                cbLicenseClasses.SelectedIndex = 2;
                lblFees.Text = clsApplicationType.FindUserPersonID((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                lblDate.Text = DateTime.Now.ToShortDateString();
                lblUserName.Text = ClsGlobal.CurrentUser.UserName;
            }
            else
            {
                lblTitle.Text = "Update Local Driving License Application";
                this.Text = "Update Local Driving License Application";

                tpApplicationInfo.Enabled = true;
                btnSave.Enabled = true;

            }

        }
        private void _LoadData()
        {

            ctrlFilterPerson1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindUserPersonIDByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ctrlFilterPerson1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lblDL_ID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToString("dd/MMM/yyyy");
            cbLicenseClasses.SelectedIndex = cbLicenseClasses.FindString(clsLicenseClass.FindUserPersonID(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            lblFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblUserName.Text = clsUser.FindUserByPersonID(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;

        }
        private void frmNewLocalDrivingLicenseApps_Load(object sender, EventArgs e)
        {

            _ResetDefualtValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            string ClassName = cbLicenseClasses.Text;
            int LicenseClassID = clsLicenseClass.FindUserPersonID (ClassName).LicenseClassID;

            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass
                (_SelectedPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);


            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the" +
                    " selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClasses.Focus();
                return;
            }

            if (clsLicense.IsLicenseExistByPersonID(_SelectedPersonID, LicenseClassID))
            {
                MessageBox.Show("The Person Already Have A Driving License With the Same License Class Name, Please " +
                    "Choose A Diferent License Class!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            byte MinAllowedAge = clsLicenseClass.FindUserPersonID(LicenseClassID).MinimumAllowedAge;

            if (MinAllowedAge > ( DateTime.Now.Year  - clsPerson.FindUserPersonID(_SelectedPersonID).DateOfBirth.Year ))
            {
                MessageBox.Show($"Person is not allowed for this Driving License Class, it requires a {MinAllowedAge}" +
                    $" years old and above", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlFilterPerson1.PersonID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = ClsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;


            if (_LocalDrivingLicenseApplication.LocalSave())
            {
                lblDL_ID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ctrlFilterPerson1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }
    }
}
