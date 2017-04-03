using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipsLibrary.Makers;
using BattleShipsLibrary.Utils;
using BattleShipsLibrary.Fields;
using BattleShipsLibrary.Manager;

namespace ShipsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = 9, w = 9;
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
                        area.BattleFields[i, j].Field.MakeField();

                        //BattleField field = area.BattleFields[i, j];

                        //if (field.IsBound)
                        //{
                        //    Console.Write('*');
                        //}
                        //else
                        //{
                        //    if (field.IsShip)
                        //    {
                        //        if(field.Ship.IsDestroy)
                        //        {
                        //            Console.WriteLine('X');
                        //        }
                        //        else
                        //        {
                        //            Console.Write('O');
                        //        }
                        //    }
                        //    else if(field.IsNearPointShip)
                        //    {
                        //        Console.Write(".");
                        //    }
                        //    else
                        //    {
                        //        Console.Write('-');
                        //    }
                        //}

                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
            while (true);

            

            
        }
    }
}
