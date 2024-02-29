
/// <summary>
/// This class represents a very simple bank account.
/// Only the amount of money on the account is represented.
/// </summary>
public class BankAccount
{
    private double _balance;
    private string _accountOwner;

    public BankAccount(string name)
    {
        _balance = 0.0;
        _accountOwner = name;
    }

    public double Balance
    {
        get { return _balance; }
    }

    public string AccountOwner
    {
        get { return _accountOwner; }
    }

    public void Deposit(double amount)
    {
        _balance = _balance + amount;
    }

    public void Withdraw(double amount)
    {
        _balance = _balance - amount;
    }
}

