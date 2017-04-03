using BattleShipsLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Makers
{
    public class SMaker : MakerBase
    {
        BattleArea Area { get; }

        public SMaker(BattleArea area, MakerBase maker)
        {
            Area = area;
        }

        public override void Create()
        {
            throw new NotImplementedException();
        }
    }
}
