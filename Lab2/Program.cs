using ShapeNameSpace;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata;

namespace Lab2;

internal class Program
{
    static void Main(string[] args)
    {      
        Shape[] shapes = new Shape[20];        

        for (int i = 0; i < shapes.Length; i++)
        {
            shapes[i] = Shape.GenerateShape();
        }

        float areaSum = GetAreaSum(shapes);
        float averageArea = areaSum / shapes.Length;

        float triangleCircumferenceSum = GetTriangleCircumferenceSum(shapes);
        float biggestVolume3D = GetBiggest3DVolume(shapes);

        var shapeOccurrence = GetMostOccurrentShape(shapes);

        PrintArray(shapes);
        PrintOutput(averageArea, triangleCircumferenceSum, biggestVolume3D);
        PrintOutput(shapeOccurrence);
    }
    static float GetAreaSum(Shape[] shapes)
    {
        return shapes.Sum(s => s.Area);
    }
    static float GetTriangleCircumferenceSum(Shape[] shapes)
    {
        return shapes.OfType<Triangle>().Sum(s => s.Circumference);
    }
    static float GetBiggest3DVolume(Shape[] shapes)
    {               
        return shapes.OfType<Shape3D>().Max(a => a.Volume);
    }
    static KeyValuePair<string, int> GetMostOccurrentShape(Shape[] shapes)
    {
        var shapeOccurrence = new Dictionary<string, int>();

        shapeOccurrence.Add("Triangle", shapes.Count(t => t is Triangle));
        shapeOccurrence.Add("Circle", shapes.Count(t => t is Circle));
        shapeOccurrence.Add("Sphere", shapes.Count(t => t is Sphere));
        shapeOccurrence.Add("Square", shapes.OfType<Rectangle>().Count(t => t.IsSquare is true));
        shapeOccurrence.Add("Rectangle", shapes.OfType<Rectangle>().Count(t => t.IsSquare is false));
        shapeOccurrence.Add("Cube", shapes.OfType<Cuboid>().Count(t => t.IsCube is true));
        shapeOccurrence.Add("Cuboid", shapes.OfType<Cuboid>().Count(t => t.IsCube is false));        

        int highestValue = shapeOccurrence.Max(occ => occ.Value);
        for (int i = 0; i < shapeOccurrence.Count; i++)
        {
            if (shapeOccurrence.ElementAt(i).Value.Equals(highestValue))
            {
                return shapeOccurrence.ElementAt(i);
            }
        }

        return new KeyValuePair<string, int>("No Shape Found", 0);
    }
    static void PrintArray(Shape[] shapes)
    {
        foreach (var shape in shapes)
        {
            Console.WriteLine(shape);
        }
    }
    static void PrintOutput(float averageArea, float triangleCercumferenceSum, float biggestVolume3D)
    {
        Console.WriteLine($"\nAvrage area: {averageArea} units");
        Console.WriteLine($"Sum of triangles circumferance: {triangleCercumferenceSum} units");
        Console.WriteLine($"Biggest 3D Shapes volume: {biggestVolume3D} units");
    }
    static void PrintOutput(KeyValuePair<string, int> shapeOccorrance)
    {
        Console.WriteLine($"Most occurrant shape was {shapeOccorrance.Key}, it occorred {shapeOccorrance.Value} times.");
    }
}