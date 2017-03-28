﻿using BattleShipsLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Fields
{
    public class BattleField
    {
        public ShipBase Ship { get; set; }

        public BattleField(ShipBase ship)
        {
            Ship = ship;
        }
    }
}
