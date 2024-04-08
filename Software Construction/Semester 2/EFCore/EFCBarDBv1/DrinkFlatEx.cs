

namespace EFCBarDBv1
{
    public partial class DrinkFlat
    {
        public override string ToString()
        {
            return $"{Id}: {Name}. Alcohol: {AlcoholicPart} - {AlcoholicPartAmount} cl. " +
                $"Non-Alcohol: {NonAlcoholicPart} - {NonAlcoholicPartAmount} cl";
        }
    }
}
