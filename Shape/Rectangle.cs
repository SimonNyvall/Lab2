using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShapeNameSpace;

public class Rectangle : Shape2D
{
    private float width;
    private float height;
    private Vector3 center;

    private float area;
    private float circumference;

    public bool IsSquare { get; private set; } = false;

    public Rectangle(Vector2 center, Vector2 size)
    {
        this.center = new Vector3(center.X, center.Y, 0.0f);
        width = size.X;
        height = size.Y;

        area = width * height;
        circumference = width * 2 + height * 2;

        if (size.X == size.Y)
            IsSquare = true;
    }

    public Rectangle(Vector2 center, float width)
    {
        this.center = new Vector3(center.X, center.Y, 0.0f);
        this.width = width;
        height = width;

        area = width * height;
        circumference = width * 2 + height * 2;

        IsSquare = true;
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
        return (IsSquare ? "Square \t " : "Rectangle") + $" @({center.X}; {center.Y}):\t\t w = {width}; h = {height}";       
    }
}
