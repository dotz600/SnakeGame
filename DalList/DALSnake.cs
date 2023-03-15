using DalApi;
using DO;
using System.Security.Cryptography;

namespace Dal;

public class DALSnake : ISnake
{
    /// <summary>
    /// create new point to the snake
    /// </summary>
    /// <param name="p"></param>
    /// <exception cref="ObjExistException"></exception>
    public void Create(Point p)
    {
        if (Search(p) != null)
            throw new ObjExistException("cannot create New Point - point already exist");
        
        DataSource.snake.SnakeBody.Add(p);
    }


    /// <summary>
    /// 
    /// </summary>
    /// <returns> the copy of our snake </returns>
    public Snake Read() => new Snake() { SnakeBody = DataSource.snake.SnakeBody.ToList(), Dir = DataSource.snake.Dir };
 

    /// <summary>
    /// update the point at index to p
    /// </summary>
    /// <param name="p"></param>
    /// <param name="index"></param>
    public void Update(Point p, int index) => DataSource.snake.SnakeBody[index] = p;


    /// <summary>
    /// update the direction of the snake
    /// </summary>
    /// <param name="dir"></param>
    public void UpdateDirection(Direction dir) => DataSource.snake.Dir = dir;
   

    /// <summary>
    /// private help function
    /// search point in the container, checks if all the coordinate are equals
    /// </summary>
    /// <param name="p"></param>
    /// <returns>the point that found or null if not found</returns>
    private static Point? Search(Point p) => DataSource.snake.SnakeBody.Find(t =>
        t!.Value.R == p.R && t!.Value.D == p.D && t!.Value.U == p.U && t!.Value.L == p.L);

    
}
