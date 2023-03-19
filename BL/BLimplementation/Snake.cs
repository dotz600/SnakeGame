using Dal;
using DalApi;

namespace BLimplementation;

/// <summary>
/// this class implement the ISnake interface.
/// it is the logic layer of the snake game.
///        |Y
///        |
///        |
///--------|-----------X
///        |*
///        |
/// here * is point (0, 0) zero point from left & zero point from top
/// there for head point clculation is defrent from the rest of the snake
/// the calculation found in the code
/// </summary>
public class Snake : BlApi.ISnake
{
    readonly IDal? dal = Dal.DalList.GetInstance();

    //max jump of the snake, 
    // taken from data base
    readonly int MaxSnakeMove = Dal.DalList.GetInstance().Snake.GetMaxSnakeMove();

    //max coordinate of the window, 
    // taken from data base
    readonly int maxCoordinate = Dal.DalList.GetInstance().Snake.GetMaxCordinate();

    //delegate & event for each time candy is eaten
    public delegate void CandyEaten();
    public static event CandyEaten? CandyEatenEvent;

    public void Create()
    {
        DO.Snake sn = dal!.Snake.Read();
        DO.Point p = sn.SnakeBody.Last() ?? throw new NullReferenceException("snake is empty");
        try
        {
            //move the point coordinate according to direction
            switch (sn.Dir)
            {
                case DO.Direction.Up:
                    p.Y += MaxSnakeMove;
                    break;
                case DO.Direction.Down:
                    p.Y -= MaxSnakeMove;
                    break;
                case DO.Direction.Left:
                    p.X += MaxSnakeMove;
                    break;
                case DO.Direction.Right:
                    p.X -= MaxSnakeMove;
                    break;

            }
            dal!.Snake.Create(p);
            CandyEatenEvent!();
        }
        catch (ObjExistException)
        {
            //if cant create the point, can be becouse direction is down but tail is still go up
            //then update point coordinate to the opposite side & recreate
            p = sn.SnakeBody.Last() ?? throw new NullReferenceException("snake is empty");
            p = UpdateHeadCoordinate(sn.Dir, p);
            dal!.Snake.Create(p);
            CandyEatenEvent!();
        }

    }

    public bool IsGameOn()
    {
        var lst = Read().SnakeBody!;
        BO.Point head = lst[0];//check if head is out of boundery
        if (head.X > maxCoordinate - MaxSnakeMove * 3 || head.X < MaxSnakeMove ||
            head.Y > maxCoordinate - MaxSnakeMove * 6 || head.Y < MaxSnakeMove)
            return false;

        //check the snake didn't touch himself
        //that mean the head coordinate not equl to other point of the body
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
        dal!.Snake.Update(UpdateHeadCoordinate(snk.Dir, oldHead), 0);

        CheckCandyEaten(snk);

        return Read();
    }
    
    public int GetMaxCoordinate() => maxCoordinate;

    
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
            if (Math.Abs(snk.SnakeBody[0]!.Value.X - candyLst[i]!.Value.X) < MaxSnakeMove
                && Math.Abs(snk.SnakeBody[0]!.Value.Y - candyLst[i]!.Value.Y) < MaxSnakeMove)//head of the snake touch candy
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
    private DO.Point UpdateHeadCoordinate(DO.Direction dir, DO.Point p)
    {
        switch (dir)
        {
            case DO.Direction.Up:
                p.Y -= MaxSnakeMove;
                break;
            case DO.Direction.Down:
                p.Y += MaxSnakeMove;
                break;
            case DO.Direction.Left:
                p.X -= MaxSnakeMove;
                break;
            case DO.Direction.Right:
                p.X += MaxSnakeMove;
                break;

        }
        return p;
    }

    
}
