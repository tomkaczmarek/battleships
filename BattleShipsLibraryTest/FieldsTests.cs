using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BattleShipsLibrary.Fields;

namespace BattleShipsLibraryTest
{
    [TestFixture]
    public class FieldsTests
    {
        [Test]
        public void ShouldMakeConcreteFieldSymbol()
        {
            string _symbol = "symbol";

            IField field = new BoundField(_symbol);

            Assert.AreEqual(_symbol, field.MakeField());
        }
    }
}
