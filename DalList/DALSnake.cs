using DalApi;
using DO;
using System.Security.Cryptography;

namespace Dal;
/// <summary>
/// this class implement the ISnake interface.
/// and all the snake operations
/// </summary>
public class DALSnake : ISnake
{
    public void Create(Point p)
    {
        if (DataSource.snake.SnakeBody.Find(t => t == p ) != null)
            throw new ObjExistException("cannot create New Point - point already exist");
        
        DataSource.snake.SnakeBody.Add(p);
    }


    public Snake Read() => new() { SnakeBody = DataSource.snake.SnakeBody.ToList(), Dir = DataSource.snake.Dir };
 

    public void Update(Point p, int index) => DataSource.snake.SnakeBody[index] = p;



    public void UpdateDirection(Direction dir) => DataSource.snake.Dir = dir;


    public int GetMaxSnakeMove() => DataSource.MAX_SNAKE_MOVE;
    
    public int GetMaxCordinate() => DataSource.MAX_COORDINATE;
}
