using BattleShipsLibrary.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Makers
{
    public abstract class MakerBase
    {
        public BattleArea Area { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public abstract void Create();
    }
}
