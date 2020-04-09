using System.Collections;
using System.Collections.Generic;

namespace _5StackofStrings
{
    public class StackOfStrings : Stack<string>
    {
        public bool isEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(Stack<string> input)
        {
            foreach (var item in input)
            {
                this.Push(item);
            }
            
            return this;
        }
    }
}