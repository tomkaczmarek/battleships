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
        public ShipsContainer ShipContainer { get; set; }

        private IAreaMaker maker;

        public ShipMaker(BattleArea area, IAreaMaker maker, LinkedList<ShipBase> ships)
        {
            Area = area;
            Height = maker.Height;
            Width = maker.Width;
            this.maker = maker;
            Ships = ships;
            ShipContainer = new ShipsContainer();
        }

        public BattleArea CreateBattleAreaWithShip()
        {
            ShipContainer.Ships = new List<List<ShipBase>>();

            do
            {
                Random random = new Random();             
                bool isEmptyField, isShipComplete;
                int iArea, jArea;
                do
                {
                    isShipComplete = true;
                    do
                    {
                        isEmptyField = true;

                        iArea = random.Next(1, Height - maker.Board);
                        jArea = random.Next(1, Width - maker.Board);

                        Guid shipGuid = Guid.NewGuid();

                        if (!(Area.BattleFields[iArea, jArea].Field is ShipField) && !(Area.BattleFields[iArea, jArea].Field is NearPointShipField))
                        {
                            isEmptyField = false;
                            int _shipsFieldCount = 1;
                            List<ShipBase> ships = new List<ShipBase>();

                            List<Point> shipPoints = new List<Point>();
                            DrawingType drawingType = DrawingMethod();
                            ShipBase shipToField = new RegularShip(false, shipGuid) { ShipsPoints = new Point(iArea, jArea) };
                            Area.BattleFields[iArea, jArea] = new BattleField(new ShipField(shipToField));
                            ships.Add(shipToField);
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
                                _shipsFieldCount += 1;

                                shipToField = new RegularShip(false, shipGuid) { ShipsPoints = new Point(iTemp, jTemp) };
                                Area.BattleFields[iTemp, jTemp] = new BattleField(new ShipField(shipToField));
                                shipPoints.Add(new Point(iTemp, jTemp));
                                ships.Add(shipToField);
                                
                            }

                            if (isShipComplete)
                            {                               
                                GenerateNearShipPoints(shipPoints, Area, drawingType, ships);
                                ShipCount += _shipsFieldCount;
                                ShipContainer.Ships.Add(ships);
                            }
                        }
                    }
                    while (isEmptyField);
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
                area.BattleFields[p.X, p.Y] = new BattleField(new EmptyField(SymbolsContent.EmptyField));
            }
        }

        private void GenerateNearShipPoints(List<Point> shipPoints, BattleArea area, DrawingType drawingType, List<ShipBase> ships)
        {
            foreach (Point p in shipPoints)
            {
                ShipBase s = ships.Where(t => t.ShipsPoints.X == p.X && t.ShipsPoints.Y == p.Y).First();

                int xTemp = drawingType == DrawingType.Horizontal ? p.X + 1 : p.X;
                int yTemp = drawingType == DrawingType.Vertical ? p.Y + 1 : p.Y;
                int xTempMinus = drawingType == DrawingType.Horizontal ? p.X - 1 : p.X;
                int yTempMinus = drawingType == DrawingType.Vertical ? p.Y - 1 : p.Y;

                if (!(area.BattleFields[xTemp, yTemp].Field is BoundField) && !(area.BattleFields[xTemp, yTemp].Field is ShipField))
                {
                    area.BattleFields[xTemp, yTemp] = new BattleField(new NearPointShipField());
                    s.NearShipPoints.Add(new Point(xTemp, yTemp));
                }                   
                if (!(area.BattleFields[xTempMinus, yTempMinus].Field is BoundField) && !(area.BattleFields[xTempMinus, yTempMinus].Field is ShipField))
                {
                    area.BattleFields[xTempMinus, yTempMinus] = new BattleField(new NearPointShipField());
                    s.NearShipPoints.Add(new Point(xTempMinus, yTempMinus));
                }                   
            }

            Point point = shipPoints.First();
            Point lastPoint = shipPoints.Last();

            ShipBase sFirst = ships.Where(t => t.ShipsPoints.X == point.X && t.ShipsPoints.Y == point.Y).First();
            ShipBase lFirst = ships.Where(t => t.ShipsPoints.X == lastPoint.X && t.ShipsPoints.Y == lastPoint.Y).First();

            if (drawingType == DrawingType.Horizontal)
            {
                for (int i = -1; i < 2; i++)
                {
                    if (!(area.BattleFields[point.X + i, point.Y - 1].Field is BoundField))
                    {
                        area.BattleFields[point.X + i, point.Y - 1] = new BattleField(new NearPointShipField());
                        sFirst.NearShipPoints.Add(new Point(point.X + i, point.Y - 1));
                    }                     
                    if (!(area.BattleFields[lastPoint.X + i, lastPoint.Y + 1].Field is BoundField))
                    {
                        area.BattleFields[lastPoint.X + i, lastPoint.Y + 1] = new BattleField(new NearPointShipField());
                        lFirst.NearShipPoints.Add(new Point(lastPoint.X + i, lastPoint.Y + 1));
                    }                     
                }
            }
            else
            {
                for(int i =-1; i<2; i++)
                {
                    if (!(area.BattleFields[point.X - 1, point.Y + i].Field is BoundField))
                    {
                        area.BattleFields[point.X - 1, point.Y + i] = new BattleField(new NearPointShipField());
                        sFirst.NearShipPoints.Add(new Point(point.X - 1, point.Y + i));
                    }                      
                    if (!(area.BattleFields[lastPoint.X + 1, lastPoint.Y + i].Field is BoundField))
                    {
                        area.BattleFields[lastPoint.X + 1, lastPoint.Y + i] = new BattleField(new NearPointShipField());
                        lFirst.NearShipPoints.Add(new Point(lastPoint.X + 1, lastPoint.Y + i));
                    }                     
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
