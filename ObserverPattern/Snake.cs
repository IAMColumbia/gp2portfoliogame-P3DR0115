using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public class Snake : SnakeSubject
    {
        public int HealthPoints;

        public Snake()
        {
            this.location = new Location(1, 1, 0);
            this.lastLocation = new Location();
            this.representation = '@';
        }

    }
}
