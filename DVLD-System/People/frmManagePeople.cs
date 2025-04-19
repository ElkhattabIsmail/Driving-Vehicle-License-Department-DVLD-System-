
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;
using System.IO;
using C19_Project.OtherClasses;
using System.Dynamic;
using System.Threading;

namespace C19_Project.People
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }
        private DataTable PeopleTable = new DataTable ();
        private async void frmManagePeople_Load(object sender, EventArgs e)
        {
            Font MyFont = new Font("Calibri", 10,FontStyle.Bold ); // 10 is the size
            DvPeople.DefaultCellStyle.Font = MyFont;
            DvPeople.ColumnHeadersDefaultCellStyle.Font = MyFont;

        //Problem: If _FillDataIntoGridView(which fetches data and updates the UI)
        //        runs on the UI thread, it can block the UI, making the application appear
        //frozen or unresponsive, especially if the data fetching operation is slow(e.g., querying a database or calling
        //        a web service).

        //Solution: By using Task.Run, the data fetching operation(clsPerson.GetPeopleInformations()) is offloaded
        //to a background thread.This keeps the UI thread free to handle user interactions, making the application
        //     feel more responsive.

            // Offload the data fetching to a background thread
            await Task.Run(() => _FillDataIntoGridView());
            cbFilterby.SelectedIndex = 0;

            if(DvPeople.Rows.Count > 0 )
            {
                DvPeople.Columns[0].Width = 85;
                DvPeople.Columns[1].Width = 90;
                DvPeople.Columns[5].Width = 120;
                DvPeople.Columns[6].Width = 70;
                DvPeople.Columns[7].Width = 130;
                DvPeople.Columns[10].Width = 170;
                DvPeople.Columns[10].Width = 170;
            }

        }
        private void _FillDataIntoGridView()
        {
            PeopleTable = clsPerson.GetAllPeople();

            // Marshal UI updates back to the UI thread
            DvPeople.Invoke((MethodInvoker)delegate
            {
                DvPeople.DataSource = PeopleTable;
                UpdateDateOfBirthColumn(DvPeople);
                _GetPeopleCount();
            });
            //DvPeople.DataSource = PeopleTable;
            //UpdateDateOfBirthColumn(DvPeople);
            //_GetPeopleCount();
        }
        private void UpdateDateOfBirthColumn(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["DateOfBirth"] != null && row.Cells["DateOfBirth"].Value != null)
                {
                    DateTime Birth;
                    if (DateTime.TryParse(row.Cells["DateOfBirth"].Value.ToString(), out Birth))
                    {
                        row.Cells["DateOfBirth"].Value = Birth.ToShortDateString();
                    }
                }
            }
        }
        private void _GetPeopleCount()
        {
            // Get People Count
            lblPPLCount.Text = (DvPeople.RowCount).ToString();
        }

        private void txtSearchPpl_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearchPpl.Text;
            // Apply the filter to the DataTable's DefaultView
            if (!string.IsNullOrEmpty(filterText))
            {
                switch (cbFilterby.Text)
                {
                    case "FirstName":
                        PeopleTable.DefaultView.RowFilter = $"FirstName LIKE '{filterText}%'";
                        break;
                    case "Gender":
                        PeopleTable.DefaultView.RowFilter = $"Gender LIKE '{filterText}%'";
                        break;
                    case "NationalNo":
                        PeopleTable.DefaultView.RowFilter = $"NationalNo LIKE '{filterText}%'";
                        break;
                    case "PersonID":
                        // Attempt to parse the filter text as an integer
                        if (int.TryParse(filterText, out int personID))
                        {
                            // Apply the filter using the equality operator (PersonID = filterText)
                            PeopleTable.DefaultView.RowFilter = $"PersonID = {personID}";
                        }
                        break;
                    case "SecondName":
                        PeopleTable.DefaultView.RowFilter = $"SecondName LIKE '{filterText}%'";
                        break;
                    case "ThirdName":
                        PeopleTable.DefaultView.RowFilter = $"ThirdName LIKE '{filterText}%'";
                        break;
                    case "LastName":
                        PeopleTable.DefaultView.RowFilter = $"LastName LIKE '{filterText}%'";
                        break;
                    case "CountryName":
                        PeopleTable.DefaultView.RowFilter = $"CountryName LIKE '{filterText}%'";
                        break;
                    case "Phone":
                        PeopleTable.DefaultView.RowFilter = $"Phone LIKE '{filterText}%'";
                        break;
                    case "Email":
                        PeopleTable.DefaultView.RowFilter = $"Email LIKE '{filterText}%'";
                        break;
                    default:
                        PeopleTable.DefaultView.RowFilter = "";
                        break;
                }
            }
            else
                PeopleTable.DefaultView.RowFilter = "";
        }

        private void cbFilterby_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearchPpl.Visible = true;
            if (cbFilterby.SelectedItem.ToString() == "None")
            {
                txtSearchPpl.Visible = false;
                txtSearchPpl.Text = "";
                _FillDataIntoGridView();
            }
        }

        private void txtSearchPpl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterby.SelectedItem.ToString() == "PersonID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAdd_Update_Person frmAdd = new frmAdd_Update_Person();
            frmAdd.ShowDialog();
            // whene Cancel the form we refrech it
            _FillDataIntoGridView();
            _GetPeopleCount();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_Update_Person frmAdd = new frmAdd_Update_Person();
            frmAdd.ShowDialog();
            // whene Cancel the form we refrech it
            _FillDataIntoGridView();
            _GetPeopleCount();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedID = Convert.ToInt32(DvPeople.SelectedRows[0].Cells[0].Value);

            frmShowPersonDetails pd = new frmShowPersonDetails(SelectedID);
            pd.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedPersonID = Convert.ToInt32(DvPeople.SelectedRows[0].Cells[0].Value);
            frmAdd_Update_Person frmUpd = new frmAdd_Update_Person(SelectedPersonID);
            frmUpd.ShowDialog();
            _FillDataIntoGridView();
        }

        private bool IsImageDeletedCorrectly(string ImagePath)
        {
            if (ImagePath != "")
            {
                try
                {
                    File.Delete(ImagePath);
                    return true;
                }
                catch (Exception ex)
                {
                    ClsGlobal.LogExecption(ex, "DLVD", System.Diagnostics.EventLogEntryType.Error);
                    return false;
                }
            }
            return true;
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int SelectedPersonID = Convert.ToInt32(DvPeople.SelectedRows[0].Cells[0].Value);

            if (MessageBox.Show("Are You Sure Do You Want  delete This Person?", "Confirm", MessageBoxButtons.YesNo,
             MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string ImagePathToDeleteImage = clsPerson.FindUserPersonID(SelectedPersonID).ImagePath ;

                if (!clsPerson.DeletePerson(SelectedPersonID))
                {
                    MessageBox.Show("Person was not deleted because it has data linked to it.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // delete Person Image
                    if (!IsImageDeletedCorrectly(ImagePathToDeleteImage))
                    {
                        MessageBox.Show("Person Image Not Deleted Seccessfully!",
                        "Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    MessageBox.Show("Person Deleted Seccessfully.", "Done", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Refresh GridData
                    _FillDataIntoGridView();
                    _GetPeopleCount();
                }
                    
            }
        }
    }
}
