using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO;

public struct Candy
{
    public List<Point> CandyOnMap { get; set; }

    public override string ToString()
    {
        return "Amount Of Candyes On Map " + CandyOnMap.Count;
    }
}
