using System;
using System.Collections.Generic;
using System.Text;

namespace TresgalloP_GameProgramming2Final.CommandPattern
{
    interface ICommandWUndo : ICommand
    {
        UndoCommand UndoCommand { get; set; }
    }
}
