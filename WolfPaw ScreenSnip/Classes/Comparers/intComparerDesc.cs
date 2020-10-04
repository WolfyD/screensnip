using System.Collections.Generic;

namespace SharpSnip
{
    public class intComparerDesc : IComparer<c_ImageHolder>
	{
		public int Compare(c_ImageHolder a, c_ImageHolder b)
		{
			return (a.LayerIndex < b.LayerIndex ? 1 : -1);
		}
	}

}
