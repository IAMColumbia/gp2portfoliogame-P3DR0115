using System;
using System.Collections.Generic;
using System.Text;
using CommandFollowAlong.CommandPattern;

namespace CommandFollowAlong.Commands
{
    public class MoveRightCommand : Command
    {
        public MoveRightCommand()
        {
            this.CommandName = "Move Right";
        }

        public override void Execute(GameComponent go)
        {
            go.MoveRight();
            base.Execute(go);
        }
    }
}
