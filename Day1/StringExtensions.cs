namespace Day1;

public static class StringExtensions
{
    private static readonly char[] Separator = [' '];

    public static (List<int> column1, List<int> column2) ToColumns(this string text)
    {
        var column1 = new List<int>();
        var column2 = new List<int>();

        var lines = text.Split(["\n", "\r"], StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            var parts = line.Split(Separator, StringSplitOptions.RemoveEmptyEntries);

            column1.Add(int.Parse(parts[0]));
            column2.Add(int.Parse(parts[1]));
        }

        return (column1, column2);
    }
}