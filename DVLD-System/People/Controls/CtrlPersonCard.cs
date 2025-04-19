using C19_Project.People.Controls;
using C19_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using DVLD_BuisnessLayer;

namespace C19_Project.People.Controls
{
    public partial class CtrlPersonCard : UserControl
    {
        private clsPerson _Person;
        private int _PersonID = -1;


        public CtrlPersonCard()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }
        public void LoadPersonInfos(int PersonID)
        {
            _Person = clsPerson.FindUserPersonID(PersonID);
            if (_Person == null)
            {
                ResetPersonData();

                MessageBox.Show("No Person With ID = " + PersonID, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FillPersonInfos();
            }
        }
        public void LoadPersonInfos(string NationalNo)
        {
            _Person = clsPerson.FindUserPersonID(NationalNo);
            if (_Person == null)
            {
                ResetPersonData();
                MessageBox.Show("No Person With NationalNo = " + NationalNo, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FillPersonInfos();
            }
        }
        public void FillPersonInfos()
        {
            lnkUpdate.Enabled = true;
            if (_Person.Gender == 0)
            {
                lblGender.Text = "Male";
            }
            else
            {
                lblGender.Text = "Female";
            }
            if (_Person.ImagePath != "")
            {
                if (File.Exists(_Person.ImagePath))
                {
                    pbProfile.ImageLocation = _Person.ImagePath;
                }  
                else
                {
                    MessageBox.Show("Errors Picture not loaded ", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (lblGender.Text == "Male")
                    {
                        pbProfile.Image = Resources.Male_512;
                    }
                    else
                    {
                        pbProfile.Image = Resources.Female_512;
                    }
                }
            }
            else
            {
                if (lblGender.Text == "Male")
                {
                    pbProfile.Image = Resources.Male_512;
                }
                else
                {
                    pbProfile.Image = Resources.Female_512;
                }
            }
            _PersonID = _Person.PersonID;

            lblNationalNo.Text = _Person.NationalNo;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblAddress.Text = _Person.Address;
            lblPhone.Text = _Person.Phone;
            lblFName.Text = _Person.FullName;
            lblEmail.Text = _Person.Email;
            lblCountry.Text = clsCountry.FindUserPersonID(_Person.NationalityCountryID).CountryName;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
        }
        public void ResetPersonData()
        {
            _PersonID = -1;
            lblPersonID.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblGender.Text = "[???]";
            lblPhone.Text = "[???]";
            lblFName.Text = "[???]";
            lblEmail.Text = "[???]";
            lblCountry.Text = "[???]";
            lblDateOfBirth.Text = "[???]";
            pbProfile.Image = Resources.Male_512;
        }

        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmAdd_Update_Person frmAddUpd = new frmAdd_Update_Person(_PersonID);
            frmAddUpd.ShowDialog();

            //refresh Person Data
            LoadPersonInfos(_PersonID);

        }
    }
}


