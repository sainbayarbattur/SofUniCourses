namespace CommandPattern.Core.Model
{
    using CommandPattern.Core.Contracts;

    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args[1]}";
        }
    }
}