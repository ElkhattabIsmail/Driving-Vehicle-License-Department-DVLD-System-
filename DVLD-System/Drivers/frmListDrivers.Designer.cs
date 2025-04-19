namespace C19_Project.Drivers
{
    partial class frmListDrivers
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
            this.lblAddUpdTitle = new System.Windows.Forms.Label();
            this.lblPPLCount = new System.Windows.Forms.Label();
            this.txtSearchPpl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilterby = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DvgDriversList = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmsDrivers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DvgDriversList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cmsDrivers.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAddUpdTitle
            // 
            this.lblAddUpdTitle.Font = new System.Drawing.Font("Calibri", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddUpdTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddUpdTitle.Location = new System.Drawing.Point(8, 261);
            this.lblAddUpdTitle.Name = "lblAddUpdTitle";
            this.lblAddUpdTitle.Size = new System.Drawing.Size(1327, 54);
            this.lblAddUpdTitle.TabIndex = 117;
            this.lblAddUpdTitle.Text = "Manage Drivers";
            this.lblAddUpdTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPPLCount
            // 
            this.lblPPLCount.AutoSize = true;
            this.lblPPLCount.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPPLCount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPPLCount.Location = new System.Drawing.Point(119, 697);
            this.lblPPLCount.Name = "lblPPLCount";
            this.lblPPLCount.Size = new System.Drawing.Size(24, 28);
            this.lblPPLCount.TabIndex = 114;
            this.lblPPLCount.Text = "0";
            // 
            // txtSearchPpl
            // 
            this.txtSearchPpl.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchPpl.Location = new System.Drawing.Point(342, 328);
            this.txtSearchPpl.Multiline = true;
            this.txtSearchPpl.Name = "txtSearchPpl";
            this.txtSearchPpl.Size = new System.Drawing.Size(252, 38);
            this.txtSearchPpl.TabIndex = 113;
            this.txtSearchPpl.Visible = false;
            this.txtSearchPpl.TextChanged += new System.EventHandler(this.txtSearchPpl_TextChanged);
            this.txtSearchPpl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchPpl_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(11, 698);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 28);
            this.label3.TabIndex = 112;
            this.label3.Text = "# Record";
            // 
            // cbFilterby
            // 
            this.cbFilterby.BackColor = System.Drawing.Color.Silver;
            this.cbFilterby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterby.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterby.Items.AddRange(new object[] {
            "None",
            "DriverID",
            "PersonID",
            "NationalNo",
            "Full Name",
            "Active Licenses"});
            this.cbFilterby.Location = new System.Drawing.Point(138, 329);
            this.cbFilterby.Name = "cbFilterby";
            this.cbFilterby.Size = new System.Drawing.Size(189, 36);
            this.cbFilterby.TabIndex = 111;
            this.cbFilterby.SelectedIndexChanged += new System.EventHandler(this.cbFilterby_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(25, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 28);
            this.label2.TabIndex = 110;
            this.label2.Text = "Filter By :";
            // 
            // DvgDriversList
            // 
            this.DvgDriversList.AllowUserToAddRows = false;
            this.DvgDriversList.AllowUserToDeleteRows = false;
            this.DvgDriversList.AllowUserToResizeColumns = false;
            this.DvgDriversList.AllowUserToResizeRows = false;
            this.DvgDriversList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DvgDriversList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DvgDriversList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DvgDriversList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.DvgDriversList.ColumnHeadersHeight = 29;
            this.DvgDriversList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DvgDriversList.ContextMenuStrip = this.cmsDrivers;
            this.DvgDriversList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DvgDriversList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DvgDriversList.Location = new System.Drawing.Point(8, 381);
            this.DvgDriversList.Name = "DvgDriversList";
            this.DvgDriversList.ReadOnly = true;
            this.DvgDriversList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DvgDriversList.RowHeadersWidth = 51;
            this.DvgDriversList.RowTemplate.Height = 24;
            this.DvgDriversList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DvgDriversList.ShowCellErrors = false;
            this.DvgDriversList.ShowCellToolTips = false;
            this.DvgDriversList.ShowEditingIcon = false;
            this.DvgDriversList.ShowRowErrors = false;
            this.DvgDriversList.Size = new System.Drawing.Size(1311, 308);
            this.DvgDriversList.TabIndex = 109;
            this.DvgDriversList.VirtualMode = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::C19_Project.Properties.Resources.Driver_Main1;
            this.pictureBox1.Location = new System.Drawing.Point(455, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(505, 266);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 118;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::C19_Project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1186, 699);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 54);
            this.btnClose.TabIndex = 124;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // cmsDrivers
            // 
            this.cmsDrivers.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsDrivers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator1,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsDrivers.Name = "contextMenuStrip1";
            this.cmsDrivers.Size = new System.Drawing.Size(347, 86);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::C19_Project.Properties.Resources.PersonDetails_32;
            this.showDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(346, 38);
            this.showDetailsToolStripMenuItem.Text = "&Show Person Info";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(343, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::C19_Project.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(346, 38);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // frmListDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 765);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblAddUpdTitle);
            this.Controls.Add(this.lblPPLCount);
            this.Controls.Add(this.txtSearchPpl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFilterby);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DvgDriversList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListDrivers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmListDrivers";
            this.Load += new System.EventHandler(this.frmListDrivers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DvgDriversList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cmsDrivers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddUpdTitle;
        private System.Windows.Forms.Label lblPPLCount;
        private System.Windows.Forms.TextBox txtSearchPpl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilterby;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DvgDriversList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmsDrivers;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}