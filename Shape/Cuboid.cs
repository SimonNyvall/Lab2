﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShapeNameSpace;

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
      
        size = Vector3.One * width;

        IsCube = true;
    }

    public override float Area
    {
        get => 2 * (size.X * size.Y + size.X * size.Z + size.Y * size.Z); 
    }

    public override float Volume
    {
        get => size.X * size.Y * size.Z; 
    }

    public override Vector3 Center
    {
        get => new Vector3(center.X, center.Y, center.Z); 
    }

    public override string ToString()
    {
        if (IsCube) 
            return $"cube @({center.X}; {center.Y}; {center.Z}): w = {size.X}, h = {size.Y}, l = {size.Z}";
        else
            return $"cuboid @({center.X}; {center.Y}; {center.Z}): w = {size.X}, h = {size.Y}, l = {size.Z}";
    }
}
