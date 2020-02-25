using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public class Snake : SnakeSubject
    {
        public Snake()
        {
            this.location = new Location();
            this.HealthPoints = 20;
            observers = new List<ISnakeObserver>();
        }
        
    }
}
