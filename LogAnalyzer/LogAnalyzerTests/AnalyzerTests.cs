using LogAnalyzer;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace LogAnalyzerTests;

public class AnalyzerTests
{
    [Fact]
    public void NotEmptyTest()
    {
        if(File.Exists("test.log"))
        {
            File.Delete("test.log");
        }
        LogFileCreator.CreateSampleLogFile("test.log");
        List<LogEntry> logEntries = Analyzer.Analyze("test.log", false);
        Assert.NotEmpty(logEntries);
    }

    [Fact]
    public void EmptyLogFileTest()
    {
        if (File.Exists("test.log"))
        {
            File.Delete("test.log");
        }
        LogFileCreator.CreateEmptyLogFile("test.log");
        List<LogEntry> logEntries = Analyzer.Analyze("test.log", false);
        Assert.Empty(logEntries);
    }

    [Fact]
    public void MalformedLogFileTest()
    {
        if (File.Exists("test.log"))
        {
            File.Delete("test.log");
        }
        LogFileCreator.CreateMalformedLogFile("test.log");
        List<LogEntry> logEntries = Analyzer.Analyze("test.log", false);
        Assert.Equal(3, logEntries.Count);
    }

    [Fact]
    public void LogFileWithMissingFieldsTest()
    {
        if (File.Exists("test.log"))
        {
            File.Delete("test.log");
        }
        LogFileCreator.CreateLogFileWithMissingFields("test.log");
        List<LogEntry> logEntries = Analyzer.Analyze("test.log", false);
        Assert.Empty(logEntries);
    }

    [Fact]
    public void NumberOfLogEntriesTest()
    {
        if (File.Exists("test.log"))
        {
            File.Delete("test.log");
        }
        if(File.Exists("analyzed_logs.txt"))
        {
            File.Delete("analyzed_logs.txt");
        }
        LogFileCreator.CreateSampleLogFile("test.log");
        List<LogEntry> expectedEntries = Analyzer.Analyze("test.log", true);
        List<LogEntry> secondLogEntries = Analyzer.Analyze("analyzed_logs.txt", false);
        Assert.Equal(expectedEntries.Count, secondLogEntries.Count);
    }

    [Fact]
    public void LogEntryContentTest()
    {
        if (File.Exists("test.log"))
        {
            File.Delete("test.log");
        }
        if(File.Exists("analyzed_logs.txt"))
        {
            File.Delete("analyzed_logs.txt");
        }
        LogFileCreator.CreateSampleLogFile("test.log");
        List<LogEntry> expectedEntries = Analyzer.Analyze("test.log", true);
        List<LogEntry> secondLogEntries = Analyzer.Analyze("analyzed_logs.txt", false);
        for (int i = 0; i < expectedEntries.Count; i++)
        {
            Assert.Equal(expectedEntries[i].Timestamp, secondLogEntries[i].Timestamp);
            Assert.Equal(expectedEntries[i].Level, secondLogEntries[i].Level);
            Assert.Equal(expectedEntries[i].Message, secondLogEntries[i].Message);
        }
    }

    [Fact]
    public void NonExistentFileTest()
    {
        if (File.Exists("nonexistent.log"))
        {
            File.Delete("nonexistent.log");
        }
        List<LogEntry> logEntries = Analyzer.Analyze("nonexistent.log", false);
        Assert.Empty(logEntries);
    }

    [Fact]
    public void AnalyzeDisplayTest()
    {
        if(File.Exists("test.log"))
        {
            File.Delete("test.log");
        }
        LogFileCreator.CreateSampleLogFile("test.log");
    }
}
