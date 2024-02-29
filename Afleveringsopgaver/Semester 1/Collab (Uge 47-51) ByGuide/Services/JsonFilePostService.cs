
// By: Jesper Højlund

using System.Text.Json;
using ByGuide.Models;

namespace ByGuide.Service
{
    public class JsonFilePostService
    {
        #region Constructor
        public JsonFilePostService(IWebHostEnvironment webHostEnvironment)
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
                return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Posts.json");
            }
        }
        #endregion

        #region Methods
        public void SaveJsonPosts(List<Post> posts)
        {
            using (FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true,
                });
                JsonSerializer.Serialize<Post[]>(jsonWriter, posts.ToArray());
            }
        }

        public IEnumerable<Post> GetJsonPosts()
        {
            using (StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<Post[]>(jsonFileReader.ReadToEnd());
            }
        }
        #endregion
    }
}
