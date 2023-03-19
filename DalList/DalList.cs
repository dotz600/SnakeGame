using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;

namespace Dal;

/// <summary>
/// this class implement the IDal interface.
/// using singltom pattern return the same instance of the class
/// </summary>
sealed public class DalList : IDal
{
    private DalList()
    {
        Candy = new DALCandy();
        Snake = new DALSnake();
    }
    
    public ICandy Candy { get; }
    public ISnake Snake { get; }
    private static IDal Instance { get; } = new DalList();
    
    public static IDal GetInstance() => Instance;

}
