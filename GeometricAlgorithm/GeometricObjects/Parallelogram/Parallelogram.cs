using GeometricAlgorithm.Common;
using System;
using System.Collections.Generic;

namespace GeometricAlgorithm.GeometricObjects.Parallelogram
{
    class Parallelogram
    {
        public Point LeftTop { get; set; }
        public Point RightTop { get; set; }
        public Point LeftBottom { get; set; }
        public Point RightBottom { get; set; }
        public Section.Section Top { get; set; }
        public Section.Section Right { get; set; }
        public Section.Section Bottom { get; set; }
        public Section.Section Left { get; set; }
        public List<Section.Section> Sections { get; set; }

        public Parallelogram(Point leftTop, Point rightTop, Point leftBottom, Point rightBottom)
        {
            try
            {
                LeftTop = new Point(leftTop);
                RightTop = new Point(rightTop);
                LeftBottom = new Point(leftBottom);
                RightBottom = new Point(rightBottom);
                Top = new Section.Section(leftTop, rightTop);
                Right = new Section.Section(rightTop, rightBottom);
                Bottom = new Section.Section(leftBottom, rightBottom);
                Left = new Section.Section(leftTop, leftBottom);
                if (IsPossible())
                {
                    Sections = new List<Section.Section>
                    {
                        Top,
                        Right,
                        Bottom,
                        Left
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private bool IsPossible()
        {
            if (Section.Section.IsParallels(Top, Bottom) && Section.Section.IsParallels(Left, Right))
            {
                return true;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public bool IsContains(Parallelogram parall)
        {
            if (this.IsIntersects(parall))
            {
                return false;
            }
            int detM12 = Section.Section.Determinant(LeftTop, RightTop, parall.LeftTop);
            int detM43 = Section.Section.Determinant(LeftBottom, RightBottom, parall.LeftTop);
            int detM14 = Section.Section.Determinant(LeftTop, LeftBottom, parall.LeftTop);
            int detM23 = Section.Section.Determinant(RightTop, RightBottom, parall.LeftTop);

            if (detM12 * detM43 < 0 && detM14 * detM23 < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasCommonPart(Parallelogram parall)
        {
            if (IsIntersects(parall))
            {
                return false;
            }
            int detM12 = Section.Section.Determinant(this.LeftTop, this.RightTop, parall.LeftTop);
            int detM43 = Section.Section.Determinant(this.LeftBottom, this.RightBottom, parall.LeftTop);
            int detM14 = Section.Section.Determinant(this.LeftTop, this.LeftBottom, parall.LeftTop);
            int detM23 = Section.Section.Determinant(this.RightTop, this.RightBottom, parall.LeftTop);

            int detN12 = Section.Section.Determinant(parall.LeftTop, parall.RightTop, this.LeftTop);
            int detN43 = Section.Section.Determinant(parall.LeftBottom, parall.RightBottom, this.LeftTop);
            int detN14 = Section.Section.Determinant(parall.LeftTop, parall.LeftBottom, this.LeftTop);
            int detN23 = Section.Section.Determinant(parall.RightTop, parall.RightBottom, this.LeftTop);

            if ((detM12 * detM43 < 0 && detM14 * detM23 < 0) || (detN12 * detN43 < 0 && detN14 * detN23 < 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsIntersects(Parallelogram parall)
        {
            foreach (Section.Section i in this.Sections)
            {
                foreach (Section.Section j in parall.Sections)
                {
                    if (Section.Section.IsIntersects(i, j))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
