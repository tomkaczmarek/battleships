using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipsLibrary.Makers;

namespace ShipsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IAreaMaker gameMaker = new AreaMaker();
            var area = gameMaker.CreateBattleArea();
            IShipMaker shipMaker = new ShipMaker();
            shipMaker.CreateBattleAreaWithShip(area);

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if(area.BattleFields[i,j].IsBound)
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
    }
}
