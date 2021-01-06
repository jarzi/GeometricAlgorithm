namespace GeometricAlgorithm.Common
{
	public class Point
	{

		public int X { get; set; }
		public int Y { get; set; }

		public Point()
		{
		}

		public Point(Point point)
		{
			X = point.X;
			Y = point.Y;
		}

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public static int MaxX(Point firstPoint, Point secondPoint)
		{
			return firstPoint.X > secondPoint.X ? firstPoint.X : secondPoint.X;
		}

		public static int MaxY(Point firstPoint, Point secondPoint)
		{
			return firstPoint.Y > secondPoint.Y ? firstPoint.Y : secondPoint.Y;
		}

		public static int MinX(Point firstPoint, Point secondPoint)
		{
			return firstPoint.X < secondPoint.X ? firstPoint.X : secondPoint.X;
		}

		public static int MinY(Point firstPoint, Point secondPoint)
		{
			return firstPoint.Y < secondPoint.Y ? firstPoint.Y : secondPoint.Y;
		}

		public void SetTo(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}
