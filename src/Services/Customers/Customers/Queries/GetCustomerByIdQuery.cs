using Core.Queries;

namespace Customers.Queries;

public record GetCustomerByIdQuery(Guid id) : IQuery<Customer>;

public class GetCustomerByIdQueryHandler : IQueryHandler<GetCustomerByIdQuery, Customer>
{
    public Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken = default)
    {
        var customer = CustomerManager.GetAllCustomers().SingleOrDefault(c => c.Id == request.id);
        return Task.FromResult(customer);
    }
}