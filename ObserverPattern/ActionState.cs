using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public enum ActionState : byte
    {
        Spawning,
        Hiding,
        Crawling,
        Sneaking,
        Standing,
        Walking,
        Running,
        Patrolling,
        Searching,
        Meleeing,
        Shooting,
        Dying
    }
}
