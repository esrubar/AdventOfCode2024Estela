var text = await Utils.Utils.ReadInputFileAsync("../../../input.txt");
var splitedText = text.Split(new[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);

var columns = splitedText[0].Split(new[] { "\r", "\n", "|" }, StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(int.Parse);
var rows = splitedText[1].Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

var sumResults = 0;
var dictionary = new Dictionary<int, List<int>>();

foreach (var row in rows)
{
    var numbers = row.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(int.Parse);
    foreach (var number in numbers)
    {
        if (dictionary.ContainsKey(number)) continue;

        dictionary[number] = [];
        for (int i = 0; i < columns.Count; i++)
        {
            if (columns[i] == number)
            {
                dictionary[number].Add(i);
            }
        }
    }
}

for (int i = 0; i < rows.Count; i++)
{
    var numbers = rows[i].Split(",", StringSplitOptions.RemoveEmptyEntries).ToList().ConvertAll(int.Parse);
    var result = new List<int>();
    var visited = new HashSet<int>();

    foreach (var number in numbers)
    {
        ProcessNumbers(number, visited, result, numbers);
    }
    result.Reverse();

    if (!result.SequenceEqual(numbers))
    {
        var middle = result.Count / 2;
        var numberInMiddle = result[middle];
        sumResults += numberInMiddle;
    }
}
Console.WriteLine(sumResults);
return;

void ProcessNumbers(int number, HashSet<int> visited, List<int> result, List<int> numbers)
{
    if (visited.Contains(number))
        return;

    visited.Add(number);

    if (!dictionary.TryGetValue(number, out var numbersList))
    {
        result.Add(number);
        return;
    }

    var evenNumbers = numbersList.Where(x => x % 2 == 0).ToList();

    if (evenNumbers.Count == 0)
    {
        result.Add(number);
        return;
    }

    foreach (var evenNumber in evenNumbers)
    {
        if (evenNumber >= columns.Count - 1)
            continue;

        var nextColumn = columns[evenNumber + 1];

        if (numbers.Contains(nextColumn))
        {
            ProcessNumbers(nextColumn, visited, result, numbers);
        }
    }

    if (!result.Contains(number))
        result.Add(number);
}
