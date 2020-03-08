using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> stack = new List<T>();

        public bool IsThereElements { get; set; }

        public void Pop()
        {
            if (stack.Count - 1 >= 0)
            {
                IsThereElements = true;
                stack.Remove(stack[stack.Count - 1]);
            }
            else
            {
                IsThereElements = false;
            }
        }

        public void Push(List<T> element)
        {
            IsThereElements = true;

            stack.AddRange(element);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
