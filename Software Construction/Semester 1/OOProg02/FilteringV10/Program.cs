
/// <Assigment>
/// 1.Figure out how to use the interface IFilterCondition to change the FilterValues method, 
/// into a method that can filter a list of integers according to any condition. That is, the 
/// condition itself has to somehow become a parameter to the method. Try out your solution with 
/// a couple of conditions.
/// 2. Figure out how you can apply several filter conditions to a list in a single method call.
/// 3. Filtering is a very generic operation. Maybe some of the .NET collection classes already support filtering…?
///</Task>

List<int> values = new List<int>() { 12, 24, 9, 10, 6, 3, 45 };

#region Single condition filtering
List<int> filteredValues = Filter.FilterValues(values, new FilterOddNumbers());
Console.WriteLine("Filter odd numbers");
foreach (var value in filteredValues)
{
    Console.Write($" {value} ");
}
Console.WriteLine();

filteredValues = Filter.FilterValues(values,new FilterBelow20());
Console.WriteLine("Filter below 20");
foreach (var value in filteredValues)
{
    Console.Write($" {value} ");
}
Console.WriteLine();

filteredValues = Filter.FilterValues(values, new FilterDivisibleBy9());
Console.WriteLine("Filter divisible by 9");
foreach (var value in filteredValues)
{
    Console.Write($" {value} ");
}
Console.WriteLine();
#endregion

#region Multi condition filtering
List<IFilterCondition> filterConditions = new List<IFilterCondition>
{
    new FilterBelow20(),
    new FilterDivisibleBy9(),
    new FilterOddNumbers()
};

filteredValues = Filter.MultipleFilterValues(values, filterConditions);
Console.WriteLine("All filters:");
foreach (var value in filteredValues)
{
    Console.Write($" {value} ");
}
Console.WriteLine();
#endregion