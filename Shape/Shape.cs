using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace ShapeNameSpace;

public abstract class Shape
{
    public abstract Vector3 Center { get; }
    public abstract float Area { get; }

    public static Shape GenerateShape()
    {
        Random rnd = new Random();
        float random_x = MathF.Round(rnd.NextSingle() * 10.0f, 1);
        float random_y = MathF.Round(rnd.NextSingle() * 10.0f, 1);
        float random_x2 = MathF.Round(rnd.NextSingle() * 10.0f, 1);
        float random_y2 = MathF.Round(rnd.NextSingle() * 10.0f, 1);
        float random_x3 = MathF.Round(rnd.NextSingle() * 10.0f, 1);
        float random_y3 = MathF.Round(rnd.NextSingle() * 10.0f, 1);
        float random_z = MathF.Round(rnd.NextSingle() * 10.0f, 1);
        float random_width = MathF.Round(rnd.NextSingle() * 10.0f, 1);
        float random_radius = MathF.Round(rnd.NextSingle() * 10.0f, 1);

        Shape obj = rnd.Next(0, 7) switch
        {
            0 => new Circle(new Vector2(random_x, random_y), random_radius),
            1 => new Cuboid(new Vector3(random_x, random_y, random_z), random_width),
            2 => new Cuboid(new Vector3(random_x, random_y, random_z), new Vector3(random_x, random_y, random_z)),
            3 => new Rectangle(new Vector2(random_x, random_y), random_width),
            4 => new Rectangle(new Vector2(random_x, random_y), new Vector2(random_x, random_y)),
            5 => new Sphere(new Vector3(random_x, random_y, random_z), random_radius),
            6 => new Triangle(new Vector2(random_x, random_y), new Vector2(random_x2, random_y2), new Vector2(random_x3, random_y3))
        };
        return obj;
    }
    public static Shape GenerateShape(Vector3 center3D)
    {
        Vector2 center2D;
        center2D.X = center3D.X;
        center2D.Y = center3D.Y;

        Random rnd = new Random();

        Shape obj = rnd.Next(0, 7) switch
        {
            0 => new Circle(center2D, rnd.Next()),
            1 => new Cuboid(center3D, rnd.Next()),
            2 => new Cuboid(center3D, rnd.Next()),
            3 => new Rectangle(center2D, rnd.Next()),
            4 => new Rectangle(center2D, rnd.Next()),
            5 => new Sphere(center3D, rnd.Next()),
            6 => new Triangle(new Vector2(rnd.Next(), rnd.Next()), new Vector2(rnd.Next(), rnd.Next()), new Vector2(rnd.Next(), rnd.Next()))
        };
        return obj;
    }
}  
