// See https://aka.ms/new-console-template for more information
using System;
using System.ComponentModel;
using System.Diagnostics;

Console.WriteLine("Hello, World!");
TextReader tr = new StreamReader(@"Input.txt");

string? line = null;


List<string> horizontalList = new List<string>();




while ((line = tr.ReadLine()) != null)
{
    horizontalList.Add(line);
}

int totalOccurrences = 0;

for (int x = 0; x < horizontalList[0].Length; x++)
{
    for (int y = 0; y < horizontalList.Count; y++)
    {
        char currentChar = horizontalList[y][x];

        if (currentChar == 'A')
        {

            // check horizontal





            int startPointX = x - 1;
            int startPointY = y - 1;

            // topLeft to BotRight
            string foundString = "";

            for (int i = -1; i <= 1; i++)
            {
                int xLocation = x + i;
                int yLocation = y + i;

                if (xLocation < 0 || xLocation >= horizontalList[y].Length || yLocation < 0 || yLocation >= horizontalList.Count)
                {
                    continue;
                }

                foundString += horizontalList[yLocation][xLocation];



            }
            bool foundMas = false;
            if (foundString.Contains("MAS"))
            {
                foundMas = true;
            }
            else if (foundString.Contains("SAM"))
            {
                foundMas = true;
            }


            if (!foundMas) continue; // no need to checkc other side if there is also no mas on the first diagonal line..



            // topLeft to BotRight
            foundString = "";
            foundMas = false;
            for (int i = -1; i <= 1; i++)
            {
                int xLocation = x - i;
                int yLocation = y + i;

                if (xLocation < 0 || xLocation >= horizontalList[y].Length || yLocation < 0 || yLocation >= horizontalList.Count)
                {
                    continue;
                }

                foundString += horizontalList[yLocation][xLocation];



            }
            if (foundString.Contains("MAS"))
            {
                foundMas = true;
            }
            else if (foundString.Contains("SAM"))
            {
                foundMas = true;
            }

            if (foundMas)
            {
                totalOccurrences++;
            }

            //foundString = "";
            //for (int i = 0; i <= roomTopLeft + roomBotRight; i++)
            //{
            //    foundString += horizontalList[startPointX + i][startPointY+i];
            //}

            //if (foundString.Contains("XMAS"))
            //{
            //    totalOccurrences++;
            //}
            //if (foundString.Contains("SAMX"))
            //{
            //    totalOccurrences++;
            //}
            //startPointX = x - (roomBotLeft);
            //startPointY = y - (roomBotLeft);
            //foundString = "";


            //for (int i = 0; i <= roomTopRight + roomBotLeft; i++)
            //{
            //    foundString += horizontalList[startPointX + i][startPointY + i];
            //}


            //if (foundString.Contains("XMAS"))
            //{
            //    totalOccurrences++;
            //}
            //if (foundString.Contains("SAMX"))
            //{
            //    totalOccurrences++;
            //}




        }






    }
}

Console.WriteLine("Total Occurrences: " + totalOccurrences);

static int FindOccurences(string StringToSearch, string StringToFind)
{
    int StringIndex = StringToSearch.IndexOf(StringToFind);
    int totalOccurences = 0;
    while (StringIndex != -1)
    {
        StringIndex += StringToFind.Length;
        totalOccurences++;
        StringToSearch = StringToSearch.Substring(StringIndex, StringToSearch.Length - StringIndex);
        StringIndex = StringToSearch.IndexOf(StringToFind);
    }

    return totalOccurences;
}