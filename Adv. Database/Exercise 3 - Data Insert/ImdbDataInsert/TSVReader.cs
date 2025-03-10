﻿using ImdbDataInsert.Models;

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

                if (++linesRead % 10000 == 0) Console.WriteLine($"\r{linesRead} Lines processed");
                if (linesRead >= linesToRead) break;
            }

            Console.WriteLine("All lines processed");
            return titles;
        }

        private static void ExtractTitleTypes(Dictionary<string, int> titleTypes, string[] fields)
        {
            if (!titleTypes.ContainsKey(fields[1]))
            {
                titleTypes[fields[1]] = titleTypes.Count + 1; // Add one as MSSQL is 1-based indexing)
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
    }
}
