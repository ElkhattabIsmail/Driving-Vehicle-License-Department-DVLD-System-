namespace C19_Project.People
{
    partial class frmManagePeople
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
            this.lblPPLCount = new System.Windows.Forms.Label();
            this.txtSearchPpl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilterby = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DvPeople = new System.Windows.Forms.DataGridView();
            this.cmsApps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblAddUpdTitle = new System.Windows.Forms.Label();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.callPhoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DvPeople)).BeginInit();
            this.cmsApps.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblPPLCount
            // 
            this.lblPPLCount.AutoSize = true;
            this.lblPPLCount.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPPLCount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPPLCount.Location = new System.Drawing.Point(131, 576);
            this.lblPPLCount.Name = "lblPPLCount";
            this.lblPPLCount.Size = new System.Drawing.Size(24, 28);
            this.lblPPLCount.TabIndex = 30;
            this.lblPPLCount.Text = "0";
            // 
            // txtSearchPpl
            // 
            this.txtSearchPpl.Location = new System.Drawing.Point(349, 139);
            this.txtSearchPpl.Multiline = true;
            this.txtSearchPpl.Name = "txtSearchPpl";
            this.txtSearchPpl.Size = new System.Drawing.Size(226, 38);
            this.txtSearchPpl.TabIndex = 29;
            this.txtSearchPpl.Visible = false;
            this.txtSearchPpl.TextChanged += new System.EventHandler(this.txtSearchPpl_TextChanged);
            this.txtSearchPpl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchPpl_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(23, 577);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 28);
            this.label3.TabIndex = 28;
            this.label3.Text = "# Record";
            // 
            // cbFilterby
            // 
            this.cbFilterby.BackColor = System.Drawing.Color.Silver;
            this.cbFilterby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterby.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterby.FormattingEnabled = true;
            this.cbFilterby.Items.AddRange(new object[] {
            "None",
            "PersonID",
            "NationalNo",
            "FirstName",
            "SecondName",
            "ThirdName",
            "LastName",
            "Gender",
            "CountryName",
            "Phone",
            "Email"});
            this.cbFilterby.Location = new System.Drawing.Point(145, 140);
            this.cbFilterby.Name = "cbFilterby";
            this.cbFilterby.Size = new System.Drawing.Size(189, 36);
            this.cbFilterby.TabIndex = 27;
            this.cbFilterby.SelectedIndexChanged += new System.EventHandler(this.cbFilterby_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(32, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 28);
            this.label2.TabIndex = 26;
            this.label2.Text = "Filter By :";
            // 
            // DvPeople
            // 
            this.DvPeople.AllowUserToAddRows = false;
            this.DvPeople.AllowUserToDeleteRows = false;
            this.DvPeople.AllowUserToResizeColumns = false;
            this.DvPeople.AllowUserToResizeRows = false;
            this.DvPeople.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DvPeople.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DvPeople.ColumnHeadersHeight = 29;
            this.DvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DvPeople.ContextMenuStrip = this.cmsApps;
            this.DvPeople.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DvPeople.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DvPeople.ImeMode = System.Windows.Forms.ImeMode.On;
            this.DvPeople.Location = new System.Drawing.Point(15, 192);
            this.DvPeople.Name = "DvPeople";
            this.DvPeople.ReadOnly = true;
            this.DvPeople.RowHeadersVisible = false;
            this.DvPeople.RowHeadersWidth = 51;
            this.DvPeople.RowTemplate.Height = 24;
            this.DvPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DvPeople.ShowCellErrors = false;
            this.DvPeople.ShowCellToolTips = false;
            this.DvPeople.ShowEditingIcon = false;
            this.DvPeople.ShowRowErrors = false;
            this.DvPeople.Size = new System.Drawing.Size(1563, 370);
            this.DvPeople.TabIndex = 25;
            this.DvPeople.VirtualMode = true;
            // 
            // cmsApps
            // 
            this.cmsApps.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsApps.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsApps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.addNewPersonToolStripMenuItem,
            this.toolStripSeparator1,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.sendEmailToolStripMenuItem,
            this.callPhoneToolStripMenuItem});
            this.cmsApps.Name = "contextMenuStrip1";
            this.cmsApps.Size = new System.Drawing.Size(282, 320);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(278, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(278, 6);
            // 
            // lblAddUpdTitle
            // 
            this.lblAddUpdTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAddUpdTitle.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddUpdTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblAddUpdTitle.Location = new System.Drawing.Point(12, 25);
            this.lblAddUpdTitle.Name = "lblAddUpdTitle";
            this.lblAddUpdTitle.Size = new System.Drawing.Size(1566, 70);
            this.lblAddUpdTitle.TabIndex = 108;
            this.lblAddUpdTitle.Text = "Manage People";
            this.lblAddUpdTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.AutoSize = true;
            this.btnAddPerson.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddPerson.FlatAppearance.BorderSize = 12;
            this.btnAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPerson.Image = global::C19_Project.Properties.Resources.Add_Person_40;
            this.btnAddPerson.Location = new System.Drawing.Point(1466, 117);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(100, 59);
            this.btnAddPerson.TabIndex = 32;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClose.FlatAppearance.BorderSize = 38;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::C19_Project.Properties.Resources.Close_321;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1436, 580);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(130, 49);
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Image = global::C19_Project.Properties.Resources.PersonDetails_32;
            this.showDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(281, 46);
            this.showDetailsToolStripMenuItem.Text = "Show Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // addNewPersonToolStripMenuItem
            // 
            this.addNewPersonToolStripMenuItem.Image = global::C19_Project.Properties.Resources.Add_Person_40;
            this.addNewPersonToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addNewPersonToolStripMenuItem.Name = "addNewPersonToolStripMenuItem";
            this.addNewPersonToolStripMenuItem.Size = new System.Drawing.Size(281, 46);
            this.addNewPersonToolStripMenuItem.Text = "Add New Person";
            this.addNewPersonToolStripMenuItem.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::C19_Project.Properties.Resources.edit_32;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(281, 46);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::C19_Project.Properties.Resources.Delete_32;
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(281, 46);
            this.deleteToolStripMenuItem.Text = "delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // sendEmailToolStripMenuItem
            // 
            this.sendEmailToolStripMenuItem.Image = global::C19_Project.Properties.Resources.send_email_32;
            this.sendEmailToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sendEmailToolStripMenuItem.Name = "sendEmailToolStripMenuItem";
            this.sendEmailToolStripMenuItem.Size = new System.Drawing.Size(281, 46);
            this.sendEmailToolStripMenuItem.Text = "Send Email";
            // 
            // callPhoneToolStripMenuItem
            // 
            this.callPhoneToolStripMenuItem.Image = global::C19_Project.Properties.Resources.call_32;
            this.callPhoneToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.callPhoneToolStripMenuItem.Name = "callPhoneToolStripMenuItem";
            this.callPhoneToolStripMenuItem.Size = new System.Drawing.Size(281, 46);
            this.callPhoneToolStripMenuItem.Text = "Call Phone";
            // 
            // frmManagePeople
            // 
            this.AcceptButton = this.btnAddPerson;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1590, 651);
            this.Controls.Add(this.lblAddUpdTitle);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblPPLCount);
            this.Controls.Add(this.txtSearchPpl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbFilterby);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DvPeople);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "frmManagePeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmManagePeople";
            this.Load += new System.EventHandler(this.frmManagePeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DvPeople)).EndInit();
            this.cmsApps.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblPPLCount;
        private System.Windows.Forms.TextBox txtSearchPpl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFilterby;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DvPeople;
        private System.Windows.Forms.Label lblAddUpdTitle;
        private System.Windows.Forms.ContextMenuStrip cmsApps;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem sendEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem callPhoneToolStripMenuItem;
    }
}