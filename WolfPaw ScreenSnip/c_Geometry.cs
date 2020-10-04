using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpSnip
{
    public static class c_Geometry
    {
        public static Point GetPointFromAngle(Point Origin, int Distance, double Angle)
        {
            Point point = new Point();

            point.X = Origin.X + Distance * (int)Math.Cos(AngleToRadians(Angle));
            point.Y = Origin.Y + Distance * (int)Math.Sin(AngleToRadians(Angle));

            return point;
        }

        private static double AngleToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

    }
}
