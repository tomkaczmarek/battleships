using System;
using BattleShipsLibrary.Utils;
using BattleShipsLibrary.Manager;

namespace ShipsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = 11, w = 11;
            string input;

            GameShipManager shipManager = new GameShipManager();

            GameAreaManager npc = new GameAreaManager(new BattleArea(h, w), shipManager);
            npc.CreateArea();

            GameAreaManager player = new GameAreaManager(new BattleArea(h, w), shipManager);
            player.CreateEmptyArea();

            GameManager manager = new GameManager(DifficultLevel.Hard, npc);
            manager.Configure();
                      
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to BattleShip");
                Console.WriteLine("Please specify points to hit. (example A1)");
                Console.WriteLine();

                player.ShowArea();

                Console.WriteLine();
                Console.WriteLine("You hit: {0}/{1} ships.", player.ShipCount, npc.ShipCount);
                Console.WriteLine("Left {0} turns.", manager.LeftTurns);
                Console.WriteLine();

                manager.WinnerConditions(player.ShipCount, npc.ShipCount, manager.LeftTurns);

                if(!manager.IsGameOver)
                {
                    input = Console.ReadLine();

                    if(input.Length == 2)
                    {
                        manager.MatchPlayerArea(player.Area, npc.Area, input, npc.ShipContainer);
                        manager.EndTurn();
                    }
                }
                else
                {
                    Console.WriteLine();
                    npc.ShowArea();
                }

            }
            while (!manager.IsGameOver);

            Console.ReadLine();
        }
    }
}
