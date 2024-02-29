
// By: Jesper Højlund

/// <summary>
/// Helper class to convert the openingshours from the razor view, into a dict so it follows the model class.
/// </summary>


namespace ByGuide.Helpers
{ 
    public static class OpeningHoursHelper
    {
        #region Methods
        public static Dictionary<string, string> ParseFromForm(IFormCollection form)
        {
            var openingHours = new Dictionary<string, string>();
            foreach (var day in new[] { "Mandag", "Tirsdag", "Onsdag", "Torsdag", "Fredag", "Lørdag", "Søndag" })
            {
                string? hours = form["OpeningHours[" + day + "]"];
                if (!string.IsNullOrEmpty(hours))
                {
                    openingHours.Add(day, hours);
                }
            }
            return openingHours;
        }
        #endregion
    }
}
