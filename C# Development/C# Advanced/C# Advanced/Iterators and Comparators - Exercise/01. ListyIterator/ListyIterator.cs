using System;
using System.Collections.Generic;

namespace Problem_1._ListyIterator
{
    public class ListyIterator<T>
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
            else
            {
                return false;
            }
        }

        public string Print()
        {
            if (List.Count > 0)
            {
                return List[currIndex].ToString();
            }
            else
            {
                return "Invalid Operation!";
            }

        }

        public bool HasNext()
        {
            if (currIndex + 1 <= List.Count - 1 && List.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
