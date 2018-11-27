namespace Motorbike
{
    partial class Form1
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
            this.mPanelChinh = new MetroFramework.Controls.MetroPanel();
            this.SuspendLayout();
            // 
            // mPanelChinh
            // 
            this.mPanelChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mPanelChinh.HorizontalScrollbarBarColor = true;
            this.mPanelChinh.HorizontalScrollbarHighlightOnWheel = false;
            this.mPanelChinh.HorizontalScrollbarSize = 10;
            this.mPanelChinh.Location = new System.Drawing.Point(20, 60);
            this.mPanelChinh.Name = "mPanelChinh";
            this.mPanelChinh.Size = new System.Drawing.Size(944, 398);
            this.mPanelChinh.TabIndex = 0;
            this.mPanelChinh.VerticalScrollbarBarColor = true;
            this.mPanelChinh.VerticalScrollbarHighlightOnWheel = false;
            this.mPanelChinh.VerticalScrollbarSize = 10;
            this.mPanelChinh.Paint += new System.Windows.Forms.PaintEventHandler(this.mPanelChinh_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 478);
            this.Controls.Add(this.mPanelChinh);
            this.Name = "Form1";
            this.Text = "Motorbike Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel mPanelChinh;
    }
}

