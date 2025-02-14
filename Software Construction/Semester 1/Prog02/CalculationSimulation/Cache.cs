
/// <summary>
/// This class acts as a cache of already calculated results
/// </summary>
public class Cache
{
    #region Instance fields
    private int?[,] cacheValues;
    #endregion

    #region Constructor
    public Cache(int maxX, int maxY)
    {
        // Create a maxX x maxY cache of results
        cacheValues = new int?[maxX, maxY];

        for (int x = 0; x < maxX; x++)
        {
            for (int y = 0; y < maxY; y++)
            {
                cacheValues[x, y] = null;
            }
        }
    }
    #endregion

    #region Properties
    /// <summary>
    /// Look up the value stored in cell [x,y]
    /// </summary>
    public int? Lookup(int x, int y)
    {
        return cacheValues[x, y];
    }

    /// <summary>
    /// Stores the given value in cell [x,y]
    /// </summary>
    public void Insert(int x, int y, int value)
    {
        cacheValues[x, y] = value;
    }
    #endregion
}
