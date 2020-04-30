using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.CharacterInfo;

namespace TresgalloP_GameProgramming2Final.CommandPattern.Commands
{
    public class MoveLeftCommand : CommandWUndo
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

        public override void UnExecute(GameComponent gc)
        {
            CommandWUndo undo = new MoveRightCommand();
            this.UndoCommand = new UndoCommand(undo);
            gc.MoveRight();
            base.UnExecute(gc);
        }
    }
}
