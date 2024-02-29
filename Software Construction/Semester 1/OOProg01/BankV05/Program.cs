
BankAccount myAccount = new BankAccount("Anders And");

myAccount.Deposit(2000);
Console.WriteLine($"Account balance is : {myAccount.Balance}");

myAccount.Withdraw(1500);
Console.WriteLine($"Account balance is : {myAccount.Balance}");

Console.WriteLine($"Account owner is: {myAccount.AccountOwner}");