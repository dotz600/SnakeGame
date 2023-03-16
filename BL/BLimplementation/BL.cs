using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLimplementation;

sealed public class BL : IBL
{
    public ISnake Snake => new Snake();

    public ICandy Candy => new Candy();

    
}
