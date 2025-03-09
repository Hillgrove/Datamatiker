using ImdbDataInsert.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ImdbDataInsert
{
    public class NormalInserter : IInserter
    {
        public void InsertData(SqlConnection sqlConn, List<Title> titles)
        {
            int titlesInserted = 0;

            Console.WriteLine("\nStarting normal inserts into database...");

            // If connection from program.cs has idled out
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();

            foreach (var title in titles)
            {
                using SqlCommand sqlComm = new SqlCommand("" +
                    "INSERT INTO Title (Tconst," +
                        "TitleTypeID," +
                        "PrimaryTitle," +
                        "OriginalTitle," +
                        "IsAdult," +"StartYear," +
                        "EndYear," +
                        "RuntimeMinutes) " +
                    "VALUES (" +
                        $"'{title.Tconst}'," +
                        $"{title.TitleTypeID}," +
                        $"'{title.PrimaryTitle.Replace("'", "''")}'," +
                        $"'{title.OriginalTitle.Replace("'", "''")}'," +
                        $"{(title.IsAdult ? "1" : "0")}," +
                        $"{(title.StartYear.HasValue ? title.StartYear : "NULL")}," +
                        $"{(title.EndYear.HasValue ? title.EndYear : "NULL")}," +
                        $"{(title.RuntimeMinutes.HasValue ? title.RuntimeMinutes : "NULL")})"
                    , sqlConn);

                try
                {
                    sqlComm.ExecuteNonQuery();
                }
                
                catch (SqlException ex)
                {
                    Console.WriteLine($"Database insert error: {ex.Message}");
                }

                titlesInserted++;

                if (titlesInserted % 5000 == 0)
                    Console.WriteLine($"{titlesInserted} titles inserted");
            }

            Console.WriteLine("Insertion complete.");
        }
    }
}
