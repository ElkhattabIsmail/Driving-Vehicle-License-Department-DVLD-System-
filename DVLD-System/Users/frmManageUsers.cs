using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BuisnessLayer;

namespace C19_Project.Users
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private DataTable UsersTable = new DataTable ();

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            //dvAllUsers.Font = new Font ()
            Font MyFont = new Font("Calibri", 15); // 15 is the size
            // Apply the font to the DataGridView's DefaultCellStyle
            dvAllUsers.DefaultCellStyle.Font = MyFont;
            // Optionally, you can also change the column header font size
            dvAllUsers.ColumnHeadersDefaultCellStyle.Font = MyFont;
            cbFilterby.SelectedIndex = 0;

            btnAddNewUser.Focus();

            _FillDataInGridView();
            _GetUsersCount();

            dvAllUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // Disable AutoSize

            // Now, set the width
            if (dvAllUsers.Columns.Contains("FullName"))
            {
                dvAllUsers.Columns["FullName"].Width = 300;
            }
            if (dvAllUsers.Columns.Contains("UserName"))
            {
                dvAllUsers.Columns["UserName"].Width = 150;
            }
            if (dvAllUsers.Columns.Contains("IsActive"))
            {
                dvAllUsers.Columns["IsActive"].Width = 104;
            }
            // Wire up the TextChanged event for filtering
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void _FillDataInGridView()
        {
            UsersTable = clsUser.GetAllUsers();
            // full the data grid view
            dvAllUsers.DataSource = UsersTable;
        }
        private void _GetUsersCount()
        {
            // Get People Count
            lblUsersCount.Text = (dvAllUsers.RowCount).ToString();
        }
        private void RefreshDataAndCountOfUsers()
        {
            _FillDataInGridView();
            _GetUsersCount();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearch.Text;

            // Apply the filter to the DataTable's DefaultView
            if (!string.IsNullOrEmpty(filterText))
            {

                if (cbFilterby.SelectedItem.ToString() == "User ID")
                {
                    if (int.TryParse(filterText, out int UserID))
                    {
                        // Apply the filter using the equality operator (PersonID = filterText)
                        UsersTable.DefaultView.RowFilter = $"UserID = {UserID}";
                    }
                }
                else if (cbFilterby.SelectedItem.ToString() == "Person ID")
                {
                    if (int.TryParse(filterText, out int personID))
                    {
                        // Apply the filter using the equality operator (PersonID = filterText)
                        UsersTable.DefaultView.RowFilter = $"PersonID = {personID}";
                    }
                }
                else if (cbFilterby.SelectedItem.ToString() == "User Name")
                {
                    UsersTable.DefaultView.RowFilter = $"UserName LIKE '{filterText}%'";
                }
                else if (cbFilterby.SelectedItem.ToString() == "Full Name")
                {
                    UsersTable.DefaultView.RowFilter = $"FullName LIKE '{filterText}%'";
                }
                else if (cbFilterby.SelectedItem.ToString() == "Is Active")
                {
                    // 0 false and 1 = true
                    if (int.TryParse(filterText, out int IsActive))
                    {
                        if (IsActive == 1)
                        {
                            // Apply the filter using the equality operator (PersonID = filterText)
                            UsersTable.DefaultView.RowFilter = $"IsActive = {true}";
                        }
                        else
                        {
                            UsersTable.DefaultView.RowFilter = $"IsActive = {false}";
                        }

                    }
                }
                else
                {
                    UsersTable.DefaultView.RowFilter = "";
                }

            }
            else
            {
                UsersTable.DefaultView.RowFilter = "";
            }
        }

        private void cbFilterby_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterby.Text == "Is Active")
            {
                txtSearch.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }
            else
            {
                txtSearch.Visible = cbFilterby.Text != "None";
                cbIsActive.Visible = false;
                txtSearch.Text = "";
                UsersTable.DefaultView.RowFilter = "";
                txtSearch.Focus ();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterby.SelectedItem.ToString() == "User ID" ||
            cbFilterby.SelectedItem.ToString() == "Person ID" ||
            cbFilterby.SelectedItem.ToString() == "Is Active")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAdd_Update_User Fau = new frmAdd_Update_User();
            Fau.ShowDialog();
            // Refresh Data
            RefreshDataAndCountOfUsers();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID  = Convert.ToInt32(dvAllUsers.SelectedRows[0].Cells[0].Value);
            frmAdd_Update_User frmEdit = new frmAdd_Update_User(UserID);
            frmEdit.ShowDialog();
            // Refresh
            RefreshDataAndCountOfUsers();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are You Sure Do You Want  delete This User?", "Confirm", MessageBoxButtons.YesNo,
             MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsUser.DeleteUser((int)dvAllUsers.SelectedRows[0].Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Seccessfully.", "Deleted", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    RefreshDataAndCountOfUsers();
                }
                else
                    MessageBox.Show("User Not Deleted !", "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserDetails UserDetails = new frmUserDetails((int)dvAllUsers.SelectedRows[0].Cells[0].Value);
            UserDetails.ShowDialog();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                UsersTable.DefaultView.RowFilter = "";
            else
                UsersTable.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblUsersCount.Text = UsersTable.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
