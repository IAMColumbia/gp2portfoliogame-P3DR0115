﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    public interface ISubject
    {
        void Attach(IObserver o);
        void Detach(IObserver o);
        void Notify();
    }
}