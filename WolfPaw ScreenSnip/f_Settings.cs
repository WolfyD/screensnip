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
			p_Buttons.BackColor = Properties.Settings.Default.s_CutoutPanelColor;
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
			Properties.Settings.Default.s_CutoutPanelColor = p_Buttons.BackColor;
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
			ColorDialog cd = new ColorDialog();
			cd.Color = oColor;

			if(cd.ShowDialog() == DialogResult.OK)
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
	}
}
