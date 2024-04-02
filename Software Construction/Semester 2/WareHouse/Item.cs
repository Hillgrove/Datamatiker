
public class Item
{
	private static int _id = 1;

	public int Id { get; }

	public Item()
	{
		Id = _id++;
	}

	public override string ToString()
	{
		return $"Item #{Id} : ";
	}
}
