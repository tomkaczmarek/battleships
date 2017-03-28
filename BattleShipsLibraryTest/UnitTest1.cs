using System;
using NUnit.Framework;
using BattleShipsLibrary.Makers;
using BattleShipsLibrary.Fields;
using BattleShipsLibrary.Utils;

namespace BattleShipsLibraryTest
{
    [TestFixture]
    public class UnitTest1
    {

        private IAreaMaker MakeMakers()
        {
            return new AreaMaker();
        }

        [Test]
        public void CreateBattleField_AllFieldsCountEquals_121()
        {
            IAreaMaker maker = MakeMakers();

            BattleArea area = maker.CreateBattleArea();

            Assert.AreEqual(121, area.BattleFields.Length);
        }
    }
}
