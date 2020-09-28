using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Up2Site;
using WolfPaw___BetterDialogs;

namespace PerpetualUpdater
{
    public partial class MainForm : Form
    {
        Timer t = new Timer();
        int TimerCountdown = 0;
        Console console = new Console();
        
        public MainForm()
        {
            InitializeComponent();

            Load += Form1_Load;
            t.Interval = 1000;
            if (Properties.Settings.Default.s_TimeCheck > 0)
            {
                t.Start();
            }
            t.Tick += T_Tick;
            console.TextBox = tb_ConsoleOutput;

            this.Icon = Properties.Resources.update;
        }

        private string GetTimeFromTimer()
        {
            return (TimerCountdown / 3600).ToString().PadLeft(2, '0') + ":" + ((TimerCountdown % 3600) / 60).ToString().PadLeft(2, '0');
        }

        private void SetTimerCountdown()
        {
            TimerCountdown = Properties.Settings.Default.s_TimeCheck * 60;
        }

        private void LoadSettings()
        {
            SetTimerCountdown();

            cb_CreateIcon.Checked = Properties.Settings.Default.s_CreateIcon;

            if (Properties.Settings.Default.s_Architecture == "")
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    rb_x64.Checked = true;
                }
                else
                {
                    rb_x86.Checked = true;
                }
            }
            else
            {
                if (Properties.Settings.Default.s_Architecture == "x64")
                {
                    rb_x64.Checked = true;
                }
                else
                {
                    rb_x86.Checked = true;
                }
            }

            num_Minutes.Value = Properties.Settings.Default.s_TimeCheck;

            cb_StartMinimized.Checked = Properties.Settings.Default.s_StartMinimized;

