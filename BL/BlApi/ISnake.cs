using BO;
namespace BlApi;

/// <summary>
/// this interface defines all BO Snake methods.
/// </summary>
public interface ISnake
{

    /// <summary>
    /// adding new part to the snake, 
    /// at the end of the tail - 
    ///call when the snake eat a candy
    /// </summary>
    void Create();


    /// <summary>
    /// update the direction of snake
    /// </summary>
    /// <param name="dir"></param>
    void UpdateDirection(BO.Direction dir);


    /// <summary>
    /// get a copy of the snake from data base
    /// </summary>
    /// <returns>BO snake</returns>
    BO.Snake Read();


    /// <summary>
    /// checks if its gameOver
    /// if any coordinate is out of range 
    /// or if head of snake touch tail
    /// </summary>
    /// <returns>true its not the end of the game</returns>
    bool IsGameOn();


    /// <summary>
    /// optional to add direction, if so, update the direction and then continue the work
    /// update the movement of the snake
    /// the head of the snake move according to the direction
    /// then each point receives the coordinate of the point before it 
    /// also check if any candy were eaten
    /// </summary>
    /// <param name="dir"></param>
    /// <returns>new Bo snake after the move</returns>
    BO.Snake UpdateMove(BO.Direction? dir);
}
