using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.GameLib;

namespace TresgalloP_GameProgramming2Final.CharacterInfo
{
    public class GameComponent
    {
        public LocationInfo locationInfo;

        public GameComponent()
        {
            locationInfo = new LocationInfo();
        }

        internal void MoveUp()
        {
            locationInfo.lastLocation = new Location(locationInfo.location.X, locationInfo.location.Y, locationInfo.location.Z);
            this.locationInfo.location.Y--;
        }

        internal void MoveDown()
        {
            locationInfo.lastLocation = new Location(locationInfo.location.X, locationInfo.location.Y, locationInfo.location.Z);
            this.locationInfo.location.Y++;
        }

        internal void MoveRight()
        {
            locationInfo.lastLocation = new Location(locationInfo.location.X, locationInfo.location.Y, locationInfo.location.Z);
            this.locationInfo.location.X++;
        }

        internal void MoveLeft()
        {
            locationInfo.lastLocation = new Location(locationInfo.location.X, locationInfo.location.Y, locationInfo.location.Z);
            this.locationInfo.location.X--;
        }

        internal void MoveUpstairs()
        {
            locationInfo.lastLocation = new Location(locationInfo.location.X, locationInfo.location.Y, locationInfo.location.Z);
            this.locationInfo.location.Z++;
        }

        internal void MoveDownstairs()
        {
            locationInfo.lastLocation = new Location(locationInfo.location.X, locationInfo.location.Y, locationInfo.location.Z);
            this.locationInfo.location.Z--;
        }

    }
}
