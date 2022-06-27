using System.ComponentModel.Design.Serialization;

namespace SectTask;

static class Program
{
    static void Main(string?[] args)
    {
        CommandParser input = new CommandParser();
        input.Commands(args);
    }
}