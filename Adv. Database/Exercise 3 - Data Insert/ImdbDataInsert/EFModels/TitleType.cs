using System;
using System.Collections.Generic;

namespace ImdbDataInsert.EFModels;

public partial class TitleType
{
    public int TitleTypeId { get; set; }

    public string Name { get; set; } = null!;
}
