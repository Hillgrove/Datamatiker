public class Menu
{
    #region Properties
    public List<Pizza> Items { get; }
    #endregion

    #region Constructor
    public Menu()
    {
        Items = new List<Pizza>();
    }
    #endregion

    #region Methods
    public void Add(Pizza pizza)
    {
        if (Items.Contains(pizza))
        {
            Console.WriteLine($"Menu: {pizza.Name} findes allerede!");
            return;
        }

        Items.Add(pizza);
        Console.WriteLine($"Menu: {pizza.Name} er blevet tilføjet!");
    }

    public void Remove(int id)
    {
        if (id < 0 || id >= Items.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Index is out of range.");
        }
        Pizza pizza = Items[id];
        Items.RemoveAt(id);
        Console.WriteLine($"Menu: {pizza.Name} er blevet fjernet!");
    }

    public void Update(Pizza pizza)
    {
        if (!Items.Contains(pizza))
        {
            Console.WriteLine($"Menu: {pizza.Name} ikke fundet!");
            return;
        }

        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i] == pizza )
            {
                Items[i] = pizza;
                break;
            }
        }

        Console.WriteLine($"Menu: {pizza.Name} er blevet opdateret!");
    }

    public void PrintMenu()
    {
        Console.WriteLine("Big Mamma's Pizzaria Menu:");
        Console.WriteLine("-----");
        for (int i = 0; i < Items.Count; i++)
        {
            Console.WriteLine($"Nr. {i + 1}: {Items[i]}");
        }
    }
    #endregion
}