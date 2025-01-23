using CommandHandlerImplementation.Interfaces;

namespace CommandHandlerImplementation;

public class ConsoleWriter : IConsoleWriter
{
    public void Write(string arg) => Console.WriteLine(arg);
}