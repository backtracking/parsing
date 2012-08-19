namespace Smi.Events
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Runtime.CompilerServices;

    public delegate void UnregisterCallback<E>(EventHandler<E> eventHandler)
    where E : EventArgs;

    public class WeakEventHandler<T> : IWeakEventHandler where T : class
    {
        private delegate void OpenEventHandler(T @this, object sender, EventArgs e);

        private EventHandler _handler;
        private OpenEventHandler _openHandler;
        private WeakReference _target;
        private Action<EventHandler> _unregister;

        public WeakEventHandler(EventHandler handler, Action<EventHandler> unregister)
        {
            Contract.Requires<ArgumentNullException>(handler != null, "handler");
            this._target = new WeakReference(handler.Target);
            this._openHandler = (OpenEventHandler)Delegate.CreateDelegate(typeof(OpenEventHandler), null, handler.Method);
            this._handler = new EventHandler(this.Invoke);
            this._unregister = unregister;
        }

        public void Invoke(object sender, EventArgs e)
        {
            T target = (T)this._target.Target;
            if (target != null)
            {
                this._openHandler(target, sender, e);
            }
            else if (this._unregister != null)
            {
                this._unregister(this._handler);
                this._unregister = null;
            }
        }

        public EventHandler Handler
        {
            get
            {
                return this._handler;
            }
        }
    }

    public class WeakEventHandler<T, TEventArgs> : IWeakEventHandler<TEventArgs>
        where T : class
        where TEventArgs : EventArgs
    {
        private delegate void OpenEventHandler(T @this, object sender, TEventArgs e);

        private WeakReference _targetRef;
        private OpenEventHandler _openHandler;
        private EventHandler<TEventArgs> _handler;
        private UnregisterCallback<TEventArgs> _unregister;


        public WeakEventHandler(EventHandler<TEventArgs> eventHandler, UnregisterCallback<TEventArgs> unregister)
        {
            Contract.Requires<ArgumentNullException>(eventHandler != null, "handler");
            _targetRef = new WeakReference(eventHandler.Target);
            _openHandler = (OpenEventHandler)Delegate.CreateDelegate(typeof(OpenEventHandler), null, eventHandler.Method);
            _handler = Invoke;
            _unregister = unregister;
        }

        public void Invoke(object sender, TEventArgs e)
        {
            T target = (T)_targetRef.Target;

            if (target != null)
                _openHandler.Invoke(target, sender, e);
            else if (_unregister != null)
            {
                _unregister(_handler);
                _unregister = null;
            }
        }

        public EventHandler<TEventArgs> Handler
        {
            get
            {
                return this._handler;
            }
        }

        public static implicit operator EventHandler<TEventArgs>(WeakEventHandler<T, TEventArgs> weakEventHandler)
        {
            return weakEventHandler._handler;
        }
    }

    //public class WeakEventHandler<T, TEventArgs> : IWeakEventHandler<TEventArgs> where T: class where TEventArgs: EventArgs
    //{
    //    private EventHandler<TEventArgs> _handler;
    //    private OpenEventHandler<T, TEventArgs> _openHandler;
    //    private WeakReference _target;
    //    private Action<EventHandler<TEventArgs>> _unregister;

    //    public WeakEventHandler(EventHandler<TEventArgs> handler, Action<EventHandler<TEventArgs>> unregister)
    //    {
    //        Contract.Requires<ArgumentNullException>(handler != null, "handler", "handler != null");
    //        this._target = new WeakReference(handler.Target);
    //        this._openHandler = (OpenEventHandler<T, TEventArgs>) Delegate.CreateDelegate(typeof(OpenEventHandler<T, TEventArgs>), null, handler.Method);
    //        this._handler = new EventHandler<TEventArgs>(this.Invoke);
    //        this._unregister = unregister;
    //    }

    //    public void Invoke(object sender, TEventArgs e)
    //    {
    //        T target = (T) this._target.Target;
    //        if (target != null)
    //        {
    //            this._openHandler(target, sender, e);
    //        }
    //        else if (this._unregister != null)
    //        {
    //            this._unregister(this._handler);
    //            this._unregister = null;
    //        }
    //    }

    //    public EventHandler<TEventArgs> Handler
    //    {
    //        get
    //        {
    //            return this._handler;
    //        }
    //    }

    //    private delegate void OpenEventHandler(T @this, object sender, TEventArgs e);
    //}
}

