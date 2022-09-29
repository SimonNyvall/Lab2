using System.Numerics;
using System.Reflection.Metadata.Ecma335;

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
            0 => new Circle(Vector2.One, 1.0f),
            1 => new Cuboid(Vector3.One, 1.0f),
            2 => new Cuboid(Vector3.One, 1.0f),
            3 => new Rectangle(Vector2.One, 1.0f),
            4 => new Rectangle(Vector2.One, 1.0f),
            5 => new Sphere(Vector3.One, 1.0f),
            6 => new Triangle(Vector2.One, Vector2.One, Vector2.One),
        };
        return obj;
    }
}  
