using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Iot.Shared.Cache
{
    public interface ICache<K, T>
    {
        bool TryGet(K key, out T obj);


        void InsertOrUpdate(K key, T obj);
    }
}
