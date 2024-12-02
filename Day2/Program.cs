var text = await Utils.Utils.ReadInputFileAsync("../../../input.txt");
string[] lines = text.Split(['\n', '\r'], StringSplitOptions.RemoveEmptyEntries);

var safeReports = 0;
foreach (string line in lines)
{
    int[] parts = Array.ConvertAll(line.Split([' '], StringSplitOptions.RemoveEmptyEntries), int.Parse);

    var unsafeRule = false;
    if (isFullAscendent(parts) == false && isFullDescendent(parts) == false)
    {
        unsafeRule = true;
    }
    if (unsafeRule is false) safeReports++;
}
Console.WriteLine(safeReports);

static bool isFullAscendent(int[] numbers)
{
    for (int i = 0; i < numbers.Length - 1; i++)
    {
        if (numbers[i] > numbers[i + 1] || Math.Abs(numbers[i] - numbers[i + 1]) > 3 || numbers[i] == numbers[i + 1])
            return false;
    }
    return true;
}

static bool isFullDescendent(int[] numbers)
{
    for (int i = 0; i < numbers.Length - 1; i++)
    {
        if (numbers[i] < numbers[i + 1] || Math.Abs(numbers[i] - numbers[i + 1]) > 3 || numbers[i] == numbers[i + 1])
            return false;
    }
    return true;
}

