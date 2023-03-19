using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO;

/// <summary>
/// Candy is a struct that represents the candy on the screen    
/// have a list of points, each point mean a candy
/// </summary>
public struct Candy
{
    public List<Point?> CandyOnMap { get; set; }

    public override string ToString()
    {
        return "Amount Of Candyes On Map " + CandyOnMap.Count;
    }
}
