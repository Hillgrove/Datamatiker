public class OrderRepository
{
    #region Properties
    public Dictionary<int, Order> Orders { get; }
    public List<Order> All
    {
        get { return Orders.Values.ToList(); }
    }
    #endregion

    #region Constructor
    public OrderRepository()
	{
        Orders = new Dictionary<int, Order>();
    }
    #endregion

    #region Methods
    public void Create(Order order)
    {
        int id = getNextID();
        Orders.Add(id, order);
        Console.WriteLine($"Ordre {id} er blevet oprettet!");
    }

    public Order Read(int id)
    {
        Order order = Orders[id];
        if (!Orders.ContainsKey(id))
        {
            Console.WriteLine($"Order med ID: {id} ikke fundet!");
            return null;
        }
        return order;
    }

    public void Update(int id, Order order)
    {
        if (!Orders.ContainsKey(id))
        {
            Console.WriteLine($"Ordre med ID: {id} ikke fundet!");
            return;
        }
        Orders[id] = order;
        Console.WriteLine($"Ordre {id} er blevet opdateret!");
    }

    public void Delete(int id)
    {
        if (!Orders.ContainsKey(id))
        {
            Console.WriteLine($"Ordre {id} ikke fundet!");
            return;
        }
        Orders.Remove(id);
        Console.WriteLine($"Ordre {id} er blevet slettet!");
    }

    public void ListCustomerOrders(Customer customer)
    {
        int orderCount = 0;

        foreach (Order order in Orders.Values)
        {
            int orderID = Orders.FirstOrDefault(x => x.Value == order).Key;

            if (order.Customer == customer)
            {
                Console.WriteLine($"Ordre ID: {orderID}. Indeholder: {order.Pizza.Name}. Total pris: {order.CalculateTotalPrice()}kr. inkl. levering.");
                orderCount++;
            }

        }

        if (orderCount == 0)
        {
            Console.WriteLine("Ingen ordrer fundet!");
        }
    }

    private int getNextID()
    {
        int total = Orders.Count;
        int nextID = total + 1;

        while (true)
        {
            if (!Orders.ContainsKey(nextID))
            {
                break;
            }
            nextID++;
        }
        return nextID;
    }
    #endregion
}
