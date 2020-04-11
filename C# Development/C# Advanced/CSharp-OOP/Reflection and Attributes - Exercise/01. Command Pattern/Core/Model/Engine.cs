namespace CommandPattern.Core.Model
{
    using CommandPattern.Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string line = Console.ReadLine();

            while (true)
            {
                Console.WriteLine(commandInterpreter.Read(line));

                line = Console.ReadLine();
            }
        }
    }
}
