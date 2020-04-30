using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.GameLib;

namespace TresgalloP_GameProgramming2Final.CharacterInfo
{
    public class Player : Character
    {
        public Player()
        {
            this.locationInfo.location = new Location(1, 1, 0);
            this.locationInfo.roomLocation = new RoomLocation();
            this.locationInfo.lastLocation = new Location();
            this.locationInfo.roomLastLocation = new RoomLocation();
            this.representation = '@';
        }

        public string ShowStats()
        {
            return $"HP: {this.HealthPoints}\n" +
                $"Current Location: {this.locationInfo.location.ToTestString()}\n" +
                //$"Prev. Location: {this.locationInfo.lastLocation.ToTestString()}" +
                $"Current Terrain: {this.locationInfo.CurrentTerrain.tileType.ToString()}";
        }

    }
}
