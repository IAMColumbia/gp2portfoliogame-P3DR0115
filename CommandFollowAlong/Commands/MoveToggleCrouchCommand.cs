using System;
using System.Collections.Generic;
using System.Text;
using CommandFollowAlong.CommandPattern;

namespace CommandFollowAlong.Commands
{
    class MoveToggleCrouchCommand : Command, ICommandWUndo
    {
        public MoveToggleCrouchCommand()
        {
            this.CommandName = "Toggle Crouch";
        }

        public UndoCommand UndoCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Execute(GameComponent go)
        {
            go.ToggleCrouch();
            base.Execute(go);
        }
    }
}
