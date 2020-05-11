namespace Object_Communication_and_Events_Lab
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var combatLogger = new CombatLogger();

            combatLogger.Handle(LogType.MAGIC, "fuck you");
        }
    }
}