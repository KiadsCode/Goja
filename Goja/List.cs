using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleList
{
    internal class List<T> : IEnumerable, IEnumerable<T>, ICollection, ICollection<T>, IReadOnlyCollection<T>
    {
        #region Properties
        private ICollection _collectionOfItems
        {
            get
            {
                return ((ICollection)_items);
            }
        }
        private ICollection<T> _collectionOfT
        {
            get
            {
                return ((ICollection<T>)_items);
            }
        }
        private IEnumerable<T> _enumerableT
        {
            get
            {
                return ((IEnumerable<T>)_items);
            }
        }
        #endregion
        #region Fields
        public bool IsFixedSize = false;

        private int _currentElement = 0;
        private int _size = 0;
        private static readonly T[] s_emptyArray = new T[0];
        private T[] _items;
        #endregion

        public List()
        {
            _currentElement = 0;
            _size = 0;
            _items = new T[_size];
        }

        public List(int size)
        {
            _currentElement = 0;
            _size = size;
            _items = new T[_size];
        }

        public T this[int id]
        {
            get => _items[id];
            set => _items[id] = value;
        }

        public T[] ToArray()
        {
            if (_size == 0)
                return List<T>.s_emptyArray;
            T[] array = new T[_size];
            Array.Copy(_items, array, _size);
            return array;
        }

        public void Add(T item)
        {
            if (_currentElement >= _size && IsFixedSize == false)
                _size++;
            T[] _itemsCopy = new T[_size];
            for (int i = 0; i < _items.Length; i++)
                _itemsCopy[i] = _items[i];
            _itemsCopy[_currentElement] = item;
            _items = _itemsCopy.ToArray();
            _currentElement++;
        }

        public void Clear()
        {
            _currentElement = 0;
            _size = 0;
            _items = new T[_size];
        }

        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _enumerableT.GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            _items.CopyTo(array, index);
        }

        public bool Contains(T item)
        {
            return _collectionOfT.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _collectionOfT.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _collectionOfT.Remove(item);
        }

        public int Count => _collectionOfItems.Count;
        public bool IsSynchronized => _items.IsSynchronized;
        public object SyncRoot => _items.SyncRoot;
        public bool IsReadOnly => _collectionOfT.IsReadOnly;

        public override bool Equals(object obj)
        {
            return obj is List<T> list &&
                   EqualityComparer<ICollection>.Default.Equals(_collectionOfItems, list._collectionOfItems) &&
                   EqualityComparer<ICollection<T>>.Default.Equals(_collectionOfT, list._collectionOfT) &&
                   EqualityComparer<IEnumerable<T>>.Default.Equals(_enumerableT, list._enumerableT) &&
                   _size == list._size &&
                   EqualityComparer<T[]>.Default.Equals(_items, list._items) &&
                   Count == list.Count &&
                   IsSynchronized == list.IsSynchronized &&
                   EqualityComparer<object>.Default.Equals(SyncRoot, list.SyncRoot) &&
                   IsReadOnly == list.IsReadOnly;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            string stringTypeOfT = typeof(T).ToString();
            return $"{{Size: {Count}, IsFixedSize: {IsFixedSize}, TypeOfElements: {stringTypeOfT} }}";
        }
    }
}