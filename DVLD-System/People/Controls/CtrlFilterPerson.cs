
using DVLD_Buisness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C19_Project.People.Controls
{
    public partial class CtrlFilterPerson : UserControl
    {
        public CtrlFilterPerson()
        {
            InitializeComponent();
        }
        // Define a custom event handler delegate with One parameter
        public event Action<int> OnPersonSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnSearchonPerson.Enabled = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled  = _FilterEnabled;
            }
        }
        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonCard1.SelectedPersonInfo; }
        }
        private void CtrlFilterPerson_Load(object sender, EventArgs e)
        {
            txtSearch4.Focus();
            cbFilterby4.SelectedIndex = 0;
        } 
        private void FindPersonNow()
        {
            switch (cbFilterby4.Text)
            {
                case "PersonID":
                    ctrlPersonCard1.LoadPersonInfos(int.Parse(txtSearch4.Text));
                    break;

                case "NationalNo":
                    ctrlPersonCard1.LoadPersonInfos(txtSearch4.Text);
                    break;

                default:
                    break;
            }

            if (OnPersonSelected != null && FilterEnabled)
            {
                // Raise the event with a parameter
                OnPersonSelected(ctrlPersonCard1.PersonID);
            }

        }
        public void LoadPersonInfo(int PersonID)
        {
            cbFilterby4.SelectedIndex = 0;
            txtSearch4.Text = PersonID.ToString();
            FindPersonNow();
        }
        private void btnSearchonPerson_Click(object sender, EventArgs e)
        {
            if (txtSearch4.Text == "")
            {
                return;
            }
            FindPersonNow();

        }
    
        public void FilterFocus()
        {
            txtSearch4.Focus();
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAdd_Update_Person frmAddUpd = new frmAdd_Update_Person();
            frmAddUpd.DataBack += DataBackEvent1; // Subscribe to the event
            frmAddUpd.ShowDialog();            
        }
        private void DataBackEvent1(object sender, int PersonID)
        {
            // Handle the data received
            cbFilterby4.SelectedIndex = 1;
            txtSearch4.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfos(PersonID);
        }
        private void cbFilterby4_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch4.Text = "";
            txtSearch4.Focus();
        }

        private void txtSearch4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnSearchonPerson.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilterby4.Text == "PersonID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


    }
}
