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
        private int _difficultRatio;
        private GameAreaManager _areaManager;

        BattleArea Area { get; }
        public bool IsGameOver { get; set; }
        public int LeftTurns { get; set; }
        public DifficultLevel Level { get; set; }
        private bool _subTurn;

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
                    _difficultRatio = 10;
                    break;
                case DifficultLevel.Medium:
                    _difficultRatio = 13;
                    break;
                case DifficultLevel.Hard:
                    _difficultRatio = 16;
                    break;
                default:
                    break;
            }
            LeftTurns = ((_areaManager.Area.Height * _areaManager.Area.Width) / _difficultRatio) + _areaManager.ShipCount;
        }

        public void MatchPlayerArea(BattleArea playerArea, BattleArea npcArea, string targetPoint, ShipsContainer shipsContainer)
        {
            _subTurn = true;
            bool isDestroyShip = false;
            int y = Coordinates.MapToLiteral(targetPoint[0].ToString());
            int x = int.Parse(targetPoint.Substring(1));

            IField npcTarget = npcArea.BattleFields[x, y].Field;

            if (!(npcTarget is BoundField))
            {
                if (npcTarget is ShipField)
                {
                    _subTurn = false;
                    Guid guid = (npcArea.BattleFields[x, y].Field as ShipField).ShipType.Guid;
                    playerArea.BattleFields[x, y] = new BattleField(new ShipField(new RegularShip(true, guid)));

                    List<ShipBase> listOfShips = shipsContainer.GetShipsByGuid(guid);
                    listOfShips.First(d => (d.ShipsPoints.X == x && d.ShipsPoints.Y == y)).IsDestroy = true;

                    foreach(ShipBase s in listOfShips)
                    {
                        if(!s.IsDestroy)
                        {
                            isDestroyShip = false;
                            break;
                        }
                        isDestroyShip = true;
                    }

                    if(isDestroyShip)
                    {
                        foreach(ShipBase s in listOfShips)
                        {
                            playerArea.BattleFields[s.ShipsPoints.X, s.ShipsPoints.Y] = new BattleField(new ShipDestroyField());

                            foreach(Point p in s.NearShipPoints)
                            {
                                playerArea.BattleFields[p.X, p.Y] = new BattleField(new MissField());
                            }
                        }
                    }
                }
                else
                {
                    playerArea.BattleFields[x, y] = new BattleField(new MissField());
                }
            }
        }

        public void WinnerConditions(int playerShips, int npcShips, int turns)
        {
            if (IsPlayerWin(playerShips, npcShips))
            {
                Console.WriteLine("YOU WON!");
                Score(playerShips, turns);
                IsGameOver = true;
            }
            if (turns == 0)
            {
                Console.WriteLine("YOU LOSE!");
                Score(playerShips, turns);
                IsGameOver = true;
            }
        }

        public bool IsPlayerWin(int playerShips, int npcShips)
        {
            return playerShips == npcShips;
        }

        public void EndTurn()
        {
            if(_subTurn)
            {
                LeftTurns -= 1;
            }          
        }

        public void Score(int playerShips, int turns)
        {
            Console.WriteLine("Your score: {0}.", (playerShips * 10) + turns);
        }
        
    }
    public enum DifficultLevel
    {
        Easy,
        Medium,
        Hard
    }
}
