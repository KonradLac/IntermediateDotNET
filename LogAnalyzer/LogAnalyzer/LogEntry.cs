namespace LogAnalyzer;

internal record LogEntry
{
    public LogEntry(DateTime timestamp, LogLevel level, string message)
    {
        Timestamp = timestamp;
        Level = level;
        Message = message;
    }

    public DateTime Timestamp { get; init; }
    public LogLevel Level { get; init; } = LogLevel.Info;
    public string Message
    {
        get; init => field = value ?? string.Empty;
    }

    public override string ToString()
    {
        return $"{Timestamp:yyyy-MM-dd HH:mm:ss} | {Level} | {Message}";
    }
}
