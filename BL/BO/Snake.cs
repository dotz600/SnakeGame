namespace BO;

/// <summary>
/// this class represent the snake.
/// snake contain list of point and direction
/// and bool is the snake run
/// </summary>
public class Snake
{
    public List<BO.Point>? SnakeBody { get; set; }

    public Direction Dir { get; set; }

    public bool IsRun { get; set; }


    override public string ToString()
    {
        return "BO Snake" + "lenth of snake " + SnakeBody?.Count 
            + "Direction " + Dir +
            " is run " + IsRun  ;
    }
}
