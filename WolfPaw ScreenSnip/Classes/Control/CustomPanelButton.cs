using System.Drawing;

namespace WolfPaw_ScreenSnip
{
    public class CustomPanelButton
	{
		public enum Anchors
		{ left, right }

		public enum HiddenVal
		{
			FullWidth,
			FullWidthOnly,
			W175,
			W135,
			W065
		}

		public Bitmap Image1 { get; set; }
		public Bitmap Image2 { get; set; }
		public int Pos { get; set; }
        public int originalPos = 0;
		public Anchors Anchor { get; set; }
		public int BorderWidth { get; set; }
		public int Value { get; set; }
		public HiddenVal HiddenAtVal { get; set; }
		public string Tooltiptext { get; set; }
		public bool visible = true;

		public int Size { get; set; } = 18;
		public int PadTop { get; set; } = 2;
		public int PadRight { get; set; } = 0;

		/// <summary>
		/// Bitmap image1  |  
		/// Bitmap image2  |  
		/// int pos  |  
		/// anchors anchor  |  
		/// int borderWidth  |  
		/// int value  |  
		/// hiddenVal hiddenAtVal  |  
		/// string tooltiptext
		/// </summary>
		public CustomPanelButton()
		{
			originalPos = Pos;
		}
	}

}
