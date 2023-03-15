using DalApi;
using DO;

namespace Dal;


public class DALCandy : ICandy
{
    /// <summary>
    /// create new candy on the screen 
    /// using pointMaker function to generate random point
    /// </summary>
    public void Create() => DataSource.candy.CandyOnMap.Add(DataSource.RandomPointMaker());


    /// <summary>
    /// remove the point from the list
    /// if the point does not found throw exception
    /// </summary>
    /// <param name="p"></param>
    /// <exception cref="ObjNotExistException"></exception>
    public void Delete(Point p)
    {
        if (Search(p) == null)
            throw new ObjNotExistException("can not delete candy - candy does not exist");

        DataSource.candy.CandyOnMap.Remove(p);
    }


    /// <summary>
    /// readCandy
    /// </summary>
    /// <returns> the copy of our candy from dataSource</returns>
    public Candy Read() => new Candy(){ CandyOnMap = DataSource.candy.CandyOnMap.ToList() };


    /// <summary>
    /// clear all the candys and make new candys
    /// </summary>
    /// <returns> the candy with the new list of candys </returns>
    public Candy Restart()
    {
        DataSource.candy.CandyOnMap.Clear();

        for (int i = 0; i < DataSource.MAX_CANDY_ON_MAP; i++)
            Create();
        return DataSource.candy;
    }


    /// <summary>
    /// replace the point in index to new random point
    /// using pointMaker function
    /// </summary>
    /// <param name="index"></param>     
    public void Update(int index) => DataSource.candy.CandyOnMap[index] = DataSource.RandomPointMaker();


    /// <summary>
    /// private help function
    /// search point in the container, checks if all the coordinate are equals
    /// </summary>
    /// <param name="p"></param>
    /// <returns>the point that found or null if not found</returns>
    private static Point? Search(Point p) => DataSource.candy.CandyOnMap.Find(t =>
        t!.Value.R == p.R && t!.Value.D == p.D && t!.Value.U == p.U && t!.Value.L == p.L);



}
