using Shape;
using System.Numerics;
using System.Xml;

namespace Lab2.Tests;

public class ShapeTests
{
    [Fact]
    public void Circle_Test()
    {
        Circle circle = new(Vector2.One, 1.0f);

        float expectedArea = MathF.PI * MathF.Pow(1.0f, 2);
        float actualArea = circle.Area;

        Assert.Equal(expectedArea, actualArea);

        float expectedCircumference = 2 * (MathF.PI * 1.0f);
        float actualCircumference = circle.Circumference;

        Assert.Equal(expectedCircumference, actualCircumference);
    }
    [Fact]
    public void Rectangle_Test()
    {
        Rectangle rectangle = new(Vector2.One, new Vector2(1.0f, 2.0f));

        float expectedArea = 1.0f * 2.0f;
        float actualArea = rectangle.Area;

        Assert.Equal(expectedArea, actualArea);

        float expectedCircumference = 1.0f * 2 + 2.0f * 2;
        float actualCircumference = rectangle.Circumference;

        Assert.Equal(expectedCircumference, actualCircumference);

        // Squre
        Rectangle square = new(Vector2.One, 1.0f);

        expectedArea = 1.0f * 1.0f;
        actualArea = square.Area;

        Assert.Equal(expectedArea, actualArea);

        expectedCircumference = 1.0f * 4;
        actualCircumference = square.Circumference;

        Assert.Equal(expectedCircumference, actualCircumference);
    }
    [Fact]
    public void Cuboid_Test()
    {
        Cuboid cuboid = new(Vector3.One, new Vector3(1.0f, 2.0f, 3.0f));

        float expectedArea = (2 * 1.0f * 1.0f) + (2 * 2.0f * 2.0f) + (2 * 3.0f * 3.0f);
        float actualArea = cuboid.Area;

        Assert.Equal(expectedArea, actualArea);

        float expectedVolume = 1.0f * 2.0f * 3.0f;
        float actualVolume = cuboid.Volume;

        Assert.Equal(expectedVolume, actualVolume);

        Cuboid cube = new(Vector3.One, 1.0f);

        expectedArea = 1.0f * 1.0f * 6.0f;
        actualArea = cube.Area;

        Assert.Equal(expectedArea, actualArea);

        expectedVolume = 1.0f * 1.0f * 1.0f;
        actualArea = cube.Volume;

        Assert.Equal(expectedVolume, actualVolume);
    }
    [Fact]
    public void Sphere_Test()
    {
        Sphere sphere = new(Vector3.One, 1.0f);

        float expectedArea = 4 * MathF.PI * 1.0f * 1.0f;
        float actualArea = sphere.Area;

        Assert.Equal(expectedArea, actualArea);

        float expectedVolume = (4 * MathF.PI * 1.0f * 1.0f * 1.0f) / 3;
        float actualVolume = sphere.Volume;

        Assert.Equal(expectedVolume, actualVolume);
    }
    [Fact]
    public void Triangle_Test()
    {
        Triangle triangle = new(Vector2.One, Vector2.One * 2.0f, Vector2.One * 3.0f);

        (float A, float B, float C) side;
        side.A = Vector2.Distance(Vector2.One * 3.0f, Vector2.One * 2.0f);
        side.B = Vector2.Distance(Vector2.One, Vector2.One * 3.0f);
        side.C = Vector2.Distance(Vector2.One, Vector2.One * 2.0f);

        float CosC = (side.C * side.C - side.A * side.A - side.B * side.B) / (-2 * side.A * side.B);
        float angileC = MathF.Acos(CosC);

        float expectedArea = (side.A * side.B * MathF.Sin(angileC)) / 2;
        float actualArea = triangle.Area;

        Assert.Equal(expectedArea, actualArea);


        float expetedCircumference = side.A + side.B + side.C;
        float actualCircumference = triangle.Circumference;

        Assert.Equal(expetedCircumference, actualCircumference);

    }
}