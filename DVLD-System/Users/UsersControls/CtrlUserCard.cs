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

namespace C19_Project.Users.UsersControls
{
    public partial class CtrlUserCard : UserControl
    {
        public CtrlUserCard()
        {
            InitializeComponent();
        }
        private clsUser _User;
        private int _UserID = -1;

        public int UserID
        {
            get { return _UserID; }
        }
        private void ResetUserData()
        {
            lblUserID.Text = "?";
            lblUserName.Text = "?";
            lblIsActive.Text = "?";
        }
        private void FillUserInfos()
        {
            // Person Infos
            ctrlPersonCard1.LoadPersonInfos(_User.PersonID);

            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName;
            lblIsActive.Text = _User.IsActive ? "Yes" : "No";
        }
        public void LoadUserInfos(int UserID)
        {
            _User = clsUser.FindUserByPersonID(UserID);
            if (_User == null)
            {
                _UserID = _User.UserID;
                ResetUserData();
                MessageBox.Show("No User With ID = " + UserID, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FillUserInfos();
            }
        }
    }
}
