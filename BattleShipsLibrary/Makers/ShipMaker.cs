﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipsLibrary.Utils;
using System.Drawing;
using System.Security.Cryptography;

namespace BattleShipsLibrary.Makers
{
    public class ShipMaker : IShipMaker
    {
        public void CreateBattleAreaWithShip(BattleArea area)
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
                        iArea = random.Next(1, 9);
                        jArea = random.Next(1, 9);
                        if (!area.BattleFields[iArea, jArea].IsShip)
                        {
                            List<Point> pointsToDelete = new List<Point>();
                            DrawingType drawingType = DrawingMethod();
                            isEmpty = true;
                            area.BattleFields[iArea, jArea].IsShip = true;
                            pointsToDelete.Add(new Point(iArea, jArea));

                            for (int i = 1; i < ships.First.Value.Lenght; i++)
                            {
                                var iTemp = drawingType == DrawingType.Vertical ? iArea + i : iArea;
                                var jTemp = drawingType == DrawingType.Horizontal ? jArea + i : jArea;

                                if (area.BattleFields[iTemp, jTemp].IsShip || area.BattleFields[iTemp, jTemp].IsBound)
                                {
                                    isShipComplete = false;
                                    DeleteInCompleteShip(area, pointsToDelete);
                                    break;
                                }
                                area.BattleFields[iTemp, jTemp].IsShip = true;
                                pointsToDelete.Add(new Point(iTemp, jTemp));
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

        private void DeleteInCompleteShip(BattleArea area, List<Point> pointsToDelete)
        {
            foreach (Point p in pointsToDelete)
            {
                area.BattleFields[p.X, p.Y].IsShip = false;
            }
        }

        private DrawingType DrawingMethod()
        {
            CustomRandom r = new CustomRandom();
            return r.Next(1, 200) > 50 ? DrawingType.Vertical : DrawingType.Horizontal;
        }
    }
    enum DrawingType
    {
        Vertical,
        Horizontal
    }

    public class CustomRandom : RandomNumberGenerator
    {
        RandomNumberGenerator r;

        public CustomRandom()
        {
            r = RandomNumberGenerator.Create();
        }

        public override void GetBytes(byte[] data)
        {
            r.GetBytes(data);
        }

        public double NextDouble()
        {
            byte[] b = new byte[4];
            r.GetBytes(b);
            return (double)BitConverter.ToInt32(b, 0) / UInt32.MaxValue;
        }

        public int Next(int min, int max)
        {
            return (int)Math.Abs((Math.Round(NextDouble() * (max - min - 1))+ min));
        }

        
    }
}
