using System;
using System.Collections.Generic;
using System.Text;

namespace TresgalloP_GameProgramming2Final.CharacterInfo
{
    public class Guard : Character
    {
        public Guard()
        {
            this.HealthPoints = 25;
            this.representation = SetRepresentation();

            this.ammo = 90;
        }

        public char SetRepresentation()
        {
            int rep = (int)(this.HealthPoints / 10);
            return Convert.ToChar(rep);
        }
    }
}
