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
            this.ID = -1;
            this.HealthPoints = 100;
            this.representation = '@';

            this.ammo = 90;
        }

        public override string ShowStats()
        {
            return $"HP: {this.HealthPoints}\n" +
                $"Current Location: {this.locationInfo.location.ToTestString()}\n" +
                //$"Prev. Location: {this.locationInfo.lastLocation.ToTestString()}" +
                $"Current Terrain: {this.locationInfo.CurrentTerrain.tileType.ToString()}\n" +
                $"Current Weapon: {this.weapons[equippedWeapon].name} [{this.weapons[equippedWeapon].magCount} | {this.ammo}]\n" +
                $"{message}";
        }

        //public override char SetRepresentation()
        //{
        //    int rep = (int)(this.HealthPoints / 10);
        //    return Convert.ToChar(rep.ToString());
        //}
    }
}
