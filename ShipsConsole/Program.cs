using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipsLibrary.Makers;
using BattleShipsLibrary.Utils;

namespace ShipsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = 19, w = 19;
            do
            {
                IAreaMaker gameMaker = new AreaMaker(h, w, true);
                BattleArea area = gameMaker.CreateBattleArea();
                IShipMaker shipMaker = new ShipMaker(area, gameMaker);
                shipMaker.CreateBattleAreaWithShip();              

                for (int i = 0; i < h + gameMaker.Board; i++)
                {
                    for (int j = 0; j < w + gameMaker.Board; j++)
                    {
                        if (area.BattleFields[i, j].IsBound)
                        {
                            Console.Write('*');
                        }
                        else
                        {
                            if (!area.BattleFields[i, j].IsShip)
                            {
                                Console.Write('-');
                            }
                            else
                            {
                                Console.Write('X');
                            }
                        }

                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
            while (true);

            

            
        }
    }
}
