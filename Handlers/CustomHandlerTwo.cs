using CommandHandlerImplementation.Attributes;
using CommandHandlerImplementation.Interfaces;

namespace CommandHandlerImplementation.Handlers;

[CommandName("second")]
public class CustomHandlerTwo(IConsoleWriter console) : IHandler
{
    public void Handle() => console.Write("Custom handler 2 doing it's job");
}