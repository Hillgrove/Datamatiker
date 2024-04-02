
using Microsoft.Data.SqlClient;

// 1) Setup DB
SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
builder.DataSource = "(localdb)\\MSSQLLocalDB";
builder.InitialCatalog = "DrinkDB";

// 2) Read all drinks from the DB
List<Drink> drinks = new List<Drink>();
List<Customer> customers = new List<Customer>();

try
{
    // 2a) Setup the connection with the "using" syntax
    using SqlConnection connection = new SqlConnection(builder.ConnectionString);
    connection.Open();

    // 2b) Prepare and execute the actual SQL command
    SqlCommand cmd = new SqlCommand("SELECT * FROM DrinkFlat", connection);
    SqlDataReader reader = cmd.ExecuteReader();

    // 2c) Process the retrieved data
    while (reader.Read())
    {
        int id = reader.GetInt32(0);
        string name = reader.GetString(1);
        string alcoholicPart = reader.GetString(2);
        int alcoholicPartAmount = reader.GetInt32(3);
        string nonAlcoholicPart = reader.GetString(4);
        int nonAlcoholicPartAmount = reader.GetInt32(5);

        drinks.Add(new Drink(id, name,
            alcoholicPart, alcoholicPartAmount,
            nonAlcoholicPart, nonAlcoholicPartAmount));
    }
}
catch (SqlException sqlEx)
{
    Console.WriteLine($"NB: An SqlException occurred : {sqlEx.Message}");
}

try
{
    using SqlConnection connection = new SqlConnection(builder.ConnectionString);
    connection.Open();

    SqlCommand cmd = new SqlCommand("SELECT * FROM Customer", connection);
    SqlDataReader reader = cmd.ExecuteReader();

    while (reader.Read())
    {
        int id = reader.GetInt32(0);
        string name = reader.GetString(1);
        string phone_number = reader.GetString(2);
        int credit = reader.GetInt32(3);

        customers.Add(new Customer(id, name, phone_number, credit));
    }
}
catch (SqlException sqlEx)
{
    Console.WriteLine($"NB: An SqlException occurred : {sqlEx.Message}");
}

// 3) Print all drinks (should print 10 drinks)
Console.WriteLine($"All Drinks ({drinks.Count} drinks in total)");
Console.WriteLine("-------------------------------------------");
foreach (Drink drink in drinks)
{
    Console.WriteLine(drink);
}

Console.WriteLine();
Console.WriteLine();

Console.WriteLine($"All Customers ({customers.Count} drinks in total)");
Console.WriteLine("-------------------------------------------");
foreach (Customer customer in customers)
{
    Console.WriteLine(customer);
}
