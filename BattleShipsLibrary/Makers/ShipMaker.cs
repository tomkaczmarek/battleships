using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleShipsLibrary.Utils;
using System.Drawing;

using BattleShipsLibrary.Helpers;
using BattleShipsLibrary.Fields;

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
                        if (!(Area.BattleFields[iArea, jArea].Field is ShipField))
                        {
                            List<Point> shipPoints = new List<Point>();
                            DrawingType drawingType = DrawingMethod();
                            isEmpty = true;
                            Area.BattleFields[iArea, jArea] = new BattleField(new ShipField(new RegularShip(false)));
                            shipPoints.Add(new Point(iArea, jArea));

                            for (int i = 1; i < ships.First.Value.Lenght; i++)
                            {
                                var iTemp = drawingType == DrawingType.Vertical ? iArea + i : iArea;
                                var jTemp = drawingType == DrawingType.Horizontal ? jArea + i : jArea;

                                if (Area.BattleFields[iTemp, jTemp].Field is ShipField || Area.BattleFields[iTemp, jTemp].Field is BoundField || Area.BattleFields[iTemp, jTemp].Field is NearPointShipField)
                                {
                                    isShipComplete = false;
                                    DeleteInCompleteShip(Area, shipPoints);
                                    break;
                                }
                                Area.BattleFields[iTemp, jTemp] = new BattleField(new ShipField(new RegularShip(false)));
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
                area.BattleFields[p.X, p.Y] = new BattleField(new EmptyField());
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

                area.BattleFields[xTemp, yTemp] = new BattleField(new NearPointShipField());
                area.BattleFields[xTempMinus, yTempMinus] = new BattleField(new NearPointShipField());
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
