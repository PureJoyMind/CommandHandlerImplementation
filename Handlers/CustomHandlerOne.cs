using CommandHandlerImplementation.Interfaces;

namespace CommandHandlerImplementation.Handlers;

[CommandName("first")]
public class CustomHandlerOne(IConsoleWriter console) : IHandler
{
    public void Handle() => console.Write("Custom handler 1 doing it's job");
}