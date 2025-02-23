using IMDBInsertApproaches.Models;
using Microsoft.Data.SqlClient;

namespace IMDBInsertApproaches
{
    public class NormalInserter
    {
        public static void InsertData(List<Title> titles)
        {
            int titlesInserted = 0;

            SqlConnection connection = new SqlConnection(
                "Server=Hilldesk;" +
                "Database=ImdbBasics;" +
                "Integrated Security=True;" +
                "TrustServerCertificate=True;");

            connection.Open();

            Console.WriteLine("Connection opened");

            foreach (var title in titles)
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Title (Tconst, TitleTypeID, PrimaryTitle, OriginalTitle, IsAdult, StartYear, EndYear, RuntimeMinutes) " +
                    "VALUES (@Tconst, @TitleTypeID, @PrimaryTitle, @OriginalTitle, @IsAdult, @StartYear, @EndYear, @RuntimeMinutes)",
                    connection);

                cmd.Parameters.AddWithValue("@Tconst", title.Tconst);
                cmd.Parameters.AddWithValue("@TitleTypeID", title.TitleTypeID);
                cmd.Parameters.AddWithValue("@PrimaryTitle", title.PrimaryTitle);
                cmd.Parameters.AddWithValue("@OriginalTitle", title.OriginalTitle);
                cmd.Parameters.AddWithValue("@IsAdult", title.IsAdult);
                cmd.Parameters.AddWithValue("@StartYear", (object?)title.StartYear ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EndYear", (object?)title.EndYear ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@RuntimeMinutes", (object?)title.RuntimeMinutes ?? DBNull.Value);

                cmd.ExecuteNonQuery();

                titlesInserted++;
                if (titlesInserted % 5000 == 0)
                {
                    Console.WriteLine($"{titlesInserted} titles inserted to database.");
                }
            }

            connection.Close();

            Console.WriteLine("Connection Closed");
        }
    }
}
