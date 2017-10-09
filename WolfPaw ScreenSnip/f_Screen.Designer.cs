namespace WolfPaw_ScreenSnip
{
    partial class f_Screen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_Screen));
            this.sb_PrecMovUD = new System.Windows.Forms.VScrollBar();
            this.sb_PrecMovLR = new System.Windows.Forms.HScrollBar();
            this.t_Tick = new System.Windows.Forms.Timer(this.components);
            this.tt_Main = new System.Windows.Forms.ToolTip(this.components);
            this.btn_Manipulate = new FontAwesome.Sharp.IconButton();
            this.btn_ToolStrip = new FontAwesome.Sharp.IconButton();
            this.btn_Dock = new FontAwesome.Sharp.IconButton();
            this.btn_Eraser = new FontAwesome.Sharp.IconButton();
            this.btn_Line = new FontAwesome.Sharp.IconButton();
            this.btn_Marker = new FontAwesome.Sharp.IconButton();
            this.btn_Arrow = new FontAwesome.Sharp.IconButton();
            this.btn_Text = new FontAwesome.Sharp.IconButton();
            this.btn_Oval = new FontAwesome.Sharp.IconButton();
            this.btn_Square = new FontAwesome.Sharp.IconButton();
            this.btn_Pen = new FontAwesome.Sharp.IconButton();
            this.btn_Font = new System.Windows.Forms.Button();
            this.num_ToolSize = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.p_Border = new System.Windows.Forms.Panel();
            this.num_Border = new System.Windows.Forms.NumericUpDown();
            this.cb_Border = new System.Windows.Forms.CheckBox();
            this.p_BgColor = new System.Windows.Forms.Panel();
            this.r_BgColor = new System.Windows.Forms.RadioButton();
            this.r_BgTransparent = new System.Windows.Forms.RadioButton();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.el_EditLayer1 = new WolfPaw_ScreenSnip.uc_WpfEditLayer();
            this.ts_Tools = new WolfPaw_ScreenSnip.myToolstrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.btn_ToolSelector = new FontAwesome.Sharp.IconDropDownButton();
            this.pointerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pencilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textMarkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ovalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrowToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eraserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_ToolColorPick = new FontAwesome.Sharp.IconToolStripButton();
            this.tb_ToolSize = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.btn_FontSelect = new FontAwesome.Sharp.IconToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cb_Background = new FontAwesome.Sharp.IconToolStripButton();
            this.btn_BGColorPick = new FontAwesome.Sharp.IconToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cb_BorderOn = new FontAwesome.Sharp.IconToolStripButton();
            this.tb_BorderSize = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.btn_BorderColorPick = new FontAwesome.Sharp.IconToolStripButton();
            this.btn_ToolWindow = new FontAwesome.Sharp.IconToolStripButton();
            this.btn_ToolPanel = new FontAwesome.Sharp.IconToolStripButton();
            this.p_Tools = new WolfPaw_ScreenSnip.myPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_ToolSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Border)).BeginInit();
            this.ts_Tools.SuspendLayout();
            this.p_Tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // sb_PrecMovUD
            // 
            this.sb_PrecMovUD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sb_PrecMovUD.LargeChange = 1;
            this.sb_PrecMovUD.Location = new System.Drawing.Point(896, 0);
            this.sb_PrecMovUD.Maximum = 5;
            this.sb_PrecMovUD.Minimum = -5;
            this.sb_PrecMovUD.Name = "sb_PrecMovUD";
            this.sb_PrecMovUD.Size = new System.Drawing.Size(30, 576);
            this.sb_PrecMovUD.TabIndex = 1;
            this.tt_Main.SetToolTip(this.sb_PrecMovUD, "Precision Movement Up and Down");
            this.sb_PrecMovUD.Visible = false;
            this.sb_PrecMovUD.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sb_PrecMovUD_Scroll);
            this.sb_PrecMovUD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_Screen_KeyDown);
            this.sb_PrecMovUD.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // sb_PrecMovLR
            // 
            this.sb_PrecMovLR.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sb_PrecMovLR.LargeChange = 1;
            this.sb_PrecMovLR.Location = new System.Drawing.Point(0, 576);
            this.sb_PrecMovLR.Maximum = 5;
            this.sb_PrecMovLR.Minimum = -5;
            this.sb_PrecMovLR.Name = "sb_PrecMovLR";
            this.sb_PrecMovLR.Size = new System.Drawing.Size(896, 30);
            this.sb_PrecMovLR.TabIndex = 2;
            this.tt_Main.SetToolTip(this.sb_PrecMovLR, "Precision Movement Left and Right");
            this.sb_PrecMovLR.Visible = false;
            this.sb_PrecMovLR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sb_PrecMovLR_Scroll);
            this.sb_PrecMovLR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_Screen_KeyDown);
            this.sb_PrecMovLR.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // t_Tick
            // 
            this.t_Tick.Enabled = true;
            this.t_Tick.Interval = 200;
            this.t_Tick.Tick += new System.EventHandler(this.t_Tick_Tick);
            // 
            // btn_Manipulate
            // 
            this.btn_Manipulate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Manipulate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Manipulate.Icon = FontAwesome.Sharp.IconChar.MousePointer;
            this.btn_Manipulate.IconColor = System.Drawing.Color.Black;
            this.btn_Manipulate.IconSize = 20;
            this.btn_Manipulate.Image = ((System.Drawing.Image)(resources.GetObject("btn_Manipulate.Image")));
            this.btn_Manipulate.Location = new System.Drawing.Point(67, 129);
            this.btn_Manipulate.Name = "btn_Manipulate";
            this.btn_Manipulate.Size = new System.Drawing.Size(20, 20);
            this.btn_Manipulate.TabIndex = 53;
            this.btn_Manipulate.TabStop = false;
            this.tt_Main.SetToolTip(this.btn_Manipulate, "Handle Cutouts");
            this.btn_Manipulate.UseVisualStyleBackColor = true;
            this.btn_Manipulate.Click += new System.EventHandler(this.btn_Manipulate_Click);
            this.btn_Manipulate.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // btn_ToolStrip
            // 
            this.btn_ToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ToolStrip.Icon = FontAwesome.Sharp.IconChar.ArrowUp;
            this.btn_ToolStrip.IconColor = System.Drawing.Color.Black;
            this.btn_ToolStrip.IconSize = 32;
            this.btn_ToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("btn_ToolStrip.Image")));
            this.btn_ToolStrip.Location = new System.Drawing.Point(130, 571);
            this.btn_ToolStrip.Name = "btn_ToolStrip";
            this.btn_ToolStrip.Size = new System.Drawing.Size(32, 32);
            this.btn_ToolStrip.TabIndex = 52;
            this.btn_ToolStrip.TabStop = false;
            this.tt_Main.SetToolTip(this.btn_ToolStrip, "Switch to Toolbar");
            this.btn_ToolStrip.UseVisualStyleBackColor = true;
            this.btn_ToolStrip.Click += new System.EventHandler(this.btn_ToolStrip_Click);
            this.btn_ToolStrip.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // btn_Dock
            // 
            this.btn_Dock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Dock.Icon = FontAwesome.Sharp.IconChar.ArrowsAlt;
            this.btn_Dock.IconColor = System.Drawing.Color.Black;
            this.btn_Dock.IconSize = 32;
            this.btn_Dock.Image = ((System.Drawing.Image)(resources.GetObject("btn_Dock.Image")));
            this.btn_Dock.Location = new System.Drawing.Point(165, 571);
            this.btn_Dock.Name = "btn_Dock";
            this.btn_Dock.Size = new System.Drawing.Size(32, 32);
            this.btn_Dock.TabIndex = 52;
            this.btn_Dock.TabStop = false;
            this.tt_Main.SetToolTip(this.btn_Dock, "Switch to Floating Window");
            this.btn_Dock.UseVisualStyleBackColor = true;
            this.btn_Dock.Click += new System.EventHandler(this.btn_Dock_Click);
            this.btn_Dock.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // btn_Eraser
            // 
            this.btn_Eraser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Eraser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Eraser.Icon = FontAwesome.Sharp.IconChar.Eraser;
            this.btn_Eraser.IconColor = System.Drawing.Color.Black;
            this.btn_Eraser.IconSize = 20;
            this.btn_Eraser.Image = ((System.Drawing.Image)(resources.GetObject("btn_Eraser.Image")));
            this.btn_Eraser.Location = new System.Drawing.Point(168, 129);
            this.btn_Eraser.Name = "btn_Eraser";
            this.btn_Eraser.Size = new System.Drawing.Size(20, 46);
            this.btn_Eraser.TabIndex = 51;
            this.btn_Eraser.TabStop = false;
            this.tt_Main.SetToolTip(this.btn_Eraser, "Eraser");
            this.btn_Eraser.UseVisualStyleBackColor = true;
            this.btn_Eraser.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // btn_Line
            // 
            this.btn_Line.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Line.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Line.Icon = FontAwesome.Sharp.IconChar.Minus;
            this.btn_Line.IconColor = System.Drawing.Color.Black;
            this.btn_Line.IconSize = 20;
            this.btn_Line.Image = ((System.Drawing.Image)(resources.GetObject("btn_Line.Image")));
            this.btn_Line.Location = new System.Drawing.Point(144, 129);
            this.btn_Line.Name = "btn_Line";
            this.btn_Line.Size = new System.Drawing.Size(20, 20);
            this.btn_Line.TabIndex = 50;
            this.btn_Line.TabStop = false;
            this.tt_Main.SetToolTip(this.btn_Line, "Straight Line Tool");
            this.btn_Line.UseVisualStyleBackColor = true;
            this.btn_Line.Click += new System.EventHandler(this.btn_Line_Click);
            this.btn_Line.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // btn_Marker
            // 
            this.btn_Marker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Marker.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Marker.Icon = FontAwesome.Sharp.IconChar.PencilSquare;
            this.btn_Marker.IconColor = System.Drawing.Color.Black;
            this.btn_Marker.IconSize = 22;
            this.btn_Marker.Image = ((System.Drawing.Image)(resources.GetObject("btn_Marker.Image")));
            this.btn_Marker.Location = new System.Drawing.Point(119, 129);
            this.btn_Marker.Name = "btn_Marker";
            this.btn_Marker.Size = new System.Drawing.Size(20, 20);
            this.btn_Marker.TabIndex = 49;
            this.btn_Marker.TabStop = false;
            this.tt_Main.SetToolTip(this.btn_Marker, "Highlighter");
            this.btn_Marker.UseVisualStyleBackColor = true;
            this.btn_Marker.Click += new System.EventHandler(this.btn_Marker_Click);
            this.btn_Marker.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // btn_Arrow
            // 
            this.btn_Arrow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Arrow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Arrow.Icon = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btn_Arrow.IconColor = System.Drawing.Color.Black;
            this.btn_Arrow.IconSize = 20;
            this.btn_Arrow.Image = ((System.Drawing.Image)(resources.GetObject("btn_Arrow.Image")));
            this.btn_Arrow.Location = new System.Drawing.Point(144, 155);
            this.btn_Arrow.Name = "btn_Arrow";
            this.btn_Arrow.Size = new System.Drawing.Size(20, 20);
            this.btn_Arrow.TabIndex = 48;
            this.btn_Arrow.TabStop = false;
            this.tt_Main.SetToolTip(this.btn_Arrow, "Arrow Tool");
            this.btn_Arrow.UseVisualStyleBackColor = true;
            this.btn_Arrow.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // btn_Text
            // 
            this.btn_Text.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Text.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Text.Icon = FontAwesome.Sharp.IconChar.Font;
            this.btn_Text.IconColor = System.Drawing.Color.Black;
            this.btn_Text.IconSize = 20;
            this.btn_Text.Image = ((System.Drawing.Image)(resources.GetObject("btn_Text.Image")));
            this.btn_Text.Location = new System.Drawing.Point(118, 155);
            this.btn_Text.Name = "btn_Text";
            this.btn_Text.Size = new System.Drawing.Size(20, 20);
            this.btn_Text.TabIndex = 48;
            this.btn_Text.TabStop = false;
            this.tt_Main.SetToolTip(this.btn_Text, "Text Tool");
            this.btn_Text.UseVisualStyleBackColor = true;
            this.btn_Text.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // btn_Oval
            // 
            this.btn_Oval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Oval.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Oval.Icon = FontAwesome.Sharp.IconChar.CircleO;
            this.btn_Oval.IconColor = System.Drawing.Color.Black;
            this.btn_Oval.IconSize = 20;
            this.btn_Oval.Image = ((System.Drawing.Image)(resources.GetObject("btn_Oval.Image")));
            this.btn_Oval.Location = new System.Drawing.Point(93, 155);
            this.btn_Oval.Name = "btn_Oval";
            this.btn_Oval.Size = new System.Drawing.Size(20, 20);
            this.btn_Oval.TabIndex = 47;
            this.btn_Oval.TabStop = false;
            this.tt_Main.SetToolTip(this.btn_Oval, "Ellipse Tool");
            this.btn_Oval.UseVisualStyleBackColor = true;
            this.btn_Oval.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // btn_Square
            // 
            this.btn_Square.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Square.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Square.Icon = FontAwesome.Sharp.IconChar.SquareO;
            this.btn_Square.IconColor = System.Drawing.Color.Black;
            this.btn_Square.IconSize = 20;
            this.btn_Square.Image = ((System.Drawing.Image)(resources.GetObject("btn_Square.Image")));
            this.btn_Square.Location = new System.Drawing.Point(67, 155);
            this.btn_Square.Name = "btn_Square";
            this.btn_Square.Size = new System.Drawing.Size(20, 20);
            this.btn_Square.TabIndex = 46;
            this.btn_Square.TabStop = false;
            this.tt_Main.SetToolTip(this.btn_Square, "Rectangle Tool");
            this.btn_Square.UseVisualStyleBackColor = true;
            this.btn_Square.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // btn_Pen
            // 
            this.btn_Pen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Pen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Pen.Icon = FontAwesome.Sharp.IconChar.Pencil;
            this.btn_Pen.IconColor = System.Drawing.Color.Black;
            this.btn_Pen.IconSize = 20;
            this.btn_Pen.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pen.Image")));
            this.btn_Pen.Location = new System.Drawing.Point(93, 129);
            this.btn_Pen.Name = "btn_Pen";
            this.btn_Pen.Size = new System.Drawing.Size(20, 20);
            this.btn_Pen.TabIndex = 45;
            this.btn_Pen.TabStop = false;
            this.tt_Main.SetToolTip(this.btn_Pen, "Freehand Drawing");
            this.btn_Pen.UseVisualStyleBackColor = true;
            this.btn_Pen.Click += new System.EventHandler(this.btn_Pen_Click);
            this.btn_Pen.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // btn_Font
            // 
            this.btn_Font.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Font.Location = new System.Drawing.Point(67, 245);
            this.btn_Font.Name = "btn_Font";
            this.btn_Font.Size = new System.Drawing.Size(53, 23);
            this.btn_Font.TabIndex = 41;
            this.btn_Font.TabStop = false;
            this.btn_Font.Text = "Change";
            this.tt_Main.SetToolTip(this.btn_Font, "Change Text Font");
            this.btn_Font.UseVisualStyleBackColor = true;
            this.btn_Font.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // num_ToolSize
            // 
            this.num_ToolSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_ToolSize.Location = new System.Drawing.Point(67, 207);
            this.num_ToolSize.Name = "num_ToolSize";
            this.num_ToolSize.Size = new System.Drawing.Size(67, 20);
            this.num_ToolSize.TabIndex = 39;
            this.num_ToolSize.TabStop = false;
            this.tt_Main.SetToolTip(this.num_ToolSize, "Tool Size");
            this.num_ToolSize.ValueChanged += new System.EventHandler(this.num_ToolSize_ValueChanged_1);
            this.num_ToolSize.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(67, 183);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 20);
            this.panel1.TabIndex = 33;
            this.tt_Main.SetToolTip(this.panel1, "Tool Color");
            // 
            // p_Border
            // 
            this.p_Border.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.p_Border.BackColor = System.Drawing.Color.Black;
            this.p_Border.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p_Border.Location = new System.Drawing.Point(168, 89);
            this.p_Border.Name = "p_Border";
            this.p_Border.Size = new System.Drawing.Size(20, 20);
            this.p_Border.TabIndex = 32;
            this.p_Border.Tag = "0";
            this.tt_Main.SetToolTip(this.p_Border, "Border Color");
            // 
            // num_Border
            // 
            this.num_Border.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.num_Border.Location = new System.Drawing.Point(117, 89);
            this.num_Border.Name = "num_Border";
            this.num_Border.Size = new System.Drawing.Size(45, 20);
            this.num_Border.TabIndex = 35;
            this.num_Border.TabStop = false;
            this.tt_Main.SetToolTip(this.num_Border, "Border Width");
            this.num_Border.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_Border.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // cb_Border
            // 
            this.cb_Border.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Border.AutoSize = true;
            this.cb_Border.Location = new System.Drawing.Point(93, 92);
            this.cb_Border.Name = "cb_Border";
            this.cb_Border.Size = new System.Drawing.Size(15, 14);
            this.cb_Border.TabIndex = 34;
            this.cb_Border.TabStop = false;
            this.tt_Main.SetToolTip(this.cb_Border, "Enable Border");
            this.cb_Border.UseVisualStyleBackColor = true;
            this.cb_Border.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // p_BgColor
            // 
            this.p_BgColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.p_BgColor.BackColor = System.Drawing.Color.White;
            this.p_BgColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.p_BgColor.Location = new System.Drawing.Point(168, 54);
            this.p_BgColor.Name = "p_BgColor";
            this.p_BgColor.Size = new System.Drawing.Size(20, 20);
            this.p_BgColor.TabIndex = 30;
            this.p_BgColor.Tag = "0";
            this.tt_Main.SetToolTip(this.p_BgColor, "Background Color");
            // 
            // r_BgColor
            // 
            this.r_BgColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.r_BgColor.AutoSize = true;
            this.r_BgColor.Location = new System.Drawing.Point(93, 58);
            this.r_BgColor.Name = "r_BgColor";
            this.r_BgColor.Size = new System.Drawing.Size(49, 17);
            this.r_BgColor.TabIndex = 29;
            this.r_BgColor.Text = "Color";
            this.tt_Main.SetToolTip(this.r_BgColor, "Enable Background Color");
            this.r_BgColor.UseVisualStyleBackColor = true;
            this.r_BgColor.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // r_BgTransparent
            // 
            this.r_BgTransparent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.r_BgTransparent.AutoSize = true;
            this.r_BgTransparent.Checked = true;
            this.r_BgTransparent.Location = new System.Drawing.Point(93, 35);
            this.r_BgTransparent.Name = "r_BgTransparent";
            this.r_BgTransparent.Size = new System.Drawing.Size(82, 17);
            this.r_BgTransparent.TabIndex = 28;
            this.r_BgTransparent.TabStop = true;
            this.r_BgTransparent.Text = "Transparent";
            this.tt_Main.SetToolTip(this.r_BgTransparent, "Disable Background Color");
            this.r_BgTransparent.UseVisualStyleBackColor = true;
            this.r_BgTransparent.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.btn_Dock_PreviewKeyDown);
            // 
            // elementHost1
            // 
            this.elementHost1.BackColorTransparent = true;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(893, 573);
            this.elementHost1.TabIndex = 3;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.el_EditLayer1;
            // 
            // ts_Tools
            // 
            this.ts_Tools.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ts_Tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.btn_ToolSelector,
            this.btn_ToolColorPick,
            this.tb_ToolSize,
            this.toolStripLabel5,
            this.btn_FontSelect,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.cb_Background,
            this.btn_BGColorPick,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.cb_BorderOn,
            this.tb_BorderSize,
            this.toolStripLabel3,
            this.btn_BorderColorPick,
            this.btn_ToolWindow,
            this.btn_ToolPanel});
            this.ts_Tools.Location = new System.Drawing.Point(0, 0);
            this.ts_Tools.Name = "ts_Tools";
            this.ts_Tools.Size = new System.Drawing.Size(926, 25);
            this.ts_Tools.TabIndex = 0;
            this.ts_Tools.Visible = false;
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabel4.Text = "Tool:";
            // 
            // btn_ToolSelector
            // 
            this.btn_ToolSelector.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_ToolSelector.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointerToolStripMenuItem,
            this.pencilToolStripMenuItem,
            this.textMarkerToolStripMenuItem,
            this.lineToolToolStripMenuItem,
            this.rectangleToolStripMenuItem,
            this.ovalToolStripMenuItem,
            this.textToolStripMenuItem,
            this.arrowToolToolStripMenuItem,
            this.eraserToolStripMenuItem});
            this.btn_ToolSelector.Icon = FontAwesome.Sharp.IconChar.MousePointer;
            this.btn_ToolSelector.IconColor = System.Drawing.Color.Black;
            this.btn_ToolSelector.IconSize = 30;
            this.btn_ToolSelector.Image = ((System.Drawing.Image)(resources.GetObject("btn_ToolSelector.Image")));
            this.btn_ToolSelector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ToolSelector.Name = "btn_ToolSelector";
            this.btn_ToolSelector.Size = new System.Drawing.Size(29, 22);
            this.btn_ToolSelector.Text = "iconDropDownButton1";
            this.btn_ToolSelector.ToolTipText = "Select Tool";
            // 
            // pointerToolStripMenuItem
            // 
            this.pointerToolStripMenuItem.Name = "pointerToolStripMenuItem";
            this.pointerToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.pointerToolStripMenuItem.Text = "Handle Cutouts";
            this.pointerToolStripMenuItem.ToolTipText = "Handle Cutouts";
            // 
            // pencilToolStripMenuItem
            // 
            this.pencilToolStripMenuItem.Name = "pencilToolStripMenuItem";
            this.pencilToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.pencilToolStripMenuItem.Text = "Pencil";
            this.pencilToolStripMenuItem.ToolTipText = "Freehand Drawing";
            // 
            // textMarkerToolStripMenuItem
            // 
            this.textMarkerToolStripMenuItem.Name = "textMarkerToolStripMenuItem";
            this.textMarkerToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.textMarkerToolStripMenuItem.Text = "Highlighter";
            this.textMarkerToolStripMenuItem.ToolTipText = "Highlighter Tool";
            // 
            // lineToolToolStripMenuItem
            // 
            this.lineToolToolStripMenuItem.Name = "lineToolToolStripMenuItem";
            this.lineToolToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.lineToolToolStripMenuItem.Text = "Straight Line";
            this.lineToolToolStripMenuItem.ToolTipText = "Straight Line Tool";
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.rectangleToolStripMenuItem.Text = "Rectangle";
            this.rectangleToolStripMenuItem.ToolTipText = "Rectangle Tool";
            // 
            // ovalToolStripMenuItem
            // 
            this.ovalToolStripMenuItem.Name = "ovalToolStripMenuItem";
            this.ovalToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ovalToolStripMenuItem.Text = "Ellipse";
            this.ovalToolStripMenuItem.ToolTipText = "Ellipse Tool";
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.textToolStripMenuItem.Text = "Text";
            this.textToolStripMenuItem.ToolTipText = "Text Tool";
            // 
            // arrowToolToolStripMenuItem
            // 
            this.arrowToolToolStripMenuItem.Name = "arrowToolToolStripMenuItem";
            this.arrowToolToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.arrowToolToolStripMenuItem.Text = "Arrow";
            this.arrowToolToolStripMenuItem.ToolTipText = "Arrow Tool";
            // 
            // eraserToolStripMenuItem
            // 
            this.eraserToolStripMenuItem.Name = "eraserToolStripMenuItem";
            this.eraserToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.eraserToolStripMenuItem.Text = "Eraser";
            this.eraserToolStripMenuItem.ToolTipText = "Eraser";
            // 
            // btn_ToolColorPick
            // 
            this.btn_ToolColorPick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_ToolColorPick.Icon = FontAwesome.Sharp.IconChar.Tint;
            this.btn_ToolColorPick.IconColor = System.Drawing.Color.Black;
            this.btn_ToolColorPick.IconSize = 30;
            this.btn_ToolColorPick.Image = ((System.Drawing.Image)(resources.GetObject("btn_ToolColorPick.Image")));
            this.btn_ToolColorPick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ToolColorPick.Name = "btn_ToolColorPick";
            this.btn_ToolColorPick.Size = new System.Drawing.Size(23, 22);
            this.btn_ToolColorPick.ToolTipText = "Tool Color";
            // 
            // tb_ToolSize
            // 
            this.tb_ToolSize.AutoSize = false;
            this.tb_ToolSize.Name = "tb_ToolSize";
            this.tb_ToolSize.Size = new System.Drawing.Size(25, 25);
            this.tb_ToolSize.Text = "3";
            this.tb_ToolSize.ToolTipText = "Tool Size";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(19, 22);
            this.toolStripLabel5.Text = "px";
            // 
            // btn_FontSelect
            // 
            this.btn_FontSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_FontSelect.Icon = FontAwesome.Sharp.IconChar.Font;
            this.btn_FontSelect.IconColor = System.Drawing.Color.Black;
            this.btn_FontSelect.IconSize = 30;
            this.btn_FontSelect.Image = ((System.Drawing.Image)(resources.GetObject("btn_FontSelect.Image")));
            this.btn_FontSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_FontSelect.Name = "btn_FontSelect";
            this.btn_FontSelect.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btn_FontSelect.Size = new System.Drawing.Size(30, 22);
            this.btn_FontSelect.ToolTipText = "Select Font";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(74, 22);
            this.toolStripLabel1.Text = "Background:";
            // 
            // cb_Background
            // 
            this.cb_Background.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cb_Background.Icon = FontAwesome.Sharp.IconChar.CheckSquareO;
            this.cb_Background.IconColor = System.Drawing.Color.Black;
            this.cb_Background.IconSize = 30;
            this.cb_Background.Image = ((System.Drawing.Image)(resources.GetObject("cb_Background.Image")));
            this.cb_Background.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cb_Background.Name = "cb_Background";
            this.cb_Background.Size = new System.Drawing.Size(23, 22);
            this.cb_Background.ToolTipText = "Enable/Disable Background Color";
            // 
            // btn_BGColorPick
            // 
            this.btn_BGColorPick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_BGColorPick.Icon = FontAwesome.Sharp.IconChar.Tint;
            this.btn_BGColorPick.IconColor = System.Drawing.Color.Black;
            this.btn_BGColorPick.IconSize = 30;
            this.btn_BGColorPick.Image = ((System.Drawing.Image)(resources.GetObject("btn_BGColorPick.Image")));
            this.btn_BGColorPick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_BGColorPick.Name = "btn_BGColorPick";
            this.btn_BGColorPick.Size = new System.Drawing.Size(23, 22);
            this.btn_BGColorPick.ToolTipText = "Background Color";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel2.Text = "Border: ";
            // 
            // cb_BorderOn
            // 
            this.cb_BorderOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cb_BorderOn.Icon = FontAwesome.Sharp.IconChar.CheckSquareO;
            this.cb_BorderOn.IconColor = System.Drawing.Color.Black;
            this.cb_BorderOn.IconSize = 30;
            this.cb_BorderOn.Image = ((System.Drawing.Image)(resources.GetObject("cb_BorderOn.Image")));
            this.cb_BorderOn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cb_BorderOn.Name = "cb_BorderOn";
            this.cb_BorderOn.Size = new System.Drawing.Size(23, 22);
            this.cb_BorderOn.ToolTipText = "Enable/Disable Border";
            // 
            // tb_BorderSize
            // 
            this.tb_BorderSize.AutoSize = false;
            this.tb_BorderSize.Name = "tb_BorderSize";
            this.tb_BorderSize.Size = new System.Drawing.Size(25, 25);
            this.tb_BorderSize.Text = "10";
            this.tb_BorderSize.ToolTipText = "Border Width";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(19, 22);
            this.toolStripLabel3.Text = "px";
            // 
            // btn_BorderColorPick
            // 
            this.btn_BorderColorPick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_BorderColorPick.Icon = FontAwesome.Sharp.IconChar.Tint;
            this.btn_BorderColorPick.IconColor = System.Drawing.Color.Black;
            this.btn_BorderColorPick.IconSize = 30;
            this.btn_BorderColorPick.Image = ((System.Drawing.Image)(resources.GetObject("btn_BorderColorPick.Image")));
            this.btn_BorderColorPick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_BorderColorPick.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.btn_BorderColorPick.Name = "btn_BorderColorPick";
            this.btn_BorderColorPick.Size = new System.Drawing.Size(23, 22);
            this.btn_BorderColorPick.ToolTipText = "Border Color";
            // 
            // btn_ToolWindow
            // 
            this.btn_ToolWindow.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_ToolWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_ToolWindow.Icon = FontAwesome.Sharp.IconChar.ArrowRight;
            this.btn_ToolWindow.IconColor = System.Drawing.Color.Black;
            this.btn_ToolWindow.IconSize = 30;
            this.btn_ToolWindow.Image = ((System.Drawing.Image)(resources.GetObject("btn_ToolWindow.Image")));
            this.btn_ToolWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ToolWindow.Name = "btn_ToolWindow";
            this.btn_ToolWindow.Size = new System.Drawing.Size(23, 22);
            this.btn_ToolWindow.ToolTipText = "Switch to panel";
            this.btn_ToolWindow.Click += new System.EventHandler(this.btn_ToolWindow_Click);
            // 
            // btn_ToolPanel
            // 
            this.btn_ToolPanel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btn_ToolPanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_ToolPanel.Icon = FontAwesome.Sharp.IconChar.ArrowsAlt;
            this.btn_ToolPanel.IconColor = System.Drawing.Color.Black;
            this.btn_ToolPanel.IconSize = 30;
            this.btn_ToolPanel.Image = ((System.Drawing.Image)(resources.GetObject("btn_ToolPanel.Image")));
            this.btn_ToolPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_ToolPanel.Name = "btn_ToolPanel";
            this.btn_ToolPanel.Size = new System.Drawing.Size(23, 22);
            this.btn_ToolPanel.ToolTipText = "Switch to Floating Window";
            this.btn_ToolPanel.Click += new System.EventHandler(this.btn_ToolPanel_Click);
            // 
            // p_Tools
            // 
            this.p_Tools.BackColor = System.Drawing.SystemColors.Control;
            this.p_Tools.Controls.Add(this.label7);
            this.p_Tools.Controls.Add(this.btn_Manipulate);
            this.p_Tools.Controls.Add(this.btn_ToolStrip);
            this.p_Tools.Controls.Add(this.btn_Dock);
            this.p_Tools.Controls.Add(this.btn_Eraser);
            this.p_Tools.Controls.Add(this.btn_Line);
            this.p_Tools.Controls.Add(this.btn_Marker);
            this.p_Tools.Controls.Add(this.btn_Arrow);
            this.p_Tools.Controls.Add(this.btn_Text);
            this.p_Tools.Controls.Add(this.btn_Oval);
            this.p_Tools.Controls.Add(this.btn_Square);
            this.p_Tools.Controls.Add(this.btn_Pen);
            this.p_Tools.Controls.Add(this.btn_Font);
            this.p_Tools.Controls.Add(this.label6);
            this.p_Tools.Controls.Add(this.num_ToolSize);
            this.p_Tools.Controls.Add(this.label5);
            this.p_Tools.Controls.Add(this.panel1);
            this.p_Tools.Controls.Add(this.label4);
            this.p_Tools.Controls.Add(this.label3);
            this.p_Tools.Controls.Add(this.p_Border);
            this.p_Tools.Controls.Add(this.num_Border);
            this.p_Tools.Controls.Add(this.cb_Border);
            this.p_Tools.Controls.Add(this.label2);
            this.p_Tools.Controls.Add(this.p_BgColor);
            this.p_Tools.Controls.Add(this.r_BgColor);
            this.p_Tools.Controls.Add(this.r_BgTransparent);
            this.p_Tools.Controls.Add(this.label8);
            this.p_Tools.Controls.Add(this.label1);
            this.p_Tools.Dock = System.Windows.Forms.DockStyle.Right;
            this.p_Tools.Location = new System.Drawing.Point(926, 0);
            this.p_Tools.Name = "p_Tools";
            this.p_Tools.Size = new System.Drawing.Size(200, 606);
            this.p_Tools.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(135, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "px";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Font: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Tool Size: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Tool Color: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Tool: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Border: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Background:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tools";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // f_Screen
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1126, 606);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.sb_PrecMovLR);
            this.Controls.Add(this.sb_PrecMovUD);
            this.Controls.Add(this.ts_Tools);
            this.Controls.Add(this.p_Tools);
            this.KeyPreview = true;
            this.Name = "f_Screen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.f_Screen_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.f_Screen_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.f_Screen_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.f_Screen_DragOver);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_Screen_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.num_ToolSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Border)).EndInit();
            this.ts_Tools.ResumeLayout(false);
            this.ts_Tools.PerformLayout();
            this.p_Tools.ResumeLayout(false);
            this.p_Tools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconButton btn_Manipulate;
        private FontAwesome.Sharp.IconButton btn_Dock;
        private FontAwesome.Sharp.IconButton btn_Eraser;
        private FontAwesome.Sharp.IconButton btn_Line;
        private FontAwesome.Sharp.IconButton btn_Marker;
        private FontAwesome.Sharp.IconButton btn_Arrow;
        private FontAwesome.Sharp.IconButton btn_Text;
        private FontAwesome.Sharp.IconButton btn_Oval;
        private FontAwesome.Sharp.IconButton btn_Square;
        private FontAwesome.Sharp.IconButton btn_Pen;
        private System.Windows.Forms.Button btn_Font;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown num_ToolSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel p_Border;
        private System.Windows.Forms.NumericUpDown num_Border;
        private System.Windows.Forms.CheckBox cb_Border;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel p_BgColor;
        private System.Windows.Forms.RadioButton r_BgColor;
        private System.Windows.Forms.RadioButton r_BgTransparent;
        private System.Windows.Forms.Label label8;
		private FontAwesome.Sharp.IconButton btn_ToolStrip;
		private System.Windows.Forms.ToolStripLabel toolStripLabel4;
		private FontAwesome.Sharp.IconDropDownButton btn_ToolSelector;
		private System.Windows.Forms.ToolStripMenuItem pointerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pencilToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem textMarkerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lineToolToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ovalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem arrowToolToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem eraserToolStripMenuItem;
		private FontAwesome.Sharp.IconToolStripButton btn_ToolColorPick;
		private System.Windows.Forms.ToolStripTextBox tb_ToolSize;
		private System.Windows.Forms.ToolStripLabel toolStripLabel5;
		private FontAwesome.Sharp.IconToolStripButton btn_FontSelect;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private FontAwesome.Sharp.IconToolStripButton btn_BGColorPick;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private FontAwesome.Sharp.IconToolStripButton cb_BorderOn;
		private System.Windows.Forms.ToolStripTextBox tb_BorderSize;
		private System.Windows.Forms.ToolStripLabel toolStripLabel3;
		private FontAwesome.Sharp.IconToolStripButton btn_BorderColorPick;
		private FontAwesome.Sharp.IconToolStripButton btn_ToolWindow;
		private FontAwesome.Sharp.IconToolStripButton btn_ToolPanel;
		private System.Windows.Forms.VScrollBar sb_PrecMovUD;
		private System.Windows.Forms.HScrollBar sb_PrecMovLR;
		private System.Windows.Forms.Timer t_Tick;
		private myPanel p_Tools;
		private System.Windows.Forms.ToolTip tt_Main;
		private FontAwesome.Sharp.IconToolStripButton cb_Background;
		private System.Windows.Forms.Integration.ElementHost elementHost1;
		private uc_WpfEditLayer el_EditLayer1;
		private myToolstrip ts_Tools;
	}
}