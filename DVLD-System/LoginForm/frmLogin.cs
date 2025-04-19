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
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Security.Cryptography;
using DVLD_BuisnessLayer;



namespace C19_Project.LoginForm
{

    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private ushort _Trials = 0;
        private ushort _TrialsNumber = 7;

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

            string UserName = "", Password = "";

            if (ClsGlobal.GetStoredCredentialUsingRegisty(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
                chkRememberMe.Checked = false;
        }
        private string HashPasswordWithStringBuilder(string Text4Hash)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(Text4Hash);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                StringBuilder hashString = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashString.Append(b.ToString("x2"));
                }
                return hashString.ToString();
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            clsUser user = clsUser.FindUserPersonIDByUsernameAndPassword(txtUserName.Text , HashPasswordWithStringBuilder(txtPassword.Text));

            if (user != null)
            {
                if (chkRememberMe.Checked)
                {
                    ClsGlobal.RememberUsernameAndPasswordUsingRegisty(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                }
                else
                {
                    ClsGlobal.RememberUsernameAndPasswordUsingRegisty("", "");
                }
                if (!user.IsActive)
                {
                    txtUserName.Focus();
                    MessageBox.Show("Your account is not Active, Contact Your Admin.", "Not Active",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ClsGlobal.CurrentUser = user;
                this.Hide();
                frmMain frm = new frmMain(this);
                frm.ShowDialog();
            }
            else
            {
                txtUserName.Focus();
                _Trials++;
                if (_TrialsNumber - _Trials == 1)
                    MessageBox.Show("Invalid Username/Password You have One left Trial.",
                        "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (_Trials == _TrialsNumber)
                {
                    ClsGlobal.LogExecption("Login Failed " + _TrialsNumber + " Times", "DVLD" , EventLogEntryType.Error);
                    MessageBox.Show("No Trails left Try to Login Next Time!", "No Trails", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }
        }

        private void pbShowHide_MouseEnter(object sender, EventArgs e)
        {
            lblShowAndHidePassword.Visible = true;
        }

        private void pbShowHidePass_MouseLeave(object sender, EventArgs e)
        {
            lblShowAndHidePassword.Visible = false;
        }

        private void PerformBtn_ShowHideClick()
        {
            if (pbShowHidePass.Tag.ToString() == "Show")
            {
                pbShowHidePass.Image = Resources.eyeOpen;
                lblShowAndHidePassword.Text = "Hide Password";
                txtPassword.UseSystemPasswordChar = true;
                pbShowHidePass.Tag = "Hide";
            }
            else
            {
                pbShowHidePass.Image = Resources.eye_closed;
                lblShowAndHidePassword.Text = "Show Password";
                txtPassword.UseSystemPasswordChar = false;
                pbShowHidePass.Tag = "Show";
            }
        }
        private void pbShowHidePass_Click(object sender, EventArgs e)
        {
            PerformBtn_ShowHideClick();
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            btnLogin.Focus();
        }
    }
}
