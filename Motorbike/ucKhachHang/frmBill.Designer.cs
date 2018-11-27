namespace Motorbike.ucKhachHang
{
    partial class frmBill
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
            this.txtQuantity = new MetroFramework.Controls.MetroTextBox();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.btnXacNhan = new MetroFramework.Controls.MetroButton();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.txtTotalMoney = new MetroFramework.Controls.MetroTextBox();
            this.txtCUSID = new MetroFramework.Controls.MetroTextBox();
            this.txtBID = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtMOTOID = new MetroFramework.Controls.MetroTextBox();
            this.dtpDateBuy = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(126, 231);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(156, 23);
            this.txtQuantity.TabIndex = 29;
            // 
            // metroButton2
            // 
            this.metroButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.metroButton2.Location = new System.Drawing.Point(207, 316);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(75, 23);
            this.metroButton2.TabIndex = 28;
            this.metroButton2.Text = "Cancel";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnXacNhan.Location = new System.Drawing.Point(126, 316);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(75, 23);
            this.btnXacNhan.TabIndex = 27;
            this.btnXacNhan.Text = "Confirm";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(27, 194);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(64, 19);
            this.metroLabel6.TabIndex = 25;
            this.metroLabel6.Text = "Date Buy:";
            // 
            // txtTotalMoney
            // 
            this.txtTotalMoney.Location = new System.Drawing.Point(126, 270);
            this.txtTotalMoney.Name = "txtTotalMoney";
            this.txtTotalMoney.ReadOnly = true;
            this.txtTotalMoney.Size = new System.Drawing.Size(156, 23);
            this.txtTotalMoney.TabIndex = 23;
            // 
            // txtCUSID
            // 
            this.txtCUSID.Location = new System.Drawing.Point(126, 107);
            this.txtCUSID.Name = "txtCUSID";
            this.txtCUSID.ReadOnly = true;
            this.txtCUSID.Size = new System.Drawing.Size(156, 23);
            this.txtCUSID.TabIndex = 22;
            // 
            // txtBID
            // 
            this.txtBID.Location = new System.Drawing.Point(126, 63);
            this.txtBID.Name = "txtBID";
            this.txtBID.Size = new System.Drawing.Size(156, 23);
            this.txtBID.TabIndex = 21;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(29, 274);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(83, 19);
            this.metroLabel5.TabIndex = 20;
            this.metroLabel5.Text = "Total money:";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(27, 235);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(61, 19);
            this.metroLabel4.TabIndex = 19;
            this.metroLabel4.Text = "Quantity:";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(28, 152);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(60, 19);
            this.metroLabel3.TabIndex = 18;
            this.metroLabel3.Text = "Moto ID:";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(28, 111);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(53, 19);
            this.metroLabel2.TabIndex = 17;
            this.metroLabel2.Text = "CUS ID:";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(28, 67);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(32, 19);
            this.metroLabel1.TabIndex = 16;
            this.metroLabel1.Text = "BID:";
            // 
            // txtMOTOID
            // 
            this.txtMOTOID.Location = new System.Drawing.Point(126, 152);
            this.txtMOTOID.Name = "txtMOTOID";
            this.txtMOTOID.Size = new System.Drawing.Size(156, 23);
            this.txtMOTOID.TabIndex = 30;
            // 
            // dtpDateBuy
            // 
            this.dtpDateBuy.Location = new System.Drawing.Point(126, 193);
            this.dtpDateBuy.Name = "dtpDateBuy";
            this.dtpDateBuy.Size = new System.Drawing.Size(156, 20);
            this.dtpDateBuy.TabIndex = 32;
            // 
            // frmBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 358);
            this.Controls.Add(this.dtpDateBuy);
            this.Controls.Add(this.txtMOTOID);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.txtTotalMoney);
            this.Controls.Add(this.txtCUSID);
            this.Controls.Add(this.txtBID);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Name = "frmBill";
            this.Text = "Information of order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtQuantity;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton btnXacNhan;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtTotalMoney;
        private MetroFramework.Controls.MetroTextBox txtCUSID;
        private MetroFramework.Controls.MetroTextBox txtBID;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtMOTOID;
        private System.Windows.Forms.DateTimePicker dtpDateBuy;
    }
}