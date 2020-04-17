namespace _10._Crossroads
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int greenLightDurationInput = int.Parse(Console.ReadLine());
            int freeWindowtDurationInput = int.Parse(Console.ReadLine());

            var greenLightDuration = greenLightDurationInput;
            var freeWindowtDuration = freeWindowtDurationInput;

            string command = Console.ReadLine();

            int carsPassed = 0;

            while (command != "END")
            {
                if (command == "green")
                {
                    greenLightDuration = greenLightDurationInput;
                    freeWindowtDuration = freeWindowtDurationInput;
                }
                else if (greenLightDuration > 0)
                {
                    var timeToPass = greenLightDuration + freeWindowtDuration;

                    var queue = new Queue<char>(command.ToCharArray());

                    while (timeToPass > 0 && queue.Count > 0)
                    {
                        timeToPass--;

                        queue.Dequeue();

                        if (greenLightDuration > 0)
                        {
                            greenLightDuration--;
                        }
                        else
                        {
                            freeWindowtDuration--;
                        }
                    }

                    if (queue.Count > 0)
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{command} was hit at {queue.First()}.");
                        return;
                    }

                    carsPassed++;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}