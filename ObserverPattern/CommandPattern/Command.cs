using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern.CommandPattern
{
    public abstract class Command : ICommand
    {
        public string CommandName;

        public Command()
        {
            this.CommandName = "Base Command";
        }

        public virtual void Execute(Character go)
        {
            this.Log();
        }

        protected virtual void Log()
        {
            // Log basic command to console
            Console.WriteLine($"{this.CommandName} executed");
        }

        protected virtual void Log(Character go)
        {
            // Log basic command to console
            this.Log();
            Console.WriteLine($"on {go.ToString()}");
        }
    }
}
