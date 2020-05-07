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

        public override void Execute(Character c)
        {
            c.MoveRight();
            base.Execute(c);
        }

        public override void UnExecute(Character c)
        {
            CommandWUndo undo = new MoveLeftCommand();
            this.UndoCommand = new UndoCommand(undo);
            c.MoveLeft();
            base.UnExecute(c);
        }
    }
}
