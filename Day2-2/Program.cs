// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



TextReader tr = new StreamReader(@"Input.txt");
List<int> ListA = new List<int>();
List<int> ListB = new List<int>();

string? line = null;
int saveLists = 0;
while ((line = tr.ReadLine()) != null)
{
    var stringLevels = line.Split(" ").ToList();
    int error = FindError(stringLevels);

    if (error == -1)
    {
        saveLists++;
        continue;
    }

    for(int i = 0; i < stringLevels.Count; i++)
    {
        var ListToCheck = stringLevels.ToList();
        ListToCheck.RemoveAt(i);
        error = FindError(ListToCheck);
        if (error == -1)
        {
            saveLists++;
            break;
        }
    }

    
}

Console.WriteLine("Safe Lists: " + saveLists); // 689


int FindError(List<string> stringLevels)
{
    bool isSafe = true;
    bool goingUp = int.Parse(stringLevels[0]) < int.Parse(stringLevels[1]);
    for (int i = 0; i < stringLevels.Count - 1; i++)
    {
        int currentNumber = int.Parse(stringLevels[i]);
        int nextNumber = int.Parse(stringLevels[i + 1]);
        if (currentNumber == nextNumber)
        {
            return i+1;
        }
        if (goingUp != currentNumber < nextNumber)
        {
            return i+1;
        }
        int difference = Math.Abs(currentNumber - nextNumber);

        if (difference > 3)
        {
            return i+1;
        }
    }
    return -1;
}