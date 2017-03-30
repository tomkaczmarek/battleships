using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleShipsLibrary.Utils;
using System.Drawing;

using BattleShipsLibrary.Helpers;

namespace BattleShipsLibrary.Makers
{
    public class ShipMaker : IShipMaker
    {
        public BattleArea Area { get; }
        public int Height { get; }
        public int Width { get; }
        private IAreaMaker maker;

        public ShipMaker(BattleArea area, IAreaMaker maker)
        {
            Area = area;
            Height = maker.Height;
            Width = maker.Width;
            this.maker = maker;
        }

        public void CreateBattleAreaWithShip()
        {
            //TODO make DI
            LinkedList<ShipBase> ships = new LinkedList<ShipBase>();
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
                        iArea = random.Next(1, Height - maker.Board);
                        jArea = random.Next(1, Width - maker.Board);
                        if (!Area.BattleFields[iArea, jArea].IsShip)
                        {
                            List<Point> shipPoints = new List<Point>();
                            DrawingType drawingType = DrawingMethod();
                            isEmpty = true;
                            Area.BattleFields[iArea, jArea].IsShip = true;
                            Area.BattleFields[iArea, jArea].Ship = new RegularShip(false);
                            shipPoints.Add(new Point(iArea, jArea));

                            for (int i = 1; i < ships.First.Value.Lenght; i++)
                            {
                                var iTemp = drawingType == DrawingType.Vertical ? iArea + i : iArea;
                                var jTemp = drawingType == DrawingType.Horizontal ? jArea + i : jArea;

                                if (Area.BattleFields[iTemp, jTemp].IsShip || Area.BattleFields[iTemp, jTemp].IsBound || Area.BattleFields[iTemp, jTemp].IsNearPointShip)
                                {
                                    isShipComplete = false;
                                    DeleteInCompleteShip(Area, shipPoints);
                                    break;
                                }
                                Area.BattleFields[iTemp, jTemp].IsShip = true;
                                Area.BattleFields[iTemp, jTemp].Ship = new RegularShip(false);
                                shipPoints.Add(new Point(iTemp, jTemp));
                            }

                            if (isShipComplete)
                            {
                                GeneratNearShipPoints(shipPoints, Area, drawingType);
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

        private DrawingType DrawingMethod()
        {
            CustomRandom r = new CustomRandom();
            return r.Next(1, 200) > 50 ? DrawingType.Vertical : DrawingType.Horizontal;
        }

        private void DeleteInCompleteShip(BattleArea area, List<Point> pointsToDelete)
        {
            foreach (Point p in pointsToDelete)
            {
                area.BattleFields[p.X, p.Y].IsShip = false;
                area.BattleFields[p.X, p.Y].Ship = null;
            }
        }

        private void GeneratNearShipPoints(List<Point> shipPoints, BattleArea area, DrawingType drawingType)
        {
            var firstElement = shipPoints[0];

            foreach (Point p in shipPoints)
            {
                int xTemp = drawingType == DrawingType.Horizontal ? p.X + 1 : p.X;
                int yTemp = drawingType == DrawingType.Vertical ? p.Y + 1 : p.Y;
                int xTempMinus = drawingType == DrawingType.Horizontal ? p.X - 1 : p.X;
                int yTempMinus = drawingType == DrawingType.Vertical ? p.Y - 1 : p.Y;

                area.BattleFields[xTemp, yTemp].IsNearPointShip = true;
                area.BattleFields[xTempMinus, yTempMinus].IsNearPointShip = true;

            }

            if(shipPoints.Count == 1)
            {
                Point point = shipPoints.First();
            }
        }


    }
    enum DrawingType
    {
        Vertical,
        Horizontal
    }
}
