using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Goja
{
    public class GameComponentsCollection : IEnumerable, IEnumerable<GameComponent>, ICollection, ICollection<GameComponent>, IReadOnlyCollection<GameComponent>
    {
        #region Properties
        private ICollection _collectionOfItems
        {
            get
            {
                return ((ICollection)_items);
            }
        }
        private ICollection<GameComponent> _collectionOfT
        {
            get
            {
                return ((ICollection<GameComponent>)_items);
            }
        }
        private IEnumerable<GameComponent> _enumerableT
        {
            get
            {
                return ((IEnumerable<GameComponent>)_items);
            }
        }
        #endregion
        #region Fields
        public bool IsFixedSize = false;

        private int _currentElement = 0;
        private int _size = 0;
        private static readonly GameComponent[] s_emptyArray = new GameComponent[0];
        private GameComponent[] _items;
        #endregion

        public GameComponentsCollection()
        {
            _currentElement = 0;
            _size = 0;
            _items = new GameComponent[_size];
        }

        public GameComponentsCollection(int size)
        {
            _currentElement = 0;
            _size = size;
            _items = new GameComponent[_size];
        }

        public GameComponent this[int id]
        {
        	get { return _items[id]; }
        	set { _items[id] = value; }
        }

        public GameComponent[] ToArray()
        {
            if (_size == 0)
                return GameComponentsCollection.s_emptyArray;
            GameComponent[] array = new GameComponent[_size];
            Array.Copy(_items, array, _size);
            return array;
        }

        public void Add(GameComponent item)
        {
            if (_currentElement >= _size && IsFixedSize == false)
                _size++;
            GameComponent[] _itemsCopy = new GameComponent[_size];
            for (int i = 0; i < _items.Length; i++)
                _itemsCopy[i] = _items[i];
            _itemsCopy[_currentElement] = item;
            _items = _itemsCopy.ToArray();
            _currentElement++;
            item.Initialize();
        }

        public void Clear()
        {
            _currentElement = 0;
            _size = 0;
            _items = new GameComponent[_size];
        }

        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator<GameComponent> IEnumerable<GameComponent>.GetEnumerator()
        {
            return _enumerableT.GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            _items.CopyTo(array, index);
        }

        public bool Contains(GameComponent item)
        {
            return _collectionOfT.Contains(item);
        }

        public void CopyTo(GameComponent[] array, int arrayIndex)
        {
            _collectionOfT.CopyTo(array, arrayIndex);
        }

        public bool Remove(GameComponent item)
        {
            return _collectionOfT.Remove(item);
        }

        public int Count { get { return _collectionOfItems.Count; } }
        public bool IsSynchronized { get { return _items.IsSynchronized; } }
        public object SyncRoot { get { return _items.SyncRoot; } }
        public bool IsReadOnly { get { return  _collectionOfT.IsReadOnly; } }

        public override bool Equals(object obj)
        {
        	return true;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            string stringTypeOfT = typeof(GameComponent).ToString();
            return stringTypeOfT;
            //return $"{{Size: {Count}, IsFixedSize: {IsFixedSize}, TypeOfElements: {stringTypeOfT} }}";
        }
    }
}