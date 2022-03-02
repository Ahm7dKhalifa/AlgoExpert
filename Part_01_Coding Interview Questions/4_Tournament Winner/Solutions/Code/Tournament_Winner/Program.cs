using System;
using System.Collections.Generic;
using Tournament_Winner.MySolutions;

namespace Tournament_Winner
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new FirstSolution_UsingHashTable();

            List<List<string>> competetions = new List<List<string>>();
            List<string> list1 = new List<string>();
            list1.Add("html");
            list1.Add("c#");
            List<string> list2 = new List<string>();
            list2.Add("c#");
            list2.Add("python");
            List<string> list3 = new List<string>();
            list3.Add("python");
            list3.Add("c#");

            competetions.Add(list1);
            competetions.Add(list2);
            competetions.Add(list3);

            List<int> results = new List<int>();
            results.Add(0);
            results.Add(0);
            results.Add(1);

            sol.TournamentWinner(competetions,results);

        }
    }
}
