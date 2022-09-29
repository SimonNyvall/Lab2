using System.Numerics;

namespace Shape
{
    public abstract class Shape
    {
        public abstract Vector3 Center { get; }
        public abstract float Area { get; }

        public static Shape? GenerateShape()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 7);

            switch (randomNumber)
            {
                case 0:
                    {
                        Circle circle = new(new Vector2(1.0f, 1.0f), 1.0f);
                        return circle;
                    }
                case 1:
                    {
                        Cuboid cuboid = new(new Vector3(1.0f, 1.0f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f));
                        return cuboid;
                    }
                case 2:
                    {
                        Cuboid cuboid = new(new Vector3(1.0f, 1.0f, 1.0f), new Vector3(1.0f, 1.0f, 1.0f));
                        return cuboid;
                    }
                case 3:
                    {
                        Rectangle rectangle = new(new Vector2(1.0f, 1.0f), new Vector2(1.0f, 1.0f));
                        return rectangle;
                    }
                case 4:
                    {
                        Rectangle rectangle = new(new Vector2(1.0f, 1.0f), 1.0f);
                        return rectangle;
                    }
                case 5:
                    {
                        Sphere sphere = new(new Vector3(1.0f, 1.0f, 1.0f), 1.0f);
                        return sphere;
                    }
                case 6:
                    {
                        Triangle triangle = new(new Vector2(1.0f, 1.0f), new Vector2(1.0f, 1.0f), new Vector2(1.0f, 1.0f));
                        return triangle;
                    }
                default:
                    return default;
                    break;
            }
        }
    }  
}