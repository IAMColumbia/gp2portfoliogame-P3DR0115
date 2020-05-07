using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.CharacterInfo;

namespace TresgalloP_GameProgramming2Final.CommandPattern
{
    public abstract class CommandWUndo : Command, ICommandWUndo
    {
        GameComponent gc;
        public UndoCommand UndoCommand { get; set; }

        public CommandWUndo()
        {
            //nothing
        }

        public override void Execute(Character c)
        {
            this.gc = c;
            base.Execute(c);
        }
        public virtual void UnExecute(Character c)
        {
            this.UndoCommand.Execute(c);
        }
    }
}
