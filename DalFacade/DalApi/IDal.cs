using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi;

public interface IDal
{
    public ICandy Candy { get;}

    public ISnake Snake { get; }
}
