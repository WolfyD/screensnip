using System.Windows.Forms;

namespace SharpSnip
{
    #region OTHER CLASSES / COMPARERS

    public class uc_myToolstrip : ToolStrip
	{
		public uc_myToolstrip()
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

#endregion

}
