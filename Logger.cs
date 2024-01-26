namespace FamousLakesQuiz;

public enum SeverityType {
    GREEN,
    ORANGE,
    RED
}

public static class Logger {
    private static readonly string _logPath = "logs.txt";
    private const string _defaultHeader = "";

    public static void Log(string message) {
        Log(message, GREEN);
    }

    public static void Log(string message, SeverityType severity)
    {
        switch (severity) {
            case ORANGE: WriteToFile(message, "Medium Severity"); break;
            case RED: WriteToFile(message, "Maximum Severity"); break;
            default: WriteToFile(message); break;
        };
    }

    private static void WriteToFile(string message, string header = _defaultHeader)
    {
        using (StreamWriter sw = new(_logPath, false)) {
            sw.WriteLine($"{header}: {message}");
        }
    }
}
