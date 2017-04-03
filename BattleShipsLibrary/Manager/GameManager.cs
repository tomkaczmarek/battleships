using BattleShipsLibrary.Fields;
using BattleShipsLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Manager
{
    public class GameManager
    {
        BattleArea Area { get; }

        public BattleArea MatchPlayerArea(BattleArea playerArea, BattleArea npcArea, Point targetPoint)
        {
            IField npcTarget = npcArea.BattleFields[targetPoint.X, targetPoint.Y].Field;

            if(npcTarget is ShipField)
            {
                playerArea.BattleFields[targetPoint.X, targetPoint.Y] = new BattleField(new ShipField(new RegularShip(true)));
            }
            else
            {
                playerArea.BattleFields[targetPoint.X, targetPoint.Y] = new BattleField(new MissField());
            }

            return null;
        }
    }
}
