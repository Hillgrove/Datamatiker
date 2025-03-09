using ImdbDataInsert.EFModels;
using ImdbDataInsert.Models;
using Microsoft.Data.SqlClient;

namespace ImdbDataInsert
{
    public class EfCoreInserter : IInserter
    {
        public void InsertData(SqlConnection sqlConn, List<Models.Title> titles)
        {
            // sqlConn not needed for EFCore, but it's part of the interface
            Console.WriteLine("\nStarting EF Core inserts into database...");

            using var context = new ImdbBasicsContext();

            // Convert List<Title> (from Models) to EFModels.Title (from EF Core)
            // Only doing this because I didn't want the scaffolding to overwrite my manually made models in Models folder.
            var efTitles = titles.Select(title => new EFModels.Title
            {
                Tconst = title.Tconst,
                TitleTypeId = title.TitleTypeID,
                PrimaryTitle = title.PrimaryTitle,
                OriginalTitle = title.OriginalTitle,
                IsAdult = title.IsAdult,
                StartYear = title.StartYear,
                EndYear = title.EndYear,
                RuntimeMinutes = title.RuntimeMinutes
            }).ToList();

            int titlesInserted = 0;
            int batchSize = 5000;

            try
            {
                for (int i = 0; i < efTitles.Count; i += batchSize)
                {
                    var batch = efTitles.Skip(i).Take(batchSize).ToList();
                    context.Titles.AddRange(batch);
                    context.SaveChanges();
                    titlesInserted += batch.Count;

                    Console.WriteLine($"{titlesInserted} titles inserted");
                }

                Console.WriteLine("Insertion complete.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"EF Core insert error: {ex.Message}");
            }
        }
    }
}
