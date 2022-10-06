using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeModel;

public abstract class Shape2D : Shape
{
    public abstract float Circumference { get; }
}
