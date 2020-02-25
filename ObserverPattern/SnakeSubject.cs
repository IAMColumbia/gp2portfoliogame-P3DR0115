using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public class SnakeSubject : Character, ISnakeSubject
    {
        protected List<ISnakeObserver> _observers;
        public List<ISnakeObserver> observers{ get { return _observers; } set { _observers = value; } }

        public void Attach(IObserver o)
        {
            throw new NotImplementedException();
        }

        public void Attach(ISnakeObserver o)
        {
            this._observers.Add(o);
        }

        public void Detach(IObserver o)
        {
            throw new NotImplementedException();
        }

        public void Detach(ISnakeObserver o)
        {
            this._observers.Remove(o);
        }

        public void Notify()
        {
            foreach(ISnakeObserver o in _observers)
            {
                o.ObserverUpdate(State);
            }
        }
    }
}
