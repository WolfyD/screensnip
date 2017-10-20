using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfPaw_ScreenSnip
{
	public class c_PointStorage
	{
		List<c_Point> pnts = new List<c_Point>();
		
		public List<c_Point> cPoints()
		{
			return pnts;
		}

		public List<Point> Points()
		{
			List<Point> pp = new List<Point>();
			foreach(c_Point cp in cPoints())
			{
				pp.Add(cp.p);
			}

			return pp;
		}

		public void add(c_Point p)
		{
			pnts.Add(p);
		}

		public void insert(c_Point p, int i)
		{
			pnts.Insert(i, p);
		}

		public void replaceBetween(c_Point p, int start, int end)
		{
			if(end - start > 0)
			{
				for(int i = 0; i < end-start; i++)
				{
					pnts.RemoveAt(start + i);
				}

				pnts.Insert(start + 1, p);
			}
		}

		public void removePoint(c_Point p)
		{
			pnts.Remove(p);
		}

		public void removePoints(c_Point[] ps)
		{
			foreach(c_Point p in ps) { pnts.Remove(p); }
		}

		public void removePoints(int start, int length)
		{
			pnts.RemoveRange(start, length);
		}

		public void movePoint(c_Point p, Point p2)
		{
			p.p = p2;
		}

		public int getIndex(c_Point p)
		{
			return pnts.IndexOf(p);
		}

		public c_Point getPointBefore(c_Point p)
		{
			if (getIndex(p) > 0)
			{
				return pnts[getIndex(p) - 1];
			}
			else
			{
				return null;
			}
		}

		public c_Point getPointAfter(c_Point p)
		{
			if (getIndex(p) < pnts.Count)
			{
				return pnts[getIndex(p) + 1];
			}
			else
			{
				return null;
			}
		}

		public int getPointDistance(c_Point p1, c_Point p2)
		{
			return distance(p1.p, p2.p);
		}

		public int distance(Point p1, Point p2)
		{
			int ret = 0;

			int x = (int)Math.Pow((p2.X - p1.X), 2.0d);
			int y = (int)Math.Pow((p2.Y - p1.Y), 2.0d);

			ret = (int)Math.Sqrt((x + y));

			return ret;
		}

		public void movePointsInRelation(Point start, Point end, c_Point[] pointsToMove)
		{
			foreach (c_Point p in pointsToMove)
			{
				int top = start.Y - p.Y;
				int left = start.X - p.X;
				p.setPoint(new Point(end.X - left, end.Y - top));
			}
		}

	}

	
	public class c_Point
	{
		private Point P;
		public Point p { get { return P; } set { P = value; setPoint(value); } }
		private int x;
		private int y;
		public int X { get { return x; } }
		public int Y { get { return y; } }

		public void setPoint(Point _p)
		{
			x = _p.X;
			y = _p.Y;
		}
	}
}
