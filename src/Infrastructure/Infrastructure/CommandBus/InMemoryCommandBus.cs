using Core.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CommandBus;

/// <summary>
/// Implements the <see cref="ICommandBus"/> interface, responsible for sending commands to their corresponding command handlers and returns a response.
/// </summary>
public class InMemoryCommandBus : ICommandBus
{
    private readonly IServiceProvider serviceProvider;

    public InMemoryCommandBus(IServiceProvider serviceProvider) =>
        this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

    public async Task<TResponse> Send<TCommand, TResponse>(TCommand command, CancellationToken ct = default)
        where TCommand : ICommand<TResponse>
        where TResponse : notnull
    {
        var handler = this.serviceProvider.GetService<ICommandHandler<TCommand, TResponse>>();

        if (handler is null)
        {
            var commandName = command.GetType().Name;
            throw new InvalidOperationException($"No handler found for the command: {commandName}");
        }

        return await handler.Handle(command, ct);
    }
}