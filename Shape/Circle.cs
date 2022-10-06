using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShapeModel;

public class Circle : Shape2D
{
    private Vector2 center;
    private float radius;

    private float area;
    private float circumference;

    public Circle(Vector2 center, float radius)
    {
        this.center = new Vector2(center.X, center.Y);
        this.radius = radius;

        area = MathF.PI * MathF.Pow(radius, 2);
        circumference = radius * MathF.PI * 2;
    }

    public override float Area
    {
        get => area;
    }
    public override Vector3 Center
    {
        get => new Vector3(center.X, center.Y, 0.0f); 
    }
    public override float Circumference
    {
        get => circumference;
    }
    public override string ToString()
    {
        return $"Circle \t  @({center.X}; {center.Y}): \t\t r = {radius}";
    }
  
}
