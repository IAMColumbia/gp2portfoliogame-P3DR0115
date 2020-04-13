using System;
using System.Collections.Generic;
using System.Text;
using ObserverPattern.CommandPattern;

namespace ObserverPattern.Commands
{
    class ReloadCommand : Command
    {
        public ReloadCommand()
        {
            this.CommandName = "Reload";
        }

        //public override void Execute(Character go)
        //{
        //    go.Reload();
        //    base.Execute(go);
        //}
    }
}
