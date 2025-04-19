namespace C19_Project.People.Controls
{
    partial class CtrlFilterPerson
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
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnSearchonPerson = new System.Windows.Forms.Button();
            this.txtSearch4 = new System.Windows.Forms.TextBox();
            this.cbFilterby4 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ctrlPersonCard1 = new C19_Project.People.Controls.CtrlPersonCard();
            this.gbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.btnAddPerson);
            this.gbFilters.Controls.Add(this.btnSearchonPerson);
            this.gbFilters.Controls.Add(this.txtSearch4);
            this.gbFilters.Controls.Add(this.cbFilterby4);
            this.gbFilters.Controls.Add(this.label14);
            this.gbFilters.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilters.Location = new System.Drawing.Point(9, -2);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(1063, 96);
            this.gbFilters.TabIndex = 0;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Filter";
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Image = global::C19_Project.Properties.Resources.AddPerson_32;
            this.btnAddPerson.Location = new System.Drawing.Point(777, 23);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(59, 56);
            this.btnAddPerson.TabIndex = 2;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnSearchonPerson
            // 
            this.btnSearchonPerson.Image = global::C19_Project.Properties.Resources.SearchPerson;
            this.btnSearchonPerson.Location = new System.Drawing.Point(702, 23);
            this.btnSearchonPerson.Name = "btnSearchonPerson";
            this.btnSearchonPerson.Size = new System.Drawing.Size(59, 56);
            this.btnSearchonPerson.TabIndex = 1;
            this.btnSearchonPerson.UseVisualStyleBackColor = true;
            this.btnSearchonPerson.Click += new System.EventHandler(this.btnSearchonPerson_Click);
            // 
            // txtSearch4
            // 
            this.txtSearch4.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch4.Location = new System.Drawing.Point(410, 34);
            this.txtSearch4.Name = "txtSearch4";
            this.txtSearch4.Size = new System.Drawing.Size(262, 36);
            this.txtSearch4.TabIndex = 0;
            this.txtSearch4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch4_KeyPress);
            // 
            // cbFilterby4
            // 
            this.cbFilterby4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterby4.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterby4.FormattingEnabled = true;
            this.cbFilterby4.Items.AddRange(new object[] {
            "PersonID",
            "NationalNo"});
            this.cbFilterby4.Location = new System.Drawing.Point(159, 35);
            this.cbFilterby4.Name = "cbFilterby4";
            this.cbFilterby4.Size = new System.Drawing.Size(242, 36);
            this.cbFilterby4.TabIndex = 5;
            this.cbFilterby4.SelectedIndexChanged += new System.EventHandler(this.cbFilterby4_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(59, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 28);
            this.label14.TabIndex = 4;
            this.label14.Text = "Filter By:";
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Location = new System.Drawing.Point(8, 109);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(1063, 265);
            this.ctrlPersonCard1.TabIndex = 1;
            // 
            // CtrlFilterPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlPersonCard1);
            this.Controls.Add(this.gbFilters);
            this.Name = "CtrlFilterPerson";
            this.Size = new System.Drawing.Size(1089, 385);
            this.Load += new System.EventHandler(this.CtrlFilterPerson_Load);
            this.gbFilters.ResumeLayout(false);
            this.gbFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.TextBox txtSearch4;
        private System.Windows.Forms.ComboBox cbFilterby4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnSearchonPerson;
        private CtrlPersonCard ctrlPersonCard1;
    }
}
