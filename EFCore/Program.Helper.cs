partial class Program
{
    static void SectionTitle(string title)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Yellow;
        WriteLine("*");
        WriteLine($"* {title}");
        WriteLine("*");
        ForegroundColor = previousColor;
    }


    static void Fail(string messag)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Red;
        WriteLine($"Failure: {messag}");
        ForegroundColor = previousColor;
    }

    static void Info(string messag)
    {
        ConsoleColor previousColor = ForegroundColor;
        ForegroundColor = ConsoleColor.Blue;
        WriteLine($"Info: {messag}");
        ForegroundColor = previousColor;
    }
}