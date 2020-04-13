using System;
using System.Collections.Generic;
using System.Text;
using ObserverPattern.CommandPattern;

namespace ObserverPattern.Commands
{
    class MoveDownCommand : Command
    {
        public MoveDownCommand()
        {
            this.CommandName = "Move Down";
        }

        public override void Execute(GameComponent go)
        {
            go.MoveDown();
            base.Execute(go);
        }
    }
}
