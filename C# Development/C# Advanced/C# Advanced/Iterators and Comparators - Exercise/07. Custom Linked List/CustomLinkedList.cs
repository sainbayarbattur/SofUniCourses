namespace Generics___Exercise
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomLinkedList<T> : IEnumerable<T>
    {
        private List<T> collection;

        public CustomLinkedList()
        {
            this.collection = new List<T>();
        }

        public int Count => this.collection.Where(c => c != null).Count();

        public CustomLinkedList<T> AddLast(T item) 
        {
            this.collection.Insert(this.collection.Count - 1, item);

            return this;
        }

        public CustomLinkedList<T> AddFirst(T item)
        {
            this.collection.Insert(0, item);

            return this;
        }

        public CustomLinkedList<T> RemoveLast()
        {
            this.collection.RemoveAt(this.collection.Count - 1);

            return this;
        }

        public CustomLinkedList<T> RemoveFirst()
        {
            this.collection.RemoveAt(0);

            return this;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.collection.Count; i++)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}