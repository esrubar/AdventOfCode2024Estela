
using Day1;

var (column1, column2) = (await Utils.Utils.ReadInputFileAsync("../../../input.txt")).ToColumns();

var finalResult = 0;
var columnsLength = column1.Count;
for (var i = 0; i < columnsLength; i++)
{
    var element = column1[i];

    var result = column2.FindAll(x => x == element);

    finalResult += element * result.Count;
}
Console.WriteLine(finalResult);