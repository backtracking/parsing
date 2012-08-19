namespace Smi.VisualStudio.Shell.Extensions
{
    using Microsoft.VisualStudio.OLE.Interop;
    using System;
    using System.Diagnostics.Contracts;
    using System.Runtime.CompilerServices;
    using Smi;

    public static class IConnectionPointContainerExtensions
    {
        public static IDisposable Advise<TObject, TEventInterface>(this IConnectionPointContainer container, TObject @object) where TObject: class, TEventInterface where TEventInterface: class
        {
            IConnectionPoint point;
            uint num;
            System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(container != null, "container");
            System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(@object != null, "object");
            Guid gUID = typeof(TEventInterface).GUID;
            container.FindConnectionPoint(ref gUID, out point);
            if (point == null)
            {
                throw new ArgumentException();
            }
            point.Advise(@object, out num);
            return new ConnectionPointCookie(point, num);
        }

        public static void Unadvise<TEventInterface>(this IConnectionPointContainer container, uint cookie) where TEventInterface: class
        {
            System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(container != null, "container");
            if (cookie != 0)
            {
                IConnectionPoint point;
                Guid gUID = typeof(TEventInterface).GUID;
                container.FindConnectionPoint(ref gUID, out point);
                if (point == null)
                {
                    throw new ArgumentException();
                }
                point.Unadvise(cookie);
            }
        }

        private sealed class ConnectionPointCookie : IDisposable
        {
            private readonly WeakReference<IConnectionPoint> _connectionPoint;
            private uint _cookie;

            public ConnectionPointCookie(IConnectionPoint connectionPoint, uint cookie)
            {
                this._connectionPoint = new WeakReference<IConnectionPoint>(connectionPoint);
                this._cookie = cookie;
            }

            public void Dispose()
            {
                if (this._cookie != 0)
                {
                    IConnectionPoint target = this._connectionPoint.Target;
                    if (target != null)
                    {
                        target.Unadvise(this._cookie);
                        this._cookie = 0;
                    }
                }
            }
        }
    }
}

