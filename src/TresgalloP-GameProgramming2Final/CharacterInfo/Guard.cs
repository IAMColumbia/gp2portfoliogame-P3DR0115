using System;
using System.Collections.Generic;
using System.Text;

namespace TresgalloP_GameProgramming2Final.CharacterInfo
{
    public class Guard : Character
    {
        public Guard()
        {
            this.HealthPoints = 10;
            this.representation = '@';

            this.ammo = 90;
        }
    }
}
