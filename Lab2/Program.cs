using ShapeModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;

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

        float averageArea = GetAverageArea(shapes);         

        float triangleCircumferenceSum = GetTriangleCircumferenceSum(shapes);
        float biggestVolume3D = GetBiggest3DVolume(shapes);

        KeyValuePair<string, int> shapeOccurrence = GetMostOccurrentShape(shapes);

        string[] sortedShapeArray = SortShapeArray(shapes);
        PrintShapeArray(sortedShapeArray);

        PrintShapeInfo(averageArea, triangleCircumferenceSum, biggestVolume3D);
        PrintMostOccurrentShapes(shapeOccurrence);

        Console.ReadLine();
    }
    static float GetAverageArea(Shape[] shapes)
    {
        return shapes.Average(a => a.Area);
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

        Dictionary<string, int> sortedShapeOccurrence = shapeOccurrence
            .OrderByDescending(x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value);

        var sb = new StringBuilder();
        int highestOccurrenceValue = sortedShapeOccurrence.ElementAt(0).Value;

        for (int i = 0; i < sortedShapeOccurrence.Count; i++)
        {
            if (highestOccurrenceValue == sortedShapeOccurrence.ElementAt(i).Value) 
            { 
                sb.Append(sortedShapeOccurrence.ElementAt(i).Key + ", ");
            }
            else
                break;
        }
        return new KeyValuePair<string, int>(sb.ToString(), highestOccurrenceValue);
    }
    static string[] SortShapeArray(Shape[] shapes)
    {
        string[] sortedShapeArray = new string[shapes.Length];

        try
        {
            Func<Shape, string> ShapeToString = (Shape input) => input.ToString() ?? string.Empty;
            sortedShapeArray = Array.ConvertAll(shapes, new Converter<Shape, string>(ShapeToString));
        }
        catch(Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex);
        }

        Array.Sort(sortedShapeArray);

        return sortedShapeArray;
    }
    static void PrintShapeArray(string[] shapes)
    {
        Console.WriteLine("{0, -10} {1, -25} {2}", "Shape", "Center", "Values" + "\n");

        foreach (var shape in shapes)
        {
            Console.WriteLine(shape);
        }
    }
    static void PrintShapeInfo(float averageArea, float triangleCercumferenceSum, float biggestVolume3D)
    {
        Console.WriteLine($"\nAvrage {"area", -30} {averageArea:f2} units^2");
        Console.WriteLine($"Sum of triangles {"circumferance", -20} {triangleCercumferenceSum:f2} units");
        Console.WriteLine($"Biggest 3D Shapes {"volume", -19} {biggestVolume3D:f2} units^3");
    }
    static void PrintMostOccurrentShapes(KeyValuePair<string, int> shapeOccorrance)
    {
        Console.WriteLine($"\nMost occurrant shape was {shapeOccorrance.Key}the occurence was {shapeOccorrance.Value}.");
    }
}