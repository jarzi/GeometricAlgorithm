namespace GeometricAlgorithm.Common
{
	public class Vector
	{

		public int X { get; set; }
		public int Y { get; set; }

		public Vector()
		{
		}

		public Vector(int x, int y)
		{
			X = x;
			Y = y;
		}

		public void ToVector(Section.Section section)
		{
			X = section.x2 - section.x1;
			Y = section.y2 - section.y1;
		}

		public bool IsParallels(Vector vector)
		{
			int det = X * vector.Y - Y * vector.X;
			if (det == 0)
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
