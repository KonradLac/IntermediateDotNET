namespace LogAnalyzer;

using System.Linq;
internal static class Analyzer
{
    /// <summary>
    /// Parses a pipe-delimited log file and writes each valid log entry to the console.
    /// </summary>
    /// <remarks>Skips entries with invalid timestamps, unknown log levels, or missing message fields. If the
    /// file does not exist, writes a message to the console and returns.</remarks>
    /// <param name="logFilePath">Path to the log file to analyze.</param>
    internal static void Analyze(string logFilePath)
    {
        List<string> logFiles = Analyze(logFilePath, false).Select(entry => entry.ToString()).ToList();
        foreach (string logFile in logFiles)
        {
            Console.WriteLine(logFile);
        }
    }

    /// <summary>
    /// Parses the specified log file and returns a list of LogEntry objects.
    /// </summary>
    /// <remarks>Expects each line to contain fields separated by '|' in the order: timestamp, log level,
    /// message. Lines with unparsable timestamps, unknown log levels, or missing message fields are skipped. Timestamp
    /// parsing uses DateTime.TryParse and log level parsing uses Enum.TryParse for the LogLevel enum.</remarks>
    /// <param name="logFilePath">Path to the log file to parse.</param>
    /// <param name="writeToFile">If true, append each parsed entry to "analyzed_logs.txt" using the format "yyyy-MM-dd HH:mm:ss | {level} |
    /// {message}".</param>
    /// <returns>A list of parsed LogEntry objects. Returns an empty list if the file does not exist or no valid entries are
    /// found.</returns>
    public static List<LogEntry> Analyze(string logFilePath, bool writeToFile)
    {
        List<LogEntry> logEntries = [];
        if (!File.Exists(logFilePath))
        {
            Console.WriteLine($"Log file not found: {logFilePath}");
            return logEntries;
        }
        string[][] entryFieldsArray = File.ReadAllLines(logFilePath).Select(line => line.Split('|')).ToArray();
        foreach (string[] entryFields in entryFieldsArray)
        {
            if(entryFields.Length > 0) 
            {
                if(!DateTime.TryParse(entryFields[0].Trim(), out DateTime timestamp))
                {
                    continue;
                }
                if(!Enum.TryParse(entryFields[1].Trim(), out LogLevel level))
                {
                    continue;
                }
                if(entryFields.Length <= 2)
                {
                    continue;
                }
                string message = entryFields[2].Trim();
                if (writeToFile)
                {
                    string logEntryString = $"{timestamp:yyyy-MM-dd HH:mm:ss} | {level} | {message}";
                    File.AppendAllText("analyzed_logs.txt", logEntryString + Environment.NewLine);
                }
                LogEntry logEntry = new(timestamp, level, message);
                logEntries.Add(logEntry);
            }
        }
        return logEntries;
    }
}
