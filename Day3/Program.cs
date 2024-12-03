using System.Text.RegularExpressions;

var text = await Utils.Utils.ReadInputFileAsync("../../../input.txt");

var mulMatches = Regex.Matches(text, @"\w*mul\(\d+,\d+\)");

var result = 0;
foreach (Match mulMatch in mulMatches)
{
    const string pattern = @"\d+";
    var numbers = Regex.Matches(mulMatch.Value, pattern);

    var multiplicationResult = Convert.ToInt16(numbers[0].Value) * Convert.ToInt16(numbers[1].Value);
    result += multiplicationResult;
}

Console.WriteLine(result);
