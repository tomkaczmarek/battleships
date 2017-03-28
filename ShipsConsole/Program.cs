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
            IGameMaker gameMaker = new GameMaker();
            var area = gameMaker.CreateBattleArea();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if(area.BattleFields[i,j].Ship != null)
                    {
                        Console.Write('X');
                    }
                    else
                    {
                        Console.Write('-');
                    }
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
