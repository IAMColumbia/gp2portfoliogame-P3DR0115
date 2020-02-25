using System;
using System.Collections.Generic;
using System.Text;
using CommandFollowAlong.CommandPattern;

namespace CommandFollowAlong.Commands
{
    class MoveDownstairsCommand : CommandWUndo
    {
        public MoveDownstairsCommand()
        {
            this.CommandName = "Move Downstairs";
        }

        public UndoCommand UndoCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Execute(GameComponent go)
        {
            go.MoveDownstairs();
            base.Execute(go);
        }
    }
}
