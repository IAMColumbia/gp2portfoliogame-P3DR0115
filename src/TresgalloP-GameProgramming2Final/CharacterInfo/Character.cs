using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.GameLib;
using TresgalloP_GameProgramming2Final.Weapons;

namespace TresgalloP_GameProgramming2Final.CharacterInfo
{
    public class Character : GameComponent, CanHoldWeapons
    {
        public int HealthPoints;
        public char representation;

        public List<Weapon> weapons { get; set; }
        public int ammo { get; set; }
        public int equippedWeapon { get; set; }

        public Character()
        {
            this.locationInfo.location = new Location(1, 1, 0);
            this.locationInfo.roomLocation = new RoomLocation();
            this.locationInfo.lastLocation = new Location();
            this.locationInfo.roomLastLocation = new RoomLocation();

            this.weapons = new List<Weapon>();
        }

        public virtual string ShowStats()
        {
            return $"HP: {this.HealthPoints}\n" +
                $"Current Location: {this.locationInfo.location.ToTestString()}\n" +
                //$"Prev. Location: {this.locationInfo.lastLocation.ToTestString()}" +
                $"Current Terrain: {this.locationInfo.CurrentTerrain.tileType.ToString()}";
        }

        public virtual string Fire()
        {
            if(weapons[equippedWeapon].magCount <= 0)
                return $"Click Click! {weapons[equippedWeapon].name} is empty!";
            else 
                return $"{weapons[equippedWeapon].name} was fired!";
        }

        public virtual string Reload()
        {
            int ammoRequired = weapons[equippedWeapon].magCapacity - weapons[equippedWeapon].magCount;
            if (ammo == 0)
            {
                return $"{equippedWeapon} could not be reloaded, you're out of ammo!";
            }
            else if(ammo >= ammoRequired)
            {
                ammo -= ammoRequired;
                weapons[equippedWeapon].magCount = weapons[equippedWeapon].magCapacity;
                return $"{equippedWeapon} was fully reloaded!";
            }
            else
            {
                weapons[equippedWeapon].magCount += ammo;
                ammo = 0;
                return $"{equippedWeapon} was partially reloaded!";
            }
        }

        public virtual string PickUpWeapon(Weapon w)
        {
            weapons.Add(w);
            equippedWeapon = (weapons.Count - 1);

            return $"{w.name} was picked up!";
        }

        public virtual string SwitchWeaponR()
        {
            if (equippedWeapon < (weapons.Count - 1))
                equippedWeapon++;
            else
                equippedWeapon = 0;

            return $"{weapons[equippedWeapon].name} was equipped!";
        }

        public virtual string SwitchWeaponL()
        {
            if (equippedWeapon > 0)
                equippedWeapon--;
            else
                equippedWeapon = (weapons.Count - 1);

            return $"{weapons[equippedWeapon].name} was equipped!";
        }
    }
}
