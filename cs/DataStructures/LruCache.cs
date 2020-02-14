using System;
using System.Collections.Generic;

namespace hello_dotnet_core.DataStructures
{
    public class LruCache<TKey,TValue> where TValue: struct
    {
        readonly Dictionary<TKey, Item<TKey,TValue>> _cache;
        readonly int _capacity;

        private Item<TKey,TValue> HEAD;
        private Item<TKey,TValue> TAIL;

        public LruCache(int capacity = 1024)
        {
            _capacity = capacity;
            _cache = new Dictionary<TKey, Item<TKey,TValue>>(capacity);
        }

        public void Add(TKey key, TValue value)
        {
            Item<TKey, TValue> item;
            if (_cache.ContainsKey(key))
            {
                item = _cache.GetValueOrDefault(key);
                Splice(item);
            }
            else
            {
                item = new Item<TKey, TValue>();
                item.key = key;
                item.value = value;
            }

            if (_cache.Count == _capacity)
            {
                Pop();
            }

            Append(item);
            _cache.Add(key, item);
        }

        public Nullable<TValue> Get(TKey key)
        {
            if(!_cache.ContainsKey(key))
            {
                return null;
            }

            var item = _cache.GetValueOrDefault(key);
            Splice(item);
            Append(item);

            return item.value;
        }

        private void Append(Item<TKey,TValue> item)
        {
            if (_cache.Count != 0)
            {
                HEAD.previous = item;
                item.next = HEAD;
            }

            HEAD = item;

            if (TAIL == null)
            {
                TAIL = item;
            }
        }

        private void Splice(Item<TKey,TValue> item)
        {
            var previous = item.previous;
            var next = item.next;

            if (next == null)
            {
                TAIL = previous;
            }
            else
            {
                next.previous = previous;
            }

            if (previous == null)
            {
                HEAD = next;
            }
            else
            {
                previous.next = next;
            }
        }

        private void Pop()
        {
            if (TAIL != null)
            {
                _cache.Remove(TAIL.key);
                TAIL = TAIL.previous;

                if (TAIL != null)
                {
                    TAIL.next = null;
                }
            }
        }
    }

    class Item<K,V>
    {
        public Item<K,V> previous;
        public Item<K,V> next;
        public K key;
        public V value;
    }
}
