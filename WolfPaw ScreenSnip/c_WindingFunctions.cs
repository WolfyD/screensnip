using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfPaw_ScreenSnip
{
	public static class c_WindingFunctions
	{
		/// <summary>
		///  isLeft(): test if a point is Left|On|Right of an infinite 2D line.
		///  Input:  three points P0, P1, and P2
		///
		///  Return:	Greater than 0 for P2 left of the line through P0 to P1
		///				0 for P2 on the line
		///				Less than 0 for P2 right of the line
		/// </summary>
		/// <param name="P0">Point to test</param>
		/// <param name="P1">First point on line</param>
		/// <param name="P2">Second point on line</param>
		/// <returns></returns>
		public static int isLeft(Point P0, Point P1, Point P2)
		{
			return ((P1.X - P0.X) * (P2.Y - P0.Y)
				   - (P2.X - P0.X) * (P1.Y - P0.Y));
		}

		/// <summary>
		///		orientation2D_Triangle(): test the orientation of a 2D triangle
		///		Input:  three vertex points V0, V1, V2
		///		Return:	Greater than 0 for counterclockwise
		///				0 for none (degenerate)
		///				Less than 0 for clockwise
		/// </summary>
		/// <param name="V0">Point to test</param>
		/// <param name="V1">Point A</param>
		/// <param name="V2">Point B</param>
		/// <returns></returns>
		public static int orientation2D_Triangle(Point V0, Point V1, Point V2)
		{
			return isLeft(V0, V1, V2);
		}

		/// <summary>
		///		area2D_Triangle(): compute the area of a 2D triangle
		///		Input:  three vertex points V0, V1, V2
		///		Return: the (float) area of triangle T
		/// </summary>
		/// <param name="V0">Point A</param>
		/// <param name="V1">Point B</param>
		/// <param name="V2">Point C</param>
		/// <returns></returns>
		public static float area2D_Triangle(Point V0, Point V1, Point V2)
		{
			return ((isLeft(V0, V1, V2) * 1.0f) / 2.0f);
		}

		/// <summary>
		///		<para>orientation2D_Polygon(): test the orientation of a simple 2D polygon</para>
		///		<para>Input:</para>  
		///		<para>	int n = the number of vertices in the polygon</para>
		///		<para>	Point[] V = an array of n+1 vertex points with V[n]=V[0]</para>
		///		<para>	Return:</para>
		///		<para>	Greater than 0 for counterclockwise</para>
		///		<para>	0 for none (degenerate)</para>
		///		<para>	Less than 0 for clockwise</para>
		///		<para>Note: this algorithm is faster than computing the signed area.</para>
		/// </summary>
		/// <param name="n">number of vertices in the polygon</param>
		/// <param name="V">array of n+1 vertex points with V[n]=V[0]</param>
		/// <returns>&gt;0&lt;</returns>
		public static int orientation2D_Polygon(int n, Point[] V)
		{
			// first find rightmost lowest vertex of the polygon
			int rmin = 0;
			int xmin = V[0].X;
			int ymin = V[0].Y;

			for (int i = 1; i < n; i++)
			{
				if (V[i].Y > ymin)
					continue;
				if (V[i].Y == ymin)
				{   // just as low
					if (V[i].X < xmin)  // and to left
						continue;
				}
				rmin = i;      // a new rightmost lowest vertex
				xmin = V[i].X;
				ymin = V[i].Y;
			}

			// test orientation at the rmin vertex
			// ccw <=> the edge leaving V[rmin] is left of the entering edge
			if (rmin == 0)
				return isLeft(V[n - 1], V[0], V[1]);
			else
				return isLeft(V[rmin - 1], V[rmin], V[rmin + 1]);
		}

		/// <summary>
		///		<para>area2D_Polygon(): compute the area of a 2D polygon</para>
		///		<para>Input:	</para>
		///		<para>	int n = the number of vertices in the polygon</para>
		///		<para>	Point[] V = an array of n+1 vertex points with V[n]=V[0]</para>
		///		<para>Return: the (float) area of the polygon</para>
		/// </summary>
		/// <param name="n">number of vertices in the polygon</param>
		/// <param name="V">array of n+1 vertex points with V[n]=V[0]</param>
		/// <returns>the (float) area of the polygon</returns>
		public static float area2D_Polygon(int n, Point[] V)
		{
			float area = 0;
			int i, j, k;   // indices

			if (n < 3) return 0;  // a degenerate polygon

			for (i = 1, j = 2, k = 0; i < n; i++, j++, k++)
			{
				area += V[i].X * (V[j].Y - V[k].Y);
			}
			area += V[n].X * (V[1].Y - V[n - 1].Y);  // wrap-around term
			return area / 2.0f;
		}

		/// <summary>
		///		<para>wn_PnPoly(): winding number test for a point in a polygon</para>
		///	    <para>Input:   </para>
		///		<para>	P = a point,</para>
		///		<para>	V[] = vertex points of a polygon V[n+1] with V[n]=V[0]</para>
		///		<para>Return:  </para>
		///		<para>	wn = the winding number (=0 only when P is outside)</para>
		/// </summary>
		/// <param name="P">Point to test</param>
		/// <param name="V">Points of a polygon V[n+1] with V[n]=V[0]</param>
		/// <param name="n">Number of points in polygon V</param>
		/// <returns>Winding number (Greater than 0 if inside, 0 if outside)</returns>
		public static int wn_PnPoly(Point P, Point[] V, int n)
		{
			int wn = 0;											// the  winding number counter

			// loop through all edges of the polygon
			for (int i = 0; i < n; i++)							// edge from V[i] to V[i + 1]
			{  
				if (V[i].Y <= P.Y)								// start y <= P.y
				{          
					if (V[i + 1].Y > P.Y)						// an upward crossing
					{     
						if (isLeft(V[i], V[i + 1], P) > 0)		// P left of  edge
						{  
							++wn;								// have  a valid up intersect
						}
					}
				}
				else											// start y > P.y (no test needed)
				{
					if (V[i + 1].Y <= P.Y)						// a downward crossing
					{
						if (isLeft(V[i], V[i + 1], P) < 0)		// P right of  edge
						{
							--wn;								// have  a valid down intersect
						}
					}
				}
			}
			return wn;
		}




	}
}
