using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Utils
{
    public abstract class ShipBase
    {
        public bool IsNearPointShip { get; set; }
        public int Lenght { get; set; }
        public bool IsDestroy { get; set; }

        public ShipBase(int lenght)
        {

        }

        public ShipBase(bool isDestroy)
        {

        }
    }
}
