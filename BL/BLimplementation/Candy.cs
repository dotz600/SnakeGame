
using BlApi;

using DalApi;

namespace BLimplementation;

/// <summary>
/// this class implement the ICandy interface.
/// and use the dal to work with the data base.
/// implement all BO.Candy function, such as:
/// create new candy, get list if candys, update candy at index i,
/// refresh candys list - clear all candys and create new candys
/// </summary>
internal class Candy : BlApi.ICandy
{
    readonly IDal? dal = Dal.DalList.GetInstance();

    public void Create() => dal?.Candy.Create();

    public List<BO.Point> GetCandys() => ConvertToBoPoint(dal!.Candy.Read().CandyOnMap);

    public List<BO.Point> Refresh() => ConvertToBoPoint(dal!.Candy.Restart().CandyOnMap);

    public void Update(int index) => dal!.Candy.Update(index);

    
    /// <summary>
    ///  help function - convert from DO.Point list to BO.Point list
    /// internal - for usege also in BLimplementation snake
    /// </summary>
    /// <param name="lst"></param>
    /// <returns>new BO.point list</returns>
    internal static List<BO.Point> ConvertToBoPoint(List<DO.Point?> lst)
    {
        return (from x in lst
                where x != null
                select new BO.Point()
                { D = x.Value.D, L = x.Value.L,
                R = x.Value.R, U = x.Value.U }).ToList();
    }
}
