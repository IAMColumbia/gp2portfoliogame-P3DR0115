using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.CharacterInfo;

namespace TresgalloP_GameProgramming2Final.CommandPattern
{
    public abstract class Command : ICommand
    {
        public string CommandName;

        public Command()
        {
            this.CommandName = "Base Command";
        }

        public virtual void Execute(Character c)
        {
            this.Log();
        }

        protected virtual void Log()
        {
            // Log basic command to console
            Console.WriteLine($"{this.CommandName} executed");
        }

        protected virtual void Log(Character c)
        {
            // Log basic command to console
            this.Log();
            Console.WriteLine($"on {c.ToString()}");
        }
    }
}
