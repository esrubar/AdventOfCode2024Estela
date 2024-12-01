using Day1;

var (column1, column2) = (await Utils.ReadInputFileAsync()).ToColumns();

var totalDistance = 0;
var columnsLenght = column1.Count;
for (int i = 0; i < columnsLenght; i++)
{
    var result1 = column1.Min();
    var result2 = column2.Min();

    column1.Remove(result1);
    column2.Remove(result2);

    var distance = Math.Abs(result1 - result2);
    totalDistance += distance;

    Console.WriteLine($"{result1} - {result2} = {distance}");
}

Console.WriteLine(totalDistance);