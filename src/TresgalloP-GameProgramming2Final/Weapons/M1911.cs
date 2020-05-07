using System;
using System.Collections.Generic;
using System.Text;

namespace TresgalloP_GameProgramming2Final.Weapons
{
    public class M1911 : Weapon
    {
        public M1911()
        {
            this.name = "M1911";
            this.damage = 10;
            this.accuracy = 85;
            this.magCapacity = this.magCount = 7;
        }
    }
}
