namespace log;

class Program
{
    static void Main(string[] args)
    {
        string[] sentences = { "New line 1", "New line 2" };
        FFManagement.ReadFile(@"c:\temp\WriteTextAsync.txt");
    }
}