            cb_IsSWW.Checked = Properties.Settings.Default.s_SWW;
        }

        private void LoadInfo()
        {
            string path = Properties.Settings.Default.s_Path;
            
            if (path != "" && Directory.Exists(path))
            {
                if(File.Exists(path + "\\WolfPaw ScreenSnip.exe"))
                {
                    lbl_IsInstalled.Text = "✓ - Installed";
                }
                else
                {
                    lbl_IsInstalled.Text = "✗ - Not Installed";
                    Properties.Settings.Default.s_CurrentVersion = "";
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                lbl_IsInstalled.Text = "✗ - Not Installed";
                Properties.Settings.Default.s_CurrentVersion = "";
                Properties.Settings.Default.Save();
            }

            lbl_Architecture.Text = Properties.Settings.Default.s_ArchitectureInstalled;

            lbl_Path.Text = Properties.Settings.Default.s_Path;

            lbl_CurrentVersion.Text = Properties.Settings.Default.s_CurrentVersion;

            var dat = Properties.Settings.Default.s_LastCheck;

            lbl_LastChecked.Text = dat.ToShortDateString() + " " + dat.ToShortTimeString();

            var ldat = Properties.Settings.Default.s_LastDownload;

            lbl_LastDownload.Text = ldat.ToShortDateString() + " " + ldat.ToShortTimeString();

        }

        private bool CheckIfPathOk()
        {
            string path = Properties.Settings.Default.s_Path;
            if (path == "" || Directory.Exists(path) == false)
            {
                MessageBox.Show("There is no path set up to save the program to.\r\nPlease open Settings and create/select a directory to save to.", "No path specified.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void CheckUpdate(bool IsManual = false)
        {
            if (!CheckIfPathOk())
            {
                return;
            }

            UpdateManager um = new UpdateManager();
            um.ConnectFtp(credentials.username, credentials.password, credentials.hostname);
            um.TryUpdate(IsManual);
            Properties.Settings.Default.Save();
            LoadInfo();
        }

        private void Exit()
        {
            if (MessageBox.Show(this, "Are you sure you wish to exit the updater?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                ni_Icon.Icon = null;
                ni_Icon.Visible = false;
                ni_Icon.Dispose();
                Application.Exit();
            }
        }

        private void T_Tick(object sender, EventArgs e)
        {
            TimerCountdown--;

            if (TimerCountdown % 30 == 0)
            {
                LoadInfo();
            }

            if (TimerCountdown == 0)
            {
                SetTimerCountdown();
                CheckUpdate();
            }

            lbl_Time.Text = GetTimeFromTimer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.s_StartMinimized)
            {
                btn_Hide_Click(null, null);
            }

            if (Properties.Settings.Default.s_FirstTime)
            {
                Properties.Settings.Default.s_FirstTime = false;
                btn_Info_Click(null, null);
            }

            LoadSettings();
            LoadInfo();
            Height = 235;

            CheckIfPathOk();
        }

        private void bnt_Settings_Click(object sender, EventArgs e)
        {
            LoadSettings();
            p_SettingsPanel.BringToFront();
            p_SettingsPanel.Show();
            p_ButtonPanel.BringToFront();
            p_ButtonPanel.Enabled = false;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void btn_Hide_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.s_WarnAtHide)
            {
                f_Warn warn = new f_Warn();
                warn.ShowDialog();
            }

            ShowInTaskbar = false;
            Hide();
            ni_Icon.Visible = true;
            ni_Icon.Icon = Properties.Resources.update_smoll;
        }

        private void ll_OpenPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Properties.Settings.Default.s_Path);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void btn_SettingsSaveAndClose_Click(object sender, EventArgs e)
        {
            p_ButtonPanel.Enabled = true;

            Properties.Settings.Default.s_CreateIcon = cb_CreateIcon.Checked;

            if (rb_x64.Checked)
            {
                Properties.Settings.Default.s_Architecture = "x64";
            }
            else
            {
                Properties.Settings.Default.s_Architecture = "x86";
            }

            Properties.Settings.Default.s_StartMinimized = cb_StartMinimized.Checked;

            Properties.Settings.Default.s_TimeCheck = (int)num_Minutes.Value;
            
            if(num_Minutes.Value == 0)
            {
                t.Stop();
                lbl_Time.Hide();
            }
            else
            {
                t.Start();
                lbl_Time.Show();
                SetTimerCountdown();
            }

            p_SettingsPanel.Hide();
            Properties.Settings.Default.Save();
        }

        private void btn_InstallPath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowser fbd = new FolderBrowser();

                fbd.TitleText = "Select install path";
                string path = Properties.Settings.Default.s_Path;
                if (path != "" && Directory.Exists(path))
                {
                    fbd.SelectedPath = path;
                }
                fbd.ShowCreateFolderButton = true;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.s_Path = fbd.SelectedPath;
                }

                LoadSettings();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void btn_CheckForUpdate_Click(object sender, EventArgs e)
        {
            CheckUpdate(true);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            p_ButtonPanel.Enabled = true;
            p_SettingsPanel.Hide();
        }

        private void lbl_CreateIcon_Click(object sender, EventArgs e)
        {
            cb_CreateIcon.Checked = !cb_CreateIcon.Checked;
        }

        private void lbl_StartMinimized_Click(object sender, EventArgs e)
        {
            cb_StartMinimized.Checked = !cb_StartMinimized.Checked;
        }

        private void lbl_AutoCheckTimer_Click(object sender, EventArgs e)
        {
            num_Minutes.Focus();
        }

        private void btn_NIMenu_ShowWindow_Click(object sender, EventArgs e)
        {
            Show();
            ShowInTaskbar = true;
            ni_Icon.Visible = false;
        }

        private void btn_NIMenu_Exit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void btn_SWW_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.s_SWW)
            {
                Auxiliary.SetSWW(false);
            }
            else
            {
                Auxiliary.SetSWW(true);
            }

            LoadSettings();
        }

        private void lbl_IsInstalled_TextChanged(object sender, EventArgs e)
        {
            if (lbl_IsInstalled.Text == "✓ - Installed")
            {
                lbl_IsInstalled.ForeColor = Color.Green;
            }
            else
            {
                lbl_IsInstalled.ForeColor = Color.Red;
            }
        }

        private void cmd_NIMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Properties.Settings.Default.s_TimeCheck == 0)
            {
                btn_NIMenu_CheckUpdate.Visible = false;
            }
            else
            {
                btn_NIMenu_CheckUpdate.Visible = true;
                btn_NIMenu_CheckUpdate.Text = $"Check for Update ({GetTimeFromTimer()})";
            }
        }

        private void btn_Info_Click(object sender, EventArgs e)
        {
            Info info = new Info();
            info.ShowDialog();
        }

        private void btn_NIMenu_CheckUpdate_Click(object sender, EventArgs e)
        {
            CheckUpdate();
        }

        private void ni_Icon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btn_NIMenu_ShowWindow_Click(null, null);
        }


    }
}
