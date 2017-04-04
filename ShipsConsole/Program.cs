using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipsLibrary.Makers;
using BattleShipsLibrary.Utils;
using BattleShipsLibrary.Fields;
using BattleShipsLibrary.Manager;
using System.Drawing;

namespace ShipsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = 9, w = 9;
            string input;
            GameAreaManager npc = new GameAreaManager(new BattleArea(h, w));
            npc.CreateArea();
            GameAreaManager player = new GameAreaManager(new BattleArea(h, w));
            player.CreateEmptyArea();
            GameManager manager = new GameManager(DifficultLevel.Hard, npc);
            manager.Configure();
            
            

            do
            {
                Console.Clear();

                player.ShowArea();

                Console.WriteLine();
                Console.WriteLine("Trafiłeś: {0}/{1} statków.", player.ShipCount, npc.ShipCount);
                Console.WriteLine("Pozostało {0} ruchów.", manager.LeftTurns);
                Console.WriteLine();

                manager.WinnerConditions(player.ShipCount, npc.ShipCount, manager.LeftTurns);

                if(!manager.IsGameOver)
                {
                    input = Console.ReadLine();

                    if(input.Length == 2)
                    {
                        manager.MatchPlayerArea(player.Area, npc.Area, input);
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
