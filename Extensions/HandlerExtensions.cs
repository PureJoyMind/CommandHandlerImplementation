using System.Reflection;
using CommandHandlerImplementation.Handlers;
using CommandHandlerImplementation.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CommandHandlerImplementation.Extensions;

public static class HandlerExtensions
{
    public static void AddCommandHandlers(this ServiceCollection sc)
    {
        sc.AddSingleton<HandlerManager>();
        var types = GetAssemblyHandlerTypes(typeof(Program).Assembly);
        foreach (var type in types)
        {
            sc.TryAddScoped(type);
        }
    }
    
    public static IEnumerable<TypeInfo> GetAssemblyHandlerTypes(Assembly assembly) => assembly.DefinedTypes
        .Where(t => t is { IsAbstract: false, IsInterface: false} && typeof(IHandler).IsAssignableFrom(t));
}