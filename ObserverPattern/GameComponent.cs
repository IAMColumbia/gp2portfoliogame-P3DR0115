using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public class GameComponent
    {
        private Location _Location;
        public Location location { get { return _Location; } set { _Location = value; } }

        private Location _LastLocation;
        public Location lastLocation { get { return _LastLocation; } set { _LastLocation = value; } }


        public char representation;


        internal void MoveUp()
        {
            lastLocation = new Location(location.X, location.Y, location.Z);
            this.location.Y--;
        }

        internal void MoveDown()
        {
            lastLocation = new Location(location.X, location.Y, location.Z);
            this.location.Y++;
        }

        internal void MoveRight()
        {
            lastLocation = new Location(location.X, location.Y, location.Z);
            this.location.X++;
        }

        internal void MoveLeft()
        {
            lastLocation = new Location(location.X, location.Y, location.Z);
            this.location.X--;
        }

        internal void MoveUpstairs()
        {
            lastLocation = new Location(location.X, location.Y, location.Z);
            this.location.Z++;
        }

        internal void MoveDownstairs()
        {
            lastLocation = new Location(location.X, location.Y, location.Z);
            this.location.Z--;
        }
        
    }
}
