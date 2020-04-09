namespace Farm
{
    using _01._Single_Inheritance;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Puppy puppy = new Puppy();
            puppy.Eat();
            puppy.Bark();
            puppy.Weep();

        }
    }
}