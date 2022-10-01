using Shape;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata;

namespace Lab2;

internal class Program
{
    static void Main(string[] args)
    {
        Shape.Shape[] shapes = new Shape.Shape[20];        

        for (int i = 0; i < shapes.Length; i++)
        {
            shapes[i] = Shape.Shape.GenerateShape();
        }
        
        float areaSum = GetAreaSum(shapes);
        float genomsnittArea = areaSum / shapes.Length;

        float cercumferenceSum = GetCircumferenceSum(shapes);
        float biggestArea3D = GetBiggest3DArea(shapes);

        var shapeOccorrance = GetMostOccorrantShape(shapes);

        PrintOutput(genomsnittArea, cercumferenceSum, biggestArea3D);
        PrintOutput(shapeOccorrance);
    }
    static float GetAreaSum(Shape.Shape[] shapes)
    {
        return shapes.Sum(s => s.Area);
    }
    static float GetCircumferenceSum(Shape.Shape[] shapes)
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
    static float GetBiggest3DArea(Shape.Shape[] shapes)
    {       
        return shapes.Where(t => t is Shape3D).Max(a => a.Area);
    }
    static (string, int) GetMostOccorrantShape(Shape.Shape[] shapes)
    {
        var shapeOccorrance = new (string shape, int occurance)[5];

        shapeOccorrance[0] = ("Circle", shapes.Count(c => c is Circle));
        shapeOccorrance[1] = ("Cuboid", shapes.Count(c => c is Cuboid));
        shapeOccorrance[2] = ("Rectangle", shapes.Count(c => c is Rectangle));
        shapeOccorrance[3] = ("Sphere", shapes.Count(c => c is Sphere));
        shapeOccorrance[4] = ("Triangle", shapes.Count(c => c is Triangle));

        (string, int) returnValue = ("defult", 0);

        int maxOccurrance = shapeOccorrance.Max(o => o.occurance);

        foreach (var item in shapeOccorrance)
        {
            if (maxOccurrance == item.occurance)
                returnValue = item;
        }
        return returnValue;
    }
    static void PrintOutput(float genomsnittArea, float cercumferenceSum, float biggestArea3D)
    {
        Console.WriteLine($"Avrage area: {genomsnittArea}");
        Console.WriteLine($"Sum of circumferance: {cercumferenceSum}");
        Console.WriteLine($"Biggest 3D Area: {biggestArea3D}");
    }
    static void PrintOutput((string shape, int occurrance) shapeOccorrance)
    {
        Console.WriteLine($"Most occurrant shape was {shapeOccorrance.shape}, it occorred {shapeOccorrance.occurrance} times.");
    }
}