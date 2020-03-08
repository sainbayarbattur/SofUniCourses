namespace Problem_11._Party_Reservation_Filter_Module
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            var trash = new Dictionary<string, List<string>>();

            while (true)
            {
                string currInput = Console.ReadLine();

                if (currInput == "Print") break;

                string[] token = currInput.Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = token[0];

                string filterType = token[1];

                string filterParameter = token[2];

                switch (command)
                {
                    case "Add filter":
                        if (filterType == "Starts with")
                        {
                            if (!trash.ContainsKey(filterParameter))
                            {
                                trash.Add(filterParameter, new List<string>());
                            }

                            foreach (var item in input.Where(x => x.StartsWith(filterParameter)).ToArray())
                            {
                                trash[filterParameter].Add(item);
                            }

                            input.RemoveAll(x => x.StartsWith(filterParameter));
                        }
                        else if (filterType == "Ends with")
                        {
                            if (!trash.ContainsKey(filterParameter))
                            {
                                trash.Add(filterParameter, new List<string>());
                            }

                            foreach (var item in input.Where(x => x.EndsWith(filterParameter)).ToArray())
                            {
                                trash[filterParameter].Add(item);
                            }

                            input.RemoveAll(x => x.EndsWith(filterParameter));
                        }
                        else if (filterType == "Length")
                        {
                            if (!trash.ContainsKey(filterParameter))
                            {
                                trash.Add(filterParameter, new List<string>());
                            }

                            foreach (var item in input.Where(x => x.Length == int.Parse(filterParameter)).ToArray())
                            {
                                trash[filterParameter].Add(item);
                            }

                            input.RemoveAll(x => x.Length == int.Parse(filterParameter));
                        }
                        else if (filterType == "Contains")
                        {
                            if (!trash.ContainsKey(filterParameter))
                            {
                                trash.Add(filterParameter, new List<string>());
                            }

                            foreach (var item in input.Where(x => x.Contains(filterParameter)).ToArray())
                            {
                                trash[filterParameter].Add(item);
                            }

                            input.RemoveAll(x => x.Contains(filterParameter));
                        }

                        break;
                    case "Remove filter":
                        if (filterType == "Starts with")
                        {
                            if (trash.ContainsKey(filterParameter))
                            {
                                foreach (var trashItem in trash[filterParameter])
                                {
                                    input.Add(trashItem);
                                }
                            }
                        }
                        else if (filterType == "Ends with")
                        {
                            if (trash.ContainsKey(filterParameter))
                            {
                                foreach (var trashItem in trash[filterParameter])
                                {
                                    input.Add(trashItem);
                                }
                            }
                        }
                        else if (filterType == "Length")
                        {
                            if (trash.ContainsKey(filterParameter))
                            {
                                foreach (var trashItem in trash[filterParameter])
                                {
                                    input.Add(trashItem);
                                }
                            }
                        }
                        else if (filterType == "Contains")
                        {
                            if (trash.ContainsKey(filterParameter))
                            {
                                foreach (var trashItem in trash[filterParameter])
                                {
                                    input.Add(trashItem);
                                }
                            }
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(' ', input));
        }
    }
}
