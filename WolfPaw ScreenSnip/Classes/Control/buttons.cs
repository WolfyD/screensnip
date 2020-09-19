using System.Collections.Generic;

namespace WolfPaw_ScreenSnip
{
    public class buttons
	{
		public List<CustomPanelButton> btns = new List<CustomPanelButton>();
		private int wid;
		public int panelWidth { get { return wid; } set { wid = value; SetupButtons(wid); } }
		public CustomPanelButton.HiddenVal currentValue = CustomPanelButton.HiddenVal.FullWidth;
		/// <summary>
		/// <para>1,	//Resize	 </para>
		/// <para>1,	//Fullscreen </para>
		/// <para>1,	//Layerup	 </para>
		/// <para>1,	//Layerdown	 </para>
		/// <para>0,	//CMS		 </para>
		/// <para>1,	//Edit		 </para>
		/// <para>1,	//Save		 </para>
		/// <para>1,	//Copy		 </para>
		/// <para>1	//Delete		 </para>
		/// </summary>
		public int[] visibleButtons = new int[] 
		{
			1,	//Resize
			1,	//Fullscreen
			1,	//Layerup
			1,	//Layerdown
			0,	//CMS
			1,	//Edit
			1,	//Save
			1,	//Copy
			1	//Delete
		};

		public void Add(CustomPanelButton button)
		{
			btns.Add(button);
		}

		public void Remove(CustomPanelButton button)
		{
			btns.Remove(button);
		}

		public void GetCurrentValue(int w)
		{
			if (w >= 175)
			{
				currentValue = CustomPanelButton.HiddenVal.FullWidth;
			}
			else if (w >= 135)
			{
				currentValue = CustomPanelButton.HiddenVal.W175;
			}
			else if (w >= 65)
			{
				currentValue = CustomPanelButton.HiddenVal.W135;
			}
			else
			{
				currentValue = CustomPanelButton.HiddenVal.W065;
			}
		}
		
		public void SetupButtons(int w)
		{
			GetCurrentValue(w);

			foreach (CustomPanelButton b in btns)
			{
				if (b.HiddenAtVal != CustomPanelButton.HiddenVal.FullWidthOnly)
				{
					if (currentValue < b.HiddenAtVal)
					{
						b.visible = true;
						b.Pos = b.originalPos;
					}
					else
					{
						b.visible = false;
						b.Pos = -9999;
					}
				}
				else
				{
					if (currentValue != CustomPanelButton.HiddenVal.FullWidth)
					{
						b.visible = true;
						if(currentValue < CustomPanelButton.HiddenVal.W135)
						{
							b.Pos = 4;
						}
						else if(currentValue == CustomPanelButton.HiddenVal.W135)
						{
							b.Pos = 1;
						}
						else
						{
							b.Pos = 0;
						}
					}
					else
					{
						b.visible = false;
					}
				}
			}

		}
	}

}
