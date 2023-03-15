using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO;
/// <summary>
/// represent point in the window, 
/// 0, 0, 0, 0 is the moddile of the window
/// right, down, left, up
/// </summary>
public struct Point 
{
    /// <summary>
    /// right coordinate
    /// </summary>
    public int R { get; set; }

    /// <summary>
    /// down coordinate
    /// </summary>
    public int D { get; set; }  

    /// <summary>
    /// left coordinate
    /// </summary>
    public int L { get; set; } 
    /// <summary>
    /// up coordinate
    /// </summary>
    public int U { get; set; } 


    public override string ToString()
    {
        return "Coordinate :" + R + "," + D + "," + L + "," + U;
    }
}
