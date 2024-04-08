﻿
public partial class Ingredient : IHasId
{
    public override string ToString()
    {
        return $"[{Id,2}]  {Name} ({AlcoholPercent:F02} %, costs {PricePerCl} kr. per cl.) ({DrinkAlcoholicParts.Count} / {DrinkNonAlcoholicParts.Count})";
    }
}
