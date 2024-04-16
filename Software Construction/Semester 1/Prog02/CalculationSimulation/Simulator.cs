/// <summary>
/// This class simulates a calculation of a value depending on
/// an x and y value. The calculation takes about 500 milliseconds.
/// However, the simulator may optionally use a cache to speed
/// up the caluclation.
/// </summary>
public class Simulator
{
    #region Instance fields
    private Random _generator;
    private Cache? _cache;
    private int _maxX;
    private int _maxY;
    #endregion

    #region Constants
    private const int MAX_VALUE = 1000;
    private const int CALCULATION_PAUSE_MS = 500;
    #endregion

    #region Constructor
    public Simulator(int maxX, int maxY, bool useCache)
    {
        _maxX = maxX;
        _maxY = maxY;
        _generator = new Random();
        _cache = useCache? new Cache(maxX, maxY) : null; // switch to null for cache-less calculation;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Simulate a calculation, possibly using a cached value.
    /// </summary>
    public int? Calculate(int x, int y)
    {
        int? result = null;

        if (x < _maxX && x >= 0 && y < _maxY && y >= 0)
        {
            if (_cache != null)
            {
                result = _cache.Lookup(x, y);
            }

            if (result == null)
            {
                result = DoCalculation(x, y);

                if (_cache != null)
                {
                    _cache.Insert(x, y, result.Value);
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Simulate an actual calculation
    /// </summary>
    private int DoCalculation(int x, int y)
    {
        Pause(CALCULATION_PAUSE_MS);
        return _generator.Next(1, MAX_VALUE);
    }

    /// <summary>
    /// Pause for the specified number of milliseconds
    /// </summary>
    private void Pause(int mSecs)
    {
        Thread.Sleep(mSecs);
    }
    #endregion
}
