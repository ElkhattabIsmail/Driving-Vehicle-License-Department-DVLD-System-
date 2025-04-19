namespace C19_Project.NewDrivingLicensesApplication.NewLocalDrivingLicense
{
    partial class frmManageLocalDrivingLicensesApps
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DvgAllDrivingLicenseApplication = new System.Windows.Forms.DataGridView();
            this.cmsApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAppsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbFilterby = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tmsShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsCancelApp = new System.Windows.Forms.ToolStripMenuItem();
            this.SheduleTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsVesionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsWritingTest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsIssueDL_FirstTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DvgAllDrivingLicenseApplication)).BeginInit();
            this.cmsApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.DvgAllDrivingLicenseApplication);
            this.panel1.Location = new System.Drawing.Point(12, 371);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1529, 353);
            this.panel1.TabIndex = 118;
            // 
            // DvgAllDrivingLicenseApplication
            // 
            this.DvgAllDrivingLicenseApplication.AllowUserToAddRows = false;
            this.DvgAllDrivingLicenseApplication.AllowUserToDeleteRows = false;
            this.DvgAllDrivingLicenseApplication.AllowUserToResizeColumns = false;
            this.DvgAllDrivingLicenseApplication.AllowUserToResizeRows = false;
            this.DvgAllDrivingLicenseApplication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DvgAllDrivingLicenseApplication.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DvgAllDrivingLicenseApplication.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DvgAllDrivingLicenseApplication.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.DvgAllDrivingLicenseApplication.ColumnHeadersHeight = 29;
            this.DvgAllDrivingLicenseApplication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DvgAllDrivingLicenseApplication.ContextMenuStrip = this.cmsApplications;
            this.DvgAllDrivingLicenseApplication.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DvgAllDrivingLicenseApplication.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DvgAllDrivingLicenseApplication.Location = new System.Drawing.Point(3, 3);
            this.DvgAllDrivingLicenseApplication.Name = "DvgAllDrivingLicenseApplication";
            this.DvgAllDrivingLicenseApplication.ReadOnly = true;
            this.DvgAllDrivingLicenseApplication.RowHeadersWidth = 51;
            this.DvgAllDrivingLicenseApplication.RowTemplate.Height = 24;
            this.DvgAllDrivingLicenseApplication.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DvgAllDrivingLicenseApplication.ShowCellErrors = false;
            this.DvgAllDrivingLicenseApplication.ShowCellToolTips = false;
            this.DvgAllDrivingLicenseApplication.ShowEditingIcon = false;
            this.DvgAllDrivingLicenseApplication.ShowRowErrors = false;
            this.DvgAllDrivingLicenseApplication.Size = new System.Drawing.Size(1523, 306);
            this.DvgAllDrivingLicenseApplication.TabIndex = 26;
            this.DvgAllDrivingLicenseApplication.VirtualMode = true;
            // 
            // cmsApplications
            // 
            this.cmsApplications.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmsShow,
            this.toolStripSeparator2,
            this.tmsEdit,
            this.tsmDelete,
            this.toolStripSeparator5,
            this.tmsCancelApp,
            this.toolStripSeparator1,
            this.SheduleTest,
            this.toolStripSeparator3,
            this.tmsIssueDL_FirstTime,
            this.toolStripSeparator4,
            this.tmsShowLicense,
            this.toolStripSeparator6,
            this.tmsHistory});
            this.cmsApplications.Name = "contextMenuStrip1";
            this.cmsApplications.Size = new System.Drawing.Size(380, 344);
            this.cmsApplications.Opening += new System.ComponentModel.CancelEventHandler(this.cmsApplications_Opening);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(376, 6);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(376, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(376, 6);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(376, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(376, 6);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(376, 6);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblTitle.Location = new System.Drawing.Point(2, 224);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1567, 53);
            this.lblTitle.TabIndex = 117;
            this.lblTitle.Text = "Local Driving License Applications";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAppsCount
            // 
            this.lblAppsCount.AutoSize = true;
            this.lblAppsCount.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppsCount.Location = new System.Drawing.Point(135, 731);
            this.lblAppsCount.Name = "lblAppsCount";
            this.lblAppsCount.Size = new System.Drawing.Size(23, 28);
            this.lblAppsCount.TabIndex = 116;
            this.lblAppsCount.Text = "?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 729);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 28);
            this.label2.TabIndex = 114;
            this.label2.Text = "# Records :";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(323, 329);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(229, 36);
            this.txtSearch.TabIndex = 121;
            this.txtSearch.Visible = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // cbFilterby
            // 
            this.cbFilterby.BackColor = System.Drawing.Color.Silver;
            this.cbFilterby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterby.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterby.FormattingEnabled = true;
            this.cbFilterby.Items.AddRange(new object[] {
            "None",
            "DDL_ID",
            "National No",
            "Full Name",
            "status"});
            this.cbFilterby.Location = new System.Drawing.Point(115, 329);
            this.cbFilterby.Name = "cbFilterby";
            this.cbFilterby.Size = new System.Drawing.Size(190, 36);
            this.cbFilterby.TabIndex = 120;
            this.cbFilterby.SelectedIndexChanged += new System.EventHandler(this.cbFilterby_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 28);
            this.label1.TabIndex = 119;
            this.label1.Text = "Filter By:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::C19_Project.Properties.Resources.Local_322;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(829, 88);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 132;
            this.pictureBox1.TabStop = false;
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbPersonImage.Image = global::C19_Project.Properties.Resources.Applications;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(662, 20);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(220, 189);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 131;
            this.pbPersonImage.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::C19_Project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1388, 731);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 47);
            this.btnClose.TabIndex = 123;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::C19_Project.Properties.Resources.New_Application_64;
            this.button1.Location = new System.Drawing.Point(1437, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 76);
            this.button1.TabIndex = 122;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tmsShow
            // 
            this.tmsShow.Image = global::C19_Project.Properties.Resources.PersonDetails_32;
            this.tmsShow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tmsShow.Name = "tmsShow";
            this.tmsShow.Size = new System.Drawing.Size(379, 38);
            this.tmsShow.Text = "&Show Application Details";
            this.tmsShow.Click += new System.EventHandler(this.tmsShow_Click);
            // 
            // tmsEdit
            // 
            this.tmsEdit.Image = global::C19_Project.Properties.Resources.edit_32;
            this.tmsEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tmsEdit.Name = "tmsEdit";
            this.tmsEdit.Size = new System.Drawing.Size(379, 38);
            this.tmsEdit.Text = "&Edit Application";
            this.tmsEdit.Click += new System.EventHandler(this.tmsEdit_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Image = global::C19_Project.Properties.Resources.Delete_32_2;
            this.tsmDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(379, 38);
            this.tsmDelete.Text = "&delete Application";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // tmsCancelApp
            // 
            this.tmsCancelApp.Image = global::C19_Project.Properties.Resources.Delete_32;
            this.tmsCancelApp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tmsCancelApp.Name = "tmsCancelApp";
            this.tmsCancelApp.Size = new System.Drawing.Size(379, 38);
            this.tmsCancelApp.Text = "&Cancel Application";
            this.tmsCancelApp.Click += new System.EventHandler(this.tmsCancelApp_Click);
            // 
            // SheduleTest
            // 
            this.SheduleTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsVesionTest,
            this.cmsWritingTest,
            this.cmsStreetTest});
            this.SheduleTest.Image = global::C19_Project.Properties.Resources.Schedule_Test_32;
            this.SheduleTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SheduleTest.Name = "SheduleTest";
            this.SheduleTest.Size = new System.Drawing.Size(379, 38);
            this.SheduleTest.Text = "Sechdule &Tests";
            // 
            // cmsVesionTest
            // 
            this.cmsVesionTest.Image = global::C19_Project.Properties.Resources.Vision_Test_32;
            this.cmsVesionTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsVesionTest.Name = "cmsVesionTest";
            this.cmsVesionTest.Size = new System.Drawing.Size(298, 38);
            this.cmsVesionTest.Text = "Schedule Vesion Test";
            this.cmsVesionTest.Click += new System.EventHandler(this.scheduleVisionTestToolStripMenuItem_Click);
            // 
            // cmsWritingTest
            // 
            this.cmsWritingTest.Image = global::C19_Project.Properties.Resources.Written_Test_32;
            this.cmsWritingTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsWritingTest.Name = "cmsWritingTest";
            this.cmsWritingTest.Size = new System.Drawing.Size(298, 38);
            this.cmsWritingTest.Text = "Schedule Written Test";
            this.cmsWritingTest.Click += new System.EventHandler(this.cmsWritingTest_Click);
            // 
            // cmsStreetTest
            // 
            this.cmsStreetTest.Image = global::C19_Project.Properties.Resources.Street_Test_32;
            this.cmsStreetTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmsStreetTest.Name = "cmsStreetTest";
            this.cmsStreetTest.Size = new System.Drawing.Size(298, 38);
            this.cmsStreetTest.Text = "Schedule Street Test";
            this.cmsStreetTest.Click += new System.EventHandler(this.cmsStreetTest_Click);
            // 
            // tmsIssueDL_FirstTime
            // 
            this.tmsIssueDL_FirstTime.Image = global::C19_Project.Properties.Resources.IssueDrivingLicense_32;
            this.tmsIssueDL_FirstTime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tmsIssueDL_FirstTime.Name = "tmsIssueDL_FirstTime";
            this.tmsIssueDL_FirstTime.Size = new System.Drawing.Size(379, 38);
            this.tmsIssueDL_FirstTime.Text = "&Issue Driving License (First Time)";
            this.tmsIssueDL_FirstTime.Click += new System.EventHandler(this.tmsIssueDL_FirstTime_Click);
            // 
            // tmsShowLicense
            // 
            this.tmsShowLicense.Image = global::C19_Project.Properties.Resources.License_View_32;
            this.tmsShowLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tmsShowLicense.Name = "tmsShowLicense";
            this.tmsShowLicense.Size = new System.Drawing.Size(379, 38);
            this.tmsShowLicense.Text = "Show &License";
            this.tmsShowLicense.Click += new System.EventHandler(this.tmsShowLicense_Click);
            // 
            // tmsHistory
            // 
            this.tmsHistory.Image = global::C19_Project.Properties.Resources.PersonLicenseHistory_32;
            this.tmsHistory.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tmsHistory.Name = "tmsHistory";
            this.tmsHistory.Size = new System.Drawing.Size(379, 38);
            this.tmsHistory.Text = "Show Person License History";
            this.tmsHistory.Click += new System.EventHandler(this.tmsHistory_Click);
            // 
            // frmManageLocalDrivingLicensesApps
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1570, 790);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbFilterby);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblAppsCount);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageLocalDrivingLicensesApps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ManageLocalDrivingLicensesApps";
            this.Load += new System.EventHandler(this.ManageLocalDrivingLicensesApps_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DvgAllDrivingLicenseApplication)).EndInit();
            this.cmsApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAppsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbFilterby;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView DvgAllDrivingLicenseApplication;
        private System.Windows.Forms.ContextMenuStrip cmsApplications;
        private System.Windows.Forms.ToolStripMenuItem tmsShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tmsEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tmsCancelApp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem SheduleTest;
        private System.Windows.Forms.ToolStripMenuItem cmsVesionTest;
        private System.Windows.Forms.ToolStripMenuItem cmsWritingTest;
        private System.Windows.Forms.ToolStripMenuItem cmsStreetTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tmsIssueDL_FirstTime;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tmsShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tmsHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbPersonImage;
    }
}