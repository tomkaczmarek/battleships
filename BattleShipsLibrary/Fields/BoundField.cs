using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Fields
{
    public class BoundField : IField
    {
        private string _symbol;

        public BoundField(string symbol)
        {
            _symbol = symbol;
        }

        public void MakeField()
        {
            Console.Write(_symbol);
        }
    }
}
