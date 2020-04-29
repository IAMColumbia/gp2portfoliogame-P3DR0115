using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.CharacterInfo;

namespace TresgalloP_GameProgramming2Final.CommandPattern.Commands
{
    public class MoveUpCommand : CommandWUndo
    {
        public MoveUpCommand()
        {
            this.CommandName = "Move Up";
            CommandWUndo undo = new MoveDownCommand();
            this.UndoCommand = new UndoCommand(undo);
        }

        public override void Execute(GameComponent go)
        {
            go.MoveUp();
            base.Execute(go);
        }

        public override void UnExecute(GameComponent gc)
        {
            //gc.MoveDown();
            //base.UnExecute(gc);
            //this.UndoCommand = new MoveDownCommand();
            this.UndoCommand.Execute(gc);
        }
    }
}
