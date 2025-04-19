namespace C19_Project.ManageAppsTests.TakeTests
{
    partial class frmTestsAppointments
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAppointmentsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DvgAppointments = new System.Windows.Forms.DataGridView();
            this.cms4Appointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctrlDrivingLicenseInformations1 = new C19_Project.ManageAppsTests.Controls.ctrlDrivingLicenseInformations();
            this.btnAddAppointement = new System.Windows.Forms.Button();
            this.pbTestType = new System.Windows.Forms.PictureBox();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DvgAppointments)).BeginInit();
            this.cms4Appointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 106);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1117, 51);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Test Appointments";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 557);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 25);
            this.label2.TabIndex = 199;
            this.label2.Text = "Appointments :";
            // 
            // lblAppointmentsCount
            // 
            this.lblAppointmentsCount.AutoSize = true;
            this.lblAppointmentsCount.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppointmentsCount.Location = new System.Drawing.Point(138, 782);
            this.lblAppointmentsCount.Name = "lblAppointmentsCount";
            this.lblAppointmentsCount.Size = new System.Drawing.Size(23, 28);
            this.lblAppointmentsCount.TabIndex = 201;
            this.lblAppointmentsCount.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 780);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 28);
            this.label3.TabIndex = 200;
            this.label3.Text = "# Records :";
            // 
            // DvgAppointments
            // 
            this.DvgAppointments.AllowUserToAddRows = false;
            this.DvgAppointments.AllowUserToDeleteRows = false;
            this.DvgAppointments.AllowUserToResizeRows = false;
            this.DvgAppointments.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DvgAppointments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.DvgAppointments.ColumnHeadersHeight = 29;
            this.DvgAppointments.ContextMenuStrip = this.cms4Appointments;
            this.DvgAppointments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DvgAppointments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DvgAppointments.Location = new System.Drawing.Point(24, 586);
            this.DvgAppointments.Name = "DvgAppointments";
            this.DvgAppointments.ReadOnly = true;
            this.DvgAppointments.RowHeadersWidth = 51;
            this.DvgAppointments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DvgAppointments.RowTemplate.Height = 24;
            this.DvgAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DvgAppointments.ShowCellErrors = false;
            this.DvgAppointments.ShowCellToolTips = false;
            this.DvgAppointments.ShowEditingIcon = false;
            this.DvgAppointments.ShowRowErrors = false;
            this.DvgAppointments.Size = new System.Drawing.Size(1077, 192);
            this.DvgAppointments.TabIndex = 203;
            this.DvgAppointments.VirtualMode = true;
            // 
            // cms4Appointments
            // 
            this.cms4Appointments.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cms4Appointments.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms4Appointments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.cms4Appointments.Name = "cms4Appointments";
            this.cms4Appointments.Size = new System.Drawing.Size(183, 80);
            // 
            // ctrlDrivingLicenseInformations1
            // 
            this.ctrlDrivingLicenseInformations1.Location = new System.Drawing.Point(12, 162);
            this.ctrlDrivingLicenseInformations1.Name = "ctrlDrivingLicenseInformations1";
            this.ctrlDrivingLicenseInformations1.Size = new System.Drawing.Size(1108, 360);
            this.ctrlDrivingLicenseInformations1.TabIndex = 207;
            // 
            // btnAddAppointement
            // 
            this.btnAddAppointement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAppointement.Image = global::C19_Project.Properties.Resources.AddAppointment_32;
            this.btnAddAppointement.Location = new System.Drawing.Point(1026, 523);
            this.btnAddAppointement.Name = "btnAddAppointement";
            this.btnAddAppointement.Size = new System.Drawing.Size(75, 54);
            this.btnAddAppointement.TabIndex = 206;
            this.btnAddAppointement.UseVisualStyleBackColor = true;
            this.btnAddAppointement.Click += new System.EventHandler(this.button1_Add_Click_1);
            // 
            // pbTestType
            // 
            this.pbTestType.Image = global::C19_Project.Properties.Resources.Vision_512;
            this.pbTestType.Location = new System.Drawing.Point(490, 6);
            this.pbTestType.Name = "pbTestType";
            this.pbTestType.Size = new System.Drawing.Size(170, 117);
            this.pbTestType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestType.TabIndex = 205;
            this.pbTestType.TabStop = false;
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::C19_Project.Properties.Resources.edit_32;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(182, 38);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::C19_Project.Properties.Resources.Retake_Test_322;
            this.takeTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(182, 38);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::C19_Project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(976, 784);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 50);
            this.btnClose.TabIndex = 202;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmTestsAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 840);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrlDrivingLicenseInformations1);
            this.Controls.Add(this.btnAddAppointement);
            this.Controls.Add(this.pbTestType);
            this.Controls.Add(this.DvgAppointments);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblAppointmentsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTestsAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Appointments";
            this.Load += new System.EventHandler(this.TestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DvgAppointments)).EndInit();
            this.cms4Appointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAppointmentsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView DvgAppointments;
        private System.Windows.Forms.PictureBox pbTestType;
        private System.Windows.Forms.Button btnAddAppointement;
        private Controls.ctrlDrivingLicenseInformations ctrlDrivingLicenseInformations1;
        private System.Windows.Forms.ContextMenuStrip cms4Appointments;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}