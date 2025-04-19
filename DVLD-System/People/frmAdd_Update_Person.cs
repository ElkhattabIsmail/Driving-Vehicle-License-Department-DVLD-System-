using C19_Project.OtherClasses;
using C19_Project.Properties;
using DVLD_BuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C19_Project.People
{
    public partial class frmAdd_Update_Person : Form
    {
        const string PeopleImagesPath = @"C:\DVLD People Pictures\";

        public delegate void DataBackToPreviousForm(object sender, int PersonID);
        public event DataBackToPreviousForm DataBack;

        private enum _enMode { AddNewMode = 0, UpdateMode = 1 };
        private _enMode _Mode;
        private clsPerson _Person;
        private int _PersonID = -1;

        public frmAdd_Update_Person()
        {
            InitializeComponent();
            _Mode = _enMode.AddNewMode;
        }
        public frmAdd_Update_Person(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = _enMode.UpdateMode;
        }

        private void _FillCountriesInComboBox()
        {
            DataTable Countries = clsCountry.GetAllCountries();
            foreach (DataRow Row in Countries.Rows)
            {
                cbCountries.Items.Add(Row["CountryName"]);
            }
        }

        private void _resetDefaultValues()
        {
            _FillCountriesInComboBox();

            if (_Mode == _enMode.AddNewMode)
            {
                lblAddUpdateTitle.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblAddUpdateTitle.Text = "Update Person";
            }
            dtBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtBirth.MinDate = DateTime.Now.AddYears(-120);
            dtBirth.Value = dtBirth.MaxDate;

            cbCountries.SelectedIndex = cbCountries.FindString("Morocco");

            // Reset form value
            txtFN.Text = ""; txtScN.Text = ""; txtScN.Text = ""; txtTN.Text = ""; txtLN.Text = ""; txtEmail.Text = "";
            txtPhone.Text = ""; txtAddress.Text = ""; txtPhone.Text = ""; rbMale.Checked = true;
            lnkRmv.Visible = (pbProfile.Tag.ToString() != "Empty");
        }
        private void _LoadPersonData4Update()
        {
            _Person = clsPerson.FindUserPersonID(_PersonID);

            if (_Person == null)
            {
                this.Close();
                return;
            }
            lblPersonID.Text = _Person.PersonID.ToString();
            txtNationalNo.Text = _Person.NationalNo;
            txtFN.Text = _Person.FirstName;
            txtScN.Text = _Person.SecondName;
            txtTN.Text = _Person.ThirdName;
            txtLN.Text = _Person.LastName;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;
            // 0 = male  , 1 = female
            if (_Person.Gender == 0)
            {
                rbMale.Checked = true;
            }
            else { rbFemale.Checked = true; };

            cbCountries.SelectedIndex = cbCountries.FindString(clsCountry.FindUserPersonID(_Person.NationalityCountryID).CountryName);
            if (_Person.ImagePath != "")
            {
                pbProfile.ImageLocation = _Person.ImagePath;
                //pbProfile.Load(_Person.ImagePath);
            }
            lnkRmv.Visible = (_Person.ImagePath != "");
        }
        private void frmAdd_Update_Person_Load(object sender, EventArgs e)
        {
            _resetDefaultValues();
            btnSave.Enabled = false;

            if (_Mode == _enMode.UpdateMode)
            {
                _LoadPersonData4Update();
            }
        }
        private void _AllowSaveButton()
        {
            if (txtFN.Text != string.Empty && txtLN.Text != string.Empty && txtAddress.Text != string.Empty &&
                txtNationalNo.Text != string.Empty)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }
        private void txtLN_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLN.Text))
            {
                e.Cancel = true;
                txtLN.Focus();
                errorProvider1.SetError(txtLN, "Is A Requred Field!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLN, "");
            }
            _AllowSaveButton();
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtNationalNo.Text))
            {
                e.Cancel = true;
                txtNationalNo.Focus();
                errorProvider1.SetError(txtNationalNo, "Is A Requred Field!");
            }
            else
            {
                string _NationalNo = txtNationalNo.Text;
                bool IsNationalNoExist = clsPerson.isPersonExist(_NationalNo);
                if (IsNationalNoExist && _NationalNo != _Person.NationalNo)
                {
                    e.Cancel = true;
                    txtNationalNo.Focus();
                    errorProvider1.SetError(txtNationalNo, "This National Number Back to Another Person In System!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtNationalNo, "");
                }

            }
            _AllowSaveButton();

        }
        private string[] ValidEmails = { "gmail", "outlook", "hotmail", "yahoo" };

        private bool IsGmailContains(string text, string[] ContainsWord)
        {

            string normalizedText = text.ToLower();  // Normalize the email address to lowercase for case-insensitive search

            foreach (var domain in ContainsWord)
            {
                string domainLower = domain.ToLower();  // Lowercase version of the domain

                // Check if the normalized email contains either the domain in lowercase or capitalized first letter form
                if (normalizedText.Contains("@" + domainLower))
                {
                    return true;  // Found a valid domain
                }
            }

            return false;  // No valid domain found

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text != string.Empty)
            {
                if (!IsGmailContains(txtEmail.Text, ValidEmails) || txtEmail.Text.Length < 11)
                {
                    e.Cancel = true;
                    txtEmail.Focus();
                    errorProvider1.SetError(txtEmail, "Not a Valid Email Format!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtEmail, "");
                }
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
            }
        }
        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                e.Cancel = true;
                txtAddress.Focus();
                errorProvider1.SetError(txtAddress, "Is A Requred Field!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAddress, "");
            }
            _AllowSaveButton();
        }
        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                e.Cancel = true;
                txtPhone.Focus();
                errorProvider1.SetError(txtPhone, "Is A Requred Field!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPhone, "");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                pbProfile.Image = Resources.Male_512;
            }
        }
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                pbProfile.Image = Resources.Female_512;
            }
        }
        private bool HandlePersonImage()
        {
            if (pbProfile.ImageLocation != null)
                pbProfile.Tag = "Fully";

            if (pbProfile.ImageLocation != _Person.ImagePath)

            {
                // try to delete the Old Pictrue
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException ex)
                    {
                        ClsGlobal.LogExecption(ex, "DLVD", System.Diagnostics.EventLogEntryType.Error);
                    }
                }
                if (pbProfile.ImageLocation != null )
                {

                    // Copy The image

                    //Ensure the destination folder exists
                    if (!Directory.Exists(PeopleImagesPath))
                    {
                        Directory.CreateDirectory(PeopleImagesPath);
                    }
                    string OriginFile = pbProfile.ImageLocation;
                    string fileExtension = Path.GetExtension(OriginFile);

                    string FileNameToAdded = Guid.NewGuid().ToString() + fileExtension;

                    ///Combine the destination folder, GUID name, and file extension
                    string DestinationFilePath = Path.Combine(PeopleImagesPath, FileNameToAdded);

                    try
                    {
                        // Copy the OriginalFile To This Destination Path
                        File.Copy(OriginFile, DestinationFilePath);
                    }
                    catch (IOException ex)
                    {
                        ClsGlobal.LogExecption(ex, "DLVD", System.Diagnostics.EventLogEntryType.Error);
                        return false;
                    }

                    pbProfile.ImageLocation = DestinationFilePath;
                    
                    return true;
                }
            }
            return true;
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (!HandlePersonImage())
            {
                MessageBox.Show("Error : We Faced a problem for Handling The Image");
            }

            // full the object
            _Person.NationalNo = txtNationalNo.Text;
            _Person.FirstName = txtFN.Text;
            _Person.SecondName = txtScN.Text;
            _Person.ThirdName = txtTN.Text;
            _Person.LastName = txtLN.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Email = txtEmail.Text;
            _Person.Address = txtAddress.Text;

            _Person.NationalityCountryID = clsCountry.FindUserPersonID(cbCountries.Text).ID;
            _Person.DateOfBirth = dtBirth.Value;

            if (rbMale.Checked)
            {
                _Person.Gender = 0;
            }
            else
            {
                _Person.Gender = 1;
            }
            if (pbProfile.Tag.ToString() == "Empty")
            {
                _Person.ImagePath = "";
            }
            else
            {
                _Person.ImagePath = pbProfile.ImageLocation;
            }

            if (_Person.Save())
            {
                // Change form to update mode
                _Mode = _enMode.UpdateMode;
                lblPersonID.Text = _Person.PersonID.ToString();
                lblAddUpdateTitle.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully", "LocalSave", MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);
                // Recall the Form With PersonID
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
            {
                MessageBox.Show("Data Is Not Saved", "LocalSave Error", MessageBoxButtons.OKCancel,
                 MessageBoxIcon.Error);
            }

        }

        private void txtFN_Validating_1(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFN.Text))
            {
                btnSave.Enabled = false;
                e.Cancel = true;
                txtFN.Focus();
                errorProvider1.SetError(txtFN, "Is A Requred Field!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFN, "");
            }
            _AllowSaveButton();
        }



        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lnkRmv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (rbFemale.Checked)
            {
                pbProfile.Image = Resources.Female_512;
            }
            else
                pbProfile.Image = Resources.Male_512;

            pbProfile.ImageLocation = null;
            pbProfile.Tag = "Empty";
            lnkRmv.Visible = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"Gallery";

            openFileDialog1.Title = "Choose An Image";

            openFileDialog1.DefaultExt = "png";
            openFileDialog1.Filter = "Image files (*.png;*.jpg;*.jpeg;*.gif;*.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // load the pic 
                string UpdatedImageFile = openFileDialog1.FileName;
                pbProfile.Load(UpdatedImageFile);
                // change pic tag
                pbProfile.Tag = "Fully";
                lnkRmv.Visible = true;
            }

        }
    }
}
