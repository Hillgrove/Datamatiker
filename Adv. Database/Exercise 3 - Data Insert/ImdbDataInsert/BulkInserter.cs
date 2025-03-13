using ImdbDataInsert.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ImdbDataInsert
{
    public class BulkInserter : IInserter
    {
        public void InsertData(SqlConnection sqlcConn, List<Title> titles)
        {
            DataTable titleTable = new DataTable("Title");
            titleTable.Columns.Add("Tconst", typeof(string)).AllowDBNull = false;
            titleTable.Columns.Add("TitleTypeID", typeof(int)).AllowDBNull = false;
            titleTable.Columns.Add("PrimaryTitle", typeof(string)).AllowDBNull = false;
            titleTable.Columns.Add("OriginalTitle", typeof(string)).AllowDBNull = false;
            titleTable.Columns.Add("IsAdult", typeof(bool)).AllowDBNull = false;
            
            titleTable.Columns.Add("StartYear", typeof(short)).AllowDBNull = true;
            titleTable.Columns.Add("EndYear", typeof(short)).AllowDBNull = true;
            titleTable.Columns.Add("RuntimeMinutes", typeof(int)).AllowDBNull = true;

            foreach (var title in titles)
            {
                titleTable.Rows.Add(
                    title.Tconst,
                    title.TitleTypeID,
                    title.PrimaryTitle,
                    title.OriginalTitle,
                    title.IsAdult,
                    title.StartYear == null ? DBNull.Value : title.StartYear,
                    title.EndYear == null ? DBNull.Value : title.EndYear,
                    title.RuntimeMinutes == null ? DBNull.Value : title.RuntimeMinutes
                );
            }

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlcConn, SqlBulkCopyOptions.KeepNulls, null))
            {
                bulkCopy.DestinationTableName = "Title";

                bulkCopy.ColumnMappings.Add("Tconst", "Tconst");
                bulkCopy.ColumnMappings.Add("TitleTypeID", "TitleTypeID");
                bulkCopy.ColumnMappings.Add("PrimaryTitle", "PrimaryTitle");
                bulkCopy.ColumnMappings.Add("OriginalTitle", "OriginalTitle");
                bulkCopy.ColumnMappings.Add("IsAdult", "IsAdult");
                bulkCopy.ColumnMappings.Add("StartYear", "StartYear");
                bulkCopy.ColumnMappings.Add("EndYear", "EndYear");
                bulkCopy.ColumnMappings.Add("RuntimeMinutes", "RuntimeMinutes");

                bulkCopy.WriteToServer(titleTable);
            }
        }
    }
}
