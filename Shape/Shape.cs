using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace ShapeNameSpace;

public abstract class Shape
{
    public abstract Vector3 Center { get; }
    public abstract float Area { get; }

    private static float maxVlaue = 10.0f;
    private static int decimalPoints = 1;

    public static Shape GenerateShape()
    {
        Random rnd = new Random();

        float random_x = MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints);
        float random_y = MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints);        
        float random_z = MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints);

        float random_width = MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints);
        float random_radius = MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints);

        Shape obj = rnd.Next(0, 7) switch
        {
            0 => new Circle(new Vector2(random_x, random_y), random_radius),
            1 => new Cuboid(new Vector3(random_x, random_y, random_z), random_width),
            2 => new Cuboid(new Vector3(random_x, random_y, random_z), new Vector3(random_x, random_y, random_z)),
            3 => new Rectangle(new Vector2(random_x, random_y), random_width),
            4 => new Rectangle(new Vector2(random_x, random_y), new Vector2(random_x, random_y)),
            5 => new Sphere(new Vector3(random_x, random_y, random_z), random_radius),
            6 => new Triangle(GetRandomVector2(), GetRandomVector2(), GetRandomVector2())
        };
        return obj;
    }
    public static Shape GenerateShape(Vector3 center3D)
    {
        Vector2 center2D = new Vector2(center3D.X, center3D.Y);

        Random rnd = new Random();        

        float random_x = MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints);
        float random_y = MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints);
        float random_z = MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints);

        float random_width = MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints);
        float random_radius = MathF.Round(rnd.NextSingle() * maxVlaue, decimalPoints);

        Shape obj = rnd.Next(0, 7) switch
        {
            0 => new Circle(center2D, random_radius),
            1 => new Cuboid(center3D, random_width),
            2 => new Cuboid(center3D, new Vector3(random_x, random_y, random_z)),
            3 => new Rectangle(center2D, random_width),
            4 => new Rectangle(center2D, new Vector2(random_x, random_y)),
            5 => new Sphere(center3D, random_radius),
            6 => new Triangle(GetRandomVector2(), GetRandomVector2(), center3D)
        };
        return obj;
    }
    private static Vector2 GetRandomVector2()
    {
        Random rnd = new Random();
        return new Vector2(MathF.Round(rnd.NextSingle() * 10.0f, 1), MathF.Round(rnd.NextSingle() * 10.0f, 1));
    }
}  
