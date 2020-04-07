namespace Problem8CollectionHierarchy
{
    using System;
    using System.Linq;
    using Problem8CollectionHierarchy.Model;

    public class Program
    {
        public static void Main()
        {
            string[] collection = Console.ReadLine().Split(' ').ToArray();

            int removeCount = int.Parse(Console.ReadLine());

            var addCollection = new AddCollection();

            var addRemoveCollection = new AddRemoveCollection();

            var myList = new MyList();

            for (int i = 0; i < collection.Length; i++)
            {
                var index = addCollection.Add(collection[i]);
                Console.Write(index + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < collection.Length; i++)
            {
                var index = addRemoveCollection.Add(collection[i]);
                Console.Write(index + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < collection.Length; i++)
            {
                var index = myList.Add(collection[i]);
                Console.Write(index + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < removeCount; i++)
            {
                var index = addRemoveCollection.Remove();
                Console.Write(index + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < removeCount; i++)
            {
                var index = myList.Remove();
                Console.Write(index + " ");
            }
        }
    }
}
