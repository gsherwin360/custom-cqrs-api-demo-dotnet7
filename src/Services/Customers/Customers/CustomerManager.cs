namespace Customers;

public static class CustomerManager
{
    private static readonly List<Customer> _customerList = new List<Customer>();

    public static void AddCustomer(Customer customer)
    {
        if(customer is null) throw new ArgumentNullException(nameof(customer));

        _customerList.Add(customer);
    }

    public static List<Customer> GetAllCustomers()
    {
        return _customerList;
    }
}