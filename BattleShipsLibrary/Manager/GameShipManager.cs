using BattleShipsLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Manager
{
    public class GameShipManager
    {
        public LinkedList<ShipBase> CreateShips()
        {
            LinkedList<ShipBase> ships = new LinkedList<ShipBase>();
            ships.AddLast(new RegularShip(5));
            ships.AddLast(new RegularShip(4));
            ships.AddLast(new RegularShip(3));
            ships.AddLast(new RegularShip(3));
            ships.AddLast(new RegularShip(2));
            return ships;
        }
    }
}
