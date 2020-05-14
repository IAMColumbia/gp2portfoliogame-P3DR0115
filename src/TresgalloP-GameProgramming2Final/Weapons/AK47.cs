using System;
using System.Collections.Generic;
using System.Text;

namespace TresgalloP_GameProgramming2Final.Weapons
{
    public class AK47 : Weapon
    {
        public AK47()
        {
            this.name = "AK-47";
            this.damage = 25;
            this.accuracy = 70;
            this.magCapacity = this.magCount = 30;
        }
    }
}
