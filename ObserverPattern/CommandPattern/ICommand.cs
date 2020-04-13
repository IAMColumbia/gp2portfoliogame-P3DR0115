using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern.CommandPattern
{
    public interface ICommand
    {
        void Execute(GameComponent go);
    }
}
