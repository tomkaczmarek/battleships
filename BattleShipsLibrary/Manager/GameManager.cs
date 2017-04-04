using BattleShipsLibrary.Fields;
using BattleShipsLibrary.Utils;
using BattleShipsLibrary.Mappers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Manager
{
    public class GameManager
    {
        private int _diffRatio;
        private GameAreaManager _areaManager;

        BattleArea Area { get; }
        public bool IsGameOver { get; set; }
        public int LeftTurns { get; set; }
        public DifficultLevel Level { get; set; }

        public GameManager(DifficultLevel level, GameAreaManager areaManager)
        {
            Level = level;
            _areaManager = areaManager;
        }

        public void Configure()
        {

            switch (Level)
            {
                case DifficultLevel.Easy:
                    _diffRatio = 6;
                    break;
                case DifficultLevel.Medium:
                    _diffRatio = 8;
                    break;
                case DifficultLevel.Hard:
                    _diffRatio = 10;
                    break;
                default:
                    break;
            }

            LeftTurns = ((_areaManager.Area.Height * _areaManager.Area.Width) / _diffRatio) + _areaManager.ShipCount;
        }

        public void MatchPlayerArea(BattleArea playerArea, BattleArea npcArea, string targetPoint)
        {

            int y = Coordinates.MapToLiteral(targetPoint[0].ToString());
            int x = int.Parse(targetPoint[1].ToString());

            IField npcTarget = npcArea.BattleFields[x, y].Field;

            if (!(npcTarget is BoundField))
            {
                if (npcTarget is ShipField)
                {
                    playerArea.BattleFields[x, y] = new BattleField(new ShipField(new RegularShip(true)));
                }
                else
                {
                    playerArea.BattleFields[x, y] = new BattleField(new MissField());
                }
            }
        }

        public bool IsPlayerWin(int playerShips, int npcShips)
        {
            return playerShips == npcShips;
        }

        public void EndTurn()
        {
            LeftTurns -= 1;
        }

        public void WinnerConditions(int playerShips, int npcShips, int turns)
        {
            if (IsPlayerWin(playerShips, npcShips))
            {
                Console.WriteLine("WYGRAŁEŚ!");
                Score(playerShips, turns);
                IsGameOver = true;
            }
            if (turns == 0)
            {
                Console.WriteLine("PRZEGRAŁEŚ!");
                Score(playerShips, turns);
                IsGameOver = true;
            }
        }

        public void Score(int playerShips, int turns)
        {
            Console.WriteLine("Twój wynik: {0} punktów.", (playerShips * 10) + turns);
        }
        
    }
    public enum DifficultLevel
    {
        Easy,
        Medium,
        Hard
    }
}
