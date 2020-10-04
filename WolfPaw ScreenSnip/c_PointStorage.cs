using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSnip
{
	public class c_PointStorage
	{
		List<Point> pnts = new List<Point>();
		
		public void setPoints(List<Point> pl)
		{
			pnts = pl;
		}

		public List<Point> Points2(int x, int y)
		{
			List<Point> pp = new List<Point>();
			foreach (Point cp in pnts)
			{
				pp.Add(new Point(cp.X + x, cp.Y + y));
			}

			return pp;
		}

		public List<Point> Points()
		{
			return pnts;
		}

		public void add(Point p)
		{
			pnts.Add(p);
		}

		public void insert(Point p, int i)
		{
			pnts.Insert(i, p);
		}

		public void replaceBetween(Point p, int start, int end)
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

		public void removePoint(Point p)
		{
			pnts.Remove(p);
		}

		public void removePoints(Point[] ps)
		{
			foreach(Point p in ps) { pnts.Remove(p); }
		}

		public void removePoints(int start, int length)
		{
			pnts.RemoveRange(start, length);
		}

		public void movePoint(Point p, Point p2)
		{
			if (pnts.Contains(p))
			{
				pnts[pnts.IndexOf(p)] = p2;
			}
		}

		public int getIndex(Point p)
		{
			return pnts.IndexOf(p);
		}

		public Point? getPointBefore(Point p)
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

		public Point? getPointAfter(Point p)
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

		public int getPointDistance(Point p1, Point p2)
		{
			return distance(p1, p2);
		}

		public int distance(Point p1, Point p2)
		{
			int ret = 0;

			int x = (int)Math.Pow((p2.X - p1.X), 2.0d);
			int y = (int)Math.Pow((p2.Y - p1.Y), 2.0d);

			ret = (int)Math.Sqrt((x + y));

			return ret;
		}

		public List<Point> movePointsInRelation(Point start, Point end, Point[] pointsToMove)
		{
			List<int> indexes = new List<int>();
			foreach (Point p in pointsToMove)
			{
				int top = start.Y - p.Y;
				int left = start.X - p.X;
				Point pp = new Point(end.X - left, end.Y - top);

				int i = pnts.IndexOf(p);
				if(i >= 0 && i <= pnts.Count)
				{
					indexes.Add(i);
					pnts.Remove(p);
					pnts.Insert(i, pp);
				}

			}

			List<Point> pntsret = new List<Point>();

			foreach(int i in indexes)
			{
				pntsret.Add(pnts[i]);
			}

			return pntsret;
		}

	}

	
	
}
