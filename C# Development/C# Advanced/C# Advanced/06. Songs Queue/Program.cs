namespace Fashion_Boutique
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var songs = new Queue<string>();

            string line = Console.ReadLine();

            for (int i = 0; i < line.Split(", ").Length; i++)
            {
                songs.Enqueue(line.Split(", ")[i]);
            }

            line = Console.ReadLine();

            while (songs.Count > 0)
            {
                string command = line.Substring(0, line.Split(" ")[0].Length);
                string song = "";
                if (line.Split(" ").Length > 1)
                {
                    song = line.Substring(command.Length, line.Length - command.Length).TrimStart();
                }

                switch (command)
                {
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Add":
                        if (songs.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            songs.Enqueue(song);
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songs));
                        break;
                }

                line = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
