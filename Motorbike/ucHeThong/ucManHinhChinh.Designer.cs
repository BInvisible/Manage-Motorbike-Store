namespace Motorbike.ucHeThong
{
    partial class ucManHinhChinh
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mPanelChinh = new MetroFramework.Controls.MetroPanel();
            this.mPanelContainer = new MetroFramework.Controls.MetroPanel();
            this.btnBack = new MetroFramework.Controls.MetroTile();
            this.btnEmployee = new MetroFramework.Controls.MetroTile();
            this.btnStatistics = new MetroFramework.Controls.MetroTile();
            this.btnCustomer = new MetroFramework.Controls.MetroTile();
            this.btnMotorbike = new MetroFramework.Controls.MetroTile();
            this.timerManHinhChinh = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.mPanelChinh.SuspendLayout();
            this.mPanelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.mPanelChinh, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 700);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // mPanelChinh
            // 
            this.mPanelChinh.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mPanelChinh.Controls.Add(this.mPanelContainer);
            this.mPanelChinh.CustomBackground = true;
            this.mPanelChinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mPanelChinh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mPanelChinh.HorizontalScrollbarBarColor = true;
            this.mPanelChinh.HorizontalScrollbarHighlightOnWheel = false;
            this.mPanelChinh.HorizontalScrollbarSize = 10;
            this.mPanelChinh.Location = new System.Drawing.Point(32, 9);
            this.mPanelChinh.Name = "mPanelChinh";
            this.mPanelChinh.Size = new System.Drawing.Size(935, 682);
            this.mPanelChinh.TabIndex = 0;
            this.mPanelChinh.VerticalScrollbarBarColor = true;
            this.mPanelChinh.VerticalScrollbarHighlightOnWheel = false;
            this.mPanelChinh.VerticalScrollbarSize = 10;
            this.mPanelChinh.Paint += new System.Windows.Forms.PaintEventHandler(this.mPanelChinh_Paint);
            // 
            // mPanelContainer
            // 
            this.mPanelContainer.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mPanelContainer.Controls.Add(this.btnBack);
            this.mPanelContainer.Controls.Add(this.btnEmployee);
            this.mPanelContainer.Controls.Add(this.btnStatistics);
            this.mPanelContainer.Controls.Add(this.btnCustomer);
            this.mPanelContainer.Controls.Add(this.btnMotorbike);
            this.mPanelContainer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mPanelContainer.HorizontalScrollbarBarColor = true;
            this.mPanelContainer.HorizontalScrollbarHighlightOnWheel = false;
            this.mPanelContainer.HorizontalScrollbarSize = 10;
            this.mPanelContainer.Location = new System.Drawing.Point(0, 0);
            this.mPanelContainer.Name = "mPanelContainer";
            this.mPanelContainer.Size = new System.Drawing.Size(1000, 680);
            this.mPanelContainer.TabIndex = 2;
            this.mPanelContainer.VerticalScrollbarBarColor = true;
            this.mPanelContainer.VerticalScrollbarHighlightOnWheel = false;
            this.mPanelContainer.VerticalScrollbarSize = 10;
            this.mPanelContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.mPanelContainer_Paint);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.btnBack.CustomBackground = true;
            this.btnBack.CustomForeColor = true;
            this.btnBack.Location = new System.Drawing.Point(449, 422);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(401, 177);
            this.btnBack.TabIndex = 7;
            this.btnBack.Tag = "NhanVien";
            this.btnBack.Text = "Log Out";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnBack.TileImage = global::Motorbike.Properties.Resources.logout;
            this.btnBack.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnBack.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnBack.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.btnBack.UseTileImage = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click_1);
            // 
            // btnEmployee
            // 
            this.btnEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.btnEmployee.CustomBackground = true;
            this.btnEmployee.CustomForeColor = true;
            this.btnEmployee.Location = new System.Drawing.Point(449, 59);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(401, 177);
            this.btnEmployee.TabIndex = 6;
            this.btnEmployee.Tag = "NhanVien";
            this.btnEmployee.Text = "Employee";
            this.btnEmployee.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnEmployee.TileImage = global::Motorbike.Properties.Resources.employee_data_management;
            this.btnEmployee.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnEmployee.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnEmployee.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.btnEmployee.UseTileImage = true;
            this.btnEmployee.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.btnStatistics.CustomBackground = true;
            this.btnStatistics.CustomForeColor = true;
            this.btnStatistics.Location = new System.Drawing.Point(449, 239);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(401, 177);
            this.btnStatistics.TabIndex = 5;
            this.btnStatistics.Tag = "ucSaR";
            this.btnStatistics.Text = "Statistics and Reports";
            this.btnStatistics.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnStatistics.TileImage = global::Motorbike.Properties.Resources.statistics_and_reports;
            this.btnStatistics.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStatistics.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnStatistics.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.btnStatistics.UseTileImage = true;
            this.btnStatistics.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.btnCustomer.CustomBackground = true;
            this.btnCustomer.CustomForeColor = true;
            this.btnCustomer.Location = new System.Drawing.Point(42, 239);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(401, 177);
            this.btnCustomer.TabIndex = 3;
            this.btnCustomer.Tag = "ucCustomer";
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnCustomer.TileImage = global::Motorbike.Properties.Resources._149449;
            this.btnCustomer.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCustomer.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnCustomer.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.btnCustomer.UseTileImage = true;
            this.btnCustomer.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnMotorbike
            // 
            this.btnMotorbike.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(137)))), ((int)(((byte)(239)))));
            this.btnMotorbike.CustomBackground = true;
            this.btnMotorbike.CustomForeColor = true;
            this.btnMotorbike.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMotorbike.Location = new System.Drawing.Point(42, 59);
            this.btnMotorbike.Name = "btnMotorbike";
            this.btnMotorbike.Size = new System.Drawing.Size(401, 174);
            this.btnMotorbike.TabIndex = 2;
            this.btnMotorbike.Tag = "ucManageMotorbike";
            this.btnMotorbike.Text = "Manage Motorbike";
            this.btnMotorbike.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnMotorbike.TileImage = global::Motorbike.Properties.Resources._0001_128;
            this.btnMotorbike.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMotorbike.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.btnMotorbike.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.btnMotorbike.UseTileImage = true;
            this.btnMotorbike.Click += new System.EventHandler(this.btn_Click);
            // 
            // timerManHinhChinh
            // 
            this.timerManHinhChinh.Interval = 10;
            this.timerManHinhChinh.Tick += new System.EventHandler(this.timerManHinhChinh_Tick);
            // 
            // ucManHinhChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucManHinhChinh";
            this.Size = new System.Drawing.Size(1000, 700);
            this.Load += new System.EventHandler(this.ucManHinhChinh_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.mPanelChinh.ResumeLayout(false);
            this.mPanelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroPanel mPanelChinh;
        private MetroFramework.Controls.MetroPanel mPanelContainer;
        private MetroFramework.Controls.MetroTile btnMotorbike;
        private MetroFramework.Controls.MetroTile btnCustomer;
        private MetroFramework.Controls.MetroTile btnStatistics;
        private MetroFramework.Controls.MetroTile btnEmployee;
        private System.Windows.Forms.Timer timerManHinhChinh;
        private MetroFramework.Controls.MetroTile btnBack;
    }
}
