namespace Smartmobili.VisualStudio.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime.CompilerServices;


    public class LazyArray<T> : List<T>
    {
        private readonly Func<int, T> itemCreator;

        public LazyArray(int count, Func<int, T> itemCreator):base(count)
        {
            this.itemCreator = itemCreator;
        }

        new public T this[int index]
        {
            get
            {
                if (index >= base.Count)
                {
                    for (int i = base.Count; i <= index; i++)
                    {
                        this.Add(this.itemCreator(index));
                    }
                }
                return base[index];
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }


    //public class LazyArray<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
    //{
    //    private readonly int count;
    //    private readonly Func<int, T> itemCreator;

    //    internal LazyArray(int count, Func<int, T> itemCreator)
    //    {
    //        this.count = count;
    //        this.itemCreator = itemCreator;
    //    }

    //    public void Add(T item)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Clear()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Contains(T item)
    //    {
    //        return (this.IndexOf(item) >= 0);
    //    }

    //    public void CopyTo(T[] array, int arrayIndex)
    //    {
    //        if (array == null)
    //        {
    //            throw new ArgumentNullException();
    //        }
    //        if (arrayIndex < 0)
    //        {
    //            throw new ArgumentOutOfRangeException("arrayIndex");
    //        }
    //        if (((array.Rank > 1) || (arrayIndex >= array.Length)) || ((array.Length - arrayIndex) < this.count))
    //        {
    //            throw new ArgumentException();
    //        }
    //        foreach (T local in this)
    //        {
    //            array[arrayIndex] = local;
    //            arrayIndex++;
    //        }
    //    }

    //    public IEnumerator<T> GetEnumerator()
    //    {
    //        int iteratorVariable0 = 0;
    //        while (true)
    //        {
    //            if (iteratorVariable0 >= this.count)
    //            {
    //                yield break;
    //            }
    //            yield return this[iteratorVariable0];
    //            iteratorVariable0++;
    //        }
    //    }

    //    public int IndexOf(T item)
    //    {
    //        int num = 0;
    //        foreach (T local in this)
    //        {
    //            if (local.Equals(item))
    //            {
    //                return num;
    //            }
    //            num++;
    //        }
    //        return -1;
    //    }

    //    public void Insert(int index, T item)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public bool Remove(T item)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void RemoveAt(int index)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return this.GetEnumerator();
    //    }

    //    public int Count
    //    {
    //        get
    //        {
    //            return this.count;
    //        }
    //    }

    //    public bool IsReadOnly
    //    {
    //        get
    //        {
    //            return true;
    //        }
    //    }

    //    public T this[int index]
    //    {
    //        get
    //        {
    //            return this.itemCreator(index);
    //        }
    //        set
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }
    //}
}

