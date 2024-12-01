public static class StringExtensions
{
    public static (List<int> column1, List<int> column2) ToColumns(this string text)
    {
        var column1 = new List<int>();
        var column2 = new List<int>();

        string[] lines = text.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);

        foreach (string line in lines)
        {
            string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            column1.Add(int.Parse(parts[0]));
            column2.Add(int.Parse(parts[1]));
        }

        return (column1, column2);
    }
}