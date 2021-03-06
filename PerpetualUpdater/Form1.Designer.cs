﻿namespace PerpetualUpdater
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ni_Icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmd_NIMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_NIMenu_Title = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_NIMenu_Title2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_NIMenu_CheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_NIMenu_ShowWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_NIMenu_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.p_ButtonPanel = new System.Windows.Forms.Panel();
            this.btn_Info = new System.Windows.Forms.Button();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Hide = new System.Windows.Forms.Button();
            this.btn_CheckForUpdate = new System.Windows.Forms.Button();
            this.bnt_Settings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_IsInstalled = new System.Windows.Forms.Label();
            this.lbl_Architecture = new System.Windows.Forms.Label();
            this.lbl_Path = new System.Windows.Forms.Label();
            this.lbl_CurrentVersion = new System.Windows.Forms.Label();
            this.lbl_LastChecked = new System.Windows.Forms.Label();
            this.lbl_LastDownload = new System.Windows.Forms.Label();
            this.p_SettingsPanel = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_SettingsSaveAndClose = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.ll_OpenPath = new System.Windows.Forms.LinkLabel();
            this.num_Minutes = new System.Windows.Forms.NumericUpDown();
            this.cb_IsSWW = new System.Windows.Forms.CheckBox();
            this.cb_StartMinimized = new System.Windows.Forms.CheckBox();
            this.cb_CreateIcon = new System.Windows.Forms.CheckBox();
            this.rb_x64 = new System.Windows.Forms.RadioButton();
            this.rb_x86 = new System.Windows.Forms.RadioButton();
            this.lbl_AutoCheckTimer = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_StartMinimized = new System.Windows.Forms.Label();
            this.lbl_CreateIcon = new System.Windows.Forms.Label();
            this.btn_InstallPath = new System.Windows.Forms.Button();
            this.btn_SWW = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_ConsoleOutput = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmd_NIMenu.SuspendLayout();
            this.p_ButtonPanel.SuspendLayout();
            this.p_SettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Minutes)).BeginInit();
            this.SuspendLayout();
            // 
            // ni_Icon
            // 
            this.ni_Icon.ContextMenuStrip = this.cmd_NIMenu;
            this.ni_Icon.Icon = ((System.Drawing.Icon)(resources.GetObject("ni_Icon.Icon")));
            this.ni_Icon.Text = "Perpetual Updater";
            this.ni_Icon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ni_Icon_MouseDoubleClick);
            // 
            // cmd_NIMenu
            // 
            this.cmd_NIMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_NIMenu_Title,
            this.btn_NIMenu_Title2,
            this.btn_NIMenu_CheckUpdate,
            this.btn_NIMenu_ShowWindow,
            this.btn_NIMenu_Exit});
            this.cmd_NIMenu.Name = "cmd_NIMenu";
            this.cmd_NIMenu.Size = new System.Drawing.Size(230, 114);
            this.cmd_NIMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cmd_NIMenu_Opening);
            // 
            // btn_NIMenu_Title
            // 
            this.btn_NIMenu_Title.Enabled = false;
            this.btn_NIMenu_Title.Name = "btn_NIMenu_Title";
            this.btn_NIMenu_Title.Size = new System.Drawing.Size(229, 22);
            this.btn_NIMenu_Title.Text = "WolfPaw - Perpetual Updater";
            // 
            // btn_NIMenu_Title2
            // 
            this.btn_NIMenu_Title2.Enabled = false;
            this.btn_NIMenu_Title2.Name = "btn_NIMenu_Title2";
            this.btn_NIMenu_Title2.Size = new System.Drawing.Size(229, 22);
            this.btn_NIMenu_Title2.Text = "-------------------------------";
            // 
            // btn_NIMenu_CheckUpdate
            // 
            this.btn_NIMenu_CheckUpdate.Name = "btn_NIMenu_CheckUpdate";
            this.btn_NIMenu_CheckUpdate.Size = new System.Drawing.Size(229, 22);
            this.btn_NIMenu_CheckUpdate.Text = "Check for Update";
            this.btn_NIMenu_CheckUpdate.Click += new System.EventHandler(this.btn_NIMenu_CheckUpdate_Click);
            // 
            // btn_NIMenu_ShowWindow
            // 
            this.btn_NIMenu_ShowWindow.Name = "btn_NIMenu_ShowWindow";
            this.btn_NIMenu_ShowWindow.Size = new System.Drawing.Size(229, 22);
            this.btn_NIMenu_ShowWindow.Text = "Show Window";
            this.btn_NIMenu_ShowWindow.Click += new System.EventHandler(this.btn_NIMenu_ShowWindow_Click);
            // 
            // btn_NIMenu_Exit
            // 
            this.btn_NIMenu_Exit.Name = "btn_NIMenu_Exit";
            this.btn_NIMenu_Exit.Size = new System.Drawing.Size(229, 22);
            this.btn_NIMenu_Exit.Text = "Exit";
            this.btn_NIMenu_Exit.Click += new System.EventHandler(this.btn_NIMenu_Exit_Click);
            // 
            // p_ButtonPanel
            // 
            this.p_ButtonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.p_ButtonPanel.Controls.Add(this.btn_Info);
            this.p_ButtonPanel.Controls.Add(this.lbl_Time);
            this.p_ButtonPanel.Controls.Add(this.btn_Close);
            this.p_ButtonPanel.Controls.Add(this.btn_Hide);
            this.p_ButtonPanel.Controls.Add(this.btn_CheckForUpdate);
            this.p_ButtonPanel.Controls.Add(this.bnt_Settings);
            this.p_ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.p_ButtonPanel.Location = new System.Drawing.Point(0, 233);
            this.p_ButtonPanel.Name = "p_ButtonPanel";
            this.p_ButtonPanel.Size = new System.Drawing.Size(757, 33);
            this.p_ButtonPanel.TabIndex = 0;
            // 
            // btn_Info
            // 
            this.btn_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Info.BackColor = System.Drawing.Color.MistyRose;
            this.btn_Info.Location = new System.Drawing.Point(475, 5);
            this.btn_Info.Name = "btn_Info";
            this.btn_Info.Size = new System.Drawing.Size(98, 23);
            this.btn_Info.TabIndex = 10;
            this.btn_Info.Text = "Info";
            this.btn_Info.UseVisualStyleBackColor = false;
            this.btn_Info.Click += new System.EventHandler(this.btn_Info_Click);
            // 
            // lbl_Time
            // 
            this.lbl_Time.AutoSize = true;
            this.lbl_Time.Location = new System.Drawing.Point(237, 10);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(34, 13);
            this.lbl_Time.TabIndex = 4;
            this.lbl_Time.Text = "00:00";
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.Location = new System.Drawing.Point(593, 5);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 1;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Hide
            // 
            this.btn_Hide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Hide.Location = new System.Drawing.Point(674, 5);
            this.btn_Hide.Name = "btn_Hide";
            this.btn_Hide.Size = new System.Drawing.Size(75, 23);
            this.btn_Hide.TabIndex = 2;
            this.btn_Hide.Text = "Hide";
            this.btn_Hide.UseVisualStyleBackColor = true;
            this.btn_Hide.Click += new System.EventHandler(this.btn_Hide_Click);
            // 
            // btn_CheckForUpdate
            // 
            this.btn_CheckForUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_CheckForUpdate.Location = new System.Drawing.Point(88, 5);
            this.btn_CheckForUpdate.Name = "btn_CheckForUpdate";
            this.btn_CheckForUpdate.Size = new System.Drawing.Size(143, 23);
            this.btn_CheckForUpdate.TabIndex = 3;
            this.btn_CheckForUpdate.Text = "Check for Update";
            this.btn_CheckForUpdate.UseVisualStyleBackColor = true;
            this.btn_CheckForUpdate.Click += new System.EventHandler(this.btn_CheckForUpdate_Click);
            // 
            // bnt_Settings
            // 
            this.bnt_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bnt_Settings.Location = new System.Drawing.Point(7, 5);
            this.bnt_Settings.Name = "bnt_Settings";
            this.bnt_Settings.Size = new System.Drawing.Size(75, 23);
            this.bnt_Settings.TabIndex = 3;
            this.bnt_Settings.Text = "Settings";
            this.bnt_Settings.UseVisualStyleBackColor = true;
            this.bnt_Settings.Click += new System.EventHandler(this.bnt_Settings_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current version: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Screen Snip installed: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Last checked for new version: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Architecture installed:  ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Path: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Last download:";
            // 
            // lbl_IsInstalled
            // 
            this.lbl_IsInstalled.AutoSize = true;
            this.lbl_IsInstalled.ForeColor = System.Drawing.Color.Red;
            this.lbl_IsInstalled.Location = new System.Drawing.Point(165, 20);
            this.lbl_IsInstalled.Name = "lbl_IsInstalled";
            this.lbl_IsInstalled.Size = new System.Drawing.Size(84, 13);
            this.lbl_IsInstalled.TabIndex = 1;
            this.lbl_IsInstalled.Text = "✗ - Not Installed";
            this.lbl_IsInstalled.TextChanged += new System.EventHandler(this.lbl_IsInstalled_TextChanged);
            // 
            // lbl_Architecture
            // 
            this.lbl_Architecture.AutoSize = true;
            this.lbl_Architecture.Location = new System.Drawing.Point(165, 48);
            this.lbl_Architecture.Name = "lbl_Architecture";
            this.lbl_Architecture.Size = new System.Drawing.Size(16, 13);
            this.lbl_Architecture.TabIndex = 1;
            this.lbl_Architecture.Text = " - ";
            // 
            // lbl_Path
            // 
            this.lbl_Path.AutoSize = true;
            this.lbl_Path.Location = new System.Drawing.Point(165, 76);
            this.lbl_Path.Name = "lbl_Path";
            this.lbl_Path.Size = new System.Drawing.Size(16, 13);
            this.lbl_Path.TabIndex = 1;
            this.lbl_Path.Text = " - ";
            // 
            // lbl_CurrentVersion
            // 
            this.lbl_CurrentVersion.AutoSize = true;
            this.lbl_CurrentVersion.Location = new System.Drawing.Point(165, 104);
            this.lbl_CurrentVersion.Name = "lbl_CurrentVersion";
            this.lbl_CurrentVersion.Size = new System.Drawing.Size(16, 13);
            this.lbl_CurrentVersion.TabIndex = 1;
            this.lbl_CurrentVersion.Text = " - ";
            // 
            // lbl_LastChecked
            // 
            this.lbl_LastChecked.AutoSize = true;
            this.lbl_LastChecked.Location = new System.Drawing.Point(165, 132);
            this.lbl_LastChecked.Name = "lbl_LastChecked";
            this.lbl_LastChecked.Size = new System.Drawing.Size(16, 13);
            this.lbl_LastChecked.TabIndex = 1;
            this.lbl_LastChecked.Text = " - ";
            // 
            // lbl_LastDownload
            // 
            this.lbl_LastDownload.AutoSize = true;
            this.lbl_LastDownload.Location = new System.Drawing.Point(165, 160);
            this.lbl_LastDownload.Name = "lbl_LastDownload";
            this.lbl_LastDownload.Size = new System.Drawing.Size(16, 13);
            this.lbl_LastDownload.TabIndex = 1;
            this.lbl_LastDownload.Text = " - ";
            // 
            // p_SettingsPanel
            // 
            this.p_SettingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.p_SettingsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.p_SettingsPanel.Controls.Add(this.btn_Cancel);
            this.p_SettingsPanel.Controls.Add(this.btn_SettingsSaveAndClose);
            this.p_SettingsPanel.Controls.Add(this.label11);
            this.p_SettingsPanel.Controls.Add(this.ll_OpenPath);
            this.p_SettingsPanel.Controls.Add(this.num_Minutes);
            this.p_SettingsPanel.Controls.Add(this.cb_IsSWW);
            this.p_SettingsPanel.Controls.Add(this.cb_StartMinimized);
            this.p_SettingsPanel.Controls.Add(this.cb_CreateIcon);
            this.p_SettingsPanel.Controls.Add(this.rb_x64);
            this.p_SettingsPanel.Controls.Add(this.rb_x86);
            this.p_SettingsPanel.Controls.Add(this.lbl_AutoCheckTimer);
            this.p_SettingsPanel.Controls.Add(this.label9);
            this.p_SettingsPanel.Controls.Add(this.lbl_StartMinimized);
            this.p_SettingsPanel.Controls.Add(this.lbl_CreateIcon);
            this.p_SettingsPanel.Controls.Add(this.btn_InstallPath);
            this.p_SettingsPanel.Controls.Add(this.btn_SWW);
            this.p_SettingsPanel.Controls.Add(this.label7);
            this.p_SettingsPanel.Location = new System.Drawing.Point(0, 5);
            this.p_SettingsPanel.Name = "p_SettingsPanel";
            this.p_SettingsPanel.Size = new System.Drawing.Size(757, 297);
            this.p_SettingsPanel.TabIndex = 2;
            this.p_SettingsPanel.Visible = false;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(547, 3);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(98, 23);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "Cancel and Close";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_SettingsSaveAndClose
            // 
            this.btn_SettingsSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SettingsSaveAndClose.Location = new System.Drawing.Point(651, 3);
            this.btn_SettingsSaveAndClose.Name = "btn_SettingsSaveAndClose";
            this.btn_SettingsSaveAndClose.Size = new System.Drawing.Size(98, 23);
            this.btn_SettingsSaveAndClose.TabIndex = 8;
            this.btn_SettingsSaveAndClose.Text = "Save and Close";
            this.btn_SettingsSaveAndClose.UseVisualStyleBackColor = true;
            this.btn_SettingsSaveAndClose.Click += new System.EventHandler(this.btn_SettingsSaveAndClose_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(268, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "minutes";
            this.toolTip1.SetToolTip(this.label11, "The delay in minutes, before the program \r\nchecks for updates automatically.\r\n---" +
        "--------------------------------\r\nDefault: 240\r\n--------------------------------" +
        "---\r\nSet to 0 to turn off!");
            // 
            // ll_OpenPath
            // 
            this.ll_OpenPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ll_OpenPath.AutoSize = true;
            this.ll_OpenPath.Location = new System.Drawing.Point(540, 48);
            this.ll_OpenPath.Name = "ll_OpenPath";
            this.ll_OpenPath.Size = new System.Drawing.Size(33, 13);
            this.ll_OpenPath.TabIndex = 6;
            this.ll_OpenPath.TabStop = true;
            this.ll_OpenPath.Text = "Open";
            this.toolTip1.SetToolTip(this.ll_OpenPath, "Click to open the selected install path\r\nin your default file explorer.");
            this.ll_OpenPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_OpenPath_LinkClicked);
            // 
            // num_Minutes
            // 
            this.num_Minutes.Increment = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.num_Minutes.Location = new System.Drawing.Point(174, 164);
            this.num_Minutes.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.num_Minutes.Name = "num_Minutes";
            this.num_Minutes.Size = new System.Drawing.Size(90, 20);
            this.num_Minutes.TabIndex = 5;
            this.toolTip1.SetToolTip(this.num_Minutes, "The delay in minutes, before the program \r\nchecks for updates automatically.\r\n---" +
        "--------------------------------\r\nDefault: 240\r\n--------------------------------" +
        "---\r\nSet to 0 to turn off!");
            this.num_Minutes.Value = new decimal(new int[] {
            240,
            0,
            0,
            0});
            // 
            // cb_IsSWW
            // 
            this.cb_IsSWW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_IsSWW.AutoSize = true;
            this.cb_IsSWW.Enabled = false;
            this.cb_IsSWW.Location = new System.Drawing.Point(558, 86);
            this.cb_IsSWW.Name = "cb_IsSWW";
            this.cb_IsSWW.Size = new System.Drawing.Size(15, 14);
            this.cb_IsSWW.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cb_IsSWW, "This is going to show checked, if the\r\nupdater is set up to start with Windows.\r\n" +
        "Otherwise it will be unchecked.");
            this.cb_IsSWW.UseVisualStyleBackColor = true;
            // 
            // cb_StartMinimized
            // 
            this.cb_StartMinimized.AutoSize = true;
            this.cb_StartMinimized.Location = new System.Drawing.Point(174, 87);
            this.cb_StartMinimized.Name = "cb_StartMinimized";
            this.cb_StartMinimized.Size = new System.Drawing.Size(15, 14);
            this.cb_StartMinimized.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cb_StartMinimized, "If checked, the updater will start in the\r\nnotification area of your tray.\r\n");
            this.cb_StartMinimized.UseVisualStyleBackColor = true;
            // 
            // cb_CreateIcon
            // 
            this.cb_CreateIcon.AutoSize = true;
            this.cb_CreateIcon.Location = new System.Drawing.Point(174, 47);
            this.cb_CreateIcon.Name = "cb_CreateIcon";
            this.cb_CreateIcon.Size = new System.Drawing.Size(15, 14);
            this.cb_CreateIcon.TabIndex = 4;
            this.toolTip1.SetToolTip(this.cb_CreateIcon, "If checked, the updater will create an icon\r\nfor the program when installing the " +
        "update\r\nif an icon does not exist already.\r\n");
            this.cb_CreateIcon.UseVisualStyleBackColor = true;
            // 
            // rb_x64
            // 
            this.rb_x64.AutoSize = true;
            this.rb_x64.Location = new System.Drawing.Point(222, 126);
            this.rb_x64.Name = "rb_x64";
            this.rb_x64.Size = new System.Drawing.Size(42, 17);
            this.rb_x64.TabIndex = 3;
            this.rb_x64.Text = "x64";
            this.toolTip1.SetToolTip(this.rb_x64, "Which architecture of the tool should be installed,\r\nthe 32 bit or the 64 bit.\r\n-" +
        "----------------------------------\r\nThe system selects the appropriate \r\nversion" +
        " by default.");
            this.rb_x64.UseVisualStyleBackColor = true;
            // 
            // rb_x86
            // 
            this.rb_x86.AutoSize = true;
            this.rb_x86.Location = new System.Drawing.Point(174, 126);
            this.rb_x86.Name = "rb_x86";
            this.rb_x86.Size = new System.Drawing.Size(42, 17);
            this.rb_x86.TabIndex = 3;
            this.rb_x86.Text = "x86";
            this.toolTip1.SetToolTip(this.rb_x86, "Which architecture of the tool should be installed,\r\nthe 32 bit or the 64 bit.\r\n-" +
        "----------------------------------\r\nThe system selects the appropriate \r\nversion" +
        " by default.");
            this.rb_x86.UseVisualStyleBackColor = true;
            // 
            // lbl_AutoCheckTimer
            // 
            this.lbl_AutoCheckTimer.AutoSize = true;
            this.lbl_AutoCheckTimer.Location = new System.Drawing.Point(10, 168);
            this.lbl_AutoCheckTimer.Name = "lbl_AutoCheckTimer";
            this.lbl_AutoCheckTimer.Size = new System.Drawing.Size(161, 13);
            this.lbl_AutoCheckTimer.TabIndex = 2;
            this.lbl_AutoCheckTimer.Text = "Time between automatic checks";
            this.toolTip1.SetToolTip(this.lbl_AutoCheckTimer, "The delay in minutes, before the program \r\nchecks for updates automatically.\r\n---" +
        "--------------------------------\r\nDefault: 240\r\n--------------------------------" +
        "---\r\nSet to 0 to turn off!");
            this.lbl_AutoCheckTimer.Click += new System.EventHandler(this.lbl_AutoCheckTimer_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Architecture to install";
            this.toolTip1.SetToolTip(this.label9, "Which architecture of the tool should be installed,\r\nthe 32 bit or the 64 bit.\r\n-" +
        "----------------------------------\r\nThe system selects the appropriate \r\nversion" +
        " by default.");
            // 
            // lbl_StartMinimized
            // 
            this.lbl_StartMinimized.AutoSize = true;
            this.lbl_StartMinimized.Location = new System.Drawing.Point(10, 87);
            this.lbl_StartMinimized.Name = "lbl_StartMinimized";
            this.lbl_StartMinimized.Size = new System.Drawing.Size(77, 13);
            this.lbl_StartMinimized.TabIndex = 2;
            this.lbl_StartMinimized.Text = "Start minimized";
            this.lbl_StartMinimized.Click += new System.EventHandler(this.lbl_StartMinimized_Click);
            // 
            // lbl_CreateIcon
            // 
            this.lbl_CreateIcon.AutoSize = true;
            this.lbl_CreateIcon.Location = new System.Drawing.Point(10, 48);
            this.lbl_CreateIcon.Name = "lbl_CreateIcon";
            this.lbl_CreateIcon.Size = new System.Drawing.Size(120, 13);
            this.lbl_CreateIcon.TabIndex = 2;
            this.lbl_CreateIcon.Text = "Create Icon on Desktop";
            this.lbl_CreateIcon.Click += new System.EventHandler(this.lbl_CreateIcon_Click);
            // 
            // btn_InstallPath
            // 
            this.btn_InstallPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_InstallPath.Location = new System.Drawing.Point(579, 43);
            this.btn_InstallPath.Name = "btn_InstallPath";
            this.btn_InstallPath.Size = new System.Drawing.Size(170, 23);
            this.btn_InstallPath.TabIndex = 1;
            this.btn_InstallPath.Text = "Set up Install Path";
            this.toolTip1.SetToolTip(this.btn_InstallPath, "Open a dialog window to select a path\r\nwhere the program will be installed \r\nafte" +
        "r downloading.");
            this.btn_InstallPath.UseVisualStyleBackColor = true;
            this.btn_InstallPath.Click += new System.EventHandler(this.btn_InstallPath_Click);
            // 
            // btn_SWW
            // 
            this.btn_SWW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SWW.Location = new System.Drawing.Point(579, 82);
            this.btn_SWW.Name = "btn_SWW";
            this.btn_SWW.Size = new System.Drawing.Size(170, 23);
            this.btn_SWW.TabIndex = 1;
            this.btn_SWW.Text = "Set up to start with Windows";
            this.toolTip1.SetToolTip(this.btn_SWW, "Click this button to toggle between\r\nit starting up with Windows or not.");
            this.btn_SWW.UseVisualStyleBackColor = true;
            this.btn_SWW.Click += new System.EventHandler(this.btn_SWW_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Settings";
            // 
            // tb_ConsoleOutput
            // 
            this.tb_ConsoleOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_ConsoleOutput.BackColor = System.Drawing.Color.Black;
            this.tb_ConsoleOutput.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_ConsoleOutput.ForeColor = System.Drawing.Color.White;
            this.tb_ConsoleOutput.Location = new System.Drawing.Point(435, 5);
            this.tb_ConsoleOutput.Multiline = true;
            this.tb_ConsoleOutput.Name = "tb_ConsoleOutput";
            this.tb_ConsoleOutput.ReadOnly = true;
            this.tb_ConsoleOutput.Size = new System.Drawing.Size(322, 158);
            this.tb_ConsoleOutput.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(757, 266);
            this.ControlBox = false;
            this.Controls.Add(this.p_ButtonPanel);
            this.Controls.Add(this.p_SettingsPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_ConsoleOutput);
            this.Controls.Add(this.lbl_LastDownload);
            this.Controls.Add(this.lbl_LastChecked);
            this.Controls.Add(this.lbl_CurrentVersion);
            this.Controls.Add(this.lbl_Path);
            this.Controls.Add(this.lbl_Architecture);
            this.Controls.Add(this.lbl_IsInstalled);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(773, 282);
            this.Name = "MainForm";
            this.Text = "WolfPaw - Perpetual Updater";
            this.cmd_NIMenu.ResumeLayout(false);
            this.p_ButtonPanel.ResumeLayout(false);
            this.p_ButtonPanel.PerformLayout();
            this.p_SettingsPanel.ResumeLayout(false);
            this.p_SettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Minutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon ni_Icon;
        private System.Windows.Forms.Panel p_ButtonPanel;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Hide;
        private System.Windows.Forms.Button bnt_Settings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_IsInstalled;
        private System.Windows.Forms.Label lbl_Architecture;
        private System.Windows.Forms.Label lbl_Path;
        private System.Windows.Forms.Label lbl_CurrentVersion;
        private System.Windows.Forms.Label lbl_LastChecked;
        private System.Windows.Forms.Label lbl_LastDownload;
        private System.Windows.Forms.Panel p_SettingsPanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ContextMenuStrip cmd_NIMenu;
        private System.Windows.Forms.ToolStripMenuItem btn_NIMenu_Title;
        private System.Windows.Forms.ToolStripMenuItem btn_NIMenu_Title2;
        private System.Windows.Forms.ToolStripMenuItem btn_NIMenu_CheckUpdate;
        private System.Windows.Forms.ToolStripMenuItem btn_NIMenu_ShowWindow;
        private System.Windows.Forms.ToolStripMenuItem btn_NIMenu_Exit;
        private System.Windows.Forms.Button btn_CheckForUpdate;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Button btn_SWW;
        private System.Windows.Forms.CheckBox cb_CreateIcon;
        private System.Windows.Forms.RadioButton rb_x64;
        private System.Windows.Forms.RadioButton rb_x86;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_CreateIcon;
        private System.Windows.Forms.Button btn_InstallPath;
        private System.Windows.Forms.NumericUpDown num_Minutes;
        private System.Windows.Forms.Label lbl_AutoCheckTimer;
        private System.Windows.Forms.CheckBox cb_IsSWW;
        private System.Windows.Forms.LinkLabel ll_OpenPath;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_SettingsSaveAndClose;
        private System.Windows.Forms.CheckBox cb_StartMinimized;
        private System.Windows.Forms.Label lbl_StartMinimized;
        private System.Windows.Forms.TextBox tb_ConsoleOutput;
        private System.Windows.Forms.Button btn_Info;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btn_Cancel;
    }
}

