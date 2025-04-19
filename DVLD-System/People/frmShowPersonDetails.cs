using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C19_Project.People
{
    public partial class frmShowPersonDetails : Form
    {
        private int _PersonID = 0;
        private string _NationalNo;
        private enum _LoadDataMode { WithPersonID = 0 , WithNationalNo  =2};
        private _LoadDataMode Mode = _LoadDataMode.WithPersonID;
        public frmShowPersonDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            Mode = _LoadDataMode.WithPersonID;
        }
        public frmShowPersonDetails(string NationalNo)
        {
            InitializeComponent();
            _NationalNo = NationalNo;
            Mode = _LoadDataMode.WithNationalNo;
        }
        private void frmShowPersonDetails_Load(object sender, EventArgs e)
        {
            if (Mode  == _LoadDataMode.WithPersonID)
            {
                ctrlPersonCard1.LoadPersonInfos(_PersonID);
            }
            else
            {
                ctrlPersonCard1.LoadPersonInfos(_NationalNo);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
