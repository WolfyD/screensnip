using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WolfPaw_ScreenSnip
{
    public partial class uc_ValueButton : UserControl
    {
        Timer t = new Timer() { Interval = 1 };
        bool IsOpened = false;
        int slideIndex = 0;
        int slideMax = 10;

        public uc_ValueButton()
        {
            InitializeComponent();

            Load += Uc_ValueButton_Load;
            t.Tick += T_Tick;
        }

        private void Uc_ValueButton_Load(object sender, EventArgs e)
        {
            pb_Image.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Image.Image = Properties.Resources.clock;

            num_Val.Value = Properties.Settings.Default.s_delayLength / 1000;

            if (Properties.Settings.Default.s_hasDelay)
            {
                IsOpened = false;
                myClick();
            }
            
        }

        private void T_Tick(object sender, EventArgs e)
        {
            slideIndex++;

            if (IsOpened)
            {
                Width -= 7;
            }
            else
            {
                Width += 7;
            }

            if(slideIndex == slideMax) { slideIndex = 0; t.Stop(); IsOpened = !IsOpened; Enabled = true; SetSave(); }
        }

        private void pb_Image_Click(object sender, EventArgs e)
        {
            myClick();
        }

        private void myClick()
        {
            Enabled = false;
            t.Start();
        }

        private void SetSave()
        {
            Properties.Settings.Default.s_hasDelay = IsOpened;
            Properties.Settings.Default.Save();
        }

        private void btn_Set_Click(object sender, EventArgs e)
        {
            if (num_Val.Value > 0)
            {
                Properties.Settings.Default.s_delayLength = (int)num_Val.Value * 1000;
            }
            else
            {
                myClick();
            }

            btn_Set.Hide();

            Properties.Settings.Default.Save();
        }

        private void num_Val_ValueChanged(object sender, EventArgs e)
        {
            if(num_Val.Value == Properties.Settings.Default.s_delayLength / 1000){
                btn_Set.Hide();
            }
            else
            {
                btn_Set.Show();
            }
        }
    }
}
