using IMDBInsertApproaches.Models;

namespace IMDBInsertApproaches
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

            foreach (string line in File.ReadLines(filepath).Skip(1))
            {
                /* 
                 * Sample data
                 * tconst       titleType   primaryTitle            originalTitle   isAdult     startYear   endYear     runtimeMinutes      genres
                 * tt0000001    short       Carmencita              Carmencita      0           1894        \N          1                   Documentary,Short
                 * tt0000019    short       The Clown BarberThe     Clown Barber	0	        1898	    \N	        \N                  Comedy,Short
                 */

                string[] fields = line.Split("\t");

                ExtractTitleTypes(titleTypes, fields);
                ExtractTitles(titles, titleTypes, fields);
                ExtractGenres(genres, titleGenres, fields);

                if (++linesRead % 10000 == 0) Console.WriteLine($"{linesRead} Lines processed.");
                if (linesRead >= linesToRead) break;
            }

            return titles;
        }

        private static void ExtractTitleTypes(Dictionary<string, int> titleTypes, string[] fields)
        {
            if (!titleTypes.ContainsKey(fields[1]))
            {
                titleTypes[fields[1]] = titleTypes.Count;
            }
        }

        private static void ExtractTitles(List<Title> titles, Dictionary<string, int> titleTypes, string[] fields)
        {
            // extract title
            titles.Add(new Title
            {
                Tconst = fields[0],
                TitleTypeID = titleTypes[fields[1]],
                PrimaryTitle = fields[2],
                OriginalTitle = fields[3],
                IsAdult = fields[4] == "1",
                StartYear = fields[5] == @"\N" ? null : short.Parse(fields[5]),
                EndYear = fields[6] == @"\N" ? null : short.Parse(fields[6]),
                RuntimeMinutes = fields[7] == @"\N" ? null : short.Parse(fields[7])
            });
        }

        private static void ExtractGenres(Dictionary<string, int> genres, Dictionary<string, HashSet<int>> titleGenres, string[] fields)
        {
            // extract genre and titlegenres
            var genreFields = fields[8].Split(",");
            foreach (string genre in genreFields)
            {
                int genreID;
                if (!genres.ContainsKey(genre))
                {
                    genreID = genres.Count;
                    genres[genre] = genreID;
                }
                else
                {
                    genreID = genres[genre];
                }

                if (!titleGenres.ContainsKey(fields[0]))
                {
                    titleGenres[fields[0]] = new HashSet<int>();
                }

                titleGenres[fields[0]].Add(genreID);
            }
        }
    }
}
