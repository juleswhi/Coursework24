using static FamousLakesQuiz.SeverityType;
namespace FamousLakesQuiz;

public enum SeverityType {
    GREEN,
    ORANGE,
    RED
}

public static class Logger {
    private static readonly string _logPath = "logs.txt";
    private static readonly string _defaultHeader = "";

    public enum SeverityType {
        GREEN,
        ORANGE,
        RED
    }

    public static void Log(string message, SeverityType severity = GREEN) {
        severity switch {
            ORANGE => WriteToFile(message, "Medium Severity"),
            RED => WriteToFile(message, "Maximum Severity"),
            _ => WriteToFile(message),
        };
    }

    private void WriteToFile(string message, string header = _defaultHeader) {
        using (StreamWriter sw = new(_logPath, false)) {
            sw.WriteLine($"{header}: {message}");
        }
    }
}
