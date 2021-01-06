using System;

namespace GeometricAlgorithm.Rectangle
{
    class Rectangle : Shape
    {
        public Rectangle(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
        public static Rectangle CommonPart(Rectangle firstRect, Rectangle secondRect)
        {
            int x1 = Math.Max(firstRect.x1, secondRect.x1);
            int y1 = Math.Min(firstRect.y1, secondRect.y1);
            int x2 = Math.Min(firstRect.x2, secondRect.x2);
            int y2 = Math.Max(firstRect.y2, secondRect.y2);
            if ((x1 > x2) || (y1 < y2))
            {
                throw new InvalidOperationException();
            }
            Rectangle resultRect = new Rectangle(x1, y1, x2, y2);
            return resultRect;
        }
        public static Rectangle SmallestRectContains(Rectangle firstRect, Rectangle secondRect)
        {
            int x1 = Math.Min(firstRect.x1, secondRect.x1);
            int y1 = Math.Max(firstRect.y1, secondRect.y1);
            int x2 = Math.Max(firstRect.x2, secondRect.x2);
            int y2 = Math.Min(firstRect.y2, secondRect.y2);
            Rectangle resultRect = new Rectangle(x1, y1, x2, y2);
            return resultRect;
        }
    }
}
