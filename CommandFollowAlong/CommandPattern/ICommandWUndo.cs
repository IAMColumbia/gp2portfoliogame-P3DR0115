using System;
using System.Collections.Generic;
using System.Text;

namespace CommandFollowAlong.CommandPattern
{
    public interface ICommandWUndo : ICommand
    {
        UndoCommand UndoCommand { get; set; }
    }
}
