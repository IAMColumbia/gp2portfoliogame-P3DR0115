using System;
using System.Collections.Generic;
using System.Text;
using ObserverPattern.WeaponStrategy;
using ObserverPattern.Weapons;

namespace ObserverPattern
{
    public class Character
    {
        private Location _Location;
        public Location location { get { return _Location; } set { _Location = value; } }

        private ActionState _State;
        public ActionState State { get { return _State; } set { _State = value; } }

        private int _HealthPoints;
        public int HealthPoints { get { return _HealthPoints; } set { _HealthPoints = value; } }

        private Weapon _Weapon;
        public Weapon weapon { get { return _Weapon; } set { _Weapon = value; } }


        public Character()
        {
            location = new Location();
            State = ActionState.Spawning;
            
        }

        internal void MoveUp()
        {
            this.location.Y++;
        }

        internal void MoveDown()
        {
            this.location.Y--;
        }

        internal void MoveRight()
        {
            this.location.X++;
        }

        internal void MoveLeft()
        {
            this.location.X--;
        }

        internal void MoveUpstairs()
        {
            this.location.Z++;
        }

        internal void MoveDownstairs()
        {
            this.location.Z--;
        }

        internal void Reload()
        {
            this.weapon.Reload();
        }

        internal void Fire()
        {
            this.weapon.Fire(this.location);
        }
        
    }
}
