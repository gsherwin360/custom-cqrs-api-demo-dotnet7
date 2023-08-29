using Core.Queries;
using Infrastructure.QueryBus;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// This class is responsible for configuring query bus services in the DI container.
/// </summary>
public static class QueryBusServices
{
    public static IServiceCollection AddQueryBus(this IServiceCollection services)
    {
        services.AddScoped<IQueryBus, QueryBus>();
        return services;
    }

    public static IServiceCollection AddQueryHandlerInAssemblyOf<TAssembly>(this IServiceCollection services)
    {
        var queryHandlerType = typeof(IQueryHandler<,>);
        var assembly = typeof(TAssembly).Assembly;

        RegisterQueryHandlersForType(assembly, queryHandlerType, services);

        return services;
    }

    private static IEnumerable<Type> GetQueryHandlers(Assembly assembly, Type commandHandlerType)
    {
        return assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == commandHandlerType));
    }

    private static void RegisterQueryHandlersForType(Assembly assembly, Type commandHandlerType, IServiceCollection services)
    {
        foreach (var queryHandler in GetQueryHandlers(assembly, commandHandlerType))
        {
            var implementedInterfaces = queryHandler.GetInterfaces()
                .Where(interf => interf.IsGenericType &&
                                 interf.GetGenericTypeDefinition() == commandHandlerType);

            foreach (var implementedInterface in implementedInterfaces)
            {
                services.AddTransient(implementedInterface, queryHandler);
            }
        }
    }
}
