using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DD_Character.Utilitaire.Eventless
{
    public class SetableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IGetable<IDictionary<TKey, TValue>>
    {

        private readonly Dictionary<TKey, TValue> _dictionary;

        public SetableDictionary(IEnumerable<KeyValuePair<TKey, TValue>> dictionary)
        {
            _dictionary = dictionary.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        public event Action Changed;
        public event Action<int> Added;
        public event Action<int> Updated;
        public event Action<int> Removed;
        public event Action Cleared;

        #region IGetable

        public IDictionary<TKey, TValue> Value
        {
            get
            {
                Computed.Listeners.Notify(this);
                return _dictionary;
            }
        }

        public Func<TValue, TValue, bool> EqualityComparer { get; set; }

        private void Writing(Action<int> also = null, int index = -1)
        {
            var evt = Changed;
            if (evt != null)
                evt();

            if (also != null)
                also(index);
        }

        #endregion

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            Computed.Listeners.Notify(this);
            return _dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).Add(item);
            Writing(Added);
        }

        public void Clear()
        {
            _dictionary.Clear();
            Writing();
            if (Cleared != null)
            {
                Cleared();
            }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            Computed.Listeners.Notify(this);
            return ((ICollection<KeyValuePair<TKey, TValue>>) _dictionary).Contains(item);
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            Computed.Listeners.Notify(this);
            ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).CopyTo(array, arrayIndex);
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            Computed.Listeners.Notify(this);
            var result = ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).Remove(item);
            Writing(Removed);
            return result;
        }

        public int Count
        {
            get
            {
                Computed.Listeners.Notify(this);
                return _dictionary.Count;
            }
        }

        public bool IsReadOnly { get { return false; } }

        public bool ContainsKey(TKey key)
        {
            Computed.Listeners.Notify(this);
            return _dictionary.ContainsKey(key);
        }

        public void Add(TKey key, TValue value)
        {
            _dictionary.Add(key, value);
            Writing(Added);
        }

        public bool Remove(TKey key)
        {
            Computed.Listeners.Notify(this);
            var result = _dictionary.Remove(key);
            Writing(Removed);
            return result;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        public TValue this[TKey key]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public ICollection<TKey> Keys { get; private set; }
        public ICollection<TValue> Values { get; private set; }
        
    }
}
