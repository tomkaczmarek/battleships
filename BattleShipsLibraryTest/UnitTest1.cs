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

        private IAreaMaker MakeMakers(bool hasBoard)
        {
            return new AreaMaker(14, 14, hasBoard);
        }

        [Test]
        public void CreateBattleField_AllFieldsCountEquals_121()
        {
            bool hasBoard = true;
            IAreaMaker maker = MakeMakers(hasBoard);

            BattleArea area = maker.CreateBattleArea();

            Assert.AreEqual(256, area.BattleFields.Length);
        }

        [Test]
        public void CreateBattleField_Return_81_Fields_Without_Board()
        {
            IAreaMaker maker = MakeMakers(false);

            BattleArea area = maker.CreateBattleArea();

            Assert.AreEqual(196, area.BattleFields.Length);
        }



    }
}
