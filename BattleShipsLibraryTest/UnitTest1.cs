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
            return new AreaMaker(9, 9, hasBoard);
        }

        [Test]
        public void CreateBattleField_AllFieldsCountEquals_121()
        {
            //bool hasBoard = true;
            //IAreaMaker maker = MakeMakers(hasBoard);

            //BattleArea area = maker.CreateBattleArea();

            //Assert.AreEqual(121, area.BattleFields.Length);
        }

        [Test]
        public void CreateBattleField_Return_81_Fields_Without_Board()
        {
            IAreaMaker maker = MakeMakers(false);

            BattleArea area = maker.CreateBattleArea();

            Assert.AreEqual(81, area.BattleFields.Length);
        }

    }
}
