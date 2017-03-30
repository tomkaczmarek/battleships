using BattleShipsLibrary.Fields;
using BattleShipsLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Makers
{
    public interface IAreaMaker
    {
        int Board { get; }
        bool HasBoard { get; set; }
        int Height { get; }
        int Width { get; }
        BattleArea CreateBattleArea();
    }
}
