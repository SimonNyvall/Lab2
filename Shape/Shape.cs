using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace ShapeModel;

public abstract class Shape
{
    public abstract Vector3 Center { get; }
    public abstract float Area { get; }

    private static float maxVlaue = 10.0f;
    private static float offset = 0.0f;

    private static Random random = new Random();

    public static Shape GenerateShape()
    {
        Vector3 random_center = GetRandomVector3();
        return GenerateShape(random_center);
    }
    public static Shape GenerateShape(Vector3 center3D)
    {
        Vector2 center2D = new Vector2(center3D.X, center3D.Y);       

        float random_width = random.NextSingle() * maxVlaue + offset;
        float random_radius = random.NextSingle() * maxVlaue + offset;

        Shape obj = random.Next(0, 7) switch
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
        return new Vector2(random.NextSingle() * maxVlaue + offset, random.NextSingle() * maxVlaue + offset);
    }
    private static Vector3 GetRandomVector3()
    {
        return new Vector3(random.NextSingle() * maxVlaue + offset, random.NextSingle() * maxVlaue + offset, random.NextSingle() * maxVlaue + offset);
    }
}  
