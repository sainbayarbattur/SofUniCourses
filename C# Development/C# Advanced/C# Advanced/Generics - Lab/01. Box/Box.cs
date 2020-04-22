namespace BoxOfT
{
    using System.Collections.Generic;

    public class Box<T>
    {
        private Stack<T> box;

        public Box()
        {
            this.box = new Stack<T>();
        }

        public T Remove()
        {
            return this.box.Pop();
        }

        public void Add(T element)
        {
            this.box.Push(element);
        }

        public int Count => this.box.Count;
    }
}