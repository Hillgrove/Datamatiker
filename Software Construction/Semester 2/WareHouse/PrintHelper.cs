
public class PrintHelper
{
	public static void PrintItem(Item? item)
	{
		if (item != null)
			Console.WriteLine(item);
		else
			Console.WriteLine("Item was null...");
	}

	public static void PrintItemList(List<Item> itemList, string text = "")
	{
		PrintList(itemList, text, PrintItem);
	}

	public static void PrintList<T>(List<T> list, string text = "", Action<T>? printFunc = null)
	{
		Console.WriteLine(text);
		foreach (T t in list)
		{
			if (printFunc != null)
				printFunc(t);
			else
				Console.WriteLine(t);
		}
		Console.WriteLine();
	}
}
