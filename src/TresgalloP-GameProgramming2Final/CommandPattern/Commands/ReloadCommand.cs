using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.CharacterInfo;

namespace TresgalloP_GameProgramming2Final.CommandPattern.Commands
{
    class ReloadCommand : CommandWUndo
    {
        public ReloadCommand()
        {
            this.CommandName = "Reload";
        }
        public override void Execute(Character c)
        {
            c.Reload();
            base.Execute(c);
        }
    }
}
