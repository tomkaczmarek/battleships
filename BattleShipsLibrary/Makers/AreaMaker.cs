using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipsLibrary.Fields;
using BattleShipsLibrary.Utils;

namespace BattleShipsLibrary.Makers
{
    public class AreaMaker : IAreaMaker
    {
        public bool HasBoard { get; set; }
        public int Board
        {
            get
            {
                if(HasBoard)
                {
                    return 2;
                }
                return 0;
            }
        }

        public int Height { get;  }
        public int Width { get; }

        public AreaMaker(int height, int width, bool hasBoard)
        {
            HasBoard = hasBoard;
            Height = HasBoard ? height + Board : height;
            Width = HasBoard ? width + Board : width;
        }

        BattleArea IAreaMaker.CreateBattleArea()
        {
            BattleArea area = new BattleArea(Height, Width);

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (HasBoard && (j == 0 || i == 0 || j == Height - 1 || i == Width - 1))
                    {
                        area.BattleFields[i, j] = new BattleField() { IsBound = true };
                    }
                    else
                    {
                        area.BattleFields[i, j] = new BattleField();
                    }
                }
            }
            return area;
        }
    }
}
