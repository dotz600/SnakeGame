using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO;

public struct Point 
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public int W { get; set; }

    public override string ToString()
    {
        return "Coordinate :" + X + "," + Y + "," + Z + "," + W;
    }
}
