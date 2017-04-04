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
            string[] points;
            string input;
            GameAreaManager npc = new GameAreaManager(new BattleArea(h, w));
            GameAreaManager player = new GameAreaManager(new BattleArea(h, w));
            GameManager manager = new GameManager(DifficultLevel.Easy, player);
            manager.Configure();
            npc.CreateArea();
            player.CreateEmptyArea();

            do
            {                            
                npc.ShowArea();             
                player.ShowArea();

                Console.WriteLine("Trafiłeś: {0}/{1} statków.", player.ShipCount, npc.ShipCount);
                Console.WriteLine("Pozostało {0} ruchów.", manager.LeftTurns);

                manager.WinnerConditions(player.ShipCount, npc.ShipCount, manager.LeftTurns);

                if(!manager.IsGameOver)
                {
                    input = Console.ReadLine();
                    points = input.Split(',');
                    manager.MatchPlayerArea(player.Area, npc.Area, new Point(int.Parse(points[1]), int.Parse(points[0])));

                    manager.EndTurn();
                }                          
            }
            while (!manager.IsGameOver);

            Console.ReadLine();
        }
    }
}
