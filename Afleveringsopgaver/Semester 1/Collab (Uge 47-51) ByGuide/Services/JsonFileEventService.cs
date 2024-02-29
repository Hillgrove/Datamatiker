using ByGuide.Models;
using System.Text.Json;

namespace ByGuide.Services
{
    public class JsonFileEventService
    {
        #region Constructor
        public JsonFileEventService(IWebHostEnvironment webHostEnvironment)
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
                return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Event.json");
            }
        }
        #endregion

        #region Methods
        public void SaveJsonEvent(List<Event> events)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true,
                });
                JsonSerializer.Serialize<Event[]>(jsonWriter, events.ToArray());
            }
        }

        public IEnumerable<Event> GetJsonEvents()
        {
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Event[]>(jsonFileReader.ReadToEnd());
            }
        }
        #endregion
    }
}