using System;
using System.Collections.Generic;
using System.Text;
using CommandFollowAlong.CommandPattern;

namespace CommandFollowAlong.Commands
{
    public class MoveLeftCommand : Command
    {
        public MoveLeftCommand()
        {
            this.CommandName = "Move Left";
        }

        public override void Execute(GameComponent go)
        {
            go.MoveLeft();
            base.Execute(go);
        }
    }
}
