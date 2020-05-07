using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.Weapons;

namespace TresgalloP_GameProgramming2Final.CharacterInfo
{
    public interface CanHoldWeapons
    {
        List<Weapon> weapons { get; set; }
        int equippedWeapon { get; set; }
        int ammo { get; set; }

        void Fire();
        void Reload();
        void PickUpWeapon(Weapon w);
        void SwitchWeaponR();
        void SwitchWeaponL();
    }
}
