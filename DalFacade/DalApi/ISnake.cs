using DO;

namespace DalApi;

/// <summary>
/// this interface is for all snake action
/// create new point to snake , read - get the snake,
/// update point in the snake body
/// update Direction of the snake
/// get max cordinate of the map
/// </summary>
public interface ISnake 
{
    /// <summary>
    /// create new point to the snake
    /// </summary>
    /// <param name="p"></param>
    /// <exception cref="ObjExistException"></exception>
    void Create(Point p);
    

    /// <summary>
    /// 
    /// </summary>
    /// <returns> the copy of our snake </returns>
    Snake Read();
    

    /// <summary>
    /// update the point at index to p
    /// </summary>
    /// <param name="p"></param>
    /// <param name="index"></param>
    void Update(Point p, int index);
    

    /// <summary>
    /// update the direction of the snake
    /// </summary>
    /// <param name="dir"></param>
    void UpdateDirection(Direction dir);

    /// <summary>
    /// get the max coordinate of the map
    /// help to know when the snake is out of range
    /// </summary>
    /// <returns>max cordinate</returns>
    int GetMaxCordinate();
}
