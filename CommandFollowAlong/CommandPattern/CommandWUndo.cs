namespace CommandFollowAlong.CommandPattern
{
    public abstract class CommandWUndo : Command, ICommandWUndo
    {
        GameComponent gc;                   //Refernece to game component
        public UndoCommand UndoCommand { get; set; }

        public CommandWUndo()
        {
            //nothing
        }

        public override void Execute(GameComponent gc)
        {
            this.gc = gc;   //Hold a refernce to the game componet this command was excuted on
            base.Execute(gc);
        }
        public void UnExecute()
        {
            this.UndoCommand.Execute(gc);
        }
    }
}