namespace Motorbike.ucKhachHang
{
    partial class ShowCheckout
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
            this.DGV_Show = new System.Windows.Forms.DataGridView();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.txtTOTAL = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Show)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Show
            // 
            this.DGV_Show.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.DGV_Show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Show.Location = new System.Drawing.Point(13, 52);
            this.DGV_Show.Name = "DGV_Show";
            this.DGV_Show.Size = new System.Drawing.Size(678, 325);
            this.DGV_Show.TabIndex = 0;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(13, 380);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 1;
            this.metroButton1.Text = "Print order";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // txtTOTAL
            // 
            this.txtTOTAL.Location = new System.Drawing.Point(566, 380);
            this.txtTOTAL.Name = "txtTOTAL";
            this.txtTOTAL.Size = new System.Drawing.Size(125, 23);
            this.txtTOTAL.TabIndex = 2;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(447, 380);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(113, 25);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Total money:";
            // 
            // ShowCheckout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 416);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtTOTAL);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.DGV_Show);
            this.Name = "ShowCheckout";
            this.Text = "ShowCheckout";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Show)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_Show;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTextBox txtTOTAL;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}