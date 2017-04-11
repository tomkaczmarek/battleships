using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipsLibrary.Fields;
using BattleShipsLibrary.Utils;
using BattleShipsLibrary.Mappers;
using BattleShipsLibrary.Helpers;

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
                    if(HasBoard &&(j == 0 || i == 0 || j == Height - 1 || i == Width - 1))
                    {
                        if (i == 0)
                        {
                            if (j == Height - 1)
                                area.BattleFields[i, j] = new BattleField(new BoundField(SymbolsContent.BoundFieldFirstElement));
                            else
                                area.BattleFields[i, j] = new BattleField(new BoundField(Coordinates.MapToChar(j)));
                        }                         
                        else if (j == 0)
                        {
                            if (i == Width - 1)
                                area.BattleFields[i, j] = new BattleField(new BoundField(SymbolsContent.BoundFieldFirstElement));
                            else
                                area.BattleFields[i, j] = new BattleField(new BoundField(Coordinates.MapIntToStringFormat(i)));
                        }                         
                        else if (j == Height - 1)
                            area.BattleFields[i, j] = new BattleField(new BoundField(SymbolsContent.BoundFieldLastElement));
                        else
                            area.BattleFields[i, j] = new BattleField(new BoundField(SymbolsContent.BoundFieldDownElement));
                    }
                    else
                    {
                        area.BattleFields[i, j] = new BattleField(new EmptyField(SymbolsContent.EmptyField));
                    }
                }
            }
            return area;
        }
    }
}
