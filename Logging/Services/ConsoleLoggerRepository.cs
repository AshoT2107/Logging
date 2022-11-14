namespace Logging.Services;

public class ConsoleLoggerRepository : ILoggerRepository
{
    public void Add(string message)
    {
        Console.WriteLine(message);
    }
}
