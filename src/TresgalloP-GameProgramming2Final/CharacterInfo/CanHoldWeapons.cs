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

        string Fire();
        string Reload();
        string PickUpWeapon(Weapon w);
        string SwitchWeaponR();
        string SwitchWeaponL();
    }
}
