using System;
using System.Collections.Generic;
using System.Text;
using ObserverPattern.WeaponStrategy;

namespace ObserverPattern.Weapons
{
    class AK47 : Weapon
    {
        public AK47()
        {
            this.Name = "AK-47";
            this.Damage = 10;
            this.MagCapacity = MagAmmo = 30;
            this.ReserveAmmo = 60;
            ReserveAmmoCapacity = 120;
        }
    }
}
