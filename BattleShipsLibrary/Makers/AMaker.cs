using BattleShipsLibrary.Fields;
using BattleShipsLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Makers
{
    public class AMaker : MakerBase
    {
        public bool HasBoard { get; set; }

        public int Board
        {
            get
            {
                if (HasBoard)
                {
                    return 2;
                }
                return 0;
            }
        }

        public AMaker(int height, int width, bool hasBoard, BattleArea area)
        {
            HasBoard = hasBoard;
            Height = HasBoard ? height + Board : height;
            Width = HasBoard ? width + Board : width;
            Area = area;
        }

        public override void Create()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (HasBoard && (j == 0 || i == 0 || j == Height - 1 || i == Width - 1))
                    {
                        Area.BattleFields[i, j] = new BattleField() { IsBound = true };
                    }
                    else
                    {
                        Area.BattleFields[i, j] = new BattleField();
                    }
                }
            }
        }
    }
}
