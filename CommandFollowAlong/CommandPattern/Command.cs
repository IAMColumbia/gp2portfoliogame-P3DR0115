using System;
using System.Collections.Generic;
using System.Text;

namespace CommandFollowAlong.CommandPattern
{
    public abstract class Command : ICommand
    {
        public string CommandName;

        public Command()
        {
            this.CommandName = "Base Command";
        }

        public virtual void Execute(GameComponent go)
        {
            this.Log();
        }

        protected virtual void Log()
        {
            // Log basic command to console
            Console.WriteLine($"{this.CommandName} executed");
        }

        protected virtual void Log(GameComponent go)
        {
            // Log basic command to console
            this.Log();
            Console.WriteLine($"on {go.ToString()}");
        }
    }
}
