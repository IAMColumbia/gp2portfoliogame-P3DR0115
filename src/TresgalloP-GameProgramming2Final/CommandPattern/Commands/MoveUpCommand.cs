﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TresgalloP_GameProgramming2Final.CharacterInfo;

namespace TresgalloP_GameProgramming2Final.CommandPattern.Commands
{
    public class MoveUpCommand : CommandWUndo
    {
        public MoveUpCommand()
        {
            this.CommandName = "Move Up";
        }

        public override void Execute(Character c)
        {
            c.MoveUp();
            base.Execute(c);
        }

        public override void UnExecute(Character c)
        {
            CommandWUndo undo = new MoveDownCommand();
            this.UndoCommand = new UndoCommand(undo);
            c.MoveDown();
            base.UnExecute(c);
        }

        //public override void UnExecute(GameComponent gc)
        //{
        //    //gc.MoveDown();
        //    //base.UnExecute(gc);
        //    //this.UndoCommand = new MoveDownCommand();
        //    gc.MoveDown();
        //    this.UndoCommand.Execute(gc);
        //}
    }
}
