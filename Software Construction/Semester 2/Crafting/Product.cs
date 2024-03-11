
public  class Product
{
    public string Name { get; }
    public Recipe Recipe { get; private set; }

    public Product(string name, Recipe recipe)
    {
        Name = name;
        Recipe = recipe;
    }
}