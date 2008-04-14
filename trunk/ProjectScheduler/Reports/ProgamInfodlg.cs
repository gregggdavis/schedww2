using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Scheduler.Reports
{
    public partial class ProgamInfodlg : DevExpress.XtraEditors.XtraForm
    {
        public ProgamInfodlg()
        {
            InitializeComponent();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}