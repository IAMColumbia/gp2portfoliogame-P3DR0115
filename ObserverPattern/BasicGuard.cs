using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public class BasicGuard : SnakeObserver
    {
        public BasicGuard(Game game, ISnakeSubject snek) : base(game, snek)
        {

        }
    }
}
