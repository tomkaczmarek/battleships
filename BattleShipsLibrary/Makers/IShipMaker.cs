using BattleShipsLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Makers
{
    public interface IShipMaker
    {
        int Height { get; }
        int Width { get; }
        BattleArea Area { get; }
        BattleArea CreateBattleAreaWithShip();
        int ShipCount { get; set; }
        ShipsContainer ShipContainer { get; set; }
    }
}
