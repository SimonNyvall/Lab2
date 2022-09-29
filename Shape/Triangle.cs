using System.Numerics;
using System.Runtime.InteropServices;

namespace Shape
{
    public class Triangle : Shape2D
    {
        private Vector3 center;

        private float sideA;
        private float sideB;
        private float sideC;

        private Vector2 p1;
        private Vector2 p2;
        private Vector2 p3;

        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;

            GetTriangleSides();

            center = new Vector3((p1.X + p2.X + p3.X) / 3, (p1.Y + p2.Y + p3.Y) / 3, 0.0f);
        }

        public override float Area
        {
            get
            {
                // Areasatsen T = (ab sin(C))/2
                // beräkna vinkel C & sidan för a och b.
                // c^2 = a^2 + b^2 - 2 * a * b * cos(C)
                // behöver alla sidor på triandgen

                float CosDegree_C = (MathF.Pow(sideC, 2) - MathF.Pow(sideA, 2) - MathF.Pow(sideB, 2)) / (-2 * sideA * sideB);
                float Degree_C = MathF.Acos(CosDegree_C);
                return (sideA * sideB * MathF.Sin(Degree_C)) / 2;

                // (c^2 - a^2 - b^2)/(-2*a*b) = Cos(C)
                // Cos^-1(C) = C
            }
        }
        private void GetTriangleSides()
        {
            sideA = CalulateDistance(p3, p2);
            sideB = CalulateDistance(p1, p3);
            sideC = CalulateDistance(p1, p2);
        }
        private float CalulateDistance(Vector2 firstPoint, Vector2 secondPoint)
        {
            // d = sqrt( (x2 - x1)^2 + (y2 - y1)^2 )
            return MathF.Sqrt(MathF.Pow(secondPoint.X - firstPoint.X, 2) + MathF.Pow(secondPoint.Y - firstPoint.Y, 2));
        }

        public override Vector3 Center
        {
            get => center;
        }

        public override float Circumference
        {
            get => sideA + sideB + sideC;
        }

        public override string ToString()
        {
            return $"triangle @({center.X}, {center.Y}): p1({p1}), p2({p2}), p3({p3})";
        }
    }
}
