using System.Linq;

public class PizzaStoreUI
{
    #region Properties
    private string? User { get; set;}
    private Menu? Menu { get; }
    private PizzaRepository? Pizzas { get; }
    private CustomerRepository? Customers { get; }
    private OrderRepository? Orders { get; }
    #endregion

    #region Constructor
    public PizzaStoreUI()
	{
        User = null;
        Menu = new Menu();
        Pizzas = new PizzaRepository();
        Customers = new CustomerRepository();
        Orders = new OrderRepository();
    }
    #endregion

    #region Methods
    public void RunUI()
	{
        // Test data creation

        Pizzas.Create(new Pizza("Oriental", new List<string> { "Tomat", "Ost", "Pepperoni", "Chili" }, 80));
        Pizzas.Create(new Pizza("Vesuvio", new List<string> { "Tomat", "Ost", "Skinke" }, 70));
        Pizzas.Create(new Pizza("Hawaii", new List<string> { "Tomat", "Ost", "Skinke" }, 60));

        Customers.Create(new Customer("Jonas", "2700 Islev", "42680021", "jonas@gmail.com", "12233"));
        Customers.Create(new Customer("Markus", "2300 CPH", "42556677", "Markus@gmail.com", "43022"));
        Customers.Create(new Customer("Maria", "2100 CPH", "43556241", "Maria@Outlook.com", "22443"));

        Orders.Create(new Order(Customers.All[1], Pizzas.All[1]));
        Orders.Create(new Order(Customers.All[2], Pizzas.All[2]));
        Orders.Create(new Order(Customers.All[2], Pizzas.All[2]));

        Menu.Add(Pizzas.All[0]);
        Menu.Add(Pizzas.All[1]);
        Menu.Add(Pizzas.All[2]);

        // End of test data creation

        Console.Clear();

        while (true) { 
            if(User == null)
            {
                Options();
            }
        }
    }

    private void Options()
    {
        Console.WriteLine("------- Velkommen til PizzaStore -------");
        Console.WriteLine("");
        Console.WriteLine("Venligst log ind som admin eller kunde");
        Console.WriteLine("-----");
        Console.WriteLine("·  a = Admin");
        Console.WriteLine("·  k = Kunde");
        Console.WriteLine("-----");
        Console.WriteLine("·  q = Afslut");
        Console.WriteLine("");

        string? option;

        while (true)
        {
            Console.Write("Indtast mulighed: ");
            option = Console.ReadLine();

            if (option == "a" || option == "k" || option == "q")
            {
                break;
            }
            else
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Vælg venligst en gyldig mulighed!");
            }
        }

