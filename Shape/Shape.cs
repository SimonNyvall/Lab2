using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Shape;

public abstract class Shape
{
    public abstract Vector3 Center { get; }
    public abstract float Area { get; }

    public static Shape GenerateShape()
    {
        Random rnd = new Random();

        Shape obj = rnd.Next(0, 7) switch
        {
            0 => new Circle(new Vector2(rnd.Next(), rnd.Next()), rnd.Next()),
            1 => new Cuboid(new Vector3(rnd.Next(), rnd.Next(), rnd.Next()), rnd.Next()),
            2 => new Cuboid(new Vector3(rnd.Next(), rnd.Next(), rnd.Next()), rnd.Next()),
            3 => new Rectangle(new Vector2(rnd.Next(), rnd.Next()), rnd.Next()),
            4 => new Rectangle(new Vector2(rnd.Next(), rnd.Next()), rnd.Next()),
            5 => new Sphere(new Vector3(rnd.Next(), rnd.Next(), rnd.Next()), rnd.Next()),
            6 => new Triangle(new Vector2(rnd.Next(), rnd.Next()), new Vector2(rnd.Next(), rnd.Next()), new Vector2(rnd.Next(), rnd.Next())),
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
            6 => new Triangle(new Vector2(rnd.Next(), rnd.Next()), new Vector2(rnd.Next(), rnd.Next()), new Vector2(rnd.Next(), rnd.Next())),
        };
        return obj;
    }
}  
