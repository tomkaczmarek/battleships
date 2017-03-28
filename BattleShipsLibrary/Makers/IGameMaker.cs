using BattleShipsLibrary.Fields;
using BattleShipsLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Makers
{
    public interface IGameMaker
    {
        BattleArea CreateBattleArea();
    }
}
