

public class Recipe
{
    private Dictionary<Resource, int> _requiredResources;
    public string Name { get; }

    public Recipe(string name, params (Resource resource, int amount)[] resources)
    {
        Validator.ValidateName(name);
        ValidateResources(resources);

        Name = name.Trim().ToTitleCase();
        _requiredResources = resources.ToDictionary(pair => pair.resource, pair => pair.amount);
    }

    public bool IsCraftable(Inventory inventory)
    {
        foreach (var (resource,  requiredAmount) in _requiredResources)
        {
            if (!inventory.HasResource(resource, requiredAmount))
            {
                return false;
            }
        }

        return true;
    }

    #region Validation Methods
    private static void ValidateResources(params (Resource resource, int amount)[] resources)
    {
        ValidateResourceParameters(resources);
        ValidateDuplicateResources(resources);
    }

    private static void ValidateResourceParameters(params (Resource resource, int amount)[] resources)
    {
        foreach (var (resource, amount) in resources)
        {
            if (amount <= 0)
            {
                throw new ArgumentException($"Invalid amount '{amount}' for resource '{resource.Name}'. Amount must be positive", nameof(amount));
            }
        }
    }

    private static void ValidateDuplicateResources(params (Resource resource, int amount)[] resources)
    {
        var duplicateResources = resources
            .GroupBy(tuple => tuple.resource)
            .Where(group => group.Count() > 1)
            .Select(group => group.Key);

        if (duplicateResources.Any())
        {
            var duplicatedResourceNames = string.Join(", ", duplicateResources.Select(resource => resource.Name));
            throw new ArgumentException($"Duplicate resources found: {duplicatedResourceNames}. " +
                $"A resource can only be listed once in a recipe.", nameof(resources));
        }
    }
    #endregion
}

