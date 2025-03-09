using ImdbDataInsert.Models;

namespace ImdbDataInsert
{
    public interface IInserter
    {
        void InsertData(List<Title> titles);
    }
}
