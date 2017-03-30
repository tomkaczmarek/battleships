using BattleShipsLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Fields
{
    public class BattleField
    {
        public bool IsShip { get; set; }
        public bool IsNearPointShip { get; set; }
        public bool IsBound { get; set; }
        public bool IsVisited { get; set; }
        public ShipBase Ship { get; set; }

        public BattleField()
        {

        }


    }
}
