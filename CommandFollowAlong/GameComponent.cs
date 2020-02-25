using System;

namespace CommandFollowAlong
{
    /// <summary>
    /// Fake GameComponent. I have no engine just trying to make a command pattern.
    /// </summary>
    public class GameComponent
    {
        private int _X, _Y, _Z;
        private bool _Crouching;


        public int X { get { return this._X; } protected set { this._X = value; } }
        public int Y { get { return this._Y; } protected set { this._Y = value; } }
        public int Z { get { return this._Z; } protected set { this._Z = value; } }
        public bool Crouching { get { return this._Crouching; } protected set { this._Crouching = value; } }

        internal void MoveUp()
        {
            this.Y++;
        }

        internal void MoveDown()
        {
            this.Y--;
        }

        internal void MoveRight()
        {
            this.X++;
        }

        internal void MoveLeft()
        {
            this.X--;
        }
        
        internal void MoveUpstairs()
        {
            this.Z++;
        }

        internal void MoveDownstairs()
        {
            this.Z--;
        }

        internal void ToggleCrouch()
        {
            this.Crouching = !this.Crouching;
        }
    }
}