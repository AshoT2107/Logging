using System.IO;
namespace Logging.Services;

public class FileLoggerRepository : ILoggerRepository
{
    private readonly string jsonPath = "txt.json";
    public void Add(string message)
    {
        if (!File.Exists(jsonPath))
            File.Create(jsonPath);
        var str = File.ReadAllLines("txt.json").ToList();
        str.Add(message);
        File.WriteAllLines(jsonPath, str);
    }
}
