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

        private IGameMaker MakeMakers()
        {
            return new GameMaker();
        }

        [Test]
        public void CreateBattleField_AllFieldsCountEquals_81()
        {
            IGameMaker maker = MakeMakers();

            BattleArea area = maker.CreateBattleArea();

            Assert.AreEqual(81, area.BattleFields.Length);
        }
    }
}
