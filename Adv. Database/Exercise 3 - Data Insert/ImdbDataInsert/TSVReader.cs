using ImdbDataInsert.Models;

namespace ImdbDataInsert
{
    public static class TSVReader
    {
        public static List<Title> ReadFromFile(string filepath, int linesToRead)
        {
            var linesRead = 0;

            var titles = new List<Title>();
            var genres = new Dictionary<string, int>();
            var titleTypes = new Dictionary<string, int>();
            var titleGenres = new Dictionary<string, HashSet<int>>();

            Console.WriteLine("Reading Lines from TSV file...");

            foreach (string line in File.ReadLines(filepath).Skip(1).Take(linesToRead))
            {
                /* 
                 * Sample data
                 * tconst       titleType   primaryTitle            originalTitle   isAdult     startYear   endYear     runtimeMinutes      genres
                 * tt0000001    short       Carmencita              Carmencita      0           1894        \N          1                   Documentary,Short
                 * tt0000019    short       The Clown BarberThe     Clown Barber	0	        1898	    \N	        \N                  Comedy,Short
                 */
                
                linesRead++;
                string[] fields = line.Split("\t");
                
                if (fields.Length != 9)
                {
                    Console.WriteLine($"The line does not have 9 columns: {linesRead}");
                }

                ExtractTitleType(titleTypes, fields);
                ExtractTitle(titles, titleTypes, fields);
                ExtractGenre(genres, titleGenres, fields);

                if (linesRead % 10000 == 0) Console.WriteLine($"\r{linesRead} Lines processed");
                if (linesRead >= linesToRead) break;
            }

            Console.WriteLine("All lines processed");
            return titles;
        }

        private static void ExtractTitleType(Dictionary<string, int> titleTypes, string[] fields)
        {
            if (!titleTypes.ContainsKey(fields[1]))
            {
                titleTypes[fields[1]] = titleTypes.Count + 1; // Add one as MSSQL is 1-based indexing)
            }
        }

        private static void ExtractTitle(List<Title> titles, Dictionary<string, int> titleTypes, string[] fields)
        {
            // extract title
            titles.Add(new Title
            {
                Tconst = fields[0],
                TitleTypeID = titleTypes[fields[1]],
                PrimaryTitle = fields[2],
                OriginalTitle = fields[3],
                IsAdult = CheckBit(fields[4], fields[0], "IsAdult"),
                StartYear = CheckNumber<short>(fields[5], fields[0], "StartYear"),
                EndYear = CheckNumber<short>(fields[6], fields[0], "EndYear"),
                RuntimeMinutes = CheckNumber<int>(fields[7], fields[0], "RuntimeMinutes")
            });
        }

        private static void ExtractGenre(Dictionary<string, int> genres, Dictionary<string, HashSet<int>> titleGenres, string[] fields)
        {
            // extract genre and titlegenres
            var genreFields = fields[8].Split(",");
            foreach (string genre in genreFields)
            {
                int genreID;
                if (!genres.TryGetValue(genre, out int genreValue))
                {
                    genreID = genres.Count + 1; // Add one as MSSQL is 1-based indexing)
                    genres[genre] = genreID;
                }
                else
                {
                    genreID = genreValue;
                }

                if (!titleGenres.TryGetValue(fields[0], out HashSet<int>? titleValue))
                {
                    titleValue = new HashSet<int>();
                    titleGenres[fields[0]] = titleValue;
                }

                titleValue.Add(genreID);
            }
        }

        private static bool CheckBit(string value, string tConst, string columnName)
        {
            if (value == "1") return true;
            if (value == "0") return false;

            Console.WriteLine($"Warning: {tConst} has an invalid value for '{columnName}': '{value}. Using false as fallback.'");
            return false;
        }

        private static T? CheckNumber<T>(string value, string tConst, string columnName) where T : struct
        {
            if (value == @"\N") return null;
            if (typeof(T) == typeof(short) && short.TryParse(value, out short shortResult)) return (T)(object)shortResult;
            if (typeof(T) == typeof(int) && int.TryParse(value, out int intResult)) return (T)(object)intResult;

            Console.WriteLine($"Warning: {tConst} has an invalid value for '{columnName}': '{value}. Using -1 as fallback.'");
            return (T)(object)-1;
        }

    }
}
