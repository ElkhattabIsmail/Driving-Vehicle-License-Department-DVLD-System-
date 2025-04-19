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
    public partial class frmUserDetails : Form
    {
        private int _UserID = -1;
        public frmUserDetails(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfos(_UserID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
