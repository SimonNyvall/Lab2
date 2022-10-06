using System.Numerics;
using System.Runtime.InteropServices;

namespace ShapeNameSpace;

public class Triangle : Shape2D
{
    private Vector3 center;    
    private (float A, float B, float C) side;
    private (Vector2 p1, Vector2 p2, Vector2 p3) cornerPoints;

    private float area;
    private float circumference;

    public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
    {
        cornerPoints.p1 = p1;
        cornerPoints.p2 = p2;
        cornerPoints.p3 = p3;


        GetTriangleSides();
        circumference = side.A + side.B + side.C;

        area = CalculateTriangleArea();

        center = new Vector3(MathF.Round((p1.X + p2.X + p3.X) / 3, 1), MathF.Round((p1.Y + p2.Y + p3.Y) / 3, 1), 0.0f);
    }

    public Triangle(Vector2 p1, Vector2 p2, Vector3 center)
    {
        cornerPoints.p1 = p1;
        cornerPoints.p2 = p2;        
        cornerPoints.p3 = new Vector2(3 * center.X - p1.X - p2.X, 3 * center.Y - p1.Y - p2.Y);

        GetTriangleSides();
        circumference = side.A + side.B + side.C;

        area = CalculateTriangleArea();

        center = new Vector3((p1.X + p2.X + cornerPoints.p3.X) / 3, (p1.Y + p2.Y + cornerPoints.p3.Y) / 3, 0.0f);
    }    

    private void GetTriangleSides()
    {           
        side.A = CalulateDistance(cornerPoints.p3, cornerPoints.p2);
        side.B = CalulateDistance(cornerPoints.p1, cornerPoints.p3);
        side.C = CalulateDistance(cornerPoints.p1, cornerPoints.p2);
    }
    private float CalulateDistance(Vector2 firstPoint, Vector2 secondPoint)
    {        
        return Vector2.Distance(firstPoint, secondPoint);
    }

    private float CalculateTriangleArea()
    {
        float s = (side.A + side.B + side.C) / 2;
        return MathF.Sqrt(s * (s - side.A) * (s - side.B) * (s - side.C));
    }

    public override float Area
    {
        get => area;
    }

    public override Vector3 Center
    {
        get => center;
    }

    public override float Circumference
    {
        get => circumference;
    }

    public override string ToString()
    {
        return $"Triangle  @({center.X}; {center.Y}):\t\t p1({cornerPoints.p1}); p2({cornerPoints.p2}); p3({cornerPoints.p3})";
    }
}
