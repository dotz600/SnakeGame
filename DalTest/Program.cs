using DalApi;
using Dal;
using DO;

namespace DalTest;

class Program
{
    static void Main()
    {
        try
        {
            IDal? obj = DalList.Instance;

            //snake test
            for (int i = 0; i < 10; i++)
            {
                obj.Snake.Create(new DO.Point() { U = i + 7, D = i - 1, L = i + 10, R = i + 1 });
            }
            var tmp = obj.Snake.Read().SnakeBody;
            for (int i = 0; i < tmp.Count; i++)
            {
                obj.Snake.Update(new DO.Point() { U = i + 2, D = i - 2, L = i + 1, R = i + 10 }, i);
            }
            var tmp1 = obj.Snake.Read().SnakeBody;
            for (int i = 0; i < tmp.Count; i++)
            {
                if (tmp1[i].Equals(tmp[i]))
                    Console.WriteLine("snake update failed");
            }
            obj.Snake.UpdateDirection(DO.Direction.Down);
            if (obj.Snake.Read().Dir != DO.Direction.Down)
                Console.WriteLine("snake update failed");

            //Candy test
            tmp = obj.Candy.Read().CandyOnMap;

            for (int i = 0; i < 10; i++)
            {
                obj.Candy.Create();
            }
            for (int i = 0; i < obj.Candy.Read().CandyOnMap.Count; i++)
            {
                obj.Candy.Update(i);
            }
            tmp1 = obj.Candy.Read().CandyOnMap;
            for (int i = 0; i < tmp.Count; i++)
                if (tmp[i].Equals(tmp1[i]))
                    Console.WriteLine("faild to create");

            tmp = obj.Candy.Restart().CandyOnMap;
            if (tmp.Count != 3)
                Console.WriteLine("the restart list size is not equal to max size of candy");

            for (int i = 0; i < tmp.Count; i++)
                if (tmp[i].Equals(tmp1[i]))
                    Console.WriteLine("faild to restart");

            tmp1 = obj.Candy.Read().CandyOnMap;
            for (int i = 0; i < tmp.Count; i++)
                if (!tmp[i].Equals(tmp1[i]))
                    Console.WriteLine("restart faild! - the restart list is not saved in the dataSource");

            tmp1 = obj.Candy.Read().CandyOnMap;
            obj.Candy.Delete((Point)tmp1[2]!);
            foreach (var x in obj.Candy.Read().CandyOnMap)
                if (x.Equals(tmp1[2]))
                    Console.WriteLine("not deleted");

            Console.WriteLine("if there is no other output - its all working well!");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    private static void printList(List<Point?> tmp1)
    {
        foreach (var item in tmp1)
        {
            Console.WriteLine(item);
        }
    }
}