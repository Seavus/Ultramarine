using System.Collections;
using System.Collections.Generic;

namespace Ultramarine.Generators.Tasks.Library.Contracts
{
    public class TaskCollection : IList<Task>
    {
        private readonly Task _parent;
        private readonly IList<Task> _collection;

        public TaskCollection(Task parent)
        {
            _parent = parent;
            _collection = new List<Task>();
        }
        public int IndexOf(Task item)
        {
            return _collection.IndexOf(item);
        }

        public void Insert(int index, Task item)
        {
            if (item != null)
                item.Parent = _parent;
            _collection.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            var oldItem = _collection[index];
            _collection.RemoveAt(index);
            if (oldItem != null)
                oldItem.Parent = null;
        }

        public Task this[int index]
        {
            get
            {
                return _collection[index];
            }
            set
            {
                var oldItem = _collection[index];
                if (value != null)
                    value.Parent = _parent;
                _collection[index] = value;
                if (oldItem != null)
                    oldItem.Parent = null;
            }
        }

        public void Add(Task item)
        {
            if (item != null)
                item.Parent = _parent;
            _collection.Add(item);
        }

        public void Clear()
        {
            foreach (var item in _collection)
            {
                if (item != null)
                    item.Parent = null;
            }
            _collection.Clear();
        }

        public bool Contains(Task item)
        {
            return _collection.Contains(item);
        }

        public void CopyTo(Task[] array, int arrayIndex)
        {
            _collection.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _collection.Count; }
        }

        public bool IsReadOnly
        {
            get { return _collection.IsReadOnly; }
        }

        public bool Remove(Task item)
        {
            var b = _collection.Remove(item);
            if (item != null)
                item.Parent = null;
            return b;
        }

        public IEnumerator<Task> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (_collection as IEnumerable).GetEnumerator();
        }
    }
}
