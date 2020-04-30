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

        public override void Execute(GameComponent go)
        {
            go.MoveDown();
            base.Execute(go);
        }

        public override void UnExecute(GameComponent gc)
        {
            CommandWUndo undo = new MoveUpCommand();
            this.UndoCommand = new UndoCommand(undo);
            gc.MoveUp();
            base.UnExecute(gc);
        }
    }
}
