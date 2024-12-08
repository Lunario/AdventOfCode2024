// See https://aka.ms/new-console-template for more information
using System.Reflection.PortableExecutable;

Console.WriteLine("Reading lists");


TextReader tr = new StreamReader(@"IDList.txt");
List<int> ListA = new List<int>();
List<int> ListB = new List<int>();

string? line = null;
while ((line = tr.ReadLine()) != null)
{

    string[] splitLine = line.Split("   ");

    //Console.WriteLine("A: " + splitLine[0] + " B: " + splitLine[1]);

    ListA.Add(int.Parse(splitLine[0]));
    ListB.Add(int.Parse(splitLine[1]));
    // do something with line
}

tr.Close();

Console.WriteLine($"Done reading list into string.. ListACCount '{ListA.Count}', listB.Count: '{ListB.Count}'");

Console.ReadLine();

Console.WriteLine("Sorting Lists..");

ListA = ListA.OrderBy(x => x).ToList();
ListB = ListB.OrderBy(x => x).ToList();

Console.WriteLine("Lists sorted..");

int totalDifference = 0;

for(int i = 0; i < ListA.Count; i++)
{
    int difference = ListA[i] - ListB[i];
    if (difference < 0) difference *= -1;
    totalDifference += difference;
}

Console.WriteLine("Total Difference: " +  totalDifference);