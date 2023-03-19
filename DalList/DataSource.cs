using DO;


namespace Dal;
/// <summary>
/// DataSource holding our data,
/// contain the snake and the candy
/// and there first initialization
/// </summary>
internal static class DataSource
{
    internal const int MAX_COORDINATE = 600, MAX_CANDY_ON_MAP = 3 ,SNAKE_START_LENGTH = 10;

    readonly static Random randomGenerate = new();

    internal static Snake snake;

    internal static Candy candy;

    static DataSource() => Initialize();

    
    static private void Initialize()
    {
        snake = new();
        candy = new();
        snake.Dir = Direction.Up;

        //Initialize start points of snake
        //Initialize capacity to 50 - will have enough space
        snake.SnakeBody = new(50);
        for (int i = 0; i < SNAKE_START_LENGTH; i++)
            snake.SnakeBody.Add(new Point() { X = 300, Y = 200+ i*10 });
            
        //generate random candys on map
        candy.CandyOnMap = new(MAX_CANDY_ON_MAP);
        for (int i = 0; i < MAX_CANDY_ON_MAP; i++)
           candy.CandyOnMap.Add(RandomPointMaker());

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
            X = randomGenerate.Next(MAX_COORDINATE -30),
            Y = randomGenerate.Next(MAX_COORDINATE - 60)
        };
    }
}
