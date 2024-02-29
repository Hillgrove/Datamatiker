
public class BankAccount
{
    /// <summary>
    /// Balance of the account; must not become negative
    /// </summary>
    public double Balance { get; private set; }

    /// <summary>
    /// Interest rate of the account; must be between 0.0 and 20.0
    /// </summary>
    public double InterestRate { get; }

    public BankAccount(double interestRate)
    {
        if (0 > interestRate || interestRate > 20.0)
        {
            throw new IllegalInterestRateException($"{interestRate}. It should be between 0.0 and 20.0.");
        }
        InterestRate = interestRate;
        Balance = 0.0;
    }

    public void Deposit(double amount)
    {
        if (amount  < 0)
        {
            throw new NegativeAmountException($"{amount}");
        }
        Balance = Balance + amount;
    }

    public void Withdraw(double amount)
    {
        if (Balance < amount)
        {
            throw new WithdrawAmountTooLargeException($"Amount was {amount} kr., balance was {Balance} kr.");
        }

        Balance = Balance - amount;
    }
}