public class Customer
{
    #region Properties
    // public int CustomerId { get; set; } - Id is used as Dictionary Key for now.
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string CardId { get; set; }
    #endregion

    #region Constructor
    public Customer(string name, string address, string phoneNumber, string email, string? cardId)
    {
        // CustomerId = customerId; - Id is used as Dictionary Key for now.
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
        CardId = cardId ?? "";
    }
    #endregion

    #region Methods
    public override string ToString()
    {
        return $"Navn: {Name}\nAdresse: {Address}\nTlf: {PhoneNumber}\nEmail:{Email}";
    }
    #endregion
}