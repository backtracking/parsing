namespace Smi.VisualStudio.Shell.Extensions
{
    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.OLE.Interop;
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.Diagnostics.Contracts;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class ServiceProviderExtensions
    {
        public static SVsServiceProvider AsVsServiceProvider(this System.IServiceProvider sp)
        {
            System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(sp != null, "sp");
            return new VsServiceProviderWrapper(sp);
        }

        public static TService GetService<TService>(this System.IServiceProvider sp)
        {
            return sp.GetService<TService, TService>();
        }

        public static TServiceInterface GetService<TServiceClass, TServiceInterface>(this System.IServiceProvider sp)
        {
            System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(sp != null, "sp");
            return (TServiceInterface)sp.GetService(typeof(TServiceClass));
        }

        public static TServiceInterface TryGetGlobalService<TServiceClass, TServiceInterface>(this Microsoft.VisualStudio.OLE.Interop.IServiceProvider sp) where TServiceInterface : class
        {
            TServiceInterface local2;
            System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(sp != null, "sp");
            Guid guidService = typeof(TServiceClass).GUID;
            Guid riid = typeof(TServiceClass).GUID;
            IntPtr obj = IntPtr.Zero;
            if (ErrorHandler.Failed(ErrorHandler.CallWithCOMConvention((Func<int>)(() => sp.QueryService(ref guidService, ref riid, out obj)))) || (obj == IntPtr.Zero))
            {
                return default(TServiceInterface);
            }
            try
            {
                TServiceInterface objectForIUnknown = (TServiceInterface)Marshal.GetObjectForIUnknown(obj);
                local2 = objectForIUnknown;
            }
            finally
            {
                Marshal.Release(obj);
            }
            return local2;
        }

        public static Microsoft.VisualStudio.OLE.Interop.IServiceProvider TryGetOleServiceProvider(this System.IServiceProvider sp)
        {
            System.Diagnostics.Contracts.Contract.Requires<ArgumentNullException>(sp != null, "sp");
            return (Microsoft.VisualStudio.OLE.Interop.IServiceProvider)sp.GetService(typeof(Microsoft.VisualStudio.OLE.Interop.IServiceProvider));
        }
    }
}

