using Utils;

var textList = (await Utils.Utils.ReadInputFileAsync("../../../input.txt")).SplitByLineBreak();
var sum = (long)0;

foreach (var line in textList)
{
    var numbers = line.Split([" ", ":"], StringSplitOptions.RemoveEmptyEntries).ToList();
    var allNumbers = numbers.ToList();
    numbers.RemoveAt(0);
    var firstNumber = Convert.ToInt64(allNumbers[0]);

    var operadores = GenerateOperations(numbers.Count - 1);

    foreach (var operador in operadores)
    {
        var expresionList = new List<object>() { numbers[0] };
        for (int i = 0; i < operador.Length; i++)
        {
            expresionList.Add(operador[i]);
            expresionList.Add(numbers[i + 1]);
        }

        System.Data.DataTable dt = new();
        var firstResult = $"{expresionList[0]}{expresionList[1]}{expresionList[2]}";
        var operationResult = Convert.ToInt64(dt.Compute(firstResult, ""));

        for (int i = 3; i < expresionList.Count - 1; i += 2)
        {
            var result = $"{operationResult}{expresionList[i]}{expresionList[i + 1]}.0";
            operationResult = Convert.ToInt64(dt.Compute(result, ""));
        }

        if (operationResult == firstNumber)
        {
            sum += firstNumber;
            break;
        }
    }
}
Console.WriteLine(sum);
return;

static List<string> GenerateOperations(int quantity)
{
    if (quantity == 0) return [""]; // Caso base
    var previous = GenerateOperations(quantity - 1);
    var combinations = new List<string>();

    foreach (var operation in previous)
    {
        combinations.Add(operation + "+");
        combinations.Add(operation + "*");
    }
    return combinations;
}