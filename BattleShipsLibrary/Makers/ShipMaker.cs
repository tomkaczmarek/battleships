using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleShipsLibrary.Utils;
using System.Drawing;
using BattleShipsLibrary.Helpers;
using BattleShipsLibrary.Fields;
using BattleShipsLibrary.Manager;

namespace BattleShipsLibrary.Makers
{
    public class ShipMaker : IShipMaker
    {
        public BattleArea Area { get; }
        public int Height { get; }
        public int Width { get; }
        public int ShipCount { get; set; }
        public LinkedList<ShipBase> Ships { get; set; }

        private IAreaMaker maker;

        public ShipMaker(BattleArea area, IAreaMaker maker, LinkedList<ShipBase> ships)
        {
            Area = area;
            Height = maker.Height;
            Width = maker.Width;
            this.maker = maker;
            Ships = ships;
        }

        public BattleArea CreateBattleAreaWithShip()
        {
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
                        if (!(Area.BattleFields[iArea, jArea].Field is ShipField) && !(Area.BattleFields[iArea, jArea].Field is NearPointShipField))
                        {
                            List<Point> shipPoints = new List<Point>();
                            DrawingType drawingType = DrawingMethod();
                            int _shipsFieldCount = 1;
                            isEmpty = true;
                            Area.BattleFields[iArea, jArea] = new BattleField(new ShipField(new RegularShip(false)));
                            shipPoints.Add(new Point(iArea, jArea));

                            for (int i = 1; i < Ships.First.Value.Lenght; i++)
                            {
                                var iTemp = drawingType == DrawingType.Vertical ? iArea + i : iArea;
                                var jTemp = drawingType == DrawingType.Horizontal ? jArea + i : jArea;

                                if (Area.BattleFields[iTemp, jTemp].Field is ShipField || Area.BattleFields[iTemp, jTemp].Field is BoundField || Area.BattleFields[iTemp, jTemp].Field is NearPointShipField)
                                {
                                    _shipsFieldCount = 0;
                                    isShipComplete = false;
                                    DeleteInCompleteShip(Area, shipPoints);
                                    break;
                                }
                                Area.BattleFields[iTemp, jTemp] = new BattleField(new ShipField(new RegularShip(false)));
                                shipPoints.Add(new Point(iTemp, jTemp));
                                _shipsFieldCount += 1;
                            }

                            if (isShipComplete)
                            {
                                GeneratNearShipPoints(shipPoints, Area, drawingType);
                                ShipCount += _shipsFieldCount;
                            }
                        }
                    }
                    while (!isEmpty);
                }
                while (!isShipComplete);

                Ships.RemoveFirst();
            }
            while (Ships.Count > 0);
           
            return Area;
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
                area.BattleFields[p.X, p.Y] = new BattleField(new EmptyField());
            }
        }

        private void GeneratNearShipPoints(List<Point> shipPoints, BattleArea area, DrawingType drawingType)
        {
            foreach (Point p in shipPoints)
            {
                int xTemp = drawingType == DrawingType.Horizontal ? p.X + 1 : p.X;
                int yTemp = drawingType == DrawingType.Vertical ? p.Y + 1 : p.Y;
                int xTempMinus = drawingType == DrawingType.Horizontal ? p.X - 1 : p.X;
                int yTempMinus = drawingType == DrawingType.Vertical ? p.Y - 1 : p.Y;

                if (!(area.BattleFields[xTemp, yTemp].Field is BoundField) && !(area.BattleFields[xTemp, yTemp].Field is ShipField))
                    area.BattleFields[xTemp, yTemp] = new BattleField(new NearPointShipField());
                if (!(area.BattleFields[xTempMinus, yTempMinus].Field is BoundField) && !(area.BattleFields[xTempMinus, yTempMinus].Field is ShipField))
                    area.BattleFields[xTempMinus, yTempMinus] = new BattleField(new NearPointShipField());
            }

            Point point = shipPoints.First();
            Point lastPoint = shipPoints.Last();
            if (drawingType == DrawingType.Horizontal)
            {
                for (int i = -1; i < 2; i++)
                {
                    if (!(area.BattleFields[point.X + i, point.Y - 1].Field is BoundField))
                        area.BattleFields[point.X + i, point.Y - 1] = new BattleField(new NearPointShipField());
                    if (!(area.BattleFields[lastPoint.X + i, lastPoint.Y + 1].Field is BoundField))
                        area.BattleFields[lastPoint.X + i, lastPoint.Y + 1] = new BattleField(new NearPointShipField());
                }
            }
            else
            {
                for(int i =-1; i<2; i++)
                {
                    if (!(area.BattleFields[point.X - 1, point.Y + i].Field is BoundField))
                        area.BattleFields[point.X -1 , point.Y + i] = new BattleField(new NearPointShipField());
                    if (!(area.BattleFields[lastPoint.X + 1, lastPoint.Y + i].Field is BoundField))
                        area.BattleFields[lastPoint.X + 1, lastPoint.Y + i] = new BattleField(new NearPointShipField());
                }
            }
        }


    }
    enum DrawingType
    {
        Vertical,
        Horizontal
    }
}
