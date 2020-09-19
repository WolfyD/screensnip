using System.Windows.Forms;

namespace WolfPaw_ScreenSnip
{
    public class myPanel : Panel
	{

		public myPanel()
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		}
		
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
				return cp;
			}
		}
	}

}
