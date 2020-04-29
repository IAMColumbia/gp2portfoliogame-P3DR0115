using System;
using System.Collections.Generic;
using System.Text;

namespace TresgalloP_GameProgramming2Final.GameLib
{
    public class Location
    {
        public int X;
        public int Y;
        public int Z;

        public Location(int XCoordinate = 0, int YCoordinate = 0, int ZCoordinate = 0)
        {
            X = XCoordinate;
            Y = YCoordinate;
            Z = ZCoordinate;
        }

        public string ToTestString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}
