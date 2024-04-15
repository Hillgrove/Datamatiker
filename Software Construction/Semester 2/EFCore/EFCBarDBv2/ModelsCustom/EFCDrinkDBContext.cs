
namespace EFCBarDBv2.ModelsGenerated
{
    public partial class EFCDrinkDBContext
    {
        public Ingredient? GetIngredientByName(string name)
        {
            return Ingredients.FirstOrDefault(i => i.Name == name);
        }
    }
}
