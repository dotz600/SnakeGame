
namespace BlApi;

/// <summary>
/// this interface define the
/// function that candy can do
/// </summary>
public interface ICandy
{
    /// <summary>
    /// create new random candy in the data base
    /// </summary>
    void Create();


    /// <summary>
    /// clear all candy and create new candys
    /// </summary>
    /// <returns>list with new candys</returns>
    List<BO.Point> Refresh();


    /// <summary>
    /// update the candy in the data base at index 
    /// </summary>
    /// <param name="index"></param>
    void Update(int index);


    /// <summary>
    /// get a copy of the candy list from data base
    /// </summary>
    /// <returns></returns>
    List<BO.Point> GetCandys();
}
