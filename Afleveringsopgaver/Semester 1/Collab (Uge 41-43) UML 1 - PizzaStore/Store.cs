
public static class Store
{
    #region Methods
    public static void Start()
    {
        Topping pepperoni = new Topping("pepperoni");
        Topping skinke = new Topping("skinke");

        Pizza pizzaA = new Pizza("Oriental", 70, pepperoni);
        Pizza pizzaB = new Pizza("Vesuvio", 60, skinke);
        Pizza pizzaC = new Pizza("Margarita", 50);

        Customer customerA = new Customer("Anders And", "131-313", "Paradisæblevej 111, Andeby");
        Customer customerB = new Customer("F. Mule", "420-69", "Mulevænget 3, Mouseton");
        Customer customerC = new Customer("Mickey Mouse", "666-666", "Musensvej 13, Andeby");

        Order orderA = new Order(customerA, pizzaA);
        Order orderB = new Order(customerB, pizzaB);
        Order orderC = new Order(customerC, pizzaC);

        Console.WriteLine("******************************\n");
        Console.WriteLine(orderA);
        Console.WriteLine("\n******************************\n");
        Console.WriteLine(orderB);
        Console.WriteLine("\n******************************\n");
        Console.WriteLine(orderC);
        Console.WriteLine("\n******************************");
    }
    #endregion
}