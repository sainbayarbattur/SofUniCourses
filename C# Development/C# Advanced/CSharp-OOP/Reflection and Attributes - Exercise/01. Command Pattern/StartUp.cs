namespace CommandPattern
{
    using System;
    using CommandPattern.Core.Model;
    using CommandPattern.Core.Contracts;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommandInterpreter command = new CommandInterpreter();

            new Engine(command).Run();
        }
    }
}