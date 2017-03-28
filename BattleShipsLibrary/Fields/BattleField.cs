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

        public BattleField(bool ship)
        {
            IsShip = ship;
        }


    }
}
