using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.CharacterInfo;

namespace TresgalloP_GameProgramming2Final.CommandPattern.Commands
{
    class SwitchWeaponRCommand : CommandWUndo
    {
        public SwitchWeaponRCommand()
        {
            this.CommandName = "Fire";
        }
        public override void Execute(Character c)
        {
            c.SwitchWeaponR();
            base.Execute(c);
        }

        public override void UnExecute(Character c)
        {
            CommandWUndo undo = new SwitchWeaponLCommand();
            this.UndoCommand = new UndoCommand(undo);
            c.MoveDown();
            base.UnExecute(c);
        }
    }
}
