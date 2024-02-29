
// By: Jesper Højlund

using System.Text.Json;
using ByGuide.Models;

namespace ByGuide.Service
{
    public class JsonFileExperienceService
    {
        #region Constructor
        public JsonFileExperienceService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region Properties
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName
        {
            get
            {
                return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Experiences.json");
            }
        }
        #endregion

        #region Methods
        public void SaveJsonExperiences(List<Experience> experiences)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true,
                });
                JsonSerializer.Serialize<Experience[]>(jsonWriter, experiences.ToArray());
            }
        }

        public IEnumerable<Experience> GetJsonExperiences()
        {
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Experience[]>(jsonFileReader.ReadToEnd());
            }
        }
        #endregion
    }
}
