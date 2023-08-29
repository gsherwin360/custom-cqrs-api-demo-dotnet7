namespace Core.Commands;

/// <summary>
/// Represents a mediator responsible for sending commands to their corresponding command handlers and returns a response.
/// </summary>
public interface ICommandBus
{
    Task<TResponse> Send<TCommand, TResponse>(TCommand command, CancellationToken cancellationToken = default)
        where TCommand : ICommand<TResponse>
        where TResponse : notnull;
}
