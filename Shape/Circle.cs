using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShapeModel;

public class Circle : Shape2D
{
    private Vector2 _center;
    private float _radius;

    private float _area;
    private float _circumference;

    public Circle(Vector2 center, float radius)
    {
        _center = new Vector2(center.X, center.Y);
        _radius = radius;

        _area = MathF.PI * MathF.Pow(radius, 2);
        _circumference = radius * MathF.PI * 2;
    }

    public override float Area => _area;
  
    public override Vector3 Center
    {
        get => new Vector3(_center.X, _center.Y, 0.0f); 
    }
    public override float Circumference
    {
        get => _circumference;
    }
    public override string ToString()
    {
        return $"{"Circle", -10} @({_center.X:f2}; {_center.Y:2}): {"",13} r = {_radius:f2}";
    }
  
}
