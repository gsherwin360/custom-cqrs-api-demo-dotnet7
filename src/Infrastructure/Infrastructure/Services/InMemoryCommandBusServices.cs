using Core.Commands;
using Infrastructure.CommandBus;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// This class is responsible for configuring in-memory command bus services in the DI container.
/// </summary>
public static class InMemoryCommandBusServices
{
    public static IServiceCollection AddInMemoryCommandBus(this IServiceCollection services)
    {
        services.AddScoped<ICommandBus, InMemoryCommandBus>();
        return services;
    }

    public static IServiceCollection AddCommandHandlerInAssemblyOf<TAssembly>(this IServiceCollection services)
    {
        var commandHandlerWithReturnType = typeof(ICommandHandler<,>);
        var assembly = typeof(TAssembly).Assembly;

        RegisterCommandHandlersForType(assembly, commandHandlerWithReturnType, services);

        return services;
    }

    private static IEnumerable<Type> GetCommandHandlers(Assembly assembly, Type commandHandlerType)
    {
        return assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == commandHandlerType));
    }

    private static void RegisterCommandHandlersForType(Assembly assembly, Type commandHandlerType, IServiceCollection services)
    {
        foreach (var commandHandler in GetCommandHandlers(assembly, commandHandlerType))
        {
            var implementedInterfaces = commandHandler.GetInterfaces()
                .Where(interf => interf.IsGenericType &&
                                 interf.GetGenericTypeDefinition() == commandHandlerType);

            foreach (var implementedInterface in implementedInterfaces)
            {
                services.AddTransient(implementedInterface, commandHandler);
            }
        }
    }
}
