using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;

namespace Motorbike.ucHeThong
{
    public partial class ucProcessBarcs : UserControl
    {
        public MetroProgressBar mPB
        {
            get
            {
                return this.mProcessBar;
            }
            set
            {
                this.mProcessBar = value;
            }
        }
        public MetroLabel lblPC
        {
            get
            {
                return this.mlbPercent;
            }
            set
            {
                this.mlbPercent = value;
            }
        }
        public ucProcessBarcs()
        {
            InitializeComponent();
        }
    }
}
