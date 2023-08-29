namespace Core.Commands;

/// <summary>
/// Represents a command handler responsible for executing the logic of a specific command.
/// </summary>
public interface ICommandHandler<in TCommand, TResponse> where TCommand : ICommand<TResponse>
{
    Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken = default);
}
