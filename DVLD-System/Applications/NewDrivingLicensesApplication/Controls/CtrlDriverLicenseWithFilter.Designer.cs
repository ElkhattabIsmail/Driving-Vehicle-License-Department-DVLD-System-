namespace C19_Project.Applications.InterNationalDrivingLicenseApplication.Controls
{
    partial class CtrlDriverLicenseWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.txtLicenseID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlDriverLicenseInfo1 = new C19_Project.Applications.InterNationalDrivingLicenseApplication.Controls.CtrlDriverLicenseInfo();
            this.btnFindUserPersonID = new System.Windows.Forms.Button();
            this.gbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.btnFindUserPersonID);
            this.gbFilters.Controls.Add(this.txtLicenseID);
            this.gbFilters.Controls.Add(this.label1);
            this.gbFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilters.Location = new System.Drawing.Point(9, 4);
            this.gbFilters.Margin = new System.Windows.Forms.Padding(4);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Padding = new System.Windows.Forms.Padding(4);
            this.gbFilters.Size = new System.Drawing.Size(968, 91);
            this.gbFilters.TabIndex = 18;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Filter";
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicenseID.Location = new System.Drawing.Point(151, 32);
            this.txtLicenseID.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.Size = new System.Drawing.Size(422, 30);
            this.txtLicenseID.TabIndex = 17;
            this.txtLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicenseID_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "LicenseID:";
            // 
            // ctrlDriverLicenseInfo1
            // 
            this.ctrlDriverLicenseInfo1.Location = new System.Drawing.Point(3, 94);
            this.ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            this.ctrlDriverLicenseInfo1.Size = new System.Drawing.Size(1069, 357);
            this.ctrlDriverLicenseInfo1.TabIndex = 19;
            // 
            // btnFindUserPersonID
            // 
            this.btnFindUserPersonID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindUserPersonID.Image = global::C19_Project.Properties.Resources.License_View_32;
            this.btnFindUserPersonID.Location = new System.Drawing.Point(623, 24);
            this.btnFindUserPersonID.Margin = new System.Windows.Forms.Padding(4);
            this.btnFindUserPersonID.Name = "btnFindUserPersonID";
            this.btnFindUserPersonID.Size = new System.Drawing.Size(68, 47);
            this.btnFindUserPersonID.TabIndex = 18;
            this.btnFindUserPersonID.UseVisualStyleBackColor = true;
            this.btnFindUserPersonID.Click += new System.EventHandler(this.btnFindUserPersonID_Click);
            // 
            // CtrlDriverLicenseWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlDriverLicenseInfo1);
            this.Controls.Add(this.gbFilters);
            this.Name = "CtrlDriverLicenseWithFilter";
            this.Size = new System.Drawing.Size(1078, 457);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.Button btnFindUserPersonID;
        private System.Windows.Forms.Label label1;
        private CtrlDriverLicenseInfo ctrlDriverLicenseInfo1;
        public System.Windows.Forms.TextBox txtLicenseID;
    }
}
