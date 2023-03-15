using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalApi;

namespace Dal;

sealed public class DalList : IDal
{
    private DalList()
    {
        Candy = new DALCandy();
        Snake = new DALSnake();
    }
    
    public ICandy Candy { get; }
    public ISnake Snake { get; }
    public static IDal Instance { get; } = new DalList();

}
