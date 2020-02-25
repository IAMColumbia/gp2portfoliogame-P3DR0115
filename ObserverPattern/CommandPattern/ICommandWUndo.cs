using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern.CommandPattern
{
    public interface ICommandWUndo : ICommand
    {
        UndoCommand UndoCommand { get; set; }
    }
}
