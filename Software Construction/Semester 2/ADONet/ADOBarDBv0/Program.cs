
using Microsoft.Data.SqlClient;

// 1) Setup DB
SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
builder.DataSource = "(localdb)\\MSSQLLocalDB";
builder.InitialCatalog = "DrinkDB";

// 2) Read all drinks from the DB
List<Drink> drinks = new List<Drink>();
List<Customer> customers = new List<Customer>();

void UpdateDrinks()
{
    drinks.Clear();

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
}

void UpdateCustomers()
{
    customers.Clear();

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
}

void DeleteCustomers()
{
    try
    {
        using SqlConnection connection = new SqlConnection(builder.ConnectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand("DELETE FROM Customer " +
                                        "WHERE Name LIKE 'J%'", connection);
        cmd.ExecuteNonQuery();
    }
    catch (SqlException sqlEx)
    {
        Console.WriteLine($"NB: An SqlException occurred : {sqlEx.Message}");
    }
}

void PrintDrinks()
{
    Console.WriteLine($"All Drinks ({drinks.Count} drinks in total)");
    Console.WriteLine("-------------------------------------------");
    foreach (Drink drink in drinks)
    {
        Console.WriteLine(drink);
    }
}

void PrintCustomers()
{
    Console.WriteLine($"All Customers ({customers.Count} customers in total)");
    Console.WriteLine("-------------------------------------------");
    foreach (Customer customer in customers)
    {
        Console.WriteLine(customer);
    }
}

void ResetCustomers()
{
    string currentDirectory = Directory.GetCurrentDirectory();
    string relativePath = @"..\..\..\ResetCustomer.sql";
    string fullPath = Path.GetFullPath(Path.Combine(currentDirectory, relativePath));
    try
    {
        string script = File.ReadAllText(fullPath);

        using SqlConnection connection = new SqlConnection(builder.ConnectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(script, connection);
        cmd.ExecuteNonQuery();
    }
    catch (SqlException sqlEx)
    {
        Console.WriteLine($"NB: An SqlException occurred : {sqlEx.Message}");
    }
}

// initial populating lists
ResetCustomers();
UpdateDrinks();
UpdateCustomers();

// priting lists
PrintDrinks();
Console.WriteLine("\n");
PrintCustomers();

// deleting customers from table
DeleteCustomers();

// updating list
UpdateCustomers();

// printing updated list
Console.WriteLine("\n");
PrintCustomers();

// Writing to customer table
try
{
    using SqlConnection connection = new SqlConnection(builder.ConnectionString);
    connection.Open();

    SqlCommand cmd = new SqlCommand("INSERT INTO Customer " +
                                    "VALUES (13,'Anders And', '987-654-3210', '-200')", connection);
    cmd.ExecuteNonQuery();
}

catch (SqlException sqlEx)
{
    Console.WriteLine($"NB: An SqlException occurred : {sqlEx.Message}");
}

UpdateCustomers();
Console.WriteLine("\n");
PrintCustomers();