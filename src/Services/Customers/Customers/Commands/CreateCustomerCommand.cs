using Core.Commands;

namespace Customers.Commands;

public class CreateCustomerCommand : ICommand<Guid>
{
    public CreateCustomerCommand(string firstName, string lastName, string gender, string address)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Gender = gender;
        this.Address = address;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Gender { get; private set; }
    public string Address { get; private set; }
}

public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Guid>
{
    public Task<Guid> Handle(CreateCustomerCommand command, CancellationToken cancellationToken = default)
    {
        var newCustomer = Customer.Create(command.FirstName, command.LastName, command.Gender, command.Address);

        return Task.FromResult(newCustomer.Id);
    }
}
