using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;

internal static class DataSource
{
    const int MAX_COORDINATE = 200;
    const int MAX_CANDY_ON_MAP = 3;

    readonly static Random randomGenerate = new(MAX_COORDINATE + 1);

    public static Snake snake;

    public static Candy candy;

    static DataSource()
    {
        s_Initialize();
    }
    static private void s_Initialize()
    {
        snake = new();
        candy = new();
        snake.Dir = Direction.Up;
        snake.SnakeBody = new() {new Point()}; /*xyzw = 0*/
        candy.CandyOnMap = new();

        //generate random candys on map
        for (int i = 0; i < MAX_CANDY_ON_MAP; i++)
            candy.CandyOnMap.Add(new Point()
            {
                X = randomGenerate.Next(),
                Y = randomGenerate.Next(),
                Z = randomGenerate.Next(),
                W = randomGenerate.Next()
            });
    }
}
