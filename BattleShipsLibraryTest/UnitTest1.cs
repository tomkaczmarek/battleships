using System;
using NUnit.Framework;
using BattleShipsLibrary.Makers;
using BattleShipsLibrary.Fields;

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

            BattleField[,] fields = maker.CreateBattleArea();

            Assert.AreEqual(81, fields.Length);
        }
    }
}
