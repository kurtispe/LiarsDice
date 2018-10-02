using LiarsDice.Library.Model;
using System;

namespace LiarsDice.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Game G = new Game(23,9);
           
            G.AddPlayer(G.CreatePlayer("Todd"));
            G.AddPlayer(G.CreatePlayer("Carl"));
            G.AddPlayer(G.CreatePlayer("Steve"));
            G.AddPlayer(G.CreatePlayer("Henry"));

            G.RollSequence();

            G.CalculateStats();

            Console.WriteLine(G.ReturnInfo("AboutPlayers"));
            Console.WriteLine(G.ReturnInfo());

            Console.WriteLine(G.SafeNumber);
            Console.WriteLine(G.ActiveDie);

            Console.Read();
        }
    }
}
