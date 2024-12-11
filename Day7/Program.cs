using Utils;

var textList = (await Utils.Utils.ReadInputFileAsync("../../../input.txt")).SplitByLineBreak();
var sum = (long)0;

foreach (var line in textList)
{
    var numbers = line.Split([" ", ":"], StringSplitOptions.RemoveEmptyEntries).ToList();
    var allNumbers = numbers.ToList();
    numbers.RemoveAt(0);
    var firstNumber = Convert.ToInt64(allNumbers[0]);

    var operations = GenerateOperations(numbers.Count - 1);

    foreach (var operador in operations)
    {
        var operador2 = operador.Split([" "], StringSplitOptions.RemoveEmptyEntries).ToList();
        var expresionList = new List<object>() { numbers[0] };
        for (int i = 0; i < operador2.Count; i++)
        {
            expresionList.Add(operador2[i]);
            expresionList.Add(numbers[i + 1]);
        }

        System.Data.DataTable dt = new();
        var result = expresionList[1].ToString() == "||"
            ? $"{expresionList[0]}{expresionList[2]}"
            : $"{expresionList[0]}{expresionList[1]}{expresionList[2]}";
        var operationResult = Convert.ToInt64(dt.Compute(result, ""));

        for (int i = 3; i < expresionList.Count - 1; i += 2)
        {
            var result2 = expresionList[i].ToString() == "||"
            ? $"{operationResult}{expresionList[i + 1]}.0"
            : $"{operationResult}{expresionList[i]}{expresionList[i + 1]}.0";
            operationResult = Convert.ToInt64(dt.Compute(result2, ""));
        }

        if (operationResult == firstNumber)
        {
            Console.WriteLine(firstNumber);
            sum += firstNumber;
            break;
        }
    }
}
Console.WriteLine("-------");
Console.WriteLine(sum);
return;

static List<string> GenerateOperations(int quantity)
{
    if (quantity == 0) return [""];
    var previous = GenerateOperations(quantity - 1);
    var combinations = new List<string>();

    foreach (var operation in previous)
    {
        combinations.Add(operation + " +");
        combinations.Add(operation + " *");
        combinations.Add(operation + " ||");
    }

    return combinations;
}