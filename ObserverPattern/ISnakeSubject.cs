using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public interface ISnakeSubject : ISubject
    {
        List<ISnakeObserver> observers { get; set; }

        void Attach(ISnakeObserver o);

        void Detach(ISnakeObserver o);
    }
}
