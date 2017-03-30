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
            //for (int i = 5; i > 0; i--)
            //{
            //    ships.AddFirst(new RegularShip(i));
            //}
            ships.AddFirst(new RegularShip(5));
            do
            {
                Random random = new Random();
                bool isEmpty, isShipComplete;
                int iArea, jArea;
                do
                {
                    isEmpty = false;
                    iArea = random.Next(1, 9);
                    jArea = random.Next(1, 9);
                    if (!area.BattleFields[iArea, jArea].IsShip)
                    {
                        isEmpty = true;
                        area.BattleFields[iArea, jArea].IsShip = true;

                        for (int i = 1; i < ships.Last.Value.Lenght; i++)
                        {
                            isShipComplete = true;
                            if(area.BattleFields[iArea + i, jArea].IsShip || area.BattleFields[iArea + i, jArea].IsBound)
                            {
                                isShipComplete = false;
                                break;
                            }
                            area.BattleFields[iArea + i, jArea].IsShip = true;
                        }
                    }
                }
                while (!isEmpty);


                ships.RemoveFirst();
            }
            while (ships.Count > 0);
        }
    }
}
