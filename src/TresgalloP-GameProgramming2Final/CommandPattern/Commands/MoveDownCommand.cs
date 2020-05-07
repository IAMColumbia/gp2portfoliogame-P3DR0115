using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.CharacterInfo;

namespace TresgalloP_GameProgramming2Final.CommandPattern.Commands
{
    class MoveDownCommand : CommandWUndo
    {
        public MoveDownCommand()
        {
            this.CommandName = "Move Down";
        }

        public override void Execute(Character c)
        {
            c.MoveDown();
            base.Execute(c);
        }

        public override void UnExecute(Character c)
        {
            CommandWUndo undo = new MoveUpCommand();
            this.UndoCommand = new UndoCommand(undo);
            c.MoveUp();
            base.UnExecute(c);
        }
    }
}
