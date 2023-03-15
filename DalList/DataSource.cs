using DO;


namespace Dal;
/// <summary>
/// DataSource holding our data,
/// contain the snake and the candy
/// and there first initialization
/// </summary>
internal static class DataSource
{
    internal const int MAX_COORDINATE = 201, MAX_CANDY_ON_MAP = 3 ,SNAKE_START_LENGTH = 5;

    readonly static Random randomGenerate = new(MAX_COORDINATE);

    internal static Snake snake;

    internal static Candy candy;

    static DataSource() => s_Initialize();

    
    static private void s_Initialize()
    {
        snake = new();
        candy = new();
        snake.Dir = Direction.Up;

        //Initialize start points of snake
        //Initialize capacity to 50 - will have enough space
        snake.SnakeBody = new(50);
        for (int i = 0; i < SNAKE_START_LENGTH; i++)
        {
            snake.SnakeBody.Add(new Point() { R = 0, D = i, L = 0, U = 0 });
        }
            
        //generate random candys on map
        candy.CandyOnMap = new(MAX_CANDY_ON_MAP);
        for (int i = 0; i < MAX_CANDY_ON_MAP; i++)
        {
           candy.CandyOnMap.Add(RandomPointMaker());
        }

    }

    /// <summary>
    /// create random point 
    /// using here  & DalCandy
    /// </summary>
    /// <returns>random point</returns>
    internal static Point RandomPointMaker()
    {
        return new Point()
        {
            D = randomGenerate.Next(MAX_COORDINATE),
            L = randomGenerate.Next(MAX_COORDINATE),
            R = randomGenerate.Next(MAX_COORDINATE),
            U = randomGenerate.Next(MAX_COORDINATE)
        };
    }
}
