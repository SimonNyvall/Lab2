using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shape;

public class Circle : Shape2D
{
    private Vector2 center;
    private float radius;

    public Circle(Vector2 center, float radius)
    {
        this.center = new Vector2(center.X, center.Y);
        this.radius = radius;
    }

    public override float Area
    {
        get => MathF.PI * MathF.Pow(radius, 2); 
    }
    public override Vector3 Center
    {
        get => new Vector3(center.X, center.Y, 0.0f); 
    }
    public override float Circumference
    {
        get => radius * MathF.PI * 2;
    }
    public override string ToString()
    {
        return $"circle @({center.X}, {center.Y}):r = {radius}";
    }
  
}
