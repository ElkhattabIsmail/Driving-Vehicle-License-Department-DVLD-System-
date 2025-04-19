using C19_Project.Applications.DetainAndReleaseLicenses;
using C19_Project.Applications.InterNationalDrivingLicenseApplication.NewInterNationalDrivingLicense;
using C19_Project.Applications.RenewLocalDrivingLicense;
using C19_Project.Applications.Replacement_For_Lost_or_Damaged_Local_Licenses;
using C19_Project.ApplicationTypes;
using C19_Project.Drivers;
using C19_Project.Licenses.DetainAndReleaseLicenses.Release_Detained_Licenses;
using C19_Project.LoginForm;
using C19_Project.ManageAppsTests;
using C19_Project.NewDrivingLicensesApplication.NewLocalDrivingLicense;
using C19_Project.OtherClasses;
using C19_Project.People;
using C19_Project.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C19_Project
{
    public partial class frmMain : Form
    {
        private frmLogin _frmLogin;

        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers MU = new frmManageUsers();
            MU.ShowDialog();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople frmPPl = new frmManagePeople();
            frmPPl.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsGlobal.CurrentUser = null;
            _frmLogin.Show();
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            //lblLoggedInUser.Text = "LoggedIn User: " + clsGlobal.CurrentUser.UserName;
            this.Refresh();
        }

        private void userInformationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmUserInfos UI = new frmUserInfos(ClsGlobal.CurrentUser.UserID);
            UI.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmCp = new frmChangePassword(ClsGlobal.CurrentUser.UserID);
            frmCp.ShowDialog();
        }

        private void manageApplicationsTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageAppsTypes frmManageApps = new frmManageAppsTypes();
            frmManageApps.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frmTestes = new frmManageTestTypes();
            frmTestes.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_UpdateNewLocalDrivingLicenseApps frmLDL = new frmAdd_UpdateNewLocalDrivingLicenseApps();
            frmLDL.ShowDialog();
        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicensesApps frmLocal = new frmManageLocalDrivingLicensesApps();
            frmLocal.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers frmDriversList = new frmListDrivers();
            frmDriversList.ShowDialog();
        }

        private void interNationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInterNationalLicenseApplication NewInternationalLicense = new frmNewInterNationalLicenseApplication();
            NewInternationalLicense.ShowDialog();
        }

        private void interNationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInternationalLicenses frminternationalLicenses = new frmManageInternationalLicenses();
            frminternationalLicenses.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewDrivingLicense Renew = new frmRenewDrivingLicense();
            Renew.ShowDialog();
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MsMainMenue.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            MsMainMenue.AutoSize = true;
            MsMainMenue.Dock = DockStyle.Right;
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MsMainMenue.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            MsMainMenue.AutoSize = true;
            MsMainMenue.Dock = DockStyle.Left;
        }

        private void topToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MsMainMenue.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            MsMainMenue.AutoSize = false;
            MsMainMenue.Dock = DockStyle.Top;
        }

        private void bottomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MsMainMenue.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            MsMainMenue.AutoSize = false;
            MsMainMenue.Dock = DockStyle.Bottom;
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceForDamagedOrLostLicenses ReplaceForm = new frmReplaceForDamagedOrLostLicenses ();
            ReplaceForm.ShowDialog ();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicensesApps ManageLocalApplications = new frmManageLocalDrivingLicensesApps ();
            ManageLocalApplications.ShowDialog();
        }

        private void manageDetainLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListofDetainLicenses frmDetained = new frmListofDetainLicenses ();
            frmDetained.ShowDialog ();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicenses Detain = new frmDetainLicenses ();
            Detain.ShowDialog();
        }

        private void releaseLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetaindeLicenses Release = new frmReleaseDetaindeLicenses();
            Release.ShowDialog();
        }

        private void ReleaseDetaindeLicenses_Click(object sender, EventArgs e)
        {
            frmReleaseDetaindeLicenses Release = new frmReleaseDetaindeLicenses();
            Release.ShowDialog();
        }
    }
}
