
public class Customer
{
    #region Properties
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    #endregion

    #region Constructor
    public Customer(string name, string phoneNumber, string address)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Address = address;
    }
    #endregion

    #region Methods
    public override string ToString()
    {
        return $"Navn: {Name}\nAdresse: {Address}\nTLF: {PhoneNumber}";
    }
    #endregion
}