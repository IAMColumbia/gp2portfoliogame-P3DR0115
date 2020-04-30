using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.GameLib;

namespace TresgalloP_GameProgramming2Final.CharacterInfo
{
    public class LocationInfo
    {
        public Location location;
        public Location lastLocation;
        public RoomLocation roomLocation;
        public RoomLocation roomLastLocation;
        public Tile CurrentTerrain;

        public LocationInfo()
        {
            location = new Location();
            lastLocation = new Location();
            roomLocation = new RoomLocation();
            roomLastLocation = new RoomLocation();
            CurrentTerrain = new Tile(location, TileType.Floor);
        }

        public void UpdateTerrain(Tile terrain)
        {
            this.CurrentTerrain = terrain;
        }
    }
}
