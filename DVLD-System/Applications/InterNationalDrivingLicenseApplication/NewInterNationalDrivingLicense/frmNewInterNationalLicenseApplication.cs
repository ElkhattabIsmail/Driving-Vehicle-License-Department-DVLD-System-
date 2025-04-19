using C19_Project.Licenses.International_Licenses;
using C19_Project.OtherClasses;
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C19_Project.Applications.InterNationalDrivingLicenseApplication.NewInterNationalDrivingLicense
{
    public partial class frmNewInterNationalLicenseApplication : Form
    {
        private int _LicenseID = -1;
        private int _IntenationalLicenseID = -1;
        public frmNewInterNationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIssueD_L_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm",
              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            // Add A new international License
            clsInternationalLicense InternationalLicense = new clsInternationalLicense();

            InternationalLicense.ApplicantPersonID = ctrlFilterDrivingLicenses1.SelectedLicenseInfo.DriverInfo.PersonInfo.PersonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            // ApplicationStatus = 1 = new or 2 = canceled or 3 = complete ;
            InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = clsApplicationType.FindUserPersonID((int)clsApplication.enApplicationType.NewInternationalLicense).Fees;
            InternationalLicense.CreatedByUserID = ClsGlobal.CurrentUser.UserID;

            InternationalLicense.DriverID = ctrlFilterDrivingLicenses1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ctrlFilterDrivingLicenses1.SelectedLicenseInfo.LicenseID;
            InternationalLicense.IsActive = true;
            InternationalLicense.CreatedByUserID = ClsGlobal.CurrentUser.UserID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);

            if (InternationalLicense.Save())
            {
                _IntenationalLicenseID = InternationalLicense.InternationalLicenseID;
                lblInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
                lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
                LlShowLicneseInfo.Enabled = true;
                MessageBox.Show("License Added Succesfully With ID = "+ InternationalLicense.InternationalLicenseID + ".",
                       "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Data Not Saved !",
                       "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlFilterDrivingLicenses1_OnLicenseFounded(int obj)
        {
            _LicenseID = obj;
            lblLocalLicenseID.Text = _LicenseID == -1 ? "[???]" : _LicenseID.ToString();

            if (_LicenseID == -1)
            {
                return;
            }
            llLicensesHistory.Enabled = (_LicenseID != -1);
            if (ctrlFilterDrivingLicenses1.SelectedLicenseInfo.LicenseClass != 3)
            {
                MessageBox.Show("Selected License should be Class 3 Only To Issue This License.", "Not allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Driver Already Take This License
            if (clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ctrlFilterDrivingLicenses1.SelectedLicenseInfo.DriverID) != -1)
            {
                MessageBox.Show("This driver has already obtained this license in the past..",
                   "Have A License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // The License Should be Active !
            if (!ctrlFilterDrivingLicenses1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("License With ID = " + _LicenseID + " Is Not Active!",
                         "Not Active", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Here Check If the Licnese is Expired
            if (ctrlFilterDrivingLicenses1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("License With ID = " + _LicenseID +
                    " Is Expired You Must Renew it To Take International License!",
                         "Licnense is Expired", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnIssueInterNationalLicense.Enabled = true;
            
        }

        private void frmNewInterNationalLicenseApplication_Load(object sender, EventArgs e)
        {
            string CurrentDateText = ClsFormat.DateToShort(DateTime.Now);
            lblApplicationDate.Text = CurrentDateText;
            lblIssueDate.Text = CurrentDateText;
            DateTime CurrentDateTime = Convert.ToDateTime( CurrentDateText);
            lblExpirationDate.Text = ClsFormat.DateToShort(CurrentDateTime.AddYears(1));
            lblFees.Text = clsApplicationType.FindUserPersonID(
                (int)clsApplication.enApplicationType.NewInternationalLicense).Fees.ToString();
            lblCreatedByUser.Text = ClsGlobal.CurrentUser.UserName;

        }

        private void LlShowLicneseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInterNationalLicenseInfo ShowLicenseInfo =
                new frmShowInterNationalLicenseInfo(_IntenationalLicenseID);
            ShowLicenseInfo.ShowDialog();
        }

        private void llLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int DriverID = ctrlFilterDrivingLicenses1.SelectedLicenseInfo.DriverID;
            int PersonID = ctrlFilterDrivingLicenses1.SelectedLicenseInfo.DriverInfo.PersonID;

            frmLicensesHistory licensesHistory = new frmLicensesHistory(DriverID, PersonID);
            licensesHistory.ShowDialog();
        }
    }
}
