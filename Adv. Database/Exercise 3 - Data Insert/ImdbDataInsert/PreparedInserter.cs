using ImdbDataInsert.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ImdbDataInsert
{
    public class PreparedInserter : IInserter
    {
        public void InsertData(SqlConnection sqlConn, List<Title> titles)
        {
            int titlesInserted = 0;

            Console.WriteLine("\nStarting prepared inserts into database...");

            // If connection from program.cs has idled out
            if (sqlConn.State == ConnectionState.Closed)
                sqlConn.Open();

            using SqlCommand cmd = new(
                "INSERT INTO Title (Tconst, TitleTypeID, PrimaryTitle, OriginalTitle, IsAdult, StartYear, EndYear, RuntimeMinutes) " +
                "VALUES (@Tconst, @TitleTypeID, @PrimaryTitle, @OriginalTitle, @IsAdult, @StartYear, @EndYear, @RuntimeMinutes)",
                sqlConn);

            cmd.Parameters.Add("@Tconst", SqlDbType.NVarChar);
            cmd.Parameters.Add("@TitleTypeID", SqlDbType.Int);
            cmd.Parameters.Add("@PrimaryTitle", SqlDbType.NVarChar);
            cmd.Parameters.Add("@OriginalTitle", SqlDbType.NVarChar);
            cmd.Parameters.Add("@IsAdult", SqlDbType.Bit);
            cmd.Parameters.Add("@StartYear", SqlDbType.SmallInt);
            cmd.Parameters.Add("@EndYear", SqlDbType.SmallInt);
            cmd.Parameters.Add("@RuntimeMinutes", SqlDbType.SmallInt);

            try
            {
                foreach (var title in titles)
                {
                    cmd.Parameters["@Tconst"].Value = title.Tconst;
                    cmd.Parameters["@TitleTypeID"].Value = title.TitleTypeID;
                    cmd.Parameters["@PrimaryTitle"].Value = title.PrimaryTitle;
                    cmd.Parameters["@OriginalTitle"].Value = title.OriginalTitle;
                    cmd.Parameters["@IsAdult"].Value = title.IsAdult;
                    cmd.Parameters["@StartYear"].Value = (object?)title.StartYear ?? DBNull.Value;
                    cmd.Parameters["@EndYear"].Value = (object?)title.EndYear ?? DBNull.Value;
                    cmd.Parameters["@RuntimeMinutes"].Value = (object?)title.RuntimeMinutes ?? DBNull.Value;

                    cmd.ExecuteNonQuery();
                    titlesInserted++;

                    if (titlesInserted % 5000 == 0)
                        Console.WriteLine($"{titlesInserted} titles inserted");
                }

                Console.WriteLine("Insertion complete.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database insert error: {ex.Message}");
            }
        }
    }
}
