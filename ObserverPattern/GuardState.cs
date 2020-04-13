using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public enum GuardState : byte
    {
        Spawning,
        Standing,
        Patroling,
        Searching,
        CQCing,
        Shooting,
        KOd,
        Dying
    }
}
