public class CustomerRepository
{
    #region Properties
    public Dictionary<int, Customer> Customers { get; }
    public List<Customer> All
    {
        get { return Customers.Values.ToList(); }
    }
    #endregion

    #region Constructor
    public CustomerRepository()
    {
        Customers = new Dictionary<int, Customer>();
    }
    #endregion

    #region Methods
    public void Create(Customer customer)
    {
        foreach (Customer c in Customers.Values)
        {
            if (c.Email == customer.Email)
            {
                Console.WriteLine($"Email: {customer.Email} er allerede i brug!");
                return;
            }
        }

        int id = getNextID();
        Customers.Add(id, customer);
        Console.WriteLine($"Kunde: {customer.Name} er blevet oprettet!");
    }

    public void Read(int id)
    {
        if (!Customers.ContainsKey(id))
        {
            Console.WriteLine($"Kunde med ID: {id} ikke fundet!");
            return;
        }
        Console.WriteLine(Customers[id]);
    }

    public void Update(Customer oldCustomerObject, Customer newCustomerObject)
    {
        if (!Customers.Values.Contains(oldCustomerObject))
        {
            Console.WriteLine($"Kunde: {oldCustomerObject.Name} ikke fundet!");
            return;
        }
        foreach (var c in Customers)
        {
            if (c.Value == oldCustomerObject)
            {
                Customers[c.Key] = newCustomerObject;
            }
        }
        Console.WriteLine($"Kunde: {newCustomerObject.Name} er blevet opdateret!");
    }

    public void Delete(int id)
    {
        if (!Customers.ContainsKey(id)) {
            Console.WriteLine($"Kunde med ID: {id} ikke fundet!");
            return;
        }
        Customers.Remove(id);
        Console.WriteLine($"Kunde med ID: {id} er blevet slettet!");
    }

    public List<Customer> Search(string name)
    {
        List<Customer> customers = new List<Customer>();
        foreach (Customer customer in Customers.Values)
        {
            if (customer.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
            {
                customers.Add(customer);
            }
        }
        return customers;
    }

    private int getNextID()
    {
        int total = Customers.Count;
        int nextID = total + 1;

        while (true)
        {
            if (!Customers.ContainsKey(nextID))
            {
                break;
            }
            nextID++;
        }
        return nextID;
    }
    #endregion
}
