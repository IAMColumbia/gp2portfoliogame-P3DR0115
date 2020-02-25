using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public class Location
    {
        public int X;// { get { return X; } set { X = value; } }
        public int Y;// { get { return Y; } set { Y = value; } }
        public int Z;// { get { return Z; } set { Z = value; } }

        public Location(int XCoordinate = 0, int YCoordinate = 0, int ZCoordinate = 0)
        {
            X = XCoordinate;
            Y = YCoordinate;
            Z = ZCoordinate;
        }

        public string ToTestString()
        {
            return $"Player Location: ({X}, {Y}, {Z})";
        }
    }
}
