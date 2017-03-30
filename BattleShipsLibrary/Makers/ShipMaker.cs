using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipsLibrary.Utils;
using System.Drawing;

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
                ships.AddLast(new RegularShip(i));
            }
            //ships.AddFirst(new RegularShip(5));
            do
            {
                Random random = new Random();
                bool isEmpty, isShipComplete;
                int iArea, jArea;
                do
                {
                    isShipComplete = true;
                    do
                    {
                        isEmpty = false;
                        iArea = random.Next(1, 9);
                        jArea = random.Next(1, 9);
                        if (!area.BattleFields[iArea, jArea].IsShip)
                        {
                            List<Point> pointsToDelete = new List<Point>();
                            isEmpty = true;
                            area.BattleFields[iArea, jArea].IsShip = true;

                            pointsToDelete.Add(new Point(iArea, jArea));

                            for (int i = 1; i < ships.First.Value.Lenght; i++)
                            {
                                if (area.BattleFields[iArea + i, jArea].IsShip || area.BattleFields[iArea + i, jArea].IsBound)
                                {
                                    isShipComplete = false;
                                    foreach(Point p in pointsToDelete)
                                    {
                                        area.BattleFields[p.X, p.Y].IsShip = false;
                                    }
                                    break;
                                }
                                area.BattleFields[iArea + i, jArea].IsShip = true;

                                pointsToDelete.Add(new Point(iArea + i, jArea));
                            }
                        }
                    }
                    while (!isEmpty);
                }
                while (!isShipComplete);
                
                ships.RemoveFirst();
            }
            while (ships.Count > 0);
        }
    }
}
