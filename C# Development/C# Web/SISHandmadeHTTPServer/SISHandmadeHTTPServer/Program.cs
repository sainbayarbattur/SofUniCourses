namespace Chronometer
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var chronometer = new Chronometer();

            var line = Console.ReadLine();

            while (line != "exit")
            {
                if (line == "lap")
                {
                    Console.WriteLine(chronometer.Lap());
                }
                else if(line == "start")
                {
                    chronometer.Start();
                }
                else if (line == "stop")
                {
                    chronometer.Stop();
                }
                else if (line == "time")
                {
                    Console.WriteLine(chronometer.GetTime);
                }
                else if (line == "laps")
                {
                    int count = 0;

                    foreach (var lap in chronometer.Laps)
                    {
                        Console.WriteLine(count + ". " + lap);

                        count++;
                    }
                }


                line = Console.ReadLine();
            }
        }
    }
}
