namespace Customers;

public class Customer
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Gender { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;

    private Customer() { }

    public static Customer Create(string firstName, string lastName, string gender, string address)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            throw new ArgumentException($"'{nameof(firstName)}' cannot be null or empty.", nameof(firstName));
        }

        if (string.IsNullOrEmpty(lastName))
        {
            throw new ArgumentException($"'{nameof(lastName)}' cannot be null or empty.", nameof(lastName));
        }

        if (string.IsNullOrEmpty(gender))
        {
            throw new ArgumentException($"'{nameof(gender)}' cannot be null or empty.", nameof(gender));
        }

        if (string.IsNullOrEmpty(address))
        {
            throw new ArgumentException($"'{nameof(address)}' cannot be null or empty.", nameof(address));
        }

        var customer = new Customer();
        customer.Id = Guid.NewGuid();
        customer.FirstName = firstName;
        customer.LastName = lastName;
        customer.Gender = gender;
        customer.Address = address;

        return customer;
    }
}
