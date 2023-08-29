using Core.Commands;
using Core.Queries;
using Customers.Api.Models;
using Customers.Commands;
using Customers.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICommandBus commandBus;
    private readonly IQueryBus queryBus;

    public CustomersController(ICommandBus commandBus, IQueryBus queryBus)
    {
        this.commandBus = commandBus ?? throw new ArgumentNullException(nameof(commandBus));
        this.queryBus = queryBus ?? throw new ArgumentNullException(nameof(queryBus));
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create(CreateCustomerModel createCustomerModel)
    {
        var createUserCommand = new CreateCustomerCommand(
            createCustomerModel.FirstName,
            createCustomerModel.LastName,
            createCustomerModel.Gender,
            createCustomerModel.Address);

        var result = await this.commandBus.Send<CreateCustomerCommand, Guid>(createUserCommand);

        return this.Ok(result);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllCustomers()
    {
        var result = await this.queryBus.Query<GetAllCustomersQuery, List<Customer>>(new GetAllCustomersQuery());

        return this.Ok(result);
    }
}
