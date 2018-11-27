namespace Motorbike.ucReport
{
    partial class frmReport
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
            this.FormCrys = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnLisCustomer = new MetroFramework.Controls.MetroButton();
            this.btnEmployee = new MetroFramework.Controls.MetroButton();
            this.btnListMoto = new MetroFramework.Controls.MetroButton();
            this.btnBack = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // FormCrys
            // 
            this.FormCrys.ActiveViewIndex = -1;
            this.FormCrys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FormCrys.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormCrys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormCrys.Location = new System.Drawing.Point(0, 0);
            this.FormCrys.Name = "FormCrys";
            this.FormCrys.Size = new System.Drawing.Size(1031, 674);
            this.FormCrys.TabIndex = 0;
            // 
            // btnLisCustomer
            // 
            this.btnLisCustomer.Location = new System.Drawing.Point(36, 96);
            this.btnLisCustomer.Name = "btnLisCustomer";
            this.btnLisCustomer.Size = new System.Drawing.Size(120, 23);
            this.btnLisCustomer.TabIndex = 1;
            this.btnLisCustomer.Text = "List customer";
            this.btnLisCustomer.Click += new System.EventHandler(this.btnLisCustomer_Click);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Location = new System.Drawing.Point(36, 154);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(120, 23);
            this.btnEmployee.TabIndex = 2;
            this.btnEmployee.Text = "List employees";
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);
            // 
            // btnListMoto
            // 
            this.btnListMoto.Location = new System.Drawing.Point(36, 208);
            this.btnListMoto.Name = "btnListMoto";
            this.btnListMoto.Size = new System.Drawing.Size(120, 23);
            this.btnListMoto.TabIndex = 3;
            this.btnListMoto.Text = "List motorbike";
            this.btnListMoto.Click += new System.EventHandler(this.btnListMoto_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(36, 618);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnListMoto);
            this.Controls.Add(this.btnEmployee);
            this.Controls.Add(this.btnLisCustomer);
            this.Controls.Add(this.FormCrys);
            this.Name = "frmReport";
            this.Size = new System.Drawing.Size(1031, 674);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer FormCrys;
        private MetroFramework.Controls.MetroButton btnLisCustomer;
        private MetroFramework.Controls.MetroButton btnEmployee;
        private MetroFramework.Controls.MetroButton btnListMoto;
        private MetroFramework.Controls.MetroButton btnBack;
    }
}
