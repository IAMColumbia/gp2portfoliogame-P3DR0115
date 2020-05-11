using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.GameLib;

namespace TresgalloP_GameProgramming2Final.CharacterInfo
{
    public class GameComponent
    {
        public LocationInfo locationInfo;
        public bool movedTile;

        public GameComponent()
        {
            locationInfo = new LocationInfo();
            movedTile = false;
        }

        internal void MoveUp()
        {
            locationInfo.lastLocation = new Location(locationInfo.location.X, locationInfo.location.Y, locationInfo.location.Z);
            this.locationInfo.location.Y--;
            movedTile = true;
        }

        internal void MoveDown()
        {
            locationInfo.lastLocation = new Location(locationInfo.location.X, locationInfo.location.Y, locationInfo.location.Z);
            this.locationInfo.location.Y++;
            movedTile = true;
        }

        internal void MoveRight()
        {
            locationInfo.lastLocation = new Location(locationInfo.location.X, locationInfo.location.Y, locationInfo.location.Z);
            this.locationInfo.location.X++;
            movedTile = true;
        }

        internal void MoveLeft()
        {
            locationInfo.lastLocation = new Location(locationInfo.location.X, locationInfo.location.Y, locationInfo.location.Z);
            this.locationInfo.location.X--;
            movedTile = true;
        }

        internal void MoveUpstairs()
        {
            locationInfo.lastLocation = new Location(locationInfo.location.X, locationInfo.location.Y, locationInfo.location.Z);
            this.locationInfo.location.Z++;
            movedTile = true;
        }

        internal void MoveDownstairs()
        {
            locationInfo.lastLocation = new Location(locationInfo.location.X, locationInfo.location.Y, locationInfo.location.Z);
            this.locationInfo.location.Z--;
            movedTile = true;
        }

    }
}
