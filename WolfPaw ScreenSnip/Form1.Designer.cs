namespace WolfPaw_ScreenSnip
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_Copy = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Options = new System.Windows.Forms.Button();
            this.btn_Preview = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.btn_SaveToDB = new System.Windows.Forms.Button();
            this.btn_DatabaseLoad = new System.Windows.Forms.Button();
            this.btn_Screen = new System.Windows.Forms.Button();
            this.btn_Minimize = new System.Windows.Forms.PictureBox();
            this.btn_Rollup = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ni_Notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.cms_Notify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_CMS_Rectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_CMS_QuickRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_CMS_Window = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_CMS_Freehand = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_CMS_Line = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_CMS_Magic = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_CMS_Preview = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_CMS_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_CMS_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_CMS_SaveToDB = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_CMS_BrowseDB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_CMS_Print = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_CMS_Email = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_CMS_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_CMS_ShowScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_CMS_MainWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_CMS_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.uc_ValueButton1 = new WolfPaw_ScreenSnip.uc_ValueButton();
            this.uc_ButtonSelector1 = new WolfPaw_ScreenSnip.uc_ButtonSelector();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Rollup)).BeginInit();
            this.cms_Notify.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Copy
            // 
            this.btn_Copy.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.clipboard;
            this.btn_Copy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Copy.Enabled = false;
            this.btn_Copy.Location = new System.Drawing.Point(323, 20);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(40, 40);
            this.btn_Copy.TabIndex = 1;
            this.btn_Copy.Tag = "3";
            this.toolTip1.SetToolTip(this.btn_Copy, "Copy Image\r\nCopies the image to your clipboard");
            this.btn_Copy.UseVisualStyleBackColor = true;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            this.btn_Copy.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.btn_Copy.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // btn_Save
            // 
            this.btn_Save.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.save;
            this.btn_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Save.Enabled = false;
            this.btn_Save.Location = new System.Drawing.Point(363, 20);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(40, 40);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Tag = "4";
            this.toolTip1.SetToolTip(this.btn_Save, "Save Image\r\nSaves the image to your PC");
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            this.btn_Save.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.btn_Save.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.shredder;
            this.btn_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Clear.Location = new System.Drawing.Point(228, 20);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(40, 40);
            this.btn_Clear.TabIndex = 4;
            this.btn_Clear.Tag = "1";
            this.toolTip1.SetToolTip(this.btn_Clear, "Clear Cutouts\r\nClears all the images you cut out from the screen\r\nWARNING: This a" +
        "ction can not be undone");
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            this.btn_Clear.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.btn_Clear.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.exit;
            this.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Exit.Location = new System.Drawing.Point(537, 20);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(40, 40);
            this.btn_Exit.TabIndex = 6;
            this.btn_Exit.Tag = "9";
            this.toolTip1.SetToolTip(this.btn_Exit, "Exit \r\nCloses the application");
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            this.btn_Exit.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.btn_Exit.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // btn_Options
            // 
            this.btn_Options.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.gear;
            this.btn_Options.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Options.Location = new System.Drawing.Point(497, 20);
            this.btn_Options.Name = "btn_Options";
            this.btn_Options.Size = new System.Drawing.Size(40, 40);
            this.btn_Options.TabIndex = 7;
            this.btn_Options.Tag = "7";
            this.toolTip1.SetToolTip(this.btn_Options, "Options\r\nOpens the Options screen");
            this.btn_Options.UseVisualStyleBackColor = true;
            this.btn_Options.Click += new System.EventHandler(this.btn_Options_Click);
            this.btn_Options.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.btn_Options.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // btn_Preview
            // 
            this.btn_Preview.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.preview;
            this.btn_Preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Preview.Enabled = false;
            this.btn_Preview.Location = new System.Drawing.Point(283, 20);
            this.btn_Preview.Name = "btn_Preview";
            this.btn_Preview.Size = new System.Drawing.Size(40, 40);
            this.btn_Preview.TabIndex = 10;
            this.btn_Preview.Tag = "2";
            this.toolTip1.SetToolTip(this.btn_Preview, "Preview Image\r\nOpens the Image preview screen");
            this.btn_Preview.UseVisualStyleBackColor = true;
            this.btn_Preview.Click += new System.EventHandler(this.btn_Preview_Click);
            this.btn_Preview.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.btn_Preview.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.UseAntiAlias = true;
            this.printPreviewDialog1.Visible = false;
            // 
            // btn_SaveToDB
            // 
            this.btn_SaveToDB.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.db;
            this.btn_SaveToDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_SaveToDB.Enabled = false;
            this.btn_SaveToDB.Location = new System.Drawing.Point(403, 20);
            this.btn_SaveToDB.Name = "btn_SaveToDB";
            this.btn_SaveToDB.Size = new System.Drawing.Size(40, 40);
            this.btn_SaveToDB.TabIndex = 11;
            this.btn_SaveToDB.Tag = "10";
            this.toolTip1.SetToolTip(this.btn_SaveToDB, "Save to Database\r\nSaves the image to the Database");
            this.btn_SaveToDB.UseVisualStyleBackColor = true;
            this.btn_SaveToDB.Click += new System.EventHandler(this.btn_SaveToDB_Click);
            this.btn_SaveToDB.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.btn_SaveToDB.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // btn_DatabaseLoad
            // 
            this.btn_DatabaseLoad.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.dbl;
            this.btn_DatabaseLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_DatabaseLoad.Location = new System.Drawing.Point(443, 20);
            this.btn_DatabaseLoad.Name = "btn_DatabaseLoad";
            this.btn_DatabaseLoad.Size = new System.Drawing.Size(40, 40);
            this.btn_DatabaseLoad.TabIndex = 12;
            this.btn_DatabaseLoad.Tag = "11";
            this.toolTip1.SetToolTip(this.btn_DatabaseLoad, "Load from Database\r\nOpens the image browser where you can load images from the Da" +
        "tabase");
            this.btn_DatabaseLoad.UseVisualStyleBackColor = true;
            this.btn_DatabaseLoad.Click += new System.EventHandler(this.btn_DatabaseLoad_Click);
            this.btn_DatabaseLoad.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.btn_DatabaseLoad.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // btn_Screen
            // 
            this.btn_Screen.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.screen;
            this.btn_Screen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Screen.Location = new System.Drawing.Point(188, 20);
            this.btn_Screen.Name = "btn_Screen";
            this.btn_Screen.Size = new System.Drawing.Size(40, 40);
            this.btn_Screen.TabIndex = 4;
            this.btn_Screen.Tag = "12";
            this.toolTip1.SetToolTip(this.btn_Screen, "Open Screen\r\nOpens the cutout editor screen");
            this.btn_Screen.UseVisualStyleBackColor = true;
            this.btn_Screen.Click += new System.EventHandler(this.btn_Screen_Click);
            this.btn_Screen.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.btn_Screen.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // btn_Minimize
            // 
            this.btn_Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.btn_Minimize.Image = global::WolfPaw_ScreenSnip.Properties.Resources.minimize_black;
            this.btn_Minimize.Location = new System.Drawing.Point(555, -2);
            this.btn_Minimize.Name = "btn_Minimize";
            this.btn_Minimize.Size = new System.Drawing.Size(20, 22);
            this.btn_Minimize.TabIndex = 13;
            this.btn_Minimize.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_Minimize, "Minimize\r\nMinimizes this toolbar to the tray or the Notification area");
            this.btn_Minimize.Click += new System.EventHandler(this.btn_Minimize_Click);
            this.btn_Minimize.MouseEnter += new System.EventHandler(this.btn_Minimize_MouseEnter);
            this.btn_Minimize.MouseLeave += new System.EventHandler(this.btn_Minimize_MouseLeave);
            // 
            // btn_Rollup
            // 
            this.btn_Rollup.BackColor = System.Drawing.Color.Transparent;
            this.btn_Rollup.Image = global::WolfPaw_ScreenSnip.Properties.Resources.rollup_black;
            this.btn_Rollup.Location = new System.Drawing.Point(0, 0);
            this.btn_Rollup.Name = "btn_Rollup";
            this.btn_Rollup.Size = new System.Drawing.Size(20, 20);
            this.btn_Rollup.TabIndex = 14;
            this.btn_Rollup.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_Rollup, "Roll up/down\r\nRolls this toolbar up or down making it take up less space ");
            this.btn_Rollup.Click += new System.EventHandler(this.btn_Rollup_Click);
            this.btn_Rollup.MouseEnter += new System.EventHandler(this.btn_Rollup_MouseEnter);
            this.btn_Rollup.MouseLeave += new System.EventHandler(this.btn_Rollup_MouseLeave);
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // ni_Notify
            // 
            this.ni_Notify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ni_Notify.BalloonTipText = "WolfPaw Screen Snip is still running";
            this.ni_Notify.BalloonTipTitle = "WolfPaw Screen Snip";
            this.ni_Notify.ContextMenuStrip = this.cms_Notify;
            this.ni_Notify.Text = "WolfPaw Screen Snip";
            this.ni_Notify.Visible = true;
            this.ni_Notify.DoubleClick += new System.EventHandler(this.ni_Notify_DoubleClick);
            // 
            // cms_Notify
            // 
            this.cms_Notify.AutoSize = false;
            this.cms_Notify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_CMS_Rectangle,
            this.btn_CMS_QuickRectangle,
            this.btn_CMS_Window,
            this.btn_CMS_Freehand,
            this.btn_CMS_Line,
            this.btn_CMS_Magic,
            this.toolStripSeparator1,
            this.btn_CMS_Preview,
            this.btn_CMS_Save,
            this.btn_CMS_Copy,
            this.toolStripSeparator2,
            this.btn_CMS_SaveToDB,
            this.btn_CMS_BrowseDB,
            this.toolStripSeparator3,
            this.btn_CMS_Print,
            this.btn_CMS_Email,
            this.toolStripSeparator4,
            this.btn_CMS_Options,
            this.btn_CMS_ShowScreen,
            this.btn_CMS_MainWindow,
            this.toolStripSeparator5,
            this.btn_CMS_Exit});
            this.cms_Notify.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.cms_Notify.Name = "cms_Notify";
            this.cms_Notify.Size = new System.Drawing.Size(310, 430);
            // 
            // btn_CMS_Rectangle
            // 
            this.btn_CMS_Rectangle.Name = "btn_CMS_Rectangle";
            this.btn_CMS_Rectangle.ShortcutKeyDisplayString = "Ctrl + F1";
            this.btn_CMS_Rectangle.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.btn_CMS_Rectangle.Size = new System.Drawing.Size(323, 22);
            this.btn_CMS_Rectangle.Text = "Rectangle cut";
            this.btn_CMS_Rectangle.ToolTipText = "Cut a rectangle from the screen";
            this.btn_CMS_Rectangle.Click += new System.EventHandler(this.btn_CMS_Rectangle_Click);
            // 
            // btn_CMS_QuickRectangle
            // 
            this.btn_CMS_QuickRectangle.Name = "btn_CMS_QuickRectangle";
            this.btn_CMS_QuickRectangle.ShortcutKeyDisplayString = "Ctrl + Shift + F1";
            this.btn_CMS_QuickRectangle.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F1)));
            this.btn_CMS_QuickRectangle.Size = new System.Drawing.Size(323, 22);
            this.btn_CMS_QuickRectangle.Text = "Quick Rectangle Cut                 ";
            this.btn_CMS_QuickRectangle.ToolTipText = "Copy a rectangle from the screen\r\nto the clipboard";
            // 
            // btn_CMS_Window
            // 
            this.btn_CMS_Window.Enabled = false;
            this.btn_CMS_Window.Name = "btn_CMS_Window";
            this.btn_CMS_Window.ShortcutKeyDisplayString = "Ctrl + F2";
            this.btn_CMS_Window.Size = new System.Drawing.Size(323, 22);
            this.btn_CMS_Window.Text = "Window cut";
            this.btn_CMS_Window.ToolTipText = "Cut out a window from the screen \r\nby clicking on it";
            this.btn_CMS_Window.Click += new System.EventHandler(this.btn_CMS_Window_Click);
            // 
            // btn_CMS_Freehand
            // 
            this.btn_CMS_Freehand.Name = "btn_CMS_Freehand";
            this.btn_CMS_Freehand.ShortcutKeyDisplayString = "Ctrl + F3";
            this.btn_CMS_Freehand.Size = new System.Drawing.Size(323, 22);
            this.btn_CMS_Freehand.Text = "Freehand cut";
            this.btn_CMS_Freehand.ToolTipText = "Cut out an area from the screen \r\nusing freehand selection";
            this.btn_CMS_Freehand.Click += new System.EventHandler(this.btn_CMS_Freehand_Click);
            // 
            // btn_CMS_Line
            // 
            this.btn_CMS_Line.Enabled = false;
            this.btn_CMS_Line.Name = "btn_CMS_Line";
            this.btn_CMS_Line.ShortcutKeyDisplayString = "Ctrl + F4";
            this.btn_CMS_Line.Size = new System.Drawing.Size(323, 22);
            this.btn_CMS_Line.Text = "Line cut";
            this.btn_CMS_Line.ToolTipText = "Cut out an area from the screen \r\nby selecting points along it\'s outside";
            this.btn_CMS_Line.Click += new System.EventHandler(this.btn_CMS_Line_Click);
            // 
            // btn_CMS_Magic
            // 
            this.btn_CMS_Magic.Name = "btn_CMS_Magic";
            this.btn_CMS_Magic.ShortcutKeyDisplayString = "Ctrl + F5";
            this.btn_CMS_Magic.Size = new System.Drawing.Size(323, 22);
            this.btn_CMS_Magic.Text = "Magic cut";
            this.btn_CMS_Magic.ToolTipText = "Cut out an area from the screen using \r\nfreehand selection mode \r\naided by edge d" +
    "etection";
            this.btn_CMS_Magic.Click += new System.EventHandler(this.btn_CMS_Magic_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(306, 6);
            // 
            // btn_CMS_Preview
            // 
            this.btn_CMS_Preview.Name = "btn_CMS_Preview";
            this.btn_CMS_Preview.Size = new System.Drawing.Size(323, 22);
            this.btn_CMS_Preview.Text = "Preview Picture";
            this.btn_CMS_Preview.Click += new System.EventHandler(this.btn_CMS_Preview_Click);
            // 
            // btn_CMS_Save
            // 
            this.btn_CMS_Save.Name = "btn_CMS_Save";
            this.btn_CMS_Save.Size = new System.Drawing.Size(323, 22);
            this.btn_CMS_Save.Text = "Save Picture";
            this.btn_CMS_Save.Click += new System.EventHandler(this.btn_CMS_Save_Click);
            // 
            // btn_CMS_Copy
            // 
            this.btn_CMS_Copy.Name = "btn_CMS_Copy";
            this.btn_CMS_Copy.Size = new System.Drawing.Size(323, 22);
            this.btn_CMS_Copy.Text = "Copy Picture";
            this.btn_CMS_Copy.Click += new System.EventHandler(this.btn_CMS_Copy_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(306, 6);
            // 
            // btn_CMS_SaveToDB
            // 
            this.btn_CMS_SaveToDB.Name = "btn_CMS_SaveToDB";
            this.btn_CMS_SaveToDB.Size = new System.Drawing.Size(323, 22);
            this.btn_CMS_SaveToDB.Text = "Save Picturte to DB";
            this.btn_CMS_SaveToDB.Click += new System.EventHandler(this.btn_CMS_SaveToDB_Click);
            // 
            // btn_CMS_BrowseDB
            // 
            this.btn_CMS_BrowseDB.Name = "btn_CMS_BrowseDB";
            this.btn_CMS_BrowseDB.Size = new System.Drawing.Size(323, 22);
            this.btn_CMS_BrowseDB.Text = "Browse DB";
            this.btn_CMS_BrowseDB.Click += new System.EventHandler(this.btn_CMS_BrowseDB_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(306, 6);
            // 
            // btn_CMS_Print
            // 
            this.btn_CMS_Print.Enabled = false;
            this.btn_CMS_Print.Name = "btn_CMS_Print";
            this.btn_CMS_Print.Size = new System.Drawing.Size(323, 22);
            this.btn_CMS_Print.Text = "Print Picture";
            this.btn_CMS_Print.Click += new System.EventHandler(this.btn_CMS_Print_Click);
            // 
            // btn_CMS_Email
            // 
            this.btn_CMS_Email.Enabled = false;
            this.btn_CMS_Email.Name = "btn_CMS_Email";
            this.btn_CMS_Email.Size = new System.Drawing.Size(323, 22);
            this.btn_CMS_Email.Text = "Email Picture";
            this.btn_CMS_Email.Click += new System.EventHandler(this.btn_CMS_Email_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(306, 6);
            // 
            // btn_CMS_Options
            // 
            this.btn_CMS_Options.Name = "btn_CMS_Options";
            this.btn_CMS_Options.Size = new System.Drawing.Size(323, 22);
            this.btn_CMS_Options.Text = "Options";
            this.btn_CMS_Options.Click += new System.EventHandler(this.btn_CMS_Options_Click);
            // 
            // btn_CMS_ShowScreen
            // 
            this.btn_CMS_ShowScreen.Name = "btn_CMS_ShowScreen";
            this.btn_CMS_ShowScreen.Size = new System.Drawing.Size(323, 22);
            this.btn_CMS_ShowScreen.Text = "Show Screen";
            this.btn_CMS_ShowScreen.Click += new System.EventHandler(this.btn_CMS_ShowScreen_Click);
            // 
            // btn_CMS_MainWindow
            // 
            this.btn_CMS_MainWindow.Name = "btn_CMS_MainWindow";
            this.btn_CMS_MainWindow.Size = new System.Drawing.Size(323, 22);
            this.btn_CMS_MainWindow.Text = "Show Main Window";
            this.btn_CMS_MainWindow.Click += new System.EventHandler(this.btn_CMS_MainWindow_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(306, 6);
            // 
            // btn_CMS_Exit
            // 
            this.btn_CMS_Exit.Name = "btn_CMS_Exit";
            this.btn_CMS_Exit.Size = new System.Drawing.Size(323, 22);
            this.btn_CMS_Exit.Text = "Exit Program";
            this.btn_CMS_Exit.Click += new System.EventHandler(this.btn_CMS_Exit_Click);
            // 
            // uc_ValueButton1
            // 
            this.uc_ValueButton1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.uc_ValueButton1.Location = new System.Drawing.Point(61, 20);
            this.uc_ValueButton1.MinimumSize = new System.Drawing.Size(40, 40);
            this.uc_ValueButton1.Name = "uc_ValueButton1";
            this.uc_ValueButton1.Size = new System.Drawing.Size(110, 40);
            this.uc_ValueButton1.TabIndex = 17;
            // 
            // uc_ButtonSelector1
            // 
            this.uc_ButtonSelector1.ButtonSize = 40;
            this.uc_ButtonSelector1.Function = WolfPaw_ScreenSnip.DropDownFunction.Cutout;
            this.uc_ButtonSelector1.Location = new System.Drawing.Point(0, 20);
            this.uc_ButtonSelector1.Name = "uc_ButtonSelector1";
            this.uc_ButtonSelector1.parent = null;
            this.uc_ButtonSelector1.Size = new System.Drawing.Size(55, 40);
            this.uc_ButtonSelector1.TabIndex = 16;
            this.uc_ButtonSelector1.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.uc_ButtonSelector1.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::WolfPaw_ScreenSnip.Properties.Resources.handle;
            this.ClientSize = new System.Drawing.Size(577, 60);
            this.ControlBox = false;
            this.Controls.Add(this.uc_ValueButton1);
            this.Controls.Add(this.uc_ButtonSelector1);
            this.Controls.Add(this.btn_Rollup);
            this.Controls.Add(this.btn_Minimize);
            this.Controls.Add(this.btn_DatabaseLoad);
            this.Controls.Add(this.btn_SaveToDB);
            this.Controls.Add(this.btn_Preview);
            this.Controls.Add(this.btn_Options);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Screen);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Copy);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Screen Snip";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Rollup)).EndInit();
            this.cms_Notify.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Options;
		private System.Windows.Forms.Button btn_Preview;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Button btn_SaveToDB;
		private System.Windows.Forms.Button btn_DatabaseLoad;
		private System.Windows.Forms.Button btn_Screen;
		private System.Windows.Forms.PictureBox btn_Minimize;
		private System.Windows.Forms.PictureBox btn_Rollup;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NotifyIcon ni_Notify;
		private uc_ButtonSelector uc_ButtonSelector1;
		private System.Windows.Forms.ContextMenuStrip cms_Notify;
		private System.Windows.Forms.ToolStripMenuItem btn_CMS_Rectangle;
		private System.Windows.Forms.ToolStripMenuItem btn_CMS_Window;
		private System.Windows.Forms.ToolStripMenuItem btn_CMS_Freehand;
		private System.Windows.Forms.ToolStripMenuItem btn_CMS_Line;
		private System.Windows.Forms.ToolStripMenuItem btn_CMS_Magic;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem btn_CMS_Preview;
		private System.Windows.Forms.ToolStripMenuItem btn_CMS_Save;
		private System.Windows.Forms.ToolStripMenuItem btn_CMS_Copy;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem btn_CMS_SaveToDB;
		private System.Windows.Forms.ToolStripMenuItem btn_CMS_BrowseDB;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem btn_CMS_Print;
		private System.Windows.Forms.ToolStripMenuItem btn_CMS_Email;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem btn_CMS_Options;
		private System.Windows.Forms.ToolStripMenuItem btn_CMS_ShowScreen;
		private System.Windows.Forms.ToolStripMenuItem btn_CMS_MainWindow;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem btn_CMS_Exit;
		private System.Windows.Forms.ToolStripMenuItem btn_CMS_QuickRectangle;
        private uc_ValueButton uc_ValueButton1;
    }
}

