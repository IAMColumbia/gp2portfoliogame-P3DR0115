using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.CharacterInfo;

namespace TresgalloP_GameProgramming2Final.CommandPattern.Commands
{
    public class MoveRightCommand : CommandWUndo
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

        public override void UnExecute(GameComponent gc)
        {
            CommandWUndo undo = new MoveLeftCommand();
            this.UndoCommand = new UndoCommand(undo);
            gc.MoveLeft();
            base.UnExecute(gc);
        }
    }
}
