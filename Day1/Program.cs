
var (column1, column2) = (await Utils.Utils.ReadInputFileAsync("../../../input.txt")).ToColumns();

var finalResult = 0;
var columnsLenght = column1.Count;
for (int i = 0; i < columnsLenght; i++)
{
    var element = column1[i];

    var result = column2.FindAll(x => x == element);

    finalResult += element * result.Count;
}
Console.WriteLine(finalResult);