using DalApi;
using DO;

namespace Dal;

/// <summary>
/// this class implement the ICandy interface.
/// and all candy operations
/// </summary>
public class DALCandy : ICandy
{
    public void Create() => DataSource.candy.CandyOnMap.Add(DataSource.RandomPointMaker());

    
    public void Delete(Point p)
    {
        if (DataSource.candy.CandyOnMap.Find(t => t == p) == null)
            throw new ObjNotExistException("can not delete candy - candy does not exist");

        DataSource.candy.CandyOnMap.Remove(p);
    }

    
    public Candy Read() => new(){ CandyOnMap = DataSource.candy.CandyOnMap.ToList() };

    
    public Candy Restart()
    {
        DataSource.candy.CandyOnMap.Clear();

        for (int i = 0; i < DataSource.MAX_CANDY_ON_MAP; i++)
            Create();
        return new() { CandyOnMap = DataSource.candy.CandyOnMap.ToList() };
    }
   
    
    public void Update(int index) => DataSource.candy.CandyOnMap[index] = DataSource.RandomPointMaker();
    
}
