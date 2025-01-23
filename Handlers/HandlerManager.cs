using System.Reflection;
using CommandHandlerImplementation.Extensions;
using CommandHandlerImplementation.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CommandHandlerImplementation.Handlers;

public class HandlerManager
{
    private IServiceScopeFactory ScopeFactory { get; }
    private Dictionary<string, Type> _handlerDictionary = new Dictionary<string, Type>();

    public HandlerManager(IServiceScopeFactory scopeFactory)
    {
        ScopeFactory = scopeFactory;
        RegisterHandlersInProject(typeof(IHandler).Assembly);
    }


    public IHandler GetHandlerForCommand(string command)
    {
        if (!_handlerDictionary.TryGetValue(command, out var handler))
            return null;

        var scope = ScopeFactory.CreateScope();
        return (IHandler)scope.ServiceProvider.GetRequiredService(handler);
    }
    
    private void RegisterHandlersInProject(Assembly assembly)
    {
        var types = HandlerExtensions.GetAssemblyHandlerTypes(assembly);

        foreach (var type in types)
        {
            var commandNameAttribute = type.GetCustomAttribute<CommandNameAttribute>();
            if(commandNameAttribute is null) continue;
            
            _handlerDictionary.Add(commandNameAttribute.CommandName, type);
        }
    }
}