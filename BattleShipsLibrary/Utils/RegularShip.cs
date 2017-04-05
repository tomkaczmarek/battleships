using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Utils
{
    public class RegularShip : ShipBase
    {
        public RegularShip(int lenght) : base(lenght)
        {
            Lenght = lenght;
        }

        public RegularShip(bool isDestroy, Guid guid) : base(isDestroy, guid)
        {

        }
    }
}
