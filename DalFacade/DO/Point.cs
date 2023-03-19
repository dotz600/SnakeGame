﻿
namespace DO;
/// <summary>
/// represent point in the window, 
/// 0, 0, 0, 0 is the middle of the window
/// right, down, left, up
/// </summary>
public struct Point 
{
    /// <summary>
    /// right coordinate
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// up coordinate
    /// </summary>
    public int Y { get; set; }


    
    public override bool Equals(object? obj)
    {
        if (obj is Point p)
            return p.X == X && p.Y == Y;
        
        return false;
    }
    public override string ToString() => "Coordinate :" + X + "," + "," + Y;

    public static bool operator ==(Point left, Point right) => left.Equals(right);

    public static bool operator !=(Point left, Point right) => !(left == right);

    public override int GetHashCode() => base.GetHashCode();
}
