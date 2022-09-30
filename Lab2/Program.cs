using Shape;
using System.Numerics;

namespace Lab2;

internal class Program
{
    static void Main(string[] args)
    {
        Shape.Shape[] shape = new Shape.Shape[20];

        for (int i = 0; i < shape.Length; i++)
        {
            shape[i] = Shape.Shape.GenerateShape();
        }

        float areaSum = 0;
        float cercumferenceSum = 0;

        for (int i = 0; i < shape.Length; i++)
        {
            areaSum += shape[i].Area;
            
            if (shape[i] is Triangle)
            {
                //cercumferenceSum += shape[i].c
            }
        }

        float genomsnittArea = areaSum / shape.Length;

        Console.WriteLine(genomsnittArea);

       

    }
}