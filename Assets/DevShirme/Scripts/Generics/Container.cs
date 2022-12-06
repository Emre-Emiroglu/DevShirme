using System.Collections.Generic;

public class Container<T>
{
    #region Fields
    private List<T> objs;
    #endregion

    #region Getters
    public List<T> Objs => objs;
    #endregion

    #region Core
    public Container()
    {
        objs = new List<T>();
    }
    #endregion

    #region Execute
    public void AddNewObj(T obj) 
    {
        if (!objs.Contains(obj))
        {
            objs.Add(obj);
        }
    }
    public void RemoveObj(T obj)
    {
        if (objs.Contains(obj))
        {
            objs.Remove(obj);
        }
    }
    public void Clear() => objs.Clear();
    #endregion
}
