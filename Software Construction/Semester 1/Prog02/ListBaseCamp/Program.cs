
List<int> listOfInt = new List<int>();
listOfInt.Add(4);
listOfInt.Add(12);
listOfInt.Add(9);


// Case 1
Console.WriteLine($"Case 1: Element with index 1 is {listOfInt[1]}");
Console.WriteLine("Expected result: 12\n");


// Case 2
Console.WriteLine($"Case 2: List contains {listOfInt.Count} elements");
Console.WriteLine("Expected result: 3\n");

listOfInt.Add(5);
listOfInt.Add(22);


// Case 3
Console.WriteLine($"Case 3: Element with index 3 is {listOfInt[3]}");
Console.WriteLine("Expected result: 5\n");

listOfInt.RemoveAt(0);


// Case 4
Console.WriteLine($"Case 4: Element with index 3 is {listOfInt[3]}");
Console.WriteLine("Expected Result: 22\n");


listOfInt.Clear();
listOfInt.Add(14);
listOfInt.Add(87);
listOfInt.Add(62);
listOfInt.Add(21);
listOfInt.Add(40);
listOfInt.Add(3);


// Case 5: Add code that prints out 
// all the elements in the list
Console.WriteLine("Case 5: Add code that prints out 14, 87, 62, 21, 40, 3");
foreach (int item in listOfInt)
{
    Console.WriteLine(item);
}
Console.WriteLine();


// Case 6: Add code that finds the 
// sum of the elements in the list, and prints the result
Console.WriteLine("Case 6: Find the sum of the elements in the list");
int sum = listOfInt.Sum(); 

Console.WriteLine($"Sum of list: {sum}");
Console.WriteLine("Expected result: 227\n");


// [DIFFICULT]
// Case 7: Add code that finds the smallest  
// element in the list, and prints the result
// Tip: Think in detail about how you would do this manually
Console.WriteLine("Case 7: Find the smallest element in the list");
int currentSmallest = listOfInt[0];
foreach (int item in listOfInt)
{
    if (item < currentSmallest) { currentSmallest = item; }
}

Console.WriteLine($"The smallest element in the list is: {currentSmallest}");
Console.WriteLine("Expected result: 3\n");


// [(maybe) DIFFICULT]
// Case 8: Add code that sorts the content of the list.
// Tip: Think before you code...
Console.WriteLine("Case 8: Sorts the content of the list.");
listOfInt.Sort();
foreach (int item in listOfInt)
{  
    Console.WriteLine(item); 
}
