using DalApi;

namespace BLimplementation;

/// <summary>
/// this class implement the ISnake interface.
/// it is the logic layer of the snake game.
/// </summary>
internal class Snake : BlApi.ISnake
{
    readonly IDal? dal = Dal.DalList.GetInstance();


    // represent the jump of each move of the snake
    // in our case 5 points
    const int SNAKE_MOVE = 5;
    
    
 
    //max coordinate of the window, 
    // taken from data base
    readonly int maxCoordinate = Dal.DalList.GetInstance().Snake.GetMaxCordinate();

    
    public void Create()
    {
        DO.Snake sn = dal!.Snake.Read();
        DO.Point p = sn.SnakeBody.Last() ?? throw new NullReferenceException("snake is empty");
        //move the point coordinate according to direction
        switch (sn.Dir)
        {
            case DO.Direction.Up:
                p.D += SNAKE_MOVE;
                break;
            case DO.Direction.Left:
                p.R += SNAKE_MOVE;
                break;
            case DO.Direction.Right:
                p.L += SNAKE_MOVE;
                break;
            case DO.Direction.Down:
                p.U += SNAKE_MOVE;
                break;
        }
        dal!.Snake.Create(p);
    }

    public bool IsGameOn()
    {
        var lst = Read().SnakeBody!;
        foreach (var p in lst)
            if (!CheckRange(p))
                return false;

        //check the snake didn't touch himself
        //that mean the head coordinate dont found in other point also
        for (int i = 1; i < lst.Count; i++)
            if (lst[0] == lst[i])
                return false;

        return true;
    }

    public BO.Snake Read()
    {
        DO.Snake snk = dal!.Snake.Read();

        return new BO.Snake()
        {
            SnakeBody = Candy.ConvertToBoPoint(snk.SnakeBody),
            Dir = (BO.Direction)snk.Dir,
            IsRun = true
        };
    }

    public void UpdateDirection(BO.Direction dir) => dal!.Snake.UpdateDirection((DO.Direction)dir);

    public BO.Snake UpdateMove(BO.Direction? dir)
    {
        if (dir != null)
            UpdateDirection(dir.Value);

        DO.Snake snk = dal!.Snake.Read();

        //body calculation --- each point receives the
        //coordinate of the point before it -- exept head 
        for (int i = 1; i < snk.SnakeBody.Count; i++)
        {
            DO.Point tmp = (DO.Point)snk.SnakeBody[i - 1]!;
            dal!.Snake.Update(tmp, i);
        }

        //update head coordinate
        DO.Point oldHead = snk.SnakeBody[0]!.Value;
        dal!.Snake.Update(HeadCoordinateUpdate(snk.Dir, oldHead), 0);

        CheckCandyEaten(snk);
        
        return Read();
    }


    /// <summary>
    /// private help function
    /// check if the update cause the snake to eat candy
    /// if so - make new candy at the place of the eaten candy & add point to snake
    /// </summary>
    /// <param name="snk"></param>
    private void CheckCandyEaten(DO.Snake snk)
    {
        var candyLst = dal!.Candy.Read().CandyOnMap;
        for (int i = 0; i < candyLst.Count; i++)
        {
            if (snk.SnakeBody[0] == candyLst[i])//head of the snake touch candy
            {
                dal!.Candy.Update(i);//make new candy
                Create();            //add new point to the snake   
            }
        }
    }


    /// <summary>
    /// private help function
    /// move the point coordinate according to direction
    /// </summary>
    /// <param name="dir"></param>
    /// <param name="p"></param>
    /// <returns>the point with the updated valu</returns>
    private static DO.Point HeadCoordinateUpdate(DO.Direction dir, DO.Point p)
    {
        switch (dir)
        {
            case DO.Direction.Up:
                p.U += SNAKE_MOVE;
                break;
            case DO.Direction.Left:
                p.L += SNAKE_MOVE;
                break;
            case DO.Direction.Right:
                p.R += SNAKE_MOVE;
                break;
            case DO.Direction.Down:
                p.D += SNAKE_MOVE;
                break;
        }
        return p;
    }

    /// <summary>
    /// private help function
    /// check if the point is in range of the window 
    /// </summary>
    /// <param name="p"></param>
    /// <returns>true if inside the boundary, else false</returns>
    private bool CheckRange(BO.Point p)
    {
        if (p.L > maxCoordinate || p.L < 0 || p.R > maxCoordinate || p.R < 0 ||
            p.U > maxCoordinate || p.U < 0 || p.D > maxCoordinate || p.D < 0)
            return false;

        return true;
    }
}
