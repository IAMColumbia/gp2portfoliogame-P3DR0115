using System;
using System.Collections.Generic;
using System.Text;
using TresgalloP_GameProgramming2Final.CharacterInfo;

namespace TresgalloP_GameProgramming2Final.CommandPattern
{
    public interface ICommand
    {
        void Execute(GameComponent go);
    }
}
