
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

namespace C19_Project.ManageAppsTests
{
    public partial class frmManageTestTypes : Form
    {
        private DataTable TestTable = new DataTable();
        public frmManageTestTypes()
        {
            InitializeComponent();
        }
        private void _FillTestDataIntoTable()
        {
            TestTable = clsTestType.GetAllTestTypes();
            DvgAllTestTypes.DataSource = TestTable;
        }
        private void _GetTestCount()
        {
            //lblAppsCount.Text = DvgAllTestTypes.Rows.Count.ToString();
            lblTestCount.Text = DvgAllTestTypes.RowCount.ToString();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            Font MyFont = new Font("Calibri", 13, FontStyle.Bold); // 14 is the size
            // Apply the font to the DataGridView's DefaultCellStyle
            DvgAllTestTypes.DefaultCellStyle.Font = MyFont;
            // Optionally, you can also change the column header font size
            DvgAllTestTypes.ColumnHeadersDefaultCellStyle.Font = MyFont;
            // Optionally, set the header text color

            //DvgAllTestTypes.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;

            _FillTestDataIntoTable();
            _GetTestCount();

            DvgAllTestTypes.Columns[0].HeaderText = "ID";
            DvgAllTestTypes.Columns[0].Width = 80;


            DvgAllTestTypes.Columns[1].HeaderText = "Title";
            DvgAllTestTypes.Columns[1].Width = 200;

            DvgAllTestTypes.Columns[2].HeaderText = "Description";
            DvgAllTestTypes.Columns[2].Width = 600;

            DvgAllTestTypes.Columns[3].HeaderText = "Fees";
            DvgAllTestTypes.Columns[3].Width = 110;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTest frmUpdTest = new frmUpdateTest(
                (clsTestType.enTestType)DvgAllTestTypes.SelectedRows[0].Cells[0].Value);

            frmUpdTest.ShowDialog();

            // Refresh Table Infos
            _FillTestDataIntoTable();
        }
    }
}
