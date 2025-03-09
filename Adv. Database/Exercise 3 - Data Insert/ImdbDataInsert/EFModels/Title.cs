using System;
using System.Collections.Generic;

namespace ImdbDataInsert.EFModels;

public partial class Title
{
    public string Tconst { get; set; } = null!;

    public int TitleTypeId { get; set; }

    public string PrimaryTitle { get; set; } = null!;

    public string OriginalTitle { get; set; } = null!;

    public bool IsAdult { get; set; }

    public short? StartYear { get; set; }

    public short? EndYear { get; set; }

    public int? RuntimeMinutes { get; set; }
}
