using Core.Queries;

namespace Customers.Queries;

public record GetAllCustomersQuery() : IQuery<List<Customer>>;

public class GetAllCustomersQueryHandler : IQueryHandler<GetAllCustomersQuery, List<Customer>>
{
    public Task<List<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken = default)
    {
        var customers = new List<Customer> {
            Customer.Create("Sherwin", "Gonzales", "Male", "Philippines")
        };

        return Task.FromResult(customers);
    }
}