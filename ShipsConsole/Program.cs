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
            GameManager manager = new GameManager();
            npc.CreateArea();
            player.CreateEmptyArea();

            do
            {                            
                npc.ShowArea();             
                player.ShowArea();

                input = Console.ReadLine();
                points = input.Split(',');

                manager.MatchPlayerArea(player.Area, npc.Area, new Point(int.Parse(points[1]),int.Parse(points[0])));
            }
            while (true);                    
        }
    }
}
