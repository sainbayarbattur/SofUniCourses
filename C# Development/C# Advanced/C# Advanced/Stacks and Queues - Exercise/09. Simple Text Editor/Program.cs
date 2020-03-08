namespace Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var previous = new Stack<string>();

            StringBuilder text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] token = input.Split().ToArray();

                switch (token[0])
                {
                    case "1":
                        previous.Push(text.ToString());
                        text.Append(token[1]);
                        break;
                    case "2":
                        previous.Push(text.ToString());
                        int removeIndex = int.Parse(token[1]);
                        text.Remove(text.Length - removeIndex, removeIndex);
                        break;
                    case "3":
                        int index = int.Parse(token[1]) - 1;
                        Console.WriteLine(text[index]);
                        break;
                    case "4":
                        text.Clear();
                        text.Append(previous.Pop());
                        break;
                }
            }
        }
    }
}
