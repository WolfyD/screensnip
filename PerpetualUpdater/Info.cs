using System;
using System.Windows.Forms;

namespace PerpetualUpdater
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
            Load += Info_Load;
        }

        private void Info_Load(object sender, EventArgs e)
        {
            rtb_Info.Rtf = Properties.Resources.info;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
