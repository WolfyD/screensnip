using System;
using System.Windows.Forms;

namespace PerpetualUpdater
{
    public partial class f_Warn : Form
    {
        public f_Warn()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (cb_NoWarn.Checked)
            {
                Properties.Settings.Default.s_WarnAtHide = false;
                Properties.Settings.Default.Save();
            }

            this.Close();
        }
    }
}
