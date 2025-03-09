using System;
using System.Collections.Generic;

namespace ImdbDataInsert.EFModels;

public partial class TitleGenre
{
    public string Tconst { get; set; } = null!;

    public int GenreId { get; set; }
}
