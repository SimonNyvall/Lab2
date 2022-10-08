using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShapeModel;

public class Sphere : Shape3D
{
    private Vector3 _center;

    private float _radius;
    private float _area;
    private float _volume;

    public Sphere(Vector3 center, float radius)
    {
        _center = center;
        _radius = radius;

        _area = 4 * MathF.PI * MathF.Pow(radius, 2);
        _volume = (4 * MathF.PI * MathF.Pow(radius, 3)) / 3;
    }

    public override float Area => _area;

    public override float Volume => _volume;

    public override Vector3 Center => _center;

    public override string ToString()
    {
        return $"{"Sphere",-10} @({_center.X:f2}; {_center.Y:f2}; {_center.Z:f2}): {"",5}r = {_radius:f2}";
    } 
}
