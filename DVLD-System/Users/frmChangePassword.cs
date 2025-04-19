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
using DVLD_BuisnessLayer;
using static System.Net.Mime.MediaTypeNames;

namespace C19_Project.Users
{
    public partial class frmChangePassword : Form
    {
        private int _UserID;
        private clsUser _User;

        public frmChangePassword(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        private void _ResetDefualtValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            _User = clsUser.FindUserByPersonID(_UserID);

            if (_User == null)
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Could not FindUserByPersonID User with id = " + _UserID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;

            }
            ctrlUserCard1.LoadUserInfos(_UserID);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if ( txtCurrentPassword.Text != _User.Password )
            {
                MessageBox.Show("Current password is wrong Enter The Right Password Please!",
                    "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                MessageBox.Show("New Password Cannot be blanc!",
                    "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtConfirmPassword.Text != txtNewPassword.Text )
            {
                MessageBox.Show("Password Confirmation does not match New Password!",
               "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNewPassword.Text == txtCurrentPassword.Text)
            {
                MessageBox.Show("New Password and Current Password Are The Same.",
                  "Passwords Are Same.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _User.Password = txtNewPassword.Text;

            if (_User.Save())
            {
                MessageBox.Show("Password Changed Successfully.",
                   "Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetDefualtValues();
            }
            else
            {
                MessageBox.Show("An Error Occured, Password did not change.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PerformBtn_ShowHideClick(TextBox txt , PictureBox pb)
        {
            if (string.IsNullOrEmpty(txt.Text))
                return;

            if (pb.Tag.ToString() == "Show")
            {
                pb.Image = Resources.eyeOpen;
                txt.UseSystemPasswordChar = true;
                pb.Tag = "Hide";
            }
            else
            {
                pb.Image = Resources.eye_closed;
                txt.UseSystemPasswordChar = false;
                pb.Tag = "Show";
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbShowHidePass_Click(object sender, EventArgs e)
        {
            PerformBtn_ShowHideClick(txtCurrentPassword, pbShowHidePass);
        }

        private void pbShowNewPassword_Click(object sender, EventArgs e)
        {
            PerformBtn_ShowHideClick(txtNewPassword, pbShowNewPassword);
        }

        private void pbShowConfirmPassword_Click(object sender, EventArgs e)
        {
            PerformBtn_ShowHideClick(txtConfirmPassword, pbShowConfirmPassword);
        }
    }
}
