

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;

namespace C19_Project.Users
{
    public partial class frmAdd_Update_User : Form
    {
        private enum _enMode { enAddnew = 0 ,enUpdate = 1};
        private _enMode _Mode;
        private int _UserID = -1;

        private clsUser _User;
        public frmAdd_Update_User()
        {
            InitializeComponent();
            _Mode = _enMode.enAddnew;
            ctrlFilterPerson1.FilterFocus();
        }
        public frmAdd_Update_User(int UserID)
        {
            InitializeComponent();
            _Mode = _enMode.enUpdate;
            _UserID = UserID;
        }
        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values

            if (_Mode == _enMode.enAddnew)
            {
                lblTitle.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUser();

                ctrlFilterPerson1.FilterFocus();
            }
            else
            {
                lblTitle.Text = "Update User";
                this.Text = "Update User";
                btnSave.Enabled = true;
            }
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPass.Text = "";
            chbIsActive.Checked = true;
        }
        private void _LoadData()
        {
            _User = clsUser.FindUserByID(_UserID);
            ctrlFilterPerson1.FilterEnabled = false;

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the User was not found
            lblUserID.Text = _UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = "";
            txtConfirmPass.Text = "";
            chbIsActive.Checked = _User.IsActive;
            ctrlFilterPerson1.LoadPersonInfo(_User.PersonID);
        }
        private void frmAdd_Update_User_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == _enMode.enUpdate)
                _LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == _enMode.enUpdate)
            {
                btnSave.Enabled = true;
                tcUserInfo.SelectTab(1);
                return;
            }
            if (ctrlFilterPerson1.PersonID != -1)
            {
                if (clsUser.isUserExistForPersonID(ctrlFilterPerson1.PersonID))
                {
                    MessageBox.Show("Person With ID = " + ctrlFilterPerson1.PersonID + " Already a User!", "Is a User",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    btnSave.Enabled = true;

                    tcUserInfo.SelectTab(1);
                    //tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlFilterPerson1.FilterFocus();
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            // All fields must be filled in.
            if (txtUserName.Text == string.Empty ||txtPassword.Text == string.Empty || txtConfirmPass.Text == string.Empty)
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are Empty !",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // UserName Must Be Unique.
            if (clsUser.isUserExist(txtUserName.Text))
            {
                if (_Mode == _enMode.enUpdate)
                {

                }
                // InCase of Adding a New User .
                else
                {
                    MessageBox.Show("This Username is used by another user", "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                  
            }
            // Two passwords must match each other.
            if (txtConfirmPass.Text != txtPassword.Text)
            {
                MessageBox.Show("Confirmation Password does not match Password!","Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // full the object
            _User.PersonID = ctrlFilterPerson1.PersonID;
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = chbIsActive.Checked;

            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                //change form mode to update.
                _Mode = _enMode.enUpdate;
                MessageBox.Show("Data Saved Successfully", "LocalSave", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                lblTitle.Text = "Update User";
                this.Text = "Update User";
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void ctrlFilterPerson1_OnPersonSelected(int obj)
        {
            btnNext.Enabled = obj != -1;
        }

    }
}
