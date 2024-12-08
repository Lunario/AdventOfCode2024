// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;

Console.WriteLine("Hello, World!");


TextReader tr = new StreamReader(@"Input.txt");

string Text = tr.ReadToEnd();

tr.Close();

int totalAmount = 0;



int startIndex = Text.IndexOf("mul(");

startIndex += 4; // add 4 so we also remove the 'mul(' part

Text = Text.Substring(startIndex, Text.Length - startIndex);



while (Text.Length > 0)
{
    

    int endIndex = Text.IndexOf(")");


    



    string subString = Text.Substring(0, endIndex);

    if (subString.Contains(","))
    {
        var splitString = subString.Split(',');

        int x = -1;
        int y = -1;

        if (splitString.Length == 2)
        {
            bool successA = int.TryParse(splitString[0].Trim(), out x);
            bool successB = int.TryParse(splitString[1].Trim(), out y);

            if (successA && successB)
            {
                Debug.WriteLine("Adding " + x + " * " + y);
                totalAmount += (x * y);
            }
        

        }
    }


    int beginIndex = Text.IndexOf("mul(");

    if (beginIndex == -1)
    {
        Text = "";
        continue;
    }
    beginIndex += 4; // add 4 so we also remove the 'mul(' part

    Text = Text.Substring(beginIndex, Text.Length - beginIndex);


}

Console.WriteLine("FoundTotal: " + totalAmount);
