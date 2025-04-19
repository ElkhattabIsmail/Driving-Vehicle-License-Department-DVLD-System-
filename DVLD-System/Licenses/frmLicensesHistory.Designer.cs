namespace C19_Project.Licenses.International_Licenses
{
    partial class frmLicensesHistory
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctrlDriverLicneses1 = new C19_Project.Licenses.International_Licenses.Controls.CtrlDriverLicneses();
            this.ctrlFilterPerson1 = new C19_Project.People.Controls.CtrlFilterPerson();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Maroon;
            this.lblTitle.Location = new System.Drawing.Point(12, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1383, 54);
            this.lblTitle.TabIndex = 175;
            this.lblTitle.Text = "Licenses History";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::C19_Project.Properties.Resources.PersonLicenseHistory_512;
            this.pictureBox1.Location = new System.Drawing.Point(15, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(290, 376);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 177;
            this.pictureBox1.TabStop = false;
            // 
            // ctrlDriverLicneses1
            // 
            this.ctrlDriverLicneses1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlDriverLicneses1.Location = new System.Drawing.Point(15, 442);
            this.ctrlDriverLicneses1.Name = "ctrlDriverLicneses1";
            this.ctrlDriverLicneses1.Size = new System.Drawing.Size(1380, 296);
            this.ctrlDriverLicneses1.TabIndex = 178;
            // 
            // ctrlFilterPerson1
            // 
            this.ctrlFilterPerson1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlFilterPerson1.FilterEnabled = true;
            this.ctrlFilterPerson1.Location = new System.Drawing.Point(311, 59);
            this.ctrlFilterPerson1.Name = "ctrlFilterPerson1";
            this.ctrlFilterPerson1.ShowAddPerson = true;
            this.ctrlFilterPerson1.Size = new System.Drawing.Size(1083, 376);
            this.ctrlFilterPerson1.TabIndex = 176;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::C19_Project.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1268, 744);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 49);
            this.btnClose.TabIndex = 226;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 804);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlDriverLicneses1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ctrlFilterPerson1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLicensesHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Licenses History";
            this.Load += new System.EventHandler(this.frmLicensesHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private People.Controls.CtrlFilterPerson ctrlFilterPerson1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Controls.CtrlDriverLicneses ctrlDriverLicneses1;
        private System.Windows.Forms.Button btnClose;
    }
}