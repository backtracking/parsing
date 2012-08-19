namespace Smi.Events
{
    using System;

    public interface IWeakEventHandler<TEventArgs> where TEventArgs : EventArgs
    {
        EventHandler<TEventArgs> Handler { get; }
    }

    public interface IWeakEventHandler
    {
        EventHandler Handler { get; }
    }
}

