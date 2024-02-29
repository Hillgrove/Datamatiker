public class PizzaRepository
{
    #region Properties
    public Dictionary<int, Pizza> Pizzas { get; }
    public List<Pizza> All
    { 
        get { return Pizzas.Values.ToList(); } 
    }
    #endregion

    #region Constructor
    public PizzaRepository()
    {
        Pizzas = new Dictionary<int, Pizza>();
    }
    #endregion

    #region Methods
    public void Create(Pizza pizza)
    {
        foreach (Pizza p in Pizzas.Values)
        {
            if (p.Name == pizza.Name)
            {
                Console.WriteLine($"Pizza med navn: {pizza.Name} er allerede i brug!");
                return;
            }
        }
        int id = getNextID();
        Pizzas.Add(id, pizza);
        Console.WriteLine($"Pizza: {pizza.Name} er blevet oprettet!");
    }

    public void Read(int id)
    {
        Pizza order = Pizzas[id];
        if (!Pizzas.ContainsKey(id))
        {
            Console.WriteLine($"Pizza med ID: {id} ikke fundet!");
            return;
        }

        Console.WriteLine(Pizzas[id]);
    }

    public void Update(Pizza pizza)
    {
        if (!All.Contains(pizza))
        {
            Console.WriteLine($"Pizza: {pizza.Name} ikke fundet!");
            return;
        }

        foreach (var p in Pizzas)
        {
            if (p.Value.Name == pizza.Name)
            {
                Pizzas[p.Key] = pizza;
                Console.WriteLine($"Pizza: {pizza.Name} er blevet opdateret!");
            }
        }
    }

    public void addTopping(string pizzaName, string newTopping)
    {
        foreach (Pizza pizza in Pizzas.Values)
        {
            if (pizza.Name == pizzaName)
            {
                if (pizza.Toppings.Contains(newTopping))
                {
                    Console.WriteLine($"Topping: {newTopping} findes allerede på {pizzaName}");
                    return;
                }
                pizza.Toppings.Add(newTopping);
                Console.WriteLine($"Topping: {newTopping} er blevet tilføjet til {pizzaName}");
                return;
            }
        }

        throw new KeyNotFoundException($"Ingen pizza fundet med navn {pizzaName}.");
    }

    public void removeTopping(string pizzaName, string toppingName)
    {
        foreach (Pizza pizza in Pizzas.Values)
        {
            if (pizza.Name == pizzaName)
            {
                if (!pizza.Toppings.Contains(toppingName))
                {
                    Console.WriteLine($"Topping: {toppingName} findes ikke på {pizzaName}");
                    return;
                }
                pizza.Toppings.Remove(toppingName);
                Console.WriteLine($"Topping: {toppingName} er blevet fjenet fra {pizzaName}");
                return;
            }
        }
    }

    public void Delete(int id)
    {
        Pizza pizza = Pizzas[id];

        if (!Pizzas.ContainsKey(id))
        {
            Console.WriteLine($"Pizza med ID: {id} ikke fundet!");
            return;
        }
        Pizzas.Remove(id);
        Console.WriteLine($"Pizza: {pizza.Name} er blevet slettet!");
    }

    public List<Pizza> Search(string name)
    {
        List<Pizza> pizzas = new List<Pizza>();

        foreach (Pizza pizza in Pizzas.Values)
        {
            if (pizza.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            {
                pizzas.Add(pizza);
            }
        }
        return pizzas;
    }

    private int getNextID()
    {
        int total = Pizzas.Count;
        int nextID = total + 1;

        while (true)
        {
            if (!Pizzas.ContainsKey(nextID))
            {
                break;
            }
            nextID++;
        }
        return nextID;
    }
    #endregion
}
