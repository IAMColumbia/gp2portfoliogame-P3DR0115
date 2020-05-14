using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TresgalloP_GameProgramming2Final.GameLib;
using TresgalloP_GameProgramming2Final.Weapons;

namespace TresgalloP_GameProgramming2Final.CharacterInfo
{
    public abstract class Character : GameComponent, CanHoldWeapons
    {
        public double ID;
        public int HealthPoints;
        public char representation;

        public List<Weapon> weapons { get; set; }
        public ushort ammo { get; set; }
        public ushort equippedWeapon { get; set; }
        public ushort direction { get; set; }
        public int shotAccuracy { get; set; }
        public bool landHit { get; set; }
        public bool gotShot { get; set; }

        public string message;

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
                $"Current Terrain: {this.locationInfo.CurrentTerrain.tileType.ToString()}\n" +
                $"{message}";
        }

        public virtual char SetRepresentation()
        {
            int rep = (int)(this.HealthPoints / 10);
            return Convert.ToChar(rep.ToString());
        }

        public virtual void TakeDamage(int damage)
        {
            this.HealthPoints -= damage;
        }

        public virtual void Fire(ushort direction)
        {
            this.direction = direction;
            if(weapons[equippedWeapon].magCount <= 0)
                message =  $"Click Click! {weapons[equippedWeapon].name} is empty!";
            else
            {
                message = $"{weapons[equippedWeapon].name} was fired!";
                weapons[equippedWeapon].magCount--;
                shotAccuracy = Game.random.Next(100);
                if(shotAccuracy >= weapons[equippedWeapon].accuracy)
                {
                    // miss
                    landHit = false;
                    message += " Shot hit a wall...!";
                }
                else
                {
                    //possible hit
                    landHit = true;
                    //message += $"\n {weapons[equippedWeapon].name} hit!";
                }
            }
        }

        public void ResetForNextTurn()
        {
            message = "";
            this.direction = 5;
            landHit = false;
        }

        public virtual void Reload()
        {
            ushort ammoRequired = (ushort)(weapons[equippedWeapon].magCapacity - weapons[equippedWeapon].magCount);
            if (ammo == 0)
            {
                message = $"{weapons[equippedWeapon].name} could not be reloaded, you're out of ammo!";
            }
            else if(ammo >= ammoRequired)
            {
                ammo -= ammoRequired;
                weapons[equippedWeapon].magCount = weapons[equippedWeapon].magCapacity;
                message = $"{weapons[equippedWeapon].name} was fully reloaded!";
            }
            else
            {
                weapons[equippedWeapon].magCount += ammo;
                ammo = 0;
                message = $"{weapons[equippedWeapon].name} was partially reloaded!";
            }
        }

        public virtual void PickUpWeapon(Weapon w)
        {
            weapons.Add(w);
            equippedWeapon = (ushort)(weapons.Count - 1);
            message = $"{w.name} was picked up!";
        }

        public virtual void SwitchWeaponR()
        {
            //if (equippedWeapon < (weapons.Count - 1))
            //    equippedWeapon++;
            //else
            //    equippedWeapon = 0;
            equippedWeapon++;
            if (equippedWeapon >= weapons.Count)
                equippedWeapon = 0;

            message = $"{weapons[equippedWeapon].name} was equipped!";
        }

        public virtual void SwitchWeaponL()
        {
            //if (equippedWeapon > 0)
            //    equippedWeapon--;
            //else
            //    equippedWeapon = (ushort)(weapons.Count - 1);
            equippedWeapon--;
            if (equippedWeapon <= 0)
                equippedWeapon = (ushort)(weapons.Count - 1);

            message = $"{weapons[equippedWeapon].name} was equipped!";
        }
    }
}
