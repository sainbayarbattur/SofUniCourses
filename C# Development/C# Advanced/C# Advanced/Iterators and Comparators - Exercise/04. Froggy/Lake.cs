using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4._Froggy
{
    class Lake : IEnumerable<int>
    {
        private List<int> lake = new List<int>();

        public List<int> Result { get; set; } = new List<int>();

        public void AddLake(List<int> lakeToAdd)
        {
            for (int i = 0; i < lakeToAdd.Count; i++)
            {
                lake.Add(lakeToAdd[i]);
            }

            for (int i = 0; i < lake.Count; i+=2)
            {
                //if (lake[i] % 2 != 0)
                {
                    Result.Add(lake[i]);
                }
            }

            var secondPart = new List<int>();

            for (int i = 1; i < lake.Count; i+=2)
            {
                //if (lake[i] % 2 == 0)
                {
                    secondPart.Add(lake[i]);
                }
            }

            secondPart.Reverse();

            Result.AddRange(secondPart);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Result.Count; i++)
            {
                yield return Result[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
