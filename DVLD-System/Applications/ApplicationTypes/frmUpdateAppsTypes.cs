
using DVLD_BuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C19_Project.ApplicationTypes
{
    public partial class frmUpdateAppsTypes : Form
    {
        private int _ApplicationID = -1;
        private clsApplicationType _AppType;

        public frmUpdateAppsTypes(int AppID)
        {
            InitializeComponent();
            _ApplicationID = AppID;
        }
        private void _FillApplicationInfos()
        {
            _AppType =  clsApplicationType.FindUserPersonID(_ApplicationID);
            if (_AppType != null)
            {
                lblApplTypeID.Text = _AppType.ID.ToString();
                txtTitle.Text = _AppType.Title;
                txtFees.Text = (_AppType.Fees).ToString();
            }
        }
        private void frmUpdateAppsTypes_Load(object sender, EventArgs e)
        {
            _FillApplicationInfos();
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

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_AppType.Title == txtTitle.Text && _AppType.Fees.ToString() == txtFees.Text)
                return;

            if (!this.ValidateChildren())
            {
                return;
            }
            else
            {
                _AppType.Title = txtTitle.Text;
                _AppType.Fees = Convert.ToSingle(txtFees.Text);
                if (_AppType.Save ())
                {
                    MessageBox.Show("Information Updatded Successfully✔️", "LocalSave", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sorry The Informations Not Updated!", "Wrong", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information);
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
