using System;
using System.Collections.Generic;
using System.Text;
using ObserverPattern.CommandPattern;

namespace ObserverPattern.Commands
{
    public class MoveLeftCommand : Command
    {
        public MoveLeftCommand()
        {
            this.CommandName = "Move Left";
        }

        public override void Execute(Character go)
        {
            go.MoveLeft();
            base.Execute(go);
        }
    }
}
