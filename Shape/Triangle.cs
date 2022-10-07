using System.Numerics;
using System.Runtime.InteropServices;

namespace ShapeModel;

public class Triangle : Shape2D
{
    private Vector3 _center;    
    private (float A, float B, float C) _side;
    private (Vector2 p1, Vector2 p2, Vector2 p3) _cornerPoints;

    private float _area;
    private float _circumference;

    public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
    {
        _cornerPoints.p1 = p1;
        _cornerPoints.p2 = p2;
        _cornerPoints.p3 = p3;


        GetTriangleSides();
        _circumference = _side.A + _side.B + _side.C;

        _area = GetTriangleArea();

        _center = new Vector3((p1.X + p2.X + p3.X) / 3, (p1.Y + p2.Y + p3.Y) / 3, 0.0f);
    }

    public Triangle(Vector2 p1, Vector2 p2, Vector3 center): this(p1, p2, Vector2.Zero)
    {             
        _cornerPoints.p3 = new Vector2(3 * center.X - p1.X - p2.X, 3 * center.Y - p1.Y - p2.Y);
        _center = new Vector3(center.X, center.Y, 0.0f);
    }    

    private void GetTriangleSides()
    {
        _side.A = Vector2.Distance(_cornerPoints.p3, _cornerPoints.p2);
        _side.B = Vector2.Distance(_cornerPoints.p1, _cornerPoints.p3);
        _side.C = Vector2.Distance(_cornerPoints.p1, _cornerPoints.p2);
    }
  
    private float GetTriangleArea()
    {
        float s = (_side.A + _side.B + _side.C) / 2;
        return MathF.Sqrt(s * (s - _side.A) * (s - _side.B) * (s - _side.C));
    }

    public override float Area
    {
        get => _area;
    }

    public override Vector3 Center
    {
        get => _center;
    }

    public override float Circumference
    {
        get => _circumference;
    }

    public override string ToString()
    {
        return $"{"Triangle",-10} @({_center.X:f2}; {_center.Y:f2}): p1({_cornerPoints.p1:f2}); p2({_cornerPoints.p2:f2}); p3({_cornerPoints.p3:f2})";
    }
}
