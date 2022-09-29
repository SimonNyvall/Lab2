using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public class Rectangle : Shape2D
    {
        private float width;
        private float height;
        private Vector3 center;

        public bool IsSquare { get; private set; } = false;

        public Rectangle(Vector2 center, Vector2 size)
        {
            this.center = new Vector3(center.X, center.Y, 0.0f);
            width = size.X;
            height = size.Y;

            if (size.X == size.Y)
                IsSquare = true;
        }

        public Rectangle(Vector2 center, float width)
        {
            this.center = new Vector3(center.X, center.Y, 0.0f);
            this.width = width;
            height = width;
            IsSquare = true;
        }

        public override float Area
        {
            get { return width * height; }
        }

        public override Vector3 Center
        {
            get { return new Vector3(width / 2, height / 2, 0.0f); }
        }

        public override float Circumference
        {
            get { return width * 2 + height * 2; }
        }

        public override string ToString()
        {
            return $"rectangle @({center.X}, {center.Y}): w = {width}, h = {height}";
        }
    }
}
