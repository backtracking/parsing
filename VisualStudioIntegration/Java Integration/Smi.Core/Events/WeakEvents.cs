namespace Smi.Events
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Runtime.CompilerServices;

    public static class WeakEvents
    {
        public static EventHandler AsWeak(EventHandler handler, Action<EventHandler> unregister)
        {
            Contract.Requires<ArgumentNullException>(handler != null, "handler");
            if (handler.Method.IsStatic)
            {
                return handler;
            }
            IWeakEventHandler handler2 = (IWeakEventHandler) typeof(WeakEventHandler<>).MakeGenericType(new Type[] { handler.Method.DeclaringType }).GetConstructor(new Type[] { typeof(EventHandler), typeof(Action<EventHandler>) }).Invoke(new object[] { handler, unregister });
            return handler2.Handler;
        }

        public static EventHandler<TEventArgs> AsWeak<TEventArgs>(this EventHandler<TEventArgs> handler, Action<EventHandler<TEventArgs>> unregister) where TEventArgs: EventArgs
        {
            Contract.Requires<ArgumentNullException>(handler != null, "handler");
            if (handler.Method.IsStatic)
            {
                return handler;
            }
            IWeakEventHandler<TEventArgs> handler2 = (IWeakEventHandler<TEventArgs>) typeof(WeakEventHandler<,>).MakeGenericType(new Type[] { handler.Method.DeclaringType, typeof(TEventArgs) }).GetConstructor(new Type[] { typeof(EventHandler<TEventArgs>), typeof(Action<EventHandler<TEventArgs>>) }).Invoke(new object[] { handler, unregister });
            return handler2.Handler;
        }
    }
}

