using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShapeModel;

public class Cuboid : Shape3D
{
    private Vector3 _center;
    private Vector3 _size;

    private float _area;
    private float _volume;
    public bool IsCube { get; private set; } = false;

    public Cuboid(Vector3 center, Vector3 size)
    {
        _center = center;
        _size = size;

        _area = 2 * (size.X * size.Y + size.X * size.Z + size.Y * size.Z);
        _volume = size.X * size.Y * size.Z;

        if (size.X == size.Y && size.Y == size.Z)
            IsCube = true;
    }

    public Cuboid(Vector3 center, float width): this(center, Vector3.Zero)
    {
        _size = Vector3.One * width;
    }

    public override float Area => _area;

    public override float Volume => _volume;

    public override Vector3 Center => new Vector3(_center.X, _center.Y, _center.Z); 

    public override string ToString()
    {
        return (IsCube ? $"{"Cube", -9}" : $"{"Cuboid", -9}") + $"  @({_center.X:f2}; {_center.Y:f2}; {_center.Z:f2}): {"",5}w = {_size.X:f2}, h = {_size.Y:f2}, l = {_size.Z:f2}";        
    }
}
