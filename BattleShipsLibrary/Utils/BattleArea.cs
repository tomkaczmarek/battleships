using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipsLibrary.Fields;

namespace BattleShipsLibrary.Utils
{
    public class BattleArea
    {
        public BattleField[,] BattleFields { get; set; }
        public int Height { get; }
        public int Width { get; }

        public BattleArea(int height, int width)
        {
            BattleFields = new BattleField[height, width];
            Height = height;
            Width = width;
        }
    }
}
