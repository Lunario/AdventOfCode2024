// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



TextReader tr = new StreamReader(@"Input.txt");
List<int> ListA = new List<int>();
List<int> ListB = new List<int>();

string? line = null;
int saveLists = 0;
while ((line = tr.ReadLine()) != null)
{
    string[] stringLevels = line.Split(" ");
    bool isSafe = true;
    bool goingUp = int.Parse(stringLevels[0]) < int.Parse(stringLevels[1]);
    for(int i = 0; i < stringLevels.Length-1; i++)
    {
        
        int currentNumber = int.Parse(stringLevels[i]);
        int nextNumber = int.Parse(stringLevels[i+1]);

        if (currentNumber == nextNumber)
        {
            isSafe = false;
            break;
        }

        if (goingUp != currentNumber < nextNumber)
        {
            isSafe = false;
            break;
        }

        int difference = Math.Abs(currentNumber - nextNumber);

        if (difference > 3)
        {
            isSafe = false;
            break;
        }
    }
    if (isSafe)
    {
        saveLists++;
    }

}

Console.WriteLine("Safe Lists: " + saveLists);
