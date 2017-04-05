using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BattleShipsLibrary.Mappers;

namespace BattleShipsLibraryTest
{
    [TestFixture]
    public class Coordinates_Tests
    {
        [Test]
        public void ShouldMapToLiteral_ReturnTrue()
        {
            int i = 1;
            Assert.AreEqual(i, Coordinates.MapToLiteral("A"));
        }
    }
}
