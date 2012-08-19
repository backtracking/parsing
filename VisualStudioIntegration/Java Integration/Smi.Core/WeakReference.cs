namespace Smi
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class WeakReference<T> : WeakReference where T: class
    {
        public WeakReference(T target) : base(target)
        {
        }

        public WeakReference(T target, bool trackResurrection) : base(target, trackResurrection)
        {
        }

        public WeakReference(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public new T Target
        {
            get
            {
                return (T) base.Target;
            }
            set
            {
                base.Target = value;
            }
        }
    }
}

