using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WolfPaw_ScreenSnip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TopMost = true;
            Icon = Properties.Resources.scissors;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            //TODO:EXIT

            Application.Exit();
        }

        private void brn_New_Click(object sender, EventArgs e)
        {
            f_Screen fs = new f_Screen();
            fs.Show();
        }
    }
}
