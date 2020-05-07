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
            this.HealthPoints = 100;
            this.representation = '@';

            this.ammo = 90;
        }

        public override string ShowStats()
        {
            return $"HP: {this.HealthPoints}\n" +
                $"Current Location: {this.locationInfo.location.ToTestString()}\n" +
                //$"Prev. Location: {this.locationInfo.lastLocation.ToTestString()}" +
                $"Current Terrain: {this.locationInfo.CurrentTerrain.tileType.ToString()}";
        }

    }
}
