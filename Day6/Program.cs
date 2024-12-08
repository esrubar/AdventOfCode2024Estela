using Utils;

var textList = (await Utils.Utils.ReadInputFileAsync("../../../input.txt")).SplitByLineBreak();
var table = new char[textList[0].Length, textList[0].Length];
const char toUp = '^';
const char toDown = 'v';
const char toRight = '>';
const char toLeft = '<';
var flag = new Flag(false, false, false);
var totalPositions2 = 0;

// Fill table
for (int i = 0; i < textList.Count; i++)
{
    var lineCharacters = textList[i].ToCharArray();
    for (int j = 0; j < textList[0].Length; j++)
    {
        table[i, j] = lineCharacters[j];
    }
}

while (!flag.Final)
{
    flag = new Flag(false, false, false);
    for (int i = 0; i < table.GetLength(0) && !flag.FoundCharacter; i++)
    {
        for (int j = 0; j < table.GetLength(1) && !flag.FoundCharacter; j++)
        {
            var moved = false;

            var currentCharacter = table[i, j];
            table[i, j] = currentCharacter;

            while (!moved)
            {
                moved = currentCharacter switch
                {
                    toUp => LookUp(i, j, table, toUp, out flag),
                    toDown => LookDown(i, j, table, toDown, out flag),
                    toLeft => LookLeft(i, j, table, toLeft, out flag),
                    toRight => LookRight(i, j, table, toRight, out flag),
                    _ => true
                };
            }
        }
    }
}

for (int i = 0; i < table.GetLength(0); i++)
{
    for (int j = 0; j < table.GetLength(1); j++)
    {
        if (table[i, j] == 'X') totalPositions2++;
    }
}

Console.WriteLine(totalPositions2);
return;


static bool LookUp(int i, int j, char[,] table, char currentDirection, out Flag flag)
{
    try
    {
        var value = table[i - 1, j];
        if (value != '#')
        {
            table[i, j] = 'X';
            table[i - 1, j] = currentDirection;
            flag = new Flag(true, true, false);
        }
        else
        {
            table[i, j] = toRight;
            flag = new Flag(true, true, false);
        }
    }
    catch
    {
        table[i, j] = 'X';
        flag = new Flag(true, true, true);
    }
    return true;
}

static bool LookDown(int i, int j, char[,] table, char currentDirection, out Flag flag)
{
    try
    {
        var value = table[i + 1, j];
        if (value != '#')
        {
            table[i, j] = 'X';
            table[i + 1, j] = currentDirection;
            flag = new Flag(true, true, false);
        }
        else
        {
            table[i, j] = toLeft;
            flag = new Flag(true, true, false);
        }
    }
    catch
    {
        table[i, j] = 'X';
        flag = new Flag(true, true, true);
    }
    return true;
}

static bool LookLeft(int i, int j, char[,] table, char currentDirection, out Flag flag)
{
    try
    {
        var value = table[i, j - 1];
        if (value != '#')
        {
            table[i, j] = 'X';
            table[i, j - 1] = currentDirection;

            flag = new Flag(true, true, false);
        }
        else
        {
            table[i, j] = toUp;
            flag = new Flag(true, true, false);
        }
    }
    catch
    {
        table[i, j] = 'X';
        flag = new Flag(true, true, true);
    }
    return true;
}

static bool LookRight(int i, int j, char[,] table, char currentDirection, out Flag flag)
{
    try
    {
        var value = table[i, j + 1];
        if (value != '#')
        {
            table[i, j] = 'X';
            table[i, j + 1] = currentDirection;
            flag = new Flag(true, true, false);
        }
        else
        {
            table[i, j] = toDown;
            flag = new Flag(true, true, false);
        }
    }
    catch
    {
        table[i, j] = 'X';
        flag = new Flag(true, true, true);
    }
    return true;
}

