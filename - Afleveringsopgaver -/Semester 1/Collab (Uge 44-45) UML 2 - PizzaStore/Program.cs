PizzaStoreUI ui = new PizzaStoreUI();

ui.RunUI();

// Below are tests of some classes - comment the above out and uncomment ClassesTest() - Det er desværre ikke alle metoder der bliver testet her, men de er testet i UI.

// ClassesTest();

static void ClassesTest()
{
    Menu menu = new Menu();
    PizzaRepository pizzas = new PizzaRepository();
    CustomerRepository customers = new CustomerRepository();
    OrderRepository orders = new OrderRepository();

    pizzas.Create(new Pizza("Oriental", new List<string> { "Tomat", "Ost", "Pepperoni", "Chili" }, 80));
    pizzas.Create(new Pizza("Vesuvio", new List<string> { "Tomat", "Ost", "Skinke" }, 70));
    pizzas.Create(new Pizza("Hawaii", new List<string> { "Tomat", "Ost", "Skinke" }, 60));
    Console.WriteLine("-");

    pizzas.All[1].Price = 150;
    Console.WriteLine("-");

    pizzas.Update(pizzas.All[1]);
    Console.WriteLine("-");

    pizzas.addTopping("Oriental", "Skinke");
    Console.WriteLine("-");

    pizzas.removeTopping("Vesuvio", "Skinke");
    Console.WriteLine("-");

    pizzas.Search("Ves");
    Console.WriteLine("-");

    pizzas.Read(1); // ID 1 = pizzas.All[0]
    Console.WriteLine("-");

    pizzas.Delete(1); // ID 1 = pizzas.All[0]
    Console.WriteLine("-");

    customers.Create(new Customer("Jonas", "2700 Islev", "42680021", "jonas@gmail.com", "12233"));
    customers.Create(new Customer("Markus", "2300 CPH", "42556677", "Markus@gmail.com", "43022"));
    customers.Create(new Customer("Maria", "2100 CPH", "43556241", "Maria@Outlook.com", "22443"));
    Console.WriteLine("-");

    orders.Create(new Order(customers.All[1], pizzas.All[1]));
    orders.Create(new Order(customers.All[2], pizzas.All[2]));
    Console.WriteLine("-");

    menu.Add(pizzas.All[1]);
    menu.Add(pizzas.All[2]);
    Console.WriteLine("-");

    menu.Update(pizzas.All[1]);
    Console.WriteLine("-");

    menu.PrintMenu();
    Console.WriteLine("-");

    menu.Remove(1); // ID 1 = pizzas.All[1] beacuse menu is a List
    Console.WriteLine("-");
}

