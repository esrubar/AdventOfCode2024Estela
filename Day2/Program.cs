var text = await Utils.Utils.ReadInputFileAsync("../../../input.txt");
var lines = text.Split(["\n", "\r"], StringSplitOptions.RemoveEmptyEntries);

var safeReports = 0;
foreach (var line in lines)
{
    var parts = Array.ConvertAll(line.Split([" "], StringSplitOptions.RemoveEmptyEntries), int.Parse);

    var unsafeRule = !IsFullAscendant(parts) && !IsFullDescendent(parts);
    if (unsafeRule is false) safeReports++;
}
Console.WriteLine(safeReports);
return;

static bool IsFullAscendant(IReadOnlyList<int> numbers)
{
    for (var i = 0; i < numbers.Count - 1; i++)
    {
        var num1 = numbers[i];
        var num2 = numbers[i + 1];
        if (num1 > num2 || Math.Abs(num1 - num2) > 3 || num1 == num2)
            return false;
    }
    return true;
}

static bool IsFullDescendent(IReadOnlyList<int> numbers)
{
    for (var i = 0; i < numbers.Count - 1; i++)
    {
        var num1 = numbers[i];
        var num2 = numbers[i + 1];
        if (num1 < num2 || Math.Abs(num1 - num2) > 3 || num1 == num2)
            return false;
    }
    return true;
}

