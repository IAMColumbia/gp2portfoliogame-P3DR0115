using System;
using System.Collections.Generic;
using System.Text;
using ObserverPattern.CommandPattern;

namespace ObserverPattern.Commands
{
    class FireCommand : Command
    {
        public FireCommand()
        {
            this.CommandName = "Fire";
        }

        //public override void Execute(Character go)
        //{
        //    go.Fire();
        //    base.Execute(go);
        //}
    }
}
