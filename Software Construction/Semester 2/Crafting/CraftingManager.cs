
public class CraftingManager
{
    public bool IsCraftable(Player player, Recipe recipe)
    {
        return player.CanCraft(recipe);
    }

    public void CraftRecipe(Recipe recipe)
    {
        // TODO
        throw new NotImplementedException();
    }
}
