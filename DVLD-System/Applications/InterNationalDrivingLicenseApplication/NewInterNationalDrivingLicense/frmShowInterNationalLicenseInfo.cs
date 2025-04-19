using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C19_Project.Applications.InterNationalDrivingLicenseApplication.NewInterNationalDrivingLicense
{
    public partial class frmShowInterNationalLicenseInfo : Form
    {
        private int _InternationalLicneseID = -1;
        public frmShowInterNationalLicenseInfo(int internationalLicneseID)
        {
            InitializeComponent();
            _InternationalLicneseID = internationalLicneseID;   
        }

        private void frmShowInterNationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationalLicenseInfo1.LoadInfo(_InternationalLicneseID);
        }
    }
}
