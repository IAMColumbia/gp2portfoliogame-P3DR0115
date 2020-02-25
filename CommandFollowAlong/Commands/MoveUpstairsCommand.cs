using System;
using System.Collections.Generic;
using System.Text;
using CommandFollowAlong.CommandPattern;

namespace CommandFollowAlong.Commands
{
    class MoveUpstairsCommand : CommandWUndo
    {
        public MoveUpstairsCommand()
        {
            this.CommandName = "Move Upstairs";
        }

        public UndoCommand UndoCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Execute(GameComponent go)
        {            
            go.MoveUpstairs();
            base.Execute(go);
        }
    }
}
