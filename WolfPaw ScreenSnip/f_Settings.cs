﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WolfPaw_ScreenSnip
{
	public partial class f_Settings : Form
	{
		public f_Settings()
		{
			InitializeComponent();
			Load += F_Settings_Load;
		}

		private void F_Settings_Load(object sender, EventArgs e)
		{
			loadSettings();
		}

		public void loadSettings()
		{
			num_MonitorToUse.Maximum = Screen.AllScreens.Length;

		//GENERAL
			//SAVE
			cb_SaveFileNameDateTime.Checked = Properties.Settings.Default.s_SaveHasDateTime;
			tb_QuickSaveDir.Text = Properties.Settings.Default.s_QuickSaveDir;
			//DELAY
			cb_SnipHasDelay.Checked = Properties.Settings.Default.s_hasDelay;
			num_DelayLength.Value = Properties.Settings.Default.s_delayLength;
			num_BaseDelay.Value = Properties.Settings.Default.s_BaseDelay;
			//MISC
			cb_ShowTooltips.Checked = Properties.Settings.Default.s_ShowTooltipOnMouseOver;
			cb_ShowTooltipsOnCutout.Checked = Properties.Settings.Default.s_ShowTooltipOnCutout;
			cb_SaveBackup.Checked = Properties.Settings.Default.s_KeepEditImage;

			//PROGRAM
			//MAIN
			cb_UseCleanButtons.Checked = Properties.Settings.Default.s_UseCleanButtons;
			num_ButtonSize.Value = Properties.Settings.Default.s_ButtonSize;
			cb_MoveToTray.Checked = Properties.Settings.Default.s_MoveToTools;
			cb_RememberLastPosition.Checked = Properties.Settings.Default.s_RememberLastPosition;
			//SCREEN
			cb_HandlePrintScreen.Checked = Properties.Settings.Default.s_handlePrintScreen;
			cb_HandleShortcuts.Checked = Properties.Settings.Default.s_HandleShortcuts;
			p_ScreenBackground.BackColor = Properties.Settings.Default.s_ScreenBGColor;
			cb_AutBeforeDelete.Checked = Properties.Settings.Default.s_ClearRequireAuth;
			//PREVIEW
			cb_PreviewOnOpen.Checked = Properties.Settings.Default.s_ShowPreview;
			cb_PreviewStyle.SelectedIndex = Properties.Settings.Default.s_LastPreviewMode;
			//CUTOUT
			p_PanelColor.BackColor = Properties.Settings.Default.s_CutoutPanelColor;
			p_SelectionBorderColor.BackColor = Properties.Settings.Default.s_CutoutSelectionColor;
			p_MouseoverBorderColor.BackColor = Properties.Settings.Default.s_CutoutMouseOverColor;
			cb_AllowDragaround.Checked = Properties.Settings.Default.s_AllowDragaround;
			cb_DragaroundMode.SelectedIndex = (Properties.Settings.Default.s_DragaroundX && Properties.Settings.Default.s_DragaroundY ? 2 : (Properties.Settings.Default.s_DragaroundX ? 0 : 1));

			//CANVAS
			//DISPLAY
			num_CanvasTransparency.Value = (decimal)Properties.Settings.Default.s_CanvasTransparency;
			p_CanvasColor.BackColor = Properties.Settings.Default.s_CanvasColor;
			//ADDITIONAL
			cb_AlwaysShowRuler.Checked = Properties.Settings.Default.s_AlwaysHaveRuler;
			cb_DrawRulerBG.Checked = Properties.Settings.Default.s_DrawRulerBackground;
			cb_DrawPositionData.Checked = Properties.Settings.Default.s_DrawPosiData;
			cb_DrawCrosshairs.Checked = Properties.Settings.Default.s_DrawCrosshairs;
			cb_DPIType.SelectedIndex = Properties.Settings.Default.s_DPIType;
			num_MonitorToUse.Value = (Screen.AllScreens.Length >= Properties.Settings.Default.s_UseMonitorForDpi + 1) ? Properties.Settings.Default.s_UseMonitorForDpi + 1 : 1;

		//RENDER
			//IQS
			cb_SmoothingMode.SelectedIndex = Properties.Settings.Default.s_g_SmoothingMode;
			cb_InterpolationMode.SelectedIndex = Properties.Settings.Default.s_g_InterpolationMode;
			cb_PixelOffsetMode.SelectedIndex = Properties.Settings.Default.s_g_PixelOffsetMode;
		}

		public void openHelp()
		{
			tc_Tabs.SelectedIndex = 4;
		}

		public void saveSettings()
		{
		//GENERAL
			//SAVE
			Properties.Settings.Default.s_SaveHasDateTime = cb_SaveFileNameDateTime.Checked;
			Properties.Settings.Default.s_QuickSaveDir = tb_QuickSaveDir.Text;
			//DELAY
			Properties.Settings.Default.s_hasDelay = cb_SnipHasDelay.Checked;
			Properties.Settings.Default.s_delayLength = (int)num_DelayLength.Value;
			Properties.Settings.Default.s_BaseDelay = (int)num_BaseDelay.Value;
			//MISC
			Properties.Settings.Default.s_ShowTooltipOnMouseOver = cb_ShowTooltips.Checked;
			Properties.Settings.Default.s_ShowTooltipOnCutout = cb_ShowTooltipsOnCutout.Checked;
			Properties.Settings.Default.s_KeepEditImage = cb_SaveBackup.Checked;

		//PROGRAM
			//MAIN
			Properties.Settings.Default.s_UseCleanButtons = cb_UseCleanButtons.Checked;
			Properties.Settings.Default.s_ButtonSize = (int)num_ButtonSize.Value;
			Properties.Settings.Default.s_MoveToTools = cb_MoveToTray.Checked;
			Properties.Settings.Default.s_RememberLastPosition = cb_RememberLastPosition.Checked;
			//SCREEN
			Properties.Settings.Default.s_handlePrintScreen = cb_HandlePrintScreen.Checked;
			Properties.Settings.Default.s_HandleShortcuts = cb_HandleShortcuts.Checked;
			Properties.Settings.Default.s_ScreenBGColor = p_ScreenBackground.BackColor;
			Properties.Settings.Default.s_ClearRequireAuth = cb_AutBeforeDelete.Checked;
			//PREVIEW
			Properties.Settings.Default.s_ShowPreview = cb_PreviewOnOpen.Checked;
			Properties.Settings.Default.s_LastPreviewMode = cb_PreviewStyle.SelectedIndex;
			//CUTOUT
			Properties.Settings.Default.s_CutoutPanelColor = p_PanelColor.BackColor;
			Properties.Settings.Default.s_CutoutSelectionColor = p_SelectionBorderColor.BackColor;
			Properties.Settings.Default.s_CutoutMouseOverColor = p_MouseoverBorderColor.BackColor;
			Properties.Settings.Default.s_AllowDragaround = cb_AllowDragaround.Checked;
			Properties.Settings.Default.s_DragaroundX = (cb_DragaroundMode.SelectedIndex == 0 || cb_DragaroundMode.SelectedIndex == 2) ? true : false;
			Properties.Settings.Default.s_DragaroundY = (cb_DragaroundMode.SelectedIndex == 1 || cb_DragaroundMode.SelectedIndex == 2) ? true : false;

		//CANVAS
			//DISPLAY
			Properties.Settings.Default.s_CanvasTransparency = (float)num_CanvasTransparency.Value;
			Properties.Settings.Default.s_CanvasColor = p_CanvasColor.BackColor;
			//ADDITIONAL
			Properties.Settings.Default.s_AlwaysHaveRuler = cb_AlwaysShowRuler.Checked;
			Properties.Settings.Default.s_DrawRulerBackground = cb_DrawRulerBG.Checked;
			Properties.Settings.Default.s_DrawPosiData = cb_DrawPositionData.Checked;
			Properties.Settings.Default.s_DrawCrosshairs = cb_DrawCrosshairs.Checked;
			Properties.Settings.Default.s_DPIType = cb_DPIType.SelectedIndex;
			Properties.Settings.Default.s_UseMonitorForDpi = (int)num_MonitorToUse.Value - 1;

		//RENDER
			//IQS
			Properties.Settings.Default.s_g_SmoothingMode = cb_SmoothingMode.SelectedIndex;
			Properties.Settings.Default.s_g_InterpolationMode = cb_InterpolationMode.SelectedIndex;
			Properties.Settings.Default.s_g_PixelOffsetMode = cb_PixelOffsetMode.SelectedIndex;
			Properties.Settings.Default.Save();
		}


		public Color getColor(Color oColor)
		{
			Color cc = new Color();
			ColorDialog cd = new ColorDialog
			{
				Color = oColor
			};

			if (cd.ShowDialog() == DialogResult.OK)
			{
				cc = cd.Color;
			}
			else
			{
				cc = oColor;
			}

			return cc;
		}


		private void btn_Close_Click(object sender, EventArgs e)
		{
			saveSettings();
			this.Close();
		}

		private void tp_Program_Click(object sender, EventArgs e)
		{

		}

		private void btn_GeneralSettings_Click(object sender, EventArgs e)
		{
			tc_Tabs.SelectedIndex = 0;
		}

		private void btn_ProgramSettings_Click(object sender, EventArgs e)
		{
			tc_Tabs.SelectedIndex = 1;
		}

		private void btn_CanvasSettings_Click(object sender, EventArgs e)
		{
			tc_Tabs.SelectedIndex = 2;
		}

		private void btn_RenderSettings_Click(object sender, EventArgs e)
		{
			tc_Tabs.SelectedIndex = 3;
		}

		private void btn_Help_Click(object sender, EventArgs e)
		{
			tc_Tabs.SelectedIndex = 4;
		}

		private void btn_About_Click(object sender, EventArgs e)
		{
			tc_Tabs.SelectedIndex = 5;
		}

		private void btn_Bugreport_Click(object sender, EventArgs e)
		{
			tc_Tabs.SelectedIndex = 7;
		}

		private void btn_Shortcuts_Click(object sender, EventArgs e)
		{
			tc_Tabs.SelectedIndex = 6;
		}

		private void btn_QuickSetup_HQ_Click(object sender, EventArgs e)
		{
			cb_SmoothingMode.SelectedIndex = 3;
			cb_InterpolationMode.SelectedIndex = 3;
			cb_PixelOffsetMode.SelectedIndex = 3;
		}

		private void btn_QuickSetup_OK_Click(object sender, EventArgs e)
		{
			cb_SmoothingMode.SelectedIndex = 1;
			cb_InterpolationMode.SelectedIndex = 2;
			cb_PixelOffsetMode.SelectedIndex = 2;
		}

		private void btn_QuickSetup_LQ_Click(object sender, EventArgs e)
		{
			cb_SmoothingMode.SelectedIndex = 0;
			cb_InterpolationMode.SelectedIndex = 6;
			cb_PixelOffsetMode.SelectedIndex = 0;
		}

		private void p_CanvasColor_Click(object sender, EventArgs e)
		{
			p_CanvasColor.BackColor = getColor(p_CanvasColor.BackColor);
		}

		private void p_ScreenBackground_Click(object sender, EventArgs e)
		{
			p_ScreenBackground.BackColor = getColor(p_ScreenBackground.BackColor);
		}

		private void p_PanelColor_Click(object sender, EventArgs e)
		{
			p_PanelColor.BackColor = getColor(p_PanelColor.BackColor);
		}

		private void p_SelectionBorderColor_Click(object sender, EventArgs e)
		{
			p_SelectionBorderColor.BackColor = getColor(p_SelectionBorderColor.BackColor);
		}

		private void p_MouseoverBorderColor_Click(object sender, EventArgs e)
		{
			p_MouseoverBorderColor.BackColor = getColor(p_MouseoverBorderColor.BackColor);
		}

		private void btn_BrowseQSDir_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if(tb_QuickSaveDir.Text != "" && Directory.Exists(tb_QuickSaveDir.Text)) { fbd.SelectedPath = tb_QuickSaveDir.Text; }
			if(fbd.ShowDialog() == DialogResult.OK)
			{
				tb_QuickSaveDir.Text = fbd.SelectedPath;
			}
		}

		private void WriteHelpString(object sender, EventArgs e)
		{
			String str = "";
			int i = 0;
			int.TryParse((sender as Label).Tag.ToString(), out i);

			switch (i)
			{
				case 0:
					str = "Automatically add date and time to the name of the save file.";
					break;
					
				case 1:
					str = "Directory where the images are saved when quicksaving. File names are 'ScreenSnip_Date_Time.Extension'";
					break;
					
				case 2:
					str = "If this checkbox is set to true, the program will delay the snipping by default. This default setting can be overridden with the checkbox on the main form";
					break;

				case 3:
					str = "The amount of time the program will wait before opening the Snipping canvas, if delay is turned on.";
					break;

				case 4:
					str = "The amount of time the program is delayed by default before opening the cavas. This is necessary on slower computers, to have time to hide the program before opening the canvas. If you can see the program or screen when snipping, you need to set this value higher.";
					break;

				case 5:
					str = "If this is turned on the program will use the new, clean buttons instead of the old outdated ones. This change requires a restart to take effect!";
					break;

				case 6:
					str = "This value sets the size of the buttons on the main screen. This change requires a restart to take effect!";
					break;

				case 7:
					str = "If this box i checked, when minimizing the program it will minimize to the notification area on the tray (next to the clock) instead of just the tray as usual.";
					break;

				case 8:
					str = "If this box is checked, the main window will reopen where you last moved it to. Otherwise it will always open at the upper left corner of your screen.";
					break;

				case 9:
					str = "This box determines weather the program should detect when the PrintScreen button is pressed and open the picture in the screen";
					break;

				case 10:
					str = "This box determines weather the program should detect the shortcut keys (ctrl + F1-F5).";
					break;

				case 11:
					str = "The background color of the screen.";
					break;

				case 12:
					str = "If this box is checked, the program will warn you about unsaved changes in your picture when you close the screen.";
					break;

				case 13:
					str = "If this box is checked, when opening the screen you will see a live preiview of what your end picture will look like (can be memory intensive)";
					break;

				case 14:
					str = "Type of preview. Window is a free floating window you can place anywhere. Panelbox is a static box that shows in your tools panel.";
					break;

				case 15:
					str = "The color of the button panel of the image boxes on the screen.";
					break;

				case 16:
					str = "The color of the border of the image boxes when they are selected.";
					break;

				case 17:
					str = "The color of the border of the image boxes when the mouse is over them but they are not selected.";
					break;

				case 18:
					str = "Allows dragaround mode. In dragaround mode you can keep moving your mouse to one direction infinitely. Useful for moving large pictures.";
					break;

				case 19:
					str = "Dragaround mode. Horizontal allowes you to drag infinitely from left to right or right to left. Vertical allows you to drag infinitely up or down. Both allows both directions simultaneously.";
					break;

				case 20:
					str = "The Opacity of the color overlay on the canvas when cutting. Higher value will make the overlay more visible.";
					break;

				case 21:
					str = "The color of the overlay on the canvas.";
					break;

				case 22:
					str = "If this is checked, rulers will always show on the canvas when cutting. Otherwise rulers will only show when holding the Alt key.";
					break;

				case 23:
					str = "If this is checked, the ruler will have a white background, otherwise it will be transparent.";
					break;

				case 24:
					str = "If this is checked position data will be drawn to the screen near the mouse pointer when ruler is visible.";
					break;

				case 25:
					str = "If this is checked, crosshairs will be drawn on the screen when ruler is visible.";
					break;

				case 26:
					str = "You can select the measurements of the ruler on screen. You can select between Centimeters, Inches, and an even distance of 100 pixels.";
					break;

				case 27:
					str = "If you have multiple monitors with different DPI characteristics, you can select which one to use as standard for the measurements.";
					break;

				case 28:
					str = "Smoothing mode. This value determines the level of antialiasing on the rendered images.";
					break;

				case 29:
					str = "Interpolation mode. This value determines the quality of an image after scaling or rotating it.";
					break;

				case 30:
					str = "Pixel offset mode. This value determines image quality based on pixel offsetting.";
					break;

				case 31:
					str = "If this is turned on, tooltips will show when you hover your cursor over controls.";
					break;

				case 32:
					str = "If this is turned on, the information about cutout buttons will show as tooltips instead of text in the description box.";
					break;

				case 33:
					str = "If this box is checked, the program will attempt to save a screenshot for every cutout you make to make it possible to recut them in editing.";
					break;

				default:
					str = "";
					break;


			}

			lbl_Description.Text = str;
			setEffect();
		}

		int effectCurrent = 0;
		int effectMax = 10;
		bool effectUp = false;

		public void setEffect()
		{
			if (t_effect.Enabled == false)
			{
				effectCurrent = 0;
				effectUp = false;
				t_effect.Start();
			}
		}

		private void t_effect_Tick(object sender, EventArgs e)
		{
			if (!effectUp)
			{
				if (effectCurrent < effectMax)
				{
					Color c = lbl_DescTitle.BackColor;

					lbl_DescTitle.BackColor = Color.FromArgb(255, c.R - 2, c.G - 2, c.B - 2);

					effectCurrent++;
				}
				else
				{
					effectUp = true;
				}
			}
			else
			{
				if (effectCurrent > 0)
				{
					Color c = lbl_DescTitle.BackColor;

					lbl_DescTitle.BackColor = Color.FromArgb(255, c.R + 2, c.G + 2, c.B + 2);

					effectCurrent--;
				}
				else
				{
					t_effect.Stop();
				}
			}
		}
	}
}