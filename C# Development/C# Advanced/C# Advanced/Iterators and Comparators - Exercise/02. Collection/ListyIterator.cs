using System;
using System.Collections;
using System.Collections.Generic;

namespace Problem_1._ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private int currIndex;
        private List<T> List;
        public string command { get; set; }

        public ListyIterator(List<T> list)
        {
            this.List = list;
            currIndex = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                currIndex++;
                return true;
            }

            return false;
        }

        public string Print()
        {
            if (List.Count > 0)
            {
                return List[currIndex].ToString();
            }

            return "Invalid Operation!";
        }

        public bool HasNext()
        {
            if (currIndex + 1 <= List.Count - 1 && List.Count > 0)
            {
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < List.Count; i++)
            {
                yield return List[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
