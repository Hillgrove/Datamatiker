
// By: jesper Højlund

/// <summary>
/// A helper class to return the next unique ID in a list of lists.
/// </summary>

using ByGuide.Models;

namespace ByGuide.Helpers
{
    public static class UniqueIdGenerator
    {
        public static int Next<T>(List<T> items) where T : IContent
        {
            int maxId = 0;
            foreach (var item in items)
            {
                if (item.Id.HasValue && item.Id.Value > maxId)
                {
                    maxId = item.Id.Value;
                }
            }
            return maxId + 1;
        }
    }
}
