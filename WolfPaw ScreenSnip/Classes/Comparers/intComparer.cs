using System.Collections.Generic;

namespace SharpSnip
{
    public class intComparer : IComparer<c_ImageHolder>
	{
		public int Compare(c_ImageHolder a, c_ImageHolder b)
		{
			return (a.LayerIndex > b.LayerIndex ? 1 : -1);
		}
	}
}
