
public class ItemRepository
{
	private Dictionary<int, Item> _items;

	public ItemRepository()
	{
		_items = new Dictionary<int, Item>();
	}

	public void Add(Item item)
	{
		if (_items.ContainsKey(item.Id))
			throw new ArgumentException();
	   
		_items.Add(item.Id, item);
	}
}
