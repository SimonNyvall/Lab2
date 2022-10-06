using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace ShapeModel;

public abstract class Shape
{
    public abstract Vector3 Center { get; }
    public abstract float Area { get; }

    private static float maxVlaue = 10.0f;
    private static int decimalPoints = 1;

    private static Random rnd = new Random();

    public static Shape GenerateShape()
    {
        float random_width = MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints);
        float random_radius = MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints);

        Shape obj = rnd.Next(0, 7) switch
        {
            0 => new Circle(GetRandomVector2(), random_radius),
            1 => new Cuboid(GetRandomVector3(), random_width),
            2 => new Cuboid(GetRandomVector3(), GetRandomVector3()),
            3 => new Rectangle(GetRandomVector2(), random_width),
            4 => new Rectangle(GetRandomVector2(), GetRandomVector2()),
            5 => new Sphere(GetRandomVector3(), random_radius),
            6 => new Triangle(GetRandomVector2(), GetRandomVector2(), GetRandomVector2())
        };
        return obj;
    }
    public static Shape GenerateShape(Vector3 center3D)
    {
        Vector2 center2D = new Vector2(center3D.X, center3D.Y);       

        float random_width = MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints);
        float random_radius = MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints);

        Shape obj = rnd.Next(0, 7) switch
        {
            0 => new Circle(center2D, random_radius),
            1 => new Cuboid(center3D, random_width),
            2 => new Cuboid(center3D, GetRandomVector3()),
            3 => new Rectangle(center2D, random_width),
            4 => new Rectangle(center2D, GetRandomVector2()),
            5 => new Sphere(center3D, random_radius),
            6 => new Triangle(GetRandomVector2(), GetRandomVector2(), center3D)
        };
        return obj;
    }
    private static Vector2 GetRandomVector2()
    {
        return new Vector2(MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints), MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints));
    }
    private static Vector3 GetRandomVector3()
    {
        return new Vector3(MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints), MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints), MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints));
    }
}  
