using GeometricAlgorithm.Common;
using System;

namespace GeometricAlgorithm.Section
{
    public class Section : Shape
    {
        public Section(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

		public Section(Point firstPoint, Point secondPoint)
		{
			x1 = firstPoint.X;
			y1 = firstPoint.Y;
			x2 = secondPoint.X;
			y2 = secondPoint.Y;
		}

		public static bool IsIntersects(Section firstSec, Section secondSec)
		{
			int detP = Determinant(secondSec.x1, secondSec.y1, secondSec.x2, secondSec.y2, firstSec.x1, firstSec.y1);
			int detQ = Determinant(secondSec.x1, secondSec.y1, secondSec.x2, secondSec.y2, firstSec.x2, firstSec.y2);
			int detR = Determinant(firstSec.x1, firstSec.y1, firstSec.x2, firstSec.y2, secondSec.x1, secondSec.y1);
			int detS = Determinant(firstSec.x1, firstSec.y1, firstSec.x2, firstSec.y2, secondSec.x2, secondSec.y2);
			if (detP * detQ > 0 || detR * detS > 0)
			{
				return false;
			}
			else if (detP * detQ < 0 || detR * detS < 0)
			{
				return true;
			}
			else
			{
				if ((Math.Max(firstSec.x1, firstSec.x2) >= Math.Min(secondSec.x1, secondSec.x2)) &&
						(Math.Max(secondSec.x1, secondSec.x2) >= Math.Min(firstSec.x1, firstSec.x2)) &&
						(Math.Max(firstSec.y1, firstSec.y2) >= Math.Min(secondSec.y1, secondSec.y2)) &&
						(Math.Max(secondSec.y1, secondSec.y2) >= Math.Min(firstSec.y1, firstSec.y2)))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public static int Determinant(int x1, int y1, int x2, int y2, int x3, int y3) => x1 * y2 + y1 * x3 + x2 * y3 - x3 * y2 - y3 * x1 - x2 * y1;
		public static int Determinant(Point first, Point second, Point third) => first.X * second.Y + first.Y * third.X + second.X * third.Y - third.X * second.Y - third.Y * first.X - second.X * first.Y;

		public static bool IsParallels(Section firstSec, Section secondSec)
		{
			Vector firstVec = new Vector();
			firstVec.ToVector(firstSec);
			Vector secondVec = new Vector();
			secondVec.ToVector(secondSec);
			if (firstVec.IsParallels(secondVec))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
