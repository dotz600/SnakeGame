using DO;

namespace DalApi;

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
}
