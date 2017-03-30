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
        BattleArea IAreaMaker.CreateBattleArea()
        {
            BattleArea area = new BattleArea(11,11);

            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    if(j==0 || i==0 || j ==10 || i ==10 )
                    {
                        area.BattleFields[i, j] = new BattleField(false) { IsBound = true };
                    }
                    else
                    {
                        area.BattleFields[i, j] = new BattleField(false);
                    }                  
                }
            }

            return area;
        }
    }
}
