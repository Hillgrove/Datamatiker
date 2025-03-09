using System;
using System.Collections.Generic;

namespace ImdbDataInsert.EFModels;

public partial class Genre
{
    public int GenreId { get; set; }

    public string Name { get; set; } = null!;
}
