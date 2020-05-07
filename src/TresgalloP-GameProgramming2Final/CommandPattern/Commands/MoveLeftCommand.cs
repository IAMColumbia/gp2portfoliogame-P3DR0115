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

        public override void Execute(Character c)
        {
            c.MoveLeft();
            base.Execute(c);
        }

        public override void UnExecute(Character c)
        {
            CommandWUndo undo = new MoveRightCommand();
            this.UndoCommand = new UndoCommand(undo);
            c.MoveRight();
            base.UnExecute(c);
        }
    }
}
