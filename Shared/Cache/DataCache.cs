using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Web.Iot.Shared.Cache
{
    public class DataCache<K, SK, T> : ICache<K, T>
    {
        private readonly IDictionary<SK, T> _data = new ConcurrentDictionary<SK, T>();


        private readonly Func<K, SK> keyFunc;


        public DataCache(Func<K, SK> keyFunc)
        {
            this.keyFunc = keyFunc;
        }


        public void InsertOrUpdate(K key, T obj)
        {
            SK subKey = keyFunc.Invoke(key);

            if (_data.ContainsKey(subKey))
                _data[subKey] = obj;
            else
                _data.Add(subKey, obj);
        }


        public bool TryGet(K key, out T obj)
        {
            SK subKey = keyFunc.Invoke(key);

            obj = default;

            if(_data.ContainsKey(subKey))
            {
                obj = _data[subKey];
                return true;
            }

            return false;
        }
    }
}
