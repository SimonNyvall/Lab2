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

        float circumferenceSum = GetCircumferenceSum(shapes);
        float biggestArea3D = GetBiggest3DArea(shapes);

        var shapeOccurrance = GetMostOccurrantShape(shapes);

        PrintArray(shapes);
        PrintOutput(averageArea, circumferenceSum, biggestArea3D);
        PrintOutput(shapeOccurrance);
    }
    static float GetAreaSum(Shape[] shapes)
    {
        return shapes.Sum(s => s.Area);
    }
    static float GetCircumferenceSum(Shape[] shapes)
    {
        float CircumferenceSum = 0;

        foreach (var shape in shapes)
        {
            if (shape is Triangle)
            {
                Triangle tries = (Triangle)shape;
                CircumferenceSum += tries.Circumference;
            }
        }
        return CircumferenceSum;

    }
    static float GetBiggest3DArea(Shape[] shapes)
    {       
        return shapes.Where(t => t is Shape3D).Max(a => a.Area);
    }
    static KeyValuePair<string, int> GetMostOccurrantShape(Shape[] shapes)
    {
        var shapeOccurrence = new Dictionary<string, int>();

        shapeOccurrence.Add("Triangle", shapes.Count(t => t is Triangle));
        shapeOccurrence.Add("Circle", shapes.Count(t => t is Circle));
        shapeOccurrence.Add("Sphere", shapes.Count(t => t is Sphere));
        shapeOccurrence.Add("Squre", shapes.OfType<Rectangle>().Count(c => c.IsSquare is true));
        shapeOccurrence.Add("Rectangle", shapes.OfType<Rectangle>().Count(c => c.IsSquare is false));
        shapeOccurrence.Add("Cube", shapes.OfType<Cuboid>().Count(c => c.IsCube is true));
        shapeOccurrence.Add("Cuboid", shapes.OfType<Cuboid>().Count(c => c.IsCube is false));

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
    static void PrintOutput(float averageArea, float cercumferenceSum, float biggestArea3D)
    {
        Console.WriteLine($"\nAvrage area: {averageArea}");
        Console.WriteLine($"Sum of circumferance: {cercumferenceSum}");
        Console.WriteLine($"Biggest 3D Area: {biggestArea3D}");
    }
    static void PrintOutput(KeyValuePair<string, int> shapeOccorrance)
    {
        Console.WriteLine($"Most occurrant shape was {shapeOccorrance.Key}, it occorred {shapeOccorrance.Value} times.");
    }
}