        if(option == "a")
        {
            User = "Admin";
            Console.Clear();
            AdminOptions();
        }
        if(option == "k")
        {
            User = "Customer";
            Console.Clear();
            CustomerOptions();
        }
        if (option == "q")
        {
            Environment.Exit(0);
        }
    }

    #region Admin view
    private void AdminOptions()
    {
        Console.WriteLine("PizzaStore - Admin");
        Console.WriteLine("");
        Console.WriteLine("Vælg venligst en mulighed nedenfor");
        Console.WriteLine("-----");
        Console.WriteLine("·  p = Pizza muligheder");
        Console.WriteLine("·  m = Menu muligheder");
        Console.WriteLine("·  k = Kunde muligheder");
        Console.WriteLine("-----");
        Console.WriteLine("·  l = Log ud");
        Console.WriteLine("·  q = Afslut");
        Console.WriteLine("");

        string? option;

        while (true)
        {
            Console.Write("Indtast mulighed: ");
            option = Console.ReadLine();

            if (option == "p" || option == "m" || option == "k" || option == "l" || option == "q")
            {
                break;
            }
            else
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Vælg venligst en gyldig mulighed!");
            }
        }

        if (option == "p")
        {
            Console.Clear();
            AdminPizzaOptions();
        }
        if (option == "m")
        {
            Console.Clear();
            AdminMenuOptions();
        }
        if (option == "k")
        {
            Console.Clear();
            AdminCustomerOptions();
        }
        if (option == "l")
        {
            Console.Clear();
            User = null;
        }
        if (option == "q")
        {
            Environment.Exit(0);
        }
    }

    #region Pizza management
    private void AdminPizzaOptions()
    {
        Console.WriteLine("PizzaStore - Admin · Pizza");
        Console.WriteLine("");
        Console.WriteLine("Vælg venligst en mulighed nedenfor");
        Console.WriteLine("-----");
        Console.WriteLine("·  t = Opret Pizza");
        Console.WriteLine("·  o = Opdater Pizza");
        Console.WriteLine("·  f = Slet Pizza");
        Console.WriteLine("·  s = Søg Pizza ved navn");
        Console.WriteLine("-----");
        Console.WriteLine("·  b = Tilbage");
        Console.WriteLine("");

        string? option;

        while (true)
        {
            Console.Write("Indtast mulighed: ");
            option = Console.ReadLine();

            if (option == "t" || option == "o" || option == "f" || option == "s" || option == "b")
            {
                break;
            }
            else
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Vælg venligst en gyldig mulighed!");
            }
        }

        if (option == "t")
        {
            Console.Clear();
            CreatePizza();
        }
        if (option == "o")
        {
            Console.Clear();
            UpdatePizza();
        }
        if (option == "f")
        {
            Console.Clear();
            DeletePizza();
        }
        if (option == "s")
        {
            Console.Clear();
            SearchPizza();
        }
        if (option == "b")
        {
            Console.Clear();
            AdminOptions();
        }
    }

    private void CreatePizza()
    {
        Console.WriteLine($"PizzaStore - Admin · Pizza · Opret");
        Console.WriteLine("");

        List<string> toppings = new List<string>();

        Console.Write("Indtast navn: ");
        string? name = Console.ReadLine();
        Console.WriteLine("");

        Console.Write("Toppings (c = Continue)");
        Console.WriteLine("");

        string? topping;

        int toppingNumber = 1;

        while (true)
        {
            Console.Write($"Topping {toppingNumber}: ");
            topping = Console.ReadLine();

            if (topping == "c")
            {
                break;
            }

            if (topping == null)
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Feltet må ikke være tomt!");
            }
            else
            {
                Console.WriteLine("-----");
                toppings.Add(topping);
                toppingNumber++;
            }
        }

        Console.WriteLine("");
        Console.Write("Indtast pris: ");
        int price = Convert.ToInt32(Console.ReadLine());

        Pizza pizza = new Pizza(name, toppings, price);

        Console.WriteLine("");
        Console.WriteLine("-----");
        Pizzas.Create(pizza);

        GoBack(AdminPizzaOptions);
    }

    private void UpdatePizza()
    {
        Console.WriteLine("PizzaStore - Admin · Pizza · Opdater");
        Console.WriteLine("");
        Console.WriteLine("Vælg venligst et nummer til at opdatere nedenfor");
        Console.WriteLine("");

        Console.WriteLine("-----");
        for (int i = 0; i < Pizzas.All.Count; i++)
        {
            Console.WriteLine($"Nr.: {i + 1}, Pizza: {Pizzas.All[i]}");
        }
        Console.WriteLine("");

        int option;

        while (true)
        {
            Console.Write("Indtast Nr.: ");
            option = Convert.ToInt32(Console.ReadLine()) - 1; // index starts at 0
            Console.WriteLine("");

            if (option <= Pizzas.All.Count - 1 && option >= 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Vælg venligst et gyldigt nummer!");
            }
        }

        Console.Clear();
        Console.WriteLine($"PizzaStore - Admin · Pizza · Opdater · {Pizzas.All[option].Name}");
        Console.WriteLine("");
        Console.WriteLine("Vælg venligst hvad du vil opdatere nedenfor");
        Console.WriteLine("-----");
        Console.WriteLine("·  t = Tilføj Topping");
        Console.WriteLine("·  f = Fjern Topping");
        Console.WriteLine("·  p = Opdater Pris");
        Console.WriteLine("-----");
        Console.WriteLine("·  b = Tilbage");
        Console.WriteLine("");

        Pizza pizza = Pizzas.All[option];

        string? optionUpdate;

        while (true)
        {
            Console.Write("Indtast mulighed: ");
            optionUpdate = Console.ReadLine();

            if (optionUpdate == "t" || optionUpdate == "f" || optionUpdate == "p" || optionUpdate == "b")
            {
                break;
            }
            else
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Vælg venligst en gyldig mulighed!");
            }
        }
        Console.WriteLine("");

        if (optionUpdate == "t")
        {
            Console.Write("Indtast ny topping: ");
            string? newTopping = Console.ReadLine();
            Console.WriteLine("");

            if (newTopping == null)
            {
                throw new ArgumentNullException(nameof(newTopping));
            }
            else
            {
                Pizzas.addTopping(pizza.Name, newTopping);
            }
        }
        if (optionUpdate == "f")
        {
            Console.WriteLine("Vælg venligst et nummer til at fjerne nedenfor");
            Console.WriteLine("-----");
            for (int i = 0; i < pizza.Toppings.Count; i++)
            {
                Console.WriteLine($"·  Nr.: {i + 1}, Topping: {pizza.Toppings[i]}");
            }
            Console.WriteLine("");

            int optionTopping;

            while (true)
            {
                Console.Write("Indtast mulighed: ");
                optionTopping = Convert.ToInt32(Console.ReadLine()) - 1;

                if (optionTopping <= pizza.Toppings.Count - 1 && optionTopping >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("-----");
                    Console.WriteLine("FEJL: Vælg venligst et gyldigt nummer!");
                }
            }
            Console.WriteLine("");

            Pizzas.removeTopping(pizza.Name, pizza.Toppings[optionTopping]);
        }
        if (optionUpdate == "p")
        {
            Console.Write("Indtast ny pris: ");
            int newPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            pizza.Price = newPrice;
            Pizzas.Update(pizza);
        }
        if (optionUpdate == "b")
        {
            Console.Clear();
            AdminPizzaOptions();
            return;
        }

        pizza = Pizzas.All[option]; // Get the latest version of pizza after updating items - Because of toppings

        Menu.Update(pizza); // Updates pizza if it is on the Menu

        // above options when chosen will print result if successful or not.

        GoBack(AdminPizzaOptions);
    }

    private void DeletePizza()
    {
        Console.WriteLine("PizzaStore - Admin · Pizza · Slet");
        Console.WriteLine("");
        Console.WriteLine("Vælg venligst et nummer til at slette nedenfor");
        Console.WriteLine("");
        Console.WriteLine("-----");
        foreach (var p in Pizzas.Pizzas)
        {
            Console.WriteLine($"·  Nr.: {p.Key}, Pizza: {p.Value}");
        }
        Console.WriteLine("");

        int option;

        while (true)
        {
            Console.Write("Indtast Nr.: ");
            option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            if (Pizzas.Pizzas.ContainsKey(option))
            {
                if (Menu.Items.Contains(Pizzas.Pizzas[option])) {
                    Console.WriteLine("-----");
                    Console.WriteLine("FEJL: Pizza findes på menu og kan derfor ikke slettes!");
                    break;
                }
                Console.WriteLine("-----");
                Pizzas.Delete(option); // prints result if successful or not.
                break;
            }
            else
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Vælg venligst et gyldigt nummer!");
            }
        }

        GoBack(AdminPizzaOptions);
    }

    private void SearchPizza()
    {
        Console.WriteLine("PizzaStore - Admin · Pizza · Søg");
        Console.WriteLine("");

        string? searchString;

        while (true)
        {
            Console.Write("Indtast søgning: ");
            searchString = Console.ReadLine();

            if (searchString == null)
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Venligst indtast et gyldigt navn!");
            }
            else
            {
                break;
            }
        }
        Console.WriteLine("");

        List<Pizza> searchResult = Pizzas.Search(searchString);

        Console.WriteLine("-----");
        if (searchResult.Count == 0)
        {
            Console.WriteLine("Ingen pizza fundet.");
        }
        else
        {
            Console.WriteLine("Søgeresultat:");
            Console.WriteLine("");
            for (int i = 0; i < searchResult.Count; i++)
            {
                Console.WriteLine(searchResult[i]);
            }
        }
        Console.WriteLine("-----");

        GoBack(AdminPizzaOptions);
    }
    #endregion

    #region Menu management
    private void AdminMenuOptions()
    {
        Console.WriteLine("PizzaStore - Admin · Menu");
        Console.WriteLine("");
        Console.WriteLine("Vælg venligst en mulighed nedenfor");
        Console.WriteLine("-----");
        Console.WriteLine("·  t = Tilføj Pizza");
        Console.WriteLine("·  f = Fjern Pizza");
        Console.WriteLine("·  v = Vis Menu");
        Console.WriteLine("-----");
        Console.WriteLine("·  b = Tilbage");
        Console.WriteLine("");

        string? option;

        while (true)
        {
            Console.Write("Indtast mulighed: ");
            option = Console.ReadLine();

            if (option == "t" || option == "f" || option == "v" || option == "b")
            {
                break;
            }
            else
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Vælg venligst en gyldig mulighed!");
            }
        }

        if (option == "t")
        {
            Console.Clear();
            AddPizza();
        }
        if (option == "f")
        {
            Console.Clear();
            RemovePizza();
        }
        if (option == "v")
        {
            Console.Clear();
            PrintMenu();
        }
        if (option == "b")
        {
            Console.Clear();
            AdminOptions();
        }
    }

    private void AddPizza()
    {
        Console.WriteLine($"PizzaStore - Admin · Menu · Tilføj Pizza");
        Console.WriteLine("");
        Console.WriteLine("Vælg venligst et nummer til at tilføje nedenfor");
        Console.WriteLine("-----");
        for (int i = 0; i < Pizzas.All.Count; i++)
        {
            Console.WriteLine($"·  Nr.: {i + 1}, Pizza: {Pizzas.All[i]}");
        }
        Console.WriteLine("");

        int option;

        while (true)
        {
            Console.Write("Indtast Nr.: ");
            option = Convert.ToInt32(Console.ReadLine()) - 1; // index starts at 0

            if (option <= Pizzas.All.Count - 1 && option >= 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Vælg venligst et gyldigt nummer!");
            }
        }
        Console.WriteLine("-----");

        Pizza pizza = Pizzas.All[option];

        Menu.Add(pizza); // prints result if successful or not.

        GoBack(AdminMenuOptions);
    }

    private void RemovePizza()
    {
        Console.WriteLine("PizzaStore - Admin · Menu · Fjern Pizza");
        Console.WriteLine("");
        Console.WriteLine("Vælg venligst et nummer til at fjerne nedenfor");
        Console.WriteLine("-----");
        for (int i = 0; i < Menu.Items.Count; i++)
        {
            Console.WriteLine($"·  Nr.: {i + 1}, Pizza: {Menu.Items[i]}");
        }
        Console.WriteLine("");

        int option;

        while (true)
        {
            Console.Write("Indtast Nr.: ");
            option = Convert.ToInt32(Console.ReadLine()) - 1; // index starts at 0

            if (option <= Menu.Items.Count - 1 && option >= 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Vælg venligst et gyldigt nummer!");
            }
        }
        Console.WriteLine("-----");

        Menu.Remove(option); // prints result if successful or not.

        GoBack(AdminMenuOptions);
    }

    private void PrintMenu()
    {
        Console.WriteLine("PizzaStore - Admin · Menu · Vis");
        Console.WriteLine("");

        Menu.PrintMenu();

        GoBack(AdminMenuOptions);
    }
    #endregion

    #region Customer management
    private void AdminCustomerOptions()
    {
        Console.WriteLine("PizzaStore - Admin · Kunde");
        Console.WriteLine("");
        Console.WriteLine("Vælg venligst en mulighed nedenfor");
        Console.WriteLine("-----");
        Console.WriteLine("·  t = Opret Kunde");
        Console.WriteLine("·  o = Opdater Kunde");
        Console.WriteLine("·  f = Slet Kunde");
        Console.WriteLine("·  s = Søg Kunde ved navn");
        Console.WriteLine("-----");
        Console.WriteLine("·  b = Tilbage");
        Console.WriteLine("");

        string? option;

        while (true)
        {
            Console.Write("Indtast mulighed: ");
            option = Console.ReadLine();

            if (option == "t" || option == "o" || option == "f" || option == "s" || option == "b")
            {
                break;
            }
            else
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Vælg venligst en gyldig mulighed!");
            }
        }

        if (option == "t")
        {
            Console.Clear();
            CreateCustomer();
        }
        if (option == "o")
        {
            Console.Clear();
            UpdateCustomer();
        }
        if (option == "f")
        {
            Console.Clear();
            DeleteCustomer();
        }
        if (option == "s")
        {
            Console.Clear();
            SearchCustomer();
        }
        if (option == "b")
        {
            Console.Clear();
            AdminOptions();
        }
    }

    private void CreateCustomer()
    {
        Console.WriteLine($"PizzaStore - Admin · Kunde · Opret");
        Console.WriteLine("");

        Console.Write("Indtast navn: ");
        string? name = Console.ReadLine();
        Console.WriteLine("-----");

        Console.Write("Indtast Adresse: ");
        string? address = Console.ReadLine();
        Console.WriteLine("-----");

        Console.Write("Indtast Tlf.: ");
        string? phoneNumber = Console.ReadLine();
        Console.WriteLine("-----");

        Console.Write("Indtast Email: ");
        string? email = Console.ReadLine();
        Console.WriteLine("");

        if (name != null || address != null || phoneNumber != null || email != null) 
        {
            Customer newCustomer = new Customer(name, address, phoneNumber, email, "");

            Console.WriteLine("-----");
            Customers.Create(newCustomer); // prints result if successful or not
            Console.WriteLine("-----");
        }
        else
        {
            Console.WriteLine("FEJL: Felter må ikke være tomme gå tilbage og prøv igen!");
        }

        GoBack(AdminCustomerOptions);
    }

    private void UpdateCustomer()
    {
        Console.WriteLine("PizzaStore - Admin · Kunde · Opdater");
        Console.WriteLine("");
        Console.WriteLine("Vælg venligst et nummer til at opdatere nedenfor");
        Console.WriteLine("");
        Console.WriteLine("-----");

        for (int i = 0; i < Customers.All.Count; i++)
        {
            Console.WriteLine($"Nr.: {i + 1}, Kunde:\n{Customers.All[i]}");
            Console.WriteLine("");
        }
        Console.WriteLine("");

        int option;

        while (true)
        {
            Console.Write("Indtast Nr.: ");
            option = Convert.ToInt32(Console.ReadLine()) - 1; // index starts at 0
            Console.WriteLine("");

            if (option <= Pizzas.All.Count - 1 && option >= 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Vælg venligst et gyldigt nummer!");
            }
        }

        Console.Clear();
        Console.WriteLine($"PizzaStore - Admin · Kunde · Opdater · {Customers.All[option].Name}");
        Console.WriteLine("");
        Console.WriteLine("Vælg venligst hvad du vil opdatere nedenfor");
        Console.WriteLine("-----");
        Console.WriteLine("·  n = Navn");
        Console.WriteLine("·  a = Adresse");
        Console.WriteLine("·  t = Tlf. nummer");
        Console.WriteLine("·  e = Email");
        Console.WriteLine("-----");
        Console.WriteLine("·  b = Tilbage");
        Console.WriteLine("");

        Pizza pizza = Pizzas.All[option];

        string? optionUpdate;

        while (true)
        {
            Console.Write("Indtast mulighed: ");
            optionUpdate = Console.ReadLine();

            if (optionUpdate == "n" || optionUpdate == "a" || optionUpdate == "t" || optionUpdate == "e"  || optionUpdate == "b")
            {
                break;
            }
            else
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Vælg venligst en gyldig mulighed!");
            }
        }
        Console.WriteLine("");

        Customer oldCustomerObject = Customers.All[option];
        Customer newCustomerObject = Customers.All[option];

        if (optionUpdate == "n")
        {
            Console.Write("Indtast nyt navn: ");
            string? newName = Console.ReadLine();
            Console.WriteLine("");
            newCustomerObject.Name = newName;
            Customers.Update(oldCustomerObject, newCustomerObject);
        }
        if (optionUpdate == "a")
        {
            Console.Write("Indtast ny adresse: ");
            string? newAddress = Console.ReadLine();
            Console.WriteLine("");
            newCustomerObject.Address = newAddress;
            Customers.Update(oldCustomerObject, newCustomerObject);
        }
        if (optionUpdate == "t")
        {
            Console.Write("Indtast nyt tlf.: ");
            string? newPhoneNumber = Console.ReadLine();
            Console.WriteLine("");
            newCustomerObject.PhoneNumber = newPhoneNumber;
            Customers.Update(oldCustomerObject, newCustomerObject);
        }
        if (optionUpdate == "e")
        {
            Console.Write("Indtast ny email: ");
            string? newEmail = Console.ReadLine();
            Console.WriteLine("");
            foreach (Customer c in Customers.All)
            {
                if (c.Email == newEmail)
                {
                    Console.WriteLine($"Email: {newEmail} er allerede i brug!");
                    GoBack(AdminCustomerOptions);
                    return;
                }
            }
            newCustomerObject.Email = newEmail;
            Customers.Update(oldCustomerObject, newCustomerObject);
        }
        if (optionUpdate == "b")
        {
            Console.Clear();
            AdminCustomerOptions();
            return;
        }

        GoBack(AdminCustomerOptions);
    }

    private void SearchCustomer()
    {
        Console.WriteLine("PizzaStore - Admin · Kunde · Søg");
        Console.WriteLine("");

        string? searchString;

        while (true)
        {
            Console.Write("Indtast søgning: ");
            searchString = Console.ReadLine();

            if (searchString == null)
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Venligst indtast et gyldigt navn!");
            }
            else
            {
                break;
            }
        }
        Console.WriteLine("");

        List<Customer> searchResult = Customers.Search(searchString);

        Console.WriteLine("-----");
        if (searchResult.Count == 0)
        {
            Console.WriteLine(" · Ingen kunder fundet.");
        }
        else
        {
            Console.WriteLine("Søgeresultat:");
            Console.WriteLine("");
            for (int i = 0; i < searchResult.Count; i++)
            {
                Console.WriteLine(searchResult[i]);
            }
        }
        Console.WriteLine("-----");

        GoBack(AdminCustomerOptions);
    }

    private void DeleteCustomer()
    {
        Console.WriteLine("PizzaStore - Admin · Kunde · Slet");
        Console.WriteLine("");
        Console.WriteLine("Vælg venligst et nummer til at slette nedenfor");
        Console.WriteLine("");
        Console.WriteLine("-----");
        foreach (var c in Customers.Customers)
        {
            Console.WriteLine($"·  Nr.: {c.Key}, Kunde: {c.Value.Name}");
        }
        Console.WriteLine("");

        int option;

        while (true)
        {
            Console.Write("Indtast Nr.: ");
            option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            if (Customers.Customers.ContainsKey(option))
            {
                Console.WriteLine("-----");
                Customers.Delete(option); // prints result if successful or not.
                Console.WriteLine("-----");
                break;
            }
            else
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Vælg venligst et gyldigt nummer!");
            }
        }

        GoBack(AdminCustomerOptions);
    }
    #endregion

    #endregion

    #region Customer view
    private void CustomerOptions()
    {
        Customer customer = Customers.All[1]; // This is a test customer to show functionality of the order system.

        Console.WriteLine("PizzaStore - Kunde");
        Console.WriteLine("");
        Console.WriteLine($"Hej {customer.Name}, vælg en mulighed nedenfor");
        Console.WriteLine("-----");
        Console.WriteLine("·  o = Opret ny ordre");
        Console.WriteLine("·  h = Vis ordre historik");
        Console.WriteLine("-----");
        Console.WriteLine("·  l = Log ud");
        Console.WriteLine("·  q = Afslut");
        Console.WriteLine("");

        string? option;

        while (true)
        {
            Console.Write("Indtast mulighed: ");
            option = Console.ReadLine();

            if (option == "o" || option == "h" || option == "l" || option == "q")
            {
                break;
            }
            else
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Vælg venligst en gyldig mulighed!");
            }
        }

        if (option == "o")
        {
            Console.Clear();
            CustomerOrderOptions(customer);
        }
        if (option == "h")
        {
            Console.Clear();
            CustomerOrderHistory(customer);
        }
        if (option == "l")
        {
            Console.Clear();
            User = null;
        }
        if (option == "q")
        {
            Environment.Exit(0);
        }
    }

    private void CustomerOrderOptions(Customer customer)
    {
        Console.WriteLine("PizzaStore - Kunde · Ny ordre");
        Console.WriteLine("");
        Console.WriteLine("Vælg venligst et Pizza ID til at bestille nedenfor");
        Console.WriteLine("");

        Console.WriteLine("-----");
        for (int i = 0; i < Pizzas.All.Count; i++)
        {
            Console.WriteLine($"·  ID: {i + 1}, Pizza: {Pizzas.All[i]}");
        }
        Console.WriteLine("");

        int option;

        while (true)
        {
            Console.Write("Enter ID: ");
            option = Convert.ToInt32(Console.ReadLine()) - 1; // index starts at 0

            if (option <= Menu.Items.Count - 1 && option >= 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Vælg venligst et gyldigt nummer!");
            }
        }
        Console.WriteLine("");

        Pizza pizza = Pizzas.All[option];

        Console.WriteLine("-----");
        Orders.Create(new Order(customer, pizza)); // prints result if successful or not.
        Console.WriteLine("-----");

        GoBack(CustomerOptions);
    }

    private void CustomerOrderHistory(Customer customer)
    {
        Console.WriteLine("PizzaStore - Kunde · Ordrer historik");
        Console.WriteLine("");
        Console.WriteLine($"Hej {customer.Name}, her er dine ordrer");
        Console.WriteLine("");

        Console.WriteLine("-----");
        Orders.ListCustomerOrders(customer); // prints result if successful or not.
        Console.WriteLine("-----");

        GoBack(CustomerOptions);
    }
    #endregion

    private static void GoBack(Action view)
    {
        Console.WriteLine("");
        Console.WriteLine("-----");
        Console.WriteLine("Vælg venligst en mulighed nedenfor");
        Console.WriteLine("-----");
        Console.WriteLine("·  b = Tilbage");
        Console.WriteLine("");

        string? option;

        while (true)
        {
            Console.Write("Indtast mulighed: ");
            option = Console.ReadLine();

            if (option == "b")
            {
                break;
            }
            else
            {
                Console.WriteLine("-----");
                Console.WriteLine("FEJL: Vælg venligst en gyldig mulighed!");
            }
        }

        if (option == "b")
        {
            Console.Clear();
            view();
        }
    }

    #endregion
}