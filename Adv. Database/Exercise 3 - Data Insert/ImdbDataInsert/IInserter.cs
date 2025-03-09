using ImdbDataInsert.Models;
using Microsoft.Data.SqlClient;

namespace ImdbDataInsert
{
    public interface IInserter
    {
        void InsertData(SqlConnection sqlcConn, List<Title> titles);
    }
}
