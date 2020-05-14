using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.Weapons;

namespace TresgalloP_GameProgramming2Final.CharacterInfo
{
    public interface CanHoldWeapons
    {
        List<Weapon> weapons { get; set; }
        ushort equippedWeapon { get; set; }
        ushort ammo { get; set; }
        ushort direction { get; set; }
        int shotAccuracy { get; set; }
        bool landHit { get; set; }

        void Fire(ushort direction);
        void Reload();
        void PickUpWeapon(Weapon w);
        void SwitchWeaponR();
        void SwitchWeaponL();
    }
}
