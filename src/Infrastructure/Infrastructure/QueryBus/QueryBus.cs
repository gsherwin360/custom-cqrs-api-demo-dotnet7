using Core.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.QueryBus;

/// <summary>
/// Implements the <see cref="IQueryBus"/> interface, responsible for sending queries to their corresponding query handlers and returning responses.
/// </summary>
public class QueryBus : IQueryBus
{
    private readonly IServiceProvider serviceProvider;

    public QueryBus(IServiceProvider serviceProvider) =>
        this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

    public async Task<TResult> Query<TQuery, TResult>(TQuery query, CancellationToken ct = default)
        where TQuery : IQuery<TResult>
        where TResult : class
    {
        var queryHandler = this.serviceProvider.GetService<IQueryHandler<TQuery, TResult>>();

        if (queryHandler is null)
        {
            var queryName = query.GetType().Name;
            throw new InvalidOperationException($"No handler found for the query: {queryName}");
        }

        return await queryHandler.Handle(query, ct);
    }
}