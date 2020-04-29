using System;
using System.Collections.Generic;
using System.Text;

namespace TresgalloP_GameProgramming2Final.CommandPattern
{
    public class UndoCommand : Command
    {
        public UndoCommand(CommandWUndo command)
        {
            this.CommandName = "Undo " + command.CommandName;
        }
    }
}
