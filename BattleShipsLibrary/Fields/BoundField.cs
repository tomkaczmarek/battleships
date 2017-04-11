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

        public string MakeField()
        {
            return _symbol;
        }
    }
}
