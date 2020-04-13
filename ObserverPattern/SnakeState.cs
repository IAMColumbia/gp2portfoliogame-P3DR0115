using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public enum SnakeState : byte
    {
        Spawning,
        Hiding,
        Crawling,
        Sneaking,
        Standing,
        Walking,
        Running,
        CQCing,
        Shooting,
        Dying
    }
}
