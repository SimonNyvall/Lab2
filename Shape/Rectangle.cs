using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShapeModel;

public class Rectangle : Shape2D
{
    private float _width;
    private float _height;
    private Vector3 _center;

    private float _area;
    private float _circumference;

    public bool IsSquare { get; private set; } = false;

    public Rectangle(Vector2 center, Vector2 size)
    {
        _center = new Vector3(center.X, center.Y, 0.0f);
        _width = size.X;
        _height = size.Y;

        _area = _width * _height;
        _circumference = _width * 2 + _height * 2;

        if (size.X == size.Y)
            IsSquare = true;
    }

    public Rectangle(Vector2 center, float width): this(center, Vector2.Zero)
    {
        _center = new Vector3(center.X, center.Y, 0.0f);
        _width = width;
        _height = width;
    }

    public override float Area => _area;

    public override Vector3 Center => new Vector3(_center.X, _center.Y, 0.0f);

    public override float Circumference => _circumference;
   
    public override string ToString()
    {
        return (IsSquare ? $"{"Square", -10}" : $"{"Rectangle", -10}") + $" @({_center.X:f2}; {_center.Y:f2}): {"", 10} w = {_width:f2}; h = {_height:f2}"; 
       
    }
}
