using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Fields
{
    public class MissField : IField
    {
        public void MakeField()
        {
            Console.Write('.');
        }
    }
}
