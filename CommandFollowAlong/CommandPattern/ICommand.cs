using System;
using System.Collections.Generic;
using System.Text;

namespace CommandFollowAlong.CommandPattern
{
    public interface ICommand
    {
        void Execute(GameComponent go);
    }
}
