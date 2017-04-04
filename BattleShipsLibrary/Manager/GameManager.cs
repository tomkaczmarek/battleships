using BattleShipsLibrary.Fields;
using BattleShipsLibrary.Utils;
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
        BattleArea Area { get; }
        public bool IsGameOver { get; set; }
        public int LeftTurns { get; set; }
        public DifficultLevel Level { get; set; }
        private int _diffRatio;
        private GameAreaManager _areaManager;


        public GameManager(DifficultLevel level, GameAreaManager areaManager)
        {
            Level = level;
            _areaManager = areaManager;
        }

        public void Configure()
        {
            
            switch(Level)
            {
                case DifficultLevel.Easy:
                    _diffRatio = 4;
                    break;
                case DifficultLevel.Medium:
                    _diffRatio = 6;
                    break;
                case DifficultLevel.Hard:
                    _diffRatio = 8;
                    break;
                default:
                    break;
            }

            LeftTurns = (_areaManager.Area.Height * _areaManager.Area.Width) / _diffRatio;
        }

        public void MatchPlayerArea(BattleArea playerArea, BattleArea npcArea, Point targetPoint)
        {
            IField npcTarget = npcArea.BattleFields[targetPoint.X, targetPoint.Y].Field;

            if(npcTarget is ShipField)
            {
                playerArea.BattleFields[targetPoint.X, targetPoint.Y] = new BattleField(new ShipField(new RegularShip(true)));
            }
            else
            {
                playerArea.BattleFields[targetPoint.X, targetPoint.Y] = new BattleField(new MissField());
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
                IsGameOver = true;
            }
            if (turns == 0)
            {
                Console.WriteLine("PRZEGRAŁEŚ!");
                IsGameOver = true;
            }
        }
    }
    public enum DifficultLevel
    {
        Easy,
        Medium,
        Hard
    }
}
