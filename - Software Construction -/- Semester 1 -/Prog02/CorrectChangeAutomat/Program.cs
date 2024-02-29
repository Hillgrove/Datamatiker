int bill = 265;
int payment = 500;
int change = payment - bill;

int amountOf200kr = change / 200;
int amountOf20kr = (change % 200) / 20;
int amountOf10kr = (change % 200 % 20) / 10;
int amountOf2kr =  (change % 200 % 20 % 10) / 2;
int amountOf1kr =  (change % 200 % 10 % 10 % 2) / 1;

Console.WriteLine($"Byttepenge i alt: {change}\n");
Console.WriteLine($"Antal 200kr seddler: {amountOf200kr}\n");
change -= amountOf200kr * 200;


Console.WriteLine($"Byttepenge endnu ikke betalt: {change}");
Console.WriteLine($"Antal 20kr mønter: {amountOf20kr}\n");
change -= amountOf20kr * 20;


Console.WriteLine($"Byttepenge endnu ikke betalt: {change}");
Console.WriteLine($"Antal 10kr mønter: {amountOf10kr}\n");
change -= amountOf10kr * 10;


Console.WriteLine($"Byttepenge endnu ikke betalt: {change}");
Console.WriteLine($"Antal 2kr mønter: {amountOf2kr}\n");
change -= amountOf2kr * 2;

Console.WriteLine($"Byttepenge endnu ikke betalt: {change}");
Console.WriteLine($"Antal 1kr mønter: {amountOf1kr}\n");