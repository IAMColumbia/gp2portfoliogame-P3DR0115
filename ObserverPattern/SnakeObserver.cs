using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public class SnakeObserver : Character, ISnakeObserver
    {
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

        public void ObserverUpdate(ActionState state)
        {
            switch (state)
            {
                case ActionState.Spawning:
                    {

                        break;
                    }
                case ActionState.Hiding:
                    {

                        break;
                    }
                case ActionState.Crawling:
                    {

                        break;
                    }
                case ActionState.Sneaking:
                    {

                        break;
                    }
                case ActionState.Standing:
                    {

                        break;
                    }
                case ActionState.Walking:
                    {

                        break;
                    }
                case ActionState.Running:
                    {

                        break;
                    }
                case ActionState.Patrolling:
                    {

                        break;
                    }
                case ActionState.Searching:
                    {

                        break;
                    }
                case ActionState.Meleeing:
                    {

                        break;
                    }
                case ActionState.Shooting:
                    {

                        break;
                    }
                case ActionState.Dying:
                    {

                        break;
                    }
            }
        }
    }
}
