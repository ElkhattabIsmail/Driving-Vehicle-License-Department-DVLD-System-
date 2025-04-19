using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C19_Project.Licenses.International_Licenses
{
    public partial class frmLicensesHistory : Form
    {
        private int _DriverID = -1;
        private int _PersonID = -1;

        public frmLicensesHistory(int DriverID, int personID)
        {
            InitializeComponent();
            _DriverID = DriverID;
            _PersonID = personID;
        }

        private void frmLicensesHistory_Load(object sender, EventArgs e)
        {
            // for Person Information
            ctrlFilterPerson1.LoadPersonInfo(_PersonID);
            ctrlFilterPerson1.FilterEnabled = false;

            // for Licenses (Local or International)
            ctrlDriverLicneses1.LoadAllLicensesByDriverID(_DriverID);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
