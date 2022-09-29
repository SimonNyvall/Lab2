using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Shape;

public class Cuboid : Shape3D
{
    private Vector3 center;
    private Vector3 size;

    public bool IsCube { get; private set; } = false;

    public Cuboid(Vector3 center, Vector3 size)
    {
        this.center = center;
        this.size = size;

        if (size.X == size.Y && size.Y == size.Z)
            IsCube = true;
    }

    public Cuboid(Vector3 center, float width)
    {
        this.center = center;
        size.X = width;
        size.Y = width;
        size.Z = width;

        IsCube = true;
    }

    public override float Area
    {
        get { return 2 * (size.X * size.Y + size.X * size.Z + size.Y * size.Z); }
    }

    public override float Volume
    {
        get { return size.X * size.Y * size.Z; }
    }

    public override Vector3 Center
    {
        get { return new Vector3(center.X, center.Y, center.Z); }
    }

    public override string ToString()
    {
        return $"cuboid @({center.X}, {center.Y}, {center.Z}): w = {size.X}, h = {size.Y}, l = {size.Z}";
    }
}
