
namespace BO;
/// <summary>
/// represent point in the window, 
/// 0, 0, 0, 0 is the middle of the window
/// right, down, left, up
/// </summary>
public class Point
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

    
    public override int GetHashCode() => base.GetHashCode();  
    public override string ToString() => "BO.Point - Coordinate :" + R + "," + D + "," + L + "," + U;

    public static bool operator ==(Point left, Point right) => left.Equals(right);

    public static bool operator !=(Point left, Point right) => !(left == right);

    public override bool Equals(object? obj)
    {
        if (obj is Point p)
            return p.R == R && p.D == D && p.L == L && p.U == U;
        
        return base.Equals(obj);
    }
}
