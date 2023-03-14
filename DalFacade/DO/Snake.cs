using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace DO;

public struct Snake
{
    public Direction Dir { get; set; }

    public List<Point> SnakeBody { get; set; }

    public override string ToString()
    {
        return "Snake Direction " + Dir +
            "Length " + SnakeBody.Count;
    }
}
