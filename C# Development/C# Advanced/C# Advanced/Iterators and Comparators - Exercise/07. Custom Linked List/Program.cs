namespace _07._Custom_Linked_List
{
    using Generics___Exercise;
    using System;

    public class Program
    {
        public static void Main()
        {
            var cll = new CustomLinkedList<int>();

            for (int i = 0; i < 8; i++)
            {
                cll.AddFirst(i);
            }

            foreach (var item in cll)
            {
                Console.WriteLine(item);
            }
        }
    }
}