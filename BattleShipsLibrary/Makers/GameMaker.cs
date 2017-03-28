using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShipsLibrary.Fields;
using BattleShipsLibrary.Utils;

namespace BattleShipsLibrary.Makers
{
    public class GameMaker : IGameMaker
    {
        BattleField[,] IGameMaker.CreateBattleArea()
        {
            BattleField[,] battlearea = new BattleField[9,9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    battlearea[i, j] = new BattleField(null);
                }
            }

            return battlearea;
        }
    }
}
