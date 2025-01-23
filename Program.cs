using CommandHandlerImplementation.Extensions;
using CommandHandlerImplementation.Handlers;
using CommandHandlerImplementation.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CommandHandlerImplementation;

class Program
{
    static void Main(string[] args)
    {
        ServiceCollection sc = new ServiceCollection();
        sc.AddSingleton<IConsoleWriter, ConsoleWriter>();
        sc.AddCommandHandlers();
        
        sc.AddSingleton<Application>();
                
        ServiceProvider sp = sc.BuildServiceProvider();
        
        var app = sp.GetRequiredService<Application>();
        app.Run(args);
    }
}
