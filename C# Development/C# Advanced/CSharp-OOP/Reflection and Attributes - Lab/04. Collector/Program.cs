namespace _1Stealer
{
    using System;
    using _1Stealer.Model;

    public class Program
    {
        public static void Main()
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersAndSetters("Hacker");
            Console.WriteLine(result);
        }
    }
}