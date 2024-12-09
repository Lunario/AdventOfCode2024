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

for(int x = 0; x < horizontalList[0].Length; x++)
{
    for(int y = 0; y < horizontalList.Count; y++)
    {
        char currentChar = horizontalList[y][x];

        if (currentChar == 'X')
        {

            // check horizontal

            int leftPoint = Math.Clamp(x-3, 0, horizontalList[0].Length-1);
            int rightPoint = Math.Clamp(x+3, 0, horizontalList[0].Length - 1);
            string foundString = "";
            for (int i = leftPoint; i <= rightPoint; i++)
            {
                foundString += horizontalList[y][i];
            }
            if (foundString.Contains("XMAS"))
            {
                totalOccurrences++;
            }
            if (foundString.Contains("SAMX"))
            {
                totalOccurrences++;
            }


            // check vertical
            int topPoint = Math.Clamp(y - 3, 0, horizontalList.Count- 1);
            int botPoint = Math.Clamp(y + 3, 0, horizontalList.Count - 1);
            foundString = "";
            for (int i = topPoint; i <= botPoint ; i++)
            {
                foundString += horizontalList[i][x];
            }
            if (foundString.Contains("XMAS"))
            {
                totalOccurrences++;
            }
            if (foundString.Contains("SAMX"))
            {
                totalOccurrences++;
            }

            // Check Diagonal
            int startPointX = x - 3;
            int startPointY = y - 3;

            // topLeft to BotRight
            foundString = "";

            for (int i = -3; i <= 3; i++)
            {
                int xLocation = x + i;
                int yLocation = y + i;

                if (xLocation < 0 || xLocation >= horizontalList[y].Length || yLocation < 0 || yLocation >= horizontalList.Count)
                {
                    continue;
                }

                foundString += horizontalList[yLocation][xLocation];



            }
            if (foundString.Contains("XMAS"))
            {
                totalOccurrences++;
            }
            if (foundString.Contains("SAMX"))
            {
                totalOccurrences++;
            }



            // topLeft to BotRight
            foundString = "";

            for (int i = -3; i <= 3; i++)
            {
                int xLocation = x - i;
                int yLocation = y + i;

                if (xLocation < 0 || xLocation >= horizontalList[y].Length || yLocation < 0 || yLocation >= horizontalList.Count)
                {
                    continue;
                }

                foundString += horizontalList[yLocation][xLocation];



            }
            if (foundString.Contains("XMAS"))
            {
                totalOccurrences++;
            }
            if (foundString.Contains("SAMX"))
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