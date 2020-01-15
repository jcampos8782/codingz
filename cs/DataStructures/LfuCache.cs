using System;
using System.Collections.Generic;
using System.Text;

namespace hello_dotnet_core.DataStructures
{
    // An example Least Frequently Used cache. Put and Get operations are O(1).
    // 
    public class LfuCache
    {
        // Key -> (Value, Fetches) 
        private Dictionary<string, (string, int)> _cache;

        // Max Cache Size
        private int _capacity;

        // # of Gets -> List of keys
        private Dictionary<int, List<string>> _getCount = new Dictionary<int, List<string>>();

        // The min of the fetchCount keys
        private int _leastRetrievedCount;

        public LfuCache(int capacity)
        {
            _capacity = capacity;
            _cache = new Dictionary<string,(string,int)>(capacity);
        }

        public void Put(string key, string value)
        {
           // If the key already exists, overwrite the value.
           // Don't reset the count though since the value should not impact
           // the number of retrievals of the key.
           if (_cache.ContainsKey(key)) {
                Replace(key, value);
                return;
           }

           // If the cache is full, remove the least frequently used key
           if(_cache.Count == _capacity) Pop();

            // Add this key to those which have never been fetched.
            List<string> neverRetrieved = _getCount.GetValueOrDefault(0);

            if (neverRetrieved == null)
            {
                _getCount[0] = neverRetrieved = new List<string>();
            }

            neverRetrieved.Add(key);
            _leastRetrievedCount = 0;
            _cache.Add(key, (value, 0));
        }

        public string Get(string key)
        {
            // If the key is not cached, return null
            if (!_cache.ContainsKey(key)) return null;

            (string value, int count) = _cache[key];

            // Remove this key from the existing count and add it to count + 1
            List<string> keysForCount = _getCount[count];
            keysForCount.Remove(key);

            // Perform some maintenance if no more keys have been fetched for this count
            if(keysForCount.Count == 0)
            {
                // Free up some space
                _getCount.Remove(count);

                // Increment the leastRetreivedCount if the fetched item was the
                // least frequently retrieved
                if (count == _leastRetrievedCount) _leastRetrievedCount++;
            }

            // Add the key to the list of items with count + 1 gets
            count++;
            List<string> keysForIncrement = _getCount.GetValueOrDefault(count);
            if (keysForIncrement == null)
            {
                _getCount[count] = keysForIncrement = new List<string>();
            }

            // Update the count in the cache.
            _getCount[count].Add(key);
            _cache[key] = (value, count);

            return value;
        }

        // Replaces the value of the existing key without changing the number of
        // fetches.
        private void Replace(string key, string value)
        {
            _cache.TryGetValue(key, out (string _, int fetches) existing);
            _cache[key] = (value, existing.fetches);
            return;
        }

        // Removes the least frequently used item from the cache.
        private void Pop()
        {
            // Possible more than one key has been retrieved _leastRetrievedCount
            // times. Removing from the front of this list gets FIFO semantics.
            // Not only do we remove one of the least recently used, but we remove
            // the key which has been in the cache longer
            List<string> leastRetrievedKeys = _getCount[_leastRetrievedCount];
            string keyToRemove = leastRetrievedKeys[0];
            leastRetrievedKeys.RemoveAt(0);
            _cache.Remove(keyToRemove);
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();

            foreach(string s in _cache.Keys)
            {
                (string v, int c) = _cache[s];
                b.Append($"{v}:{c}\n");
            }
            return b.ToString();
        }
    }
}
