using DO;

namespace DalApi;

public interface ICandy 
{
    /// <summary>
    /// create new candy on the screen 
    /// using pointMaker function to generate random point
    /// </summary>
    void Create();

    
    /// <summary>
    /// readCandy
    /// </summary>
    /// <returns> the copy of our candy from dataSource</returns> 
    Candy Read();

    
    /// <summary>
    /// replace the point in index to new random point
    /// using pointMaker function
    /// </summary>
    /// <param name="index"></param> 
    void Update(int index);
    

    /// <summary>
    /// remove the point from the list
    /// if the point does not found throw exception
    /// </summary>
    /// <param name="p"></param>
    /// <exception cref="ObjNotExistException"></exception>
    void Delete(Point p);

    
    /// <summary>
    /// clear all the candys and make new candys
    /// </summary>
    /// <returns> the candy with the new list of candys </returns>
    Candy Restart();

}
