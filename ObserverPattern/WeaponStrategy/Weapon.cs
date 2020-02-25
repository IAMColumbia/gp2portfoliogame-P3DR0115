using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern.WeaponStrategy
{
    public abstract class Weapon
    {
        public string Name;// { get { return Name; } protected set { Name = value; } }
        /// <summary>
        /// Damage number of the weapon
        /// </summary>
        public float Damage;// { get { return Damage; } protected set { Damage = value; } }
        /// <summary>
        /// The capacity of the magazine, i.e. how many bullets it can hold
        /// </summary>
        public int MagCapacity;// { get { return MagCapacity; } protected set { MagCapacity = value; } }
        /// <summary>
        /// Maximum reserve ammo capacity allowed to be carried
        /// </summary>
        public int ReserveAmmoCapacity;// { get { return ReserveAmmoCapacity; } protected set { ReserveAmmoCapacity = value; } }

        /// <summary>
        /// How many bullets are currently in the magazine
        /// </summary>
        public int MagAmmo;// { get { return MagAmmo; } protected set { MagAmmo = value; } }
        /// <summary>
        /// How much ammo is being carried in reserve
        /// </summary>
        public int ReserveAmmo;// { get { return ReserveAmmo; } protected set { ReserveAmmo = value; } }

        public Weapon()
        {
            //Name = "Gun";
            //Damage = MagCapacity = ReserveAmmoCapacity = MagAmmo = ReserveAmmo = 1;
        }

        public void Fire(Location origin)
        {
            if(MagAmmo > 0)
            {
                MagAmmo -= 1;
            }

            List<Character> targets = new List<Character>();
            
            foreach(Character c in Game.characters)
            {
                if(origin != c.location)
                {
                    if (origin.Z == c.location.Z)
                    {
                        if (origin.X - 2 >= c.location.X && origin.X + 2 <= c.location.X)
                        {
                            if (origin.Y - 2 >= c.location.X && origin.Y + 2 <= c.location.X)
                            {
                                targets.Add(c);
                            }
                        }
                    }
                }                    
            }

            if(targets.Count > 1)
            {
                bool fired = false;
                for(int i = 0; i < targets.Count; i++)
                {
                    Console.WriteLine($"Target found at {targets[i].location.ToTestString()}, Press J to fire at them. K to check next target");

                    ConsoleKeyInfo input = Console.ReadKey();
                    switch(input.Key)
                    {
                        case ConsoleKey.J:
                            {
                                fired = true;
                                break;
                            }
                        case ConsoleKey.K:
                            {
                                if (i == targets.Count)
                                    i = -1;
                                break;
                            }
                    }
                }
            }
            
            
        }

        public string Reload()
        {
            int reloadedRounds;
            // Full Reload
            if(ReserveAmmo >= (MagCapacity - MagAmmo))
            {
                ReserveAmmo -= (MagCapacity - MagAmmo);
                reloadedRounds = (MagCapacity - MagAmmo);
                MagAmmo = MagCapacity;
            }
            else // Partial Reload
            {
                MagAmmo += ReserveAmmo;
                reloadedRounds = ReserveAmmo;
                ReserveAmmo = 0;
            }

            return $"{reloadedRounds} bullets reloaded!";
        }

        public string ToTestString()
        {
            return $"{Name}: {MagAmmo} / {ReserveAmmo}";
        }
    }
}
