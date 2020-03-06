using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputData = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split(' ');

                string command = tokens[0];

                switch(command)
                {
                    case "Add":

                        int elementToAdd = int.Parse(tokens[1]);

                        inputData.Add(elementToAdd);
                        break;
                    case "Insert":
                        int number = int.Parse(tokens[1]);

                        int insertIndex = int.Parse(tokens[2]);

                        if (insertIndex < 0 || insertIndex > inputData.Count)
                        {
                            Console.WriteLine("Invalid index");

                            input = Console.ReadLine();

                            continue;
                        }

                        inputData.Insert(insertIndex, number);

                        break;
                    case "Remove":

                        int removeIndex = int.Parse(tokens[1]);
                        if (removeIndex < 0 || removeIndex > inputData.Count -1)
                        {
                            Console.WriteLine("Invalid index");

                            input = Console.ReadLine();

                            continue;
                        }

                        inputData.RemoveAt(removeIndex);

                        break;
                    case "Shift":
                        string direction = tokens[1];

                        int count = int.Parse(tokens[2]);

                        if (direction == "left")
                        {
                            inputData = GetLeft(inputData, count);

                            
                        }
                        else
                        {
                            inputData = GetRight(inputData, count);
                            
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join( " ",inputData));
        }
        private static List<int> GetRight(List<int> inputData, int count)
        {
            for (int i = 0; i < count % inputData.Count; i++)
            {
                int temp = inputData[inputData.Count -1];
                inputData.RemoveAt(inputData.Count -1);
                inputData.Insert(0,temp);
            }
            return inputData;
        }

        private static List<int> GetLeft(List<int> inputData, int count)
        {
            for (int i = 0; i < count% inputData.Count; i++)
            {
                int temp = inputData[0];
                inputData.RemoveAt(0);
                inputData.Add(temp);
            }
            return inputData;
        }
    }
}