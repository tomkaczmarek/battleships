using BattleShipsLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Fields
{
    public class ShipField : IField
    {
        public ShipBase ShipType { get; set; }

        public ShipField(ShipBase ship)
        {
            ShipType = ship;
        }

        public void MakeField()
        {
            Console.Write("O");
        }
    }
}
