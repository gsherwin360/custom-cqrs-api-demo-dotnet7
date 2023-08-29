namespace Core.Queries;

/// <summary>
/// Represents a query handler responsible for retrieving specific queries and generating results.
/// </summary>
public interface IQueryHandler<in TQuery, TResult>
    where TQuery : IQuery<TResult>
    where TResult : class

{
    Task<TResult> Handle(TQuery request, CancellationToken cancellationToken = default);
}