﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Mappers
{
    public static class Coordinates
    {
        public static string MapToChar(int i)
        {
            switch(i)
            {
                case 0:
                    return "  ";
                case 1:
                    return "A";
                case 2:
                    return "B";
                case 3:
                    return "C";
                case 4:
                    return "D";
                case 5:
                    return "E";
                case 6:
                    return "F";
                case 7:
                    return "G";
                case 8:
                    return "H";
                case 9:
                    return "I";
                case 10:
                    return "J";
                case 11:
                    return "K";
                case 12:
                    return "L";
                case 13:
                    return "M";
                case 14:
                    return "N";
                default:
                    return string.Empty;
            }
        }

        public static int MapToLiteral(string s)
        {
            switch (s.ToUpper())
            {
                case "A":
                    return 1;
                case "B":
                    return 2;
                case "C":
                    return 3;
                case "D":
                    return 4;
                case "E":
                    return 5;
                case "F":
                    return 6;
                case "G":
                    return 7;
                case "H":
                    return 8;
                case "I":
                    return 9;
                case "J":
                    return 10;
                case "K":
                    return 11;
                case "L":
                    return 12;
                case "M":
                    return 13;
                case "N":
                    return 13;
                default:
                    return 0;
            }
        }

        public static string MapIntToStringFormat(int i)
        {
            switch (i)
            {
                case 0:
                    return " 0";
                case 1:
                    return " 1";
                case 2:
                    return " 2";
                case 3:
                    return " 3";
                case 4:
                    return " 4";
                case 5:
                    return " 5";
                case 6:
                    return " 6";
                case 7:
                    return " 7";
                case 8:
                    return " 8";
                case 9:
                    return " 9";
                case 10:
                    return "10";
                case 11:
                    return "11";
                case 12:
                    return "12";
                case 13:
                    return "13";
                case 14:
                    return "14";
                default:
                    return string.Empty;
            }
        }
    }
}
