using System;
using System.Collections.Generic;
using System.Text;

namespace TresgalloP_GameProgramming2Final.Weapons
{
    class RPG : Weapon
    {
        public RPG()
        {
            this.name = "RPG";
            this.damage = 100;
            this.accuracy = 45;
            this.magCapacity = this.magCount = 1;
        }
    }
}
