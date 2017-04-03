using BattleShipsLibrary.Makers;
using BattleShipsLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Manager
{
    public class GameManager
    {
        public BattleArea Area { get; }

        public GameManager(BattleArea area)
        {
            Area = area;
        }

        public void CreateArea()
        {
            IAreaMaker gameMaker = new AreaMaker(Area.Height, Area.Width, true);
            BattleArea area = gameMaker.CreateBattleArea();
            IShipMaker shipMaker = new ShipMaker(area, gameMaker);
            shipMaker.CreateBattleAreaWithShip();
        }
    }
}
