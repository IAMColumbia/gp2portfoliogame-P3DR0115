using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.Weapons;

namespace TresgalloP_GameProgramming2Final.CharacterInfo
{
    public class Guard : Character
    {
        public Guard()
        {
            ID = Game.random.NextDouble();
            this.HealthPoints = 25 + Game.random.Next(55);
            this.representation = SetRepresentation();
            AK47 ak = new AK47();
            this.weapons.Add(ak);
            this.ammo = 90;
        }

        public override char SetRepresentation()
        {
            int rep = (int)(this.HealthPoints / 10);
            return Convert.ToChar(rep.ToString());
        }
    }
}
