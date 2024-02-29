
/// <summary>
/// This class contains a very clever solver implementation
/// </summary>
public class BackPackingSolverSmart : BackPackingSolverBase
{
    public BackPackingSolverSmart(List<BackPackItem> items, decimal capacity)
        : base(items, capacity)
    {
    }

    public override void Solve(ItemVault theItemVault, BackPack theBackPack)
    {
        string description = PickNextItemFromVault(theItemVault, theBackPack.WeightCapacityLeft);
        if (description != string.Empty)
        {
            BackPackItem item = theItemVault.RemoveItem(description);
            theBackPack.AddItem(item);
             Solve(theItemVault, theBackPack);
        }
    }

    /// <summary>
    /// This method  returns the first item in the Vault that is lighter than
    /// the allowed weight if
    ///   1) Any items are left at all, and
    ///   2) The weight of the item does not exceed the given limit.
    /// </summary>
    /// <returns>
    /// Identifier for the next item (String.Empty if no item found)
    /// </returns>
    private string PickNextItemFromVault(ItemVault theItemVault, decimal weightLimit)
    {
        //return the next item that fits in the backpack
         foreach (var item in theItemVault.Items)
        {
            if (item.Weight <= weightLimit && theItemVault.Items.Count != 0)
            {
                return item.Description;
            }
        }

        return string.Empty;
    }
}

