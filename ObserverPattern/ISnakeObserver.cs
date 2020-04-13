using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public interface ISnakeObserver : IObserver
    {
        void ObserverUpdate(SnakeState state);
    }
}
