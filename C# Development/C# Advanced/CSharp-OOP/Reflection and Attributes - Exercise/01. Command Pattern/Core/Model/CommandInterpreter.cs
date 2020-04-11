namespace CommandPattern.Core.Model
{
    using CommandPattern.Core.Contracts;
    using System;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string commandName = args.Split(' ')[0];

            var type = Type.GetType($"CommandPattern.Core.Model.{commandName}Command");

            var result = (ICommand)Activator.CreateInstance(type);

            return result.Execute(args.Split(' '));
        }
    }
}