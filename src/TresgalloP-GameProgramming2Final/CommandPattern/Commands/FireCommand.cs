using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.CharacterInfo;

namespace TresgalloP_GameProgramming2Final.CommandPattern.Commands
{
    class FireCommand : CommandWUndo
    {
        public ushort dir;
        public FireCommand(ushort dir)
        {
            this.dir = dir;
            this.CommandName = "Fire";
        }
        public override void Execute(Character c)
        {
            c.Fire(dir);
            base.Execute(c);
        }
    }
}
