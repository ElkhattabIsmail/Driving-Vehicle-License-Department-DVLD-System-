
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

namespace C19_Project.ManageAppsTests
{
    public partial class frmUpdateTest : Form
    {
        private clsTestType.enTestType _TestTypeID ;

        private clsTestType _Test;

        public frmUpdateTest(clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _TestTypeID = TestType;
        }
      
        private void _FillApplicationInfos()
        {
            
            _Test = clsTestType.FindUserPersonID(_TestTypeID);

            if (_Test != null)
            {
                lblTestID.Text = ((int)_TestTypeID).ToString();

                txtTitle.Text = _Test.Title;
                txtDescription.Text = _Test.Description;
                txtFees.Text = _Test.Fees.ToString();
            }
            else
            {
                MessageBox.Show("No Test With ID = " + _TestTypeID.ToString() + " !", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmUpdateTest_Load(object sender, EventArgs e)
        {
            _FillApplicationInfos();
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                e.Cancel = true;
                txtTitle.Focus();
                errorProvider1.SetError(txtTitle, "Is A Requred Field!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTitle, "");
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFees.Text))
            {
                e.Cancel = true;
                txtFees.Focus();
                errorProvider1.SetError(txtFees, "Is A Requred Field!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFees, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Test.Title == txtTitle.Text && _Test.Fees.ToString() == txtFees.Text
                && _Test.Description.ToString () == txtDescription.Text)
                return;

            if (!this.ValidateChildren())
            {
                return;
            }
            else
            {
                _Test.Title = txtTitle.Text;
                _Test.Fees = Convert.ToSingle(txtFees.Text);
                _Test.Description = txtDescription.Text;

                if (_Test.Save())
                {
                    MessageBox.Show("Test Information Updatded Successfully✔️", "LocalSave", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sorry The Informations Not Updated!", "Wrong", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
