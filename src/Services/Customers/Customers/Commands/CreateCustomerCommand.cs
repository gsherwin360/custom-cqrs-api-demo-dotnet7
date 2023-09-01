using Core.Commands;

namespace Customers.Commands;

public record CreateCustomerCommand(
    string FirstName,
    string LastName,
    string Gender,
    string Address)
    : ICommand<Guid>;

public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Guid>
{
    public Task<Guid> Handle(CreateCustomerCommand command, CancellationToken cancellationToken = default)
    {
        var newCustomer = Customer.Create(command.FirstName, command.LastName, command.Gender, command.Address);
        CustomerManager.AddCustomer(newCustomer);
        return Task.FromResult(newCustomer.Id);
    }
}