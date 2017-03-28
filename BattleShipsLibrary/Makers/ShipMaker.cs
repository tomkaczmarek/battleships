using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipsLibrary.Utils;

namespace BattleShipsLibrary.Makers
{
    public class ShipMaker : IShipMaker
    {
        public void CreateBattleAreaWithShip(BattleArea area)
        {
            //TODO make DI
            LinkedList<RegularShip> ships = new LinkedList<RegularShip>();
            for (int i = 5; i > 0; i--)
            {
                ships.AddFirst(new RegularShip(i));
            }
            do
            {
                ships.RemoveFirst();
            }
            while (ships.Count > 0);
        }
    }
}
