namespace Core.Queries;

/// <summary>
/// Represents a mediator responsible for sending queries to their corresponding query handlers and returns a response.
/// </summary>
public interface IQueryBus
{
    Task<TResult> Query<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
        where TQuery : IQuery<TResult>
        where TResult : class;

}
