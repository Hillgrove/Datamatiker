﻿

namespace EFCBarDBv1
{
    public partial class DrinkFlat
    {
        public override string ToString()
        {
            return $"{Id}: {Name} - {AlcoholicPart} ({AlcoholicPartAmount} cl) " +
                $"{NonAlcoholicPart} ({NonAlcoholicPartAmount} cl)";
        }
    }
}
