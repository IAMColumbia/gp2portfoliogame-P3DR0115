using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public class SnakeObserver : GameComponent, ISnakeObserver
    {
        GuardState state;
        ISnakeSubject snakeSub;

        public SnakeObserver(Game game, ISnakeSubject snek)
        {
            snakeSub = snek;
            this.snakeSub.Attach(this);
        }
        public void ObserverUpdate()
        {
            throw new NotImplementedException();
        }

        public void ObserverUpdate(SnakeState state)
        {
            switch (state)
            {
                case SnakeState.Spawning:
                    {

                        break;
                    }
                case SnakeState.Hiding:
                    {

                        break;
                    }
                case SnakeState.Crawling:
                    {

                        break;
                    }
                case SnakeState.Sneaking:
                    {

                        break;
                    }
                case SnakeState.Standing:
                    {

                        break;
                    }
                case SnakeState.Walking:
                    {

                        break;
                    }
                case SnakeState.Running:
                    {

                        break;
                    }
                case SnakeState.Shooting:
                    {

                        break;
                    }
                case SnakeState.Dying:
                    {

                        break;
                    }
            }
        }
    }
}
