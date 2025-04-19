
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
namespace C19_Project.ApplicationTypes
{
    public partial class frmManageAppsTypes : Form
    {
        private DataTable ApplicationsTable = new DataTable ();
        public frmManageAppsTypes()
        {
            InitializeComponent();
        }
        private void _FillAppsDataIntoTable()
        {
            ApplicationsTable = clsApplicationType.GetAllApplicationTypes();
            DvgAllAppsTypes.DataSource = ApplicationsTable;
        }
        private void _GetAppsCount()
        {
            lblAppsCount.Text = DvgAllAppsTypes.RowCount.ToString();
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppID = Convert.ToInt32(DvgAllAppsTypes.SelectedRows[0].Cells[0].Value);

            frmUpdateAppsTypes frmUpdateApps = new frmUpdateAppsTypes(AppID);
            frmUpdateApps.ShowDialog();
        }

        private void frmManageAppsTypes_Load_1(object sender, EventArgs e)
        {
            Font MyFont = new Font("Calibri", 13, FontStyle.Bold); // 13 is the size
            // Apply the font to the DataGridView's DefaultCellStyle
            DvgAllAppsTypes.DefaultCellStyle.Font = MyFont;
            // Optionally, you can also change the column header font size
            DvgAllAppsTypes.ColumnHeadersDefaultCellStyle.Font = MyFont;
            // Optionally, set the header text color

            _FillAppsDataIntoTable();
            _GetAppsCount();

            DvgAllAppsTypes.Columns[0].HeaderText = "ID";
            DvgAllAppsTypes.Columns[0].Width = 110;

            DvgAllAppsTypes.Columns[1].HeaderText = "Title";
            DvgAllAppsTypes.Columns[1].Width = 400;

            DvgAllAppsTypes.Columns[2].HeaderText = "Fees";
            DvgAllAppsTypes.Columns[2].Width = 110;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
