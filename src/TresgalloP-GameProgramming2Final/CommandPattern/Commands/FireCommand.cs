using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.CharacterInfo;

namespace TresgalloP_GameProgramming2Final.CommandPattern.Commands
{
    class FireCommand : CommandWUndo
    {
        public FireCommand()
        {
            this.CommandName = "Fire";
        }
        public override void Execute(Character c)
        {
            c.Fire();
            base.Execute(c);
        }
    }
}
