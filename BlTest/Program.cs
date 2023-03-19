
namespace BlTest;
/// <summary>
/// this class for test BL logical layer
/// </summary>
static class Program
{
    public static void Main()
    {
        BlApi.IBL bl = new BLimplementation.BL();

        //candy test
        var lst1 = bl.Candy.Read().CandysOnMap;
        bl.Candy.Create();
        if (lst1!.Count + 1 != bl.Candy.Read().CandysOnMap!.Count)
            Console.WriteLine("faild to create");
        bl.Candy.Update(0);
        if (lst1[0] == bl.Candy.Read().CandysOnMap![0])
            Console.WriteLine("faild to update");
        lst1 = bl.Candy.Read().CandysOnMap;
        int i = 0;
        foreach (var x in bl.Candy.Refresh().CandysOnMap!)
            if (x == lst1![i++])
                Console.WriteLine("not deleted");
        
        Console.WriteLine("end of candy test - if no other output - its all working well!");
        
        //snake test
        var snk= bl.Snake.Read();
        bl.Snake.UpdateDirection(BO.Direction.Down);
        if (snk.Dir == bl.Snake.Read().Dir)
            Console.WriteLine("faild to update direction");
        PrintList(snk.SnakeBody!);
        bl.Snake.UpdateDirection(BO.Direction.Up);

        var snk2 = bl.Snake.UpdateMove(null);
        Console.WriteLine("updateMove");
        PrintList(snk2.SnakeBody!);
        for (i = 0; i < snk.SnakeBody!.Count; i++)
            if (snk.SnakeBody[i] == snk2.SnakeBody![i])
                Console.WriteLine("faild to update move");
        bl.Snake.Create();
        if (snk.SnakeBody!.Count + 1 != bl.Snake.Read().SnakeBody!.Count)
            Console.WriteLine("faild to create");
        Console.WriteLine("after create");
        PrintList(bl.Snake.Read().SnakeBody!);

        if (!bl.Snake.IsGameOn())
            Console.WriteLine("faild to check if game is on");

        Console.WriteLine("end of snake test - if no other output - its all working well!");

    }
    private static void PrintList(List<BO.Point?> tmp1)
    {
        foreach (var item in tmp1)
        {
            Console.WriteLine(item);
        }
    }
}
