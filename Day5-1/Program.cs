// See https://aka.ms/new-console-template for more information
using System.Numerics;
using System.Threading.Tasks.Dataflow;

Console.WriteLine("Hello, World!");
TextReader tr = new StreamReader(@"Input.txt");

string? line = null;




bool copyingRules = true;

Console.WriteLine("Reading Input.txt, reading rules..");


Dictionary<string, List<string>> rules = new Dictionary<string, List<string>>();
List<string[]> PageLists = new List<string[]>();

while ((line = tr.ReadLine()) != null)
{
    if (copyingRules)
    {
        // first Part of txt



        if (!line.Equals(""))
        {// reading Rules
            string[] newRule = line.Split('|');
            if (!rules.ContainsKey(newRule[0]))
            {   // if no rules are known yet for our key, add a new key to the dictionary...
                rules.Add(newRule[0], new List<string>());
            }

            if (!rules[newRule[0]].Contains(newRule[1]))
            {
                rules[newRule[0]].Add(newRule[1]);
            }


        }
        else
        {
            // if we reach our empty line, switch to reading our PageLists
            copyingRules = false;
            Console.WriteLine($"done reading rules({rules.Count}), reading PageLists");
        }
    }
    else
    {
        string[] pageOrder = line.Split(",");

        PageLists.Add(pageOrder);


        // second part of txt 
    }
}

Console.WriteLine($"done reading PageLists({PageLists.Count}), Checking Order");

int totalOrders = 0;

for (int pageListIndex = 0; pageListIndex < PageLists.Count; pageListIndex++)
{// loop for all the print orders

    bool OrderOK = true;


    string[] currentOrder = PageLists[pageListIndex];

    for (int pageIndex = 0; pageIndex < currentOrder.Length; pageIndex++)
    {// loop for the Pages
        string CurrentPage = currentOrder[pageIndex];


        for (int CheckIndex = pageIndex + 1; CheckIndex < currentOrder.Length; CheckIndex++)
        {
            if (!rules[CurrentPage].Contains(currentOrder[CheckIndex]))
            {
                OrderOK = false; break;
            }
        }
    }

    if (OrderOK)
    {
        totalOrders += int.Parse(currentOrder[currentOrder.Length/2]);
    }
}

Console.WriteLine($"amount of Orders OK: " + totalOrders);
