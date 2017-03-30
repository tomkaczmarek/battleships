using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Helpers
{
    public class CustomRandom : RandomNumberGenerator
    {
        RandomNumberGenerator r;

        public CustomRandom()
        {
            r = RandomNumberGenerator.Create();
        }

        public override void GetBytes(byte[] data)
        {
            r.GetBytes(data);
        }

        public double NextDouble()
        {
            byte[] b = new byte[4];
            r.GetBytes(b);
            return (double)BitConverter.ToInt32(b, 0) / UInt32.MaxValue;
        }

        public int Next(int min, int max)
        {
            return (int)Math.Abs((Math.Round(NextDouble() * (max - min - 1)) + min));
        }


    }
}
