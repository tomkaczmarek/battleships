using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Utils
{
    public abstract class ShipBase
    {
        //public bool IsNearPointShip { get; set; }
        public int Lenght { get; set; }
        public bool IsDestroy { get; set; }
        public Guid Guid { get; set; }
        public Point ShipsPoints { get; set; }
        public List<Point> NearShipPoints { get; set; }

        public ShipBase(int lenght)
        {
            NearShipPoints = new List<Point>();
        }

        public ShipBase(bool isDestroy, Guid guid)
        {
            IsDestroy = isDestroy;
            Guid = guid;
            NearShipPoints = new List<Point>();
        }
    }
}
