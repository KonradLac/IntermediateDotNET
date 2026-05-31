[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("LogAnalyzerTests")]

namespace LogAnalyzer;

internal class Program
{
    static void Main(string[] args)
    {
        LogFileCreator.CreateSampleLogFile("sample.log");
        Analyzer.Analyze("sample.log");
    }
}
