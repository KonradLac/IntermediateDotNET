namespace LogAnalyzer;

internal static class LogFileCreator
{
    public static void CreateSampleLogFile(string filePath)
    {
        string[] logEntries =
        [
            "2024-06-01 12:00:00 | Info | Application started.",
            "2024-06-01 12:01:00 | Debug | Debugging information.",
            "2024-06-01 12:02:00 | Warning | Potential issue detected.",
            "2024-06-01 12:03:00 | Error | An error occurred.",
            "2024-06-01 12:04:00 | Info | Application stopped."
        ];
        File.WriteAllLines(filePath, logEntries);
    }

    public static void CreateEmptyLogFile(string filePath)
    {
        File.WriteAllText(filePath, string.Empty);
    }

    public static void CreateMalformedLogFile(string filePath)
    {
        string[] logEntries =
        [
            "2024-06-01 12:00:00 | Info | Application started.",
            "Malformed log entry without proper format",
            "2024-06-01 12:02:00 | Warning | Potential issue detected.",
            "2024-06-01 12:03:00 | Error | An error occurred."
        ];
        File.WriteAllLines(filePath, logEntries);
    }

    public static void CreateLogFileWithMissingFields(string filePath)
    {
        string[] logEntries =
        [
            "Debug | Debugging information.",
            "2024-06-01 12:02:00 | Potential issue detected.",
            "2024-06-01 12:03:00 | Error "
        ];
        File.WriteAllLines(filePath, logEntries);
    }
}
