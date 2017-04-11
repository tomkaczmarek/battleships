using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Fields
{
    public class EmptyField : IField
    {
        private string _symbol;

        public EmptyField(string symbol)
        {
            _symbol = symbol;
        }

        public string MakeField()
        {
            return " ";
        }
    }
}
