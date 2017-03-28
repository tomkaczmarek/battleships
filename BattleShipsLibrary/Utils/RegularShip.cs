using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Utils
{
    public class RegularShip : ShipBase
    {
        public int Lenght { get; set; }

        public RegularShip(int lenght)
        {
            Lenght = lenght;
        }
    }
}
