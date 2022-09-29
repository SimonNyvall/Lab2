﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public class Sphere : Shape3D
    {
        private Vector3 center;
        private float radius;

        public Sphere(Vector3 center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public override float Area
        {
            get { return 4 * MathF.PI * MathF.Pow(radius, 2); }
        }

        public override float Volume
        {
            get { return (4 * MathF.PI * MathF.Pow(radius, 3)) / 3; }
        }

        public override Vector3 Center
        {
            get { return center; }
        }

        public override string ToString()
        {
            return $"sphere @({center.X}, {center.Y}, {center.Z}): r = {radius}";
        }
    }
}