using BattleShipsLibrary.Fields;
using BattleShipsLibrary.Makers;
using BattleShipsLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Manager
{
    public class GameAreaManager
    {
        public BattleArea Area { get; private set; }
        public int ShipCount { get; private set; }
        public GameShipManager ShipManager { get; set; }

        private IAreaMaker _areaMaker;

        public GameAreaManager(BattleArea area, GameShipManager shipManager)
        {
            Area = area;
            ShipManager = shipManager;
        }

        public void CreateEmptyArea()
        {
            _areaMaker = new AreaMaker(Area.Height, Area.Width, true);
            Area = _areaMaker.CreateBattleArea();
        }

        public void CreateArea()
        {
            CreateEmptyArea();
            IShipMaker shipMaker = new ShipMaker(Area, _areaMaker, ShipManager.CreateShips());
            Area = shipMaker.CreateBattleAreaWithShip();
            ShipCount = shipMaker.ShipCount;
        }

        public void ShowArea()
        {
            int count = 0;
            for (int i = 0; i < Area.Height; i++)
            {
                for (int j = 0; j < Area.Width; j++)
                {
                    Area.BattleFields[i, j].Field.MakeField();
                    if(Area.BattleFields[i, j].Field is ShipField)
                    {
                        count += 1;
                    }
                }
                Console.WriteLine();
            }
            ShipCount = count;
        }
    }
}
