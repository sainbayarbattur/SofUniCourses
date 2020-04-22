namespace Generics___Exercise
{
    using System.Linq;

    public class CustomLinkedList<T>
    {
        private T[] collection;
        private readonly T T_DEFAULT = default(T);

        public CustomLinkedList(int length)
        {
            this.collection = new T[length];
        }

        public int Count => this.collection.Where(c => c != null).Count();

        public CustomLinkedList<T> AddLast(T item) 
        {
            this.collection[this.collection.Length - 1] = item;

            return this;
        }

        public CustomLinkedList<T> AddFirst(T item)
        {
            this.collection[0] = item;

            return this;
        }

        public CustomLinkedList<T> RemoveLast(T item)
        {
            this.collection[this.collection.Length - 1] = T_DEFAULT;

            return this;
        }

        public CustomLinkedList<T> RemoveFirst(T item)
        {
            this.collection[0] = T_DEFAULT;

            return this;
        }
    }
}