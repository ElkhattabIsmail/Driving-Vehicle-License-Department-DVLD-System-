using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C19_Project.ManageAppsTests
{
    public partial class frmShowLocalDrivingLicenseApplicationDetails : Form
    {
 
        private int _ApplicationID = -1;

        public frmShowLocalDrivingLicenseApplicationDetails(int AppId)
        {
            InitializeComponent();
            _ApplicationID = AppId;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowAppDetails_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseInformations1.LoadDrivingLicenseByApplicationID(_ApplicationID);
        }
    }
}
