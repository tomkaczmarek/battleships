using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Utils
{
    public class ShipsContainer
    {
        public List<List<ShipBase>> Ships { get; set; }

        public List<ShipBase> GetShipsByGuid(Guid guid)
        {
            return Ships.SelectMany(p => p.Where(c => c.Guid.Equals(guid))).ToList();
        }
    }
}
