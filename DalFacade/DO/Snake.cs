
namespace DO;

/// <summary>
/// Snake is a struct that represent the snake on the screen
/// snake have a direction and a list of points
/// each point represent a part of the snake body
/// </summary>
public struct Snake
{
    public Direction Dir { get; set; }

    public List<Point?> SnakeBody { get; set; }
    
    public override string ToString() => "Snake Direction " + Dir +
            "Length " + SnakeBody.Count;
}
