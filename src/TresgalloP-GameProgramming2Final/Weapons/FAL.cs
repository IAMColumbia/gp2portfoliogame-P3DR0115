using System;
using System.Collections.Generic;
using System.Text;

namespace TresgalloP_GameProgramming2Final.Weapons
{
    public class FAL : Weapon
    {
        public FAL()
        {
            this.name = "FAL";
            this.damage = 20;
            this.accuracy = 90;
            this.magCapacity = this.magCount = 20;
        }
    }
}
