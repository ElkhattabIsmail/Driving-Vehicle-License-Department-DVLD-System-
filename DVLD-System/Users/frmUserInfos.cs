using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C19_Project.Users
{
    public partial class frmUserInfos : Form
    {
        private int UserID = -1;

        public frmUserInfos(int UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUserInfos_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfos(this.UserID);
        }
    }
}
