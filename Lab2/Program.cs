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
        float averageArea = areaSum / shapes.Length;

        float circumferanceSum = GetCircumferenceSum(shapes);
        float biggestArea3D = GetBiggest3DArea(shapes);

        var shapeOccurrance = GetMostOccurrantShape(shapes);

        PrintOutput(averageArea, circumferanceSum, biggestArea3D);
        PrintOutput(shapeOccurrance);
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
    static (string, int) GetMostOccurrantShape(Shape.Shape[] shapes)
    {
        var shapeOccurrance = new (string shape, int occurrance)[5];

        shapeOccurrance[0] = ("Circle", shapes.Count(c => c is Circle));
        shapeOccurrance[1] = ("Cuboid", shapes.Count(c => c is Cuboid));
        shapeOccurrance[2] = ("Rectangle", shapes.Count(c => c is Rectangle));
        shapeOccurrance[3] = ("Sphere", shapes.Count(c => c is Sphere));
        shapeOccurrance[4] = ("Triangle", shapes.Count(c => c is Triangle));

        (string, int) returnValue = ("defult", 0);

        int maxOccurrance = shapeOccurrance.Max(occ => occ.occurrance);

        foreach (var item in shapeOccurrance)
        {
            if (maxOccurrance == item.occurrance)
                returnValue = item;
        }
        return returnValue;
    }
    static void PrintOutput(float averageArea, float cercumferenceSum, float biggestArea3D)
    {
        Console.WriteLine($"Avrage area: {averageArea}");
        Console.WriteLine($"Sum of circumferance: {cercumferenceSum}");
        Console.WriteLine($"Biggest 3D Area: {biggestArea3D}");
    }
    static void PrintOutput((string shape, int occurrance) shapeOccorrance)
    {
        Console.WriteLine($"Most occurrant shape was {shapeOccorrance.shape}, it occorred {shapeOccorrance.occurrance} times.");
    }
}