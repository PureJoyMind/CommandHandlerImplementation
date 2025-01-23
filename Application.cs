using CommandHandlerImplementation.Handlers;
using CommandHandlerImplementation.Interfaces;

namespace CommandHandlerImplementation;

public class Application(HandlerManager handlerManager,IConsoleWriter console)
{
    public void Run(string[] args)
    {
        var command = args.FirstOrDefault() ?? "first";
        
        if (string.IsNullOrEmpty(command))
        {
            console.Write("Invalid command, aborting session.");
            return;
        }

        var handler = handlerManager.GetHandlerForCommand(command);
        
        handler.Handle();
    }

}